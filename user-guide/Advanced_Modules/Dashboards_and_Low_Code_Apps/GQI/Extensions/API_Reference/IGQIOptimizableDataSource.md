---
uid: GQI_IGQIOptimizableDataSource
---

# IGQIOptimizeableDataSource interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

The *IGQIOptimizableDataSource* interface can be used to optimize an ad hoc data source based on operators added to a query.

> [!TIP]
> You can implement this interface to forward sort operations to an underlying database to improve performance.

## Methods

### IGQIQueryNode Optimize(IGQIDataSourceNode currentNode, IGQICoreOperator nextOperator)

Called when an optimizeable operator is appended directly to the ad hoc data source. Given the current query node that represents the ad hoc data source and the next operator, it should return the resulting query node.

> [!IMPORTANT]
>
> - The `Optimize` method may not be called if there are no supported subsequent operators.
> - The `Optimize` method will be called each time the next operator changes.

> [!NOTE]
> Currently, the `Optimize` method only triggers for filter operators (`IGQIFilterOperator`) and (from DataMiner 10.4.0/10.4.1 onwards<!-- RN 37806 -->) sort operators (`IGQISortOperator`).

#### Parameters

- [IGQIOperatorNode](xref:GQI_IGQIDataSourceNode) `currentNode`: A reference to the current node.

- [IGQICoreOperator](xref:GQI_IGQICoreOperator) `nextOperator`: A reference to the next operator.

#### Examples

##### Optimize a sort operation

This example shows how you could optimize a sort operation by intercepting the sort operator and applying a sort operation on the underlying database.

```csharp
public sealed class MyDataSource : IGQIDataSource, IGQIOptimizableDataSource, IGQIOnPrepareFetch
{
    private readonly GQIStringColumn _myColumn = new GQIStringColumn("My column");
    private GQISortDirection? _sortDirection;
    private GQIRow[] _rows;

    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[] { _myColumn };
    }
    
    public IGQIOperatorNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
    {
        if (TryOptimizeSort(nextOperator))
        {
            // We determined that we can optimize and apply the next operator ourselves
            // So we can return the current node as is
            return currentNode;
        }
    
        // We determined that we cannot optimize the next operator
        // So we'll just append the operator and let GQI handle it
        return currentNode.Append(nextOperator);
    }
    
    private bool TryOptimizeSort(IGQICoreOperator nextOperator)
    {
        if (!nextOperator.IsSortOperator(out var sortOperator))
            return false;
    
        if (sortOperator.Fields.Count != 1)
            return false;
    
        var sortField = sortOperator.Fields[0];
        if (!sortField.Column.Equals(_column))
            return false;
    
        _sortDirection = sortField.Direction;
        return true;
    }

    public OnPrepareFetchOutputArgs OnPrepareFetch(OnPrepareFetchInputArgs args)
    {
        var sqlStatement = "SELECT * FROM MyData";

        // Add the SQL ORDER BY command if a sort operator was optimized
        switch (_sortDirection)
        {
            case GQISortDirection.Ascending:
                sqlStatement += " ORDER BY MyColumn ASC";
            case GQISortDirection.Descending:
                sqlStatement += " ORDER BY MyColumn DESC";
        }

        _rows = FetchRowsFromDatabase(sqlStatement);        

        return default;
    }

    private GQIRow[] FetchRowsFromDatabase(string sqlStatement)
    {
        // Fetch data from a SQL database ...
    } 

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
         return new GQIPage(_rows);   
    }
}
```

#### See also

- The [ad hoc data source life cycle](xref:Ad_hoc_Life_cycle).
- The [IGQIOptimizableOperator](xref:GQI_IGQIOptimizableOperator) to optimize custom operators.
