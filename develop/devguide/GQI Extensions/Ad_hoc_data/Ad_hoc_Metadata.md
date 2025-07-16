---
uid: Ad_hoc_Metadata
---

# Linking rows to DataMiner objects

GQI allows query rows to be linked to certain DataMiner objects. This is achieved via metadata that informs the Dashboards and Low-Code Apps of what a row represents. The metadata can then be used to pass these DataMiner objects from one component to another.

From DataMiner 10.4.0/10.4.1 onwards, you can also add this metadata to the rows of your ad hoc data source, just like the rows from built-in data sources.

To link a GQI row to a DataMiner object, add a reference to the object in the [Metadata property](xref:GQI_GQIRow#properties) of the row.

## Example

The following ad hoc data source exposes a table of elements contained within a specific view.

### [From DataMiner 10.4.6/10.5.0 onwards](#tab/tabid-2)

:::code language="csharp" source="./SLC-GQIDS-ViewElements_10.4.6.cs":::

### [In earlier DataMiner versions](#tab/tabid-1)

:::code language="csharp" source="./SLC-GQIDS-ViewElements_10.4.0.cs":::

***

## See also

- [Supported references to DataMiner objects](xref:GQI_ObjectRefMetadata#dmaobjectref)
- [ObjectRefMetadata](xref:GQI_ObjectRefMetadata)
- [GenIfRowMetadata](xref:GQI_GenIfRowMetadata)
- [GQIRow](xref:GQI_GQIRow)
