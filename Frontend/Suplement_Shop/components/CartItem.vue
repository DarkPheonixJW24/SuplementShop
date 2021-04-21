<template>
    <v-list-group-item class="d-flex justify-content-between allign-items-center">
        <v-link :to="'/product/' + item.productId">{{ittem.productName}} - {{item.price}}ден.</v-link>
        <div class="count">
            <v-button side="sm" pill variant= "outline-secondary" @click="increment()">-</v-button>
            <span>{{item.count}}</span>
            <v-button side="sm" pill variant= "outline-secondary" @click="decrement()">+</v-button>
        </div>
    </v-list-group-item>
</template>

<script>
export default {
    props:["item"],
    methods: {
        increment(){
            this.$emit("increment")
            },

           decrement(){
            this.$emit("decrement")
            },
            
            remove(){
            this.$emit("remove")
            },
        }
    };
</script>

<style lang="scss" scoped>
.count * {
    margin: 0 0.5rem;
}

</style>