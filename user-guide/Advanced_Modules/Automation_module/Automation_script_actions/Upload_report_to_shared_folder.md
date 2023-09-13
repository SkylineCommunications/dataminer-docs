---
uid: Upload_report_to_shared_folder
---

# Upload report to shared folder

Use this action to upload a report to a shared network folder:

1. In the *IP address/host* field, enter the hostname or IP address of the server.

1. In the *Folder path* field, enter the path of the folder where the report should be uploaded. Please note that this path must be in the format specified by the Universal naming convention (UNC).

1. In the *Domain\\User name* and *Password* fields, enter the credentials to connect to the server.

1. To upload the report in PDF format, instead of the default MHT format, next to *Format*, select *PDF*.

1. Optionally, in the *Report name prefix* field, specify a prefix for the report name. This can for instance be the name of the DMA, or the location where an issue occurs.

1. Click the field next to *Report* and select a report template or dashboard, then specify any elements or other required input.

   > [!NOTE]
   >
   > - If you want to specify multiple indices for one table parameter, use a semicolon “;” as separator.
   > - If you want to specify multiple parameters for one element, service, or protocol version, assign them all within a single line.
   > - From DataMiner 9.6.13 onwards, you can select to include a dashboard from the new Dashboards app. The dashboards are listed in the drop-down list along with the reports. The icon in front of each item in the list shows whether the item is a dashboard or a report. From DataMiner 10.0.13 onwards, a *Configure* button is available that allows you to further configure a report based on a dashboard. See [Generating a PDF report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).

## Example configurations

**Example 1:** User _JohnDoe_, belonging to the _BROADCAST_ domain, wants their scheduled task to upload a report/dashboard named _Versions_ to a folder in server _DMAServer01_ (_C:/Users/JohnDoe/Reports_).

The folder path must be converted to a UNC path format: _C$\Users\JohnDoe\Reports_, as in the image below.

![image](https://github.com/SkylineCommunications/dataminer-docs/assets/121097704/19414799-d3b4-4e2b-a346-f323173343d6)

**Example 2:** A user wants to upload a report/dashboard to a folder in the _F:_ disk of a server with IP _10.200.10.20_ (_F:/Reports_), using an _Administrator_ account.

![image](https://github.com/SkylineCommunications/dataminer-docs/assets/121097704/7936a6bd-4899-48b8-8498-468ac56d9934)


