namespace Terceirizados.Dominio.Entidades
{
    public class Cargo
    {
        public Cargo(string nome)
        {
            CargoId = Guid.NewGuid();

            ArgumentNullException.ThrowIfNullOrEmpty(nome, nameof(nome));

            Nome = nome;
        }

        public Guid CargoId { get; protected set; }

        public string Nome { get; protected set; }

        // relacionamento
        public Funcionario Funcionario{ get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Cargo outro)
                return false;

            return CargoId.Equals(outro.CargoId);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(CargoId);
        }
    }
}
