---
uid: Connector_help_Aten_PE6324
---

# Aten PE6324

The ATEN NRGence PE6324 PDU is a green energy power distribution unit (PDU) that effectively increases the efficiency of data center power usage. The ATEN PE6324 connector is a solution designed to monitor this device.

This connector uses **SNMP** to retrieve and update data on the device. With this communication it is possible to fully monitor and remotely control the PDU.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                   | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                                                                                                                                                                   | \-           | \-                |
| 1.0.1.x \[SLC Main\] | \- Changed the column descriptions to match the current guidelines and use parentheses instead of square brackets. - Changed discretes to be consistent in the connector. - Updated measurements to the correct type. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device.
- **Set community string**: The community string needed to set to the device.

### Web interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### Device

This page displays the **Device Name** and **Model**, **Device Measurements**, **Device Info**, **Outlet information**, and **CAP** and **POP** parameters.

The page also contains the following page buttons:

- **Device Config**: Allows you to configure thresholds for the device.
- **Outlet Status**: Displays a table with the state of each of the outlets.
- **CAP Table**: Displays the Outlet CAP Table.

### Sensors

This page displays information about the sensors and allows you to configure their thresholds.

### Outlet

This page displays the current status of the outlets. It also contains two page buttons, **Measurements** and **Configuration**, which allow you to check the corresponding electric values and to configure the parameters of the outlets, respectively.

### Bank

This page contains information about the banks, as well as a configuration table where you can set the thresholds for the bank parameters.

### Configuration

This page contains several sections with settings: **Device Configuration**, **Dashboard**, **Service Ports**, **Device SNMP** and **Syslog**. Page buttons allow access to further settings related to **IP Config**, **SMTP**, **Time Settings** and **User Management**. Finally, the **Reboot Device** button can be used to remotely reboot the device.

### Security

This page contains information regarding the security of the device, such as **Login Failures**, **Working Mode**, **Radius**, **Login Registration** and **Account Policy**.
