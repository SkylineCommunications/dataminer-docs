---
uid: Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field-columnPid
description: "Use the Field columnPid attribute in a DataMiner protocol to identify a table column used as a search field, including linked tables."
---

# columnPid attribute

Specifies the column parameter ID of a column of the table referred to by the tablePid attribute of the enclosing Tab, or a column of a table that is linked with this table.

## Content Type

unsignedInt

## Parent

[Field](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field)

## Remarks

If a filter in an EPM search chain refers to a column parameter of type discreet, the filter will be displayed as a dropdown box instead of a text box. If the filter is used for multiple tables, it will be displayed as a dropdown box as soon as one of the columns represents a discreet parameter. When multiple columns have different discreet values, all these values will be displayed as long as they have a unique value and display string.<!-- RN 25862 -->

> [!NOTE]
> Dynamic discreet parameters are currently not supported.
