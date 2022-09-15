---
uid: SLNetClientTest_making_Cube_ignore_view_updates
---

# Making DataMiner Cube ignore view updates

With the SLNetClientTest tool, you can make DataMiner Cube clients stop handling view changes. Instead, as soon as a view change has been ignored, a *Reconnect* button will appear at the top of the Surveyor. You can click this button to reconnect and manually reload any view changes.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *ClientSkipViewUpdates*.

   A list of the Agents in the cluster will be displayed, indicating for each of them whether client view updates are ignored.

1. In the *Value* column, right-click the "false" value for the Agent for which you want client view updates to be ignored, and select *Edit value*.

1. Enter "true" and click *OK*.

> [!NOTE]
> You can also configure this setting directly in the file *MaintenanceSettings.xml*. See [Making DataMiner Cube ignore view updates](xref:Configuration_of_DataMiner_processes#making-dataminer-cube-ignore-view-updates).

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
