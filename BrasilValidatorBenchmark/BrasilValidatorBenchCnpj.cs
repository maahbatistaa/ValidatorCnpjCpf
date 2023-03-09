using BenchmarkDotNet.Attributes;
using BrasilValidator;
using Marrari.Helpers;

namespace BrasilValidatorBenchmark
{
    [RankColumn]
    [MemoryDiagnoser]
    public class BrasilValidatorBenchCnpj
    {
        [Params("18322588000165")]
        public string Input { get; set; }

        [Benchmark(Baseline = true)]
        public bool EhCnpjValido0()
        {
            return BrasilHelper.EhCnpjValido(Input);
        }

        [Benchmark]
        public bool EhCnpjValido1()
        {
            return BrasilValidator1.EhCnpjValido(Input);
        }

        [Benchmark]
        public bool EhCnpjValido2()
        {
            return BrasilValidator2.EhCnpjValido(Input);
        }

        [Benchmark]
        public bool EhCnpjValido4()
        {
            return BrasilValidator4.EhCnpjValido(Input);
        }

        [Benchmark]
        public bool EhCnpjValido5()
        {
            return BrasilValidator5.EhCnpjValido(Input);
        }

        [Benchmark]
        public bool EhCnpjValido6()
        {
            return BrasilValidator6.EhCnpjValido(Input);
        }
    }
}
