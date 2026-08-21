---
uid: Generic_Penalty_Box_Installation
---

# Installing the Generic Penalty Box

## Deploying the Generic Penalty Box

1. Deploy the Generic Penalty Box solution from the catalog.

   Once deployed, the *generic-penalty-box* folder will be available in *C:\Skyline DataMiner\Webpages\Public* on the DataMiner Agent.

1. Edit *generic-penalty-box/config.json* to match your environment (protocol name, parameter IDs, etc.). See [Configuring the Generic Penalty Box](xref:Generic_Penalty_Box_Configuration).

1. Browse to `http://[DMA name]/public/generic-penalty-box/` in a web browser.

> [!NOTE]
> *config.json* is loaded fresh on every page load, so any edits you make take effect immediately on the next browser refresh. No rebuild is required.

### Creating additional penalty boxes

To display multiple, differently configured penalty box walls (for example, one per protocol or site) on the same DataMiner Agent, you can copy the deployed *generic-penalty-box* folder in *C:\Skyline DataMiner\Webpages\Public* and rename the copy, for example to *generic-penalty-box-eaton-ups*. Each copy can then be configured independently by editing its own [*config.json*](xref:Generic_Penalty_Box_Configuration), and is accessed via its own folder name, for example `http://[DMA name]/public/generic-penalty-box-eaton-ups/`.
