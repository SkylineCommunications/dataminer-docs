---
uid: Connector_help_Mier_Comunicaciones_50N0176_MTDT
---

# Mier Comunicaciones 50N0176 MTDT

This connector can be used in combination with a Mier Comunicaciones 50N0176 MTDT transmitter.

## About

With this connector, it is possible to monitor and configure the transmitter itself, as well as to enable the trap notifications and their priorities.

### Version Info

| **Range** | **Description**                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                 | No                  | No                      |
| 2.0.0.x          | Branch version based on 1.0.0.x | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device, by default *public.*
- **Set community string:** The community string used when setting values on the device, by default *private*.

### Configuration

Once the element has been created, go to the **System** page and update the **Poll** parameter to make the connector poll the device.

To enable the **LITE functionality** of the connector, go to the **Network Settings** page, and enable the parameter **Lite Protocol**.

## Usage

### System

This page contains system-critical parameters, such as **MUX State**, **Poll** and **IP Config**.

### Remodulator

This page displays transmission parameters, such as **MUX1 Transmission Mode**.

### Mux Data Trap Config

This page contains a list of **MUX Digital Input traps**. It is possible to configure these.

### Rack Data

This page contains parameters that display the **physical state** of the rack.

### Rack Data Trap Config

This page displays the **Analog Input traps** from the rack, as well as the rack's **Digital Input Traps** and its **Digital Output Traps**. It is possible to configure these.

### GPRS Data

This page displays state and configuration parameters for **GPRS**.

### MC Data

This page displays configuration parameters for **MC Data**.

### MC Data Trap Config

This page displays the **traps for each channel** of the device. It is possible to configure these.

### GPS Data

This page displays state and configuration parameters for **GPS**.

### GPS Data Trap Config

This page displays **configuration** parameters for **traps about GPS states**.

### Network Settings

This page contains the **Lite Protocol** toggle button.
