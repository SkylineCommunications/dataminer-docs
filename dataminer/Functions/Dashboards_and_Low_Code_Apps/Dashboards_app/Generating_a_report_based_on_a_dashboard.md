---
uid: Generating_a_report_based_on_a_dashboard_Cube
---

# Generating a report based on a dashboard using DataMiner Cube

In the Automation, Correlation, and Scheduler modules, you can generate a report based on a dashboard. See [Sending an email](xref:Sending_an_email) (Correlation), [Email](xref:Email), [Upload report to FTP](xref:Upload_report_to_FTP) and [Upload report to shared folder](xref:Upload_report_to_shared_folder) (Automation), and [Manually adding a scheduled task](xref:Manually_adding_a_scheduled_task).

When you do so, you can click the *Configure* button to open a window where you can configure the report:

- At the top of the window, the link to the dashboard is displayed, with the following icons next to it:

  - ![Edit URL](~/dataminer/images/Report_EditURL.png): Available from DataMiner web 10.5.0 [CU10]/10.6.1 onwards, with a minimum server version of 10.6.0/10.6.1<!--RN 43887 + 43888-->. Opens a pop-up allowing you to view and modify the dashboard URL configuration in JSON format.

  - ![Reload dashboard](~/dataminer/images/Report_ReloadDashboard.png): Available from DataMiner web 10.5.0 [CU10]/10.6.1 onwards, with a minimum server version of 10.6.0/10.6.1<!--RN 43887 + 43888-->. Reloads the dashboard.

  - ![Copy URL](~/dataminer/images/Report_Copy.png): Copies the dashboard URL to your clipboard.

  - ![Browse to URL](~/dataminer/images/Report_BrowseToURL.png): Opens the dashboard URL in your browser.

- In the pane to the right, you can configure general settings for the report. Prior to DataMiner 10.5.0 [CU10]/10.6.1<!--RN 43887 + 43888-->, these settings are available via *Options*, at the top of the window.

  - *Data*: From DataMiner web 10.5.0 [CU10]/10.6.1 onwards, with a minimum server version of 10.6.0/10.6.1<!--RN 43887 + 43888-->, you can choose the report format. In earlier versions, the report is always generated as a PDF. Depending on the components in the dashboard, the following formats may be available:

    - **PDF**: `<dashboard name>.pdf` will be included as an attachment.

    - **Non-interactive HTML**: `<dashboard name>.mhtml` will be included as an attachment.

      This format bundles everything required for browser rendering, including the HTML code, images, and CSS stylesheets.

    - **CSV**: `<dashboard name>.csv.zip` will be included as an attachment.

      - This option is only available if the dashboard contains at least one supported component: a line & area chart, pivot table, or table component.

      - The zip file contains a separate CSV file for each supported component.

  - *Report title*: Specify the title for the report. Available from DataMiner web 10.5.0 [CU10]/10.6.1 onwards<!--RN 43887 + 43888-->.

  - *Add DMS info*: Select this option to include your company details in the report.

  - *Add DMS logo*: Select this option to display the company logo in the report.

    > [!NOTE]
    > To check your company details and logo in DataMiner Cube, go to System Center \> *Agents* > *System*.

  - *Include CSV*: Available up to DataMiner web 10.5.0 [CU9]/10.5.12. Includes a CSV file for each component of the dashboard. Only supported for specific components, such as the line graph, pivot table, and table component.

  - *Page numbers*: Select this option to display page numbers in the report. Available from DataMiner web 10.5.0 [CU10]/10.6.1 onwards<!--RN 43887 + 43888-->.

  - *Include controls*: Select this option to include certain components in the report.

  - *Stack components*: Select this option if you want all components to be displayed below one another. This can be especially useful for dashboards containing large components (e.g. pivot tables) in order to make sure all data is displayed.

  - *Dashboard width*: Allows you to select a custom width for the report.

  - *Orientation*: Select whether you want the report to be generated in portrait or landscape mode respectively. Available from DataMiner web 10.5.0 [CU10]/10.6.1 onwards<!--RN 43887 + 43888-->.

  - *Paper format*: Select a different format than the default A4 format for the report.

- In the main pane, the dashboard is displayed. If any data should be specified for the report, you can do so here.

- When the report is fully configured, click *Save & close*.

> [!NOTE]
>
> - By design, the following components are not included in reports: button panel, map, and web components.
> - Prior to DataMiner 10.5.10/10.6.0<!-- RN 43393+43394+43570 -->, if access to a dashboard is limited to some users only, this dashboard will not be available to generate reports from DataMiner Cube. In later DataMiner versions, you can use such private dashboards to generate reports, but only if you have access to them.
