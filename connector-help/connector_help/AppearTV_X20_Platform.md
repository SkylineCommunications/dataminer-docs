---
uid: Connector_help_AppearTV_X20_Platform
---

# AppearTV X20 Platform

The AppearTV X20 Platform connector can be used to display information from the corresponding device and to configure the device.
It allows manual creation of DVEs for **IP Switch**, **Dual IP**, **SDI IO, Encoder, Decoder, Transcoder, DVB**, and **Descrambler** cards connected to the slots of the device (see "Exported Connectors" table below).

The connector uses an **HTTP** connection. This connection uses the MMI, IpGateway, XGER, ASI, and SDI APIs to retrieve information and to configure the device. The information transfer is performed using JSON.
The connector **sequentially** requests information from the device, processes the responses and displays the results. It is possible to send configuration requests and receive the updated results.

## About

### Version Info

| **Range**                | **Description**                                                                                                                                                                                                                                                                                                                                                                                     | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\]     | Initial version.                                                                                                                                                                                                                                                                                                                                                                                    | No                  | Yes                     |
| 1.0.1.x \[Obsolete\]     | Based on 1.0.0.3. - Implemented trap support. - Added new SNMP connection.                                                                                                                                                                                                                                                                                                                          | No                  | Yes                     |
| 1.1.0.x \[Obsolete\]     | Based on 1.0.1.2. - Improved card type identification based on new firmware. - Added functionality to edit input and output services.                                                                                                                                                                                                                                                               | No                  | Yes                     |
| 1.2.0.x \[Obsolete\]     | Based on 1.1.0.1. - New firmware 2.x.x. - Removed FPGA table; added new table SDI Cards Info.                                                                                                                                                                                                                                                                                                       | Yes                 | Yes                     |
| 1.2.1.x \[Obsolete\]     | Based on 1.2.0.31. - New firmware update 3.x.x on the IP Encoder card (ECx210). - Encoder Service IP parameters moved from Encoder Services Table to Input Profiles Table because of incompatible API changes.                                                                                                                                                                                      | Yes                 | Yes                     |
| 1.2.2.x \[Obsolete\]     | Based on 1.2.1.5. - Added external DLL with C++ code to generate service profile keys.                                                                                                                                                                                                                                                                                                              | Yes                 | Yes                     |
| 1.2.3.x \[Obsolete\]     | Based on 1.2.2.26 - Changed the primary keys of tables with PIDs 1600, 31000, 31100, 3000, 32000, and 32100. The previous primary keys were not unique and caused duplicate key errors.                                                                                                                                                                                                             | Yes                 | Yes                     |
| 1.2.4.x \[SLC Main\]     | Full Refactor - Same as range 2.0.3.x but without Unicode encoding. Does not support characters such as á, ”, etc.                                                                                                                                                                                                                                                                                  | Yes                 | Yes                     |
| 2.0.0.x \[Obsolete\]     | Based on 1.2.0.28. - Usage of class library features. - Marked as obsolete because versions are copies of the 1.2.0.x range but with the class library features enabled. The main range should be used to develop further.                                                                                                                                                                          | Yes                 | Yes                     |
| 2.0.1.x \[Obsolete\]     | Based on 2.0.0.14. - Marked as obsolete because this is a copy of the main range with class library features included (requires higher minimum DataMiner version). - This range is based on the 2.0.0.x range but now has the default protocol encoding type set to "unicode". Upgrading to this range will require manual work to clean up the element data in the database for existing elements. | Yes                 | Yes                     |
| 2.0.2.x \[Obsolete\]     | Based on 2.0.1.6 - Marked as obsolete because this is a copy of the main range with class library features included (requires higher minimum DataMiner version). - The table index of the dual output input redundancy table has been altered to support the 3 output mappings (rawMode, tsWhitelistMode, tsBlacklistMode).                                                                         | Yes                 | Yes                     |
| 2.0.3.x **\[SLC Main\]** | Full refactor - Same as range 1.2.4.x but with Unicode encoding. Supports characters such as á, ”, etc. Note: If you switch to this range, you will need to **recreate existing elements**. Otherwise, existing elements using the 1.x range might not function properly as database data is affected by the use of Unicode encoding.                                                               | Yes                 | Yes                     |

### Product Info

