---
uid: TicketingInstallation
description: Deploy the Ticketing Solution from the DataMiner Catalog after checking whether the prerequisites are met.
---

# Installing the Ticketing Solution

1. Make sure you have the following DataMiner **user permissions**:

   - [General > Elements > Add](xref:DataMiner_user_permissions#general--elements--add)
   - [General > Alarms > Allow to add or update hyperlinks](xref:DataMiner_user_permissions#general--alarms--allow-to-add-or-update-hyperlinks)
   - [General > Alarms > Properties > Add](xref:DataMiner_user_permissions#general--views--properties--add) and [General > Alarms > Properties > Edit](xref:DataMiner_user_permissions#general--views--properties--edit)

1. Confirm whether the following **prerequisites** are met:

   - **DataMiner 10.5.9/10.6.0** or higher is installed.

   - [**Standard Data Model Registration**](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x or higher is installed.

   - DataMiner users who will use the Ticketing Solution (including the user installing the solution) have **write access** to the root view and the Ticketing Lock Manager element under the root view (via *Permissions* > *Views*; see [Configuring a user group](xref:Configuring_a_user_group)).

   - Optionally, but **highly recommended**, as this will provide access to additional functionality:

     - [MediaOps.Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) 1.4.x or higher: Required to be able to assign people to tickets.
     - [InfraOps](https://catalog.dataminer.services/details/5a1edac2-45aa-4498-8ab7-ee322d07da27): Required to be able to link assets to tickets.

1. Look up the [Ticketing package](https://catalog.dataminer.services/details/c132decf-b918-4ee2-be25-1302f41e7705) in the DataMiner Catalog.

1. If all prerequisites are met, click the *Deploy* button.

   > [!TIP]
   > For more details on deploying items from the Catalog, see [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).
