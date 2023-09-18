---
uid: Connector_help_Skyline_Flow_Tracking
---

# Skyline Flow Tracking

The Skyline Flow Tracking application is an investigation support tool for multicast flow tracking. The purposed-designed app uses the Nevion Video iPath as SDN controller and is compatible with CISCO switches to represent the switch fabric.

The framework of the application is generic and may be extended to supported other SDN controllers and switches. Any edge device can be made compatible, as long as the multicast address can be found and mapped to the correct DCF interface.

The main goal of the application is to support IP troubleshooting investigations via DataMiner. When a certain multicast is not being received at the edge device, you can use this tool to analyze where the signal goes missing.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                                                               | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version.<br>- Supported SDNC: Nevion Video iPath.<br>- Supported switch fabric: CISCO Manager.<br>- Supported edge devices: Any connectors that have the "**MC**" property on the physical DCF interfaces populated with a semi-colon-separated list of multicast addresses for that interface. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                 | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | [Nevion Video iPath](xref:Connector_help_Nevion_Video_iPath)<br>[CISCO Manager](xref:Connector_help_CISCO_Manager) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the **Configurations** page, configure the **Processing Interval** to define how fast the data should be fetched from the configured SDN controllers.

To define one or more SDN controllers to sync with the application, go to the **SDNC Configurations** subpage of the Configurations page. Use the right-click menu to add or remove SDN controllers as needed.

On the **Device Mapping** subpage of the Configurations page, you can specify the DCF interface mapping for all edge device types. Use the right-click menu to add or remove edge connector types as needed. The goal of this mapping is to match the interface names defined in the SDN controller with the DCF interface names present on the DataMiner elements via the respective edge device connectors. When you define multiple mapping replacement pairs, delimit these using a semicolon (";"). Each replacement pair must consist of two subparts delimited by four ampersand symbols: "**\<RegexFilter\>&&&&\<StringFormat\>**":

- \<RegexFilter\>: This should be the regex filter to match the received interface format of the SDN controller. Using regex capturing groups (by using parentheses "(" ")"), you can define dynamic parts.
- \<StringFormat\>: This format will be used to output the converted interface name. This converted name will be used to check if it matches the actual DCF interface name on the endpoint of the hop. The format of this stringFormat is custom text with curly braces to allow dynamic parts: "aa{0}bb{1}cc".

Example of a replacement pair: **Eth(.\*) .\*&&&&Interfaces Ethernet{0}**
With this example, DCF interface name "Eth1/3/1 (in)" will be translated to "Interfaces Ethernet1/3/1".

## How to use

When you launch the application, it will list all services (i.e. all crosspoints) that are populated by the configured SDN controllers in the app. Multiple SDN instances can be linked to this same application.

Metadata is present to show the service state, start and end timing, multicast IPs, tags and more.

You can **quick-filter** **on** **tags** (e.g. Audio, Video, Data, etc.). The standard table filtering is also available to filter on any other metric listed.

When a service has been selected, you can start the analysis by clicking the **Show Edges** button at the bottom of the application. This will open a pop-up window.

### Service Info

During an investigation of a selected service, this page will show a summary of all the details originating from the SDN controller.

### SDP

The full URLs of the **sender** and **receiver SDP data files** on NMOS are available to browse. An inline version is also shown directly in Visual Overview. Here you can verify the SDP data and compare sender and receiver side by side.

### SDNC Path

Here you will see the path of the service as defined by the SDN controller. DCF interface checks happen to verify if the multicast is found as expected on the interfaces mentioned by the SDN controller.

All the hops are displayed in table format. When you select a specific hop, more metadata will be displayed. When the source of a hop originates from the switch fabric, an inline filter view can be loaded to verify the **NBM flows** directly from the switch element card.

There are two subtabs for main and backup routes. In addition, the aggregated service path state for all paths is shown. (**Green marker**: All multicasts are found where expected. **Red marker**: One or more multicasts are not found where expected.)

### Node Edge Main & Backup

This inline view of the **node edge graph** dashboard component is filtered on the main or backup multicast, depending on the respective tab page.

## Notes

The application is intended to be used through Visual Overview. Make sure the linked visual overview is enabled.

**Communication** between the application and data elements happens via IAC (Inter App Communication). As such, you will not be able to see any communication traffic in **Stream Viewer**.
