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

A Log Collector package provides comprehensive information about the DataMiner System, including software version, cluster composition, network and database statistics, and more. Even if the Log Collector package appears empty, it can be valuable information, helping Technical Support verify that the DataMiner core logic is functioning correctly, and the issue lies elsewhere.

To save a Log Collector package:

1. Connect to the DataMiner server using Remote Desktop.

1. Run the Log Collector tool by following the steps in [SLLogCollector](xref:SLLogCollector).

1. The Log Collector package is saved by default in an *SL_LogCollector* folder on your desktop.

## Cube Debug information

### Cube is connected to your DMA

1. In DataMiner Cube, go to *Apps* > *About*.

1. In the *general* tab, select *Export debug information*.

### Cube is unable to connect to your DMA

1. On the login page, click the cogwheel button in the lower right corner and select *About* in the menu.

1. In the *general* tab, select *Export debug information*.

> [!NOTE]
> To investigate why Cube could not connect to your DMA, go to the DataMiner Cube start window, click the cogwheel button in the lower right corner, and select *View logging*. In the *Logs* folder, open the file named corresponding to the current date, e.g. `log20230904.txt` for September 4th, 2023.

## DELT export packages

When investigating issues related to a specific element or service, DELT (DataMiner Element Location Transparency) export packages are invaluable sources of information. This functionality allows you to export and import elements, services, and more to/from a *.dmimport* file.

- To export an element or service, follow the procedure in [Exporting elements, services, etc. to a .dmimport file](xref:Exporting_elements_services_etc_to_a_dmimport_file).

- To import an element or service, follow the procedure in [Importing elements, services, etc. from a .dmimport file](xref:Importing_elements_services_etc_from_a_dmimport_file).

## Stream Viewer traces

Stream Viewer captures communication between the DMA and the monitored device.

To save a Stream Viewer trace:

1. Open Stream Viewer as detailed in [Connecting to an element using Stream Viewer](xref:Connecting_to_an_element_using_Stream_Viewer).

1. In the *Stream Viewer* window, select *Sniffer*.

1. In the *Stream Sniffer* pop-up window, specify the output location and click *Start*.

> [!NOTE]
> Closing the *Stream Sniffer* and *Stream Viewer* window will not interrupt the capture. However, closing or disconnecting Cube will stop the capture.
