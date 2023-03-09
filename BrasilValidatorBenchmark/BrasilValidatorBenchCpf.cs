using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BrasilValidator;
using Marrari.Helpers;

namespace BrasilValidatorBenchmark
{
    [RankColumn]
    [MemoryDiagnoser]
    public class BrasilValidatorBenchCpf

    {
        [Params("124.595.324-90")]
        public string Input { get; set; }

        [Benchmark(Baseline = true)]
        public bool EhCpfValido0()
        {
            return BrasilHelper.EhCpfValido(Input);
        }

        [Benchmark]
        public bool EhCpfValido1()
        {
            return BrasilValidator1.EhCpfValido(Input);
        }

        [Benchmark]
        public bool EhCpfValido2()
        {
            return BrasilValidator2.EhCpfValido(Input);
        }

        [Benchmark]
        public bool EhCpfValido4()
        {
            return BrasilValidator4.EhCpfValido(Input);
        }

        [Benchmark]
        public bool EhCpfValido5()
        {
            return BrasilValidator5.EhCpfValido(Input);
        }

        [Benchmark]
        public bool EhCpfValido6()
        {
            return BrasilValidator6.EhCpfValido(Input);
        }
    }
}
