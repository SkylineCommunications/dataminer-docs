---
uid: Assistant_native_data_tools
description: "Discover the built-in native data tools available in the DataMiner Assistant app, covering a fixed set of out-of-the-box GQI data sources."
---

# Native data tools

Several native data tools are available in the Assistant app out of the box, without any additional configuration:

- *alarms*
- *bookings*: Requires the appropriate license; only visible when the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option is enabled.
- *change-points*
- *dataminer-documentation*
- *dcf-connections*
- *dcf-interface-properties*
- *dcf-interfaces*
- *elements*
- *parameter-relations*: Requires the [ModelHost DxM](xref:DataMinerExtensionModules#modelhost).
- *parameters*: Includes standalone and table parameters, and parameter trend data.
- *pattern-occurrence*
- *process-automation-processes*: Only visible when the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option is enabled.
- *process-automation-tokens*: Only visible when the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option is enabled.
- *relational-anomalies*
- *resource-pools*: Requires the appropriate license; only visible when the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option is enabled.
- *services*
- *trend-data-pattern*
- *views*

Native data tools cover a fixed set of GQI data sources. To query DOM instances of a specific DOM definition, a specific ad hoc GQI data source, or a fully customized ad hoc data source, define a custom data tool instead. See [Custom data tools](xref:Assistant_custom_data_tools).
