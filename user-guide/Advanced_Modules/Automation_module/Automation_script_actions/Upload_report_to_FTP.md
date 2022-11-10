---
uid: Upload_report_to_FTP
---

# Upload report to FTP

Use this action to upload a report to an FTP server:

1. In the *IP address/host* field, enter the hostname or IP address of the FTP server.

1. Optionally, enter the port in the *Port* field.

1. In the *Folder path* field, enter the path of the folder where the report should be uploaded.

1. In the *User name* and *Password* fields, enter the credentials to connect to the FTP server.

1. To upload the report in PDF format, instead of the default MHT format, next to *Format*, select *PDF*.

1. Optionally, in the *Report name prefix* field, specify a prefix for the report name. This can for instance be the name of the DMA, or the location where an issue occurs.

1. Click the field next to *Report* and select a report template or dashboard, then specify any elements or other required input.

   > [!NOTE]
   >
   > - If you want to specify multiple indices for one table parameter, use a semicolon “;” as separator.
   > - From DataMiner 9.6.13 onwards, you can select to include a dashboard from the new Dashboards app. The dashboards are listed in the drop-down list along with the reports. The icon in front of each item in the list shows whether the item is a dashboard or a report. From DataMiner 10.0.13 onwards, a *Configure* button is available that allows you to further configure a report based on a dashboard. See [Generating a PDF report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).
