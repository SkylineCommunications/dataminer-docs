---
uid: Performance_Analyzer_LCA
---

# Performance Analyzer Low-Code App

The second component of the Performance Analyzer solution is the Low-Code App. Raw numbers can often be difficult to interpret, which is why Performance Analyzer provides a built-in method to visualize the collected data using the Low-Code App.

## Problem

Let's consider the following example:

You have collected the necessary performance metrics from your solution, and now need to make decisions based on those results.

## Visualizing the performance

Collecting the data is only piece of the puzzle, if you want the solution to bring value, you need to be able to make sense of the data and make decision based on it. As human, you might struggle to comprehend the numbers, particularly when they are extremely large or, as is often the case with performance metrics, very small. This makes it essential to provide a more intuitive way to interpret the data, such as visualization. Performance Analyzer provides a generic LCA that works out of the box, along with collection of GQIs that allows you to visualize the data based on your specific needs.

![Performance Analyzer LCA](~/user-guide/images/performance_analyzer_lca.png)

1.	**Performance Analyzer Metrics Folder**: Defines the folder where performance data files are located. By default that folder is located at *C:\Skyline_Data\PerformanceAnalyzer*.
2.	**Files**: Shows a list of files available in the selected directory, with each file’s name, creation date, last modified date, and size. This table allows you to choose specific data file to analyze.
3.	**Collections**: Displays a list of collections in the selected file. In Performance Analyzer terms, a "collection" simply refers to one disposal of the collector.
4.	**Collections Filter**: Enables filtering of collections based on metadata, making it easy to locate a specific collection or understand its context.
5.	**Collection Metadata**: Understanding the context in which a collection was created is crucial, and this section provides all the relevant details. 
6.	**Metrics**: Provides a detailed list of individual metrics, each representing a specific operation or method call. The table includes information such as class, method, start and end times, making it easier to identify which parts of the code impact the performance. 
7.	**Metrics Filter**: Allows filtering metrics by specific classes, methods, execution time ranges, or metadata.
8.	**Metric Metadata**: Understanding metrics without context is challenging, so this section provides it.
9.	**Timeline**: Visual representation of every metric. You can focus on a specific block by double-clicking its corresponding table entry for it.
10.	**Metric Metadata (Timeline)**: Provides overview of the context for selected timeline block.
