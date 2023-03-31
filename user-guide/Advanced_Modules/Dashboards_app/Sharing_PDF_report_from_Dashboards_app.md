---
uid: Sharing_PDF_report_from_Dashboards_app
---

# Sharing a dashboard as a PDF report from the Dashboards app

> [!NOTE]
> From DataMiner 10.2.2/10.2.0 onwards, you can generate a PDF report in the Dashboards app if the *ReportsAndDashboardsExport* [soft-launch option](xref:SoftLaunchOptions) is activated. From DataMiner 10.2.12/10.3.0 onwards, this feature is fully available.

To share a dashboard as a PDF report in the Dashboards app:

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

1. When everything has been configured, at the top, click *Send*.
