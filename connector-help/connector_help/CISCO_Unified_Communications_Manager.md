---
uid: Connector_help_CISCO_Unified_Communications_Manager
---

# CISCO Unified Communications Manager

This connector can be used to monitor the **CISCO Unified Communications Manager**. The CUCM is responsible for the management and configuration of SIP and VoIP lines and extensions.

## About

This is a read-only SNMP monitoring connector, which polls information about registered devices and the local CUCM cluster connection status.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 11.5.1.12900-21             |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general parameters related to the device. It also contains the **CUCM Cluster Table**, which contains information on all the known CUCMs in a CUCM cluster.

### Phones

This page displays the **Phone Table**, which lists all phone devices that have tried to register with the local CUCM at least once.

Note: This table may be exceptionally large, so **polling may take around 3 minutes**.

### Gateways

This page displays the **Gateway Table**, which lists all gateway devices that have tried to register with the local CUCM at least once.

### Media Devices

This page displays the **Media Devices Table**, which lists all media devices that have tried to register with the local CUCM at least once.

### CTI Devices

This page displays the **CTI Devices Table**, which lists all CTI (Computer Telephony Integration) devices that have tried to register with the local CUCM at least once.
