<template>
  <v-list class="d-flex justify-content-between allign-items-center">
    <v-btn :to="'/product/' + item.productId" text
      >{{ item.productName }} - {{ item.price }}ден.</v-btn
    >
    <div class="count">
      <v-btn fab x-small color="red" elevation="0" dark @click="decrement()"
        ><v-icon>mdi-minus</v-icon></v-btn
      >
      <span>{{ item.count }}</span>
      <v-btn fab x-small color="green" elevation="0" dark @click="increment()"
        ><v-icon>mdi-plus</v-icon></v-btn
      >
    </div>
  </v-list>
</template>

<script>
export default {
  props: ["item"],
  methods: {
    increment() {
      this.$emit("increment");
    },

    decrement() {
      this.$emit("decrement");
    },

    remove() {
      this.$emit("remove");
    },
  },
};
</script>

<style lang="scss" scoped>
.count * {
  margin: 0 0.5rem;
}
</style>