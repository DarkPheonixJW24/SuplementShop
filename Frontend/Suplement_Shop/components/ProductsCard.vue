<template>
  <b-card no-body class="product-card">
    <b-row no-gutters md="6">
      <b-card-img :src="product.imageUrls[0]" alt="Image" class="rounded-0"></b-card-img>
    </b-row>
    <b-row no-gutters md="6">
      <b-card-body :title="product.name">
        <b-link :to="'/manufacturer/' + product.manufacturer">{{product.manufacturer}}</b-link>
        <b-card-text class="product-description">{{product.description.slice(0, 150)}}...</b-card-text>
      </b-card-body>
    </b-row>
    <Ribbon class="product-ribon" :text="product.price + ' ден.'"></Ribbon>
    <template v-slot:footer>
      <b-button :to="'/product/' + product.id" variant="primary" style="margin-right: 1rem;">Details</b-button>
      <b-button @click="addToCart()" variant="primary">Add to cart</b-button>
    </template>
  </b-card>
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
