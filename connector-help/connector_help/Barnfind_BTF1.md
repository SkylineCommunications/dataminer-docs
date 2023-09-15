---
uid: Connector_help_Barnfind_BTF1
---

# Barnfind BTF1

The **Barnfind BTF1** connector is an **SNMP** connector that is used in order to monitor an **Input and Output Port Table** with **Matrix** layout.

## About

This connector displays an **Input Port Table** and **Output Port Table**. The link between the two is set in the **Output Port Table** as **InputPortOutputPort**. These two tables make it possible to generate a **Matrix** with the necessary **crosspoints**.

### Version Info

| **Range** | **Description**                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                    | No                  | Yes                     |
| 1.0.1.x          | Current version                    | No                  | Yes                     |
| 1.1.0.x          | Compatible with firmware v. 0.2.96 | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |
| 1.1.0.x          | 0.2.96                      |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

- **IP address/host:** The polling IP of the device.
- **Port:** The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### Matrix

This page displays the complete matrix with all the crosspoints. The crosspoints can be modified in the matrix.

The labels come from the **Output Label** and **Input Label** parameters in the **Output Ports Table** and **Input Ports Table**.

### Inputs

This page displays the **Input Ports Table**, which lists all input ports with their names, labels and parameters. The **Input Label** can be edited as normal text and the other editable parameters can be changed from a list.

### Outputs

This page displays the **Output Ports Table**, which lists all output ports with their names, labels, linked input port and parameters. The **Output Label** can be edited as normal text, the **InputPortOutputPort** is a list with all possible input ports, and the other editable parameters can be changed from a list.

### General

This page displays the **Model**, **Serial Number** and all **Diagnostics**, such as the temperature, RPM and voltage.

In addition, there are page buttons linking to **SFP Info, Hardware** and **Firmware:**

- The **SPF Info** subpage displays all **Common** and **Smart** info on all available SFPs.
- The **Hardware** subpage displays every possible **Hardware Type** and all the **Hardware Type Parameters**. These are linked and are used to fill in the correct parameters in the **Inputs** and **Outputs**.
- On the **Firmware** subpage, you can check for firmware upgrades and view the relevant log. If an upgrade is available, you can do a **Firmware Upgrade**.

### Automatic Change Over

This page displays a tree control containing the output table and the **automatic change over** table for each row. It allows you to configure all automatic change over parameters. This includes the enabling and disabling of each input interface.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface. In addition, the QBit Q561 web interface is not currently supported by Internet Explorer.
