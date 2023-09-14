---
uid: Connector_help_Al_Jazeera_Media_Network_Arvato_VPMS_Doha
---

# Al Jazeera Media Network Arvato VPMS Doha

The Arvato System's VPMS (Video Production Management System) is a solution designed to create, manage and process digital video content. With this solution, every integrated workflow, from ingest and production, transcoding and quality management to distribution, playout and archiving, can be managed. The Al Jazeera Media Network Arvato VPMS Doha connector enables the monitoring of this solution.

## About

An **SNMP** connection is used in order to retrieve the necessary information. In addition, this connector can process SNMP traps in order to update the monitored parameters.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string needed to read from the device.
- **Set community string**: The community string needed to set to the device.

## Usage

### General

This page displays information regarding the **Control Center, Media Center, Sequence Generator Interplay** and **Migrate Archive** running status.

### Agent

This page displays the following page buttons, which open a new page with information regarding the running state of each agent's parameter group.

- VolGen
- KeyFrame Generator
- Image Grabber
- Clip Transfer
- Trim High Res
- KeyFrame Generator
- Transfer Avid TM
- WF Host
- Metadata Exchange Avid
- Multimedia Transfer
- XML Export
- Meta Worker
- DVD Image Creator
- Audio Exchanger
- Empty Avid Sequence
- Common Index Creator
- Fuser AME
- Send Email
- Archive Diva CTRL
- Restore Diva CTRL
- Tec Data Reader
- Image Preview Generator
- HighRes Switcher
- Vantage Direct Control
- Router Control
- Transcoder S4M
- Transfer in Avid Interplay
- Transfer to Avid
- Transfer from Avid
- Transfer Avid Multimedia
- Check Baton
- Transfer Signiant

### Server

This page displays the following page buttons, which open a new page with information regarding the running state of each server's parameter group.

- Media Request Service
- Query Service
- Retrieve Log Files
- Transfer Service
- Workflow Management Status
- IFinder Index Writer
- IFinder Searcher

### Watchdog

This page displays the following page buttons, which open a new page with information regarding the running state of each watchdog's parameter group.

- Essence Balancer
- XML Import Balancer
- IFinder Event Log Observer
- SNMP Trapper
- Encoding Unit
- Logfile Move
- Essence Streaming
- PJob Export
- Delete Queue Calc
- Asset Eraser
- Balancer Avid
- CJ Core Services
- Cutlist Control
- System Cleaner
- Deletion Data
- Virtual Channel Manager
