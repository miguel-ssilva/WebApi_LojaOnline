namespace WebApi_LojaOnline.Models
{
    public class ProductClass
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Tamanho { get; set; }
        public string Cor { get; set; }
        public string Categoria { get; set; }
        public string Moda { get; set; }
        public int Stock { get; set; }
        public decimal Preco { get; set; }
        public byte[] Imagem { get; set; }
    }
}
