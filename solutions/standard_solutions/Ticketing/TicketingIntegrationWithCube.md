---
uid: CreatingTicketsFromCube
---

# Creating tickets from DataMiner Cube

## Overview

Tickets can be created directly from the DataMiner Cube Alarm Console. This allows operators to quickly create and automatically link tickets to alarms without leaving the monitoring environment.

![Ticketing Cube](~/solutions/images/Ticketing_Cube_1.png)

Tickets created in this way are automatically linked to the relevant:

- Alarm(s)
- Element(s)
- Service(s)
- Asset(s) (if available)

This ensures full traceability between monitoring data and ticketing workflows.

## Manual Ticket Creation from an Alarm

### Procedure

1. Open **DataMiner Cube**.
2. Navigate to the **Alarm Console**.
3. Select an alarm.
4. Right-click the alarm.
5. Click **Create ticket**.

This action launches an **Interactive Automation Script (IAS)** provided by the Ticketing solution.

### Ticket Creation Form

The interactive script presents a form with pre-filled and editable fields.

#### Default Behavior

- The **ticket name** is automatically derived from the alarm and can be modified if needed.
- A **description** is generated and can be modified.

#### Configurable Fields

The user can define:

- **Ticket Type** (for example, Generic Issue)
- **Assignment** (from People & Organizations)
- **Severity**
- **Priority**

### Ticket Creation Result

After confirmation the ticket is created in Ticketing.

![Ticket Confirmation](~/solutions/images/Ticket_Creation_Succesfull.png)

- A confirmation message shows:
  - Ticket ID
  - Name
  - Severity
  - Priority

The form can then be closed.

The below image shows the tickets have been successfully created in Ticketing.

![Ticketing solution tickets](~/solutions/images/Ticketing_Cube_2.png)

### Behavior in Alarm Console

After the ticket is created:

- The **Ticket ID** is written to the alarm property.
- The **Incident Status** is updated (*Acknowledged*).

This information is visible if the alarm properties are enabled in the Alarm Console.

### Ticket Linking

The created ticket in Ticketing Low-Code App is automatically linked to:

- The originating alarm(s)
- The associated element(s) and service(s)
- Any related asset(s) (if available through Asset Manager)

## Automatic Ticket Creation via Correlation

### Overview

Tickets can also be created automatically using **correlation rules**.

A correlation rule can detect specific alarm conditions and trigger ticket creation without user interaction.

### Example Configuration

A common use case is:

- Filter alarms with **critical severity**
- Execute a predefined automation script

The automation script used is provided with the Ticketing solution.

### Behavior

When a matching alarm is generated:

- A ticket is created immediately.
- The ticket is linked to the alarm and related objects.
- The Ticket ID is written back to the alarm.

## Best Practices

- Use manual ticket creation for operator-driven workflows.
- Use correlation rules for automated handling of alarms.
- Ensure alarm properties are enabled to display Ticket ID and status.
