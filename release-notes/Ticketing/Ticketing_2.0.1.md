---
uid: Ticketing_2.0.1
---

# Ticketing 2.0.1

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

## Enhancements

#### Various UI improvements [ID 44993]

Various UI improvements have been implemented in the Ticketing app and the interactive automation scripts used in the Ticketing Solution.

#### Improved Ticketing Lock Manager exception handling [ID 44994]

The exception handling of the Ticketing Lock Manager has been improved. Instead of the full stack trace, a user-friendly message will now be displayed.

## Fixes

#### Problem installing Ticketing Demo package [ID 44995]

In some cases, it could occur that the Ticketing Demo package could not be installed.

To prevent this issue, the Ticketing Lock Manager configuration has been adjusted. The Ticketing Lock Manager is now hidden by default, and the InterApp timeout is set to 30 seconds by default.
