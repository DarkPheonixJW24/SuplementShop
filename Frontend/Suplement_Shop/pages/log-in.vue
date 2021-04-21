<template>
  <v-container style="padding: 2rem;">
    <v-card title="Log in">
      <v-form @submit="onSubmit" @reset="onReset" v-if="show">
        <v-form-group
          id="input-group-1"
          label="Email address:"
          label-for="input-1"
          description="We'll never share your email with anyone else."
        >
          <v-form-input
            id="input-1"
            v-model="form.email"
            type="email"
            required
            placeholder="Enter email"
          ></v-form-input>
        </v-form-group>

        <v-form-group id="input-group-1" label="Password:" label-for="input-1">
          <v-form-input
            id="input-1"
            v-model="form.password"
            type="password"
            required
            placeholder="Enter password"
          ></v-form-input>
        </v-form-group>

        <v-link to="/register" style="display: inherit; text-align: center;">Dont have an account?</v-link>
        <br>
        <v-button type="submit" variant="primary">Submit</v-button>
        <v-button type="reset" variant="danger">Reset</v-button>
      </v-form>
      <v-card class="mt-3" header="Form Data Result">
        <pre class="m-0">{{ form }}</pre>
      </v-card>
    </v-card>
  </v-container>
</template>


<script>
export default {
  data() {
    return {
      form: {
        email: "",
        password: ""
      },
      show: true
    };
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      this.$store.dispatch("userState/logIn", this.form);
    },
    onReset(evt) {
      evt.preventDefault();
      // Reset our form values
      this.form.email = "";
      this.form.password = "";
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    }
  }
};
</script>