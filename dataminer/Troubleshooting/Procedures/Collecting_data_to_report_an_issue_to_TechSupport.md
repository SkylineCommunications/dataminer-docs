---
uid: Collecting_data_to_report_an_issue_to_TechSupport
description: To report an issue to DataMiner Tech Support, you will need a Log Collector package, as well as additional information depending on the issue.
---

# Collecting data to report an issue to Technical Support

The type of data required depends on the type of issue you are experiencing:

- For all issues: [Log Collector packages](#log-collector-packages)

- For Cube-related issues: [Cube Debug information](#cube-debug-information)

- For DataMiner web apps issues: [Web App recordings](#web-app-recordings)

- For element or service-related issues: [DELT export packages](#delt-export-packages)

- For element communication issues: [Stream Viewer traces](#stream-viewer-traces)

> [!TIP]
> See also: [Contacting DataMiner Support](xref:Contacting_tech_support)

## Log Collector packages

A Log Collector package provides comprehensive information about the DataMiner System, including software version, cluster composition, network and database statistics, and more. Even if the Log Collector package contains no errors, this can be valuable information, helping Technical Support verify that the DataMiner core logic is functioning correctly, and the issue lies elsewhere.

To save a Log Collector package:

1. Connect to the DataMiner server using Remote Desktop.

1. Right-click the DataMiner Taskbar Utility icon and select *Launch > Tools > Log Collector*

   ![Log Collector](~/dataminer/images/LogCollector.png)

   > [!NOTE]
   > If the DataMiner Taskbar Utility icon is missing from the taskbar, or if the Log Collector option is not present in the dropdown list, you can manually find the `C:\Skyline DataMiner\Tools\SLLogCollector\SL_LogCollector.exe` file or download it from [DataMiner Dojo](https://community.dataminer.services/download/sllogcollector/).

1. In the *DataMiner Log Collector* pop-up window, select *Start* in the lower-right corner.

   > [!NOTE]
   > If you want a memory dump to be saved, before starting the log collection, first select the checkbox next to *Include memory dump* and choose the required process(es) from the list. In the case of a runtime error, the necessary processes are selected automatically.
   >
   > ![Include memory dump](~/dataminer/images/Include_Memory_Dump.png)<br/>*DataMiner Log Collector version 10.3.2330.1610*

The Log Collector package will be saved by default in an *SL_LogCollector* folder on your desktop. Please do not rename or modify any of the files.

> [!TIP]
> For more information about the Log Collector, see [SLLogCollector](xref:SLLogCollector).

## Cube debug information

When investigating issues related to DataMiner Cube, Cube debug information is invaluable. The way you can access this information depends on whether Cube is able to connect to your DMA.

### Cube is connected to your DMA

#### Exporting Cube debug info

If Cube is connected to your DMA, export Cube debug information as follows:

1. In DataMiner Cube, go to *Apps* > *About*.

1. In the *general* tab, select *Export debug information*.

   ![Export debug information](~/dataminer/images/Debug_information.png)<br/>*DataMiner Cube version 10.3.10*

#### Following the Cube session

In some cases, it may be necessary to follow an ongoing Cube session to get more information. This is sometimes called a "Cube follow".

To do so, you will need to use SLNetClientTest tool. For detailed information, refer to [Following a DataMiner Cube session](xref:SLNetClientTest_tracking_dma_communication#following-a-dataminer-cube-session).

### Cube is unable to connect to your DMA

#### Exporting Cube debug info

If Cube is unable to connect to your DMA, export Cube debug information as follows:

1. On the login page, click the cogwheel button in the lower-right corner and select *About* in the menu.

   ![Login page](~/dataminer/images/Login_Screen.png)<br/>*DataMiner Cube version 10.3.10*

1. In the *general* tab, select *Export debug information*.

#### Investigating the connection issue

You should also collect information to investigate why Cube could not connect to your DMA:

1. Go to the DataMiner Cube start window, click the cogwheel button in the lower-right corner, and select *View logging*.

   ![View Logging](~/dataminer/images/View_Logging.png)<br/>*DataMiner Cube version 10.3.10*

1. In the *Logs* folder, find the file named corresponding to the current date, e.g., `log20230904.txt` for September 4th, 2023.

## Web app recordings

For troubleshooting issues related to DataMiner web apps, such as DataMiner Dashboards, the Monitoring app, and DataMiner Low-Code Apps, we recommend using the **DataMiner Web Support Assistant browser extension**. This extension is available for Google Chrome or any Chromium-based browser.

For information about how to install the extension and create a recording with it, refer to [Web Support Assistant](xref:Web_Issues_Support_Assistant).

## DELT export packages

When investigating issues related to a specific element or service, DELT (DataMiner Element Location Transparency) export packages are invaluable sources of information. This functionality allows you to export and import elements, services, and more to/from a *.dmimport* file.

To export an element or service, refer to [Exporting elements, services, etc. to a .dmimport file](xref:Exporting_elements_services_etc_to_a_dmimport_file).

Note that unless otherwise requested, we recommend **not including trend data, alarm data, documents, and information events** in the export to reduce the package size and export time.

> [!TIP]
> For more information on DELT export and import packages, see [Exporting and importing packages on a DMA](xref:Exporting_and_importing_packages_on_a_DMA).

## Stream Viewer traces

Stream Viewer captures communication between the DMA and the monitored device.

To save a Stream Viewer trace:

1. Right-click the element in the Surveyor or open the element card's hamburger menu.

1. In the context menu or header menu, select *View > Stream Viewer*.

   ![Stream Viewer](~/dataminer/images/Stream_Viewer.png)<br/>*DataMiner Cube version 10.3.10*

1. In the *Stream Viewer* window, select *Sniffer*.

1. In the *Stream Sniffer* pop-up window, specify the output location and capture duration, and click *Start*.

   ![Stream Sniffer](~/dataminer/images/Stream_Sniffer.png)<br/>*DataMiner Cube version 10.3.10*

> [!NOTE]
>
> - We recommend setting the capture duration to 5 minutes.
> - Closing the *Stream Sniffer* and *Stream Viewer* windows will not interrupt the capture. However, closing or disconnecting Cube will stop the capture.
