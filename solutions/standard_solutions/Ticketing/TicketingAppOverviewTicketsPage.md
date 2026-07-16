---
uid: TicketingAppOverviewTicketsPage
description: Get a clear overview of open tickets with smart filters, quick actions, and detailed insights to track issues from creation to closure.
---

# Tickets page

The **Tickets page** is displayed by default when you open the app.

This page provides an overview of all tickets in the system that are currently open, sorted by creation time.

![Ticketing page](~/solutions/images/Ticketing_Demo_02_TicketsPage.png)

## Displayed fields

For each ticket, the following information is shown:

- Ticket ID
- Name
- Status
- Severity
- Priority
- Ticket type
- Assignee
- Creation date
- Requested and expected resolution dates

## Filtering

The Tickets page includes several filtering options:

- **Basic filters**, available via the magnifying glass icon in the upper-right corner of the tickets table:

  - Filter by status (for example, In Progress, Pending, Resolved, On Hold, Acknowledged)
  - Filter by severity (for example, Critical, Major, Minor)
  - Filter by priority (for example, High, Medium, Low)
  - Filter by ticket type (for example, Generic Issue, Service Disruption)
  - Filter by assignee (for example, P&O Team, P&O Person)
  - Search by Ticket ID
  - Search by name or keyword

- **Predefined filters**, available via buttons in the upper-left corner:

  - **Open Tickets**: Default view.
  - **All**: Shows all tickets, including closed, canceled, and rejected tickets.

    For example, below all tickets are set to be shown:

    ![Tickets page with 'All' tickets filter activated](~/solutions/images/Ticketing_Demo_03_AllTickets.png)

- **Assignment filter**, available to the right of the predefined filters:

  - **All Assignees**: View tickets assigned to all users.
  - **My Tickets**: View tickets assigned to the current user (based on [People & Organizations](xref:People_Organizations)), for example:

    ![Tickets page with 'My Tickets' filter activated](~/solutions/images/Ticketing_Demo_04_MyTickets.png)

  > [!TIP]
  > To make sure tickets can be assigned to DataMiner users, the user accounts must be [mapped to People & Organizations contacts](xref:MappingUsersAndContacts).

## Viewing closed tickets

Once a ticket is closed, it is no longer shown in the default **Open Tickets** view. To locate it, switch to the **All** filter, which includes closed, canceled, and rejected tickets.

For example, the ticket #47 below is shown as *Closed* in the full ticket list:

![Closed ticket shown in All Tickets view on the Tickets page](~/solutions/images/Ticketing_Demo_18_ClosedTicket.png)

## Creating tickets

The *Create Ticket* button in the upper-right corner can be used to manually add a ticket. For details, refer to [Manually creating a ticket in the Ticketing app](xref:CreatingTicketsManuallyFromApp).

## Overview subpage

Via the *Overview* button in the upper-right corner of the Tickets page, you can access the Overview subpage.

![Overview button on the Tickets page](~/solutions/images/Ticketing_Button_to_Overview_page.png)

This subpage provides a high-level summary of all tickets in the system, allowing you to quickly monitor workloads, identify trends, and track the current status of open issues. It serves as a central dashboard where key ticket statistics and recently created tickets are displayed in one place.

![Overview subpage](~/solutions/images/Ticketing_Demo_10_Overview.png)

At the top of the page, you can use the available filters to narrow down the displayed information:

- **Time Range**: Display ticket statistics for a specific period.
- **Assignee**: Display tickets assigned to a particular user or team.
- **Ticket State**: Focus on tickets in a specific status, such as Open, Pending, Resolved, or In Progress.

The dashboard includes several charts that provide insight into your ticket data:

- **Tickets by Priority**: Shows how tickets are distributed across priority levels (for example: Low, Medium, and High).
- **Tickets by Severity**: Displays the number of tickets based on their severity, helping identify critical issues that may require immediate attention.
- **Tickets by State**: Provides an overview of the current status of tickets, such as Open, Pending, Acknowledged, Resolved, or In Progress.
- **Tickets by Type**: Breaks down tickets by category or ticket type, giving visibility into the kinds of requests being handled.

At the bottom of the page, the **Most Recently Created Tickets** section displays the latest tickets added to the system. This section allows you to quickly review newly created tickets and access them for further investigation or action.

## Ticket Information subpage

