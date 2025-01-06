import { ref } from 'vue'
const checkPassword = (value) => {
  const regex = /^[a-zA-Z0-9]{3,20}$/
  return regex.test(value)
}
const checkPhone = (value) => {
  const regex = /^\+?[0-9]{1,3}9[0-9]{2}[0-9]{7}$/
  return regex.test(value)
}
const checkEmail = (value) => {
  const regex = /^[a-zA-Z0-9.-_]{3,25}@[a-z]{3,8}\.[a-z]{2,8}$/
  return regex.test(value)
}
const checkFIO = (value) => {
  const regex = /^[А-ЯA-Z][а-яa-z]+\s[А-ЯA-Z][а-яa-z]+\s[А-ЯA-Z][а-яa-z]+$/
  return regex.test(value)
}

// Переменные для input
const password = ref('')
const phone = ref('')
const email = ref('')
const fio = ref('')
export { password, phone, email, fio, checkPassword, checkPhone, checkEmail, checkFIO }
