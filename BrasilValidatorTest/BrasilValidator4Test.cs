using BrasilValidator;

namespace BrasilValidatorTest;

public class BrasilHelper4 : IBrasilValidatorTests
{
    public bool EhCnpjValido(string? input)
    {
        return BrasilValidator4.EhCnpjValido(input);
    }

    //public bool EhCnpjValido(long? input)
    //{
    //    return BrasilValidator4.EhCnpjValido(input);
    //}

    public bool EhCpfValido(string? input)
    {
        return BrasilValidator4.EhCpfValido(input);
    }

    //public bool EhCpfValido(long? input)
    //{
    //    return BrasilValidator4.EhCpfValido(input);
    //}
}

public class BrasilValidator4Tests : BrasilValidatorTestsBase<BrasilHelper4>
{
    public BrasilValidator4Tests(BrasilHelper4 brasilHelper)
        : base(brasilHelper)
    {
    }
}
