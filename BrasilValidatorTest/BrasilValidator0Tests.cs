using BrasilValidator;
using Marrari.Helpers;

namespace BrasilValidatorTest;
public class BrasilHelper0 : IBrasilValidatorTests
{
    public bool EhCnpjValido(string? input)
    {
        return BrasilHelper.EhCnpjValido(input);
    }

    //public bool EhCnpjValido(long? input)
    //{
    //    return BrasilValidator5.EhCnpjValido(input);
    //}

    public bool EhCpfValido(string? input)
    {
        return BrasilHelper.EhCpfValido(input);
    }

    //public bool EhCpfValido(long? input)
    //{
    //    return BrasilValidator5.EhCpfValido(input);
    //}
}

public class BrasilValidator0Tests : BrasilValidatorTestsBase<BrasilHelper0>
{
    public BrasilValidator0Tests(BrasilHelper0 brasilHelper)
        : base(brasilHelper)
    {
    }
}