When you click the information icon for a ticket on the Tickets page, this will open the Ticket Information subpage for this ticket.

![Ticket Information subpage](~/solutions/images/Ticketing_Demo_11_InformationPageHistory.png)

### General Info section

In the upper-left corner, this page displays the following general information:

- Status
- Priority
- Severity
- Ticket ID
- Ticket type
- Assignee
- Requested and expected resolution dates
- Description

Via the pencil icon in the upper-right corner of this section, you can open a pane where you can edit this general information, for example:

![Panel shown when general ticket information is edited](~/solutions/images/Ticketing_Demo_12_EditTicketFields.png)

### Additional Info section

In the upper-right corner, any additional fields defined in the ticket type are displayed.

Via the pencil icon in this section, you can edit the values as needed, for example:

![Panel shown when additional ticket information is edited](~/solutions/images/Ticketing_Demo_13_EditTicketTypeFields.png)

### Ticket state transitions

The ticket transition controls at the top of the Ticket Information subpage can be used to progress the ticket through its lifecycle. A reason must be provided for every state change, which is automatically recorded in the [Notes section](#notes-section).

Tickets usually follow a defined lifecycle. The ideal path for them to follow, i.e., the "happy path", goes as follows: *Acknowledged* → *In Progress* → *Resolved* → *Closed*.

The suggested next step according to the happy path is highlighted and placed first in the list of state transition controls, for example:

![State transition controls showing Resolve as the next step for a ticket with status 'In Progress'](~/solutions/images/Ticketing_State_transition_controls.png)

When applicable, alternative transitions are also available.

### Subscribe button

You can subscribe to a ticket by using the **Subscribe** button on the Ticket Information page.

![Subscribe button on the Ticket Information page](~/solutions/images/Ticketing_subscribe_button.png)

When you are subscribed to a ticket, you will receive email notifications whenever the ticket is updated, including:

- State changes
- Field updates
- New notes
- Changes to linked items
- Other modifications made to the ticket

This way, you can stay informed about ticket progress without being assigned to the ticket directly.

### History button

Via the History button on the Ticket Information page, you can access a complete audit trail of all changes made to a ticket throughout its lifecycle.

![History button on the Ticket Information page](~/solutions/images/Ticketing_History_button.png)

For every modification, the history records show the following information:

- The date and time of the change
- The user who performed the change
- The modified field name
- The previous value
- The new value

The history page also includes filtering options, allowing you to focus on specific field changes and quickly locate relevant updates.

This audit trail provides full visibility into how a ticket evolved over time and supports operational reviews, troubleshooting, compliance requirements, and accountability.

![Ticket history shown after clicking the History button](~/solutions/images/Ticketing_Demo_21_TicketHistory.png)

### Linked Items section

If a ticket has been linked to an item, this is shown in the Linked Items section.

Tickets can be linked to the following objects (depending on your setup):

- Alarms
- Elements
- Assets
- Services
- External tickets

Clicking the ![Monitoring](~/solutions/images/Ticketing_Monitoring_icon.png) or ![Cube](~/solutions/images/Ticketing_Cube_icon.png) icon for a linked alarm, element, or service will show the corresponding item in the Monitoring app or Cube app, respectively.

![Linked alarms icons and the resulting Monitoring and Cube windows](~/solutions/images/Ticketing_Demo_14_LinkedItemsAlarmDataMiner.png)

![Linked element icons and the resulting Monitoring and Cube windows](~/solutions/images/Ticketing_Demo_20_LinkedItemsAlarmCube_2.png)

Clicking a linked asset will open [Asset Manager](xref:Asset_Manager), while clicking an external ticket will open the [external ticketing system](xref:ExternalTicketingSystemIntegration) (for example, ServiceNow):

![Linked asset and external ticket and the resulting windows when these are clicked](~/solutions/images/Ticketing_Demo_LinkedItemsExternalAsset.png)

### Notes section

The Notes section provides a history of system notes and user notes:

- System notes are created for state changes. Whenever a user changes the state of a ticket, they need to provide the reason, which is then included in a system note.
- Additional user notes can be added at any point. These can also be edited or removed.

![Notes section of the Ticket Information subpage](~/solutions/images/Ticketing_Demo_16_NotesOverview.png)

Each user note maintains its own change history. When a note is modified, previous versions are preserved, and these can be viewed from the note history.
