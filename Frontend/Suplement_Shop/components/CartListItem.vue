<template>
    <b-list-group-item class="d-flex justify-content-between align-items-center">
        <ul>
<li v-for="item in cart.cartItems" :key="item.productId">
    <b-link : to="'/product/' + item.productId">{{item.productName}}</b-link>:{{item.price}}
</li>
        </ul>
        <br>
<span>{{cart.cartStatus}}</span>
    </b-list-group-item>        
</template>

<script>
export default {
    name:"CartListItem",
    props:["cart"]
};

</script>