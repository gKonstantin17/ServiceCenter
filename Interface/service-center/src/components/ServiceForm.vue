<template>
  <div @click="close" class="background-black"></div>
  <div class="form-wrapper">
    <form class="form-service">
      <label for="device">Вид техники:</label>
      <input type="text" id="device" name="device" required v-model="typetech" />
      <label for="name">Название:</label>
      <input type="text" id="name" name="name" required v-model="title" />
      <label for="description">Описание поломки:</label>
      <textarea id="description" name="description" required v-model="description"></textarea>
      <button type="button" class="btn btn_form" @click="sendServiceOrder">Отправить</button>
      <button type="button" class="btn btn_form" @click="close">Отменить</button>
    </form>
  </div>
</template>

<script setup>
import { ref, onMounted, onBeforeUnmount, computed } from 'vue'
import axios from 'axios'
import { useStore } from 'vuex'

const emit = defineEmits(['close'])
const isVisible = ref(false)

const close = () => {
  isVisible.value = false
  emit('close')
}

onMounted(() => {
  isVisible.value = true
})

onBeforeUnmount(() => {
  isVisible.value = false
})

const store = useStore()

const id = computed(() => {
  return JSON.parse(JSON.stringify(store.getters['client']))
})
const title = ref('')
const typetech = ref('')
const description = ref('')

async function sendServiceOrder() {
  try {
    const response = await axios.post('https://127.0.0.1:7171/api/techniques', {
      Title: title.value,
      Typetech: typetech.value,
      Description: description.value,
      ClientId: id.value.client
    })
    console.log(response.data)
    isVisible.value = false
    emit('close')
    alert('Заказ оформлен')
  } catch (error) {
    console.error(error)
    console.log(error.response.data)
  }
}
</script>

<style>
.background-black {
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.6);
  position: absolute;
  z-index: 5;
}
form {
  background-color: white;
  width: 400px;
  display: flex;
  flex-direction: column;

  font-size: 20px;
  padding: 30px;
  margin-top: 30px;
  border-radius: 10px;
  text-align: center;
}
.form-service {
  position: absolute;
  margin: 30px auto;
  z-index: 10;
  left: 35%;
}
form input {
  height: 50px;
  border-radius: 10px;
  padding: 10px;
  font-size: 20px;
}
form textarea {
  height: 125px;
  border-radius: 10px;
  padding: 10px;
  font-size: 14px;
}
.btn_form {
  height: 40px;
  margin-top: 25px;
  margin-bottom: 0;
}
</style>
