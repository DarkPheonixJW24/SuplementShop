<template>
  <b-container>
    <b-card class="cart-card" no-body>
      <template v-slot:header>
        <h6 class="mb-0">Cart</h6>
      </template>
      <b-list-group flush>
        <template v-if="hasItems">
          <CartItem
            v-for="item in cartItems"
            :key="item.productId"
            :item="item"
            @increment="incrementCartItem(item.productId)"
            @decrement="decrementCartItem(item.productId)"
            @remove="removeCartItem(item.productId)"
          ></CartItem>
        </template>
        <b-list-group-item v-else href="#">No items</b-list-group-item>
      </b-list-group>
      <template v-slot:footer>
        <b-row>
          <b-col>
            <span>Total price: {{totalPrice}} ден.</span>
          </b-col>
          <b-col></b-col>
          <b-button class="pad" variant="danger" @click="clearCart()">Clear</b-button>
          <b-button class="pad" variant="primary" @click="buyCart()">Buy</b-button>
        </b-row>
      </template>
    </b-card>
  </b-container>
</template>

<script>
import CartItem from "@/components/CartItem.vue";
export default {
  components: {
    CartItem
  },
  computed: {
    cartState() {
      return this.$store.state.cartState;
    },
    cart() {
      return this.cartState.cart;
    },
    cartItems() {
      return this.cart ? this.cart.cartItems : [];
    },
    hasItems() {
      return this.cartItems.length;
    },
    totalPrice() {
      return this.cartItems
        .map(item => item.price * item.count)
        .reduce((a, b) => a + b, 0);
    },
    user() {
      return this.$store.state.userState.user;
    }
  },
  methods: {
    clearCart() {
      if (this.cart)
        this.$store.dispatch("clearCart", { cartId: this.cart.id });
    },
    buyCart() {
      if (this.user && this.cart)
        this.$store.dispatch("buyCart", {
          cartId: this.cart.id,
          userId: this.user.id
        });
    },
    incrementCartItem(productId) {
      if (this.cart) {
        this.$store.dispatch("incrementCartItem", {
          cartId: this.cart.id,
          productId: productId
        });
      }
    },
    decrementCartItem(productId) {
      if (this.cart) {
        this.$store.dispatch("decrementCartItem", {
          cartId: this.cart.id,
          productId: productId
        });
      }
    },
    removeCartItem(productId) {
      if (this.cart) {
        this.$store.dispatch("removeCartItem", {
          cartId: this.cart.id,
          productId: productId
        });
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.cart-card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  margin: 2rem 0;
}

.pad {
  margin-right: 1rem;
}
</style>