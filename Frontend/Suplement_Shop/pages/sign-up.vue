<template>
  <v-container style="padding: 2rem">
    <v-card>
      <v-card-title>Sign up</v-card-title>
      <v-card-text>
        <v-form @submit="onSubmit" @reset="onReset" v-if="show">
          <v-text-field label="Full name" v-model="form.fullName" />

          <v-text-field label="Email" v-model="form.email" />

          <v-text-field
            label="Enter password"
            type="password"
            v-model="form.password"
          />

          <v-text-field
            label="Repeat password"
            type="password"
            v-model="form.repeat"
          />

          <br />
          <v-btn type="reset" outlined rounded color="red">Reset</v-btn>
          <v-btn type="submit" outlined rounded color="primary">Submit</v-btn>
        </v-form>
      </v-card-text>
    </v-card>
  </v-container>
</template>


<script>
export default {
  layout: 'auth',
  data() {
    return {
      form: {
        email: "",
        password: "",
        repeat: "",
        fullName: "",
      },
      show: true,
    };
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      this.$store.dispatch("userState/register", this.form);
    },
    onReset(evt) {
      evt.preventDefault();
      // Reset our form values
      this.form.email = "";
      this.form.password = "";
      this.form.repeat = "";
      this.form.fullName = "";
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },
  },
};
</script>