---
uid: GQI_Ad_hoc_Optimizing_filter_operations
---

# Optimizing filter operations for ad hoc data sources

This example shows how you can optimize a filter operation by intercepting the filter operator and applying a filter on the underlying database.

It can be used from DataMiner 10.5.0 [CU11]/10.6.2 onwards when using the [GQI DxM](xref:GQI_DxM).<!-- RN 44230 -->

> [!IMPORTANT]
> When optimizing, **avoid changing the functional behavior of a filter**. Both the GQI framework and the end user rely on the fact that an optimization does not change the final result of the query. Respect case-insensitive comparisons, regex options, etc.

## Use case

This example uses an ad hoc data source called `EventDataSource`, which fetches events from an SQL database.

The goal is to optimize the ad hoc data source such that when the events are filtered by ID in a query, the filtering is done on the database directly to maximize performance.

This is the starting implementation without filter optimization:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "Events from database")]
public sealed class EventDataSource : IGQIDataSource, IGQIOnPrepareFetch
{
    private readonly Dictionary<string, GQIColumn> _columns = new Dictionary<string, GQIColumn>
        {
            { "id", new GQIStringColumn("Event Id") },
            { "name", new GQIStringColumn("Event name") },
            { "time", new GQIDateTimeColumn("Event time") },
            { "priority", new GQIIntColumn("Event priority") },
        };
    
    private GQIRow[] _rows;
    
    public GQIColumn[] GetColumns()
    {
        return _columns.Values.ToArray();
    }
    
    public OnPrepareFetchOutputArgs OnPrepareFetch(OnPrepareFetchInputArgs args)
    {
        var sqlStatement = "SELECT id, name, time, priority FROM events";
    
        _rows = FetchRowsFromDatabase(sqlStatement);
    
        return default;
    }
    
    private GQIRow[] FetchRowsFromDatabase(string sqlStatement)
    {
        // Connect and fetch events from the SQL database
        ...
    }
    
    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        return new GQIPage(_rows);
    }
}
```

## Implementing the filter optimization

To implement the filter optimization, take the following steps:

1. Add a private field `_filterEventId` of type `string`, where an event ID can be stored to filter on.

1. Define a private helper method `TryGetFilterEventId` that will try to extract the event ID to filter on from operators applied to the data source. It takes in a [IGQICoreOperator](xref:GQI_IGQICoreOperator) and has an `out` parameter of type `string`. It will return true if it can find an event ID to filter on when:

   1. The `nextOperator` is a [IGQIFilterOperator](xref:GQI_IGQIFilterOperator). This can be checked using the [IsFilterOperator](xref:GQI_IGQICoreBlock#bool-isfilteroperatorout-igqifilteroperator-filteroperator) method.
   1. The filter of the filter operator is a [IGQIValueFilter](xref:GQI_IGQIValueFilter).
   1. The column on which the filter is applied is the `id` column.
   1. The filter is comparing the exact event ID value using `GQIFilterMethod.Equals`.
   1. The filter value is a `string` value that represents the event ID to filter on.

1. Implement the [IGQIOptimizableDataSource](xref:GQI_IGQIOptimizableDataSource) for the `EventDataSource` class to intercept potential filter operators; try to extract an event ID and store that in the `_filterEventId` field:

   1. Use the [Optimize](xref:Ad_hoc_Life_cycle#optimize) lifecycle method defined on the [IGQIOptimizableDataSource](xref:GQI_IGQIOptimizableDataSource#igqiquerynode-optimizeigqidatasourcenode-currentnode-igqicoreoperator-nextoperator) building block interface to intercept operators that are applied directly to the ad hoc data source.

   1. Call the `TryGetFilterEventId` helper method you defined earlier to try to extract an event ID to filter on.

      - If `true`: Store the event ID in the `_filterEventId` field to use later in the lifecycle. Return the `currentNode` without appending the filter operator to remove the operator from the query and transfer the responsibility of applying the filter to the data source.
      - If `false`: Append the `nextOperator` to the `currentNode` and return the result. This tells the GQI framework that the operator should still be applied after the data is received from the data source. This would also be the default behavior in case the [IGQIOptimizableDataSource](xref:GQI_IGQIOptimizableDataSource) interface was not implemented.

1. Extend the [OnPrepareFetch](xref:Ad_hoc_Life_cycle#onpreparefetch) lifecycle method to apply the filter on the `id` field:

   1. Create an SQL `WHERE` clause to filter the database table by comparing the `id` column to the stored `_filterEventId`.

      Since the original GQI string filter works with **case-insensitive** string comparisons, you should use `UPPER` to convert the values to uppercase before comparing them. That way, the behavior remains consistent: `$"WHERE UPPER(id) = UPPER({_filterEventId})"`

   1. Append the new `WHERE` clause to the SQL statement.

This will be the result:

```csharp
...
using Skyline.DataMiner.Analytics.GenericInterface.Operators;

