<template>
  <div class="container">
    <CardsShow />
    <CartShow />
  </div>
</template>
<script setup>
import CardsShow from '@/components/Shop/CardsShow.vue'
import CartShow from '@/components/Shop/CartShow.vue'
</script>
<style>
#productInput {
  width: 250px;
  height: 100%;
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 10px 35px;
  box-sizing: border-box;
  font-size: 16px;
  background-color: #fff;
  background-image: url('/src/components/icons/searchicon.png');
  background-position: 10px 10px;
  background-repeat: no-repeat;
  background-size: 18px 18px;
  transition: width 0.4s ease-in-out;
}
</style>
