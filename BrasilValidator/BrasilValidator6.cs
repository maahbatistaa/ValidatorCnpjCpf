﻿namespace BrasilValidator
{
    public class BrasilValidator6
    {
        public static int VerificadorDigito(int soma)
        {
            var resultado = soma % 11;
            return resultado < 2 ? 0 : 11 - resultado;
        }

        public static int ObterDigito(string input, int posicao)
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
            return -1;
        }

        public static bool EhIgual(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[0]) { return false;  }
            }
            return true;   
        }

        /// <summary>Verifica se o CPF é válido </summary>
        /// <param name="cpf">Digitos de um cpf</param>
        /// <returns>true of false</returns>
        public static bool EhCpfValido(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) {return false;}

            var nums = new int[11];
            for (int posicao = 0; posicao < nums.Length; posicao++)
            {
                nums[posicao] = ObterDigito(input, posicao);
                if (nums[posicao] == -1) { return false;}
            }

            if (EhIgual(nums)) {return false;}

            int soma = 0;
            for (int posicao = 0; posicao < 9; posicao++)
            {
                soma += nums[posicao] * (10 - posicao);
            }

            if (VerificadorDigito(soma) != nums[9]) { return false;}
            
            soma = 0;
            for (int posicao = 0; posicao < 10; posicao++)
            {
                soma += nums[posicao] * (11 - posicao);
            }
            return VerificadorDigito(soma) == nums[10];
        }

        /// <summary>Verifica se o CNPJ é válido</summary>
        /// <param name="cnpj">Digitos de um cnpj</param>
        /// <returns>true or false</returns>
        public static bool EhCnpjValido(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) { return false;}

            var nums = new int[14];
            for (int posicao = 0; posicao < nums.Length; posicao++)
            {
                nums[posicao] = ObterDigito(input, posicao);
                if (nums[posicao] == -1) { return false; }
            }

            if (EhIgual(nums)) { return false;}

            //Faz os calculos do primeiro digito
            int soma = 0;
            for (int posicao = 0; posicao < 12; posicao++)
            {
                var referencia = posicao < 4 ? 5 : 13;
                soma += nums[posicao] * (referencia - posicao);
            }

            if (VerificadorDigito(soma) != nums[12]) { return false;}
            
            soma = 0;
            //Faz os calculos do segundo digito
            for (int posicao = 0; posicao < 13; posicao++)
            { 
                var referencia = posicao < 5 ? 6 : 14;
                soma += nums[posicao] * (referencia - posicao);
            }
            return VerificadorDigito(soma) == nums[13];
        }

        
    }    
}
