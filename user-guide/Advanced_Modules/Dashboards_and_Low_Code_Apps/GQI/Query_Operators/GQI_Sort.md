---
uid: GQI_Sort
---

# (Then) Sort (by)

To sort data based on a specific column, three query operators are available, depending on your DataMiner version and objective:

- ***Sort by***:

  - Available from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35807 & 35834 -->.

  - When you select this operator, you will need to select the column to sort by. By default, sorting happens in descending order. To sort in ascending order instead, select the *Ascending* checkbox.

- ***Then sort by***:

  - Available from DataMiner 10.3.5/10.4.0 onwards. <!--  RN 35807 & 35834 -->

  - This operator allows you to sort data based on a specific column, after it has already been sorted based on another column. See [Sorting by multiple columns](#sorting-by-multiple-columns).

  - When you select this operator, you will need to select the column to sort by. By default, sorting happens in descending order. To sort in ascending order instead, select the *Ascending* checkbox.

- ***Sort***:

  - Available from DataMiner 10.2.11 to 10.3.4 (Feature Release) and in DataMiner 10.3.0 (Main Release).

    > [!IMPORTANT]
    > From DataMiner 10.3.5/10.4.0 onwards, this operator is replaced by the *Sort by* and *Then sort by* operators.

  - When you select this operator, you will need to select the column to sort by. By default, sorting happens in descending order. To sort in ascending order instead, select the *Ascending* checkbox.

## Sorting by multiple columns

DataMiner 10.3.5/10.4.0 introduces the *Sort by* and *Then sort by* operators to allow more intuitive sorting. To sort by multiple columns, add the *Sort by* operator first and then the *Then sort by* operator.

> [!CAUTION]
> Reusing the *Sort by* operator will nullify the result of the previous sorting operation.

Prior to DataMiner 10.3.5/10.4.0, if you want to sort by multiple columns, the order in which you need to add the *Sort* operators may seem counter-intuitive. For example, if you want to first sort by column A and then by column B, you have to create your query as follows:

1. Data source
1. Sort by B
1. Sort by A

or

1. Query X (i.e. Data Source, sorted by B)
1. Sort by A

> [!NOTE]
> When you upgrade to DataMiner version 10.3.5/10.3.4 or higher, the behavior of existing queries (using e.g. *Sort by B* followed by *Sort by A*) will not be altered. Their syntax will automatically be adapted when they are migrated to the most recent GQI version.

## Sorting on a joined column

From DataMiner 10.4.2/10.5.0 onwards<!--RN 38150-->, when you add a sort operator (*Sort by* or *Then sort by*) after adding a [*Join*](xref:GQI_Join) operator, the sort operator is automatically forwarded to the correct query in the *Join* operator. When you sort on a joined column, the sort operator is forwarded in the following situations:

- In case of an *Inner* type of join

- In case of a *Left* type of join, but only if all sorts are descending

- In case of a *Right* type of join
