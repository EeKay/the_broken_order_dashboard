<script setup lang="ts">
import { computed } from "vue";
import { useOrderStore } from "../stores/useOrderStore";
import { ORDER_STATUSES, STATUS_LABEL } from "../types";
import OrderCard from "./OrderCard.vue";

const props = defineProps<{ query: string }>();

const store = useOrderStore();

const grouped = computed(() => {
  const q = props.query.trim().toLowerCase();
  return Object.fromEntries(
    ORDER_STATUSES.map((status) => [
      status,
      store.orders.filter((order) => {
        const text =
          `${order.orderNumber} ${order.customerName} ${order.location} ${order.product} ${order.orderedBy}`.toLowerCase();
        const match = !q || text.includes(q);
        return order.status === status && match;
      }),
    ]),
  );
});
</script>

<template>
  <div class="board">
    <section v-for="status in ORDER_STATUSES" :key="status" class="column">
      <h2>
        {{ STATUS_LABEL[status] }}
        <span>{{ grouped[status].length }}</span>
      </h2>
      <OrderCard v-for="order in grouped[status]" :key="order.id" :order="order" />
      <p v-if="grouped[status].length === 0" class="empty">Geen bestellingen</p>
    </section>
  </div>
</template>
