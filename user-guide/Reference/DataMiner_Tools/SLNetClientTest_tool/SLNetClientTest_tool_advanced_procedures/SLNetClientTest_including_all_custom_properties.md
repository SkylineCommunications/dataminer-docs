---
uid: SLNetClientTest_including_all_custom_properties
---

# Configuring server-side search to include all custom properties

From DataMiner 10.2.12/10.3.0 onwards, an option is available through which you can configure the DataMiner Cube server-side search engine by specifying one or more search options in the *SLNet.SearchOptions* element.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Options > SLNet Options > SearchOptions*.

1. Add *includeAllCustomProperties*.

   > [!NOTE]
   >
   > - This option is saved into the file *MaintenanceSettings.xml* under the *SLNet* tag. It is not synchronized across Agents in the DMS.
   > - If multiple search options are specified, they should be separated by semicolons (";").

1. In addition, in the *Diagnostics* menu, select *SLNet > Search Index Info*.

1. Click the *Rebuild* button.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
