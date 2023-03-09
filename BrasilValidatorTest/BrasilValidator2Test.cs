using BrasilValidator;

namespace BrasilValidatorTest;

public class BrasilHelper2 : IBrasilValidatorTests
{
    public bool EhCnpjValido(string? input)
    {
        return BrasilValidator2.EhCnpjValido(input);
    }

    //public bool EhCnpjValido(long? input)
    //{
    //    return BrasilValidator2.EhCnpjValido(input);
    //}

    public bool EhCpfValido(string? input)
    {
        return BrasilValidator2.EhCpfValido(input);
    }

    //public bool EhCpfValido(long? input)
    //{
    //    return BrasilValidator2.EhCpfValido(input);
    //}
}

public class BrasilValidator2Tests : BrasilValidatorTestsBase<BrasilHelper2>
{
    public BrasilValidator2Tests(BrasilHelper2 brasilHelper)
        : base(brasilHelper)
    {
    }
}
