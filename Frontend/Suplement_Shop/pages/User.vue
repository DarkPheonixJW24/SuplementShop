<template>
  <b-container>
    <b-card class="cart-card" no-body>
      <template v-slot:header>
        <h6 class="mb-0">History</h6>
      </template>
      <b-list-group flush>
        <template v-if="hasItems">
          <CartListItem v-for="cart in carts" :key="cart.id" :cart="cart"></CartListItem>
        </template>
        <b-list-group-item v-else href="#">No items</b-list-group-item>
      </b-list-group>
    </b-card>
  </b-container>
</template>

<script>
import CartListItem from "@/components/CartListItem.vue";

export default {
  components: {
    CartListItem
  },
  mounted() {
    this.$store.dispatch("loadCartHistory", {
      userId: this.$store.state.userState.user.id
    });
  },
  computed: {
    cartHistoryState() {
      return this.$store.state.cartHistoryState;
    },
    carts() {
      return this.cartHistoryState.carts ? this.cartHistoryState.carts : [];
    },
    hasItems() {
      return this.carts.length;
    }
  }
};
</script>