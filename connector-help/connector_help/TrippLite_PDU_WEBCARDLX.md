---
uid: Connector_help_TrippLite_PDU_WEBCARDLX
---

# TrippLite PDU WEBCARDLX

 The PDU line of devices from TrippLite allow for the use of multiple outlets, but does not guard against surge or line noise protection for connected equipment.

## About

The TrippLite PDU WEBCARDLX connector allows for configuration and monitoring of several PDU and EnviroSense devices.

### Version Info

| Range            | Key Features | Based on | System Impact |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial version. | -           | -                |

### Product Info

| Range | Supported Firmware |
|-----------|------------------------|
| 1.0.0.x   | -                     |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                    | -                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Security level and protocol**: The level of security used for the SNMPv3 communication, either no authorization or privacy (noAuthNoPriv), authorization but no privacy (authNoPriv), or authorization and privacy (authPriv).
- **User name**: The user name used for the connection with the device.
- **Authentication password:** The password used during the authorization process.
- **Encryption password:** The password used for decryption private information
- **Authentication algorithm:** The algorithm used for the authentication.
- **Encryption algorithm:** The algorithm used for the encryption.

## Usage

### General Page

This page displays all the generic information of the connected devices, including the number of **PDU Devices** and **EnviroSense Devices**.

The **Devices** table allows for monitoring of the different devices and configuration of the **Name, ID, Location,** and **Region**.

### PDU Page

All of the information regarding the PDU devices can be found using this page.

The **PDU** **Device Info** table contains mostly the status of the PDU device but also allows for commanding the **Main Load** and the configuration of the **Power On** **Delay**.

The **PDU Display Info** table allows for configuration of the PDU **Scheme, Orientation, Auto Scrolling, Intensity,** and **Units.**

The **PDU Identity Info** table displays the amount of connections to the PDU, including the **Inputs, Outputs** and **Outlets**.

Using page buttons, the following can be accessed:

- **Outlets:** contains information on the PDU outlets in the **Outlets** and **Outlet Groups** tables.
- **Inputs:** contains information on the PDU inputs in the **Inputs** and **Input Phase Info** tables.
- **Outputs:** displays the **Outputs** table with data on the outputs of the PDUs.
- **Breakers**: displays the **Breakers** table with data on the breakers of the PDUs.
- **Heat Sinks:** displays the **Heat Sinks** table with data on the heat sinks of the PDUs.
- **Circuits:** displays the **Circuits** table with data on the circuits on the PDUs.
- **Supports:** displays the **PDU Supports** table with the various supported functions of a PDU.
- **Configuration:** the **Controls** and **Configuration** tables allows the user to perform commands and changes on the PDU.

### EnviroSense Page

All of the information regarding the EnviroSense devices can be found using this page. Polling of the EnviroSense information can be enabled or disabled using the **Poll EnviroSense Info** toggle button.

The **EnviroSense Identity Info** table displays if the **Temperature** and **Humidity** is supported and the number of **Input** and **Output Contacts.**

The **EnviroSense Configuration** table allows for configuration of the **Temperature** and **Humidity Limits.**

Using page buttons, the following can be accessed:

- **Contacts:** contains the **Input** and **Output Contacts** table.
- **Temperature:** the temperature status of the EnviroSense device is displayed in the **Temperature Info** table.
- **Humidity:** the humidity status of the EnviroSense device is displayed in the **Humidity Info** table.

### Web Interface Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
