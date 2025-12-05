---
uid: Upload_report_to_shared_folder
---

# Upload report to shared folder

Use this action to upload a report to a shared network folder:

1. In the *IP address/host* field, enter the hostname or IP address of the server.

1. In the *Folder path* field, enter the path of the folder where the report should be uploaded.

   > [!NOTE]
   > Make sure the path uses the format specified by the Universal Naming Convention (UNC). See [UNC paths](https://learn.microsoft.com/en-us/dotnet/standard/io/file-path-formats#unc-paths).

1. In the *Domain\\User name* and *Password* fields, enter the credentials to connect to the server.

1. To upload the report in PDF format, instead of the default MHT format, next to *Format*, select *PDF*.

1. Optionally, in the *Report name prefix* field, specify a prefix for the report name. This can for instance be the name of the DMA, or the location where an issue occurs.

1. Click the field next to *Report* and select a report template or dashboard, then specify any elements or other required input.

   > [!NOTE]
   >
   > - If you want to specify multiple indices for one table parameter, use a semicolon ";" as separator.
   > - If you want to specify multiple parameters for one element, service, or protocol version, assign them all within a single line.
   > - Dashboards are listed in the dropdown list along with the reports. The icon in front of each item in the list shows whether the item is a dashboard or a report. With the *Configure* button, you can further configure a report based on a dashboard. See [Generating a report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).
   > - Private dashboards will not appear in the dropdown list, as they cannot be shared. You can edit access to dashboards in the [dashboard settings](xref:Configuring_dashboard_security).

## Examples

### Example 1

User *JohnDoe*, belonging to the *BROADCAST* domain, wants a scheduled task to upload a report or dashboard named *Versions* to a folder on the server *DMAServer01* (`C:/Users/JohnDoe/Reports`).

The folder path must be converted to a UNC path, `C$\Users\JohnDoe\Reports`, as shown in the image below.

![example 1 configuration](~/dataminer/images/Upload_to_shared_folder1.png)<br>
*Configuration in DataMiner Cube (version 10.3.9)*

### Example 2

A user wants to upload a report or dashboard to a folder on the *F:* disk of a server with IP *10.200.10.20* (`F:/Reports`), using an *Administrator* account.

![example 2 configuration](~/dataminer/images/Upload_to_shared_folder2.png)<br>
*Configuration in DataMiner Cube (version 10.3.9)*
