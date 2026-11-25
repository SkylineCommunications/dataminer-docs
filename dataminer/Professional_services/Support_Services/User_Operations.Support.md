---
uid: User_operations_support
---

# Support application

Via the [Support application](https://admin.dataminer.services/support) on dataminer.services, you can report issues to Skyline Support and track the progress of your support tickets.

Key features:

- **Maintenance requests**: Create a new support ticket under your maintenance contract via a guided pop-up window.

- **Real-time monitoring**: Access an overview of all tickets submitted for your organization.

- **Status tracking**: Instantly see the status of a reported ticket, including any tasks linked to it.

> [!IMPORTANT]
> If you experience any technical issues while using the portal, please contact the DataMiner Support team directly via email at <support@dataminer.services>.

## Accessing the support application

The application is available at <https://admin.dataminer.services/support>.

You can log in in the [same way as for dataminer.services](xref:Logging_on_to_dataminer_services).

To get access, you need to be part of an organization on dataminer.services (see [Controlling user access to dataminer.services features](xref:Giving_users_access_to_cloud_features)).

## Support tickets overview

When you open the [Support application](https://admin.dataminer.services/support), an overview of the support tickets for your organization is shown. For each ticket, the following information is available:

- **ID**: The unique identifier of the ticket.
- **Title**: A short description of the reported issue.
- **State**: The current state of the ticket, e.g. *In Progress*, *Follow-up*, or *Closed*.
- **Reported by**: The person who created the ticket.
- **Created**: The date and time when the ticket was created.

The following filters are available above the overview:

- **Created at**: A time filter that determines which tickets are shown based on their creation time. By default, only the tickets created in the last 30 days are shown. Select a wider range to retrieve older tickets.
- **Include closed tickets**: Enable this toggle button to also include tickets that have already been closed.

## Creating a support ticket

1. In the upper-right corner of the [Support application](https://admin.dataminer.services/support), click *Create support ticket*.

   This opens the *Create support ticket* pop-up window.

1. Fill in the following information:

   - **Maintenance contract**: Mandatory. Select the maintenance contract the ticket applies to.
   - **Title**: Mandatory. A short explanation of the problem you are encountering.
   - **Description**: Mandatory. A detailed explanation of the problem.
   - **Contacts**: The person creating the ticket is automatically added here and will be included in the *To* field of the ticket creation email. Any other contacts you add will be included in the *Cc* field.
   - **Cloud-connected DMS**: The DataMiner System connected to dataminer.services that the ticket applies to. Only the DataMiner Systems that your account has been added to will be listed (see [Controlling user access to dataminer.services features](xref:Giving_users_access_to_cloud_features)). If the relevant DataMiner System is not connected to dataminer.services, select the *Non-cloud-connected Agent (DMA)* option and provide the cluster name, the Agent name, and Agent ID.
   - **Attachments (optional)**: Drag and drop files onto the box, or click *choose files* to select them. To upload a file with an unsupported extension, zip the file and upload the zip file instead.

1. Click *Create*.

   A confirmation pop-up window will be displayed, and a ticket creation email will be sent out.

   > [!NOTE]
   > If the ticket includes large attachments, ticket creation can take a moment. Please be patient and do not close the window while the ticket is being created.

## Viewing ticket details

When you click a ticket in the overview, a side panel opens on the right with the details of that ticket:

- The ticket title, its current state, and its creation time.
- The full description of the reported issue.
- The team the ticket is currently assigned to.
- The project the ticket is linked to.
- Any tasks linked to the ticket, with their current status.

Every ticket also has a unique URL, so you can bookmark it or share a direct link with a colleague. Opening the ticket in the side panel will give you the URL for that ticket, ending with `?id=<ticket ID>`.
