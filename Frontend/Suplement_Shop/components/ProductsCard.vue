<template>
  <v-card class="rounded-xl"> 
    <v-img :src="product.imageUrls[0]" max-height="500" />
    <Ribbon class="product-ribon" :text="product.price + ' ден.'"></Ribbon>
    <v-card-title>{{product.name}}</v-card-title>
    <v-card-actions>
      <v-btn text color="blue" dark small rounded :to="'/product/' + product.id" variant="primary" style="margin-right: 1rem;">Details</v-btn>
      <v-btn text color="blue" dark small rounded @click="addToCart()" variant="primary">Add to cart</v-btn>
    </v-card-actions>
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

</style>
