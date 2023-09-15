---
uid: Connector_help_Ericsson_RX9500
---

# Ericsson RX9500

Ericsson's RX9500 bulk **descrambler** provides cable and IPTV providers and other direct-to-home operators with the capability to efficiently process encrypted and free-to-air content from satellite platforms. The RX9500 is a bulk descrambler consisting of a base unit or chassis into which six option cards can be plugged. Each descrambled service/channel (descrambled via DVB common interface modules) is output via a single transport stream.

## About

This connector monitors basic parameters and alarms related to the device. It also receives traps from the device, so that alarm events can immediately be displayed or cleared.

In addition, the connector is used to monitor satellite services through cards or modules mounted on the device.

The initial versions of the connector only support SNMP traps. The latest version of the connector includes a REST API implementation to retrieve all data information from the device by using HTTP protocol.

### Version Info

| **Range** | **Description**                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                 | No                  | Yes                     |
| 2.0.0.x          | Branch version based on 1.0.0.x | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.0                       |
| 2.0.0.x          | 1.0.0                       |

### Exported connectors

| **Exported Connector**              | **Description** |
|------------------------------------|-----------------|
| Ericsson RX9500 - Descrambler Card | Device cards    |

## Installation and configuration

### Creation

The connector uses SNMP and HTTP connections as follows:

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: 80
- **Bus address**: *bypassproxy.*

## Usage

### General

This page contains general information regarding the device itself, such as the **System Description**, **Uptime**, **Contact**, **Name** and **Location**.

### Active Alarms

This page displays the **active alarms** on the device, which are added to the table when an SNMP trap is received. For each alarm, more information is displayed in the table, including the **Reference Number**, **Trap Sequence**, **Alarm ID**, **Alarm Type**, **Alarm Text**, **Source Text**, **Severity**, **Profile ID**, **Stream ID** and **Virtual Resource ID**. For each row, a **Delete Row** button is available.

This page also displays the **Number of Alarm Rows** parameter, which indicates the number of rows in the active alarms table. The button **Refresh Table** can be used to update the Active Alarms table.

The **Traps Config** page button provides access to parameters such as **Keep Cleared Alarms**, **Maximum Number of Alarms**, the **Delete Cleared Alarms** button, **Maximum Age of Alarms** and **Alarms Clean Up Method**.

### Alarm History

This page contains a table with the same columns as the Active Alarms table. This table **retrieves the last 20 alarms** that have occurred on the device.

### Notifications

This page shows **notifications events** in the Notifications table. Notification are received as SNMP traps.

### Dashboard Page

This page displays the following tables:

- The **Transport** **Stream** **Source** table: Displays all sources for the transport stream of which one is active at one time. Contains the following parameters: **Card** **ID**, **Availability**, **BER**, **C/N Margin**, **C/N**, **Configured**, **Demodulation**, **FEC Rate**, **Satellite** **Frequency**, **Interface** **ID**, **LNB 22 KHz**, **LNB** **Low** **Frequency**, **LNB** **Power**, **Locked**, **Modulation**, **Modulation** **Type**, **Roll Off**, **Search** **Range**, **Signal** **Level**, **Spectrum** **Inversion**, **Spectrum** **Sense**, **Template** **Name** and **Symbol** **Rate**.
- The **Interface** **Groups** table: Lists each group linked to the interfaces. Contains the following columns: **Interface** **Name**, **Interface**, **Direction**, **Gateway**, **IP Address**, **Link License**, **Link Status**, **Link Uptime**, **Link Usage**, **MAC** **Address**, **Port Type**, **Rx** **Packets**, **Tx** **Packets** and **Subnet** **Address**.
- The **Interface** **Collection** table: Displays all the interfaces on a card. Contains the following columns: **Interface** **ID**, **Index**, **Name**, **Redundancy** **Mode** and **Template** **Name**.
- The **Input** **Stream** **Transport** **Collection** table: Displays all the input transport streams that have either been explicitly created or created automatically because an RF front end has been introduced into the system. The table has the following columns: **ID Collection**, **Active Source**, **Content Extraction Source**, **Transport Stream ID**, and **Template Name**.

### Input Services Page

This page displays a **tree control** along with three tables: **Transport Stream Source**, **Input Transport Services** and **Stream**.

- The **tree control** contains active cards, each of which contains a subset of input channels. Each channel may have audio, data and video as channel components.
- The **Input** **Transport** **Services** table lists all active channels over the cards, with the following columns: **Service** **Name**, **Service** **ID**, **CA** **Systems**, **PCR** **PID**, **PMT** **PID**, **Service** **Type**.
- The **Stream** **table** lists the components of all input channels, with the following columns: **PID**, **Type**, **ATSC** **PMT** **Stream** **Type**, **CA** **System** **Specified**, **Coding** **Standard**, **Data** **Type** and **DVB** **PMT** **Stream**.

### Output Services Page

The purpose of the Output Services query is to descramble a set of scrambled services and to create a single MPTS (Multi-Program Transport Stream) containing the descrambled services or a set of SPTS (Single-Program Transport Streams) that each contain one of the descrambled services. The unscrambled services are passed directly to the output, which may be the output on any or all of the available interfaces.

A **tree control** is displayed containing all data interfaces; each data interface has a single descrambled output channel. The **tree control** is based on the following tables: **Output** **Transport** **Stream**, **Output** **Stream** **Service** and **Output** **Service** **Components**.

The **Output** **Transport** **Stream** table contains the **Data** **Interfaces** along with the **Bit** **Rate**, **Mode**, **PMT** **Repetition**, etc. These constitute the top branch of the hierarchical view. The **Output** **Stream** **Service** table contains their associated channels and the **Output** **Service** **Components** table contains all components of the descrambled services

### Device Page

This page displays an overview of device-related slots. Two tables are displayed: **Device** **Items** and **Cards** **Properties** **Collection**.

- The **Device** **Items** table displays one to six descrambler option slots. It contains the following parameters: **Card** **ID**, **Status** and **Name**. Note that slot 0 is reserved for the Host Controller.
- The **Cards** **Properties** **Collection** table displays all cards installed in the system. It contains the following columns: **Key**, **Assembly** **Number**, **Board** **Type**, **Boot** **Timeout**, **Card Name**, **CRC**, **Format Version**, **Hardware Modification**, **HSSI Present**, **Hardware Revision**, **Installed**, **Name**, **Package Valid**, **Package Version**, **Product Number**, **Serial Number**, **Token** and **Unit Test Time**.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to able to access the device, as otherwise it will not be possible to open the web interface.
