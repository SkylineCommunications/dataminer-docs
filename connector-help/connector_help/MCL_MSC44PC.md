---
uid: Connector_help_MCL_MSC44PC
---

# MCL MSC44PC

The MCL MSC44PC is a VPC redundant TWTA system by MCL (licensed by Miteq).

## About

With this connector it is possible to configure and monitor the positions of the switches, the main parameters of the two HPAs, the PSU state and the current alarms on the device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP connection**

- **IP address/host:** The polling IP of the device.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. There are **8 pages** available.

### General

Includes general information such as the **device name**, **location** and **serial** and **model** numbers. The page also indicates what modules are installed (**Output Maintenance Switches**, **HPA AC Power Control**, **Ethernet**, **Power Metering**).

### Switch View

On this page, you can monitor the state or change the **position** of the **VPC**, **maintenance** and **polarization switches**.

### HPA A

This page contains the main configuration parameters of HPA A (**Software version** and **revision**, **alarm summary**, **tube mode**, **attenuation** (from HPA and switch positions), **forward** and **reflected power**, **baud rate**, **helix current**, **RF state**, etc.). It's also possible to **enable**/**disable** the HPA's **serial interfaces**.

### HPA B

This page contains the main configuration parameters of HPA B, which are similar to the parameters described for the page above.

### Dynamic Values

This page contains **miscellaneous readings** such as the device **temperature**, the **PSU voltage** and the **forward** and **null power** values.

### Configuration

This page contains miscellaneous configuration options, such us **networking**, **trap configuration** and **SNMP**/**HTTP** **configuration**. There's an additional page button with even **more options**: **Thresholds** for power and **temperature** meter alarms, **control mode**, **auto switch behavior** and remote **CSP baud rate**.

### Alarms

This page displays the **alarmed modules** within the equipment such as **power** and **temperature** meters, cable and cover **interlocks**, **stuck keys**, HPA **communications**, HPA **control modes**, **power supplies**, **attenuators** and local and remote **panels**.

### Web Interface

This page displays the web interface of the device.
