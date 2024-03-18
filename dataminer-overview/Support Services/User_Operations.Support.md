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

- Customer
- Project Type
- Project
- Additional Contacts

### Ticket Details Tab

On this tab is possible to specify the following:

- Title
- Description
- Impact
- Affecting Production
- Related systems. Allows to select cloud connected systems and manual input.
- Log Collection:
  - Automatic (via Cloud)
  - Manual (will require to upload a Log Collector Package)
  - Non (Not Recommended)

### Attachments Tab

On this tab is possible to upload files related with the ticket.

### Finish

On this tab is possible to see a summary of the ticket that will be created.

The submit button will initiate the ticket creation flow. A progress bar will show the status. In case the ticket contains attachments this will also be reflected on the progress bar. Once the ticket creation has completed a the [Ticket Details](#ticket-details) will be shown.
