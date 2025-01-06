using Domain.DTO;
using Domain.Repositories;

namespace Domain.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(string dalUrl, HttpClientHandler clientHandler)
        {
            _productRepository = new ProductRepository(dalUrl, clientHandler);
        }
        public async Task<int?> ChangeQty(ProductBuyDto product, int ProductQty)
        {
            var productForChange = await _productRepository.GetById(product.Id);
            var ostatok = productForChange.Quantity - ProductQty;
            productForChange.Quantity = ostatok;
            var changedProduct = await _productRepository.Put(productForChange);
            return changedProduct;
        }
        public async Task<int?> ReturnQtyInProduct(int id, int ProductQty)
        {
            var productForChange = await _productRepository.GetById(id);
            var ostatok = productForChange.Quantity + ProductQty;
            productForChange.Quantity = ostatok;
            var changedProduct = await _productRepository.Put(productForChange);
            return changedProduct;
        }
    }
}
