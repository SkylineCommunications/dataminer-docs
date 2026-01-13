---
uid: User_operations_support
---

# Support application

Our support application is designed to streamline your maintenance requests and keep you informed every step of the way. 
Through this portal, you can easily manage technical issues and track the progress of your tickets in real-time.

**Key Features:**
 - Request Maintenance: Create a new ticket within your dedicated Maintenance Support project using a step-by-step wizard designed to guide you through the entire reporting process effortlessly.

 - Real-Time Monitoring: Access a comprehensive dashboard of all your submitted tickets.

 - Status Tracking: Instantly see the status of a reported ticket.

The application is available at <https://supportpreview.dataminer.services/>. You can log in in the [same way as for dataminer.services](xref:Logging_on_to_dataminer_services).

> [!IMPORTANT]
> Please note that this application is currently in a Preview stage. While we strive for a seamless experience, you may encounter minor bugs. If you experience any technical issues while using the portal, please contact our support team directly via email at support@dataminer.services.


## Ticket Overview page

The *Ticket Overview* page is the default page shown when you open the Support application. On this page, you can check existing tickets.

Several **filters** are available on this page:

- You can use the filters in the top-left corner to only show tickets with a specific **status**.

- With the time filter at the top, you can filter the tickets on **creation time**.

The check boxes right above the table allow you to show or hide specific columns. Below this, you can also select how many rows should be displayed at the same time.

If you click a ticket ID in the table, the **ticket details** will be displayed. These include any **tasks** related to the ticket.

## Report Ticket page

The *Report Ticket* page allows you to report a new ticket:

1. On the *Registration* tab, fill in the following information:

   - *Customer*: Mandatory field. The customer matching the logged-in user is selected by default.

   - *Order Type*: This field is used to filter the projects by type. In case there is a maintenance contract project available for the logged-in user, it will be selected by default.

   - *Order*: Mandatory field. In case there is a maintenance contract project available with status *In Progress*, it will be selected by default.

   - *Additional Contacts*: Optional. In this field, you can add an email per line. When the ticket is created, the confirmation email will have the specified contacts in CC.

1. When all the necessary information is filled in, click *Next* in the lower-right corner.

1. On the *Ticket Details* tab, fill in the following information:

   - *Title*: Mandatory field. Specify a title for the ticket.

   - *Description*: Mandatory field. Add a detailed description of the issue.

   - *Impact*: Mandatory field. Select the impact in the dropdown list. If you select *Other*, you will need to specify the impact details in an additional field.

   - *This issue is affecting a Production System*: Select *Yes* or *No*.

   - *Systems*:

     - If the system is connected to dataminer.services, select the system and the relevant DMA in the dropdown boxes.

     - If the system is not connected to dataminer.services, click the cloud toggle button and then specify the system details manually.

     - To add more systems, click the *Add System* button.

     - If you have accidentally added a system that should not be included for the ticket, you can remove it using the garbage can icon on the right.

   - *Log Collection*: Select how logs will be collected for the ticket:

     - *Automatic (via Cloud)*: Select this option if logs can be collected via dataminer.services. Only select this option if at least one of the systems specified under *Systems* is connected to dataminer.services.

     - *Manual*: If you select this option, you will need to upload a [Log Collector package](xref:Collecting_data_to_report_an_issue_to_TechSupport). Requires the selection of at least one system.

     - *None (not recommended)*: In most cases, a logCollector package is crucial for the investigation. One example to select this option is, for instance, when something failed collecting the logcollector package. 

1. When all the necessary information is filled in, click *Next* in the lower-right corner.

1. Optionally, on the *Attachments* tab, upload files related to the ticket. Please note that if you need to upload more than 1 file, they all need to be in the same folder.

1. Click *Next* in the lower-right corner.

   The *Finish* tab will be displayed, which will show a summary of the ticket that will be created.

1. If all the information is correct, click *Submit* to initiate ticket creation. Otherwise, click *Back*, adjust the information, and click *Next* again until you can submit the ticket.

   A progress bar will show the status of the ticket. In case the ticket contains attachments, this will also be reflected on the progress bar. Once the ticket creation is complete, the ticket details will be shown. A ticket creation email will also be sent out at this phase.
