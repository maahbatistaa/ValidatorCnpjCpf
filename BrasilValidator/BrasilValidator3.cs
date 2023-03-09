namespace BrasilValidator
{
    public class BrasilValidator3
    {
       
        private static int RestoDivisaoCnpj(int resultado)
        {
            resultado = resultado < 2
            ? 0
            : 11 - resultado;
            return resultado;
        }

        /// <summary> Verifica se CPF ou CNPJ são válidos </summary>
        /// <param name="dados">Recebe como parametro cpf ou cnpj</param>
        /// <returns>true or false</returns>
        public static bool EhValido(string dados)
        {
            int soma = 0, resultado = 0;

            if (string.IsNullOrWhiteSpace(dados)) { return false; }

            //remove caracteres indesejados
            dados = dados.Replace(".", "").Replace("-", "")
                         .Replace(",", "").Replace(" ", "")
                         .Replace("/", "").Trim();

            //Verifica se os caracteres são iguais 
            bool igual = true;
            for (int i = 1; i < dados.Length && igual; i++)
            {
                if (dados[i] != dados[0])
                {
                    igual = false;
                }
            }
            if (igual || dados == "12345678909") { return false; }

            //Verifica o número de caracteres é correspondente a CPF ou CNPJ
            if (dados.Length == 11)
            {
                //Faz o calculo do primeiro digito
                for (int i = 0, j = 10; i < 9; i++, j--)
                {
                    soma += int.Parse(dados[i].ToString()) * j;
                }
                resultado = (soma * 10) % 11;

                //Verifica se o resto da divisão é igual a 10, e retorna 0
                if (resultado == 10) { resultado = 0; }

                //Faz a comparação do resto da divisão com o primeiro digito
                if (Convert.ToString(resultado) == Convert.ToString(dados[9]))
                {
                    soma = 0;
                    //faz o calculo do segundo digito
                    for (int i = 0, j = 11; i < 10; i++, j--)
                    {
                        soma += int.Parse(dados[i].ToString()) * j;
                    }
                    resultado = (soma * 10) % 11;

                    //Verifica se o resto da divisão é igual a 10, e retorna 0
                    if (resultado == 10) { resultado = 0; }

                    //Faz a comparação do resultado com o segundo digito
                    if (Convert.ToString(resultado) == Convert.ToString(dados[10])) { return true; }

                    else { return false; }
                }
                else { return false; }
            }
            else if (dados.Length == 14)
            {
                //Faz o calculo do primeiro digito
                for (int i = 0, j = 5; i < 4; i++, j--)
                {
                    soma += int.Parse(dados[i].ToString()) * j;
                }
                for (int i = 4, j = 9; i < 12; i++, j--)
                {
                    soma += int.Parse(dados[i].ToString()) * j;
                }
                resultado = soma % 11;

                //Verifica se o resto da divisão é 1 ou 0, e retorna 0
                int resto = RestoDivisaoCnpj(resultado);

                //Faz a comparação do resto da divisão com o primeiro digito
                if (Convert.ToString(resto) == Convert.ToString(dados[12]))
                {
                    soma = 0;

                    //faz o calculo do segundo digito
                    for (int i = 0, j = 6; i < 5; i++, j--)
                    {
                        soma += int.Parse(dados[i].ToString()) * j;
                    }
                    for (int i = 5, j = 9; i < 13; i++, j--)
                    {
                        soma += int.Parse(dados[i].ToString()) * j;
                    }
                    resultado = soma % 11;

                    //Verifica se o resto da divisão é 1 ou 0, e retorna 0
                    resto = RestoDivisaoCnpj(resultado);

                    //Faz a comparação do resultado com o segundo digito
                    if (Convert.ToString(resto) == Convert.ToString(dados[13])) { return true; }

                    else { return false; }
                }
                else { return false; }
            }
            else {return false; }
        }
    }
}