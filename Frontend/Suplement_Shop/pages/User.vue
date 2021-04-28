<template>
  <v-container>
    <v-card class="cart-card" no-body>
      <template v-slot:header>
        <h6 class="mv-0">History</h6>
      </template>
      <v-list-group flush>
        <template v-if="hasItems">
          <CartListItem
            v-for="cart in carts"
            :key="cart.id"
            :cart="cart"
          ></CartListItem>
        </template>
        <v-list-group-item v-else href="#">No items</v-list-group-item>
      </v-list-group>
    </v-card>
  </v-container>
</template>

<script>
import CartListItem from "@/components/CartListItem.vue";

export default {
  components: {
    CartListItem,
  },
  mounted() {
    this.$store.dispatch("userState/loadCartHistory");
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
    },
  },
};
</script>