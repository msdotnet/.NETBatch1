// See https://aka.ms/new-console-template for more information
using GenericComparator.Core;
using System.Collections;
using System.Diagnostics;

var comparision = new Comparision();
Console.WriteLine($"Compare 10 & 10: {comparision.CompareValues(10, 11)}");
Console.WriteLine($"Compare 10 & 10: {comparision.CompareValues<int>(11, 12)}");
Console.WriteLine($"Compare 10 & 10: {comparision.CompareValues<double>(10.0, 10)}");
Console.WriteLine($"Compare 10 & 10: {comparision.CompareValues<string>("15.5", "15.5")}");

var nonGenericList = new ArrayList { 1, 2, 3, 4, 5, 6, 7};

Stopwatch nonGenericStopwatch = Stopwatch.StartNew();
nonGenericStopwatch.Start();
nonGenericList.Sort();
nonGenericStopwatch.Stop();
Console.WriteLine($"Time taken to sort a non generic collection: {nonGenericStopwatch.Elapsed.TotalMilliseconds}");

var genericList = new List<int> { 1, 2, 3, 4, 5, 6, 7};

Stopwatch genericStopwatch = Stopwatch.StartNew();
genericStopwatch.Start();
genericList.Sort();
genericStopwatch.Stop();
Console.WriteLine($"Time taken to sort a generic collection: {genericStopwatch.Elapsed.TotalMilliseconds}");

