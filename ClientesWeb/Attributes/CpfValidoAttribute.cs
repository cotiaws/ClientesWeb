using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClientesWeb.Attributes
{
    public class CpfValidoAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            var cpf = value.ToString();
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            cpf = Regex.Replace(cpf, @"[^\d]", "");

            if (cpf.Length != 11) return false;

            if (new string(cpf[0], cpf.Length) == cpf) return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;
            var digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            var digito2 = resto < 2 ? 0 : 11 - resto;

            var cpfCalculado = tempCpf + digito2;

            return cpf == cpfCalculado;
        }

        public override string FormatErrorMessage(string name)
        {
            return "O CPF informado é inválido.";
        }
    }
}
