<template>
  <div class="product-container">
    <v-container>
      <v-card no-body class="product-card" v-if="!loading && !error">
        <v-row no-gutters>
          <v-col>
            <v-carousel
              id="carousel-1"
              :interval="4000"
              controls
              indicators
              background="#ababab"
              img-width="1024"
              img-height="480"
              style="text-shadow: 1px 1px 2px #333;"
            >
              <v-carousel-slide v-for="image in product.imageUrls" :key="image" :img-src="image"></v-carousel-slide>

              <v-carousel-slide
                v-if="!product || !product.imageUrls.length"
                caption="Blank Image"
                img-blank
                img-alt="Blank image"
              ></v-carousel-slide>
            </v-carousel>
          </v-col>
          <v-col>
            <v-card-body :title="product.name">
              <v-link :to="'/manufacturer/' + product.manufacturer">{{product.manufacturer}}</v-link>
              <v-card-text class="product-description">{{product.description}}</v-card-text>
            </v-card-body>
          </v-col>
        </v-row>
        <Ribbon class="product-ribon" :text="product.price + ' ден.'"></Ribbon>
        <template v-slot:footer>
          <v-button @click="addToCart(product)" variant="primary">Add to cart</v-button>
        </template>
      </v-card>
      <div v-if="loading">Loading</div>
    </v-container>
  </div>
</template>

<script>
import Ribbon from "@/components/Ribbon.vue";

export default {
  components: {
    Ribbon
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
    }
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
            count: 1
          }
        });
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.product-container {
  max-width: 1400px;
  margin: auto;
  padding: 2rem 2rem;
}

.product-card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
}

.product-ribon {
  right: -21px;
  top: -22px;
}

.product-description {
  white-space: pre-wrap;
}
</style>