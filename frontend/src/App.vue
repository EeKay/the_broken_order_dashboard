<script setup lang="ts">
import { computed } from "vue";
import { useRoute, useRouter } from "vue-router";
import { setAuthToken } from "./services/api";

const route = useRoute();
const router = useRouter();
const isLogin = computed(() => route.name === "login");

function logout() {
  setAuthToken(null);
  router.push({ name: "login" });
}
</script>

<template>
  <div class="app">
    <header class="top">
      <router-link class="brand" to="/">
        Leverportaal
        <span class="tag">Inkoop</span>
      </router-link>
      <nav v-if="!isLogin" class="nav">
        <router-link to="/">Bestellingen</router-link>
        <router-link to="/about">Over</router-link>
        <button type="button" class="linkish" @click="logout">Uitloggen</button>
      </nav>
    </header>
    <router-view />
  </div>
</template>