| **Range**       | **Supported Firmware**                                                                                                                                                                                                                                                                                                                                                                                                                     |
|-----------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x         | 1.5-dev 1.10.2-1433-g641c1cd                                                                                                                                                                                                                                                                                                                                                                                                               |
| 1.0.1.x         | 1.5-dev 1.10.2-1433-g641c1cd                                                                                                                                                                                                                                                                                                                                                                                                               |
| 1.1.0.x         | 1.12                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| 1.2.0.x         | 2.x.x                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| 1.2.1.x         | 2.x.x                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| 1.2.2.x         | 2.x.x                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| 1.2.3.x         | 2.x.x                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| 1.2.4.x 2.0.3.x | \- MMI (IP Switch Control): 2.x.x and higher (MMI 2.8+) - IP Switch / Dual IP (SWx/IPx): 2.x.x and higher (IpGateway 1.11+) - IP 2022 Encoder (ECx2): 3.x.x and higher (XGer 2.17+) - SDI Encoder/Decoder (ECx1): 5.6.x and higher (XGer 2.17+) - ASI IO (SIx): 2.4.x and higher (Asi 1.11+) - SDI IO (SIx): 2.4.x and higher (Sdi 1.11+) - DVB-S2 (SRx): 2.2.x and higher (S2xIn 1.3+) - Descrambler (DSx): 2.0.x and higher (Descr 1.1+) |
| 2.0.0.x         | 2.x.x                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| 2.0.1.x         | 2.x.x                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| 2.0.2.x         | 2.x.x                                                                                                                                                                                                                                                                                                                                                                                                                                      |

### Exported Connectors

| **Exported Connector**                                                                                                                                     | **Description**                                                                                                                          |
|------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------|
| [AppearTV X20 Platform - AppearTV X20 IP Switch](xref:Connector_help_AppearTV_X20_Platform_-_AppearTV_X20_IP_Switch)                         | Displays information and settings regarding IP inputs and outputs, services, IP interfaces, and ports for an IP Switch card in a slot.   |
| [AppearTV X20 Platform - AppearTV X20 Dual IP](xref:Connector_help_AppearTV_X20_Platform_-_AppearTV_X20_Dual_IP)                             | Displays information and settings regarding IP inputs and outputs, services, IP interfaces, and ports for a Dual IP card in a slot.      |
| [AppearTV X20 Platform - AppearTV X20 SDI IO](xref:Connector_help_AppearTV_X20_Platform_-_AppearTV_X20_SDI_IO)                               | Displays information and settings regarding inputs and outputs for an SDI IO card in a slot. Also shows information related to the card. |
| [AppearTV X20 Platform - AppearTV X20 Encoder](xref:Connector_help_AppearTV_X20_Platform_-_AppearTV_X20_Encoder)                               | Displays information and settings regarding encoder services with their audio components in a slot.                                      |
| [AppearTV X20 Platform - AppearTV X20 Decoder](xref:Connector_help_AppearTV_X20_Platform_-_AppearTV_X20_Decoder)                               | Displays information and settings regarding decoder services with their audio components in a slot.                                      |
| [AppearTV X20 Platform - AppearTV X20 Transcoder](xref:Connector_help_AppearTV_X20_Platform_-_AppearTV_X20_Transcoder)                         | Displays information and settings regarding the transcoded services per slot.                                                            |
| [AppearTV X20 Platform - AppearTV X20 Multituner Sat Demod](xref:Connector_help_AppearTV_X20_Platform_-_AppearTV_X20_Multituner_Sat_Demod) | Displays information and settings regarding satellite demodulator cards.                                                                 |
| [AppearTV X20 Platform - AppearTV X20 Descrambler](xref:Connector_help_AppearTV_X20_Platform_-_AppearTV_X20_Descrambler)                       | Displays information and settings regarding all descrambled services.                                                                    |

## Configuration

### Connections

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The port of the connected device, by default 443 (*4949).*
- **Bus address**: By default *bypassproxy.*

