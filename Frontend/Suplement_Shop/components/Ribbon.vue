<template>
  <div class="m-ribbon" v-bind:title="text"></div>
</template>

<script>
export default {
  name: "Ribbon",
  props: ["text"]
};
</script>

<style lang="scss" scoped>
.m-ribbon {
  position: relative;
}

*,
*::before,
*::after {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

.m-ribbon::before {
  position: absolute;
  content: "";
  background: linear-gradient(45deg, #0000, #0000 50%, #0070ff 50%, #0070ff);
  height: 28px;
  width: 28px;
  transform: rotate(45deg);
  right: 6px;
  bottom: -54px;
}

.m-ribbon::after {
  position: absolute;
  color: white;
  content: attr(title);
  padding: 0.5rem;
  width: 10rem;
  background: #007bff;
  text-align: center;
  font-family: "Roboto", sans-serif;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  right: 0;
}
</style>