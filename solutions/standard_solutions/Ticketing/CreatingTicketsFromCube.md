---
uid: CreatingTicketsFromCube
description: Discover how to create DataMiner tickets directly from Cube alarms so operators can act faster and keep every incident linked to the right context.
---

# Manually creating a ticket in DataMiner Cube

Tickets can be created directly from the DataMiner Cube Alarm Console. This allows operators to quickly create tickets linked to alarms without leaving the monitoring environment, based on an interactive Automation script that makes use of the Ticketing API Helper.

The tickets will be automatically linked to the relevant alarms, elements, and/or services. If the [Asset Manager](xref:Asset_Manager) app is installed, they will also be linked to the relevant assets.

To manually create a ticket for an alarm in Cube:

1. Right-click the alarm in the Alarm Console, and select **Create ticket**.

   ![Create Ticket option in the right-click menu of the Cube Alarm Console](~/solutions/images/Ticketing_Create_ticket.png)

   This will open a pop-up window where a name and description will be suggested based on the alarm.

1. In the pop-up window, adjust the name, description, type, assignee, impact, and priority as needed.

   ![Ticket creation pop-up window](~/solutions/images/Ticketing_Create_ticket_popup.png)

   > [!TIP]
   > Selecting an assignee is only possible if the [People & Organizations](xref:People_Organizations) app is available in the system.

1. Click *Create*.

   A confirmation message will be shown, which will contain the ticket ID, name, severity, and priority. For example:

   ![Confirmation message shown when a ticket has been successfully created](~/solutions/images/Ticketing_Ticket_created_confirmation.png)

1. Click *OK*.

   The *Ticket ID* property of the alarm will now be set to ID of your new ticket, and the *Incident Status* property of the alarm will be set to *Acknowledged*.

   In the ticketing app, you will be able to see your newly created ticket. For example:

   ![Ticketing app with new ticket based on the right-clicked alarm](~/solutions/images/Ticketing_Creation_result.png)

> [!TIP]
> Ensure that alarm properties are displayed in the Alarm Console so users can view the ticket ID and status for each alarm in DataMiner Cube.
