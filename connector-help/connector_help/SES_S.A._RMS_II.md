---
uid: Connector_help_SES_S.A._RMS_II
---

# SES S.A. RMS II

The SES S.A. RMS II connector can be used to monitor the attenuation calculated by RMS II devices.

## About

The Radiometer Server II offers the possibility to receive atmospheric attenuation calculated for a specific frequency and radiometer using TCP/IP.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The required IP port of the device. The range of port numbers is 1 to 65535**.**
  - **Bus address**: The bus address of the device. Default value is 66, with a range of 64 to 90.

## Usage

### General

On this page, you can see and manipulate the **Radiometers**. Each request requires the Radiometer **ID** and **Frequency** and the **Protocol Version Number** found on the **Advanced** page. For all entries in the table, the **Attenuation**, **Sky Noise**, and **Status** are filled in. If there is a status message to show, it is displayed in the **Error Description** column.

### Advanced

The RMS II **Protocol Version Number** must be filled in on this page to send correct requests to the RMS II device.

It is also possible to click **Import File** on this page, in order to immediately load radiometers from a .CSV file. If the file you want to import is not in the drop-down menu, you can **Refresh** the list. You can also **Export Radiometers** to a .CSV file, which will be stored in C:\Skyline DataMiner\Documents\SES S.A. RMS II**.** Imported files must be stored there as well. If there is a problem with importing or exporting, the **Import/Export Status** will display "Fail".

Normally, importing a .CSV file will not remove any existing rows in the **Radiometers** table. However, if the **Auto Delete Radiometers** option is enabled, only the imported .CSV rows will be displayed.
