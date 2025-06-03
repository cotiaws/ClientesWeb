namespace ClientesWeb.Models
{
    public class ClienteQuery
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public DateTime? DataHoraUltimaAlteracao { get; set; }
        public bool? Ativo { get; set; }
    }
}
