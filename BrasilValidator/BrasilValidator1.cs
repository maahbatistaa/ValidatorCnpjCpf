namespace BrasilValidator
{
    
    public class BrasilValidator1
    {

        /// <summary> Verifica se o CPF é válido </summary>
        /// <param name="cpf">Digitos de um cpf</param>
        /// <returns> true of false </returns>
        public static bool EhCpfValido(string cpf )
        {
            int soma = 0, resultado = 0;
            
            if (string.IsNullOrWhiteSpace(cpf)) { return false; }

            //remove caracteres indesejados
            cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "")
                    .Replace("@", "").Replace(" ", "").Replace("=", "")
                    .Replace("/", "").Replace("\\", "").Replace("_", "")
                    .Replace(":", "").Replace("CPF", "").Replace("cpf", "").Trim(); 

            if (cpf.Length != 11) { return false; }

            //Confere se não são caracteres iguais
            else if (cpf[0] == cpf[1] && cpf[1] == cpf[2] && cpf[2] == cpf[3] && 
                     cpf[3] == cpf[4] && cpf[4] == cpf[5] && cpf[5] == cpf[6] &&
                     cpf[6] == cpf[7] && cpf[7] == cpf[8] && cpf[8] == cpf[9])
            {
                return false;
            }
            else
            {
                int[] multi1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multi2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                //Faz o calculo do primeiro digito
                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(cpf[i].ToString()) * multi1[i];
                }

                resultado = (soma * 10) % 11;

                //Verifica se o resto da divisão é igual a 10, e retorna 0
                if (resultado == 10) { resultado = 0; }

                //Faz a comparação do resto da divisão com o primeiro digito
                if (Convert.ToString(resultado) == Convert.ToString(cpf[9]))
                {
                    soma = 0;
                    //faz o calculo do segundo digito
                    for (int i = 0; i < 10; i++)
                    {
                        soma += int.Parse(cpf[i].ToString()) * multi2[i];
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
            int soma = 0;
            int resultado = 0;
            int[] multi1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multi2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (string.IsNullOrWhiteSpace(cnpj)) { return false; }

            //remove caracteres indesejados 
            cnpj = cnpj.Replace(".", "").Replace("-", "")
                        .Replace(",", "").Replace("@", "")
                        .Replace(" ", "").Replace("=", "")
                        .Replace("/", "").Replace("\\", "")
                        .Replace("_", "").Replace(":", "")
                        .Replace("CNPJ", "").Replace("cnpj", "")
                        .Trim();

            //Verifica se caracteres são iguais 
            if (cnpj[0] == cnpj[1] && cnpj[1] == cnpj[2] && cnpj[2] == cnpj[3] && 
                cnpj[3] == cnpj[4] && cnpj[4] == cnpj[5] && cnpj[5] == cnpj[6] &&
                cnpj[6] == cnpj[7] && cnpj[7] == cnpj[8] && cnpj[8] == cnpj[9] &&
                cnpj[9] == cnpj[10] && cnpj[10] == cnpj[11] && cnpj[11] == cnpj[12])
            {
                return false;
            }

            else if (cnpj.Length != 14)
            {
                return false;
            }

            else
            {
                //Faz o calculo do primeiro digito
                for (int i = 0; i < 12; i++)
                {
                    soma += int.Parse(cnpj[i].ToString()) * multi1[i];
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
                    for (int i = 0; i < 13; i++)
                    {
                        soma += int.Parse(cnpj[i].ToString()) * multi2[i];
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
                    if (Convert.ToString(resultado) == Convert.ToString(cnpj[13]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }
    }
}