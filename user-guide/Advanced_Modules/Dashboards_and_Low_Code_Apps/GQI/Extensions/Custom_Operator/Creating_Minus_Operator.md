---
uid: Creating_Minus_Operator
---

# Creating a minus operator

In this tutorial, you will learn how to create a custom operator that subtracts two values and adds the result to a table. You could, for example, use this operator to calculate the profit for each project in this table:

| Project (String) | Customer (Int) | Sales (Double) | Cost (Double) |
| ---------------- | -------------- | -------------- | ------------- |
| Project 1        | Customer A     | €1000          | €750.0        |
| Project 2        | Customer B     | €2000          | €250.0        |
| Project 3        | Customer A     | €1500          | €500.0        |

The result will look like this:

| Project (String) | Customer (Int) | Sales (Double) | Cost (Double) | Profit (Double) |
| ---------------- | -------------- | -------------- | ------------- | --------------- |
| Project 1        | Customer A     | €1000          | €750.0        | €250.0          |
| Project 2        | Customer B     | €2000          | €250.0        | €1750.0         |
| Project 3        | Customer A     | €1500          | €500.0        | €1000.0         |

Estimated duration: 20 minutes.

> [!TIP]
> See also: [Configuring a custom operator for a query](xref:GQI_Custom_Operator)

> [!NOTE]
> This tutorial uses DataMiner version 10.3.2.

## Prerequisites

- DataMiner version 10.2.7/10.3.0 or higher.

- Depending on your DataMiner version, you may need to enable the [*GenericInterface* soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface).

  > [!NOTE]
  > To check whether this soft-launch option is required in your DataMiner version, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

  > [!TIP]
  > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

- Basic knowledge of GQI extension development.

## Overview

- [Step 1: Create a basic implementation](#step-1-create-a-basic-implementation)
- [Step 2: Make the operator reusable](#step-2-make-the-operator-reusable)
- [Final result](#final-result)

## Step 1: Create a basic implementation

Create a new class that implements the `IGQIColumnOperator` and the `IGQIRowOperator` interfaces.

- To create a new column called "Profit" to store your results, you need the `IGQIColumnOperator` interface.

  This interface features a single function, `HandleColumns`, which provides the implementation with information about the available columns and makes it possible to create, rename, and add columns.

- To calculate the profit based on the *Sales* and *Cost* values and update the *Profit* column cells with the calculated result, you need the `IGQIRowOperator` interface.

  This interface features a single function, `HandleRow`, which allows the implementation to read and update cells within a row.

> [!TIP]
> For an overview of all predefined interfaces that can be implemented by a custom operator, see [Building blocks](xref:CO_Building_blocks)

Above the class, add the *GQIMetaData* attribute to configure the name of the data source as displayed in the Dashboards app or Low-Code Apps.

> [!NOTE]
> All types needed to create a user-definable operator can be found within the `Skyline.DataMiner.Analytics.GenericInterface` namespace.

```csharp
[GQIMetaData(Name = "Minus operator")]
public class MyCustomOperator : IGQIColumnOperator, IGQIRowOperator
{
    private GQIDoubleColumn _profitColumn = new GQIDoubleColumn("Profit");

    public void HandleColumns(GQIEditableHeader header)
    {
        header.AddColumns(_profitColumn);
    }

    public void HandleRow(GQIEditableRow row)
    {
        var sales = row.GetValue<double>("Sales");
        var cost = row.GetValue<double>("Cost");
        var profit = sales - cost;

        row.SetValue(_profitColumn, profit, $"€{profit}");
    }
}
```

## Step 2: Make the operator reusable

The solution you have just created is specific to the data. To make the operator more generic and reusable, allow users to select the columns used for subtraction in the query builder and choose a custom name for the newly generated column. This means you will no longer hardcode the column name ("Profit") or the columns that contain the *Sales* and *Cost* values.

To allow users to interact with the custom operator, implement the `IGQIInputArguments` interface.

The `IGQIInputArguments` interface features two functions, `GetInputArguments` and `OnArgumentsProcessed`.

- The `GetInputArguments` function allows the GQI to know the input required by the user. In this case, the user needs to choose a first column, a second column, and a column name.

  The `GQIColumnDropdownArgument` argument allows users to select columns by displaying a dropdown list with all applicable columns. The `Types` property ensures only columns of type `Double` are available for selection.

  ```csharp
  private GQIColumnDropdownArgument _firstColumnArg = new GQIColumnDropdownArgument("First column") { IsRequired = true, Types = new GQIColumnType[] { GQIColumnType.Double } };
  private GQIColumnDropdownArgument _secondColumnArg = new GQIColumnDropdownArgument("Second column") { IsRequired = true, Types = new GQIColumnType[] { GQIColumnType.Double } };
  private GQIStringArgument _nameArg = new GQIStringArgument("Column name") { IsRequired = true };

  public GQIArgument[] GetInputArguments()
  {
      return new GQIArgument[] { _firstColumnArg, _secondColumnArg, _nameArg };
  }
  ```

- The `OnArgumentsProcessed` function, with the `OnArgumentsProcessedInputArgs` argument, allows the value to be processed.

  ```csharp
  private GQIColumn _firstColumn;
  private GQIColumn _secondColumn;
  private GQIDoubleColumn _newColumn;

  public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
  {
      _firstColumn = args.GetArgumentValue(_firstColumnArg);
      _secondColumn = args.GetArgumentValue(_secondColumnArg);
      _newColumn = new GQIDoubleColumn(args.GetArgumentValue(_nameArg));

      return new OnArgumentsProcessedOutputArgs();
  }
  ```

## Final result

In the end, the code of your minus operator should look like this:

```csharp
using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "Minus operator")]
public class MyCustomOperator : IGQIColumnOperator, IGQIRowOperator, IGQIInputArguments
{
    private GQIColumnDropdownArgument _firstColumnArg = new GQIColumnDropdownArgument("First column") { IsRequired = true, Types = new GQIColumnType[] { GQIColumnType.Double } };
    private GQIColumnDropdownArgument _secondColumnArg = new GQIColumnDropdownArgument("Second column") { IsRequired = true, Types = new GQIColumnType[] { GQIColumnType.Double } };
    private GQIStringArgument _nameArg = new GQIStringArgument("Column name") { IsRequired = true };

    private GQIColumn _firstColumn;
    private GQIColumn _secondColumn;
    private GQIDoubleColumn _newColumn;

    public GQIArgument[] GetInputArguments()
    {
        return new GQIArgument[] { _firstColumnArg, _secondColumnArg, _nameArg };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _firstColumn = args.GetArgumentValue(_firstColumnArg);
        _secondColumn = args.GetArgumentValue(_secondColumnArg);
        _newColumn = new GQIDoubleColumn(args.GetArgumentValue(_nameArg));

        return new OnArgumentsProcessedOutputArgs();
    }

    public void HandleColumns(GQIEditableHeader header)
    {
        header.AddColumns(_newColumn);
    }

    public void HandleRow(GQIEditableRow row)
    {
        var firstValue = row.GetValue<double>(_firstColumn);
        var secondValue = row.GetValue<double>(_secondColumn);
        var result = firstValue - secondValue;

        row.SetValue(_newColumn, result, $"€{result}");
    }
}
```
