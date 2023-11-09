using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_LojaOnline.Models;
using WebApi_LojaOnline.Data;
using WebApi_LojaOnline.Repositories;

namespace WebApi_LojaOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // 1.  Dados
        // 1.1 Ligação às operações CRUD. 
        private readonly IProductRepository _productRepository;

        // 2. Funções
        // 2.1 Construtor com "dependency injection".
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // 2.2 Método para "SELECT" - Verbo GET.
        // SELECT.
        [HttpGet]
        public async Task<IEnumerable<ProductClass>> GetProducts()
        {
            return await _productRepository.Get();
        }

        // 2.3 Método para "SELECT" por id - Verbo GET.
        // SELECT.
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductClass>> GetProducts(int id)
        {
            return await _productRepository.Get(id);
        }

        // 2.4 Método para "INSERT" - Verbo POST.
        // INSERT.
        [HttpPost]
        public async Task<ActionResult<ProductClass>> PostProducts([FromBody] ProductClass product)
        {
            var newProduct = await _productRepository.Create(product);
            return CreatedAtAction(nameof(GetProducts),
                    new { id = newProduct.Id }, newProduct);
        }

        // 2.5 a) Método para "UPDATE" - Verbo HttpPut.
        // UPDATE.
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducts(int id, [FromBody] ProductClass product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productRepository.Update(product);

            return NoContent();
        }

        // 2.5 b) Método para "UPDATE" - Verbo HttpPut.
        // UPDATE II
        [HttpPut]
        public async Task<ActionResult> PutProducts([FromBody] ProductClass product)
        {

            await _productRepository.Update(product);

            return NoContent();
        }


        // 2.6 Método para "DELETE" - Verbo HttpDelete.
        // DELETE.
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelete = await _productRepository.Get(id);
            if (productToDelete == null)
                return NotFound();

            await _productRepository.Delete(productToDelete.Id);
            return NoContent();
        }
    }
}
