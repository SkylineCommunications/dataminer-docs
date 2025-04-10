---
uid: NL2GQI
---

# Natural language to GQI

Starting from version 1.0.0, the [DataMiner Copilot](xref:Copilot_DxM) DxM will translate requests in human language into ready-to-execute GQI queries making use of an underlying Large Language Model (LLM). 

## GQI operators

The following GQI operators are supported by Copilot:

- [Aggregate](xref:GQI_Aggregate)
- [Filter](xref:GQI_Filter)
- [Join](xref:GQI_Join)
- [Select](xref:GQI_Select)
- [Sort by](xref:GQI_Sort)
- [Top X](xref:GQI_Top_X)

> [!NOTE]
> At this point in time, Copilot does not provide any support for [Column manipulations](xref:GQI_Column_manipulations).

## GQI data sources 

Copilot is able to automatically detect all [GQI data sources](xref:Query_data_sources) available on the system, including ad [hoc data sources](xref:Get_ad_hoc_data) and [object manager instances](xref:Get_object_manager_instances). However, data sources requiring the selection of a parameter are not supported. For example, it is  not possible to use data sources like [Get parameter table by ID](xref:Get_parameter_table_by_ID) that requires the selection of an element ID.

> [!NOTE]
> For performance reasons, Copilot caches all the information about GQI data sources. This cache is refreshed once a day at a random time. Therefore, newly added data sources might be unavailable for a short time after creation.

> [!IMPORTANT]
> While Copilot is able to enrich the underlying LLM with fundamental dataminer context, it is important to keep in mind that the LLM has no information about the data actually contained in the many data sources. For this reason, it might have a hard time picking the perfect operator every time. This can usually be overcome by rephrasing the initial request with more specific instructions.