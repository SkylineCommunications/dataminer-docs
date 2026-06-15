---
uid: TicketingAppOverview
---

# Ticketing app overview

## Overview

The Ticketing application provides a user interface to create, manage, and track tickets within DataMiner.

![How To Open Ticketing](~/solutions/images/Ticketing_Demo_01_OpeningTicketing.png)

It can be accessed in multiple ways:

- Open from Cube using the available apps menu
- Search for the Ticketing application and pin it to the sidebar
- Open it from the DataMiner home interface

## Tickets page

### General page

When opening the application, the **Tickets page** is displayed by default.

![Ticketing Page](~/solutions/images/Ticketing_Demo_02_TicketsPage.png)

This page provides an overview of all tickets in the system which are currently open sorted by creation time.

### Displayed Fields

Each ticket shows general parameters:

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

The Tickets page includes filtering options:

#### Basic Filters

- Filter by status (for example, In Progress, Pending, Resolved, On Hold, Acknowledged)
- Filter by severity (for example, Critical, Major, Minor)
- Filter by priority (for example, High, Medium, Low)
- Filter by ticket type (for example, Generic Issue, Service Disruption)
- Filter by assignee (for example, P&O Team, P&O Person)
- Search by Ticket ID
- Search by name or keyword

#### Predefined Filters

- **Open tickets** (default view)
- **All tickets** (includes closed, cancelled, and rejected tickets)

![All Tickets](~/solutions/images/Ticketing_Demo_03_AllTickets.png)

#### Assignment Filter

- View tickets assigned to all users
- View tickets assigned to the current user (based on People & Organizations)

![My Tickets](~/solutions/images/Ticketing_Demo_04_MyTickets.png)

## Overview page

The Overview page provides a high-level summary of all tickets in the system, allowing you to quickly monitor workload, identify trends, and track the current status of open issues. It serves as a central dashboard where key ticket statistics and recently created tickets are displayed in one place.

![Overview](~/solutions/images/Ticketing_Demo_10_Overview.png)

At the top of the page, you can use the available filters to narrow down the displayed information. The dashboard can be filtered by:

- Time Range – View ticket statistics for a specific period.
- Assignee – Display tickets assigned to a particular user or team.
- Ticket State – Focus on tickets in a specific status, such as Open, Pending, Resolved or In Progress.

The dashboard includes several visual charts that provide insight into your ticket data:

- Tickets by Priority – Shows how tickets are distributed across priority levels (for example: Low, Medium, and High).
- Tickets by Severity – Displays the number of tickets based on their severity, helping identify critical issues that may require immediate attention.
- Tickets by State – Provides an overview of the current status of tickets, such as Open, Pending, Acknowledged, Resolved, or In Progress.
- Tickets by Type – Breaks down tickets by category or ticket type, giving visibility into the kinds of requests being handled.

At the bottom of the page, the Most Recently Created Tickets section displays the latest tickets added to the system. This section allows users to quickly review newly created tickets and access them for further investigation or action.

## Ticket Types

### Overview

Ticket types define the structure of tickets and may include additional fields.

![Ticket Types](~/solutions/images/Ticketing_Demo_05_DifferentTicketTypes.png)

### Ticket Type Categories

Ticket types can be configured as one of the following categories:

#### Base Ticket Types

A **base ticket type** serves as a reusable foundation for other ticket types.

Base types can be designated when creating a new ticket type or by editing an existing ticket type and enabling the **Base** option.

Characteristics:

- Can define a common set of additional fields.
- Can be used as a base for other ticket types.

#### Extended Ticket Types

An **extended ticket type** inherits the configuration and additional fields of a base ticket type.

When creating or editing an extended ticket type, you can select the base ticket type from which it should extend.

Characteristics:

- Inherits all fields from the selected base type.
- Can define its own additional fields in addition to the inherited fields.
- Allows specialization of existing ticket types without duplicating configuration.

#### Standalone Ticket Types

A **standalone ticket type** is independent and is not extended from a base type.

