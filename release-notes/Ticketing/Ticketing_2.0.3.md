---
uid: Ticketing_2.0.3
---

# Ticketing 2.0.3

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.9/10.6.0 or higher
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x or higher

> [!IMPORTANT]
> The user installing Ticketing should have permission to:
>
> - Add Elements under the Root View (Permissions:Rights General => Elements => Add / Permissions:Views => Root View enabled)
> - Edit hyperlinks (Permissions:Rights General => Alarms => Allow to add or update hyperlinks)
> - Add and Edit Alarm Properties (Permissions:Rights General => Alarms => Properties => Add/Edit)
>
> Any user using Ticketing should have Write access on the Ticketing Lock Manager element under the Root View (via Groups => Permissions => Views).


> [!TIP]
> Installing the following apps alongside the Ticketing Solution will provide access to additional functionality:
>
> - [MediaOps.Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) 1.4.x or higher: Required to be able to assign people to tickets.
> - [InfraOps](https://catalog.dataminer.services/details/5a1edac2-45aa-4498-8ab7-ee322d07da27): Required to be able to link assets to tickets.

## Fixes

#### Ticket type enum field display issue [ID 45143]

Previously, UI handling for adding ticket type fields was refactored to make the code cleaner and easier to maintain. However, this change introduced an issue when an enum field was followed by another field. The UI did not properly clean up previous fields before adding enum options, which caused display issues.

This issue has now been resolved, restoring the correct behavior while keeping the improved code structure.
