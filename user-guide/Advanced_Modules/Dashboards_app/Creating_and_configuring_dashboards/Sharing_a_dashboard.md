---
uid: Sharing_a_dashboard
---

# Sharing a dashboard

## Sharing a dashboard using the Live Sharing Service

> [!NOTE]
> - Prior to DataMiner 10.1.12, this feature is only available in [soft launch](https://community.dataminer.services/documentation/soft-launch-options/).
> - This feature is only available if the DMA is connected to the cloud. See [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. In the list of dashboards on the left, select the dashboard you want to share.

1. Click the ... button in the top-right corner of the dashboard, and select *Start sharing*.

    > [!NOTE]
    > - Make sure you have the necessary user permissions for this:
    >     - To edit the dashboard, you need the user permission [Modules > Reports & Dashboards > Dashboards > Edit](xref:DataMiner_user_permissions#modules--reports--dashboards--dashboards--edit).
    >     - In DataMiner 10.1.2, you need the user permission *Other* > *CCALinkAccount*.
    >     - In DataMiner 10.1.3, you need the user permission [Modules > System configuration > Cloud sharing/gateway > Account linking](xref:DataMiner_user_permissions#modules--system-configuration--cloud-sharinggateway--account-linking).
    >     - From DataMiner 10.1.4 onwards, you need the appropriate [Live sharing user permissions](xref:DataMiner_user_permissions#general--live-sharing).
    > - If access to a dashboard is limited to some users only, it will not be possible to share this dashboard.

1. If it is the first time you are sharing the dashboard, you may be asked to confirm that you want to link your account to the cloud. Select *I want to link the above users* and click *Link accounts*.

1. In the pop-up window, fill in the email address of the person you want to share the dashboard with.

1. Optionally, in the *Message* field, add a message you want to send to the person you are sharing the dashboard with, in order to provide additional information.

1. If you do not want the dashboard to remain permanently available, select the *Expires* option and specify the expiration date.

1. Click *Share*. An email will be sent to the person you are sharing the dashboard with, to inform them that they now have access to the dashboard.

> [!NOTE]
> - You can stop sharing a dashboard by clicking the ... button again and selecting *Manage share*. This will open a pop-up box where you can delete the share or update the message.
> - At present, sharing dashboards that use the following components is not supported: spectrum components, Maps, SRM components (service definition and resource usage line graph), pivot tables, queries using feeds, and visualizations based on query feeds (e.g. node edge graph, table). If you attempt to share a dashboard with content that is not supported for sharing, a message will be displayed with more information.
>

## Sharing a dashboard as a PDF

This feature is currently still in preview. To activate it, the soft-launch option *ReportsAndDashboardsExport* must be activated. For more information, refer to [Soft-launch options](https://community.dataminer.services/documentation/soft-launch-options/) on DataMiner Dojo.

> [!NOTE]
> Sharing a dashboard as a PDF report is possible from the Automation, Correlation and Scheduler modules even if the *ReportsAndDashboardsExport* soft-launch option is not activated. For more information, see [Generating a report based on a dashboard](xref:Generating_a_report_based_on_a_dashboard)
>
