---
uid: Intelligence_native_data_tools
description: "Explore the native data tools that DataMiner Intelligence agents can use to query a built-in set of GQI data sources."
---

# Native data tools

DataMiner Intelligence includes the following native data tools without any additional configuration. You can browse them in the [DataMiner Assistant app](xref:Intelligence_Assistant_app).

- *alarms*
- *bookings*: Requires the appropriate license; only visible when the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option is enabled.
- *change-points*
- *dataminer-documentation*
- *dcf-connections*
- *dcf-interface-properties*
- *dcf-interfaces*
- *elements*
- *parameter-relations*: Requires the [ModelHost DxM](xref:DataMinerExtensionModules#modelhost).
- *parameters*: Includes standalone and table parameters, parameter trend data, and cross-element comparisons for elements that share a protocol.
- *pattern-occurrence*
- *process-automation-processes*: Only visible when the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option is enabled.
- *process-automation-tokens*: Only visible when the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option is enabled.
- *relational-anomalies*
- *resource-pools*: Requires the appropriate license; only visible when the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option is enabled.
- *services*: Provides detailed service information and service-related insights.
- *trend-data-pattern*
- *views*: Lets you inspect views and nested views, find their elements and services, and identify which views contain a specific element or service.

Native data tools cover a fixed set of GQI data sources. To query DOM instances of a specific DOM definition, a specific ad hoc GQI data source, or a fully customized ad hoc data source, define a custom data tool instead. See [Custom data tools](xref:Intelligence_custom_data_tools).
