---
uid: Ticketing_1.0.2
---

# Ticketing 1.0.2

> [!NOTE]
> This version of the Ticketing app is only intended for use with DataMiner version 10.5.0 up to (and including) 10.5.8.

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
