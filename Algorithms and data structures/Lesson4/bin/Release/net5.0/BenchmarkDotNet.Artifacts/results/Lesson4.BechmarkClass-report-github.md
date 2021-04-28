``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.928 (2004/?/20H1)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


```
|      Method |         Mean |     Error |    StdDev |
|------------ |-------------:|----------:|----------:|
| TestHashSet |     11.56 ns |  0.168 ns |  0.149 ns |
|    TestMass | 27,110.51 ns | 33.412 ns | 27.901 ns |
