<template>
  <v-container class="home">
    <div class="category-grid">
      <v-card v-for="cart in carts" :key="cart.id" class="rounded-xl">
        <v-card-text>
          <v-list>
            <v-list-item v-for="item in cart.cartItems" :key="item.id">
              <v-list-item-content>
                <v-list-item-title>{{ item.productName }}</v-list-item-title>
                <v-list-item-subtitle
                  >{{ item.price }}мкд * {{ item.count }} =
                  {{ item.price * item.count }}мкд</v-list-item-subtitle
                >
              </v-list-item-content>
            </v-list-item>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title
                  >Total: {{ calculateTotal(cart) }}мкд</v-list-item-title
                >
              </v-list-item-content>
            </v-list-item>
            <v-list-item>
              <v-list-item-content>
                <v-chip
                  dark
                  class="justify-center"
                  :color="statusToColor(cart.cartStatus)"
                  >{{ statusToText(cart.cartStatus) }}</v-chip
                >
              </v-list-item-content>
            </v-list-item>
          </v-list>
        </v-card-text>
      </v-card>
    </div>
  </v-container>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("cartHistoryState/loadCartHistory");
  },
  computed: {
    cartHistoryState() {
      return this.$store.state.cartHistoryState;
    },
    carts() {
      return this.cartHistoryState.carts ?? [];
    },
  },
  methods: {
    statusToText(status) {
      switch (status) {
        case 0:
          return "Active";
        case 1:
          return "Bought";
        case 2:
          return "Discarded";
        case 3:
          return "Processing";
        default:
          return status;
      }
    },
    statusToColor(status) {
      switch (status) {
        case 0:
          return "green darken-4";
        case 1:
          return "blue darken-4";
        case 2:
          return "gray darken-4";
        case 3:
          return "yellow darken-4";
        default:
          return status;
      }
    },
    calculateTotal(cart) {
      return cart.cartItems.reduce(
        (acc, item) => acc + item.price * item.count,
        0
      );
    },
  },
};
</script>

<style lang="scss" scoped>
.category-grid {
  display: grid;
  align-items: start;
  grid-template-columns: repeat(auto-fit, 300px);
  grid-gap: 1rem;
  margin: auto;
  padding: 1rem 1rem;
}
</style>