using BenchmarkDotNet.Running;
using BrasilValidatorBenchmark;

public class Program
{
    public static void Main(string[] args)
    {
        //var resultado = BenchmarkRunner.Run< BrasilValidatorBenchCpf>();
        var resultado2 = BenchmarkRunner.Run< BrasilValidatorBenchCnpj>();
    }
}