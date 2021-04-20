<template>
  <b-container class="products-container">
    <h1>{{ $route.params.manufacturer }}</h1>
    <div class="products-grid">
      <ProductsCard
        v-for="product in products"
        :key="product.id"
        :product="product"
        @add-to-cart="addToCart(product)"
      ></ProductsCard>
    </div>
  </b-container>
</template>

<script>
import ProductsCard from "@/components/ProductsCard.vue";

export default {
  name: "Manufacturer",
  components: {
    ProductsCard
  },
  mounted() {
    this.$store.dispatch("loadProductsByMannufacturer", this.$route.params.manufacturer);
  },
  computed: {
    productsState() {
      return this.$store.state.productsState;
    },
    loading() {
      return this.productsState.loading;
    },
    error() {
      return this.productsState.error;
    },
    products() {
      return this.productsState.products;
    },
    cart() {
      return this.$store.state.cartState.cart;
    }
  },
  methods: {
    addToCart(product) {
      if (this.cart) {
        this.$store.dispatch("addCartItem", {
          cartId: this.cart.id,
          cartItem: {
            productId: product.id,
            productName: product.name,
            price: product.price,
            count: 1
          }
        });
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.products-container {
  max-width: 1400px;
  margin: auto;
  padding: 2rem 2rem;
}

.products-grid {
  display: grid;
  align-items: center;
  grid-template-columns: repeat(auto-fit, minmax(400px, 1fr));
  grid-gap: 2rem;
}
</style>