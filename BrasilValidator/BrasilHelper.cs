using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Marrari.Helpers;

/// <summary>
/// Funções auxiliares para registros brasileiros.
/// </summary>
public class BrasilHelper
{
    /// <summary>
    /// Formata o CNPJ fornecido em: ##.###.###/####-##
    /// </summary>
    /// <param name="input">CNPJ a ser formatado.</param>
    /// <param name="failText">Texto a ser retornado em caso de falha.</param>
    /// <returns>CNPJ formatado, ou <paramref name="failText"/> se o CNPJ for inválido.</returns>
    public static string GetCnpjFormatado(string? input, string failText)
    {
        if (!EhCnpjValido(input)) { return failText; }
        ulong number = StringToUInt64(input);
        return GetCnpjFormatado(number);
    }

    /// <summary>
    /// Formata o CNPJ fornecido em: ##.###.###/####-##
    /// </summary>
    /// <param name="input">CNPJ a ser formatado.</param>
    /// <param name="failText">Texto a ser retornado em caso de falha.</param>
    /// <returns>CNPJ formatado, ou <paramref name="failText"/> se o CNPJ for inválido.</returns>
    public static string GetCnpjFormatado(ulong? input, string failText)
    {
        if (!EhCnpjValido(input)) { return failText; }
        return GetCnpjFormatado(input.Value);
    }

    private static string GetCnpjFormatado(ulong input)
    {
        Span<char> result = stackalloc char[18];

        for (int i = 17; i >= 0; i--)
        {
            if (i == 2 || i == 6) { result[i] = '.'; }
            else if (i == 10) { result[i] = '/'; }
            else if (i == 15) { result[i] = '-'; }
            else
            {
                result[i] = (char)((input % 10) + '0');
                input /= 10;
            }
        }

        return new string(result);
    }

    /// <summary>
    /// Tenta converter o CNPJ em número.
    /// </summary>
    /// <param name="input">Entrada que representa o CNPJ.</param>
    /// <returns>O número (<see langword="long"/>) que corresponde ao CNPJ, ou zero se a entrada não for um CNPJ válido.</returns>
    public static bool TryGetCnpjNumero(string? input, out ulong result)
    {
        result = 0;
        if (!EhCnpjValido(input)) { return false; }
        result = StringToUInt64(input);
        return true;
    }

    /// <summary>
    /// Verifica se a entrada corresponde a um CNPJ válido.
    /// </summary>
    /// <param name="input">Entrada a ser validada.</param>
    /// <returns><see langword="true"/> se for um CNPJ válido. Caso contrário, <see langword="false"/>.</returns>
    public static bool EhCnpjValido([NotNullWhen(true)] string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        Span<int> cnpjArray = stackalloc int[14];

        if (!GetOnlyDigits(input, 3, ref cnpjArray)) { return false; }

        return EhCnpjValido(cnpjArray);
    }

    /// <summary>
    /// Verifica se a entrada corresponde a um CNPJ válido.
    /// </summary>
    /// <param name="input">Entrada a ser validada.</param>
    /// <returns><see langword="true"/> se for um CNPJ válido. Caso contrário, <see langword="false"/>.</returns>
    public static bool EhCnpjValido([NotNullWhen(true)] ulong? input)
    {
        if (input is null || input < 191 || input > 99999999999962)
        {
            return false;
        }

        Span<int> cnpjArray = stackalloc int[14];

        for (int i = 13; i >= 0; i--)
        {
            cnpjArray[i] = (int)(input % 10);
            input /= 10;
        }

        return EhCnpjValido(cnpjArray);
    }

    private static bool EhCnpjValido(Span<int> cnpjArray)
    {
        if (EhTodosValoresIguais(ref cnpjArray))
        {
            return false;
        }

        int soma1 = 0;
        int soma2 = 0;

        for (int posicao = 0; posicao < 12; posicao++)
        {
            soma1 += cnpjArray[posicao] * (((11 - posicao) % 8) + 2);
            soma2 += cnpjArray[posicao] * (((12 - posicao) % 8) + 2);
        }

        int digito1 = GetDigitoVerificador(soma1);

        if (cnpjArray[12] != digito1)
        {
            return false;
        }

        soma2 += digito1 * 2;

        int digito2 = GetDigitoVerificador(soma2);

        return cnpjArray[13] == digito2;
    }


    /// <summary>
    /// Formata o CPF fornecido em: ###.###.###-##
    /// </summary>
    /// <param name="input">CPF a ser formatado.</param>
    /// <param name="failText">Texto a ser retornado em caso de falha.</param>
    /// <returns>CPF formatado, ou <paramref name="failText"/> se o CPF for inválido.</returns>
    public static string GetCpfFormatado(string? input, string failText)
    {
        if (!EhCpfValido(input)) { return failText; }
        ulong number = StringToUInt64(input);
        return GetCpfFormatado(number);
    }

    /// <summary>
    /// Formata o CPF fornecido em: ###.###.###-##
    /// </summary>
    /// <param name="input">CPF a ser formatado.</param>
    /// <param name="failText">Texto a ser retornado em caso de falha.</param>
    /// <returns>CPF formatado, ou <paramref name="failText"/> se o CPF for inválido.</returns>
    public static string GetCpfFormatado(ulong? input, string failText)
    {
        if (!EhCpfValido(input)) { return failText; }
        return GetCpfFormatado(input.Value);
    }

