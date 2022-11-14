---
uid: SLNetClientTest_including_all_custom_properties
---

# Configuring server-side search to include all custom properties

From DataMiner 10.2.12/10.3.0 onwards, in the *MaintenanceSettings.xml* file, you can configure the DataMiner Cube server-side search engine by specifying one or more search options in the *SLNet.SearchOptions* element.

1. Stop DataMiner

1. Open the file *C:\Skyline Dataminer\MaintenanceSettings.xml*.

1. In the SLNet.SearchOptions tag, specify the following option:

   | **Option** | **Description** |
   |--|--|
   | includeAllCustomProperties | Server-side search engine will search the values of all custom properties. |

This is an excerpt from *MaintenanceSettings.xml* where indexing has been set to “includeAllCustomProperties”:

   ```xml
   <SLNet>
     <SearchOptions>includeAllCustomProperties</SearchOptions>
   </SLNet>
   ```

   > [!NOTE]
   > For more information on the available search options, see [Setting the indexing options for the server-side search](xref:Setting_the_indexing_options_for_the_server-side_search).

1. Save the file and restart DataMiner.

> [!NOTE]
>
> - This option is saved into the file MaintenanceSettings.xml under the <SLNet> tag. It is not synchronized across Agents in the DMS.
> - DataMiner Cube will call the server-side search engine when you enter a numeric search string like "1234".

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