In case of communication issues (ERROR_WINHTTP_TIMEOUT), check the used TLS version in Wireshark. If it is TLS 1.0, download and install the "Easy fix" from the page [*https://support.microsoft.com/en-gb/help/3140245/update-to-enable-tls-1-1-and-tls-1-2-as-default-secure-protocols-in-wi*](https://support.microsoft.com/en-gb/help/3140245/update-to-enable-tls-1-1-and-tls-1-2-as-default-secure-protocols-in-wi), and reboot the server.

#### SNMP Secondary Connection.

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Configurable API Versions

From version 1.2.0.28 onwards, it is possible to configure a higher API version for specific cards. To do so, go to the **General** \> **Module Config** page.

Increasing the API version will result in extra data being filled in if that API version is supported on the chassis.

## Usage - Versions 1.2.0.x/1.2.1.x/1.2.2.x/1.2.3.x/1.2.4.x/2.0.0.x/2.0.1.x/2.0.2.x/2.0.3.x

### General

This page displays the **Chassis Cards Table**, which contains one row per card in the chassis, detailing **Serial**, **Name**, **Hardware**, **Software**, **Slot**, **Features**, **Licenses**, and **State** information. For each card, you can enable or disable the corresponding DVE. Via the **Module Config** page button, you can configure the behavior in case cards are removed. This page also shows the **Chassis Type** and allows you to select the **Firmware**.

The page also displays the **Link Rates Table**, which contains one row per card, displaying the reception and transmission link rates for each card.

The following page buttons are available:

- **Module Config**: Allows you to enable or disable the **Automatic Remove all Deleted DVEs** parameter. Also contains a button that allows you to remove all deleted DVEs manually.
  From version 1.2.0.28 onwards, it is possible to also select the implemented API version per card. Increasing the API version for a card will result in extra data being retrieved from the device.
  For compatibility reasons, the lower API version can be selected to ensure a functional connector in case you are not running a higher API version yet.
- **Authentication**: This page displays the current authentication status and allows you to specify a **Username** and **Password** to connect to the device.
- **Redundancy**: Available from version 1.2.0.17 onwards. The AppearTV X20 platform has two separate IP addresses to communicate with. On this subpage, you can specify the redundant IP address and port to be polled for the second gateway in case the first IP gateway goes into timeout. If a redundant IP is configured, the connector will try and switch to this address if timeouts occur.
- **SDI IO**: Displays the SDI IO DVE table.
- **Dual IP**: Displays the Dual IP DVE table.
- **IP Switch**: Displays the IP Switch DVE table.
- **Encoder**: Displays the Encoder DVE table.
- **Decoder**: Displays the Decoder DVE table.

### Alarms

This page displays two tables, the **Active Alarms Table** and **Alarms History Table.** These contain information regarding the alarm **Name**, **Severity**, **Time Set** and, for cleared alarms in the history table, **Time Clear**.

This page contains a dropdown box that allows you to select the **display key format** to apply to the **Active Alarms Table**. The following formats can be selected:

- *Default:* This display key is based on the Description column.
- *Label:* This display key is based on the Label column.

Via the **Traps** page button, you can configure the **trap source IP**.

### Input Services

This page displays the **Input Services Table**, with information about the service **ID**, **Name**, **Bitrate** status, **CC Errors**, **RTP Errors**, and **Slot** of the service.

### IP Switch Input - Services

This page contains a tree control with the **IP inputs** of the card and the **services per input**. It allows you to view and configure information related to the inputs.

### IP Switch Inputs

This page displays the **IP Inputs Table**, **IP Input Status Services Table**, and **Input Components**, with configurable information related to the IP inputs.

This page contains the following page button:

- **Add Input**: Allows you to add a new input to the selected IP Switch card. To do so, you must specify the **Label**, **Type** (*Single* or *Seamless*), **Analyze Mode** (*DVB*, *MPEG* or *RTP*), **Slot**, and **Interface ID**, **IP** and **Port** for the selected type.

### IP Switch Outputs - Services

This page contains a tree control for the **IP outputs** of the card and the **services per output**. It allows you to view and configure information related to the outputs, and to add, change, or remove services on a specific output.

### IP Switch Outputs

This page displays the **IP Outputs Table**, **IP Outputs Service Table**, and **IP Output Service Component Layout**, with configurable information related to the IP outputs.

This page contains the following page buttons:

- **Add Output**: Allows you to add a new output to the selected IP Switch card. To do so, you must specify the **Label**, **Type** (*Single* or *Cloned*), **Service**, **Slot**, and **Interface ID**, **IP** and **Port** for the selected type.
- **PID Mapping**: Displays the PID Mapping table. You can **add or delete** entries in table via the **right-click menu**.

### IP Switch Interfaces

This page contains a table with information related to the IP interfaces of the card. Adjusting the configuration in this table is not possible, as this could accidentally disconnect the DMA.

### IP Switch Ports

This page contains two tables with information about **physical and virtual ports**. For virtual ports, the **Allow Seamless** and **Allow Cloned** settings can be adjusted.

### IP Encoder Interfaces

This page contains two tables with information about **Encoder Interface Configurations** and the **Encoder Link Rates**.

Note: This functionality is only available for the ECx210 card, not for the ECx100 card.

### Dual IP Inputs

This page displays the **Dual IP Inputs Table**, **Dual IP Input Status Service Table**, and **Dual IP Input Components**, with configurable information related to the inputs in the Dual IP card.

This page contains the following page button:

- **Add Dual IP Input**: Allows you to add a new input to the selected Dual IP card. To do so, you must specify the **Label**, **Type** (*Single* or *Seamless*), **Analyze Mode** (*DVB*, *MPEG* or *RTP*), **Slot**, and **Interface ID**, **IP** and **Port** for the selected type.

### Dual IP Switch Input - Services

This page contains a tree control with the **IP inputs** of the card and the **services per input**. It allows you to view and configure information related to the inputs.

### Dual IP Outputs - Services

This page contains a tree control for the **IP outputs** of the card and the **services per output**. It allows you to view and configure information related to the outputs, and to add, change or remove services on a specific output.

### Dual IP Outputs

This page displays the **Dual IP Outputs Table**, **Dual IP Output Multiplex Service Table**, and **Dual IP Output Service Component Layout**, with configurable information related to the IP outputs.

This page contains the following page button:

- **Add Dual IP Output**: Allows you to add a new output to the selected Dual IP card. To do so, you must specify the **Label**, **Type** (*Single* or *Cloned*), **Service**, **Slot**, and **Interface ID**, **IP** and **Port** for the selected type.

### Dual IP Interfaces

This page contains a table with information related to the IP interfaces of the card. Adjusting the configuration in this table is not possible, as this could accidentally disconnect the DMA.

### Dual IP Ports

This page contains two tables with information about **physical and virtual ports**. For virtual ports, the **Allow Seamless** and **Allow Cloned** settings can be adjusted.

### SDI IO Inputs/Outputs

This page contains the **SDI IO Physical Ports Table**.

### SDI Cards Info

This page contains the **Cards Info Table**.

### ASI I/O

This page contains the **ASI Input** and **ASI Output Table**.

This page contains the following page buttons:

- **ASI Port Config**: Contains a list of all ports, indicating for each port whether it is configured as **Input** or **Output**. This table also allows you to adjust this configuration.
- **ASI Output Config**: Contains a list of all **linked input sources per ASI output**. This page also contains controls to link a **TS** or **service** source to an ASI output.

### Encoder Services

This page contains the **Encoder Services**, **Audio Encoder Services**, and **VANC Services** tables. The Audio Encoder Services table links the data with encoder services and audio profiles. The VANC Services table links the data with encoder services and VANC profiles.

The page contains the page buttons **Add IP/SDI Encoder Service**, **Add IP/SDI Audio Encoder Services**, and **Add IP/SDI VANC Services**, which can be used to add new entries to the tables.

The **IP/SDI Options** are applicable for the different card types, IP (ECx210) and SDI (ECx100). To delete one or more table entries, use the right-click menu.

### Encoder Services - Overview

This page contains a tree control for the **Encoder Services** and **Audio Encoder Services** per encoder service.

### Decoder Services

This page contains the **Decoder Services** and **Audio Decoder Services** tables.
The page contains two page buttons, **Add Decoder Service** and **Add Audio Decoder Services**, which can be used to add new entries to the tables.

To delete one or more table entries, use the right-click menu.

### Decoder Services - Overview

This page contains a tree control for the **Decoder Services** and **Audio Decoder Services** per decoder service.

### Input Profiles (Available in range 1.2.1.x)

This page contains the **Input Profiles** table. Via the **Add Input Profile** page button, you can add new entries to this table.
To delete one or more table entries, use the right-click menu.

### Video Profiles

This page contains the **Video Profiles** table. Via the **Add Video Profile** page button, you can add new entries to this table.
To delete one or more table entries, use the right-click menu.

### Audio Profiles

This page contains the **Audio Profiles** table. Via the **Add Audio Profile** page button, you can add new entries to this table.
To delete one or more table entries, use the right-click menu.

### VANC Profiles

This page contains the **VANC Profiles**, **VANC Services** and **Teletext Pages** tables. The VANC Services table links data with encoder services and VANC profiles.

For each of the tables, a page button is available that allows you to add more entries to the table.
To delete one or more table entries, use the right-click menu.

### Color Profiles

This page contains the **Color Profiles** table. Via the **Add Color Profile** page button, you can add new entries to the table.
To delete one or more table entries, use the right-click menu.

### Multi Services (available from version 1.2.2.x onwards)

This page displays two tables.

- The **Multi Services** table lists the current services with detailed information, including the current profile used by each service.
- The **Service Profiles** table contains all the data about the profiles. For each profile, the audio and video resolution are displayed.

Note: To retrieve the information on this page, an **additional external DLL is required**. This DLL must be added **in the ProtocolScripts folder**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

In **version 1.2.0.29** of the connector, DCF integration has been added for the following tables: Physical Ports Table, IP Encoder Interfaces Table, Dual IP Physical Ports Table, SDI IO Physical Ports Table, ASI Input Table, ASI Output Table, and S2X Input Ports.

Note: For the **SDI IO Physical Ports** table, the extra configuration parameter **SDI IO DCF Interfaces**, which can be found on the same page as the table, must be set to *Enabled*. Setting this parameter to *Enabled* will change the display key format in order to allow the creation of the interfaces. This change can affect trend and alarm data, Automation scripts, Visio drawings, etc. As such, the default setting of the parameter is *Disabled*.
