---
uid: Connector_help_Rohde_Schwarz_THR9_FM_Dual_Drive
---

# Rohde Schwarz THR9 FM Dual Drive

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

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page displays the **Transmitter Operation Mode State, Local Mode, Control Unit Fault** and the **Transmitter Control Table**.

It also contains the page buttons **Event Priority**, **Event Status**, **Exciter Info** and **UPS Info**.

### Liquid Cooling State

This page displays the **Liquid Cooling State Table**, the **Liquid Cooling Pump State Table** and the **Liquid Cooling Fan State Table**.

### Liquid Cooling Notification

This page displays the **Liquid Cooling Notification Table**.

### Liquid Cooling Configuration

This page displays the **Liquid Cooling Configuration Table**.

### Audio Signaling

This page displays the **FM Input General Setup Table** andthe **FM Deviation Table**.

### N+1 Notifications

This page displays the **N+1 Notification Table**.

### Tx - Transmitters

This page displays the **Transmitter State Table** and the **Transmitter Commands Table**.

### Tx - Exciter

This page displays the **Exciter Notification Table** and the **Exciter Commands Table**.

### Tx - Input/Output

This page displays the **Input Stage Notification Table** and the **Output Stage Notification Table**.

### Tx - Amplifier

This page displays the **Tx Amplifier Phr901 Power Table**, the **Tx Amplifier Phr901 Transistors Table** and the **Tx Amplifier State Table**.
