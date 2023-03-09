namespace BrasilValidator
{
    public class BrasilValidator4
    {
        public static int VerificadorDigito(int resultado, int soma)
        {
            resultado = soma % 11;
            resultado = resultado < 2
            ? 0
            : 11 - resultado;
            return resultado;
        }

        private static int ObterDigito(string input, int posicao)
        {
            int count = 0;
            foreach (char c in input)
                if (char.IsDigit(c))
                {
                    if (count == posicao)
                    {
                        return c - '0';
                    }
                    count++;
                }
            return 0;
        }

        private static bool EhIgual(string input)
        {
            bool igual = true;
            input = input.Replace(".", "").Replace("-", "").Replace(",", "").Replace("@", "")
                         .Replace(" ", "").Replace("=", "").Replace("/", "").Replace("\\", "")
                         .Replace("_", "").Replace(":", "").Trim();

            for (int i = 1; i < input.Length && igual; i++)
            {
                if (input[i] != input[0])
                {
                    igual = false;
                    break;
                }
            }
            return igual;   
        }

        /// <summary>Verifica se o CPF é válido </summary>
        /// <param name="cpf">Digitos de um cpf</param>
        /// <returns>true of false</returns>
        public static bool EhCpfValido(string cpf)
        {
            string input = cpf;
            if (string.IsNullOrWhiteSpace(input)) { return false; }
            
            else if (EhIgual(input) || input == "12345678909") { return false; }
          
            else
            {
                //Faz os calculos do primeiro digito
                int soma = 0, resultado = 0;
                for (int posicao = 0; posicao < 9; posicao++)
                {
                    soma += ObterDigito(input, posicao) * (10 - posicao);
                }
                int verificaDigito = VerificadorDigito(resultado, soma);

                if (verificaDigito == ObterDigito(input, 9))
                {
                    //Faz os calculos do segundo digito
                    soma = 0;
                    for (int posicao = 0; posicao < 10; posicao++)
                    {
                        soma += ObterDigito(input, posicao) * (11 - posicao);
                    }
                    verificaDigito = VerificadorDigito(resultado, soma);

                    if (verificaDigito == ObterDigito(input, 10)) { return true; }

                    return false;
                }
                return false;
            }
        }

        /// <summary>Verifica se o CNPJ é válido</summary>
        /// <param name="cnpj">Digitos de um cnpj</param>
        /// <returns>true or false</returns>
        public static bool EhCnpjValido(string cnpj)
        {
            string input = cnpj;
            if (string.IsNullOrWhiteSpace(input)) { return false; }
            
            else if (EhIgual(input) || input == "123456789000190") { return false; }
           
            else
            {
                int soma = 0, resultado = 0;
                //Faz os calculos do primeiro digito
                for (int posicao = 0; posicao < 12; posicao++)
                {
                    if (posicao < 4)
                    {
                        soma += ObterDigito(input, posicao) * (5 - posicao);
                    }
                    else
                        soma += ObterDigito(input, posicao) * (13 - posicao);
                }
                int verificaDigito = VerificadorDigito(resultado, soma);

                if (verificaDigito == ObterDigito(input, 12))
                {
                    soma = 0;
                    //Faz os calculos do segundo digito
                    for (int posicao = 0; posicao < 13; posicao++)
                    {
                        if (posicao < 5)
                        {
                            soma += ObterDigito(input, posicao) * (6 - posicao);
                        }
                        else
                            soma += ObterDigito(input, posicao) * (14 - posicao);
                    }
                    verificaDigito = VerificadorDigito(resultado, soma);

                    if (verificaDigito == ObterDigito(input, 13)) { return true; }
                    
                    return false;
                }
                return false;
            }
        }
    }    
}
