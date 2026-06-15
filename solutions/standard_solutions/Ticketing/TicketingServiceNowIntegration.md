---
uid: ServiceNowIntegration
---

# ServiceNow integration

## Overview

The DataMiner Ticketing solution can be integrated with ServiceNow to enable the creation and synchronization of external incidents.

This integration is implemented using a dedicated connector element, which manages the communication between DataMiner and the ServiceNow instance.

## Configuration

### ServiceNow Instance & Connector Element

A ServiceNow instance must be available to allow incident creation.

Integration is configured by creating a DataMiner element using the **ServiceNow Incident Manager connector**.

The following parameters must be configured:

- ServiceNow instance IP address or endpoint
- User credentials (username and password)

The below image shows the Service Now instance and the configured element.

![Service Now and Connector Element](~/solutions/images/Ticketing_ServiceNowIntegration_1.png)

### External Ticketing Registration

When the connector element is created:

- An entry is automatically added to the **External Ticketing** page in the Ticketing solution.
- A **visualization endpoint** is registered.
- An **API endpoint** is also created (not used in this setup).

![Service Now Integration](~/solutions/images/Ticketing_ServiceNowIntegration_2.png)

The visualization endpoint allows direct navigation to ServiceNow incidents.

## Ticket Creation Flow

For better understanding see the image above.

### Subscription Mechanism

The ServiceNow connector subscribes to ticket creation events in DataMiner.

When a new ticket is created:

- A message is sent to the connector element.
- The message contains a **GUID** identifying the external ticketing configuration.

### GUID Matching

Each connector instance representing an external ticketing system is associated with a unique external identifier GUID.

- When a ticket is created, it includes an external identifier GUID reference.
- If the GUID in the ticket matches the connector GUID:
  - The connector processes the request.
  - A corresponding incident is created in ServiceNow.

### Incident Creation

When a match is identified:

1. The connector creates an incident in ServiceNow.
1. ServiceNow returns its **incident ID**.
1. The connector sends this ID back to the DataMiner Ticketing application.

## Ticket and Incident Linking

After the incident is created:

- The ServiceNow incident ID is stored in the DataMiner ticket.
- The Ticketing application can construct a direct link using:
  - The visualization endpoint
  - The incident ID

This allows users to open the corresponding ServiceNow incident directly from DataMiner.

## Synchronization behavior

### Direction

In this implementation:

- Synchronization is **one-way**
- Updates are propagated from **ServiceNow to DataMiner only**

### Update Mechanism

The connector element periodically polls the ServiceNow instance for updates.

When a change is detected:

1. The update is retrieved using the ServiceNow incident ID.
2. The corresponding DataMiner ticket is located.
3. The ticket is updated in the Ticketing application.

### Extensibility

The integration can be extended to support:

- Two-way synchronization
- Updates initiated from DataMiner
- Full lifecycle management across both systems

## Best Practices

- Ensure correct configuration of credentials and endpoints.
- Use consistent mapping between DataMiner tickets and ServiceNow incidents.
- The visualization endpoint is used to navigate to the incident on the external ticketing system.
