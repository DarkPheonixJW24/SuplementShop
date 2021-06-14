<template>
  <div class="product-container">
    <v-container>
      <template v-if="!loading && !error">
        <v-card class="rounded-xl">
          <v-carousel>
            <v-carousel-item
              v-for="image in product.imageUrls"
              :key="image"
              :src="image"
            ></v-carousel-item>
          </v-carousel>
        </v-card>

        <v-card class="mt-10 rounded-xl">
          <v-card-title>
            {{ product.name }}
          </v-card-title>
          <v-card-subtitle :to="'/manufacturer/' + product.manufacturer">
            <nuxt-link :to="'/manufacturer/' + product.manufacturer">
              {{ product.manufacturer }}</nuxt-link
            >
            <Ribbon
              class="product-ribon"
              :text="product.price + ' ден.'"
            ></Ribbon>
          </v-card-subtitle>
          <v-card-text class="product-description">
            {{ product.description }}
          </v-card-text>
          <v-card-actions>
            <v-spacer />
            <v-btn @click="addToCart(product)" color="primary" rounded
              >Add to cart</v-btn
            >
          </v-card-actions>
        </v-card>
      </template>

      <div v-if="loading">Loading</div>
    </v-container>
  </div>
</template>

<script>
import Ribbon from "@/components/Ribbon.vue";

export default {
  components: {
    Ribbon,
  },
  name: "Product",
  mounted() {
    this.$store.dispatch("productState/loadProduct", this.$route.params.id);
  },
  computed: {
    productState() {
      return this.$store.state.productState;
    },
    loading() {
      return this.productState.loading;
    },
    error() {
      return this.productState.error;
    },
    product() {
      return this.productState.product;
    },
    cart() {
      return this.$store.state.cartState.cart;
    },
  },
  methods: {
    addToCart(product) {
      if (this.cart) {
        this.$store.dispatch("cartState/addCartItem", {
          cartId: this.cart.id,
          cartItem: {
            productId: product.id,
            productName: product.name,
            price: product.price,
            count: 1,
          },
        });
      }
    },
  },
};
</script>

<style lang="scss" scoped>
.product-container {
  max-width: 1400px;
  margin: auto;
  padding: 2rem 2rem;
}

.product-ribon {
  right: -36px;
  top: -30px;
}

.product-description {
  white-space: pre-wrap;
}
</style>