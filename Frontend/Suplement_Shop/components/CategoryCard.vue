<template>

  <router-link :to="'category/' + title" class="category-card">
    <img :src="image" />
    <Ribbon class="category-ribbon" :text="title"></Ribbon>

  </router-link>

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
.category-card {
  position: relative;
  border-radius: 0.5rem;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  transition-duration: 200ms;
  &:hover {
    box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
  }
}

.category-card img {
  width: 100%;
  min-height: 100px;
  border-radius: 0.5rem;
}

.category-ribbon {
  position: absolute;
  right: -20px;
  bottom: 70px;
}
</style>