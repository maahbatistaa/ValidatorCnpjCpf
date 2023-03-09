using BrasilValidator;

namespace BrasilValidatorTest;
public class BrasilHelper1 : IBrasilValidatorTests
{
    public bool EhCnpjValido(string? input)
    {
        return BrasilValidator1.EhCnpjValido(input);
    }

    //public bool EhCnpjValido(long? input)
    //{
    //    return BrasilValidator5.EhCnpjValido(input);
    //}

    public bool EhCpfValido(string? input)
    {
        return BrasilValidator1.EhCpfValido(input);
    }

    //public bool EhCpfValido(long? input)
    //{
    //    return BrasilValidator5.EhCpfValido(input);
    //}
}

public class BrasilValidator1Tests : BrasilValidatorTestsBase<BrasilHelper1>
{
    public BrasilValidator1Tests(BrasilHelper1 brasilHelper)
        : base(brasilHelper)
    {
    }
}