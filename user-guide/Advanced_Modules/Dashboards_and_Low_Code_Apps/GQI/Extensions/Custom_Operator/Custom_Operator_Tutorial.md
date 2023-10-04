---
uid: Custom_Operator_Tutorial
---

# Optimizing your custom operator

In this tutorial, you will learn how to:

- implement optimizations for your custom operator.

- avoid common pitfalls when optimizing custom operators.

You will use a data source that contains people with their age, income, and expenses.

| Name (string) | Age (int) | Income (int) | Expenses (int) |
|--|--|--|--|
| Luiz Nevaeh | 51 | $200,000 | $100,000 |
| Ariah Landon | 82 | $500,000 | $800,000 |
| Kenneth Brodie | 71 | $300,000 | $400,000 |
| ... | ... | ... | ... |

> [!NOTE]
> These are only the first three rows of the actual data source that contains billions more entries.

The custom operator you create will have two functions:

- Creating a new column called "Balance" that contains the difference between the *Income* and *Expenses* values.

- Obfuscating a person's real name by changing the original entries in the *Name* column to initials.

The result will look like this:

| Name | Age | Income   | Expenses | Balance   |
| ---- | --- | -------- | -------- | --------- |
| L.N. | 51  | $200,000 | $100,000 | $100,000  |
| A.L. | 82  | $600,000 | $900,000 | -$300,000 |
| K.B. | 71  | $400,000 | $300,000 | $100,000  |

> [!NOTE]
> This tutorial uses DataMiner version 10.3.2.

> [!TIP]
> See also: [Configuring a custom operator for a query](xref:GQI_Custom_Operator)

## Prerequisites

- DataMiner version 10.2.7/10.3.0 or higher.

- Depending on your DataMiner version, you may need to enable the [*GenericInterface* soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface).

  > [!NOTE]
  > Future DataMiner versions may already include this feature. To check the release version of a soft-launch option, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

  > [!TIP]
  > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

- A [minus operator](xref:Creating_Minus_Operator).

- Basic knowledge of GQI extension development.

## Create the implementation

The custom operator you created while following the [*minus operator* tutorial](xref:Creating_Minus_Operator) already implements the `IGQIColumnOperator`, the `IGQIRowOperator`, and the `IGQIInputArguments` interfaces you also need for this operator.

- To create a new column called "Balance" to store your results, you need the `IGQIColumnOperator` interface.

  This interface features a single function, `HandleColumns`, which provides the implementation with information about the available columns and makes it possible to create, rename, and add columns.

- To calculate the balance based on the *Income* and *Expenses* values and update the *Balance* column cells with the calculated result, and to obfuscate the entries in the *Name* column by replacing it with initials, you need the `IGQIRowOperator` interface.

  This interface features a single function, `HandleRow`, which allows the implementation to read and update cells within a row.

- To allow users to interact with the custom operator, implement the `IGQIInputArguments` interface.

  The `IGQIInputArguments` interface features two functions, `GetInputArguments` and `OnArgumentsProcessed`.

  - The `GetInputArguments` function allows the GQI to know the input required by the user. In this case, the user needs to choose an income column, an expenses column, and a name column.

    The `GQIColumnDropdownArgument` argument allows users to select columns by displaying a dropdown list with all applicable columns. The `Types` property ensures only columns of type `Int` are available for selection for the *Income* and *Expenses* columns and only columns of type `String` are available for selection for the *Name* column.

  - The `OnArgumentsProcessed` function, with the `OnArgumentsProcessedInputArgs` argument, allows the value to be processed.

> [!TIP]
> For an overview of all predefined interfaces that can be implemented by a custom operator, see [Building blocks](xref:CO_Building_blocks)

Change the *GQIMetaData* attribute above the class to configure a new name for your custom operator, e.g. "Balance & obfuscate".

In the end, the code of your operator should look like this:

```csharp
using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "Balance & obfuscate")]
public class MyOperator : IGQIColumnOperator, IGQIRowOperator, IGQIInputArguments
{
    private readonly GQIColumnDropdownArgument _incomeColumnArgument;
    private readonly GQIColumnDropdownArgument _expensesColumnArgument;
    private readonly GQIColumnDropdownArgument _nameColumnArgument;

    private GQIColumn _incomeColumn;
    private GQIColumn _expensesColumn;
    private GQIColumn _nameColumn;

    private readonly GQIIntColumn _balanceColumn;

    public MyOperator()
    {
        _incomeColumnArgument = new GQIColumnDropdownArgument("Income")
        {
            IsRequired = true,
            Types = new GQIColumnType[] { GQIColumnType.Int }
        };
        _expensesColumnArgument = new GQIColumnDropdownArgument("Expenses")
        {
            IsRequired = true,
            Types = new GQIColumnType[] { GQIColumnType.Int }
        };
        _nameColumnArgument = new GQIColumnDropdownArgument("Name")
        {
            IsRequired = true,
            Types = new GQIColumnType[] { GQIColumnType.String }
        };

        _balanceColumn = new GQIIntColumn("Balance");
    }

    public GQIArgument[] GetInputArguments()
    {
        return new[] {
            _incomeColumnArgument,
            _expensesColumnArgument,
            _nameColumnArgument
        };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _incomeColumn = args.GetArgumentValue(_incomeColumnArgument);
        _expensesColumn = args.GetArgumentValue(_expensesColumnArgument);
        _nameColumn = args.GetArgumentValue(_nameColumnArgument);

        return default;
    }

    public void HandleColumns(GQIEditableHeader header)
    {
        header.AddColumns(_balanceColumn);
    }

    public void HandleRow(GQIEditableRow row)
    {
        var income = row.GetValue<int>(_incomeColumn);
        var expenses = row.GetValue<int>(_expensesColumn);
        var balance = income - expenses;
        row.SetValue(_balanceColumn, balance);

        var name = row.GetValue<string>(_nameColumn);
        var obfuscatedName = ObfuscateName(name);
        row.SetValue(_nameColumn, obfuscatedName);
    }

    private string ObfuscateName(string name)
    {
        var obfuscatedName = "";
        foreach (var part in name.Split())
            obfuscatedName += $"{part[0]}.";
        return obfuscatedName;
    }
}
```

## Optimize your custom operator

This tutorial includes three use cases demonstrating different strategies to optimize your custom operators and highlights common pitfalls that may arise during the process.

### Use case: Filtering by 'Age'

With a large data set, you may want to filter your results to avoid retrieving millions of rows each time you run your custom operator. Imagine you are only interested in individuals aged 70 or older.

![Filter by age](~/user-guide/images/tutorial_2_query_1.png)

| Name | Age | Income   | Expenses | Balance   |
| ---- | --- | -------- | -------- | --------- |
| A.L. | 82  | $600,000 | $900,000 | -$300,000 |
| K.B. | 71  | $400,000 | $300,000 | $100,000  |

Results are now only displayed for subjects aged 70 or older. However, while the outcome is accurate, you may notice the query takes a very long time to load.

To expedite the process, we recommend **filtering as early as possible**. This approach prevents the need to generate results for all individuals before filtering by age. Even if the data source efficiently filters on *Age* (e.g. using internal SQL queries), the framework cannot filter directly on the data source because the custom operator is defined first.

![Prioritizing age filtering](~/user-guide/images/tutorial_2_query_2.png)

#### Optimize your custom operator: adjusting the order of operations

To avoid the need to manually filter by *Age* before executing the custom operator, you can optimize your custom operator to filter by age first automatically.

Implement the `IGQIOptimizableOperator` interface. This interface features a single method, `Optimize`, which allows you to tap into the logic that determines how operators are combined.

The `IGQIOperatorNode` argument *currentNode* represents the query node for your custom operator.

The `IGQICoreOperator` argument *nextOperator* represents the operator next in line.

This is an example of an implementation that leaves the order of operations untouched:

```csharp
public class MyOperator : IGQIColumnOperator, IGQIRowOperator, IGQIInputArguments, IGQIOptimizableOperator
{
   ...

   public IGQIQueryNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
   {
       return currentNode.Append(nextOperator);
   }
}
```

> [!CAUTION]
> Exercise caution and double-check your logic to ensure that the correct query node is returned to avoid unexpected behavior.