Characteristics:

- Is not marked as a base type.
- Does not extend another ticket type.
- Contains only the fields configured for it.
- Suitable for unique ticket structures that do not share a common foundation with other ticket types.

### Default Type

- **Generic Issue**
  - No additional fields
  - Used for standard out of the box tickets

![Generic Issue](~/solutions/images/Ticketing_Demo_06_GenericIssueType.png)

## Sample Ticket Type

### Service Disruption

The **Service Disruption** sample ticket type is intended for incidents that affect the availability or performance of a service. It includes additional fields that help operators assess the operational and business impact of the disruption and prioritize response efforts accordingly.

![Service Disruption](~/solutions/images/Ticketing_Demo_Service_Disruption.png)

The following additional fields are available:

- **Affected Service** – Name of the service experiencing the disruption.
- **Customer Impact Level** – Indicates the scope of the customer impact. Available values are:

  - Low – Individual User
  - Medium – Small Group
  - High – Department/Region
  - Critical – Entire Service
- **Customers Affected** – Number of customers impacted by the disruption.
- **Revenue Impact ($/hour)** – Estimated revenue loss per hour caused by the disruption.
- **SLA Breach Risk** – Indicates whether the disruption may result in a service-level agreement (SLA) breach.
- **Target Resolution Time** – Expected time required to restore the affected service.
- **Service Disruption Start** – Date and time when the service disruption began.

### Ticket Type Creation

Users can create ticket types:

1. Select **Create ticket type**
1. Define:
   - Name
   - Icon
   - Define as Base Ticket Type (enable this option to designate the ticket type as a reusable base type that other ticket types can extend from, reusing all its fields) or select a base type from which you want to extend.
   - Additional fields
1. Save the configuration

![Create Ticket Type Form](~/solutions/images/Ticketing_Demo_08_CreateTicketTypes.png)

## External Ticketing Page

The External Ticketing page lists all configured external integrations.

![External Ticketing](~/solutions/images/Ticketing_Demo_09_ExternalTicketing.png)

- Entries may represent external systems such as ServiceNow
- Each entry includes:
  - Visualization endpoint
  - API endpoint

Custom external systems can also be edited or added if required.

## Ticket Information Page

![Information Page](~/solutions/images/Ticketing_Demo_11_InformationPageHistory.png)

### Access

Open the information page by:

- Clicking the ticket ID
- Selecting the information icon

### General Information

Each ticket displays:

- Status
- Priority
- Severity
- Ticket ID
- Ticket type
- Assignee
- Requested and expected resolution dates
- Description

Fields can be edited using the edit option.

![Edit Ticket Fields](~/solutions/images/Ticketing_Demo_12_EditTicketFields.png)

### Additional Information

As defined in the additional fields of a ticket type:

- These fields are displayed in the Additional Information section
- Values can be edited as needed

![Edit Ticket Type Fields](~/solutions/images/Ticketing_Demo_13_EditTicketTypeFields.png)

### Ticket Subscription To Email Notifications

Users can subscribe to a ticket by selecting the **Subscribe** button on the Ticket Information page.

When subscribed, the user receives email notifications whenever the ticket is updated, including:

- State changes
- Field updates
- New notes
- Changes to linked items
- Other modifications made to the ticket

This allows users to stay informed about ticket progress without being assigned to the ticket directly.

### Ticket State Transitions

- Tickets follow a defined lifecycle (for example *happy path*: Acknowledged → In Progress → Resolved → Closed).
- Suggested next steps according to the happy path are highlighted and placed first in the list (see if there is a better wording for this).
- Alternative transitions are also available when applicable.

### Linked Items

Tickets can include links to:

- Alarms
- Elements
- Assets
- Services
- External tickets

These links allow navigation to:

- Monitoring app or DataMiner Cube (alarms, elements and services)

![Linked Items Alarms](~/solutions/images/Ticketing_Demo_14_LinkedItemsAlarmDataMiner.png)