...
public sealed class EventDataSource : IGQIDataSource, IGQIOnPrepareFetch, IGQIOptimizableDataSource
{
    ...
    // Field to store the event ID that should be filtered on
    private string _filterEventId;
    ...

    public IGQIQueryNode Optimize(IGQIDataSourceNode currentNode, IGQICoreOperator nextOperator)
    {
        // Try to extract an event ID to filter on from the next operator
        if (TryGetFilterEventId(nextOperator, out _filterEventId))
        {
            // If you have successfully extracted the event ID to filter on,
            // you can drop the next operator and just return the current node
            return currentNode;
        }

        // Otherwise, you cannot optimize the next operator,
        // so you return the current node with the next operator appended to let GQI handle it
        return currentNode.Append(nextOperator);
    }

    // Helper method to try and extract an event ID filter from the next operator
    private bool TryGetFilterEventId(IGQICoreOperator nextOperator, out string eventId)
    {
        eventId = default;

        // The next operator must be a filter operator
        if (!nextOperator.IsFilterOperator(out var filterOperator))
            return false;

        // The filter of the operator should be a value filter
        if (!(filterOperator.Filter is IGQIValueFilter valueFilter))
            return false;

        // The filter column should be the event ID column
        var idColumn = _columns["id"];
        if (!valueFilter.Column.Equals(idColumn))
            return false;

        // The filter should be using equality to filter on the ID
        if (valueFilter.Method != GQIFilterMethod.Equals)
            return false;

        // The filter value should be a string value representing the event ID
        if (!(valueFilter.Value is string stringValue))
            return false;

        eventId = stringValue;
        return true;
    }

    public OnPrepareFetchOutputArgs OnPrepareFetch(OnPrepareFetchInputArgs args)
    {
        ...

        // If you have an event ID to filter on...
        if (_filterEventId != null)
        {
            // ... modify the SQL statement accordingly,
            // using UPPER to preserve the case-insensitive semantics
            sqlStatement += $" WHERE UPPER(id) = UPPER('{_filterEventId}')";
        }

        ...
    }
    

    ...
}
```

## Further optimizations

This basic example could be extended to support more optimizations:

- Optimize event ID filters with filter methods that do not match the exact value like `Contains` or `MatchesRegex`.
- Optimize event ID filters that use negated filter methods like `DoesNotEqual`, `DoesNotContain`, and `DoesNotMatchRegex`.
- Optimize filters for the other columns `name`, `time`, and `priority` as well.
- Optimize other types of [IGQIFilter](xref:GQI_IGQIFilter) to support a combination of multiple filters.

## See also

- [IGQIOptimizableDataSource](xref:GQI_IGQIOptimizableDataSource) interface building block
- [IGQIOnPrepareFetch](xref:GQI_IGQIOnPrepareFetch) interface building block
- [IGQIFilterOperator](xref:GQI_IGQIFilterOperator) interface
- [IGQIValueFilter](xref:GQI_IGQIValueFilter) interface
- [GQIFilterMethod](xref:GQI_GQIFilterMethod) enum
- [Optimize](xref:Ad_hoc_Life_cycle#optimize) lifecycle method
- [OnPrepareFetch](xref:Ad_hoc_Life_cycle#onpreparefetch) lifecycle method
