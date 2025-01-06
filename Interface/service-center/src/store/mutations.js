export default {
  addProductToCart(state, payload) {
    const productData = payload
    const productInCartIndex = state.cart.findIndex((ci) => ci.id === productData.id)

    const availableProduct = state.products.find((p) => p.id === productData.id)

    if (productInCartIndex >= 0) {
      if (state.cart[productInCartIndex].quantity < availableProduct.quantity) {
        state.cart[productInCartIndex].quantity++
        state.quantity++
        state.total += productData.price
      } else {
        alert('Достигнуто максимальное количество товара в корзине')
      }
    } else {
      const newItem = {
        id: productData.id,
        title: productData.title,
        price: productData.price,
        imgLink: productData.imgLink,
        quantity: 1
      }
      state.cart.push(newItem)
      state.quantity++
      state.total += productData.price
    }
  },

  removeProductFromCart(state, payload) {
    const prodId = payload.id
    const productInCartIndex = state.cart.findIndex((cartItem) => cartItem.id === prodId)
    const prodData = state.cart[productInCartIndex]
    state.cart.splice(productInCartIndex, 1)
    state.quantity -= prodData.quantity
    state.total -= prodData.price * prodData.quantity
  },

  updateProducts(state, products) {
    state.products = products
  },
  setClient(state, client) {
    state.client = client
  },

  clearCart(state) {
    state.cart = []
    state.quantity = 0
    state.total = 0
  }
}
