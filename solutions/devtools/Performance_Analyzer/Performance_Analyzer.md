---
uid: Performance_Analyzer
---

# Performance Analyzer Solution

When you have implemented a solution, it is often necessary to monitor whether its performance is up to the required standards. To track the performance of a solution and identify possible bottlenecks, people often implement their own performance tracking, but this can be both time-consuming and difficult. This is where the generic Performance Analyzer Solution comes in. It will **streamline the process of analyzing the performance of a solution**, thereby reducing time to deliver and the cost.

The solution consists of two main parts: the Performance Analyzer library and the corresponding low-code app.

## Performance Analyzer library

The Performance Analyzer library is available as a NuGet package. It is designed to track and log performance metrics for methods in single- or multithreaded environments. The library provides developers with an easy way to monitor execution times and track method calls across systems by logging performance data to the storage of their choice. While you can use this library together with the low-code app, it can also be used as a standalone tool.

For information on how to install and use the library, see [Performance Analyzer library](xref:Performance_Analyzer_Library).

## Performance Analyzer app

Using the Performance Analyzer NuGet package allows you to gather the performance metrics for your solution, but collecting the data is only one piece of the puzzle. If you want the collected metrics to bring value, you need to be able to interpret them and use them for decision-making. The Performance Analyzer app, built using DataMiner Low-Code Apps, visualizes the data in such a way that you can interpret it easily and intuitively.

For information on how to install and use the app, see [Performance Analyzer app](xref:Performance_Analyzer_LCA).
