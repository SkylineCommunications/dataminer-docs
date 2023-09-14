---
uid: Connector_help_Evertz_MVP-DEC-4-IP
---

# Evertz MVP-DEC-4-IP

This device is a bulk IP MPEG decoding/monitoring input solution for the MVPr System.

## About

This connector allows you to monitor and configure the Evertz MVP-DEC-4-IP device using an SNMP connection.

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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Video

This page contains information about the **current video streams** being decoded.

### Audio

This page contains information about the **current audio streams** being decoded.

It also contains a button that allows you to view the monitored **Audio Channels** and see if any **faults** are present. It also allows you to configure if **traps** are sent in case problems happen.

### Subtitles

On this page, you can configure the **Subtitles** options, such as **Type**, **Service**, **Language** and **Page**. Optional **Thumbnail** options are also available, such as **Server**, **Bandwidth**, **Size** and **Engine**.

### Controls

This is the **default** page. It allows you to configure the **connected inputs**, including their **names**, **types**, **URLs** and **statuses**. You can also configure IGMP options such as **Host** and **Visibility**.

### MVP ID

This page displays the **current MVPs** and their respective **IDs**.

### Monitoring

This page only contains page buttons, which open subpages where you can configure the management **trap notifications** and the **fault state** associated with the current items in the sections **Audio**, **Video**, **Channel**, **Metadata**, **Program** and **Sources**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

This connector does not have a "General" page, as the available MIB files do not show general purpose information.
