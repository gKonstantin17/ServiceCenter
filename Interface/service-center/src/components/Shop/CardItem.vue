<template>
  <div class="card_item">
    <img :src="'src/assets/img/shop/' + imgLink" alt="image" />
    <div class="line"></div>
    <div class="card_item_info">
      <h3>{{ title }}</h3>
      <p>Цена: {{ price }} руб.</p>
      <p>Количество: {{ quantity }}</p>
    </div>
    <button class="btn btn_card" @click="addToCart">Добавить в корзину</button>
  </div>
</template>

<script>
export default {
  name: 'CardItem',
  props: ['id', 'title', 'price', 'quantity', 'imgLink'],
  computed: {
    idClient() {
      return this.$store.getters['client']
    }
  },

  methods: {
    addToCart() {
      if (this.idClient != null) {
        this.$store.dispatch('addToCart', {
          id: this.id,
          title: this.title,
          price: this.price,
          quantity: this.quantity,
          imgLink: this.imgLink
        })
      } else {
        alert('Для добавления товара в корзину необходимо авторизоваться')
      }
    }
  }
}
</script>
<style>
.card_item {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 300px;
  height: 400px;
  margin: 10px;
  border: 1px solid black;
  border-radius: 10px;
  box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.2);
  transition: all 0.3s ease-in-out;
}
.card_item img {
  width: 100%;
  height: 220px;
  object-fit: contain;
}
.card_item .line {
  width: 100%;
  height: 1px;
  background-color: black;
}
.card_item_info {
  display: flex;
  flex-direction: column;
  width: 100%;
  padding: 10px;
}
.btn_card {
  width: 90%;
  height: 40px;
  margin-top: 25px;
  position: relative;
}
</style>
