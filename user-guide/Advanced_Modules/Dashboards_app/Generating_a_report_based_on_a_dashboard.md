---
uid: Generating_a_report_based_on_a_dashboard
---

# Generating a report based on a dashboard]

## [Sharing a dashboard as PDF report in DataMiner Cube](#tab/tabid-1)

In the Automation, Correlation and Scheduler modules, you can generate a report based on a dashboard. See [Sending an email](xref:Sending_an_email) (Correlation), [Email](xref:Email), [Upload report to FTP](xref:Upload_report_to_FTP) and [Upload report to shared folder](xref:Upload_report_to_shared_folder) (Automation), and [Manually adding a scheduled task](xref:Manually_adding_a_scheduled_task).

When you do so, from DataMiner 10.0.13 onwards, a *Configure* button is available. Clicking this button opens a pop-up window where you can configure the report.

- At the top of the window, the link to the dashboard is displayed. Two icons next to this link allow you to copy it or browse to it, respectively.

- Via *Options*, at the top of the window, you can configure these general settings for the report:

  - *Add DMS info*: Select this option to include your company details in the report.

  - *Add DMS logo*: Select this option to display the company logo in the report.

    > [!NOTE]
    > To check your company details and logo in DataMiner Cube, go to System Center \> *Agents* > *System*.

  - *Include CSV*: Includes a CSV file for each component of the dashboard. Only supported for specific components, such as the line graph, pivot table, and table component. Available from DataMiner 10.2.0/10.1.7 onwards.

  - *Include feeds*: Select this option to also include feed components in the report.

  - *Stack components*: Select this option if you want all components to be displayed below one another. This can be especially useful for dashboards containing large components (e.g. pivot tables) in order to make sure all data is displayed.

  - *Dashboard width*: Allows you to select a custom width for the report.

- Below this, the dashboard is displayed. If any data feeds should be specified for the report, you can do so here.

- When the report is fully configured, click *Save & close*.

> [!NOTE]
> - By design, the following components are not included in reports: button panel (soft launch), map and web components.
> - If access to a dashboard is limited to some users only, this dashboard will not be available to generate reports from DataMiner Cube.

## [Sharing a dashboard as PDF report in Dashboards app](#tab/tabid-2)

To share a dashboard as a PDF report in the Dashboards app (from DataMiner 10.2.0/10.2.2 onwards):

1. In the list of dashboards on the left, select the dashboard you want to share.

1. Click the ... button in the top-right corner of the dashboard, and select *Share*.

   > [!NOTE]
   > From DataMiner 10.3.0 onwards, the *Share* button is only available in read mode.

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
