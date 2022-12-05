---
uid: Setting_the_indexing_options_for_the_server-side_search
---

# Setting the indexing options for the server-side search

In the file *MaintenanceSettings.xml*, you can prevent certain items from being indexed by the DataMiner Cube server-side search engine.

To do so:

1. Stop DataMiner.

1. Open the file *C:\\Skyline Dataminer\\MaintenanceSettings.xml.*

1. In the SLNet.SearchOptions tag, specify one or more of the following options. To specify multiple options, separate them by semicolons (“;”).

    Available options:

    | Option  | Description    |
    |---------|----------------|
    | disable | Search will not return anything. Indexing will be disabled on the DMA. |
    | excludeParams | Search will not return any parameters. |
    | excludeElements | Search will not return any elements. |
    | excludeServices | Search will not return any services. |
    | excludeServiceTemplates  | Search will not return any service templates. |
    | excludeRedundancy  | Search will not return any redundancy groups. |
    | excludeDocuments | Search will not return any documents. |
    | includeAllCustomProperties | Search will return the values of all custom properties. |
    | redirectTo:*\[DMA ID\]* | Indexing will be disabled on the local DMA, and all search requests will be redirected to the DMA with the specified ID. For example, to redirect to the DMA with ID 123, specify *redirectTo:123*. This option allows you to reduce load on your DMAs by redirecting all search requests to one dedicated “search-handling DMA”. |
    | trendedParamsOnly  | Search will only return trended parameters. |

    For example, in the following excerpt from *MaintenanceSettings.xml*, indexing has been set to “trendedParamsOnly”:

    ```xml
    <SLNet>
      <SearchOptions>trendedParamsOnly</SearchOptions>
    </SLNet>
    ```

1. Save the file and restart DataMiner.

> [!NOTE]
>
> - If the *\<SearchOptions>* tag is empty, then there will be no indexing restrictions. In other words, all items will be indexed.
> - If no *\<SearchOptions>* tag can be found in *MaintenanceSettings.xml*, indexing will be restricted to “trendedParamsOnly” by default.
