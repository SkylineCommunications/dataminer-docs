---
uid: Generic_Penalty_Box_Installation
description: "Install the Generic Penalty Box app and set up one or multiple real-time alarm walls on your DataMiner Agent with flexible, environment-specific config."
---

# Installing the Generic Penalty Box

## Deploying the Generic Penalty Box

1. Deploy the Generic Penalty Box solution from the Catalog.

1. When the deployment is complete, go to the folder `C:\Skyline DataMiner\Webpages\Public\generic-penalty-box` on the DataMiner Agent.

1. Edit *generic-penalty-box/config.json* to match your environment (protocol name, parameter IDs, etc.).

   > [!TIP]
   > For details, see [Configuring the Generic Penalty Box](xref:Generic_Penalty_Box_Configuration).

1. Browse to `http://[DMA name]/public/generic-penalty-box/` in a web browser.

## Creating additional penalty boxes

It is possible to display multiple penalty box walls on the same DataMiner Agent, each with its own configuration, for example, one per connector or one per site.

To do this, copy the deployed *generic-penalty-box* folder in `C:\Skyline DataMiner\Webpages\Public` and rename the copy, for example to *generic-penalty-box-eaton-ups*.

You can then configure each copy independently by editing its own [*config.json*](xref:Generic_Penalty_Box_Configuration), and you can access the copies using the folder name, for example, `http://[DMA name]/public/generic-penalty-box-eaton-ups/`.
