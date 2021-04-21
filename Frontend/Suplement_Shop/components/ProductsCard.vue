<template>
  <v-card no-body class="product-card">
    <v-row no-gutters md="6">
      <v-card-img :src="product.imageUrls[0]" alt="Image" class="rounded-0"></v-card-img>
    </v-row>
    <v-row no-gutters md="6">
      <v-card-body :title="product.name">
        <v-link :to="'/manufacturer/' + product.manufacturer">{{product.manufacturer}}</v-link>
        <v-card-text class="product-description">{{product.description.slice(0, 150)}}...</v-card-text>
      </v-card-body>
    </v-row>
    <Ribbon class="product-ribon" :text="product.price + ' ден.'"></Ribbon>
    <template v-slot:footer>
      <v-button :to="'/product/' + product.id" variant="primary" style="margin-right: 1rem;">Details</v-button>
      <v-button @click="addToCart()" variant="primary">Add to cart</v-button>
    </template>
  </v-card>
</template>

<script>
import Ribbon from "./Ribbon.vue";

export default {
  components: {
    Ribbon
  },
  props: ["product"],
  name: "ProductsCard",
  methods: {
    addToCart() {
      this.$emit("add-to-cart");
    }
  }
};
</script>

<style lang="scss" scoped>
.product-ribon {
  right: -21px;
  top: -22px;
}

.product-card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  transition-duration: 200ms;
  &:hover {
    box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
  }
}

.product-description {
  white-space: pre-wrap;
}
</style>
