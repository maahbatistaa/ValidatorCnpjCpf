namespace BrasilValidator
{
    public class BrasilValidator2
    {
        /// <summary> Verifica se o CPF é válido </summary>
        /// <param name="cpf">Digitos de um cpf</param>
        /// <returns>true of false</returns>
        public static bool EhCpfValido(string cpf)
        {
            int soma = 0, resultado = 0;

            if (string.IsNullOrWhiteSpace(cpf)) { return false; }

            //remove caracteres indesejados
            cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "")
                    .Replace("@", "").Replace(" ", "").Replace("=", "")
                    .Replace("/", "").Replace("\\", "").Replace("_", "")
                    .Replace(":", "").Replace("CPF", "").Replace("cpf", "").Trim();

            //Verifica se os caracteres são iguais 
            bool igual = true;
            for (int i = 1; i < cpf.Length && igual; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    igual = false;
                }
            }

            if (igual || cpf == "12345678909") { return false; }
          
            else if (cpf.Length != 11) { return false; }
           
            else
            {
                //Faz o calculo do primeiro digito
                for (int i = 0, j = 10; i < 9; i++, j--)
                {
                    soma += int.Parse(cpf[i].ToString()) * j;
                }
                resultado = (soma * 10) % 11;

                //Verifica se o resto da divisão é igual a 10, e retorna 0
                if (resultado == 10) { resultado = 0; }

                //Faz a comparação do resto da divisão com o primeiro digito
                if (Convert.ToString(resultado) == Convert.ToString(cpf[9]))
                {
                    soma = 0;
                    //faz o calculo do segundo digito
                    for (int i = 0, j = 11; i < 10; i++, j--)
                    {
                        soma += int.Parse(cpf[i].ToString()) * j;
                    }
                    resultado = (soma * 10) % 11;

                    //Verifica se o resto da divisão é igual a 10, e retorna 0
                    if (resultado == 10) { resultado = 0; }

                    //Faz a comparação do resultado com o segundo digito
                    if (Convert.ToString(resultado) == Convert.ToString(cpf[10])) { return true; }
                    
                    else { return false; }
                }
                else { return false; }
            }
        }

        /// <summary> Verifica se o CNPJ é válido </summary>
        /// <param name="cnpj">Digitos de um cnpj</param>
        /// <returns>true or false</returns>
        public static bool EhCnpjValido(string cnpj)
        {
            int soma = 0, resultado = 0;

            if (string.IsNullOrWhiteSpace(cnpj)) { return false; }

            //remove caracteres indesejados 
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace(",", "")
                        .Replace("@", "").Replace(" ", "").Replace("=", "")
                       .Replace("/", "").Replace("\\", "").Replace("_", "")
                       .Replace(":", "").Replace("CNPJ", "").Replace("cnpj", "").Trim();

            //Verifica se os caracteres são iguais 
            bool igual = true;
            for (int i = 1; i < cnpj.Length && igual; i++)
            {
                if (cnpj[i] != cnpj[0])
                {
                    igual = false;
                }
            }

            if (igual || cnpj == "12345678901234") { return false; }
            
            else if (cnpj.Length != 14) { return false; }
           
            else
            {
                //Faz o calculo do primeiro digito
                for (int i = 0, j = 5; i < 4; i++, j--)
                {
                    soma += int.Parse(cnpj[i].ToString()) * j;
                }
                for (int i = 4, j = 9; i < 12; i++, j--)
                {
                    soma += int.Parse(cnpj[i].ToString()) * j;
                }

                resultado = soma % 11;

                //Verifica se o resto da divisão é 1 ou 0, e retorna 0
                if (resultado == 0 || resultado == 1)
                {
                    resultado = 0;
                }
                else
                {
                    resultado = 11 - resultado;
                }

                //Faz a comparação do resto da divisão com o primeiro digito
                if (Convert.ToString(resultado) == Convert.ToString(cnpj[12]))
                {
                    soma = 0;

                    //faz o calculo do segundo digito
                    for (int i = 0, j = 6; i < 5; i++, j--)
                    {
                        soma += int.Parse(cnpj[i].ToString()) * j;
                    }
                    for (int i = 5, j = 9; i < 13; i++, j--)
                    {
                        soma += int.Parse(cnpj[i].ToString()) * j;
                    }

                    resultado = soma % 11;

                    //Verifica se o resto da divisão é 1 ou 0, e retorna 0
                    if (resultado == 0 || resultado == 1)
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = 11 - resultado;
                    }

                    //Faz a comparação do resultado com o segundo digito
                    if (Convert.ToString(resultado) == Convert.ToString(cnpj[13])) { return true; }
                  
                    else { return false; }
                }
                else { return false; }
            }
        }
    }
}