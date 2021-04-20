<template>
  <b-container style="padding: 2rem;">
    <b-card title="Register">
      <b-form @submit="onSubmit" @reset="onReset" v-if="show">
        <b-form-group
          id="input-group-1"
          label="Email address:"
          label-for="input-1"
          description="We'll never share your email with anyone else."
        >
          <b-form-input
            id="input-1"
            v-model="form.email"
            type="email"
            required
            placeholder="Enter email"
          ></b-form-input>
        </b-form-group>

        <b-form-group
          id="input-group-1"
          label="Full name:"
          label-for="input-full-name"
        >
          <b-form-input
            id="input-full-name"
            v-model="form.fullName"
            required
            placeholder="Enter full name"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-1" label="Password:" label-for="input-1">
          <b-form-input
            id="input-1"
            v-model="form.password"
            type="password"
            required
            placeholder="Enter password"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-1" label="Repeat password:" label-for="input-1">
          <b-form-input
            id="input-1"
            v-model="form.repeat"
            type="password"
            required
            placeholder="Repeat password"
          ></b-form-input>
        </b-form-group>
        <b-link
          to="/log-in"
          style="display: inherit; text-align: center;"
        >Already have an account? Log in.</b-link>
        <br />
        <b-button type="submit" variant="primary">Submit</b-button>
        <b-button type="reset" variant="danger">Reset</b-button>
      </b-form>
      <b-card class="mt-3" header="Form Data Result">
        <pre class="m-0">{{ form }}</pre>
      </b-card>
    </b-card>
  </b-container>
</template>


<script>
export default {
  data() {
    return {
      form: {
        email: "",
        password: "",
        repeat: "",
        fullName: ""
      },
      show: true
    };
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      this.$store.dispatch("register", this.form);
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
    }
  }
};
</script>