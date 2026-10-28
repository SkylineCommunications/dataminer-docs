---
uid: MediaOps_Live_1.0.0
---

# MediaOps Live 1.0.0

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11 or higher.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 1.0.1 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.2.0 or higher.

> [!TIP]
> Installing [MediaOps Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) alongside MediaOps Live allows you to schedule orchestration events. This requires MediaOps Plan **1.5.0** or higher.

## New features

#### Virtual Signal Groups: Initial functionality [ID 44887]

The Virtual Signal Groups app enables engineers to model and manage sources and destinations across different devices and transport technologies in large-scale networks.

With this initial release, you can:

- Create, edit, delete, import, and export endpoints, including transport-specific metadata.
- Define transport types and configure custom free-text fields per transport type.
- Create, edit, delete, import, and export source and destination virtual signal groups.
- Organize endpoints in virtual signal groups by levels, with each level linked to a transport type.
- Assign virtual signal groups to categories to simplify source and destination selection in the Control Surface app.
- Provision and update endpoints and virtual signal groups at scale through CSV import/export and the MediaOps Live API.

#### Control Surface: Initial functionality [ID 44889]

The Control Surface app provides operators with a software-defined panel to manage source and destination routing without requiring detailed knowledge of the underlying devices or transport technology.

With this initial release, you can:

- Connect one source to one or multiple destinations.
- Connect and disconnect individual levels for granular routing control.
- Disconnect one or multiple destinations in a single action.
- Lock and unlock destinations, including a lock reason and visibility of lock ownership.
- See scheduled job-driven connections in the UI to reduce accidental overwrites during live operations.
- Filter sources and destinations by category to quickly find relevant signals.

#### Orchestration Events: Initial functionality [ID 44890]

The Orchestration Events app provides operational visibility and search capabilities for scheduled orchestration events in MediaOps Live.

With this initial release, you can:

- View upcoming and recently started events on an arrivals board.
- Search events by name, time, type, state, or orchestration type.
- Open detailed event information from both overview pages.
