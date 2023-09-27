---
uid: SLNetClientTest_activating_verbose_correlation_logging
---

# Activating verbose Correlation logging

To activate verbose Correlation logging:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *CorrelationLogVerbose*.

   A list of the Agents in the cluster will be displayed, indicating for each of them whether verbose Correlation is activated.

1. In the *Value* column, right-click the “false” value for the Agent for which you wish to activate verbose Correlation logging, and select *Edit value*.

1. Enter “true” and click *OK*.

> [!NOTE]
> This option is saved into the file *MaintenanceSettings.xml* under the *\<SLNet>* tag. It is not synchronized across Agents in the DMS.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
