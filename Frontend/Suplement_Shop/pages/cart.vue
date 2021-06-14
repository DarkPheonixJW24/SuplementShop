<template>
  <v-container>
    <v-card>
      <v-card-title> Cart </v-card-title>
      <v-card-text>
        <v-list flush>
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
          <v-list-item v-else>No items</v-list-item>
        </v-list>
        <v-divider />
        <span>Total price: {{ totalPrice }} ден.</span>
      </v-card-text>
      <v-card-actions>
        <v-btn outlined rounded color="red" @click="clearCart()">Clear</v-btn>
        <v-btn outlined rounded color="primary" @click="buyCart()">Buy</v-btn>
      </v-card-actions>
    </v-card>
    <stripe-checkout
      ref="checkoutRef"
      :pk="publishableKey"
      :session-id="sessionId"
    />
  </v-container>
</template>

<script>
import CartItem from "@/components/CartItem.vue";
import { StripeCheckout } from "@vue-stripe/vue-stripe";

export default {
  components: {
    CartItem,
    StripeCheckout,
  },
  data() {
    return {
      publishableKey:
        "pk_test_51IkvviLTOkIxXYKR5UyelTdSRz7u8VXLPKZe8LZQikQ28trVar9REM3YWZa6QShZd5935Ctv2KtX1Hwys1ECV6Lx00eCPBa63h",
      sessionId: "",
    };
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
      return this.cartItems?.length ?? false;
    },
    totalPrice() {
      return (
        this.cartItems
          ?.map((item) => item.price * item.count)
          ?.reduce((a, b) => a + b, 0) ?? 0
      );
    },
  },
  methods: {
    clearCart() {
      if (this.cart)
        this.$store.dispatch("cartState/clearCart", { cartId: this.cart.id });
    },
    buyCart() {
      if (this.cart) {
        this.$axios
          .post(`cart/buy/${this.cart.id}`, { cartId: this.cart.id })
          .then((r) => r.data)
          .then(
            (cart) => {
              this.sessionId = cart.sessionId;
              this.$refs.checkoutRef.redirectToCheckout();
            },
            (err) => console.error("Payment failed", err)
          );
      }
    },
    incrementCartItem(productId) {
      if (this.cart) {
        this.$store.dispatch("cartState/incrementCartItem", {
          cartId: this.cart.id,
          productId: productId,
        });
      }
    },
    decrementCartItem(productId) {
      if (this.cart) {
        this.$store.dispatch("cartState/decrementCartItem", {
          cartId: this.cart.id,
          productId: productId,
        });
      }
    },
    removeCartItem(productId) {
      if (this.cart) {
        this.$store.dispatch("cartState/removeCartItem", {
          cartId: this.cart.id,
          productId: productId,
        });
      }
    },
  },
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