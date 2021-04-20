<template>
    <b-leist-group-item class="d-flex justify-content-between allign-items-center">
        <b-link :to="'/product/' + item.productId">{{ittem.productName}} - {{item.price}}ден.</b-link>
        <div class="count">
            <b-button side="sm" pill variant= "outline-secondary" @click="increment()">-</b-button>
            <span>{{item.count}}</span>
            <b-button side="sm" pill variant= "outline-secondary" @click="decrement()">+</b-button>
        </div>
    </b-leist-group-item>

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