> [!NOTE]
> If your custom operator does not implement the `IGQIOptimizableOperator` interface, appending the next operator to the current node will be the default behavior.

This is an example of an implementation that changes the order of operations:

```csharp
public IGQIQueryNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
{
    return currentNode.Forward(nextOperator);
}
```

Use the `Forward` method to execute age filtering before defining the custom operator, resulting in improved query execution.

![Filter on age faster](~/user-guide/images/tutorial_2_query_1_to_2.png)

> [!NOTE]
> In certain cases, you can further accelerate this process by completely removing the filter operator and filtering natively.
>
> ![filter natively](~/user-guide/images/tutorial_2_query_2_to_3.png)

### Use case: Filter by 'Balance'

Imagine you are only interested in individuals aged 70 or older that have a positive number in the *Balance* column.

If you add this second filter, you will receive the following error: `Error trapped: Value cannot be null. Parameter name: column`

Two issues arise:

- Our custom operator currently forwards all operators, and not just filters.

- We use the `Forward` method to execute a filter that uses data that is yet to be introduced by our custom operator in the subsequent step.

  The optimized query now looks like this:

  ![filter by balance](~/user-guide/images/tutorial_2_query_5.png)

  We cannot filter on the *Balance* column until calculations are performed and results are generated.

To resolve these issues:

- Make sure only filters are included in the `Forward` method.

- Make sure new columns are created before any filters are applied.

#### Optimize your custom operator: only forwarding filters

The `IsFilterOperator`method modifies *nextOperator* so that this **no longer includes just any operator next in line, but only filters**.

```csharp
public IGQIQueryNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
{
    if (!nextOperator.IsFilterOperator(out var filterOperator))
        return currentNode.Append(nextOperator);
    ...
}
```

This ensures that if the next operator is not a filter, it will be appended as usual.

> [!NOTE]
> Currently, the `Optimize` method only handles filter operators by default. However, in the future, other operators may be included, and this step will become necessary if you only want to handle filters.

#### Optimize your custom operator: excluding filters dependent on other columns

The `OptimizeForFilter` method ensures **filters only move forward if they do not rely on other columns**.

```csharp
public IGQIQueryNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
{
    if (!nextOperator.IsFilterOperator(out var filterOperator))
        return currentNode.Append(nextOperator);

    return currentNode.OptimizeForFilter(filterOperator, _balanceColumn);
}
```

This ensures that if a filter depends on the new *Balance* column, it will not run first but wait until the calculations have been added to the column.

![OptimizeForFilter](~/user-guide/images/tutorial_2_query_6.png)

Once you have optimized you custom operator, you will get the expected results:

| Name | Age | Income   | Expenses | Balance   |
| ---- | --- | -------- | -------- | --------- |
| K.B. | 71  | $400,000 | $300,000 | $100,000  |

### Use case: Filter by 'Name'

Imagine you want to identify an individual even after the original entries in the *Name* column have been replaced with initials.

![filter by 'name'](~/user-guide/images/tutorial_2_query_7.png)

If you filter on a specific name, e.g. Luiz Nevaeh, you get the following result:

| Name | Age | Income | Expenses | Balance |
|--|--|--|--|--|
| L.N. | 51  | $200,000 | $100,000 | $100,000 |

The anonymization of names is essential for privacy. Consequently, filtering on a specific name should not reveal any information.

#### Optimize your custom operator: disable filtering on modified columns

The `OptimizeForFilter` method ensures that **no filters run on columns set to be modified**. You should only be able to filter on the final result, when the columns contain the correct values.

To prevent filtering on the original *Name* column, indicate it as an affected column:

```csharp
public IGQIQueryNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
{
    if (!nextOperator.IsFilterOperator(out var filterOperator))
        return currentNode.Append(nextOperator);

    var affectedColumns = new IGQIColumn[]
    {
        _balanceColumn,
        _nameColumn,
    }

    return currentNode.OptimizeForFilter(filterOperator, affectedColumns);
}
```

If a filter attempts to use an affected column, it will only run after the column has been modified.

Filtering by the original *Name* column will now yield no results.

> [!NOTE]
> The `IGQIColumn` interface is used for the affected columns array, combining both new columns (`GQIColumn`) and existing columns (`GQIEditableColumn`).
