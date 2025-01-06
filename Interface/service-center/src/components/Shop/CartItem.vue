<template>
  <div class="cart_item">
    <img :src="'src/assets/img/shop/' + imgLink" alt="image" />
    <div class="cart_item_info">
      <h3>{{ title }}</h3>
      <p>Цена: {{ price }} руб.</p>
      <p>Количество: {{ quantity }}</p>
      <div class="item-total">Сумма: {{ itemTotal }} руб.</div>
      <button class="btn btn_cart" @click="remove">Убрать</button>
    </div>
  </div>
</template>
<script>
export default {
  props: ['id', 'title', 'price', 'quantity', 'imgLink'],
  computed: {
    itemTotal() {
      return (this.price * this.quantity).toFixed(2)
    }
  },
  methods: {
    remove() {
      this.$store.dispatch('removeFromCart', { id: this.id })
    }
  }
}
</script>

<style scoped>
li {
  margin: 1rem auto;
  padding: 1rem;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05);
  text-align: center;
  max-width: 25rem;
  border-radius: 15px;
  border: 1px solid rgba(60, 60, 60, 0.2);
}
.cart_item {
  display: flex;
  flex-direction: row;
  align-items: center;
  width: 300px;
  height: 150px;
  margin: 10px;
  border: 1px solid black;
  border-radius: 10px;
  box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.2);
  transition: all 0.3s ease-in-out;
}
.cart_item img {
  margin-left: 5px;
  height: 100px;
  width: 100px;
  object-fit: contain;
}
.cart_item .line {
  width: 100%;
  height: 1px;
  background-color: black;
}
.cart_item_info {
  display: flex;
  flex-direction: column;
  width: 100%;
  padding: 10px;
  font-size: 13px;
}
.btn_cart {
  width: 90%;
  height: 25px;
  position: relative;
}
</style>
