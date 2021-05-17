<template>
  <v-card elevation="5" class="rounded-xl" :to="'category/' + title">
    <v-img :src="image" class="rounded-xl" :to="'category/' + title"/>
    <Ribbon class="category-ribbon" :text="title"></Ribbon>
  </v-card>
</template>

<script>
import Ribbon from "./Ribbon.vue";

export default {
  components: {
    Ribbon
  },
  name: "CategoryCard",
  props: ["title", "image"]
};
</script>

<style lang="scss" scoped>


.category-ribbon {
  position: absolute;
  right: -20px;
  bottom: 80px;
}
</style>