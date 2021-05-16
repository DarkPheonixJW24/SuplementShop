<template>
  <v-app>
    <v-app-bar app dark color="blue">
      <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>
      <v-toolbar-title to="/">Supplement Store</v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer" class="blue" dark app>
      <v-list>
        <v-list-item v-for="item in items" :key="item.title" :to="item.to" link>
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>

      <template v-slot:append>
        <div class="pa-2">
          <v-btn block> Logout </v-btn>
        </div>
      </template>
    </v-navigation-drawer>
    <v-main>
      <nuxt />
    </v-main>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      drawer: false,
      items: [
        {
          to: "/",
          title: "Home",
          icon: "mdi-home",
        },
        {
          to: "/about",
          title: "About",
          icon: "mdi-info",
        },
        {
          to: "/catalog",
          title: "Catalog",
          icon: "mdi-menu"
        }
      ],
    };
  },
};
</script>