    private static string GetCpfFormatado(ulong input)
    {
        Span<char> result = stackalloc char[14];

        for (int i = 13; i >= 0; i--)
        {
            if (i == 3 || i == 7) { result[i] = '.'; }
            else if (i == 11) { result[i] = '-'; }
            else
            {
                result[i] = (char)((input % 10) + '0');
                input /= 10;
            }
        }

        return new string(result);
    }

    /// <summary>
    /// Tenta converter o CPF em número.
    /// </summary>
    /// <param name="input">Entrada que representa o CPF.</param>
    /// <returns>O número (<see langword="long"/>) que corresponde ao CPF, ou zero se a entrada não for um CPF válido.</returns>
    public static bool TryGetCpfNumero(string? input, out ulong result)
    {
        result = 0;
        if (!EhCpfValido(input)) { return false; }
        result = StringToUInt64(input);
        return true;
    }

    /// <summary>
    /// Verifica se a entrada corresponde a um CPF válido.
    /// </summary>
    /// <param name="input">Entrada a ser validada.</param>
    /// <returns><see langword="true"/> se for um CPF válido. Caso contrário, <see langword="false"/>.</returns>
    public static bool EhCpfValido([NotNullWhen(true)] string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        Span<int> cpfArray = stackalloc int[11];

        if (!GetOnlyDigits(input, 3, ref cpfArray)) { return false; }

        return EhCpfValido(cpfArray);
    }

    /// <summary>
    /// Verifica se a entrada corresponde a um CPF válido.
    /// </summary>
    /// <param name="input">Entrada a ser validada.</param>
    /// <returns><see langword="true"/> se for um CPF válido. Caso contrário, <see langword="false"/>.</returns>
    public static bool EhCpfValido([NotNullWhen(true)] ulong? input)
    {
        if (input is null || input < 191 || input > 99999999808)
        {
            return false;
        }

        Span<int> cpfArray = stackalloc int[11];

        for (int i = 10; i >= 0; i--)
        {
            cpfArray[i] = (int)(input % 10);
            input /= 10;
        }

        return EhCpfValido(cpfArray);
    }

    private static bool EhCpfValido(Span<int> cpfArray)
    {
        if (EhTodosValoresIguais(ref cpfArray))
        {
            return false;
        }

        int soma1 = 0;
        int soma2 = 0;

        for (int posicao = 0; posicao < 9; posicao++)
        {
            soma1 += cpfArray[posicao] * (10 - posicao);
            soma2 += cpfArray[posicao] * (11 - posicao);
        }

        int digito1 = GetDigitoVerificador(soma1);

        if (cpfArray[9] != digito1)
        {
            return false;
        }

        soma2 += digito1 * 2;

        int digito2 = GetDigitoVerificador(soma2);

        return cpfArray[10] == digito2;
    }

    /// <summary>
    /// Converte uma cadeia de caracteres em número.
    /// </summary>
    /// <param name="input">Cadeia de caracteres a ser convertida.</param>
    /// <returns>Número do tipo <see langword="ulong"/> a partir dos dígitos encontrados na cadeia.</returns>
    public static ulong StringToUInt64(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) { return 0; }

        ulong result = 0L;

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                result = result * 10 + c - '0';
            }
        }

        return result;
    }

    private static bool EhTodosValoresIguais(ref Span<int> input)
    {
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[0])
            {
                return false;
            }
        }

        return true;
    }

    private static int GetDigitoVerificador(int soma)
    {
        int digito = soma % 11;
        return (digito < 2) ? 0 : 11 - digito;
    }

    private static bool GetOnlyDigits(string input, int minCount, ref Span<int> span)
    {
        int upperBound = span.Length - 1;
        int count = 0;

        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(input[i]))
            {
                if (count > upperBound) { return false; }
                span[upperBound - count] = input[i] - '0';
                count++;
            }
        }

        return count >= minCount;
    }


    private static readonly HashSet<string> _UFs = new() {
        "AC", "AL", "AM", "AP", "BA", "CE", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SF", "SP", "TO", };
    private static readonly IEnumerable<string> _UFsA = Array.AsReadOnly(_UFs.ToArray());
    private static readonly IEnumerable<string> _UFeNomes = Array.AsReadOnly(new[]
    {
        "AC - Acre",
        "AL - Alagoas",
        "AM - Amazonas",
        "AP - Amapá",
        "BA - Bahia",
        "CE - Ceará",
        "ES - Espírito Santo",
        "GO - Goiás",
        "MA - Maranhão",
        "MG - Minas Gerais",
        "MS - Mato Grosso do Sul",
        "MT - Mato Grosso",
        "PA - Pará",
        "PB - Paraíba",
        "PE - Pernambuco",
        "PI - Piauí",
        "PR - Paraná",
        "RJ - Rio de Janeiro",
        "RN - Rio Grande do Norte",
        "RO - Rondônia",
        "RR - Roraima",
        "RS - Rio Grande do Sul",
        "SC - Santa Catarina",
        "SE - Sergipe",
        "SF - Distrito Federal",
        "SP - São Paulo",
        "TO - Tocantins",
    });

    /// <summary>
    /// Verifica se a entrada corresponde a uma sigla de estado válida.
    /// </summary>
    /// <param name="input">Entrada a ser validada.</param>
    /// <returns><see langword="true"/> se for uma UF válida. Caso contrário, <see langword="false"/>.</returns>
    public static bool EhUFValido(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) { return false; }
        return _UFs.Contains(input);
    }

    /// <summary>
    /// Lista das siglas dos estados.
    /// </summary>
    public static IEnumerable<string> UFs => _UFsA;

    /// <summary>
    /// Lista das siglas e nome dos estados.
    /// </summary>
    public static IEnumerable<string> UFeNomes => _UFeNomes;
}
