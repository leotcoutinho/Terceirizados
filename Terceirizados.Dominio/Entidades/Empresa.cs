namespace Terceirizados.Dominio.Entidades
{
    public class Empresa
    {
        public Empresa(string razaoSocial, string cnpj)
        {
            EmpresaId = Guid.NewGuid();

            ArgumentNullException.ThrowIfNull(razaoSocial, nameof(razaoSocial));
         
            ArgumentNullException.ThrowIfNull(cnpj, nameof(cnpj));

            if(cnpj.Length < 14)
                throw new ArgumentException("CNPJ não é válido.", nameof(cnpj));    

            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
        }

        public Guid EmpresaId { get; protected set; }

        public string RazaoSocial { get; protected set; }

        public string Cnpj { get; protected set; }

        // relacionamentos
        public ICollection<Funcionario> Funcionarios { get; protected set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Empresa outro)
                return false;

            return EmpresaId.Equals(outro.EmpresaId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmpresaId);
        }
    }
}
