---
uid: Collecting_data_to_report_an_issue_to_TechSupport
---

# Collecting data to report an issue to Technical Support

The type of data required depends on the type of issue you are experiencing:

- For all issues: [Log Collector packages](#log-collector-packages)

- For Cube-related issues: [Cube Debug information](#cube-debug-information)

- For element or service-related issues: [DELT export packages](#delt-export-packages)

- For element communication issues: [Stream Viewer traces](#stream-viewer-traces)

## Log Collector packages

A Log Collector package provides comprehensive information about the DataMiner System, including software version, cluster composition, network and database statistics, and more. Even if the Log Collector package contains no errors, this can be valuable information, helping Technical Support verify that the DataMiner core logic is functioning correctly, and the issue lies elsewhere.

To save a Log Collector package:

1. Connect to the DataMiner server using Remote Desktop.

1. Right-click the DataMiner Taskbar Utility icon and select *Launch > Tools > Log Collector*

   ![Log Collector](~/user-guide/images/LogCollector.png)

   > [!NOTE]
   > If the DataMiner Taskbar Utility icon is missing from the taskbar, or if the Log Collector option is not present in the dropdown list, you can manually find the *C:\Skyline DataMiner\Tools\SLLogCollector\SL_LogCollector.exe* file or download it from [DataMiner Dojo](https://community.dataminer.services/download/sllogcollector/).

1. In the *DataMiner Log Collector* pop-up window, select *Start* in the lower right corner.

   > [!NOTE]
   > If you want a memory dump to be saved, before starting the log collection, first select the checkbox next to *Include memory dump* and choose the required process(es) from the list. In the case of a run-time error, the necessary processes are selected automatically.
   >
   > ![Include memory dump](~/user-guide/images/Include_Memory_Dump.png)<br/>*DataMiner Log Collector version 10.3.2330.1610*

1. The Log Collector package will be saved by default in an *SL_LogCollector* folder on your desktop.

> [!TIP]
> For more information about the Log Collector, see [SLLogCollector](xref:SLLogCollector).

## Cube Debug information

When investigating issues related to DataMiner Cube, Cube Debug information is invaluable. You can access this information either through DataMiner Cube when Cube is connected to your DMA or via the Cube login page when Cube cannot connect to your DMA.

### Cube is connected to your DMA

To export Cube debug information:

1. In DataMiner Cube, go to *Apps* > *About*.

1. In the *general* tab, select *Export debug information*.

![Export debug information](~/user-guide/images/Debug_information.png)<br/>*DataMiner Cube version 10.3.10*

### Cube is unable to connect to your DMA

To export Cube debug information:

1. On the login page, click the cogwheel button in the lower right corner and select *About* in the menu.

   ![Login page](~/user-guide/images/Login_Screen.png)<br/>*DataMiner Cube version 10.3.10*

1. In the *general* tab, select *Export debug information*.

To investigate why Cube could not connect to your DMA:

1. Go to the DataMiner Cube start window, click the cogwheel button in the lower right corner, and select *View logging*.

![View Logging](~/user-guide/images/View_Logging.png)<br/>*DataMiner Cube version 10.3.10*

1. In the *Logs* folder, find the file named corresponding to the current date, e.g. `log20230904.txt` for September 4th, 2023.

## DELT export packages

When investigating issues related to a specific element or service, DELT (DataMiner Element Location Transparency) export packages are invaluable sources of information. This functionality allows you to export and import elements, services, and more to/from a *.dmimport* file.

> [!TIP]
> For more information on DELT export and import packages, see [Exporting and importing packages on a DMA](xref:Exporting_and_importing_packages_on_a_DMA).

To export an element or service:

1. In the Surveyor, right-click the item and select *Actions > Export*.

   ![Export element](~/user-guide/images/Export_Element.png)<br/>*DataMiner Cube version 10.3.10*

1. In the *Export* pop-up window, choose *Export to DataMiner package (\*.dmimport)*.

1. Select the items you want to export. If you have selected to include a service, any elements within that group will automatically be included in the export. Similarly, if you have selected an SLA, the SLA service and its service children will automatically be included.

1. Specify which additional information should be included (if any) using the checkboxes below this:

   - Trend and alarm data

   - Documents

   - Information events

   Unless requested otherwise, we recommend disabling these options to reduce the package size and export time.

1. Select *Export* in the lower right corner.

   ![Exporting an SLA](~/user-guide/images/SLA_Export.png)<br/>*DataMiner Cube version 10.3.10*

   > [!IMPORTANT]
   > If the export fails due to package size, consider excluding trend and alarm data. Also, try connecting directly to the DMA hosting the item to be exported.

## Stream Viewer traces

Stream Viewer captures communication between the DMA and the monitored device.

To save a Stream Viewer trace:

1. Right-click the element in the Surveyor or open the element card's hamburger menu.

1. In the context menu or header menu, select *View > Stream Viewer*.

   ![Stream Viewer](~/user-guide/images/Stream_Viewer.png)<br/>*DataMiner Cube version 10.3.10*

1. In the *Stream Viewer* window, select *Sniffer*.

1. In the *Stream Sniffer* pop-up window, specify the output location and capture duration, and click *Start*.

   ![Stream Sniffer](~/user-guide/images/Stream_Sniffer.png)<br/>*DataMiner Cube version 10.3.10*

   > [!NOTE]
   >
   > - We recommend setting the capture duration to 5 minutes.
   > - Closing the *Stream Sniffer* and *Stream Viewer* windows will not interrupt the capture. However, closing or disconnecting Cube will stop the capture.
