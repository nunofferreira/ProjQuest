// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Numerics;

public class BenchmarkSerializers 
{
    Car car;
    string json;
    public BenchmarkSerializers()
    {
        car = new Car() { Plate = "AA-11-BB", Make = "Jaguar" };
        json = System.Text.Json.JsonSerializer.Serialize(car);
    }

    [Benchmark]
    public string SerializeJson()
    => car.ToJson(SerializerType.DotnetNative);

    [Benchmark]
    public string SerializeNewtonJson()
    => car.ToJson(SerializerType.Newtonsoft);
        
    [Benchmark]
    public Car DeSerializeJson()
    {
        return System.Text.Json.JsonSerializer.Deserialize<Car>(json);
    }

    [Benchmark]
    public Car DeSerializeNewtonJson()
    {
        return JsonConvert.DeserializeObject<Car>(json);
    }
}


