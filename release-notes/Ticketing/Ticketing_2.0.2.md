---
uid: Ticketing_2.0.2
---

# Ticketing 2.0.2

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

#### Ticket creation from correlation rule now includes affected resources and assets [ID 45110]

When a ticket is created from a correlation rule, the script that takes care of the ticket creation will now include the affected resources and any assets linked to those affected resources.

#### Next transition state shown based on happy path [ID 45117]

The Ticket Information page will now always show the state transition buttons according to the happy path. The first purple button on the left will always show the next expected state of the happy path.

#### Ticket fields removed from the "Generic Issue" default Ticket Type [ID 45120]

The "Generic Issue" default ticket type now no longer contains any additional fields.

#### No longer possible to edit ticket fields for rejected, canceled, or closed tickets [ID 45138]

On the Information page of a ticket, it is now no longer possible to edit any ticket fields for tickets in the *Rejected*, *Cancelled*, or *Closed* state.

#### Various UI improvements [ID 45139]

Various improvements have been implemented to the user interface of both the Ticketing app and the automation scripts used in the Ticketing Solution.

#### Resolved tickets now also included under Open Tickets filter [ID 45140]

When you apply the Open Tickets filter, resolved tickets will now also be displayed.

## Fixes

#### Alarms deleted when affected resources were added/deleted [ID 45132]

When affected resources were added or deleted, it could occur that alarms were deleted.
