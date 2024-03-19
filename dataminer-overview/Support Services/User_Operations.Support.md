---
uid: User_operations_support
---

# User Operations Support application

With the User Operations Support application, you can both keep track of existing tickets and create new ones.

The application is available at <https://operations.skyline.be/>

## Ticket Overview page

The *Ticket Overview* page is the default page shown when you open the User Operations Support application. On this page, you can check existing tickets.

Several **filters** are available on this page:

- You can use the filters in the top-left corner to only show tickets with a specific **status**.

- With the time filter at the top, you can filter the tickets on **creation time**.

The check boxes right above the table allow you to show or hide specific columns. Below this, you can also select how many rows should be displayed at the same time.

If you click a ticket ID in the table, the **ticket details** will be displayed. These include any **tasks** related to the ticket.

## Report Ticket page

The *Report Ticket* page allows you to report a new ticket:

1. On the *Registration* tab, fill in the following information:

   - *Customer*

   - *Project Type*

   - *Project*

   - *Additional Contacts*

   - *24/7 Intervention*: Yes/No

1. When all the necessary information is filled in, click *Next* in the lower right corner.

1. On the *Ticket Details* tab, fill in the following information:

   - *Title*

   - *Description*

   - *Impact*

   - *This issue is affecting a Production System*: Yes/No

   - *Systems*:

     - If the system is connected to dataminer.services, select the system and the relevant DMA in the drop-down boxes.

     - If the system is not connected to dataminer.services, click the cloud toggle button and then specify the system details manually.

     - To add more systems, click the *Add System* button.

     - If you have accidentally added a system that should not be included for the ticket, you can remove it using the garbage can icon on the right.

   - *Log Collection*: Select how logs will be collected for the ticket.

     - *Automatic (via Cloud)*: Select this option if the DataMiner System is connected to dataminer.services.

     - *Manual*: If you select this option, you will need to upload a Log Collector package.

     - *None (not recommended)*

1. When all the necessary information is filled in, click *Next* in the lower right corner.

1. Optionally, on the *Attachments* tab, upload files related to the ticket.

1. Click *Next* in the lower right corner.

   The *Finish* tab will be displayed, which will show a summary of the ticket that will be created.

1. If all the information is correct, click *Submit* to initiate ticket creation. Otherwise, click *Back*, adjust the information, and click *Next* again until you can submit the ticket.

   A progress bar will show the status of the ticket. In case the ticket contains attachments, this will also be reflected on the progress bar. Once the ticket creation is complete, the ticket details will be shown.
