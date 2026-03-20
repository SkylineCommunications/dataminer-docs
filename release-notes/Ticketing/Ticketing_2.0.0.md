---
uid: Ticketing_2.0.0
---

# Ticketing 2.0.0

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.9/10.6.0 or higher
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x or higher

> [!TIP]
> Installing the following apps alongside the Ticketing Solution will provide access to additional functionality:
>
> - [MediaOps.Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) 1.4.x or higher: Required to be able to assign people to tickets.
> - [InfraOps](https://catalog.dataminer.services/details/5a1edac2-45aa-4498-8ab7-ee322d07da27): Required to be able to link assets to tickets.

## New features

#### MediaOps.Plan People & Organizations integration [ID 44965]

The Ticketing Solution has been integrated with the MediaOps.Plan People & Organizations module, enabling the following new features:

- Ability to assign tickets to contacts defined in the People & Organizations module.

- Additional predefined view, *My Tickets*, to only view tickets assigned to the current user, based on the user's email address that is matched with their record in the People & Organizations module.

#### InfraOps Asset Manager integration [ID 44978]

The Ticketing Solution has been integrated with the InfraOps Asset Manager module, enabling the following new features:

- Ability to link tickets to DataMiner objects (elements, services, alarms) and assets from Asset Manager using SDM Object Linking.

- Exposed URL supporting asset filtering so opening the Ticketing app will only display the tickets for the provided asset.

#### Support for ticket creation using correlation rules [ID 44986]

The Ticketing Solution now supports creating tickets using correlation rules.

## Enhancements

#### Various UI improvements + Dev Pack compatibility [ID 44986]

Various UI improvements have been implemented in the Ticketing app and the interactive automation scripts used in the Ticketing Solution.

In addition, the solution has been updated to use and be compatible with DataMiner Dev Packs.
