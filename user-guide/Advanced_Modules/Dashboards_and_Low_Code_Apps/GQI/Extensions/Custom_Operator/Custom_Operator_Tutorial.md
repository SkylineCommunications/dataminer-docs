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
| Kenneth Brodie | 69 | $300,000 | $400,000 |
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
| K.B. | 69  | $400,000 | $300,000 | $100,000  |

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

- A [minus operator](xref:Creating_Minus_Operator)

- Basic knowledge of GQI extension development

## Title of the first main step

This is the implementation:

```csharp
using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "Balance & obfuscate")]
public class MyOperator : IGQIColumnOperator, IGQIRowOperator, IGQIInputArguments
{
    // 3 column input arguments: income, expenses, and name 
    private readonly GQIColumnDropdownArgument _incomeColumnArgument;
    private readonly GQIColumnDropdownArgument _expensesColumnArgument;
    private readonly GQIColumnDropdownArgument _nameColumnArgument;

    // 3 variables to store the given argument values
    private GQIColumn _incomeColumn;
    private GQIColumn _expensesColumn;
    private GQIColumn _nameColumn;

    // new balance output column
    private readonly GQIIntColumn _balanceColumn;

    public MyOperator()
    {
        // initialize input column arguments
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

        // new balance output column
        _balanceColumn = new GQIIntColumn("Balance");
    }

    public GQIArgument[] GetInputArguments()
    {
        // define input arguments
        return new[] {
            _incomeColumnArgument,
            _expensesColumnArgument,
            _nameColumnArgument
        };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        // store given argument values
        _incomeColumn = args.GetArgumentValue(_incomeColumnArgument);
        _expensesColumn = args.GetArgumentValue(_expensesColumnArgument);
        _nameColumn = args.GetArgumentValue(_nameColumnArgument);

        return default;
    }

    public void HandleColumns(GQIEditableHeader header)
    {
        // new balance output column
        header.AddColumns(_balanceColumn);
    }

    public void HandleRow(GQIEditableRow row)
    {
        // calculate and set balance
        var income = row.GetValue<int>(_incomeColumn);
        var expenses = row.GetValue<int>(_expensesColumn);
        var balance = income - expenses;
        row.SetValue(_balanceColumn, balance);

        // obfuscate name
        var name = row.GetValue<string>(_nameColumn);
        var obfuscatedName = ObfuscateName(name);
        row.SetValue(_nameColumn, obfuscatedName);
    }

    private string ObfuscateName(string name)
    {
        var obfuscatedName = "";
        // apply an obfuscation transformation
        foreach (var part in name.Split())
            obfuscatedName += $"{part[0]}.";
        return obfuscatedName;
    }
}
```

## Title of the next main step

1. First step

1. Second step

1. ...

<!-- Add as many subtitles as needed to describe the main steps. -->

## Next steps

<!-- Optionally add this title, with a link to a tutorial that logically follows this one. If there is no such tutorial, leave this out. -->