![Linked Items Element](~/solutions/images/Ticketing_Demo_20_LinkedItemsAlarmCube_2.png)

- Asset Manager
- External systems (for example ServiceNow)

![Linked Items External Ticketing](~/solutions/images/Ticketing_Demo_LinkedItemsExternalAsset.png)

### Notes

The Notes section provides a history of system notes and user notes:

- System notes are created for state changes (reason must be provided whenever a ticket state is changed)
- User notes can be added, edited and removed

![Notes section](~/solutions/images/Ticketing_Demo_16_NotesOverview.png)

Each user note maintains its own change history. When a note is modified, previous versions are preserved and can be viewed from the note history.

### History

The History button on the Ticket Information page provides a complete audit trail of all changes made to a ticket throughout its lifecycle.

![Ticket History](~/solutions/images/Ticketing_Demo_21_TicketHistory.png)

The history view records every modification and displays:

- Date and time of the change
- User who performed the change
- Field name that was modified
- Previous value
- New value

The history page also includes filtering options, allowing users to focus on specific field changes and quickly locate relevant updates.

This audit trail provides full visibility into how a ticket evolved over time and supports operational reviews, troubleshooting, compliance requirements, and accountability.

## Creating Tickets

### Manual Creation

![Create Ticket](~/solutions/images/Ticketing_Demo_17_CreateATicket.png)

1. Select **Create Ticket** in the Ticketing application on Tickets Page
1. Enter:
   - Name
   - Description
   - Ticket type
   - Assignee
   - Priority and severity
   - Notify me about changes via email (see note below)
1. Optionally:
   - Set resolution dates
   - Link affected resources (elements and services) or assets
   - Select external ticketing system
   - Enable email notifications
1. Save the ticket

> [!NOTE]
> Email notifications are disabled by default for users other than the assignee. The ticket assignee (from People & Organizations) always receives email notifications for ticket updates. Other users can opt in by enabling the **Notify me about changes via email** option during ticket creation or when editing the ticket.

### Progressing Through the Ticket Lifecycle

After creation, open the ticket's information page and use the state transition controls to progress it through its lifecycle. A reason must be provided for every state change, which is automatically recorded in the Notes section.

### Viewing a Closed Ticket

Once a ticket is closed, it no longer appears in the default **Open Tickets** view. To locate it, switch to the **All** filter, which includes closed, canceled, and rejected tickets.

![Closed Ticket in All Tickets View](~/solutions/images/Ticketing_Demo_18_ClosedTicket.png)

In the example above, ticket **#10** (*Broadcast Signal Degradation – Sports XTreme Channel*) is shown as **Closed** in the full ticket list, with its creation and closure timestamps visible.

Opening the ticket again displays the full information page, including all state transitions and the notes added at each step.

![Closed Ticket Information Page](~/solutions/images/Ticketing_Demo_19_ClosedTicketInformation.png)

The information page shows:

- The current **Closed** status, along with Priority (*High*) and Severity (*Major*)
- All **Additional Info** fields from the *Service Disruption* ticket type, such as Affected Service, Customer Impact Level, Customers Affected, Revenue Impact, SLA Breach Risk, and Target Resolution Time
- A complete **Notes** history with system notes for each state transition and any user notes added during the lifecycle

### Behavior

- New tickets are created in an initial state (*Acknowledged*)
- Users can progress the ticket through the states during its lifecycle
- All state changes are automatically recorded in the Notes section

## Ticket Lifecycle Example

The ideal workflow (happy path):

1. Ticket is created (Acknowledged)
1. Set to **In Progress**
1. Move to **Resolved**
1. Finalize as **Closed**

If necessary:

- Tickets can be moved to other states (add the states)
- Additional notes can be added at each step

## Best Practices

- Use filters to categorize types of incidents.
- Define clear ticket types with appropriate fields.
- Always assign tickets to ensure ownership (requires People & Organizations to be configured).
- Use notes to document all actions and decisions.
- Ensure proper linking to elements, services and assets.
- Review ticket states and update accordingly.
