---
uid: Connector_help_Socomec_Diris_D-50
---

# Socomec Diris D-50

The Socomec Diris D-50 is a Control and Power Supply Interface. This connector can be used to monitor and control this device.

## About

The DIRIS Digiware D-50 is a master device on the RS485 bus and master on the DIRIS Digiware bus. It can display measurements from other Socomec counters and measuring units such as Countis, Diris A and Diris B. It centralizes data from up to 32 devices with a maximum of 186 outputs.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | True                    |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

### Exported connectors

| **Exported Connector**     | **Description**            |
|---------------------------|----------------------------|
| Socomec Diris D-50 - B-30 | Power Monitoring Device    |
| Socomec Diris D-50 - I-60 | Current Measurement Module |
| Socomec Diris D-50 - U-30 | Voltage Measurement Module |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### General

This page contains all the configuration General Information of the device. It shows the Diris D-50 Product Identification parameters such as **Product ID**, **JBUS Table** and **Software Version**, **Customization Data Loaded**, **Vendor**, **Product** and **Extended Name**, **Resource Version** and **Network ID**. It also displays the **Product Major** and **Minor Versions**, **Product Version** and **Build Date** along with **Software Technical Base Version** which has a **Major** and **Minor** options and the **Serial AA SS**, **SST L**, **Order** and **Reserve**.

### Connection Info

This page contains all the configuration General Information such as the **Ethernet IP Address**, **Gate** and **Mask**, the **JBUS Gateway Status**, **Baudrate**, **Parity**, **Stop Bit** and **DHCP Status**.

### Device Overview

This page shows the **Devices Table** which contains all the Devices present on the current configuration along with their most important parameters. It also displays the **Overall Polling Status** and the **Polling Steps** parameters. The **DVE Overview** subpage contains the **B30**, **I60** and **U30 DVEs** Tables, where the created DVEs will be displayed. It also shows the **Automatic Delete Missing Devices** button that will automatically removed the deleted devices.
