---
uid: Connector_help_Sony_XVS-G1
---

# Sony XVS-G1

The Sony XVS-G1 is a vision mixer controller to which different cards can be attached: the ICP-X1116, ICP-X1124, ICP-X1216, and ICP-X1224.

## About

| **Range**            | **Key Features**  | **Based on** | **System Impact** |
|----------------------|-------------------|--------------|-------------------|
| 1.0.0.x              | Initial version   | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Added DCF support | 1.0.0.3      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default value *public*.
- **Set community string**: The community string used when setting values on the device, by default value *private*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created using the 1.0.0.x range of the connector has the following data pages:

- **General**: This page contains general information, such as the **System Description**, **System Up Time**, **System Contact**, **Name**, and **Location**. It also displays an overview of the **OSI Model** of the availability of each layer, as well as the Agent and Switcher **MIB Versions**.
- **Network**: This page displays the **Interfaces** and **Address Translation** tables. The Interfaces table displays the operational status of the interfaces available in the workstation. This operational status can also change based on incoming traps.
- **Product Information**: This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables.
- **Traps**: This page displays the **Traps Destination** table.
- **Alarms**: This page displays the **Error Status** table. This table is cleared when a "Coldstart" trap is received.
- **Configuration**: This page displays the **CTRL1, 2, 3**, and **4** configuration settings and the **SWR1** and **SWR2** configuration settings. Each has a **Status**; this can be enabled or disabled. When a resource is created, these statuses will be taken into consideration. When the status is enabled, the resource will contain this parameter; otherwise, it will not contain this parameter.
- **XVS Control**: This page allows you to check which XVS G1 element is connected to which the XVS G1 via the **Control Interfaces** table. There is a **Resubscribe** button to reset all the created subscriptions.
- **Agent MIB**: This page displays the **Agent MIB Categories** and **Agent MIB Products** tables.
- **Switcher**: This page displays the **Agent MIB Categories** and **Agent MIB Products** tables.
- **Product Information**: This page displays the **Switcher Reference Information**, **Switcher Temperature Information**, **Switcher Fan Information**, **Switcher Power Sensors**, **Switcher SSD Information**, and **Switcher Battery Information** tables.
