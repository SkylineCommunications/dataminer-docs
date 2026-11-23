---
uid: Letting_DataMiner_Assistant_create_a_query
keywords: DataMiner Assistant, NL2GQI, AI query creation, natural language, generate query, GQI query
description: Use DataMiner Assistant to generate a GQI query from a natural-language request and automatically create a query definition.
---

# Letting DataMiner Assistant create a GQI query

From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42234-->, you can use the DataMiner Assistant [natural language to GQI feature](xref:Intelligence_NL2GQI) to automatically create a GQI query based on a request in natural language.

To use this feature, your DataMiner System must run DataMiner 10.7.0 or later, the system-wide *DataMiner Intelligence* setting must be enabled, and your user profile must have the *General > DataMiner Intelligence > Access* permission. For more information, see [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started) and [DataMiner user permissions](xref:DataMiner_user_permissions).

To do so, in a system where DataMiner Assistant has been deployed, when you click the "+" button to add a query, type your request in the textbox and click **Generate query**. DataMiner Assistant will then create the desired GQI query and generate a relevant query name.

![Natural language to GQI query generation in a DataMiner dashboard](~/dataminer/images/NL2GQI.png)<br>*Natural language to GQI feature in DataMiner Web 10.6.1.*

> [!TIP]
> For more information about how to deploy this feature, see [DataMiner Assistant DxM](xref:Intelligence_Assistant_DxM).

> [!IMPORTANT]
> DataMiner Assistant can make mistakes. We recommend manually checking the resulting queries and correcting or extending them to your liking when necessary. However, keep in mind that typing a new request and clicking the button a second time will override the query, causing all manual changes to be lost.
