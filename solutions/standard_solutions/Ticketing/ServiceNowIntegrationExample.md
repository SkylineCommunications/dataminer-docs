---
uid: ServiceNowIntegrationExample
---

# ServiceNow integration example

This example describes the end-to-end workflow of creating a ticket from DataMiner Cube and automatically generating a corresponding incident in ServiceNow:

1. An alarm is generated in DataMiner.
1. A [ticket is created from Cube](#creating-a-ticket) with ServiceNow integration enabled.
1. A corresponding incident is automatically created in ServiceNow, and the ServiceNow incident ID is stored in the DataMiner ticket.
1. [Updates in ServiceNow](#synchronization-with-updates-in-servicenow) are synchronized back to DataMiner, ensuring that the ticket state in DataMiner reflects the state of the incident on the external system.

## Creating a ticket

[Create a ticket from the Alarm Console](xref:CreatingTicketsFromCube), but also configure the following details in the ticket creation window:

- Select an **external ticketing system**
- Choose the ServiceNow entry created during the [integration configuration](xref:ServiceNowIntegration#configuration).

![Ticket creation example illustrating the ServiceNow integration](~/solutions/images/Ticketing_ServiceNowExample_1.png)

Several things will now happen:

- A DataMiner ticket ID and ServiceNow incident ID are generated and shown in the creation response.
- A ticket is created in DataMiner, linked to the alarm.
- A corresponding incident is created in ServiceNow.
- Ticket properties in the Alarm Console (Ticket ID, Incident Number, Incident Status) are updated accordingly.

## Viewing the ticket

In the Ticketing application, you will see the ticket listed with its assigned ID.

Clicking the information icon for the ticket will among others show the following details:

- Linked alarm and element
- External ticketing details
- The corresponding ServiceNow incident ID

## Opening the ServiceNow incident

From the ticket information page, you can select the **ServiceNow incident link**.

This opens the corresponding incident directly in ServiceNow using the stored incident ID.

![ServiceNow incident link on the information page with the corresponding incident in ServiceNow](~/solutions/images/Ticketing_ServiceNowExample_Incident.png)

## Synchronization with updates in ServiceNow

When the incident is updated in ServiceNow, for example, if the status is set to *In progress*, or if the incident is assigned to a user, the ServiceNow Incident Manager connector will automatically detect these updates. The connector will then synchronize the ticket accordingly in the Ticketing application.

After synchronization, the DataMiner ticket will reflect the updated state (e.g., status change to *In progress*), and you will be able to see the updates in the ticket details and notes section.

For example:

![Example of ServiceNow state change reflected in the Ticketing app](~/solutions/images/Ticketing_ServiceNowExample_StateChange.png)
