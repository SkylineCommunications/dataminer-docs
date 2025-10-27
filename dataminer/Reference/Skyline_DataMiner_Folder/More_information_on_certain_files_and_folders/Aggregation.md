---
uid: Aggregation
---

# Aggregation

This folder contains all aggregation rules configured on the DMA. These can be contained in subfolders, corresponding to the aggregation folder configuration in Cube. The *Aggregation* folder is synced on all Agents in the DMS.

For each aggregation rule, there is an XML file detailing its configuration. Normally, you will never need to adjust this configuration directly in the XML file, as practically all aggregation configuration is possible in Cube. However, one exception to this is the configuration of whether a specific aggregation rule will take parameter exception values in account.

## Specifying whether an aggregation rule ignores parameter exception values

On system level, this setting is configured in the *Aggregation.Source* tag of the *MaintenanceSettings.xml* file, but if you configure this setting for a specific aggregation rule, this will override the system-level setting. See [MaintenanceSettings XML Schema](xref:SchemaMaintenanceSettings).

To configure this setting for a specific aggregation rule, open the corresponding XML file, add the *ignoreExceptionValues* attribute to the *\<Rule>* tag, and set it to *"true"* or *"false"*, depending on whether you want exception values to be ignored or not, respectively.

Example:

```xml
<Rule type="avg" timer="0.0833333333333333" ignoreExceptionValues="true">
```

> [!NOTE]
> Before you make any changes to an aggregation XML file or to the *MaintenanceSettings.xml* file, stop the DMA. After you have saved your changes, restart the DMA.
