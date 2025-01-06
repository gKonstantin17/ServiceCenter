export default {
  addToCart(context, payload) {
    const prodId = payload.id
    const products = context.rootGetters.products
    const product = products.find((prod) => prod.id === prodId)
    context.commit('addProductToCart', product)
  },
  removeFromCart(context, payload) {
    context.commit('removeProductFromCart', payload)
  },
  updateProductsList(context, products) {
    context.commit('updateProducts', products)
  },
  setClient(context, client) {
    context.commit('setClient', client)
  },
  clearCart(context) {
    context.commit('clearCart')
  }
}
