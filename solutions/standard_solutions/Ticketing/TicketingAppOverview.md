---
uid: TicketingAppOverview
---

# Ticketing app overview

The Ticketing application provides a user interface to create, manage, and track tickets within DataMiner.

It consists of the following main pages:

- [Tickets](#tickets-page)
- [Ticket Types](#ticket-types-page)
- [External Ticketing](#external-ticketing-page)

## Accessing the Ticketing app

To access the Ticketing low-code app:

1. Go to the [landing page](xref:Accessing_the_web_apps#dataminer-landing-page) of your DataMiner System.

1. Search for the Ticketing app and click the app tile to open it.

![The Ticketing app tile on the DataMiner System landing page](~/solutions/images/Ticketing_OpeningTicketing_Landing_page.png)

Alternatively, you can also look for the Ticketing app in the *Apps* pane of the DataMiner Cube sidebar, and open the app from there.

[Pinning the app in the sidebar](xref:DataMiner_Cube_sidebar) will allow quick and easy access to the app from Cube.

![The Ticketing app access via the DataMiner Cube sidebar either via the Apps pane or via a pinned app in the sidebar](~/solutions/images/Ticketing_OpeningTicketing_Cube.png)<br>*Ticketing app access via the DataMiner Cube sidebar in DataMiner 10.6.7*

## Tickets page

### General page

The **Tickets page** is displayed by default when you open the app.

This page provides an overview of all tickets in the system that are currently open, sorted by creation time.

![Ticketing page](~/solutions/images/Ticketing_Demo_02_TicketsPage.png)

### Displayed Fields

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

### Filtering

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

#### Viewing closed tickets

Once a ticket is closed, it is no longer shown in the default **Open Tickets** view. To locate it, switch to the **All** filter, which includes closed, canceled, and rejected tickets.

For example, the ticket #10 below (*Broadcast Signal Degradation – Sports XTreme Channel*) is shown as *Closed* in the full ticket list:

![Closed ticket shown in All Tickets view on the Tickets page](~/solutions/images/Ticketing_Demo_18_ClosedTicket.png)

### Create Ticket button

The *Create Ticket* button in the upper-right corner can be used to manually add a ticket. For details, refer to [Manually creating a ticket in the Ticketing app](xref:CreatingTicketsManuallyFromApp).

### Overview subpage

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

### Ticket Information subpage

When you click the information icon for a ticket on the Tickets page, this will open the Ticket Information subpage for this ticket.

![Ticket Information subpage](~/solutions/images/Ticketing_Demo_11_InformationPageHistory.png)

#### General Info section

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

#### Additional Info section

In the upper-right corner, any additional fields defined in the ticket type are displayed.

Via the pencil icon in this section, you can edit the values as needed, for example:

![Panel shown when additional ticket information is edited](~/solutions/images/Ticketing_Demo_13_EditTicketTypeFields.png)

#### Ticket state transitions

The ticket transition controls at the top of the Ticket Information subpage can be used to progress the ticket through its lifecycle. A reason must be provided for every state change, which is automatically recorded in the [Notes section](#notes-section).

Tickets usually follow a defined lifecycle. The ideal path for them to follow, i.e., the "happy path", goes as follows: *Acknowledged* → *In Progress* → *Resolved* → *Closed*.

The suggested next step according to the happy path is highlighted and placed first in the list of state transition controls, for example:

![State transition controls showing Resolve as the next step for a ticket with status 'In Progress'](~/solutions/images/Ticketing_State_transition_controls.png)

When applicable, alternative transitions are also available.

#### Subscribe button

You can subscribe to a ticket by using the **Subscribe** button on the Ticket Information page.

![Subscribe button on the Ticket Information page](~/solutions/images/Ticketing_subscribe_button.png)

When you are subscribed to a ticket, you will receive email notifications whenever the ticket is updated, including:

- State changes
- Field updates
- New notes
- Changes to linked items
- Other modifications made to the ticket

This way, you can stay informed about ticket progress without being assigned to the ticket directly.

#### History button

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

#### Linked Items section

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

#### Notes section

The Notes section provides a history of system notes and user notes:

- System notes are created for state changes. Whenever a user changes the state of a ticket, they need to provide the reason, which is then included in a system note.
- Additional user notes can be added at any point. These can also be edited or removed.

![Notes section of the Ticket Information subpage](~/solutions/images/Ticketing_Demo_16_NotesOverview.png)

Each user note maintains its own change history. When a note is modified, previous versions are preserved, and these can be viewed from the note history.

## Ticket Types page

Ticket types define the structure of tickets and may include additional fields. The Ticket Types page provides an overview of all available ticket types and allows you to [create additional ticket types](#creating-a-ticket-type).

![Ticket Types page](~/solutions/images/Ticketing_Demo_05_DifferentTicketTypes.png)

### Ticket type categories

Ticket types can be configured as one of the following categories:

- A **base ticket type** can define a common set of additional fields and can be used as a base for other ticket types. This means that base ticket types serve as a reusable foundation for other ticket types.

  When creating a new ticket type or editing an existing ticket type, you can designate it as a base ticket type by enabling the **Base** option.

- An **extended ticket type** inherits the configuration and additional fields of a base ticket type. It can define its own additional fields in addition to the inherited fields, allowing specialization of existing ticket types without duplicating configuration.

  When creating or editing an extended ticket type, you can select the base ticket type from which it should extend.

- A **standalone ticket type** is independent and is not extended from a base type. This is any ticket type that is not marked as a base type and does not extend another ticket type. This is especially suitable for unique ticket structures that do not share a common foundation with other ticket types.

### Default ticket type

The default ticket type is **Generic Issue**.

No additional fields are defined for this ticket type, and it is used for standard out-of-the-box tickets.

![Generic Issue ticket type shown in edit mode](~/solutions/images/Ticketing_Demo_06_GenericIssueType.png)

### Example ticket type: Service Disruption

As an example of how you can use ticket types, you could use the **Service Disruption** ticket type. This type is intended for incidents that affect the availability or performance of a service. It includes additional fields that help operators assess the operational and business impact of the disruption and prioritize response efforts accordingly, as illustrated below.

![Service Disruption ticket type shown in edit mode](~/solutions/images/Ticketing_Demo_Service_Disruption.png)

The following additional fields are available:

- **Affected Service**: Name of the service experiencing the disruption.
- **Customer Impact Level**: Indicates the scope of the customer impact. Available values:
  - Low: Individual User
  - Medium: Small Group
  - High: Department/Region
  - Critical: Entire Service
- **Customers Affected**: Number of customers affected by the disruption.
- **Revenue Impact ($/hour)**: Estimated revenue loss per hour caused by the disruption.
- **SLA Breach Risk**: Indicates whether the disruption may result in a service-level agreement (SLA) breach.
- **Target Resolution Time**: Expected time required to restore the affected service.
- **Service Disruption Start**: Date and time when the service disruption began.

### Creating a ticket type

To create a ticket type:

1. In the upper-right corner of the Ticket Types page, click **Create ticket type**.

1. Enter a name and select an icon for the ticket type.

1. If you wish to use the ticket type as a base ticket type, select the *Base* option, or, alternatively, if you want to create an extended ticket type based on another ticket type, select the base type from which you want to extend. See [Ticket type categories](#ticket-type-categories).

1. Specify additional fields to match your use case.

1. Click *Save*.

![Create Ticket Type form](~/solutions/images/Ticketing_Demo_08_CreateTicketTypes.png)

## External Ticketing page

The External Ticketing page lists all configured [external integrations](xref:ExternalTicketingSystemIntegration). Entries can represent external systems such as ServiceNow. For each entry, a visualization endpoint and API endpoint are listed.

If aplicable additional custom external systems can be added with the *Create External Ticketing* button in the upper-right corner, but typically however such an entry will be created automatically by the element responsible for the communication with the external ticketing system. See for example [ServiceNow integration](xref:ServiceNowIntegration).

Via the pencil icon, you can edit each of the added external integrations.

![External Ticketing page](~/solutions/images/Ticketing_Demo_09_ExternalTicketing.png)
