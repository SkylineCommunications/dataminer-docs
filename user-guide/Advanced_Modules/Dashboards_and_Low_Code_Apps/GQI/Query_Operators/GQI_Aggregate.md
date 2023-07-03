---
uid: GQI_Aggregate
---

# Aggregate

The *Aggregate* query operator allows you to aggregate data from the data source. After you have selected this option, first select the aggregation column, and the method that should be used. Depending on the type of data available in the selected column, different methods are available, e.g. Average, Count, Distinct Count, Maximum, Median, Minimum, Percentile 90/95/98 or Standard deviation.

You can then further filter the result by applying another operator. An additional *Group by* operator is available for this, which will display the result of the aggregation operation for each different item in the column selected in the *Group by column* box.

> [!NOTE]
>
> - From DataMiner 10.3.3/10.4.0 onwards, after an aggregation operation, you can apply multiple *GroupBy* operations.
> - From DataMiner 10.1.0/10.1.3 onwards, exception values are not taken into account, except for the Count and Distinct Count methods. <!-- RN35355 -->
