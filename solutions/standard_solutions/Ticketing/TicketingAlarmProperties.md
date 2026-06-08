# Alarm Properties for Ticketing

## Overview

When the DataMiner Ticketing solution is installed, it automatically creates three custom alarm properties. These properties allow ticket information to be visible directly in the Alarm Console.

![Ticketing Alarm Properties](~/solutions/images/Ticketing_AlarmProperties.png)

The following properties are added:

- **Ticket ID**
- **Incident Status**
- **Incident Number** 

These properties support both internal ticket tracking and integration with external ticketing systems.

---

## Enabling Alarm Properties in Cube

The custom alarm properties are not displayed by default. They must be manually enabled in the Alarm Console.

### Procedure

1. Open **DataMiner Cube**.
2. Navigate to the **Alarm Console**.
3. Right-click on any column header.
4. Select **Add or remove columns**.
5. Open the **Alarm Properties** section.
6. Select:
   - Ticket ID
   - Incident Status
   - Incident Number

After selection, the properties will be available as columns in the Alarm Console.

---

## Property Description

### Ticket ID

- Contains the identifier of the ticket created from the alarm.
- Automatically populated when a ticket is created.
- Used for internal tracking within DataMiner. 

---

### Incident Status

- Displays the current status of the associated ticket.
- Reflects updates made during the ticket lifecycle.
- Allows operators to monitor progress directly from the Alarm Console. 

---

### Incident Number

- Contains the reference to an external ticket.
- Used when integration with external systems (for example ServiceNow or Jira) is configured.
- Used for synchronisation of DataMiner tickets and external incidents.

---

## Behaviour

When a ticket is created from an alarm:

- The **Ticket ID** is automatically written to the alarm.
- The **Incident Status** is updated based on the ticket state.
- If an external system is used, the **Incident Number** is populated with the external reference.

This ensures that all relevant ticket information is visible without leaving the Alarm Console.

---

## Best Practices

- Always enable the 3 alarm properties in operational views.
- Include these columns in standard Alarm Console layouts.
- Use Incident Number when external integrations are active to ensure traceability.
- Monitor Incident Status to track ticket progress without opening the ticket.

---