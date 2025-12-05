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
   > - If you want to specify multiple indices for one table parameter, use a semicolon ";" as separator.
   > - If you want to specify multiple parameters for one element, service, or protocol version, assign them all within a single line.
   > - Dashboards are listed in the dropdown list along with the reports. The icon in front of each item in the list shows whether the item is a dashboard or a report. With the *Configure* button, you can further configure a report based on a dashboard. See [Generating a report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).
   > - Private dashboards will not appear in the dropdown list, as they cannot be shared. You can edit access to dashboards in the [dashboard settings](xref:Configuring_dashboard_security).

## Example

A user wants to upload a report or dashboard named *Versions* to the root folder of an FTP server with IP *10.200.10.20* (port 21), using the credentials of the user *JohnDoe*. This is configured as follows:

![Upload report to FTP](~/dataminer/images/Upload_to_FTP.png)<br>
*Configuration in DataMiner Cube (version 10.3.9)*
