<template>
  <div class="header_wrapper">
    <RouterLink to="/" class="header_wrapper_item">
      <img src="@/assets/logo.svg" alt="logo" class="logo" />
    </RouterLink>
    <a href="#" class="header_wrapper_item" @click.prevent="showForm">Заказать услугу</a>
    <RouterLink to="/shop" class="header_wrapper_item">Заказать товар</RouterLink>
    <RouterLink to="/authorization" class="header_wrapper_item" v-if="idClient == null"
      >Авторизация</RouterLink
    >
    <RouterLink to="/lk" class="header_wrapper_item" v-if="idClient != null"
      >Личный кабинет</RouterLink
    >
  </div>
  <ServiceForm @close="showForm" v-if="isFormVisible"></ServiceForm>
</template>
<script setup>
import { computed, ref } from 'vue'
import { useStore } from 'vuex'
import { RouterLink } from 'vue-router'
import ServiceForm from '@/components/ServiceForm.vue'
// получение id клиента
const store = useStore()
const idClient = computed(() => store.getters['client'])
// появление ServiceForm
const isFormVisible = ref(false)
const showForm = () => {
  if (idClient.value != null) {
    isFormVisible.value = !isFormVisible.value
  } else {
    alert('Авторизуйтесь, чтобы заказать услугу')
  }
}
</script>
<style>
.header_wrapper {
  display: flex;
  justify-content: space-evenly;
  align-items: center;
  background-color: white;
  height: 100px;
}
.header_wrapper_item {
  font-size: 25px;
}

.logo {
  height: 90px;
}
</style>
