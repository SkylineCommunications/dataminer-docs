---
uid: User_operations_support
---

# User Operations Support

This application allows to view the existing tickets and the creation of new ones. [User Operations Support](https://operations.skyline.be/)

## Ticket Overview 

This Section allows to check the existing tickets.

It is possible to adjust which tickets will be displayed based on:

- Ticket Status.
- Ticket Creation Time.

It is also possible to adjust the table by selecting which columns to display and the number of rows to display.

From the table is possible to click on the ticket id to open the [Ticket Details](#ticket-details)

## Ticket Details

This section allows to view the ticket details.

Tasks related with the ticket will be shown here also.

## Report Ticket

This section allows to report a new ticket.

### Registration Tab

On this tab is possible to specify the following:

- Customer, this is a mandatory field. The customer for the logged user is selected by default.
- Project Type, this field is used to filter the projects by type. In case there is a **Maintenance Contract** project available for the logged user it will be selected by default.
- Project, this is a mandatory field. In case there is a **Maintenance Contract** project available with status **In Progress** it will be selected by default.
- Additional Contacts, this field is optional. Is possible to add an email per line. The confirmation email will have the specified contacts in cc.

### Ticket Details Tab

On this tab is possible to specify the following:

- Title, this is a mandatory field. Please specify the title of the ticket.
- Description, this is a mandatory field. Please specify a detailed description of the ticket.
- Impact, this is a mandatory field. Please select the impact from the list. In case **Other** is selected as impact and additional required field will show to specify the impact details.
- Affecting Production, this is a mandatory field. Please specify if the ticket is related to a production system.
- Related systems. Allows to specify which systems are related with the ticket. Is possible to select cloud connected systems or to manually specify them.
- Log Collection.
  - Automatic (via Cloud). Requires the selection of at least one cloud system.
  - Manual (will require to upload a [Log Collector Package](xref:Collecting_data_to_report_an_issue_to_TechSupport)). Requires the selection of at least one system.
  - Non (Not Recommended)

### Attachments Tab

On this tab is possible to upload files related with the ticket.

### Finish

On this tab is possible to see a summary of the ticket that will be created.

The submit button will initiate the ticket creation flow. A progress bar will show the status. In case the ticket contains attachments this will also be reflected on the progress bar. Once the ticket creation has completed a the [Ticket Details](#ticket-details) will be shown.
