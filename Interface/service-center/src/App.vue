<template>
  <Header></Header>
  <RouterView />
</template>
<script setup>
// https://127.0.0.1:7171/api/ - domain
import { RouterView } from 'vue-router'
import Header from '@/components/HeaderComp.vue'
</script>
