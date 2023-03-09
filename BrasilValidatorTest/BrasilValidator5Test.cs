using BrasilValidator;

namespace BrasilValidatorTest;

public class BrasilHelper5 : IBrasilValidatorTests
{

    public bool EhCnpjValido(string? input)
    {
        return BrasilValidator5.EhCnpjValido(input);
    }

    //public bool EhCnpjValido(long? input)
    //{
    //    return BrasilValidator5.EhCnpjValido(input);
    //}

    public bool EhCpfValido(string? input)
    {
        return BrasilValidator5.EhCpfValido(input);
    }

    //public bool EhCpfValido(long? input)
    //{
    //    return BrasilValidator5.EhCpfValido(input);
    //}
}

public class BrasilValidator5Tests : BrasilValidatorTestsBase<BrasilHelper5>
{
    public BrasilValidator5Tests(BrasilHelper5 brasilHelper)
        : base(brasilHelper)
    {
    }
}
