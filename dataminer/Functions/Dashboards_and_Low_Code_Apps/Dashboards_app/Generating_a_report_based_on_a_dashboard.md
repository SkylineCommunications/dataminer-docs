---
uid: Generating_a_report_based_on_a_dashboard_Cube
---

# Generating a PDF report based on a dashboard using DataMiner Cube

In the Automation, Correlation, and Scheduler modules, you can generate a report based on a dashboard. See [Sending an email](xref:Sending_an_email) (Correlation), [Email](xref:Email), [Upload report to FTP](xref:Upload_report_to_FTP) and [Upload report to shared folder](xref:Upload_report_to_shared_folder) (Automation), and [Manually adding a scheduled task](xref:Manually_adding_a_scheduled_task).

When you do so, you can click the *Configure* button to open a window where you can configure the report:

- At the top of the window, the link to the dashboard is displayed. Two icons next to this link allow you to copy it or browse to it, respectively.

- Via *Options*, at the top of the window, you can configure these general settings for the report:

  - *Add DMS info*: Select this option to include your company details in the report.

  - *Add DMS logo*: Select this option to display the company logo in the report.

    > [!NOTE]
    > To check your company details and logo in DataMiner Cube, go to System Center \> *Agents* > *System*.

  - *Include CSV*: Includes a CSV file for each component of the dashboard. Only supported for specific components, such as the line graph, pivot table, and table component. Available from DataMiner 10.2.0/10.1.7 onwards.

  - *Include controls*: Select this option to include certain components in the report.

  - *Stack components*: Select this option if you want all components to be displayed below one another. This can be especially useful for dashboards containing large components (e.g. pivot tables) in order to make sure all data is displayed.

  - *Dashboard width*: Allows you to select a custom width for the report.

- Below this, the dashboard is displayed. If any data should be specified for the report, you can do so here.

- When the report is fully configured, click *Save & close*.

> [!NOTE]
>
> - By design, the following components are not included in reports: button panel, map, and web components.
> - Prior to DataMiner 10.4.0 [CU19]/10.5.0 [CU7]/10.5.10<!-- RN 43394+43570 -->, if access to a dashboard is limited to some users only, this dashboard will not be available to generate reports from DataMiner Cube. In later DataMiner versions, you can use such private dashboards to generate reports, but only if you have access to them.
