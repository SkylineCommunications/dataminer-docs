---
uid: Connector_help_ADVA_Optical_Networking_FSP3000_5WCA-PCN-16GU
---

# ADVA Optical Networking FSP3000 5WCA-PCN-16GU

The **ADVA Optical Networking FSP3000** is an optical data transport solution. This connector can be used to monitor and control a **5WCA-PCN-16GU** card.

## About

The **ADVA Optical Networking FSP3000** is an extensible chassis with multiple slots. Each slot can contain a different type of extension card. This connector is especially meant for the **5WCA-PCN-16GU** card.

This connector requires an element of protocol "**ADVA Optical Networking FSP3000**" with the same polling IP to function. The purpose of that element is to retrieve the entity IDs of the different components on this card, i.e. channels. The entity ID is used in the SNMP OID in order to successfully retrieve data from this card.

All information is retrieved using the SNMP protocol.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Ok                      |

Supported firmware versions

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Required. Format: "\<chassis id\>.\<slot id\>", e.g. "1.5".

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Configuration

No additional configuration is necessary in the element.

## Usage

### General

This page contains general information of the device, such as the **name** and **temperature**. Additionally, the most important statuses of the different channels that are managed by this card are available on this page.

### Channel x page

The information of each channel is displayed on a separate page. Each channel contains at least the following parameters:

- **Admin State**
- **Operational State**
- **Secondary States**
- **Facility Type**
- **Alias**
- **ALS**
- **Wavelength**
- **Fiber Type**
- **Frequency**
- **Connector**
- **Connectivity Type**

Some of the channels also display configuration parameters.

### Embedded Web Server

Displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
