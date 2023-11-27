---
uid: CO_Metadata
---

# Modifying links to DataMiner objects

In a custom operator, you can modify the metadata that links DataMiner objects to a row. This metadata allows you to feed the objects in Dashboards and Low-Code Apps to other components.

To add, remove, or modify a DataMiner object link, use the [Metadata property](xref:GQI_GQIRow#properties) of the editable row.

## Example

The following custom operator links GQI rows to DataMiner views based on a column that contains the view ID.

:::code language="csharp" source="./SLC-GQIO-LinkToView.cs":::

> [!CAUTION]
> Although it is technically possible to modify the existing metadata instances, this can in some cases lead to undefined behavior and is therefore strongly discouraged.
>
> If you need to modify existing links, you should **create new instances and treat the existing instance as immutable**.

## See also

- [Supported references to DataMiner objects](xref:GQI_ObjectRefMetadata#dmaobjectref)
- [ObjectRefMetadata](xref:GQI_ObjectRefMetadata)
- [GenIfRowMetadata](xref:GQI_GenIfRowMetadata)
- [GQIEditableRow](xref:GQI_GQIEditableRow)
