---
uid: Connector_help_Plisch_SCU_Dual_Drive_DVB
---

# Plisch SCU Dual Drive DVB

Plisch SCU Dual Drive DVB is a transmitter that can broadcast live 4K (Ultra HD). This connector allows you to monitor information related to different aspects of the device, and also to control the entire device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: 161
- **Get community string**: public
- **Set community string**: private

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below. For each of the pages, you can **enable or disable polling**.

### General

This page contains the main settings to control the device, including input **pre-selection**, **pre-selection mode**, **switch over control**, **events enabling** and **events priority**.

It also allows you to monitor the **amplifier state**, the **active exciter**, the **operation mode** and the **control unit** live status. You can also force a **fault reset**. If polling is enabled, the refresh button allows you to trigger a live refresh.

### SCU General

This page contains general parameters such as the **system description**, **OID** and **system up time**. The **system OR last change** displays the uptime of the latest system change.

This page also allows you to monitor SCU general parameters such as **reserve system type**, **general control mode**, **warning**, **alarms** and **operation states**. In addition, you can perform a **system reset** and **switch over control**.

### DAB General

On this page, you can configure general parameters such as input **pre-selection**, **pre-selection mode**, **events enabling** and **events priority**.

You can also monitor the **amplifier state**, the **active exciter**, the **operation mode** and the **control unit** live status. You can also force a **fault reset**. If polling is enabled, the refresh button allows you to trigger a live refresh.

### Dual Drive

This page contains the main monitoring parameters regarding **change over**, **switch over**, **power**, **alarms** and **amplifiers**. It also allows **system** and **program** **configuration** and **control**.

### Tx Notify

This page allows you to monitor parameters related to transmitter notification, including **exciter states**, **amplifiers**, **inputs** and **power**.

### Tx Output

This page allows you to monitor all parameters related to the **transmitter** **output**, and also to **control** the output setup.

### Tx Amplifiers

This page contains two tables that allow you to monitor the amplifiers, **Tx Amplifiers Config** and **Tx Amplifiers Statistics**.

### Tx System

This page contains **Tx System Configuration** and **Tx System Statistics** information, allowing quick live monitoring of the main transmitter system parameters.

### Tx Operation

This page allows you to monitor and configure the main **transmitter operation** parameters.

### Tx Channels

This page allows you to **control** all configurable parameters regarding **channel regions**.

### Exciter

This page allows you to monitor both **exciters** (A and B). You can also control every parameter accessible via the **events enabling** and **priority** pages.

### Exciter A/B Stats

These pages contain the statistical summary for exciter A and B, respectively.

### DAB Exciter

This page allows you to monitor both DAB **exciters** (A and B). You can also control every parameter accessible via the **events enabling** and **priority** pages.

### VTX

This page allows you to monitor the **VTX parameters** from **exciters**, **transmitters**, **inputs**, etc.
