---
uid: Connector_help_Miranda_Kaleido_IP_X310
---

# Miranda Kaleido IP X310

This connector supports the Miranda Kaleido IP X310. This is an IP video multiviewer that is used to monitor and view local/remote IP multicast streams. By means of SNMP and serial communication, information is gathered and loaded into the connector. After a configuration file (.xls/.xlsx) is supplied, a DataMiner element will keep track of the provisioned services. If enabled on the device, SNMP traps will be used to update the hardware status more efficiently.

## About

### Version Info

| **Range**            | **Based on** | **Description**                                                                                             |
|----------------------|--------------|-------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | \-           | Initial version.                                                                                            |
| 1.0.1.x              | 1.0.0.4      | Different display key for virtual alarm table. Changes in import file and mandatory value in service table. |
| 1.0.2.x \[Obsolete\] | 1.0.1.2      | Audio alarms were separated from the service table.                                                         |
| 1.0.3.x \[SLC Main\] | 1.0.2.3      | Changes to Health Information Table to allow trending and alarm monitoring.                                 |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 7.60 (build552)        |
| 1.0.1.x   | 7.60 (build552)        |
| 1.0.2.x   | 7.60 (build552)        |
| 1.0.3.x   | 7.60 (build552)        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.3.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

To create a new element, several ports will need to be configured. Most of the values are filled in by default, except for the IP address.

#### SNMP connections

This connector uses Simple Network Management Protocol (SNMP) connections and requires the following input during element creation:

SNMP CONNECTION (KaleidoK3):

- **IP address/host**: The polling IP of the device, e.g. *127.0.0.1.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

BASEBOARD:

- **IP address/host**

BASEBOARD Settings:

- **Port number**: The port of the connected device, by default *1161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

GSMALARM:

- **IP address/host**

GSMALARM Settings:

- **Port number**: The port of the connected device, by default 2*161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *127.0.0.1.*
- **IP port**: The port of the connected device, by default *13000*.
- **Timeout time**: The timeout of a single command in ms, by default *10000*.

### Configuration

To load the services that need to be monitored, an Excel file is required with a fixed format. Go to the **General** page and open the pop-up page **Load File**. Then specify the **File Path** and **File Name** of the Excel file, and finally click **Import**.

**IMPORTANT**: This connector interacts with Excel files via the Microsoft OLE DB API. To be able to communicate with Excel files, make sure the Microsoft Access Runtime database tool is installed before you use this connector.

The Excel file should be filled in as explained in the *Usage* \> *General* section below.

Finally, go to the **Alarm Table** page and enable the alarm table polling if necessary.

## Usage

### General

This page displays basic information about the device. The **channel** and **layout** can also be set here.

The page also contains two page buttons:

- **Load File**: Opens the configuration file import window.

> To load the services that need to be monitored, an Excel file is required with a fixed format (.xls or .xlsx). Go to the **General** page and open the pop-up page **Load File**. Then specify the **File Path** and **File Name** of the file, and finally click **Import**.
>
> The Excel file should contain columns with the following headers (example values refer to the image below):
>
> - **Input ref ID**: You can take this from the Program Number. For example, in this case, for Stream 6, it is 221.
> - **Input Service Name**: You can take this from the Source Info: Name. For example, in this case, for Stream 5, it is "OSN Sports 4".
> - **Input mon device**: The name of the device, which must equal the element's name. This way, one file can be used to configure any element.
> - **Input mon device port**: A unique port number (used as index).
> - **Program number**: This must be the same as the Input Ref ID.
> - **Multicast**: You can take this from the Multicast IP.
> - **UDP Port**: You can take this from the UDP Port.
> - **Output Service name:** Take this from the Kaleido configuration. If you cannot find this information, leave this the same as the Input Service Name.
> - **Source Friendly Name**: Take this from the Stream Name. Replace each whitespace by a "+". Range 1.0.1.x only.
>
> ![2022-07-05 15_26_05-Clipboard.png](~/connector-help/images/Miranda_Kaleido_IP_X310_2022-07-05_15_26_05-Clipboard.png)![Clipboard](~/connector-help/images/Miranda_Kaleido_IP_X310_2022-07-05_15_26_05-Clipboard.png)
>
> Finally, go to the **Alarm Table** page and enable the alarm table polling if necessary. By default, the connector should enable alarm monitoring for the necessary parameters.
>
> **Note:** The Transport Stream, Services, Teletext, and Card Health tables are filled in based on the imported Excel file, located in the folder indicated by the File Path parameter or in the element document folder. After these are filled in, the data is polled.

