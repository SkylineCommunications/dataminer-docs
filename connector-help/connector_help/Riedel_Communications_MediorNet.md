---
uid: Connector_help_Riedel_Communications_MediorNet
---

# Riedel Communications MediorNet

The Riedel Communications MediorNet connector is used to monitor the Riedel Communications MediorNet processor.

This connector uses SNMP to retrieve a list of cards of the **Riedel Communications MediorNetProcessor**. For each **GPI slot**, **Link slot** and **Video slot**, a connector is **exported**.

## About

### Version Info

| **Range** | **Key Features**                         | **Based on** | **System Impact** |
|-----------|------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version                          | \-           | \-                |
| 1.0.1.x   | Added smart-serial connection for Ember+ | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.00                   |
| 1.0.1.x   | 1.00                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                            | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \- Riedel Communications MediorNet - Link Module - Riedel Communications MediorNet - Video Module - Riedel Communications MediorNet - GPI Module | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*

#### IP Connection

This connector uses a serial connection (**Ember+ gateway**) and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *9000*).

## How to Use

The element consists of the data pages detailed below.

### Frame

This page displays information about the Riedel Communications MediorNet Frame, which houses the processor modules.

### Slot Table

This page displays all the slots on the frame.

### Link DVE Table

This page lists the link modules in the frame for which DVEs are exported and allows you to change the DVE names.

### Video DVE Table

This page displays the video modules in the frame for which DVEs are exported and allows you to change the DVE names.

### Gpi DVETable

This page displays the GPI modules in the frame for which DVEs are exported and allows you to change the DVE names.

### Video IP (from range 1.0.1.x onwards)

This page displays the **Video In IP** and **Video Out IP** tables.
