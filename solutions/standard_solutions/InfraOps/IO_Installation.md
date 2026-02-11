---
uid: IO_Installation
---

# Installing InfraOps

To install dataminer.InfraOps:

1. Confirm whether the following prerequisites are met:

   - Your system uses DataMiner 10.5.9/10.6.0 or higher.
   - The [GQI DxM](xref:GQI_DxM) is installed.
   - [MediaOps](xref:MediaOps) 1.1.3-CU0 or higher is installed.
   - [Web File Manager](https://catalog.dataminer.services/details/330649ca-c685-4e1c-a9a5-aeca6ca8b40f) is installed.

1. Look up the [InfraOps package](https://catalog.dataminer.services/details/5a1edac2-45aa-4498-8ab7-ee322d07da27) in the DataMiner Catalog.

1. If all prerequisites are met, click the *Deploy* button.

   > [!TIP]
   > For more details on deploying items from the Catalog, see [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).

During the installation, the following steps will automatically be executed:

1. Prerequisites are checked.
1. automation scripts are installed/updated.
1. Applications are installed/updated.
1. DOM definitions are installed/updated.
1. In case of a fresh install, the system is initialized.
1. Any required migration actions are executed.
1. Any required cleanup actions are executed.
