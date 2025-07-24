---
uid: GQI_Ad_hoc_Optimizing_sort_operations
---

# Optimizing sort operations for ad hoc data sources

This example shows how you can optimize a sort operation by intercepting the sort operator and applying a sort operation on the underlying database.

## Use case

**Given**: An ad hoc data source called `EventDataSource` that fetches events from an SQL database.

**Goal**: Optimize the ad hoc data source such that *if* the events are sorted in a query, the sort operation is done on the database directly to maximize performance.

This is the current implementation without sort optimization:

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

## Implementing the sort optimization

To implement the sort optimization, take the following steps:

1. Add a private field `_sortOperator` of type [IGQISortOperator](xref:GQI_IGQISortOperator) where a sort operator can be stored.
2. [Implement](#implementing-the-optimize-life-cycle-method) the [IGQIOptimizableDataSource](xref:GQI_IGQIOptimizableDataSource) for the `EventDataSource` class to intercept potential sort operators and store them in the `sortOperator` field.
3. [Extend](#extending-the-onpreparefetch-life-cycle-method) the [OnPrepareFetch](xref:Ad_hoc_Life_cycle#onpreparefetch) life cycle method to apply the sort operator stored in the `sortOperator` field.

```csharp
...
using Skyline.DataMiner.Analytics.GenericInterface.Operators;

...
public sealed class EventDataSource : IGQIDataSource, IGQIOnPrepareFetch, IGQIOptimizableDataSource
{
    ...
    // Field to store the sort operator that should be optimized
    private IGQISortOperator _sortOperator;
    ...
    
    public IGQIQueryNode Optimize(IGQIDataSourceNode currentNode, IGQICoreOperator nextOperator)
    {
        // Check if the next operator is a sort operator that we can optimize
        if (nextOperator.IsSortOperator(out var sortOperator))
        {
            // The next operator is a sort operator that we can optimize
            // Store the sort operator to apply later in the life cycle
            _sortOperator = sortOperator;
    
            // Return the current node without appending the sort operator
            return currentNode;
        }
    
        // We cannot optimize the next operator
        // So we return the current node with the next operator appended to let GQI handle it
        return currentNode.Append(nextOperator);
    }
    
    public OnPrepareFetchOutputArgs OnPrepareFetch(OnPrepareFetchInputArgs args)
    {
        ...

        // If a sort operator is stored for optimization...
        if (_sortOperator != null)
        {
            // ... add an ORDER BY clause to the SQL statement
            var databaseSortFields = _sortOperator.Fields.Select(GetDatabaseSortField);
            sqlStatement += $" ORDER BY {string.Join(", ", databaseSortFields)}";
        }
    
        ...
    }
    
    // Helper method to translate the GQI sort field into the corresponding SQL expression
    private string GetDatabaseSortField(IGQISortField sortField)
    {
        var columnName = GetDatabaseColumnName(sortField.Column);
        var sortDirection = GetDatabaseSortDirection(sortField.Direction);
        return $"{columnName} {sortDirection}";
    }
    
    // Helper method that maps the GQI sort column to the corresponding database column name
    private string GetDatabaseColumnName(IGQIColumn sortColumn)
    {
        return _columns.First(c => sortColumn.Equals(c.Value)).Key;
    }
    
    // Helper method that maps the GQI sort direction to the corresponding SQL keyword
    private string GetDatabaseSortDirection(GQISortDirection sortDirection)
    {
        return (sortDirection == GQISortDirection.Descending) ? "DESC" : "ASC";
    }

    ...
}
```

### Implementing the Optimize life cycle method

Use the [Optimize](xref:Ad_hoc_Life_cycle#optimize) life cycle method defined on the [IGQIOptimizableDataSource](xref:GQI_IGQIOptimizableDataSource#igqiquerynode-optimizeigqidatasourcenode-currentnode-igqicoreoperator-nextoperator) building block interface to intercept operators that are applied directly to the ad hoc data source.

Use the [IsSortOperator](xref:GQI_IGQICoreBlock#bool-issortoperatorout-igqisortoperator-sortoperator) method on the `nextOperator` argument to check whether the next operator is a sort operator.

- If `true`: Store the sort operator in the `_sortOperator` field to optimize later in the life cycle. Return the `currentNode` without appending the sort operator to remove the operator from the query and transfer the responsability of applying the sort operation to our data source.
- If `false`: Append the `nextOperator` to the `currentNode` and return the result. This tells the GQI framework that the operator should still be applied after receiving the data from our data source. This is also the default behavior if we would not implement the [IGQIOptimizableDataSource](xref:GQI_IGQIOptimizableDataSource).

### Extending the OnPrepareFetch life cycle method

In the [OnPrepareFetch](xref:Ad_hoc_Life_cycle#onpreparefetch) life cycle method, if a sort operator was stored in the `_sortOperator` field, add an `ORDER BY` clause to the SQL statement for each [sort field](xref:GQI_IGQISortOperator#properties) in the sort operator to apply the sort operation on the database.

To construct the `ORDER BY` clause, each [sort field](xref:GQI_IGQISortField) needs to be translated into valid SQL:

- Map the [sort column](xref:GQI_IGQIColumn) back to its corresponding database column name using the `_columns` field.
- Map the [sort direction](xref:GQI_GQISortDirection) to either `ASC` or `DESC`

Finally, all translated sort fields can be joined together with `", "` and appended to the SQL statement.

## See also

- [IGQIOptimizableDataSource](xref:GQI_IGQIOptimizableDataSource) interface building block
- [IGQIOnPrepareFetch](xref:GQI_IGQIOnPrepareFetch) interface building block
- [IGQISortOperator](xref:GQI_IGQISortOperator) interface
- [Optimize](xref:Ad_hoc_Life_cycle#optimize) life cycle method
- [OnPrepareFetch](xref:Ad_hoc_Life_cycle#onpreparefetch) life cycle method
