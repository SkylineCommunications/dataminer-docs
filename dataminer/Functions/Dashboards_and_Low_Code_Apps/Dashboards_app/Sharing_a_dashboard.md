---
uid: Sharing_a_dashboard
---

# Sharing a dashboard

Multiple dashboard sharing options are available, depending on your use case.

- Do you want to send someone a quick static snapshot for reference, or do you want them to be able to explore the live dashboard themselves?

- Does your recipient have direct access to the DataMiner System, or do they rely on remote access?

- Do you want to automatically revoke access to the dashboard based on an expiration date?

There are **three main ways** to share a dashboard:

- [Share a live dashboard with another DataMiner System user via URL](#sharing-a-live-dashboard-via-url).

  This is the preferred option when the recipient already **has access** to your DataMiner System and the necessary permissions. Depending on whether they connect directly or via [remote access](xref:About_Remote_Access), they may also need a [dataminer.services account](xref:Logging_on_to_dataminer_services).

- [Share a live dashboard with an external recipient via cloud share](#sharing-a-live-dashboard-via-cloud-share).

  For this option, recipients **do not need access** to the DataMiner System. They **only need a [dataminer.services account](xref:Logging_on_to_dataminer_services)** to confirm their identity.

  You can automatically revoke dashboard access by configuring an expiration date.

- [Send a static PDF report by email](#sharing-via-email-report).

  This option is useful when you want to share a **read-only snapshot version** of the dashboard.

  The recipient does not need any account or access to the DataMiner System. The PDF is immediately available in their email inbox.

![Sharing](~/dataminer/images/Dashboard_Sharing.png)
*Dashboard sharing in DataMiner 10.5.9*

## Sharing a live dashboard via URL

From DataMiner 10.2.0/10.2.2 onwards, you can generate a URL to easily share your dashboard with other people. Use this option when the recipient is already a user of the DataMiner System.

- The recipient needs to be a **[known user in the DMS](xref:Managing_users)** with the necessary permissions.

- If they access directly, only their DataMiner System account is required.

- If they access remotely (i.e. the URL contains `.on.dataminer.services`), they will also need a [dataminer.services account](xref:Logging_on_to_dataminer_services), with access to the cloud organization and the DataMiner System.

To generate a shareable URL:

1. Open the dashboard you want to share.

1. Click the ... button in the top-right corner and select *Share*.

1. For DataMiner versions older than 10.3.0 [CU12]/10.4.3 only, click *URL*.

1. To share just the dashboard (without the full app UI), enable *Embed*.

1. To get an uncompressed URL (useful for [embedding in a Visio drawing](xref:Linking_a_shape_to_a_webpage) using URL placeholders), enable *Use uncompressed URL parameters*.

1. Copy the link using the *Copy link* button next to the URL.

1. Share the copied URL from your clipboard in your preferred way.

> [!NOTE]
> Dashboards with [restricted user access](xref:Changing_dashboard_settings) cannot be shared yet.

## Sharing a live dashboard via cloud share

Using **cloud sharing**, you can let anyone view your dashboard live in their browser.

You can set an optional expiration date to stop sharing automatically.

- Recipients do not need access to your DataMiner System. They **only need a [dataminer.services account](xref:Logging_on_to_dataminer_services)**. Access to your cloud organization or DMS is not required. A verification ensures that the person opening the link is the same as the person it was shared with.

- This feature is only available if the DataMiner System is **[connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)**. Our cloud services handle the access control and connection to the DMS. No data from your dashboard gets stored in the cloud (see [Cloud connectivity and security](xref:Cloud_connectivity_and_security#live-sharing)).

- The user who shares the dashboard needs the correct **[live sharing permissions](xref:DataMiner_user_permissions#general--live-sharing)**.

### Creating a cloud share

1. Open the dashboard you want to share.

1. Click the ... button in the top-right corner and select *Share* or *Start sharing* (depending on your DataMiner version).

1. If prompted, select *Create cloud share*.

1. If this is your first time sharing a dashboard, link your account to dataminer.services by selecting *I want to link the above users*, and then clicking *Link accounts*.

1. Enter the email addresses of the people you want to share the dashboard with.

1. Optionally add a description, message, or expiration date.

1. Click *Share*.

   The recipients will receive an email with the live dashboard link. You will get a confirmation message, and in the header bar of your dashboard you will see a *Shared* icon (shown from DataMiner 10.3.5/10.4.0 onwards).

> [!NOTE]
>
> - Dashboards with [restricted user access](xref:Changing_dashboard_settings) cannot be shared yet.
> - Dashboards containing certain components cannot be shared yet: spectrum components, Maps, SRM components (service definition and resource usage line graph), pivot tables, queries linked to data, and visualizations based on query data (e.g. node edge graph, table). For dashboards with queries that have the *Update data* setting enabled, sharing is supported from DataMiner 10.2.0 [CU4]/10.2.6 onwards. If you attempt to share a dashboard with content that is not supported for sharing, a message will be displayed with more information.

### Managing or deleting a cloud share

1. Open the dashboard.

1. Click the *Shared* button in the header bar, or click the ... button in the top-right corner and select *Manage share* or *Share* (depending on your DataMiner version).

1. If prompted, select *Manage cloud share*.

1. Remove the share by clicking *Delete*, or update its properties and choose *Update*.

   You will get a confirmation message.

## Sharing via email report

If you only want to share a **static version** of a dashboard, use the steps described under [Sharing a dashboard as a PDF report from the Dashboards app](xref:Sharing_PDF_report_from_Dashboards_app).

Recipients will get the dashboard as a **PDF attachment**. They **do not need any account** or access to the DataMiner System.
