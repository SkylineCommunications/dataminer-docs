---
uid: Ticketing_1.0.2
---

# Ticketing 1.0.2

## Prerequisites

- This version of the Ticketing app is only intended for use with DataMiner version **10.5.0 up to (and including) 10.5.8**.

- Ticketing needs the **GQI DxM** to be enabled. For information on how to enable this prior to DataMiner 10.5.8, refer to [Enabling or disabling the use of the GQI DxM](xref:GQI_DxM#enabling-or-disabling-the-use-of-the-gqi-dxm).

- The user installing Ticketing needs the following **user permissions**:

  - [General > Elements > Add](xref:DataMiner_user_permissions#general--elements--add)
  - [General > Alarms > Allow to add or update hyperlinks](xref:DataMiner_user_permissions#general--alarms--allow-to-add-or-update-hyperlinks)
  - [General > Alarms > Properties > Add](xref:DataMiner_user_permissions#general--views--properties--add) and [General > Alarms > Properties > Edit](xref:DataMiner_user_permissions#general--views--properties--edit)

- Any users who will use the Ticketing Solution (including the user installing the solution) will need to have **write access** to the root view and the Ticketing Lock Manager element under the root view (via *Permissions* > *Views*; see [Configuring a user group](xref:Configuring_a_user_group)).

## New features

#### Ticketing app: Initial functionality [ID 44970]

The new Ticketing app provides a centralized way to create, manage, and track operational tickets, allowing users to handle incidents, manage the ticket lifecycle through state transitions, link tickets to elements, services and alarms and integrate with external ticketing systems.

With this initial release, you can:

- Create, view, edit, and manage tickets with standard fields and lifecycle state transitions, including the ability to add notes for progress tracking.

- Define configurable ticket types with custom fields to extend ticket metadata for different operational use cases.

- View tickets in a centralized table with filtering capabilities and predefined views such as *Active Tickets* and *All Tickets*.

- Link tickets to DataMiner objects (elements, services, and alarms).

- Manually create tickets directly from alarms or alarm groups in DataMiner Cube with automatic linking to alarms and elements.

- Automatically generate tickets through correlation rules.

- Integrate with external ticketing systems and track external ticket identifiers.

- Create and manage tickets programmatically through a backend API for automation and external system integrations.
