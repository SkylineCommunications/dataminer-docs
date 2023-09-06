---
uid: Connector_help_Miranda_Kaleido_IP_X320
---

# Miranda Kaleido IP X320

This driver supports the new iteration of the Miranda Kaleido IP device, namely the Miranda Kaleido IP X320. Hardware monitoring is the main new feature of this new device.

## About

The Kaleido IP X320 is an IP Video Multiviewer that is used to monitor and view local/remote IP multicast streams. By means of SNMP and serial communication, information is gathered and loaded into the driver. After a configuration file (.xls/.xlsx) has been supplied, a DataMiner element will keep track of the provisioned services. If enabled on the device, SNMP traps will be used to update the hardware status more efficiently.

### Ranges of the driver

| **Driver Range**     | **Based on** | **Description** |
|----------------------|--------------|-----------------|
| 1.0.0.x \[SLC Main\] | \-           | Initial version |

## Installation and configuration

### Creation

To create a new element, several ports will need to be configured. Most of the values are filled in by default, except for the IP address.

#### SNMP connections

This driver uses Simple Network Management Protocol (SNMP) connections and requires the following input during element creation:

SNMP CONNECTION (KaleidoK3):

- **IP address/host**: The polling IP of the device, e.g. *127.0.0.1.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

SNMP CONNECTION (IPMI):

- **IP address/host**: The polling IP of the device, e.g. *127.0.0.1.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

GSMALARM:

- **IP address/host**

GSMALARM Settings:

- **Port number**: The port of the connected device, by default 2*161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

#### Serial connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *127.0.0.1.*
- **IP port**: The port of the connected device, by default *13000*.
- **Timeout time**: The timeout of a single command in ms, by default *10000*.

### Configuration

To load the services that need to be monitored, an Excel file is required with a fixed format. Go to the **General** page and open the pop-up page **Load File**. Then specify the **File Path** and **File Name** of the Excel file, and finally click **Import**.

The Excel file should contain columns with the following headers:

- **Input ref ID**: SID
- **Input Service Name**
- **Input mon device**: The name of the device, which must equal the element's name. This way, one file can be used to configure any element.
- **Input mon device port**: A unique port number (mandatory, used as index).
- **Program number:** Mandatory.
- **Multicast**: Mandatory.
- **UDP Port**: Mandatory.
- **Output Service name**
- **Source Friendly Name**: To be provided when the source-friendly name is not of the format {multicast}\_{udp port}. Range 1.0.1.x only

Finally, go to the **Alarm Table** page and enable the alarm table polling if necessary.

## Usage

### General

This page displays basic information about the device. The **channel** and **layout** can also be set here.

The page also contains two page buttons:

- **Load File**: Opens the configuration file import window.

> To load the services that need to be monitored, an Excel file is required with a fixed format (.xls or .xlsx). Go to the **General** page and open the pop-up page **Load File**. Then specify the **File Path** and **File Name** of the file, and finally click **Import**.
>
> The Excel file should contain columns with the following headers:
>
> - **Input ref ID**: SID
> - **Input Service Name**
> - **Input mon device**: The name of the device, which must equal the element's name. This way, one file can be used to configure any element.
> - **Input mon device port**: A unique port number (mandatory, used as index).
> - **Program number**: Mandatory.
> - **Multicast**: Mandatory.
> - **UDP Port**: Mandatory.
> - **Output Service name**
> - **Source Friendly Name**: To be provided when the source-friendly name is not of the format {multicast}\_{udp port}. Range 1.0.1.x only
>
> Finally, go to the **Alarm Table** page and enable the alarm table polling if necessary.
>
> Note that the Transport Stream, Services, Teletext and Card health tables are filled via the imported Excel file, located in the folder indicated by the File Path parameter or in the element document folder. After these are filled in, the data is polled.

- **On-Air Services**: Opens a window where you can edit the on-air service times.

### Transport Stream

This page displays an overview of the transport streams, including status, TSID and an indication of whether the underlying services are on air.

### Services

This page displays all the services as specified in the configuration file. For each service, the alarm values are filled in in the columns, with the on-air status at the end. To prevent an overload of (irrelevant) data, not all possible alarm values are displayed.

### Teletext

This page displays the **Teletext Information Table**. This table contains the teletext alarm values, which have been separated from the services table.

### Card Health

This page displays another subset of the alarm table, with hardware information about the cards of the device.

### System

This page displays system and chassis information parameters related to IPMI interface.

### Temperature

On this page, you can find information about temperature sensors related to IPMI interface:

- CPU Temperature Sensors
- Memory Temperature Sensors
- Other Temperature Sensors

### Voltage

This page displays the power measurements and status related to IPMI interface:

- CPU Voltage Sensors
- Power Voltage Sensors
- Memory Voltage Sensors

### Fan

This page displays measurements for the different FANs in the IPMI interface.

### Power

On this page, you can find the information about power supply sensors.

### Alarm Table

This page contains a subtable polling all the required information for the configured services. This information is converted into the readable formats on the Transport Stream, Services, Teletext and Card Health pages.

The **Configure Polling** pop-up page contains the full set of rows, but only the columns needed to decide what should be kept in the filtered **Alarm Table**.

### Traps

On this page, you can find trap destinations and the virtual alarm status.

*Note*: For the **Virtual Alarm Table** to function properly, make sure the device has its SNMP trap targets configured correctly. The trap target should be the IP/VIP of the DataMiner Agent hosting the element, followed by the SNMP Trap port, by default *162*.

### RCP

On this page, you can send RCP Commands.

The commands are property of Kaleido and so they target specific fields on the device, for instance:

*\<setKDynamicText\>set address='Address' text='NewText' \</setKDynamicText\>*, where "Address" is the configured text address of the UMD or text label component and "NewText" is the text to display.

In the driver, you can define up to four text strings to be displayed: Text1, Text2, Text3 and Text4, which will replace the "NewText" string.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Troubleshooting

### GSMALARM connection issues

In case the element immediately enters a timeout state when trying to load an Excel file, it's likely the problem is coming from the GSMALARM connection. This connection uses port 2161 to retrieve data and fill the **Alarm Table (CFG)**, found in the **Configure Polling** pop-up page.

The GSM SNMP support can be added to the device by enabling the global action edition menu, using Miranda's XEdit software. Step-by-step guide on how to enable the GSM SNMP support:

1.  Download XEdit.
2.  Modify the *.medit.ini* file, present under the Windows user folder (usually "*C:\Users\\user name\>*").
3.  Add this line to *.medit.ini* while XEdit is closed: *enableGlobalActionsEdition=true* .
4.  Open *XEdit* and connect to the device.
5.  Click the *Tools* menu and navigate to *Edit global actions...*.
6.  Press *Add global...*, enter the name, community string and port *2161* and click *OK*.
