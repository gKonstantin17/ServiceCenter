using Domain.DTO;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

namespace Domain.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        private readonly string? _dalUrl;
        private readonly HttpClient _httpClient;
        public ProductsController(string dalUrl, HttpClientHandler clientHandler)
        {
            _productRepository = new ProductRepository(dalUrl, clientHandler);
            _dalUrl = dalUrl;
            _httpClient = new HttpClient(clientHandler);
        }
        // GET: api/products
        [HttpGet] // загрузка товаров на странице ShopView
        public async Task<ActionResult<List<ProductDto>>?> GetProducts() 
        {
            var products = await _productRepository.Get();
            return products;
        }
        // GET api/products/5
        [HttpGet("{id}")] // найти товар
        public async Task<ActionResult<ProductDto?>> GetProductById(int id)
        {
            var product = await _productRepository.GetById(id);
            return product;
        }

    }
}
