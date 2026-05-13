---
uid: Ticketing_2.0.1
---

# Ticketing 2.0.1

## Prerequisites

- **DataMiner 10.5.9/10.6.0** or higher must be installed.

- [**Standard Data Model Registration**](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x or higher must be installed.

- The user installing Ticketing needs the following **user permissions**:

  - [General > Elements > Add](xref:DataMiner_user_permissions#general--elements--add)
  - [General > Alarms > Allow to add or update hyperlinks](xref:DataMiner_user_permissions#general--alarms--allow-to-add-or-update-hyperlinks)
  - [General > Alarms > Properties > Add](xref:DataMiner_user_permissions#general--views--properties--add) and [General > Alarms > Properties > Edit](xref:DataMiner_user_permissions#general--views--properties--edit)

- Any users who will use the Ticketing Solution (including the user installing the solution) will need to have **write access** to the root view and the Ticketing Lock Manager element under the root view (via *Permissions* > *Views*; see [Configuring a user group](xref:Configuring_a_user_group)).

- Installing the following apps alongside the Ticketing Solution will provide access to **additional functionality**:

  - [MediaOps.Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) 1.4.x or higher: Required to be able to assign people to tickets.
  - [InfraOps](https://catalog.dataminer.services/details/5a1edac2-45aa-4498-8ab7-ee322d07da27): Required to be able to link assets to tickets.

## Enhancements

#### Various UI improvements [ID 44993]

Various UI improvements have been implemented in the Ticketing app and the interactive automation scripts used in the Ticketing Solution.

#### Improved Ticketing Lock Manager exception handling [ID 44994]

The exception handling of the Ticketing Lock Manager has been improved. Instead of the full stack trace, a user-friendly message will now be displayed.

## Fixes

#### Problem installing Ticketing Demo package [ID 44995]

In some cases, it could occur that the Ticketing Demo package could not be installed.

To prevent this issue, the Ticketing Lock Manager configuration has been adjusted. The Ticketing Lock Manager is now hidden by default, and the InterApp timeout is set to 30 seconds by default.
