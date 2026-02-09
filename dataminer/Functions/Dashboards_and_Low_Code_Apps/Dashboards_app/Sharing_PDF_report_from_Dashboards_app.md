---
uid: Sharing_report_from_Dashboards_app
---

# Sharing a dashboard via an email report from the Dashboards app

To learn how to share a dashboard as an email report in the Dashboards app, you can follow the steps below or watch this short video:

<div style="width: 100%; max-width: 800px;">
  <video style="width: 100%; aspect-ratio: 16 / 9; height: auto;" controls>
    <source src="~/dataminer/images/Sharing_a_dashboard.mp4" type="video/mp4">
  </video>
</div>

*Watch first: [Creating your first dashboard](xref:Creating_a_completely_new_dashboard)*

*Watch next: [Creating a scheduled task to send reports](xref:Manually_adding_a_scheduled_task)*

## [From DataMiner 10.3.0 [CU12]/10.4.3 onwards](#tab/tabid-1)

1. In the list of dashboards on the left, select the dashboard you want to share<!--RN 38278-->.

1. Click the ... button in the top-right corner of the dashboard, and select *Share*.

   > [!NOTE]
   > From DataMiner 10.2.12/10.3.0 onwards, the *Share* button is only available in read mode.

1. Click *Email report*.

1. Specify the email address of at least one recipient in the *To*, *CC*, and/or *BCC* box.

   Prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!--RN 43848-->, all recipients need to be present in your contact list, and you need to specify at least one *To* recipient. Optionally, specify additional addresses in the *CC* and *BCC* boxes.

1. In the *Subject* box, specify the subject for the email.

1. Optionally, in the *Message* box, add the message body for the email.

1. From DataMiner 10.6.0/10.6.1 onwards<!--RN 43887 + 43888-->, you can select one of the following formats for the report, depending on the components in the dashboard:

   - **PDF**: `<dashboard name>.pdf` will be included as an attachment.

   - **Non-interactive HTML**: `<dashboard name>.mhtml` will be included as an attachment.

     This format bundles everything required for browser rendering, including the HTML code, images, and CSS stylesheets.

   - **CSV**: `<dashboard name>.csv.zip` will be included as an attachment.

     - This option is only available if the dashboard contains at least one supported component: a line & area chart, pivot table, or table component.

     - The zip file contains a separate CSV file for each supported component.

   In earlier DataMiner versions, reports are generated in PDF format by default, but if the dashboard contains a line & area chart, pivot table, or table component, you can select the **Include CSV** option to include a CSV file for each supported component.

1. Optionally, specify the following options:

   - *Report title*: Specify the title for the report.

   - *Add DMS info*: Select this option to include your company details in the report.

   - *Add DMS logo*: Select this option to display the company logo in the report.

   - *Page numbers*: Select this option to display page numbers in the report.

   - *Stack components*: Select this option if you want all components to be displayed below one another. This can be especially useful for dashboards containing large components (e.g. pivot tables) in order to make sure all data is displayed.

   - *Landscape*: Available from DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43826-->. Select this option to generate the report in landscape mode.

   - *Paper format*: Allows you to select a different format than the default A4 format for the report.

1. When everything has been configured, at the top, click *Send*.

## [Prior to DataMiner 10.3.0 [CU12]/10.4.3](#tab/tabid-2)

1. In the list of dashboards on the left, select the dashboard you want to share.

1. Click the ... button in the top-right corner of the dashboard, and select *Share*.

   > [!NOTE]
   > From DataMiner 10.2.12/10.3.0 onwards, the *Share* button is only available in read mode.

1. Click *Email report*.

1. In the *To* box, specify the email address(es) you want to send the PDF report to.

1. Optionally, specify additional addresses in the *CC* box, and/or click *Add BCC* to add additional addresses in the *BCC* box.

1. In the *Subject* box, specify the subject for the email.

1. Optionally, in the *Message* box, add the message body for the email.

1. To include a CSV file for each component of the dashboard, select *Include CSV*. This is only supported for specific components, such as the line graph, pivot table, and table component.

1. Optionally, expand the *Report* section to specify the following options:

   - *Add info*: Select this option to include your company details in the report.

   - *Add logo*: Select this option to display the company logo in the report.

   - *Page numbers*: Select this option to display page numbers in the report.

   - *Stack components*: Select this option if you want all components to be displayed below one another. This can be especially useful for dashboards containing large components (e.g. pivot tables) in order to make sure all data is displayed.

   - *Paper format*: Allows you to select a different format than the default A4 format for the PDF.

1. When everything has been configured, click *Send*.

***

> [!NOTE]
> From DataMiner 10.2.2/10.2.0 onwards, you can generate a report in the Dashboards app if the *ReportsAndDashboardsExport* [soft-launch option](xref:SoftLaunchOptions) is activated. From DataMiner 10.2.12/10.3.0 onwards, this feature is fully available.
