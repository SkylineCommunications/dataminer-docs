---
uid: DataMinerAssistant_change_log
---

# DataMiner Assistant change log

#### 9 October 2025 - DataMiner Assistant 2.0.0 - DataMiner Copilot has been renamed to DataMiner Assistant [ID 43922]

DataMiner Copilot has now been renamed to DataMiner Assistant.

#### 6 October 2025 - Enhancement - DataMiner Assistant 2.0.0 - Natural language to GQI: All datetime values will now be formatted according to the ISO 8601 standard [ID 43874]

Up to now, in some cases, the Large Language Model would format datetime values incorrectly.

From now on, all datetime values will be formatted according to the ISO 8601 standard.

#### 27 August 2025 - Fix - Copilot 1.4.8 - Natural language to GQI: Columns could get removed from the cache when repeatedly requesting queries against the same data source [ID 43616]

When you repeatedly requested GQI queries with aggregations like e.g. "group by" against the same data source, in some cases, certain columns could incorrectly get removed from the data sources cache.

#### 7 July 2025 - Fix - Copilot 1.4.0 - Automatically generated query name would not be a meaningful term [ID 43255]

When, in the Dashboards app or Low-Code Apps, you used the Natural language to GQI feature to create a query, in some cases, the automatically generated query name would not be a meaningful term.

#### 14 April 2025 - Copilot 1.0.0 - Natural language to GQI [ID 42234] [ID 42507]

The new Copilot DxM extends DataMiner with conversational AI. In this first release, it can translate a request in natural language into a GQI query.

Copilot is currently not included in DataMiner upgrade packages and [needs to be deployed separately](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node). It requires a DataMiner System connected to dataminer.services. To be able to create GQI queries, it also requires that the [GQI DxM](xref:GQI_DxM) is installed.

At present, the feature supports the *Aggregate*, *Filter*, *Join*, *Select*, *Sort by*, and *Top X* GQI operators. It can detect all GQI data sources in the system, including ad hoc data sources and object manager instances. However, data sources requiring the selection of a parameter are not supported (e.g. *Get parameter table by ID*).

In the Dashboards app and Low-Code Apps, from DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards, when you create a query, you will be able to enter your query in natural language in a text box and then click a button to automatically create the corresponding GQI query.

For more detailed information, refer to [Copilot DxM](xref:Assistant_DxM).

> [!IMPORTANT]
> Copilot can make mistakes. We recommend manually checking the resulting queries and correcting or extending them to your liking when necessary. However, keep in mind that typing a new request and clicking the button a second time will override the query, causing all manual changes to be lost.
