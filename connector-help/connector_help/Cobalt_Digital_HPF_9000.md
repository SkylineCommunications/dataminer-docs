---
uid: Connector_help_Cobalt_Digital_HPF_9000
---

# Cobalt Digital HPF 9000

The Cobalt Digital HPF 9000 is an SNMP connector for a modular frame. This frame consists of twenty slots for compatible cards. The function of the connector is to detect cards inserted into the various slots and display the information fetched via SNMP. The information can be exported to a DVE table if requested by the user, displaying detailed information of the card inserted into the specific slot.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial Version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   |                        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                          |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     |                       | [Cobalt Digital HPF 9000 - Cobalt Digital 9001](xref:Connector_help_Cobalt_Digital_HPF_9000_-_Cobalt_Digital_9001) |

## Configuration

### Connections

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: 183
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.



### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this SNMP connector consists of the data pulled from the individual cards inserted into the slots on the frame. A dynamic virtual element can be created by the SNMP connector via a toggle button. The user can toggle DVE creation for the specific card in the slot which exports the information virtually. In order to delete the virtual elements, there are buttons to delete each individual DVE and a clear all button.
