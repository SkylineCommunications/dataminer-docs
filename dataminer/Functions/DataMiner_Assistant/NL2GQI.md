---
uid: NL2GQI
---

# Natural language to GQI

Starting from version 1.0.0, the [DataMiner Assistant](xref:Assistant_DxM) DxM will translate requests in human language into ready-to-execute GQI queries making use of an underlying Large Language Model (LLM).

You can use this feature when [configuring queries in dashboards or low-code apps](xref:Creating_GQI_query#letting-dataminer-assistant-create-a-query).

![NL2GQI](~/dataminer/images/NL2GQI.png)<br>*Natural language to GQI feature in DataMiner 10.6.1*

Examples of such natural languages request could be:

- "Show me all the critical alarms from last week"
- "Sort elements by their name"

The result will be a GQI query that you can use to fetch the requested data.

> [!NOTE]
> Prior to version 2.0.0, the DataMiner Assistant DxM is called "Copilot" instead.

## Supported GQI operators

The following GQI operators are supported by DataMiner Assistant:

- [Aggregate](xref:GQI_Aggregate)
- [Filter](xref:GQI_Filter)
- [Join](xref:GQI_Join)
- [Select](xref:GQI_Select)
- [Sort by](xref:GQI_Sort)
- [Top X](xref:GQI_Top_X)

> [!NOTE]
> At present, DataMiner Assistant does not provide any support for [column manipulations](xref:GQI_Column_manipulations) and [custom operators](xref:GQI_Custom_Operator).

## Supported GQI data sources

DataMiner Assistant is able to automatically detect all [GQI data sources](xref:Query_data_sources) available in the system, including [ad hoc data sources](xref:Get_ad_hoc_data) and [object manager instances](xref:Get_object_manager_instances). However, data sources requiring the selection of a parameter are not supported. For example, it is not possible to use data sources like [Get parameter table by ID](xref:Get_parameter_table_by_ID), which requires the selection of an element ID.

> [!NOTE]
> For performance reasons, DataMiner Assistant caches all the information about GQI data sources. This cache is refreshed once a day at a random time. Therefore, newly added data sources might be unavailable for a short time after creation.

> [!IMPORTANT]
> While DataMiner Assistant is able to enrich the underlying LLM with fundamental DataMiner context, it is important to keep in mind that the LLM has no information about the data actually contained in the many data sources. For this reason, it might have a hard time picking the perfect operator every time. You can usually overcome this by rephrasing your initial request with more specific instructions.