- **On-Air Services**: Opens a window where you can edit the on-air service times.

### Transport Stream

This page displays an overview of the transport streams, including status, TSID, and an indication of whether the underlying services are on air.

### Services

This page displays all the services as specified in the configuration file. For each service, the alarm values are filled in in the columns, with the on-air status at the end. To prevent an overload of possibly irrelevant data, not all possible alarm values are displayed.

### Teletext

This page displays the **Teletext Information Table**. This table contains the teletext alarm values, which have been separated from the services table.

### Card Health

This page displays another subset of the alarm table, with hardware information about the cards of the device.

### System

This page displays system and chassis information parameters.

Parameters on this page are only available with the appropriated firmware version.

### Processor

On this page, you can find the identification, classification, and status of the processor.

Parameters on this page are only available with the appropriated firmware version.

### Power

This page displays the power supply measurements and status.

Parameters on this page are only available with the appropriated firmware version.

### Voltage

This page displays measurements for the different voltages in the device.

Parameters on this page are only available with the appropriated firmware version.

### Memory

On this page, you can find the identification and status of the memory modules.

Parameters on this page are only available with the appropriated firmware version.

### Cooling

This page displays the measurements and status of the cooling hardware.

Parameters on this page are only available with the appropriated firmware version.

### Temperature

This page displays the temperatures measured by all the hardware.

Parameters on this page are only available with the appropriated firmware version.

### Drive Slot

This page displays information on the hard drives present in the device.

Parameters on this page are only available with the appropriated firmware version.

### Alarm Table

This page contains a subtable polling all the required information for the configured services. This information is converted into the more user-friendly information displayed on the Transport Stream, Services, Teletext, and Card Health pages.

The **Configure Polling** pop-up page contains the full set of rows but only the columns that are needed to decide what should be kept in the filtered **Alarm Table**.

Note: The Excel file provisioned on the General page should already configure all the necessary parameter polling.

### Traps

On this page, you can find trap destinations and the virtual alarm status.

Note: For the **Virtual Alarm Table** to function properly, make sure the device has its SNMP trap targets configured correctly. The trap target should be the IP/VIP of the DataMiner Agent hosting the element, followed by the SNMP trap port, by default *162*.

### RCP

On this page, you can send RCP Commands.

The commands are property of Kaleido. They target specific fields on the device, for instance:
*\<setKDynamicText\>set address='Address' text='NewText' \</setKDynamicText\>*, where "Address" is the configured text address of the UMD or text label component and "NewText" is the text to display.

In the connector, you can define up to four text strings to be displayed: Text1, Text2, Text3, and Text4, which will replace the "NewText" string.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Troubleshooting

### GSMALARM connection issues

In case the element immediately enters a timeout state when trying to load an Excel file, it is likely the problem originates from the GSMALARM connection. This connection uses port 2161 to retrieve data and fill the **Alarm Table (CFG)**, found on the **Configure Polling** subpage.

You can add the GSM SNMP support to the device by enabling the global action edition menu, using Miranda's XEdit software:

1. Download XEdit.

1. Modify the *.medit.ini* file, present under the Windows user folder (usually "*C:\Users\\user name\>*").

1. Add the following line to *.medit.ini* while XEdit is closed:

   *enableGlobalActionsEdition=true*.

1. Open *XEdit* and connect to the device.

1. In the *Tools* menu, select *Edit global actions*.

1. Click *Add global*, enter the name, the community string, and port *2161,* and click *OK*.
