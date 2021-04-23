``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.928 (2004/?/20H1)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.202
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


```
|                  Method |     Mean |   Error |  StdDev |
|------------------------ |---------:|--------:|--------:|
|  TestPointDistanceClass | 239.4 μs | 1.14 μs | 1.07 μs |
|       PointDistanceTect | 350.5 μs | 0.37 μs | 0.31 μs |
| PointDistanceDoubleTect | 369.1 μs | 0.22 μs | 0.19 μs |
|  PointDistanceShortTect | 311.6 μs | 0.91 μs | 0.81 μs |
