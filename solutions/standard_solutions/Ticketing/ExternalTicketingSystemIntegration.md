---
uid: ExternalTicketingSystemIntegration
description: Learn how the Ticketing Solution can be integrated with external ticketing systems such as ServiceNow, Jira, or Remedy.
---

# External ticketing system integration

The Ticketing Solution can integrate with external ticketing systems such as:

- [ServiceNow](xref:ServiceNowIntegration)
- Jira
- Remedy

This integration is implemented using an element based on a **dedicated connector**, which communicates with the external system.

The element is responsible for:

- Creating incidents or tickets in the external ticketing system.
- Retrieving the external ticket ID (known as the external reference).
- Feeding the external ticket ID back into the Ticketing application.
- Synchronizing status updates between the Ticketing application and the external ticketing system.

External ticketing systems may use different fields, states, severity values, or priority values. The **connector performs the required mapping** and translation between the DataMiner Ticketing ticket fields and states and the external ticketing system ticket fields and states. This mapping and translation works in both directions and ensures consistency between both systems.

When a Ticketing ticket is linked to a ticket in an external ticketing system:

- The external ticket ID is stored on the DataMiner ticket.
- The ticket information page contains a direct link to the ticket on the external ticketing system.
- Users can open the ticket on the external ticketing system directly from DataMiner.
