<template>
  <div class="container-cart">
    <div class="cart-show">
      <img
        src="@/components/icons/cart-icon.svg"
        alt="cart-icon"
        class="cart-icon"
        @click="toggleCart"
      />
      <div class="cart-qry">{{ cartQuantity }}</div>
    </div>
    <div class="cart-cards" v-if="showCart">
      <h3 class="cart-total">Общая сумма: {{ cartTotal }} руб.</h3>
      <ul>
        <CartItem
          v-for="product in cartProducts"
          :key="product.id"
          :id="product.id"
          :title="product.title"
          :price="product.price"
          :quantity="product.quantity"
          :imgLink="product.imgLink"
        ></CartItem>
      </ul>
      <button class="btn btn_cart_order" @click="sendProductOrder">Купить</button>
    </div>
  </div>
</template>

<script>
import CartItem from '@/components/Shop/CartItem.vue'
import axios from 'axios'

export default {
  components: {
    CartItem
  },
  computed: {
    cartTotal() {
      return this.$store.getters['totalSum'].toFixed(2)
    },
    cartProducts() {
      return this.$store.getters['cart']
    },
    cartQuantity() {
      return this.$store.getters['quantity']
    },
    clientId() {
      return this.$store.getters['client'].client
    }
  },
  data() {
    return {
      showCart: false
    }
  },
  methods: {
    toggleCart() {
      this.showCart = !this.showCart
    },
    async sendProductOrder() {
      try {
        const response = await axios.post('https://127.0.0.1:7171/api/carts', {
          ClientId: this.clientId,
          Products: this.cartProducts.map((product) => ({
            id: product.id,
            productQty: product.quantity
          }))
        })
        console.log(response.data)
        alert('Заказ оформлен')
        this.$store.dispatch('clearCart')
        this.$router.push({ name: 'Lk' })
      } catch (error) {
        console.error(error)
      }
    }
  }
}
</script>
<style>
ul {
  padding: 0;
}
.cart-icon {
  width: 60px;
  height: 60px;
  margin-right: 10px;
}
.cart-icon:hover {
  cursor: pointer;
}
.cart-show {
  display: flex;
  position: fixed;
  bottom: 0;
  right: 0;
}
.cart-qry {
  background-color: rgb(64, 184, 211);
  color: white;
  font-size: 16px;
  width: 25px;
  height: 25px;
  border-radius: 50%;
  text-align: center;
  transform: translateX(-25px);
}
.cart-cards {
  position: fixed;
  bottom: 0;
  left: 0;
  width: 350px;
  height: 100%;
  background-color: white;
  padding: 10px;
  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
  z-index: 100;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
}

.cart-cards ul {
  margin-top: 40px;
  overflow: auto;
  height: 600px;
}
.cart-total {
  position: fixed;
  top: 0;
  margin-top: 10px;
}
.btn_cart_order {
  width: 330px;
  height: 35px;
  position: fixed;
  bottom: 0;
  margin-bottom: 20px;
}
</style>
