---
uid: Query_operators
---

# Query operators

When you create a query, you can use the operators listed below. Selecting an operator is optional. If you do not select an operator, the dataset will be returned untouched.

Available operators:

- [Aggregate](xref:GQI_Aggregate)

- [Column manipulations](xref:GQI_Column_manipulations)

- [Custom operator](xref:GQI_Custom_Operator_About)

- [Filter](xref:GQI_Filter)

- [Join](xref:GQI_Join)

- [Select](xref:GQI_Select)

- [(Then) Sort (by)](xref:GQI_Sort)

- [Top X](xref:GQI_Top_X)

From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42127-->, you can rearrange the operators that have been added in a query by dragging and dropping them to a different position on the same level. If an operator turns red after being moved, this indicates that it cannot be used at that location and the query has become invalid.

> [!NOTE]
>
> - Some operators can make use of data. From DataMiner 10.3.5/10.4.0 onwards<!--  RN 35837 -->, a link icon is displayed to the right of a selection box if using data is possible. Click this icon to select the data. In earlier DataMiner versions, a *Use feed* checkbox is available for this instead.
> - The *Then sort by* operator is a child node of the *Sort by* operator, so if you move a *Sort by* node, all its *Then sort by* child nodes will move with it<!--RN 42229-->.
