---
uid: Ticketing_2.0.4
---

# Ticketing 2.0.4 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

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

#### Text improvements in General Info and Additional Info editing form [ID 45247]

The following text has been adjusted in the General Info and Additional Info editing form:

- "Edit Ticket" has been changed to "Edit Ticket Fields".
- "Edit Fields" has been changed to "Edit Ticket Type Fields".
- The message "This ticket currently has no ticket type fields that can be edited." has been changed to "No fields defined for the selected Ticket Type."

#### Contacts sorted alphabetically [ID 45248]

In the dropdown that can be used to assign a contact to a ticket, the contacts from the People and Organizations app are now sorted alphabetically. The "No Assignee" option will continue to be shown at the top when applicable (i.e., for a ticket that has not yet been set to "In Progress", because making such a ticket unassigned again is not possible).

#### Improved messages on Ticket Information page [ID 45257]

In several places on the Ticket Information page, the "Nothing to show" messages have been removed or replaced with more meaningful messages:

- In case a ticket is closed, canceled, or rejected, it can no longer be transitioned to another state, and no transition buttons are displayed. The previously displayed message "Nothing to show" is no longer shown.
- In the Additional Info section, "Nothing to show" has been replaced with "No fields defined for the selected Ticket Type".
- In the Linked Items section, "Nothing to show" has been replaced with "Ticket has no Linked Items".
- In the External Ticketing section, "Nothing to show" has been replaced with "Ticket has no External Ticketing".

## Fixes

#### Large description cannot be fully viewed in expanded view [ID 45245]

If a ticket had a very large description (e.g., over 60 lines), the expanded view of the ticket did not show the complete description even though this should actually be the case. This issue has been resolved, so that you can now scroll down to see the complete description.

#### Additional info fields could be edited for rejected, canceled, and closed tickets [ID 45246]

If a ticket was rejected, canceled, or closed, it was possible to edit the Additional Info fields on the information page, even though this should not be the case.

#### Enum default value for ticket type kept reverting to first defined Enum field [ID 45249]

When a ticket type field of data type Enum was defined, the configured default value kept incorrectly reverting to the Enum field that has been defined first.
