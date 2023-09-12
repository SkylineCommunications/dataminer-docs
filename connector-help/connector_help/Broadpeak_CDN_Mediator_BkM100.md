---
uid: Connector_help_Broadpeak_CDN_Mediator_BkM100
---

# Broadpeak CDN Mediator BkM100

The **Broadpeak CDN Mediator BkM100** driver can be used to display information of any related device. This protocol can be used to monitor the Broadpeak CDN Mediator BkM100. An **SNMP** connection and **SNMP TRAPS** are used to successfully retrieve the device's information.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (fixed value: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages detailed below.

### Overview

This page displays a POP-related tree control.

### CDN

This page contains the following information related to the **CDN Back Office** and **CDN Front Office**:

- General: Availability, Version, and Date Process Last Restart.
- Alarm monitoring: Interface Level, Process Level, Settings Level, etc.
- Counters: Session, Session Error, Provisioning, and Provisioning Error.

### Bandwidth Manager

You can find the following information related to the Bandwidth Manager here:

- General: Availability, Version, and Date Process Last Restart.
- Alarm monitoring: Interface Level, Process Level, Settings Level, etc.
- Counters: Reservation request and errors.

### Geolocalizer

You can find the following information related to the Geolocalizer here:

- General: Availability, Version, and Date Process Last Restart.
- Alarm monitoring: Interface Level, Process Level, and Settings Level.
- Counters: Localization request and errors.

### POP Manager

You can find the following information related to the POP Manager here:

- General: Availability and Version.

- Alarm monitoring: Provisioning Level, Session Level, and Topology Level.

- Subpages:

- **POP**: Overview of POP information.
  - **MLI**: Overview of Media Library information.
  - **Video Server**: Overview of Video Server information.
  - **QOE**: Overview of QOE Server information.
