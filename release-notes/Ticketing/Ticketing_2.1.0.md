---
uid: Ticketing_2.1.0
---

# Ticketing 2.1.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## Prerequisites

- **DataMiner 10.5.9/10.6.0** or higher must be installed.

- [**Standard Data Model Registration**](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x or higher must be installed.

- The user installing Ticketing needs the following **user permissions**:

  - [General > Elements > Add](xref:DataMiner_user_permissions#general--elements--add)
  - [General > Alarms > Allow to add or update hyperlinks](xref:DataMiner_user_permissions#general--alarms--allow-to-add-or-update-hyperlinks)
  - [General > Alarms > Properties > Add](xref:DataMiner_user_permissions#general--views--properties--add) and [General > Alarms > Properties > Edit](xref:DataMiner_user_permissions#general--views--properties--edit)

- If you are upgrading an **existing Ticketing installation** to this version, make sure the hidden Ticketing Lock Manager element is explicitly configured to use version **1.0.3.4** of the **Skyline Lock Manager** connector. Do not set the element to use the Production version; it must reference version 1.0.3.4 directly.

- Any users who will use the Ticketing Solution (including the user installing the solution) will need to have **write access** to the root view and the Ticketing Lock Manager element under the root view (via *Permissions* > *Views*; see [Configuring a user group](xref:Configuring_a_user_group)).

- Installing the following apps alongside the Ticketing Solution will provide access to **additional functionality**:

  - [MediaOps.Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) 1.4.x or higher: Required to be able to assign people to tickets.
  - [InfraOps](https://catalog.dataminer.services/details/5a1edac2-45aa-4498-8ab7-ee322d07da27): Required to be able to link assets to tickets.

## New features

#### Status progress context menu [ID 45900]

You can now transition tickets directly from the Tickets table without opening the ticket details page.

The *Status* column now includes a drop-down indicator with a context menu that only shows transitions available for the ticket's current state. The most likely transition (i.e., the next step in the standard workflow or "happy path") is listed at the top for quick access.

This reduces the number of clicks needed to progress tickets and streamlines common ticket management actions.

#### Ticket history [ID 45904]

A new *Ticket History* view is now available from the ticket *Information* page via the **History** button.

This view provides a complete audit trail of ticket field and status changes, including the following:

- Date and time of the change.
- Modified field or status.
- User who made the change.
- Previous value.
- New value.

> [!NOTE]
> Updates to user notes are not included in this ticket history.

#### Tickets can now be assigned to teams [ID 45911]

It is now possible to assign tickets directly to a team from the People & Organizations app. Previously, tickets could only be assigned to contacts.

Dedicated icons have also been added so you can easily distinguish between teams and contacts when assigning tickets:

![Contact and team assignee icons shown in the Ticketing app](~/release-notes/images/Ticketing_assignment_icons.png)

#### Improved access to linked resources from tickets [ID 45913]

Previously, for linked elements, services, and alarms, only hyperlinks to the Monitoring app were available. Now you can also navigate to Cube for these resources. While navigating to the Monitoring app is perfect for operational monitoring and quick access, the new Cube link will be especially helpful in case more advanced analysis or troubleshooting is needed.

To make navigation more intuitive, dedicated icons indicate the available Monitoring and Cube links. In addition, linked assets now use the Asset Manager icon, making them easier to distinguish from other resource types.

![Linked Items section in the Ticketing app showing the new icons linking to the Monitoring app, Cube, and Asset Manager](~/release-notes/images/Ticketing_linked_resource_icons.png)

#### Email notifications for ticket activity and status changes [ID 45914]

An email notification system has been added so users can stay informed about ticket activity and status changes. This includes the following features:

- Automatic notifications for assigned users:

  - Users assigned to a ticket automatically receive email notifications for all changes made to that ticket.
  - This notification cannot be disabled while the ticket remains assigned; assigned users will continue to receive notifications until the ticket is reassigned or unassigned.

- Subscription-based notifications:

  - Users can subscribe to tickets they want to follow, even when they are not assigned.
  - Non-assigned users can opt in or out of notifications at any time.
  - Upon subscribing or unsubscribing, users receive a confirmation email.
  - Whenever changes are made to a ticket, including notes and other ticket modifications, subscribers receive an email update.

- Direct ticket access from notifications:

  - Notification emails include a direct link to the corresponding ticket.
  - The ticket URL is currently configured as a predefined link but will become configurable in a future release to support customer-specific endpoints.

> [!NOTE]
> Automatic notifications for assigned users are only possible in case a valid email address is configured for these users in the People & Organizations app.

## Changes

### Enhancements

#### Ticket type fields can now be filled in during ticket creation [ID 45915]

When creating a ticket via the Ticketing app or in Cube, you can now immediately provide values for ticket type-specific fields. Previously, these fields had to be filled in afterwards through *Ticket Information* > *Additional Info*.

This streamlines ticket creation and helps ensure that all relevant ticket metadata is captured from the start.

### Fixes

#### Resolution dates not sorted chronologically [ID 45908]

When you sorted on *Expected Resolution Date* or *Requested Resolution Date*, tickets were not correctly ordered chronologically.

This issue has been resolved, improving visibility of upcoming and overdue resolutions.

#### Deprecated contacts could still be used in ticket assignment [ID 45912]

In some cases, deprecated contacts from the People & Organizations app could still be returned and used when assigning tickets. This could cause unexpected behavior when multiple contacts shared the same email address and one or more of those contacts had been deprecated.

This issue has been resolved. Ticket assignment and the *My Tickets* filter now correctly use the active contact linked to the user's email address.
