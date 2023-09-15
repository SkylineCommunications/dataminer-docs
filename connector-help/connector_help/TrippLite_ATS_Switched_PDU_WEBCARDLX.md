---
uid: Connector_help_TrippLite_ATS_Switched_PDU_WEBCARDLX
---

# TrippLite ATS Switched PDU WEBCARDLX

The PDU line of devices from TrippLite allow for the use of multiple outlets, but does not guard against surge or line noise protection for connected equipment.

## About

The TrippLite ATS Switched PDU WEBCARDLX connector allows for configuration and monitoring of several ATS and EnviroSense devices.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x \[SLC Main\] | 15.5.1                      |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) version 3 connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

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

This page displays all the generic information of the connected devices, including the number of **ATS Devices** and **EnviroSense Devices**.

The **Devices** table allows for monitoring of the different devices and configuration of the **Name, ID, Location,** and **Region**.

### ATS Page

All of the information regarding the ATS devices can be found using this page.

The **ATS** **Device Info** table contains mostly the status of the ATS device but also allows for commanding the **Main Load** and the configuration of the **Power On** **Delay**.

The **ATS Display Info** table allows for configuration of the ATS **Scheme, Orientation, Auto Scrolling, Intensity**, and **Units.**

The **ATS Identity Info** table displays the amount of connections to the ATS, including the **Inputs**, **Outputs**, and **Outlets**.

Using page buttons, the following can be accessed:

- **Outlets:** contains information on the ATS outlets in the **Outlets** and **Outlet Groups** tables.
- **Inputs:** contains information on the ATS inputs in the **Inputs** and **Input Phase Info** tables.
- **Outputs:** displays the **Outputs** table with data on the outputs of the ATS.
- **Breakers**: displays the **Breakers** table with data on the breakers of the ATS.
- **Heat Sinks:** displays the **Heat Sinks** table with data on the heat sinks of the ATS.
- **Circuits:** displays the **Circuits** table with data on the circuits on the ATS.
- **Supports:** displays the **ATS Supports** table with the various supported functions of a ATS.
- **Controls:** allows the user to run several commands via buttons in the **Controls** table.
- **Configuration:** displays the **Configuration** and **Threshold Config** tables which allow the user to configure the device source and threshold information.
- **Voltage Ranges:** displays the **Voltage Range Config** and **Voltage Range Limits** table with configuration parameters for the ATS voltage ranges.

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
