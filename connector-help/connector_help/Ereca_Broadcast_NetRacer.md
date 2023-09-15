---
uid: Connector_help_Ereca_Broadcast_NetRacer
---

# Ereca Broadcast NetRacer

This connector is used to monitor the **Ereca Broadcast NetRacer** chassis and plug-in cards.

## About

The NetRacer is a chassis with 16 slots for swappable broadcast cards. Although the chassis firmware is independent of the inserted cards, the cards supported by DataMiner are currently:

- **2 Rx Card**
- **2 Tx Card**
- **Ethernet Card**

The minimum framework required is .NET 4.0, so that System.Web.Extensions.dll is available.

### Version Info

| **Range** | **Description**                | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                | No                  | Yes                     |
| 1.0.1.x          | Changed keys and naming format | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.1.1                       |
| 1.0.1.x          | 1.1.1                       |

### Exported connectors

| **Exported Connector**                                                                        | **Description**    |
|----------------------------------------------------------------------------------------------|--------------------|
| [Ereca Broadcast NetRacer - 2Rx](xref:Connector_help_Ereca_Broadcast_NetRacer_-_2Rx) | Receiver module    |
| [Ereca Broadcast NetRacer - 2Tx](xref:Connector_help_Ereca_Broadcast_NetRacer_-_2Tx) | Transmitter module |
| [Ereca Broadcast NetRacer - Eth](xref:Connector_help_Ereca_Broadcast_NetRacer_-_Eth) | Ethernet module    |

## Installation and configuration

HTTP primary connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

The Details page from the web interface is recreated in this connector, while the chassis overview is represented by a table on a separate page. The data of active cards is added to one of the card tables depending on the card's type. Finally, it is possible to create a DVE for the cards.

### Details

This is the default page of this connector. It has the same layout as the corresponding page in the web interface.

### Chassis

This page only contains the **Chassis Table.** The data is represented in the following columns:

- **Card Presence**: Shows whether a card is inserted, with the values *Absent* or *Present.*
- **Power LED**: Shows whether the card is powered on, with the values *On* or *Off.*
- **Alarm LED**: Shows whether the card is in alarm, with the values *On* or *Off.*
- **Polling LED**: Shows whether the card is polling / being polled, with the values *On* or *Off.*

Finally, because the API does not indicate the card type, you should select the correct **Card Type** for each inserted card in order to load the values into DataMiner.

### Cards

This page contains the data tables for each card type. In the **DVE Creation** column, you can select whether a DVE should be created.

- **Rx Cards Table**
- **Tx Cards Table**
- **Ethernet Cards Table**

With the **DVE** page button, the **DVE Tables** pop-up page can be accessed.

### Configuration

This page contains the configuration parameters of the chassis: the **Firmware** **Version**, the **Device Name** and the IP configuration.

### Web Interface

This page loads the web interface if the client is in the same network as the device. However, this device's web interface might not be fully supported by Internet Explorer.
