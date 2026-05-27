---
uid: TicketingArchitecture
---

# Ticketing Solution architecture

The Ticketing Standard Solution consists of two main building blocks:

- [Ticketing backend](#ticketing-backend)
- [Ticketing frontend](#ticketing-frontend)

These blocks work together to provide ticket lifecycle management, integration with other DataMiner components, and user interaction.

Below you can see a more detailed overview of the solution's architecture and how it interacts with other components.

![Overview of the Ticketing Solution architecture](~/solutions/images/Ticketing_HighLevel.png)

## Ticketing backend

The Ticketing backend implements the core logic of the Ticketing app and is built on top of the **DataMiner Standard Data Model (SDM)**. This allows the Ticketing Solution to expose a **Ticketing API Helper** that can be used by other DataMiner components, such as:

- Automation scripts
- DataMiner connectors/elements
- Other Standard Solutions

The Ticketing backend uses **SDM relationships** (formerly known as "SDM Object Linking") to associate tickets with other DataMiner objects or objects from other applications, including:

- Alarms
- Elements
- Services
- Assets from the InfraOps [Asset Manager](xref:Asset_Manager) app

This SDM relationships layer can be consulted by other DataMiner applications to determine which tickets are linked to which objects.

## Ticketing frontend

The Ticketing frontend is the user interface of the solution, which is implemented as a low-code app.

All tickets, fields, and related values are stored as a DataMiner Object Model (DOM).

The user interaction is handled through forms. The logic for these is implemented using interactive automation scripts. The scripts are responsible for:

- Input validation
- Business logic checks
- Ticket processing actions

The Ticketing app can be used as a standalone app or via its API Helper. Both methods support full ticket lifecycle management, from creation to resolution.

## Interaction with other apps

Interaction with other apps is built into the solution. For example:

- On the Ticket Information page of the Ticketing app:

  - Clicking an alarm opens it in the [Monitoring app](xref:Working_with_the_Monitoring_app).
  - Clicking an element opens it in the Monitoring app.
  - Clicking an asset opens it in the [Asset Manager](xref:Asset_Manager) app.

- In the Asset Manager app:

  - Assets display an indication of linked tickets.
  - The list of linked tickets in the Ticketing application can be opened directly from the asset.

The Ticketing Solution can also optionally interact with the MediaOps.Plan [People & Organizations](xref:People_Organizations) app to manage the **ownership and assignment** of tickets. Ownership ensures that it is always clear who is responsible for progressing a ticket towards closure. Tickets can be assigned to a contact or a team as defined in the People & Organizations app.

While technically Ticketing can operate without the People & Organizations app, tickets cannot be assigned in that case, which means you lose the benefit of structured ticket ownership. We therefore **strongly recommend using the Ticketing application together with the MediaOps.Plan Solution**.
