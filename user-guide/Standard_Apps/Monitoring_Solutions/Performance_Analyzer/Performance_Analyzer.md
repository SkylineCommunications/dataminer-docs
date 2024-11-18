---
uid: Performance_Analyzer
---

# Performance Analyzer

You may have found yourself in situations where you need to monitor the performance of the solution. The end user will not be satisfied with it unless it’s performant, but how do you track the performance of your code and identify the bottlenecks? Chances are you are forced to implement your own performance tracking, which can be both time consuming and difficult. That’s why we decide to create a generic Performance Analyzer solution that will streamline the process, reduce time to deliver and the cost. 

## Installing the Performance Analyzer

Performance Analyzer is divided in to following: 

### NuGet
The Performance Analyzer NuGet is designed to track and log performance metrics for methods in single or multi-threaded environments. It provides developers with an easy way to monitor execution times and track method calls across systems by logging performance data to the storage of their choice.

> [!INSTALL]
> The NuGet can be installed by downloading [Skyline.DataMiner.Utils.PerformanceAnalyzer](https://www.nuget.org/packages/Skyline.DataMiner.Utils.PerformanceAnalyzer).

> [!NOTE]
> The NuGet can be used as standalone tool.

### Low Code App
Using the NuGet allows you to gather the performance metrics for your solution, but collecting the data is only piece of the puzzle. If you want the collected metrics to bring value, you need to be able to interpret them and use them for decision-making. Performance Analyzer LCA provide a more intuitive way to interpret the data, by visualizing it.

> [!INSTALL]
> The LCA can be installed by deploying package [Performance Analyzer](https://catalog.dataminer.services/details/414894ce-21ae-48e7-b2c3-0652fff08349).