---
uid: Connector_help_CEFD_CDM-625_Serial
---

# CEFD CDM-625 Serial

The **CDM-625 Serial** Advanced Satellite Modem is intended for both closed network and legacy Intelsat applications. The CDM-625 is a replacement for the CDM-600 and CDM-600L Open Network Satellite Modems.

To further information access the link <http://www.comtechefdata.com/support/docs/satellitemodemdocs>.

About

This connector is intended to get and set information in the device via an Element in a DataMiner System, using Serial commands.

### Version Info

| **Range** | **Key Features**                                                                                                    | **Based on** | **System Impact**                                 |
|-----------|---------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------|
| 1.0.0.x   | Initial version                                                                                                     | \-           | \-                                                |
| 2.0.0.x   | \-                                                                                                                  | \-           | \-                                                |
| 3.0.0.x   | \-                                                                                                                  | \-           | \-                                                |
| 3.0.1.x   | Multiple tables now uses naming instead of displayColumn to make the database for these tables Cassandra-compliant. | 3.0.0.16     | **Old trend data will be lost for these tables.** |
| 4.0.0.x   | \-                                                                                                                  | \-           | \-                                                |

## Installation and configuration

### Creation

### SERIAL CONNECTION

- **Type of Port:** the type of port used to connect to the device, default *TCP/IP*
- **IP address/host**: the polling IP of the Ethernet To Serial Converter eg *10.11.12.13*
- **IP Port**: the port addressed to connect the device, set in the Ethernet To Serial Converter, eg *4001*
- **BUS Address**: the BUS address set in the device, eg *1*

## Usage

### General

In this page is given information about the **System** and the **Device's** **Overall Status**.

### Admin-Firmware

**Base Modem** and **Packet Processor Firmware** versions can be set under this page.

### Admin - FAST

Under this page is given information about **Equipment ID** and installed **Hardware**.

### Config - Modem

Under this page, Modem's **Transmit** and **Receive** parameters can be set. There's also available for configuration the **ACM** and **CnC** parameters under the page buttons.

### Config - LAN - IP

**Network Configuration**, **Per Port Configuration,** **VLAN Mode** and related parameters can be set here.

### Config - Overhead

Access this page to configure **ESC**, **AUPC** and **EDMAC**. Also **CnC-APC** and **IDR Backward Alarms** can be set under the page buttons.

### Config - Utilities

Parameters related to **Redundancy**, **Buffer**, **Unit**, **Clocks**, **Circuit ID**, **Date&Time**, **BERT Config**, **Warm-Up** and **Save/Load** **Configuration** can be found here.

### Config - Drop and Insert

**Drop and Insert** and **Quad Drop and Insert** configurations are made in this page.

### Config - BUC / LNB

**BUC** and **LNB** **Configuration** and also its **Status** are set in this page.

### Config - PTP

Under this page the **PTP** **Feature** is set.

### Status - Modem Status

To get the status of the modem's functionalities. Those can be the **Alarms**, **Rx Parameters**, **CnC**, **General Status**, **AUPC**, **WAN Statistics**, **ACM Status** and **Fractional CnC** **Counters**.

### Status - Modem Logs

To get information about latest **Events** and device **Statistics** use this page. This can be *enabled* or *disabled* through the buttons. Initialize Pointer is used to load again the entries that are on the device's memory when polling is *disabled*. To mask alarms use the **Alarm Masking** page button.

### ODU / Redundancy

**Outdoor Unit** and **Redundacy** related configurations can be done in this page.

### FSK

In this page is possible to set the FSK functionality. This functionality will generate a virtual element that contains all BUC/LNB parameters. A unique FSK Element Name can be set for the virtual element.

### Save / Load Configuration

In this page is possible to **Save** to a csv file all parameters values. After, is also possible to **Load** that same file. It will set the parameters with the values that were saved.

- The file will be stored by default on this folder: *C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\\PROTOCOLNAME\]*

- The file will be named by default: *backup_ELEMENTNAME_datetime*
