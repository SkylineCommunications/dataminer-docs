---
uid: Connector_help_Ross_Video_General_Frame
---

# Ross Video General Frame

The Ross Video General Frame connector can monitor **product**, **hardware**, **power**,and **network** parameters. The device it monitors is a 2RU frame controller.

**SNMP** polling is used to retrieve the device information.

This connector will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors" below.

## About

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|-----------|-----------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Software version 2.50  |

### Exported Connectors

| **Exported Protocol**                                                                                             | **Description**       |
|-------------------------------------------------------------------------------------------------------------------|-----------------------|
| [Cobalt Digital 9004](xref:Connector_help_Ross_Video_General_Frame_-_Cobalt_Digital_9004)           | Card 9004 Module      |
| [Cobalt Digital 9006](xref:Connector_help_Ross_Video_General_Frame_-_Cobalt_Digital_9006)           | Card 9006 Module      |
| [Cobalt Digital 9223](xref:Connector_help_Ross_Video_General_Frame_-_Cobalt_Digital_9223)           | Card 9223 Module      |
| [Cobalt Digital 9970-QS](xref:Connector_help_Ross_Video_General_Frame_-_Cobalt_Digital_9970-QS)     | Card 9970-QS Module   |
| [Cobalt Digital 9902-UDX](xref:Connector_help_Ross_Video_General_Frame_-_Cobalt_Digital_9902-UDX)   | Card 9902-UDX Module  |
| [Cobalt Digital 9902-2UDX](xref:Connector_help_Ross_Video_General_Frame_-_Cobalt_Digital_9902-2UDX) | Card 9902-2UDX Module |
| [Cobalt Digital CDI-9363](xref:Connector_help_Ross_Video_General_Frame_-_Cobalt_Digital_CDI-9363)   | Card CDI-9363 Module  |
| [Cobalt Digital 9960](xref:Connector_help_Ross_Video_General_Frame_-_Cobalt_Digital_9960)           | Card 9960 Module      |
| [Cobalt Digital 9922](xref:Connector_help_Ross_Video_General_Frame_-_Cobalt_Digital_9922)           | Card 9922 Module      |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: *161*
- **Get community string**: *public*
- **Set community string**: *private*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General

This page contains 4 page buttons: **Product**, **Hardware**, **Power**, and **Network:**

- The **Product** subpage displays information about the frame: **Name**, **Serial Number**, **Product**, **Software Version**, and the **Installed Slots**
- The **Hardware** subpage displays status information: **Frame Status**, **Safe State**, **Voltage**, etc.
- The **Power** subpage displays status information: **PSU1** and **PSU2 Current**, **Frame Power**, **PSU1** and **PSU2 Temperature**, etc.
- The **Network** subpage displays node information: **Node Name**, **IP Address**, etc.

### Slots

This page displays a table with all the active and supported slots that are connected to the device. It allows you to change the view and the name for the DVEs.

If **Automatic DVE Deletion** is enabled, a DVE element will be deleted when the corresponding card is removed.
