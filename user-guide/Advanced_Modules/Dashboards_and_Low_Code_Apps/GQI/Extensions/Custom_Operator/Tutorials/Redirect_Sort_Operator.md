---
uid: GQI_Redirect_Sort_Tutorial
---

# Providing a custom sort order

In this tutorial, you will learn a technique that will allow you to implement a custom GQI column sort order using a custom operator.

This technique is available from DataMiner 10.4.5/10.5.0 onwards.<!-- RN 39136 -->

Expected duration: 15 minutes.

## When do I need a custom sort order?

By default, every column in a GQI result can be sorted. However, because GQI is so generic, the sort order you use may not be suited for all types of data.

For example, a column containing text is sorted alphabetically by default, which is perfect for most use cases. However, it does not behave as desired when the values in that column are IP addresses:

| IP address   |
|--------------|
| 127.0.0.1    |
| 19.10.53.4   |
| 192.168.11.1 |
| 192.168.7.1  |

Rather, we would prefer the address to be sorted by the value of their respective octets, like so:

| IP address   |
|--------------|
| 19.10.53.4   |
| 127.0.0.1    |
| 192.168.0.1  |
| 192.168.11.1 |

We will keep using this example in the rest of the tutorial.

## How will we achieve this?

We can define a custom sort order for the IP address column by implementing a custom operator that "redirects" the sort operation on one column to another.

First of all, what do we mean by "redirecting" a sort operator? It means we want to change an incoming sort operator in our query, and modify it so it sorts on a different column. More concretely, if someone sorts the query on column A, we want to intercept this with a custom operator to change it to a sort operation on column B.

![Redirect sort operation diagram](~/user-guide/images/GQI_redirect_sort.png)

Looking at our IP address example, we want to change the sort operation on our IP address column to another column that contains an "IP address ranking". This IP address ranking will be a column that, when sorted using the default GQI sort order, will result in the desired order for our IP address column.

## Overview

