---
uid: Intelligence_NL2GQI
description: "Learn how to use the natural language to GQI feature in DataMiner Assistant to generate ready-to-execute GQI queries from human-language requests."
---

# Natural language to GQI

The [DataMiner Assistant](xref:Intelligence_Assistant_DxM) DxM can translate requests in human language into ready-to-execute GQI queries making use of an underlying Large Language Model (LLM).

You can use this feature when [configuring queries in dashboards or low-code apps](xref:Letting_DataMiner_Assistant_create_a_query).

![Natural language to GQI query generation in a DataMiner dashboard](~/dataminer/images/NL2GQI.png)<br>*Natural language to GQI feature in DataMiner Web 10.6.1.*

Examples of such natural languages request could be:

- "Show me all the critical alarms from last week"
- "Sort elements by their name"

The result will be a GQI query that you can use to fetch the requested data.

## Requirements

- Your DataMiner System must run DataMiner 10.7.0/10.7.1 or later.
- The system-wide *DataMiner Intelligence* web apps setting must be enabled.
- You must have the [General > DataMiner Intelligence > Access](xref:DataMiner_user_permissions#general--dataminer-intelligence--access) user permission.

> [!TIP]
> For more information, see [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started)

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

## Enabling this feature in preview

If you are running a DataMiner version prior to DataMiner 10.7.0/10.7.1, you can enable this feature in preview starting from DataMiner 10.5.0 [CU11]/10.6.2<!-- RN 44342 -->. To do so, create the file `C:\Program Files\Skyline Communications\DataMiner Assistant\appsettings.custom.json` with the following content:

```json
{   
  "NL2GQIOptions": {
    "ShowUserInterface": true
  }
}    
```

This file needs to be created on every Agent in the DataMiner System where the DxM is installed.
