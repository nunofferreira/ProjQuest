// See https://aka.ms/new-console-template for more information
using Benchmark;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Numerics;

Console.WriteLine("BenchmarkDotNet");


//var summary = BenchmarkRunner.Run<BenchmarkSerializers>();


var s = $""""
                        sdashkjl 
                    \ejkhqg\"""qe keqw629 
                ""dsa,
            sdaqhgf ]{5 + 7}
        sdad
     """";

var t = $@"                sdashkjl 
            \ejkhqg\""""""qe keqw629 
        """"dsa,{5 + 7}
    sdaqhgf ]
  sdad";
Console.WriteLine(s);
Console.WriteLine(t);

static void Main(string[] args)
{
    BenchmarkRunner.Run<ListVersusDictionary>();
}

public class ListVersusDictionary
{
    private const int NumElements = 1_000;
    private readonly Random _rnd;
    private readonly string[] _keys;
    private readonly List<string> _list;
    private readonly Dictionary<string, string> _dict;
    public ListVersusDictionary() { }
    //[Benchmark]
    //public string GetValueFromDictionary() { }
    //[Benchmark]
    //public string GetValueFromList() { }
    //private string RandomKey() { }
    //private IEnumerable<string> GetKeys(int numElements) { }
}