- [Step 1: Provide a column with the ranking](#step-1-provide-a-column-with-the-ranking)
- [Step 2: Create a new custom operator to redirect sort operations](#step-2-create-a-new-custom-operator-to-redirect-sort-operations):
- [Step 3: Provide column arguments](#step-3-provide-column-arguments)
- [Step 4: Provide the necessary dependencies](#step-4-provide-the-necessary-dependencies)
- [Step 5: Implement the sort redirection on a high level](#step-5-implement-the-sort-redirection-on-a-high-level)
- [Step 6: Implement the sort redirection details](#step-6-implement-the-sort-redirection-details)
- [Step 7: Build a query using the new custom operator](#step-7-build-a-query-using-the-new-custom-operator)

## Step 1: Provide a column with the ranking

Depending on the specific use case, the column might be readily available in the data source. However, in our example we will implement a new custom operator that will add a new column and fill it with a rank based on the IP address.

[!code-csharp[](SLC-GQIO-IPAddressSortRank.cs)]

## Step 2: Create a new custom operator to redirect sort operations

We create a new custom operator called `SortRedirector` and give it the display name "Redirect sort". We already added all the necessary `using` statements at the top. In the following steps, we will be added the rest of the code.

```csharp
using Skyline.DataMiner.Analytics.GenericInterface;
using Skyline.DataMiner.Analytics.GenericInterface.Operators;
using System.Linq;

[GQIMetaData(Name = "Redirect sort")]
public sealed class SortRedirector
{
    // The implementation will go here.
}
```

## Step 3: Provide column arguments

In order to redirect from one column to another, we will need to know which columns. Therefore, we will implement the [IGQIInputArguments](xref:GQI_IGQIInputArguments) interface to give us life cycle methods where we can define some custom arguments and retrieve their value.

We will need 2 arguments:

- A column dropdown argument to select the column from which we want to redirect the sorting away.
- A column dropdown argument to select the column to which we want to redirect the sorting to.

```csharp
public sealed class SortRedirector : IGQIInputArguments
{
    // Fields to store the arguments
    private readonly GQIColumnDropdownArgument _fromArg;
    private readonly GQIColumnDropdownArgument _toArg;

    // Fields to store the argument values
    private IGQIColumn _fromColumn;
    private IGQIColumn _toColumn;

    // A constructor to initialize the arguments
    public SortRedirector()
    {
        _fromArg = new GQIColumnDropdownArgument("Redirect from column") { IsRequired = true };
        _toArg = new GQIColumnDropdownArgument("Redirect to column") { IsRequired = true };
    }

    // Life cycle method to define the arguments
    public GQIArgument[] GetInputArguments()
    {
        return new[] { _fromArg, _toArg };
    }

    // Life cycle method to retrieve the argument values
    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _fromColumn = args.GetArgumentValue(_fromArg);
        _toColumn = args.GetArgumentValue(_toArg);
        return default;
    }
}
```

## Step 4: Provide the necessary dependencies

Since operators in GQI are immutable, we will need to create our own new instance of the sort operator if we want to modify the original one.

The way to do this, is by using the [Factory](xref:GQI_OnInitInputArgs#properties) property on the [OnInitInputArgs](xref:GQI_OnInitInputArgs).This gives us access to the [IGQIFactory](xref:GQI_IGQIFactory) interface that provides methods to construct a new sort operator.

So, in order to get access to the [OnInitInputArgs](xref:GQI_OnInitInputArgs), we need to implement the [IGQIOnInit](xref:GQI_IGQIOnInit) interface for our custom operator:

```csharp
public sealed class SortRedirector : IGQIInputArguments, IGQIOnInit
{
    //...omitted for brevity

    // A field to store a reference to the IGQIFactory
    private IGQIFactory _gqi;

    // ...omitted for brevity

    public OnInitOutputArgs OnInit(OnInitInputArgs args)
    {
        // Save the factory in our local field for later use
        _gqi = args.Factory;
        return default;
    }
}
```

## Step 5: Implement the sort redirection on a high level

Now that we are all set up, it is time to implement the main logic of our sort redirector. This logic will be triggered by the [Optimize](xref:GQI_IGQIOptimizableOperator#igqiquerynode-optimizeigqioperatornode-currentnode-igqicoreoperator-nextoperator) life cycle method of the [IGQIOptimizableOperator](xref:GQI_IGQIOptimizableOperator) interface.

The high-level optimization logic will go like this:

1. If the next operator is not a sort operator, just forward it.
1. Otherwise, if it is a sort operator, redirect it from the `fromColumn` to the `toColumn`.
1. Forward our redirected sort operator.

Now, let us implement this:

```csharp
public sealed class SortRedirector : IGQIInputArguments, IGQIOnInit, IGQIOptimizableOperator
{
    //...omitted for brevity

    public IGQIQueryNode Optimize(IGQIOperatorNode currentNode, IGQICoreOperator nextOperator)
    {
        if (!nextOperator.IsSortOperator(out var sortOperator))
            return currentNode.Forward(nextOperator);
    
        var redirectedSortOperator = Redirect(sortOperator);
        return currentNode.Forward(redirectedSortOperator);
    }
    
    private IGQISortOperator Redirect(IGQISortOperator sortOperator)
    {
        // We still need to implement the redirect details here
    }
}
```

> [!TIP]
> See also the following API references:
>
> - [IGQICoreBlock.IsSortOperator](xref:GQI_IGQICoreBlock#bool-issortoperatorout-igqisortoperator-sortoperator)
> - [IGQIOperatorNode.Forward](xref:GQI_IGQIOperatorNode#igqiquerynode-forwardigqicoreoperator-nextoperator)

## Step 6: Implement the sort redirection details

It is now time to put the icing on the cake and finalize our sort redirector with the final details.

For this, it is important to know that a sort operator in GQI consists of sort fields, and that each sort field defines a sorting on a specific column together with a sort direction. So, for our redirection algorithm, we will need to consider every sort field separately, and keep the ones we do not care about intact.

The algorithm goes as follows:

1. If the sort operator contains no sort field for our `fromColumn`, we can return the original sort operator. No changes are required.
1. Otherwise, construct an array of redirected sort fields where each sort field is determined as follows:

    1. If the sort field is not for our `fromColumn`, keep it as it is.
    1. Otherwise, construct a new sort field for `toColumn` with the same sort direction.

1. Construct and return a new sort operator based on the redirected sort fields.

```csharp
public sealed class SortRedirector : IGQIInputArguments, IGQIOnInit, IGQIOptimizableOperator
{
    //...omitted for brevity
    
    private IGQISortOperator Redirect(IGQISortOperator sortOperator)
    {
        // Check if we need to do some redirecting
        if (!sortOperator.Fields.Any(field => field.Column.Equals(_fromColumn)))
            return sortOperator; // No redirect necessary
    
        // Construct the redirected sort fields based on the original sort fields
        var redirectedFields = sortOperator.Fields.Select(field =>
        {
            if (!field.Column.Equals(_fromColumn))
                return field; // No redirect necessary
    
            return _gqi.CreateSortField(_toColumn, field.Direction);
        });

        // Construct and return a new sort operator based on the redirected sort fields
        return _gqi.CreateSortOperator(redirectedFields.ToArray());
    }
}
```

> [!TIP]
> See also the following API references:
>
> - [IGQISortOperator.Fields](xref:GQI_IGQISortOperator#properties)
> - [IGQISortField.Column](xref:GQI_IGQISortField#properties)
> - [IGQIColumn.Equals](xref:GQI_IGQIColumn#bool-equalsigqicolumn)
> - [IGQIFactory.CreateSortField](xref:GQI_IGQIFactory#igqisortfield-createsortfieldigqicolumn-gqisortdirection--gqisortdirectionascending)
> - [IGQIFactory.CreateSortOperator](xref:GQI_IGQIFactory#igqisortoperator-createsortoperatorparams-igqisortfield)

## Step 7: Build a query using the new custom operator

Now that the implement is finished, we can test and use our sort redirector in a query:

1. Add the data source containing the IP addresses. This can be any CSV source, parameter table, etc.
1. Append the *Rank IP address* custom operator that creates the rank column if that column does not exist yet.
1. Append the *Redirect sort* custom operator:

    1. For the *Redirect from column* argument, select the IP address column.
    1. For the *Redirect to column* argument, select the IP address rank column.

1. Append a sort operator that sorts the query on the IP address column.

   > [!NOTE]
   > This sort operator does not have to be added statically. It can also be added when a user sorts by e.g. clicking the table column header in a table visualization.
