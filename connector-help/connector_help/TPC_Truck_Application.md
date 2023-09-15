---
uid: Connector_help_TPC_Truck_Application
---

# TPC Truck Application

The TPC Truck Application is an application that helps the user to navigate, investigate, validate and troubleshoot IP flows inside the full IP truck.

## About

The application comes with an interactive Visio drawing. You need this drawing in order to be able to use the application.

The visual page of the element is the main page to be used for the application. The data pages contain settings for the configuration of the application.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | Yes                 | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

As the source file for this application is an Excel sheet, the Microsoft Access Database Engine 2010 has to be installed on the DataMiner server (see <https://www.microsoft.com/en-us/download/details.aspx?id=13255>).

In addition, some parameters need to be configured on the data pages of the element, i.e. the **Import Excel File Path** and **Excel File Name (Xls, Xlsx)**. Once these have been configured, the **Import** button allows you to load the file into DataMiner so that all the information from the file is stored in the element data.

Finally, element references are needed in order for the truck app to calculate the whole flow. The following element references are required:

- Arista Main & Backup elements
- Audio Arista Main & Backup elements
- Main & Backup Wireshark capture elements
- SFlow Manager

## Usage

### Source Selection

On the left, you can select the source. There are two ways of narrowing down the flows:

- Family-based: Select a family filter and select one of the linked groups.
- Device-based: Select a device and then select one of the groups this device is part of.

When you have selected the group, you can load the lists of flows by clicking the **Fetch Flows** button at the bottom.

Flow analysis can be started based on the selected group. An interactive Automation script will be launched when the **Flow Analysis button** is clicked. This will allow you to configure PRISM and start live Wireshark captures.

### Incoming Flows

When an incoming flow is selected, you can start flow analysis by clicking the **Flow Analysis button**.

The related element will be visualized with its state and the ability to navigate to the element.

The linked source connected with this incoming flow will be extracted from the VSM matrix.

The source information (originally coming from the Excel sheet) will be displayed below the selection.

In case the source element is an SNP, configuration validation will be performed and markers will become visible. (Excel sheet data for this source is compared with the live settings on the element).

### Outgoing Flows

When an outgoing flow is selected, you can start flow analysis via the **Flow Analysis button**.

The source details will be visualized and in case the source element is an SNP, configuration validation will be performed and markers will become visible. (Excel sheet data for this source is compared with the live settings on the element.)

When an outgoing flow is selected, you can load the receivers from VSM and perform SFlow checks via the **Fetch** **Receivers button**.

### Arista Switches / Sflow

DCF is used to find the Arista interfaces linked to the source element that was selected via the outgoing flow. The interface name, RX and TX rates are displayed along with generic parameters of the Arista elements.

SFlow monitoring is initiated when you press the **Fetch Receivers** **button**. The Truck Application will then check if the multicast and ANC addresses are detected in the SFlow packets.
A green or red indicator will show the result. To view extra details, open the **Sflow Details** pop-up window.

The **Egress Flows** pop-up window is a direct view on the linked Arista element and shows the **IGMP Snooping Table**. Filter buttons with the MC and ANC addresses are available at the top.

### Receivers

All receivers that are linked with the outgoing flow are listed. This information comes from the VSM Matrix. There are two ways of visualizing the receivers:

- **Tiles**: A quick overview of the receivers is visualized.
- **Table**: A list of all the receivers is displayed. You can copy values or export the table data via the context menu.

There is a slider control available to toggle the data set between ***All*** and ***Configured Only***. *Configured Only* displays all receivers that are listed in VSM but where no active stream was detected.

The states are calculated via the IGMP Snooping tables from the linked Arista switches. DCF is used to find the interface link and check if the multicasts are sent to these interfaces.

The refresh button will refresh all checks as if you were to press the Fetch Receivers button.
