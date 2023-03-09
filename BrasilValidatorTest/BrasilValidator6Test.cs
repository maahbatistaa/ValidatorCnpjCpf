using BrasilValidator;

namespace BrasilValidatorTest;

public class BrasilHelper6 : IBrasilValidatorTests
{
    public bool EhCnpjValido(string? input)
    {
        return BrasilValidator6.EhCnpjValido(input);
    }

    //public bool EhCnpjValido(long? input)
    //{
    //    return BrasilValidator6.EhCnpjValido(input);
    //}

    public bool EhCpfValido(string? input)
    {
        return BrasilValidator6.EhCpfValido(input);
    }

    //public bool EhCpfValido(long? input)
    //{
    //    return BrasilValidator6.EhCpfValido(input);
    //}
}

public class BrasilValidator6Tests : BrasilValidatorTestsBase<BrasilHelper6>
{
    public BrasilValidator6Tests(BrasilHelper6 brasilHelper)
        : base(brasilHelper)
    {
    }
}
