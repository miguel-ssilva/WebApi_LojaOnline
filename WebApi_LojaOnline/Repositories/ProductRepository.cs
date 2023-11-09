using Microsoft.EntityFrameworkCore;
using WebApi_LojaOnline.Data;
using WebApi_LojaOnline.Models;

namespace WebApi_LojaOnline.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // 1.  Dados
        // 1.1 Ligação à base de dados.
        private readonly ApiDbContext _context;

        // 2. Funções
        // 2.1 Construtor com "dependency injection".
        public ProductRepository(ApiDbContext context)
        {
            _context = context;
        }


        // 2.2 Método para "Criar" - Verbo POST.
        // Devolve dados em JSON format.
        // Create.
        public async Task<ProductClass> Create(ProductClass product)
        {
            _context.SetProdutos.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }



        // 2.3 Método para "Apagar" - Verbo PUT.
        // Delete.
        public async Task Delete(int id)
        {
            var bookToDelete = await _context.SetProdutos.FindAsync(id);
            _context.SetProdutos.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        // 2.4 Método para "SELECT" - Verbo GET.
        // SELECT.
        public async Task<IEnumerable<ProductClass>> Get()
        {
            return await _context.SetProdutos.ToListAsync();
        }

        // 2.5 Método para "SELECT" para um item - Verbo GET.
        // SELECT.
        public async Task<ProductClass> Get(int id)
        {
            return await _context.SetProdutos.FindAsync(id);
        }

        // 2.6 Método para "UPDATE" - Verbo POST.
        // UPDATE.
        public async Task Update(ProductClass book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    } // Fim da classe.
}
