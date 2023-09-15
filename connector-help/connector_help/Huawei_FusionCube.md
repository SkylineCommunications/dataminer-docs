---
uid: Connector_help_Huawei_FusionCube
---

# Huawei FusionCube

This connector monitors the Huawei FusionCube hardware. The FusionCube provides a virtualized platform and cloud applications.

## About

Huawei FusionCube is a hyper-converged infrastructure, which consists of computing, storage, network, virtualization, and management systems. It is mainly used for virtualization of services and infrastructure.

### Version Info

| **Range**         | **Description** | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x **\[SLC Main\]** | Initial version | No                  | Yes                     |

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

- **IP port**: The IP port of the device. The default FusionCube SNMP port is *20161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information about the device. This includes the **LAN Status** and the list of **VM Guests**.

It also shows the **Alarm Update Status**, i.e. if the alarm page is being updated or not.

### HW Resources

This page details the hardware resources of the device. It contains information about the Virtual Machine **Hosts**, **Clusters** and **Storage**.

### Alarms

This page shows the currently active alarms associated with the device. Depending on how many alarms are in the system, it may take a while for this page to load.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
