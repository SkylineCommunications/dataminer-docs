---
uid: Connector_help_Rohde_Schwarz_THR9_FM_Single_Drive
---

# Rohde Schwarz THR9 FM Single Drive

The Rohde Schwarz THR9 high-power FM transmitter makes terrestrial broadcasting of audio broadcast signals extremely efficient.

Liquid cooling and multiple transmitters are integrated in a single rack. The liquid-cooled transmitters deliver FM output power of up to 40 kW per rack.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Initialization

No additional configuration is required.

### Redundancy

No redundancy is defined in the driver.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page displays the **Single Transmitter Op Mode, Local Mode, Fault State** and **Transmitter Control Table**.

On this page, there are also the page buttons **Event Priority** and **Event Enable**. On the **Event Priority** page, there are the parameters **Transmitter Op Mode Priority, Fault Priority, Local Mode Priority ...** On the **Event Enable** page, there are the parameters **Transmitter Op Mode Enable, Fault Enable, Local Mode Enable,** etc.

### Liquid Cooling State

This page displays the **Liquid Cooling State Table**. This table contains information about **Inlet Temperature, Inlet Temperature Sensor Status, Outlet Temperature, Outlet Temperature Sensor**, etc.

### Liquid Cooling Notification

This page displays the **Liquid Cooling Notification Table**. This table contains information about the **Name** and the **State** for each liquid cooling notification.

### N+1 Notifications

This page displays the **N+1 Notification Table**. This table contains information about the **Name** and the **State** for each N+1 notification.

### Tx - Transmitters

This page displays the **Transmitter Notification Table** , which contains information about the **Name** of the **Transmitter Notification**.This page also displays the **Tx Transmitter State Table**, which contains information about the **Forward and Reflected Power, Power Amplifier Efficiency**, etc.

### Tx - Exciter

This page displays the **Exciter Notification Table**, which contains information about the **State** of the **Exciter Notification**.

This page also displays the **Exciter Commands Table**, which contains information about the **Frequency, Modulation Mode and Output Attenuation**.

### Tx - Input/Output

This page displays the **FM Input Stage Notification Table**, which contains information about the state of the FM input stage notification.

This page also displays the **Output Stage Notification Table**, which contains information about the state of the output stage notification.

### Tx - Amplifier

This page displays the **Tx Amplifier Phr901 Table**, which contains information about the **Power Input, Power Driver**, etc.

### Tx - Amplifier State

This page displays the **Tx Amplifier State Table**, which contains information about the **Status Power, Power Out** and **Amplifier Stage Temperature**.

### UPS Info

This page displays the **UPS Table**.
