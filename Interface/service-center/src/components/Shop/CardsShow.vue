<template>
  <div class="cards_wrapper">
    <CardItem
      v-for="product in products"
      :key="product.id"
      :id="product.id"
      :title="product.title"
      :price="product.price"
      :quantity="product.quantity"
      :imgLink="product.imgLink"
    />
  </div>
</template>
<script setup>
import CardItem from '@/components/Shop/CardItem.vue'
import axios from 'axios'
import { onMounted, ref } from 'vue'
import { useStore } from 'vuex'

const store = useStore()
const products = ref([])
async function getProduct() {
  try {
    const response = await axios.get('https://127.0.0.1:7171/api/products', { skip: 0, limit: 100 })
    products.value = response.data
    store.dispatch(
      'updateProductsList',
      products.value.map((product) => ({
        id: product.id,
        title: product.title,
        price: product.price,
        quantity: product.quantity,
        imgLink: product.imgLink
      }))
    )
  } catch (error) {
    console.error('Ошибка:', error)
  }
}
onMounted(getProduct)
</script>
<style>
.cards_wrapper {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  grid-gap: 20px;
  justify-content: center;
  align-items: center;
  margin-top: 20px;
  margin-bottom: 20px;
}
</style>
