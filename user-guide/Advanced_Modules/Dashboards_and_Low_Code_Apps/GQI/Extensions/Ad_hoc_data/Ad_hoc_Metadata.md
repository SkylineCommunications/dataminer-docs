---
uid: Ad_hoc_Metadata
---

# Linking rows to DataMiner objects

Just like the rows from built-in data sources can contain metadata that allow you to feed certain DataMiner objects in your Dashboards and Low-Code Apps, so too can you link the rows of your ad hoc data source to these DataMiner objects.

To link a GQI row to a DataMiner object, add a reference to the object in the [Metadata property](xref:GQI_GQIRow#properties) of the row.

## Example

The following ad hoc data source exposes a table of elements contained within a specific view.

:::code language="csharp" source="./SLC-GQIDS-ViewElements.cs":::

## See also

- [Supported references to DataMiner objects](xref:GQI_ObjectRefMetadata#dmaobjectref)
- [ObjectRefMetadata](xref:GQI_ObjectRefMetadata)
- [GenIfRowMetadata](xref:GQI_GenIfRowMetadata)
- [GQIRow](xref:GQI_GQIRow)
