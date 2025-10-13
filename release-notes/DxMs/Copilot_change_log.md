---
uid: Copilot_change_log
---

# Copilot change log

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
