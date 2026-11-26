---
uid: Intelligence_NL2GQI
description: "Use the natural language to GQI capability in DataMiner Intelligence to generate GQI queries from plain-language requests in dashboards and low-code apps."
---

# Natural language to GQI

Natural language to GQI is a [DataMiner Intelligence](xref:DataMiner_Intelligence) capability that uses a large language model (LLM) to turn plain-language requests into ready-to-execute GQI queries. The [DataMiner Assistant module](xref:DataMinerCoreModules#assistant) powers this capability.

You can use this feature when [configuring queries in dashboards or low-code apps](xref:Generating_a_GQI_query_with_natural_language).

![Natural language to GQI query generation in a DataMiner dashboard](~/dataminer/images/NL2GQI.png)<br>*Natural language to GQI feature in DataMiner Web 10.6.2*

Examples of natural-language requests include:

- "Show me all the critical alarms from last week"
- "Sort elements by their name"

The result will be a GQI query that you can use to fetch the requested data.

## Requirements

- Your DataMiner System must run DataMiner 10.7.0/10.7.1 or later.
- The system-wide *DataMiner Intelligence* web apps setting must be enabled.
- You must have the [General > DataMiner Intelligence > Access](xref:DataMiner_user_permissions#general--dataminer-intelligence--access) user permission.
- The feature must be [enabled in the app settings](#enabling-this-feature).

> [!TIP]
> For more information, see [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started).

## Supported GQI operators

Natural language to GQI supports the following operators:

- [Aggregate](xref:GQI_Aggregate)
- [Filter](xref:GQI_Filter)
- [Join](xref:GQI_Join)
- [Select](xref:GQI_Select)
- [Sort by](xref:GQI_Sort)
- [Top X](xref:GQI_Top_X)

> [!NOTE]
> This feature does not currently support [column manipulations](xref:GQI_Column_manipulations) or [custom operators](xref:GQI_Custom_Operator).

## Supported GQI data sources

Natural language to GQI automatically detects [GQI data sources](xref:Query_data_sources) available in your DataMiner System, including [ad hoc data sources](xref:Get_ad_hoc_data) and [object manager instances](xref:Get_object_manager_instances). However, data sources requiring the selection of a parameter are not supported. For example, it is not possible to use data sources like [Get parameter table by ID](xref:Get_parameter_table_by_ID), which requires the selection of an element ID.

> [!NOTE]
> For performance reasons, the feature caches information about GQI data sources. This cache is refreshed once a day at a random time. Therefore, newly added data sources might be unavailable for a short time after creation.

> [!IMPORTANT]
> The model receives DataMiner context but cannot see the data contained in the data sources. If it selects an unsuitable operator, try rephrasing your request with more specific instructions.

## Enabling this feature

To enable this feature, create the file `C:\Program Files\Skyline Communications\DataMiner Assistant\appsettings.custom.json` with the following content:

```json
{   
  "NL2GQIOptions": {
    "ShowUserInterface": true
  }
}    
```

This file needs to be created on every Agent in the DataMiner System where the DxM is installed.

> [!NOTE]
> Prior to DataMiner 10.7.0/10.7.1, it is possible to enable this feature in preview. This is possible starting from DataMiner 10.5.0 [CU11]/10.6.2<!-- RN 44342 -->
