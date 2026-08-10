using System.Text.RegularExpressions;
using Terceirizados.Dominio.Entidades;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Dominio.Fabricas
{
    public class FabricaEmpresa(IRepositorioEmpresa repositorioEmpresa)
    {
        public async Task<Empresa> CriarEmpresa(string razaoSocial, string cnpj)
        {
            if (!ValidateCnpj(cnpj))
                throw new ArgumentException("CNPJ inválido", nameof(cnpj));

            Empresa? empresaExistente = await repositorioEmpresa.BuscarPorCnpj(cnpj);

            if (empresaExistente is not null)
                throw new InvalidOperationException("Já existe uma empresa cadastrada com este CNPJ.");

            return new Empresa(razaoSocial, cnpj);
        }

        private static bool ValidateCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) return false;
            var digits = Regex.Replace(cnpj, @"\D", "");
            if (digits.Length != 14) return false;
            if (Enumerable.Range(0, 10).Select(d => new string(char.Parse(d.ToString()), 14)).Any(s => s == digits)) return false;

            int[] GetDigits(string s) => s.Select(ch => ch - '0').ToArray();

            bool CheckDigit(string num, int[] weights, int expectedPos)
            {
                var d = GetDigits(num).Take(weights.Length).ToArray();
                int sum = d.Select((val, idx) => val * weights[idx]).Sum();
                int rem = sum % 11;
                int check = rem < 2 ? 0 : 11 - rem;
                return check == (num[expectedPos] - '0');
            }

            var weights1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var weights2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // first check digit (position 12)
            if (!CheckDigit(digits, weights1, 12)) return false;

            // second check digit (position 13) — use full 13 digits (including first check digit) with weights2
            if (!CheckDigit(digits, weights2, 13)) return false;

            return true;
        }

    }
}
