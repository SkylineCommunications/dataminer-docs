---
uid: Custom_Operator_Tutorial
---

# Optimizing your custom operator

In this tutorial, you will learn how to:

- implement optimizations for your custom operator.

- avoid common pitfalls when optimizing custom operators.

Estimated duration: 20 minutes.

You will use a data source that contains people with their age, income, and expenses.

| Name (string) | Age (int) | Income (int) | Expenses (int) |
|--|--|--|--|
| Luiz Nevaeh | 51 | $200,000 | $100,000 |
| Ariah Landon | 82 | $500,000 | $800,000 |
| Kenneth Brodie | 71 | $300,000 | $400,000 |
| ... | ... | ... | ... |

> [!NOTE]
> These are only the first three rows of the actual data source that contains billions of entries.

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

- If you are using a DataMiner version prior to DataMiner 10.3.0 [CU10]/10.4.1, make sure the [*GenericInterface* soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface) is enabled.

  > [!TIP]
  > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

- A [minus operator](xref:Creating_Minus_Operator).

- Basic knowledge of GQI extension development.

## Overview

- [Step 1: Create the implementation](#step-1-create-the-implementation)
- [Step 2: Optimize your custom operator](#step-2-optimize-your-custom-operator)

  - [Use case: Filtering by 'Age'](#use-case-filtering-by-age)
  - [Use case: Filtering by 'Balance'](#use-case-filter-by-balance)
  - [Use case: Filtering by 'Name'](#use-case-filter-by-name)

## Step 1: Create the implementation

Change the *GQIMetaData* attribute above the class to configure a new name for your custom operator, e.g. "Balance & obfuscate".

The code of your operator should look like this:

```csharp
using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "Balance & obfuscate")]
public class MyOperator : IGQIColumnOperator, IGQIRowOperator, IGQIInputArguments
{
    // You need 3 column input arguments: income, expenses, and name 
    private readonly GQIColumnDropdownArgument _incomeColumnArgument;
    private readonly GQIColumnDropdownArgument _expensesColumnArgument;
    private readonly GQIColumnDropdownArgument _nameColumnArgument;

    // You need 3 variables to store the given argument values
    private GQIColumn _incomeColumn;
    private GQIColumn _expensesColumn;
    private GQIColumn _nameColumn;

    // Define your new balance output column
    private readonly GQIIntColumn _balanceColumn;

    public MyOperator()
    {
        // Initialize your input column arguments
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

        // Initialize your new balance output column
        _balanceColumn = new GQIIntColumn("Balance");
    }

    public GQIArgument[] GetInputArguments()
    {
        // Tell the framework what your input arguments are
        return new[] {
            _incomeColumnArgument,
            _expensesColumnArgument,
            _nameColumnArgument
        };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        // Store the given argument values
        _incomeColumn = args.GetArgumentValue(_incomeColumnArgument);
        _expensesColumn = args.GetArgumentValue(_expensesColumnArgument);
        _nameColumn = args.GetArgumentValue(_nameColumnArgument);

        return default;
    }

    public void HandleColumns(GQIEditableHeader header)
    {
        // Add your new balance output column
        header.AddColumns(_balanceColumn);
    }

    public void HandleRow(GQIEditableRow row)
    {
        // Calculate and set balance
        var income = row.GetValue<int>(_incomeColumn);
        var expenses = row.GetValue<int>(_expensesColumn);
        var balance = income - expenses;
        row.SetValue(_balanceColumn, balance);

        // Obfuscate name
        var name = row.GetValue<string>(_nameColumn);
        var obfuscatedName = ObfuscateName(name);
        row.SetValue(_nameColumn, obfuscatedName);
    }

    private string ObfuscateName(string name)
    {
        var obfuscatedName = "";
        // Apply an obfuscation transformation
        foreach (var part in name.Split())
            obfuscatedName += $"{part[0]}.";
        return obfuscatedName;
    }
}
```

## Step 2: Optimize your custom operator

This tutorial includes three use cases demonstrating different strategies to optimize your custom operators and highlights common pitfalls that may arise during the process.

### Use case: Filtering by 'Age'

With a large data set, you may want to filter your results to avoid retrieving millions of rows each time you run your custom operator. Imagine you are only interested in individuals aged 70 or older.

![Filter by age](~/dataminer/images/tutorial_2_query_1.png)

| Name | Age | Income   | Expenses | Balance   |
| ---- | --- | -------- | -------- | --------- |
| A.L. | 82  | $600,000 | $900,000 | -$300,000 |
| K.B. | 71  | $400,000 | $300,000 | $100,000  |

Results are now only displayed for subjects aged 70 or older. However, while the outcome is accurate, you may notice the query takes a very long time to load.

To expedite the process, we recommend **filtering as early as possible**. This approach prevents the need to generate results for all individuals before filtering by age. Even if the data source efficiently filters on *Age* (e.g. using internal SQL queries), the framework cannot filter directly on the data source because the custom operator is defined first.

![Prioritizing age filtering](~/dataminer/images/tutorial_2_query_2.png)

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

![Filter on age faster](~/dataminer/images/tutorial_2_query_1_to_2.png)

> [!NOTE]
> In certain cases, you can further accelerate this process by completely removing the filter operator and filtering natively.
>
> ![filter natively](~/dataminer/images/tutorial_2_query_2_to_3.png)

### Use case: Filter by 'Balance'

Imagine you are only interested in individuals aged 70 or older that have a positive number in the *Balance* column.

If you add this second filter, you will receive the following error: `Error trapped: Value cannot be null. Parameter name: column`

Two issues arise:

- Our custom operator currently forwards all operators, and not just filters.

- You use the `Forward` method to execute a filter that uses data that is yet to be introduced by our custom operator in the subsequent step.

  The optimized query now looks like this:

  ![filter by balance](~/dataminer/images/tutorial_2_query_5.png)

  You cannot filter on the *Balance* column until calculations are performed and results are generated.

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

![OptimizeForFilter](~/dataminer/images/tutorial_2_query_6.png)

Once you have optimized you custom operator, you will get the expected results:

| Name | Age | Income   | Expenses | Balance   |
| ---- | --- | -------- | -------- | --------- |
| K.B. | 71  | $400,000 | $300,000 | $100,000  |

### Use case: Filter by 'Name'

Imagine you want to identify an individual even after the original entries in the *Name* column have been replaced with initials.

![filter by 'name'](~/dataminer/images/tutorial_2_query_7.png)

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
> The [IGQIColumn](xref:GQI_IGQIColumn) interface is used for the affected columns array, combining both new columns ([GQIColumn](xref:GQI_GQIColumn)) and existing columns (`GQIEditableColumn`).
