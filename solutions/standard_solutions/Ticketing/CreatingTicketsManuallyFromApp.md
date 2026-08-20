---
uid: CreatingTicketsManuallyFromApp
---

# Manually creating a ticket in the Ticketing app

1. On the Tickets page of the Ticketing app, click *Create Ticket*.

   ![Create Ticket button in the top-right corner of the Ticketing app's Tickets page](~/solutions/images/Ticketing_Create_Ticket_button.png)

1. In the pop-up window, fill in the following information:

   - Name (mandatory)
   - Description (mandatory)
   - Type (mandatory)
   - Assignee (mandatory)
   - Priority (mandatory)
   - Severity (mandatory)

   For example:

   ![Create Ticket](~/solutions/images/Ticketing_Demo_17_CreateATicket.png)

   > [!TIP]
   > To make sure tickets can be assigned to DataMiner users, the user accounts must be [mapped to People & Organizations contacts](xref:MappingUsersAndContacts).

1. Optionally, also configure the following settings:

   - Specify a requested and expected resolution date.
   - Link affected resources such as elements, services, and assets.
   - Select an external ticketing system.
   - Enable email notifications.

     > [!NOTE]
     > Email notifications are disabled by default for users other than the assignee. The ticket assignee always receives email notifications for ticket updates. Other users can opt in by enabling the **Notify me about changes via email** option during ticket creation or when editing the ticket.

1. If you selected a ticket type that requires the configuration of additional fields, click *Next* and configure those fields.<!-- RN 45915 -->

1. Click *Save*.
