---
uid: Connector_help_Evertz_XPRF14
---

# Evertz XPRF14

The **Evertz XPRF14** is a wideband, non-blocking, full fan-out RF router system supporting signals from 850 MHz to 2.3 GHz. This includes L-band and other applications. A single system supports 128x128, but can be combined with multiple units to support 2048x2048.

## About

This connector allows communication to and from the ScheduAll Manager, simulating the usual communication of the ScheduAll Web Service and Interop Service.

The connector can be used to configure, control and view the XPRF14-FR router system. It contains a matrix interface to view, add or remove connections.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.1 \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.2 Build 289-A             |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page contains **general information** about the XPRF14-FR router system. This also includes a **Reset** button, which you can use to reset the system.

### System

This page contains the **Card Status**, **Product Features Supported**, **Power Supply** and **Fan Status tables**.

### Engineering

This page contains the system's **engineering parameters**. This includes the ability to do a **system restore** and to **download** the **factory tech file**.

The page also contains other parameters, such as the **FC Serial Number** and **Board Revision**.

### Input

This page contains the Inputs table, which allows you to control the **Gain Control**, **Power Gain** and **LNB Power** of the inputs. The table also shows the **Power Status** of channels A and B.

### Output

This page contains the Output table. For each output channel, the **Output Name** column in this table displays the actual name of that output channel. For each output, a button is also available that allows you to **enable** **or** **disable** **the output**. The **Input Source** column allows you to manually specify an input for a specified output. This will then be shown in the matrix on the **Crosspoints page**. The **Output Power Gain**, **Output Power Raw**, and **AGC Gain** columns allow you to specify a value in **dBm** for a specific output.

### Crosspoint

This page contains the **Matrix Control** for the input and outputs of the XPRF14-FR router system. The matrix allows you to **set** and **remove crosspoints.** The result of this will be reflected in the **Outputs Table**.

### Traps

This page contains the **Traps Destination Table**, **System Traps** and the **IO Card Traps** in the form of a tree control. To **enable or disable traps**, press the toggle button for the corresponding table or tree control.

### IO Traps

This page contains **input** and **output** **trap tables** for all inputs and outputs. The controls on this page are similar to those on the Traps page.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise, it will not be possible to open the web interface.

## Revision History

DATE VERSION AUTHOR COMMENTS

19/12/2017 1.0.0.1 JBR, Skyline Initial version.

12/03/2018 1.0.0.1 AGA, Skyline Fixed issues with the matrix in initial version (before QA).

24/06/2018 1.0.0.2 RBL, Skyline Issues fixed: trapDestination Set, trap repolling implemented, faultPresent wrong status.
