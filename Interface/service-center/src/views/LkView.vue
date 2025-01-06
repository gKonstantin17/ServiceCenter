<template>
  <h1>Личный кабинет</h1>
  <div class="lk_container">
    <div class="lk_sidebar">
      <div class="client_data">
        <p>{{ client.fullname }}</p>
        <p>Ваш телефон: {{ client.phone }}</p>
        <p>Ваш email: {{ client.email }}</p>
      </div>
      <div class="client_orders">
        <div
          class="order_client"
          v-for="fullorder in fullorders"
          :key="fullorder.order.id"
          @click="selectOrder(fullorder)"
        >
          <p>Заказ № {{ fullorder.order.id }}</p>
          <p>Статус: {{ fullorder.order.status }}</p>
          <p v-if="fullorder.product != null">Купленный товар: {{ fullorder.product.title }}</p>
          <p v-if="fullorder.service != null">Услуга: {{ fullorder.service.title }}</p>
          <p v-if="fullorder.service != null">{{ fullorder.technique.title }}</p>
        </div>
      </div>
    </div>

    <div class="lk_main">
      <div class="order_select" v-if="selectedOrder">
        <p>Заказ №{{ selectedOrder.order.id }}</p>
        <p>Создан: {{ formatDate(selectedOrder.order.orderDate) }}</p>
        <p>Срок выполнения: {{ formatDate(selectedOrder.order.deadline) }}</p>
        <p>Статус: {{ selectedOrder.order.status }}</p>
        <p>Заказ выполняет: {{ selectedOrder.employee.fullname }}</p>

        <div class="product-client" v-if="selectedOrder.product != null">
          <p>Товар: {{ selectedOrder.product.title }}</p>
          <p>Количество: {{ selectedOrder.order.productQty }}</p>
          <p>Цена: {{ selectedOrder.product.price }}</p>
          <p>Общая стоимость: {{ selectedOrder.order.productQty * selectedOrder.product.price }}</p>
        </div>
        <div class="service-client" v-if="selectedOrder.service != null">
          <p>Услуга: {{ selectedOrder.service.title }}</p>
          <p>Стоимость: {{ selectedOrder.service.price }}</p>
          <p>Техника, над проводится услуга: {{ selectedOrder.technique.title }}</p>
          <p>Тип техники: {{ selectedOrder.technique.typetech }}</p>
          <p>Описание поломки: {{ selectedOrder.technique.description }}</p>
        </div>

        <button class="btn btn_cancel" @click="cancelOrder">Отменить заказ</button>
      </div>
    </div>
  </div>
</template>
<script>
import axios from 'axios'
export default {
  computed: {
    idClient() {
      return this.$store.getters['client']
    }
  },
  data() {
    return {
      selectedOrder: null,
      client: {},
      fullorders: []
    }
  },
  methods: {
    selectOrder(fullorder) {
      this.selectedOrder = fullorder
    },
    formatDate(date) {
      const options = { year: 'numeric', month: 'long', day: 'numeric' }
      return new Date(date).toLocaleDateString(undefined, options)
    },
    async getClient() {
      try {
        const response = await axios.get(
          'https://127.0.0.1:7171/api/clients/' + this.idClient.client
        )
        this.client = response.data
      } catch (error) {
        console.error(error)
      }
    },
    async getOrders() {
      try {
        const response = await axios.get(
          'https://127.0.0.1:7171/api/orders/' + this.idClient.client
        )
        this.fullorders = response.data
      } catch (error) {
        console.error(error)
      }
    },
    async cancelOrder() {
      try {
        const response = await axios.delete(
          'https://127.0.0.1:7171/api/orders/' + this.selectedOrder.order.id
        )
        console.log(response.data)
        alert('Заказ отменен')
        const index = this.fullorders.findIndex(
          (order) => order.order.id === this.selectedOrder.order.id
        )
        if (index > -1) {
          this.fullorders.splice(index, 1)
          this.selectedOrder = null
        }
      } catch (error) {
        console.error(error)
      }
    }
  },

  created() {
    this.getClient()
    this.getOrders()
  }
}
</script>
<style>
h1 {
  text-align: center;
}
.client_data {
  text-align: center;
  font-size: 18px;
  font-weight: bold;
  border: 1px solid #000;
  padding: 10px;

  background-color: #eee;
  box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.1);
}
.client_orders {
  overflow: auto;
  height: 400px;
  width: 315px;
}
.order_client {
  display: flex;
  flex-direction: column;
  border: 1px solid #000;
  padding: 10px;

  background-color: #eee;
  text-align: center;
  cursor: pointer;
}
.order_client:hover {
  background-color: #dbd9d9;
}
.lk_container {
  display: flex;
}
.lk_main {
  width: 100%;
}
.order_select {
  margin: 30px auto;
  background-color: aliceblue;
  width: 500px;
  text-align: center;
  font-size: 20px;
  border: 1px solid #000;
  border-radius: 10px;
}
.btn_cancel {
  position: relative;
  width: 75%;
  height: 30px;
  font-size: 20px;
  margin-top: 10px;
}
.lk_sidebar {
  width: 300px;
}
</style>
