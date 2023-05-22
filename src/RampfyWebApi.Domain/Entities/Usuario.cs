namespace RampfyWebApi.Domain.Entities
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario() { }
        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
        public Usuario(int codigo, string email, string senha) 
        { 
            Codigo = codigo;
            Email = email;
            Senha = senha;
        }
           
    }
}
