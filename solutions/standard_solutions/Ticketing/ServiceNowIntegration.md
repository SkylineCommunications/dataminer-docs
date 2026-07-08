---
uid: ServiceNowIntegration
---

# ServiceNow integration

The DataMiner Ticketing solution can be integrated with ServiceNow to enable the creation and synchronization of external incidents.

This integration is implemented using a dedicated element, which manages the communication between DataMiner and the ServiceNow instance.

## Prerequisites

A ServiceNow instance must be available to allow incident creation.

![ServiceNow instance](~/solutions/images/Ticketing_ServiceNowInstance.png)

## Configuration

To configure the integration, create a DataMiner element using the **ServiceNow Incident Manager connector**, and configure the following parameters in the element:

- ServiceNow instance IP address or endpoint
- User credentials (username and password)

The image below shows the ServiceNow instance and the configured element.

![ServiceNow instance and DataMiner element shown side by side](~/solutions/images/Ticketing_ServiceNowIntegration_1.png)

When the element is created:

- An entry is automatically added to the **External Ticketing** page in the Ticketing solution.
- A **visualization endpoint** is registered, allowing direct navigation to ServiceNow incidents.

![ServiceNow visualization endpoint shown in the Ticketing app](~/solutions/images/Ticketing_ServiceNowExternalTicketing.png)

## Ticket creation flow

### Subscription mechanism

The ServiceNow connector subscribes to ticket creation events in DataMiner.

When a new ticket is created:

- A message is sent to the connector element.
- The message contains a **GUID** identifying the external ticketing configuration.

### GUID matching

Each connector instance representing an external ticketing system is associated with a unique external identifier GUID.

- When a ticket is created, it includes an external identifier GUID reference.
- If the GUID in the ticket matches the connector GUID:
  - The connector processes the request.
  - A corresponding incident is created in ServiceNow.

### Incident creation

When a match is identified:

1. The connector creates an incident in ServiceNow.
1. ServiceNow returns its **incident ID**.
1. The connector sends this ID back to the DataMiner Ticketing application.

### Ticket and incident linking

After the incident is created:

- The ServiceNow incident ID is stored in the DataMiner ticket.
- The Ticketing application can construct a direct link using:
  - The visualization endpoint
  - The incident ID

This allows users to open the corresponding ServiceNow incident directly from DataMiner.

## Update behavior

In this implementation, synchronization is **one-way** for updates. Updates are propagated from **ServiceNow to DataMiner only**.

The connector element periodically polls the ServiceNow instance for updates. When a change is detected:

1. The update is retrieved using the ServiceNow incident ID.
1. The corresponding DataMiner ticket is located.
1. The ticket is updated in the Ticketing application.

## Best practices

- Ensure correct configuration of credentials and endpoints.
- Field mapping between DataMiner tickets and ServiceNow incidents must be defined to ensure consistent synchronization. Fields may differ in structure and therefore require explicit mapping and value translation where needed.
