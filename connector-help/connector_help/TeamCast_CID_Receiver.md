---
uid: Connector_help_TeamCast_CID_Receiver
---

# TeamCast CID Receiver

With the TeamCast CID Receiver connector it is possible to configure and monitor the Carrier ID extractor DVB-S/DVB-S demodulator. This device is a **satellite receiver** and is used to optimize the quality of satellite links.

This optimization is achieved by embedding and detecting a small message and a unique ID within the video or data satellite carrier.

## About

The product reference of this CID Receiver is **CID0-1510**. The CID0-1510 is used to detect the Carrier Identification of a host carrier that has embedded the DVB-CID ETSI TS 103 129 standards-based Carrier ID technology.

This connector retrieves and sets data via **SNMP**.

Ranges of the connector

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

Supported firmware versions

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | S1100-B008                  |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, the default value is *public*.
- **Set community string:** The community string used when setting values on the device, the default value is *private*.

## Usage

### General

This page shows the **version info** and allows the user to **configure ethernet**, **snmp** and **time** options.

### Configuration

This page allows the user to **configure** the **RF Input** options and the **RF Output** options.

### Profile

This page shows a table containing all created **profiles**. Futhermore it is possible to **create** a new profile or **delete** a profile and to **load/store** configurations from/to a created profile.

### Monitoring

This page shows the **monitored parameters**. These are grouped by **input, process, DVB-S2 - Single Stream, DVB-S2 - Multi Stream, Output - ASI, Output - IP, Probes, Probes DVB-S, Probes DVB-S2.**

### TSOIP

This page allows the user to **configure** the **TSOIP** parameters. These configuration are grouped by **Common Configuration** and **Channels Configuration.**

### Carrier ID

This page allows the user to **enable/disable CID Extraction.** **Info** parameters regarding the **CID Extraction** are also shown on this page.

### Alarm

This page shows the device **temperature** followed by a **Alarms - General table** and a **Alarms - Product table**. Both tables show the **alarm status value** (ON/OFF) and **alarm counter**. Both tables also allow the user to configure the **alarm settings**.
Following the alarm tables the page shows the **status LEDs** and the **relay status**. It's also possible to **reset** the relays from this page.

### WebInterface

The web interface is meant to embed the **device webUI**. The **address** **of the host/webUI** has to be configured on the **General** page (**SNMP Configuration**), otherwise the web interface defaults to localhost (127.0.0.1).
