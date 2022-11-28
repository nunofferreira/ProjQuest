``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
AMD Ryzen 7 4800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|                Method |     Mean |   Error |  StdDev |
|---------------------- |---------:|--------:|--------:|
|         SerializeJson | 251.8 ns | 1.19 ns | 0.93 ns |
|   SerializeNewtonJson | 558.9 ns | 5.05 ns | 4.72 ns |
|       DeSerializeJson | 370.1 ns | 2.00 ns | 1.67 ns |
| DeSerializeNewtonJson | 978.7 ns | 5.21 ns | 4.88 ns |
