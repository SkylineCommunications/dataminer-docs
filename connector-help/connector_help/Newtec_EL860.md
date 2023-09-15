---
uid: Connector_help_Newtec_EL860
---

# Newtec EL860

The **Newtec EL860** shaper and encapsulator combines multilevel IP/VLAN traffic policing and real-time shaping functionalities with a DVB-S2 IP encapsulator and a DVB-S2 modulation parameter controller. The EL860 enables Constant Coding and Modulation (CCM), Variable Coding and Modulation (VCM) and Adaptive Coding and Modulation (ACM) implementations in the forward link of satellite star services applications, such as IP trunking networks.

## About

This connector communicates with the device using a serial connection. It retrieves data from the equipment to enable monitoring of rates, statistics over rules, terminals and ACM.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                         |
|------------------|---------------------------------------------------------------------|
| 1.0.0.x          | TelliShape version 3.0.1 201010191428391 Decapsulator version 1.1.7 |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *10210* (TelliShape Server).

### Configuration

To allow DataMiner to poll the equipment, you need to add the IP address/subnet mask of the polling DMA to a configuration file, and restart the TelliShape server to apply the changes:

1. Either log in on the device's web interface in expert mode or locate the file "/usr/local/tellitec/tc-shape-server/shape-server.ini".

1. Determine the IP address of the DMA in the management LAN of the equipment, and add the address in the following section of the configuration/file:

   ```
   [command_port]
   allowed_address=127.0.0.1
   allowed_address=x.x.x.0/24
   ```

1. Restart the shaper process to apply your changes.

Note that with an EL860 1+1 hot standby redundancy configuration, it is not possible to poll the standby/backup device/element, because the Tellishape Server process can only run on one device/element at a time.

## Usage

### General Page

This page displays the **Received Packets**, **Dropped Packets** and **Rates**.

### Encapsulator Page

This page contains information related to the encapsulator (**IP**), including the **Number of the Packets Sent**, **Frames Sent** and **IP Packet Rate.**

The **Statistics Per Modcod** page button provides access to more information about the Modcod, such as **Rates** and **Fill Efficiency**.

### Terminals Page

This page provides an overview of the terminals, with information such as the **Number of IP Bytes sent**, **Symbols Rate** and **Terminal Current Modcod**.

### ACM Control Page

This page contains information related to the ACM, including the **Total Received ACM Feedbacks** and **Total Received ACM Changes**.

The page also contains the **Statistics Per ACM Controller** table, which displays among others the **ACM Feedback Rate**, **ACM changes** and **ACM Expiry Rate.**

### Statistics per Rule Page

This page displays a table with information on each rule, including the **Bit Rate Unit**, **Packets Rate** and **Guaranteed Rate.**

### Web Interface Page

This page allows you to access the original web interface of the device. To do so, the default username is '**admin**', and the default password is '**el860**'.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
