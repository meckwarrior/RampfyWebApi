namespace RampfyWebApi.Domain.Entities
{
    public class Venda
    {
        public int Codigo { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal Valor { get; set; }
        
        public Venda() { }
        public Venda(int codigo, DateTime dataVenda, decimal valor)
        {
            Codigo = codigo;
            DataVenda = dataVenda;
            Valor = valor;
        }
    }
}
