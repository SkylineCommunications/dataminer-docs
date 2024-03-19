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

   - *Customer*, this is a mandatory field. The customer for the logged user is selected by default.

   - *Project Type*, this field is used to filter the projects by type. In case there is a **Maintenance Contract** project available for the logged user it will be selected by default.

   - *Project*, this is a mandatory field. In case there is a **Maintenance Contract** project available with status **In Progress** it will be selected by default.

   - *Additional Contacts*, this field is optional. Is possible to add an email per line. The confirmation email will have the specified contacts in cc.

1. When all the necessary information is filled in, click *Next* in the lower right corner.

1. On the *Ticket Details* tab, fill in the following information:

   - *Title*, this is a mandatory field. Please specify the title of the ticket.

   - *Description*, this is a mandatory field. Please specify a detailed description of the ticket.

   - *Impact*, this is a mandatory field. Please select the impact from the list. In case **Other** is selected as impact and additional required field will show to specify the impact details.

   - *This issue is affecting a Production System*: Yes/No

   - *Systems*:

     - If the system is connected to dataminer.services, select the system and the relevant DMA in the drop-down boxes.

     - If the system is not connected to dataminer.services, click the cloud toggle button and then specify the system details manually.

     - To add more systems, click the *Add System* button.

     - If you have accidentally added a system that should not be included for the ticket, you can remove it using the garbage can icon on the right.

   - *Log Collection*: Select how logs will be collected for the ticket.

     - *Automatic (via Cloud)*: Select this option if the DataMiner System is connected to dataminer.services. Requires the selection of at least one cloud system.

     - *Manual*: If you select this option, you will need to upload a [Log Collector package](xref:Collecting_data_to_report_an_issue_to_TechSupport). Requires the selection of at least one system.

     - *None (not recommended)*

1. When all the necessary information is filled in, click *Next* in the lower right corner.

1. Optionally, on the *Attachments* tab, upload files related to the ticket.

1. Click *Next* in the lower right corner.

   The *Finish* tab will be displayed, which will show a summary of the ticket that will be created.

1. If all the information is correct, click *Submit* to initiate ticket creation. Otherwise, click *Back*, adjust the information, and click *Next* again until you can submit the ticket.

   A progress bar will show the status of the ticket. In case the ticket contains attachments, this will also be reflected on the progress bar. Once the ticket creation is complete, the ticket details will be shown.
