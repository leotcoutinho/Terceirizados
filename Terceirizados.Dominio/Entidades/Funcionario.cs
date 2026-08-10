namespace Terceirizados.Dominio.Entidades
{
    public class Funcionario
    {
        public Funcionario(string nome, string cpf, DateTime dataNascimento, string? telefone, string email, Guid empresaId, Guid cargoId)
        {
            FuncionarioId = Guid.NewGuid();

            ArgumentNullException.ThrowIfNullOrWhiteSpace(nome, nameof(nome));
            
            ArgumentNullException.ThrowIfNullOrWhiteSpace(cpf, nameof(cpf));
            
            if(cpf.Length < 11)
                throw new ArgumentException("CPF não é válido.", nameof(cpf));

            if (dataNascimento == default)
                throw new ArgumentException("Data Nascimento não é válida.", nameof(dataNascimento));

            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Ativo = true;

            if (string.IsNullOrEmpty(EmpresaId.ToString()))
                throw new ArgumentException("EmpresaId não é válido.", nameof(empresaId));

            if (string.IsNullOrEmpty(CargoId.ToString()))
                throw new ArgumentException("CargoId não é válido.", nameof(cargoId));

            EmpresaId = empresaId;
            CargoId = cargoId;
        }

        public Guid FuncionarioId { get; protected set; }

        public string Nome { get; protected set; }

        public string Cpf { get; protected set; }

        public string Email { get; protected set; }

        public DateTime DataNascimento { get; protected set; }

        public string? Telefone { get; protected set; }

        public bool Ativo { get; set; }

        // relacionamentos
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        public Guid CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Funcionario outro)
                return false;

            return FuncionarioId.Equals(outro.FuncionarioId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FuncionarioId);
        }      
    }
}
