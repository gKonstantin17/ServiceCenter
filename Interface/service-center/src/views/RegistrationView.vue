<template>
  <div class="form-wrapper-reg">
    <form class="client-data">
      <div class="input-block">
        <label for="fio">Введите ваше фио</label>
        <input
          type="text"
          id="fio"
          name="fio"
          placeholder="Иванов Иван Иванович"
          required
          v-model="fio"
          @input="checkFIO(fio)"
        />
        <p class="error" v-if="!checkFIO(fio)">Invalid fio</p>
      </div>
      <div class="input-block">
        <label for="phone">Введите ваш телефон</label>
        <input
          type="text"
          id="phone"
          name="phone"
          placeholder="+79123456789"
          required
          v-model="phone"
          @input="checkPhone(phone)"
        />
        <p class="error" v-if="!checkPhone(phone)">Invalid phone</p>
      </div>
    </form>
    <form class="user-data">
      <div class="input-block">
        <label for="email">Введите ваш email</label>
        <input
          type="text"
          id="email"
          name="email"
          placeholder="example@example.com"
          required
          v-model="email"
          @input="checkEmail(email)"
        />
        <p class="error" v-if="!checkEmail(email)">Invalid email</p>
      </div>
      <div class="input-block">
        <label for="password">Придумайте пароль</label>
        <input
          type="password"
          id="password"
          name="password"
          required
          v-model="password"
          @input="checkPassword(password)"
        />
        <p class="error" v-if="!checkPassword(password)">Invalid password</p>
      </div>
    </form>
  </div>
  <button type="submit" class="btn btn_reg" @click="sendData">Создать аккаунт</button>
  <div class="error-request">
    <p class="error-request__text" v-if="!error === null">{{ error }}</p>
  </div>
</template>
<script>
import {
  password,
  phone,
  email,
  fio,
  checkPassword,
  checkPhone,
  checkEmail,
  checkFIO
} from '@/validation'
import axios from 'axios'
export default {
  data() {
    return {
      password,
      phone,
      email,
      fio,
      error: null
    }
  },
  methods: {
    checkPassword,
    checkPhone,
    checkEmail,
    checkFIO,
    async sendData() {
      try {
        const response = await axios.post('https://127.0.0.1:7171/api/clients', {
          fullname: this.fio,
          phone: this.phone,
          email: this.email,
          password: this.password
        })
        console.log(response.data)
        this.$router.push({ name: 'Authorization' })
      } catch (error) {
        console.error(error)

        if (error.response.status === 400) {
          if (error.response.data === 'Неверно введены данные') {
            this.error = error.response.data
          } else if (error.response.data === 'Пользователь с таким Email существует') {
            this.error = error.response.data
          }
        }
      }
    }
  }
}
</script>
<style>
.form-wrapper-reg {
  display: flex;
  width: 950px;
  margin: 0 auto;
}
.btn_reg {
  height: 55px;
  width: 200px;
  font-size: 20px;
  display: block;
  margin: 0 auto;
}

p.error {
  color: red;
  font-size: 12px;
  margin-top: 10px;
  margin-bottom: 10px;
  text-align: center;
  font-weight: 600;
  display: block;
  width: 100%;
  text-align: center;
  font-size: 12px;
  font-weight: 600;
  margin-top: 10px;
  margin-bottom: 10px;
}
.error-request {
  margin: 50px auto;
  background-color: darksalmon;
}
.error-request__text {
  text-align: center;
  font-size: 22px;
  font-weight: 600;
  padding: 5% 0;
  color: red;
}
</style>
