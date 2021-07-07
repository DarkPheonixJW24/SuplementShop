<template>
  <v-app>
    <v-app-bar app dark color="blue">
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title to="/">Supplement Store</v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer" class="blue" dark app temporary>
      <template v-slot:prepend>
        <v-list-item two-line>
          <v-list-item-content v-if="loggedIn">
            <v-list-item-title>{{ user.fullName }}</v-list-item-title>
          </v-list-item-content>

          <v-list-item-content v-else>
            <v-list-item-title>Guest</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </template>

      <v-divider></v-divider>

      <v-list>
        <v-list-item v-for="item in items" :key="item.title" :to="item.to" link>
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item to="/cart" link v-if="loggedIn">
          <v-list-item-icon>
            <v-icon>mdi-cart</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>Cart</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item to="/cart-history" link v-if="loggedIn">
          <v-list-item-icon>
            <v-icon>mdi-currency-usd-off</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>Cart history</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>

      <template v-slot:append>
        <div class="pa-2">
          <v-btn block rounded v-if="user.id" @click="logOut()"> Logout </v-btn>
          <v-btn block rounded v-else to="/log-in"> Log in </v-btn>
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
  name: "Default",
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
          icon: "mdi-dumbbell",
        },
        {
          to: "/catalog",
          title: "Catalog",
          icon: "mdi-menu",
        },
      ],
    };
  },
  methods: {
    logOut() {
      this.$store.dispatch("userState/logOut");
    },
  },
  computed: {
    userState() {
      return this.$store.state.userState;
    },
    user() {
      return {
        ...this.userState,
      };
    },
    loggedIn() {
      return !!this.user.id;
    },
  },
};
</script>