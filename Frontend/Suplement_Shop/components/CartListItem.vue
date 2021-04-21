<template>
  <v-list-group-item class="d-flex justify-content-between align-items-center">
    <ul>
      <li v-for="item in cart.cartItems" :key="item.productId">
        <v-link :to="'/product/' + item.productId">{{
          item.productName
        }}</v-link
        >:{{ item.price }}
      </li>
    </ul>
    <br />
    <span>{{ cart.cartStatus }}</span>
  </v-list-group-item>
</template>

<script>
export default {
  name: "CartListItem",
  props: ["cart"],
};
</script>