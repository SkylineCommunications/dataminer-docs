---
uid: GQI_Join
---

# Join

The *Join* query operator combines the result of two queries by stitching their rows together.

When you select this operator, configure the following:

1. In the *Type* dropdown box, select [how the data should be joined](#join-types).
1. Build the query to join on.
    1. Select a data source.
    1. Optionally, select operators to apply on the data source.
1. Define one or more [join conditions](#join-conditions) by selecting columns from the *left query* and *right query* to match.
1. Optionally for advanced use cases, [select a join strategy](#selecting-a-join-strategy).

> [!NOTE]
> The joined queries are referred to as the *left query* and *right query*.
>
> - The *left query* is the query where you add the *Join* operator.
> - The *right query* is the query that is built/selected within the *Join* operator.

> [!TIP]
> To keep your queries maintainable and reusable, it is often good practice to define the *right query* as a separate query and to select the [Start from](xref:Start_from) data source to use it in the join operator.

> [!NOTE]
> Technically, the order of the rows is **undefined** after applying a *Join* operator. Therefore, you should not rely on the position the rows were in before joining and instead add a [sort operator](xref:GQI_Sort) afterwards when required. If possible, the *Join* operator will automatically optimize these sort operators.

## Join types

There are four ways to join two queries. They differ only in what happens to a query row when no match is found.

| Join type | Behavior |
| --------- | -------- |
| Inner | Only include matching rows. |
| Outer | Include all rows from both queries, even when there is no match. |
| Left | Include all rows from the *left query*, but only include matching rows from the *right query*. |
| Right | Include all rows from the *right query*, but only include matching rows from the *left query*. |

When a row without a match is included in the result, the corresponding cells from the other query will be empty.

## Join conditions

The join conditions determine when a row from the *left query* matches a row from the *right query*. You have to define at least one join condition. If you define multiple join conditions, the query rows will only match when **all** join conditions match.

To define a join condition, you select a column from the *left query* and a column from the *right query*. The join condition will match query rows when the cell values in those two columns are equal.

> [!NOTE]
> Depending on the [join strategy](#join-strategies), the join condition will either compare the raw cell values or the display values.

## Join strategies

### Selecting a join strategy

In most cases, you do not need to consider the join strategy. The default choice made by the GQI framework is usually sufficient. However, in certain specific scenarios, using a different strategy can improve query performance.

You can change the default join strategy of a join operator in the query builder by following these steps:

1. Add `showAdvancedSettings=true` as a query parameter in the URL while editing a dashboard or low-code app.
1. Reload the page.
1. Open the query builder.
1. Add or edit a join operator.
1. Below the join conditions, you will get the following options:
    - *Join row by row*: check this option to use the [row by row strategy](#row-by-row-strategy) if possible. Available from DataMiner 10.3.3/10.4.0 onwards. <!-- RN 35565 -->
    - *Join by fetching all data*: check this option to use the [prefetch strategy](#prefetch-strategy). Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards. <!-- RN 44275 -->

In the sections below, you can find out more about the available join strategies.

### Partition strategy

This strategy is available from DataMiner 10.5.0 [CU11]/10.6.2 onwards. <!-- RN 44275 -->

It is the default strategy when the following conditions are met:

- Real-time updates are not enabled.
- There is only a single join condition.
- The column types used in the join condition are the same.
- The join type is either:
  - *Inner* and there is no sorting defined on the left or right query.
  - *Left* and there is no sorting defined on the right query.
  - *Right* and there is no sorting defined on the left query.
- The *target query* [supports partitioning](#partitioning-support).

It works by designating one query as the *source query* and the other as the *target query*. The strategy then fetches rows page-by-page from the *source query* as long as more query results are needed. Based on the values in the *source query* rows, partition filters are constructed to apply on the *target query*. The goal is to fetch results from the *target query* in distinct partitions.

> [!TIP]
> This strategy works best when the join operation is highly selective, i.e. the rows from the *source query* match relatively few rows from the total *target query*. If this is not the case, consider using the [prefetch strategy](#prefetch-strategy) instead.

#### Partitioning support

A query supports partitioning when **all** data sources and operators in that query support partitioning.

The overview below shows which data sources currently support partitioning.

| Data source | Support |
| ----------- | ------- |
| [Get object manager instances](xref:Get_object_manager_instances) | Limited by filter complexity. |
| All other data sources | No support |

The overview below shows which operators currently support partitioning.

| Operator | Support |
| -------- | ------- |
| [Filter](xref:GQI_Filter) | Always |
| [Select](xref:GQI_Select) | Always |
| [Column manipulations](xref:GQI_Column_manipulations) | Only when the resulting column is not used in the join condition |
| [Aggregate](xref:GQI_Aggregate) | Only when grouping on the column used in the join condition |
| All other operators | No support |

### Prefetch strategy

This is the default strategy when the [partition strategy](#partition-strategy) is not available or cannot be used. It is applicable in all scenarios.

It works by fetching **all** rows from the *target query* into memory immediately. The join operation then proceeds by fetching the rows of the *source query* as needed and looks up matching rows from memory.

> [!WARNING]
> Join conditions for the prefetch strategy are evaluated on the **display value** of the cells.

> [!TIP]
> This strategy works best when the join operation has low selectivity, i.e. when almost all rows from the joined queries are present in the result. If this is not the case, consider using the [partition strategy](#partition-strategy) instead.

### Row by row strategy

This strategy is available from DataMiner 10.3.3/10.4.0 onwards. <!-- RN 35057 --> It can only be used together with the *Inner* and *Left* [join types](#join-types).

It works by fetching rows from the *source query* one by one. For every row, a filter is constructed to apply on the *target query*. The goal is to execute the *target query* once for every row in the *source query*.

> [!WARNING]
> Since every row from the *source query* triggers a new query execution, the workload can quickly explode. Therefore, only use this strategy in one of the following scenarios:
>
> - The number of rows requested from the joined query is limited.
> - Executing the *target query* with a filter has no meaningful impact on the system.

> [!TIP]
> This strategy works best when the join operation is a one-to-many relation and when there is no overlap in matching rows.
