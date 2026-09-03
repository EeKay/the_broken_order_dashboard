<script setup lang="ts">
import { ref } from "vue";
import { useRouter } from "vue-router";
import { describeApiError, loginApi, setAuthToken } from "../services/api";

const router = useRouter();
const email = ref("");
const password = ref("");
const error = ref<string | null>(null);
const submitting = ref(false);

async function login() {
  error.value = null;
  submitting.value = true;
  try {
    const result = await loginApi(email.value.trim(), password.value);
    setAuthToken(result.token);
    await router.push({ name: "dashboard" });
  } catch (err) {
    error.value = describeApiError(err);
  } finally {
    submitting.value = false;
  }
}
</script>

<template>
  <section class="login">
    <p class="eyebrow">Leverportaal</p>
    <h1>Aanmelden</h1>
    <p class="lede">
      Bestellingen van hulpmiddelen en verbruiksmateriaal voor zorglocaties.
    </p>
    <p v-if="error" class="error">{{ error }}</p>
    <label>
      E-mail
      <input v-model="email" type="email" autocomplete="username" />
    </label>
    <label>
      Wachtwoord
      <input v-model="password" type="password" autocomplete="current-password" />
    </label>
    <button type="button" :disabled="submitting" @click="login">
      {{ submitting ? "Bezig…" : "Aanmelden" }}
    </button>
  </section>
</template>
