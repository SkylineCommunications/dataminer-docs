# ServiceNow Integration Example

## Overview

This example describes the end-to-end workflow of creating a ticket from DataMiner Cube and automatically generating a corresponding incident in ServiceNow.

It also demonstrates how updates performed in ServiceNow are synchronised back to DataMiner.

---

## Creating a Ticket with External Integration

### Procedure

![Ticketing Service Now Integration Example](~/solutions/images/Ticketing_ServiceNowExample_1.png)

1. Open **DataMiner Cube**.
2. Navigate to the **Alarm Console**.
3. Right-click an alarm.
4. Select **Create ticket**.
5. In the ticket creation form:
   - Select an **external ticketing system**
   - Choose the ServiceNow entry created during connector configuration
6. Confirm the ticket creation.

The system will:

- Create a ticket in DataMiner
- Trigger the creation of a corresponding incident in ServiceNow

---

## Creation Result

After the process completes:

- A **DataMiner ticket ID** is assigned
- A **ServiceNow incident ID** is generated
- Both identifiers are shown in the creation response

In the Alarm Console:

- The ticket is linked to the alarm
- Ticket properties (Ticket ID, Incident Number, Incident Status) are updated accordingly

---

## Viewing the Ticket

In the Ticketing application:

- The ticket is visible with its assigned ID
- The information page shows:
  - Linked alarm and element
  - External ticketing details
  - The corresponding ServiceNow incident ID

---

## Opening the ServiceNow Incident

From the ticket information page you can select the **ServiceNow incident link**.

This opens the corresponding incident directly in ServiceNow using the stored incident ID. 

![Service Now Incident Example](~/solutions/images/Ticketing_ServiceNowExample_Incident.png)

---

## Synchronisation Behaviour

### Updating in ServiceNow

When the incident is updated in ServiceNow, for example:

- Change status to **In Progress**
- Assign the incident to a user

These updates are automatically detected by the connector which will synchronise the ticket accordingly in the Ticketing application.

After synchronisation:

- The DataMiner ticket reflects the updated state
- The status changes accordingly (for example, to *In Progress*)
- Updates are visible in the ticket details and notes section

![Service Now State Change Example](~/solutions/images/Ticketing_ServiceNowExample_StateChange.png)

---

## End-to-End Flow Summary

1. An alarm is generated in DataMiner.
2. A ticket is created from Cube with ServiceNow integration enabled.
3. A corresponding incident is created in ServiceNow.
4. The ServiceNow incident ID is stored in the DataMiner ticket.
5. Updates in ServiceNow are synchronised back to DataMiner.
6. The ticket state in DataMiner reflects the state of the incident on the external system.

---