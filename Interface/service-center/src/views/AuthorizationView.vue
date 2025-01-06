<template>
  <div class="form-wrapper">
    <form class="form-auth">
      <label for="email">Email</label>
      <input type="text" id="email" name="email" required v-model="email" />
      <label for="password">Пароль</label>
      <input type="password" id="password" name="password" required v-model="password" />
      <button type="button" class="btn btn_auth" @click="login">Войти</button>
      <RouterLink to="/registration" class="btn btn_auth">Создать аккаунт</RouterLink>
    </form>
  </div>
  <div class="error-request">
    <p class="error-request__text" v-if="error !== null">{{ error }}</p>
  </div>
</template>
<script>
import axios from 'axios'

export default {
  data() {
    return {
      email: '',
      password: '',
      error: null
    }
  },
  methods: {
    async login() {
      try {
        const response = await axios.post('https://127.0.0.1:7171/api/logins', {
          email: this.email,
          password: this.password
        })

        this.$store.dispatch('setClient', { client: response.data.id })
        console.log(response.data)
        this.$router.push({ name: 'Lk' })
      } catch (error) {
        console.error(error)
        this.error = 'Не удалось войти в систему.'
      }
    }
  }
}
</script>
<style>
.form-auth {
  margin: 0 auto;
}
.btn_auth {
  font-size: 20px;
  height: 40px;
  margin-bottom: 0;
  margin-top: 15px;
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
