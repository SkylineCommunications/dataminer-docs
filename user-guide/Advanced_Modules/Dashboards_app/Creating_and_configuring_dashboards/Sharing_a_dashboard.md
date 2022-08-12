---
uid: Sharing_a_dashboard
---

# Sharing a dashboard

## Sharing a dashboard using the Live Sharing Service

> [!NOTE]
> This feature is only available if the DMA is connected to the cloud. See [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud). Prior to DataMiner 10.1.12, this feature is only available in [soft launch](https://community.dataminer.services/documentation/soft-launch-options/).

1. In the list of dashboards on the left, select the dashboard you want to share.

1. Click the ... button in the top-right corner of the dashboard, and select *Share* or *Start sharing* (depending on your DataMiner version).

   > [!NOTE]
   >
   > - Make sure you have the necessary user permissions for this:
   >     - Prior to DataMiner 10.2.0 \[CU2\]/10.2.5, to edit the dashboard, you need the user permission [Modules > Reports & Dashboards > Dashboards > Edit](xref:DataMiner_user_permissions#modules--reports--dashboards--dashboards--edit).
   >     - In DataMiner 10.1.2, you need the user permission *Other* > *CCALinkAccount*.
   >     - In DataMiner 10.1.3, you need the user permission [Modules > System configuration > Cloud sharing/gateway > Account linking](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--account-linking).
   >     - From DataMiner 10.1.4 onwards, you need the appropriate [Live sharing user permissions](xref:DataMiner_user_permissions#general--live-sharing).
   > - If access to a dashboard is limited to some users only, it will not be possible to share this dashboard.

1. If you are using DataMiner 10.2.0/10.2.2 or higher, in the pop-up window, select *Create cloud share*. Otherwise, skip this step.

1. If it is the first time you are sharing the dashboard, you may be asked to confirm that you want to link your account to the cloud. Select *I want to link the above users* and click *Link accounts*.

1. In the pop-up window, *With* field, fill in the email address of the person you want to share the dashboard with.

1. Optionally, you can add a description in the *Description* field.

1. Optionally, in the *Message* field, add a message you want to send to the person you are sharing the dashboard with, in order to provide additional information.

1. If you do not want the dashboard to remain permanently available, toggle *Add expiration date* option and specify the expiration date.

1. Click *Share*. An email will be sent to the person you are sharing the dashboard with, to inform them that they now have access to the dashboard.

> [!NOTE]
>
> - You can stop sharing a dashboard by clicking the ... button again and selecting *Manage share*. This will open a pop-up box where you can delete the share or update the message.
> - At present, sharing dashboards that use the following components is not supported: spectrum components, Maps, SRM components (service definition and resource usage line graph), pivot tables, queries using feeds, and visualizations based on query feeds (e.g. node edge graph, table). For dashboards with queries that have the *Update data* setting enabled, sharing is supported from DataMiner 10.2.0 [CU4]/10.2.6 onwards. If you attempt to share a dashboard with content that is not supported for sharing, a message will be displayed with more information.

> [!TIP]
> See also: [Cloud connectivity and security](xref:Cloud_connectivity_and_security)

## Sharing a dashboard URL

From DataMiner 10.2.0/10.2.2 onwards, you can generate a URL to easily share a dashboard with other people who have the necessary rights to access it.

To do so:

1. In the list of dashboards on the left, select the dashboard.

1. Click the ... button in the top-right corner of the dashboard, and select *Share*.

1. Click *URL*.

1. To get a URL that only shows the dashboard without the rest of the app, select *Embed*.

1. To get an uncompressed version of the URL, select *Use uncompressed URL parameters*.

1. To the right of the URL, click the *Copy* button.

## Sharing a dashboard as a PDF report via email

This feature is currently still in preview. To use it, the soft-launch option *ReportsAndDashboardsExport* must be activated. For more information, refer to [Soft-launch options](https://community.dataminer.services/documentation/soft-launch-options/) on DataMiner Dojo.

> [!NOTE]
> Sharing a dashboard as a PDF report is possible from the Automation, Correlation and Scheduler modules even if the *ReportsAndDashboardsExport* soft-launch option is not activated. For more information, see [Generating a report based on a dashboard](xref:Generating_a_report_based_on_a_dashboard)

To share a dashboard as a PDF report in the Dashboards app (from DataMiner 10.2.0/10.2.2 onwards):

1. In the list of dashboards on the left, select the dashboard you want to share.

1. Click the ... button in the top-right corner of the dashboard, and select *Share*.

1. Click *Email report*.

1. In the *To* box, specify the email address(es) you want to send the PDF report to.

1. Optionally, specify additional addresses in the *CC* boc, and/or click *Add BCC* to add additional addresses in the *BCC* box.

1. In the *Subject* box, specify the subject for the email.

1. Optionally, in the *Message* box, add the message body for the email.

1. To include a CSV file for each component of the dashboard, select *Include CSV*. This is only supported for specific components, such as the line graph, pivot table, and table component.

1. Optionally, expand the *Report* section to specify the following options:

   - *Add info*: Select this option to include your company details in the report.

   - *Add logo*: Select this option to display the company logo in the report.

   - *Page numbers*: Select this option to display page numbers in the report.

   - *Stack components*: Select this option if you want all components to be displayed below one another. This can be especially useful for dashboards containing large components (e.g. pivot tables) in order to make sure all data is displayed.

   - *Paper format*: Allows you to select a different format than the default A4 format for the PDF.

1. When everything has been configured, at the top, click *Send*.
