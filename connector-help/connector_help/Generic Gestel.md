---
uid: Connector_help_Generic_Gestel
---

# Generic Gestel

The driver implements a proprietary protocol called Gestel, which is a layered structured protocol specifically designed for communication applications between remote control and telemetry stations.

Dataminer acts as the Master station initializing the communication with the Remote station.
The Remote Station is made up of a maximum of 128 modules, numbered from 0 to 127. Each module can be one of the following types:

- Digital inputs
- Digital outputs
- Analog inputs
- Analog outputs

Each module has a maximum of 16 channels, regardless of the type of module in question. The channel is a processed signal, so that each channel can correspond to one or more physical signals.

## About

### Version Info

| **Range** | **Key Features**             | **Based on** | **System Impact** |
|-----------|------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version \[SLC Main\] | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x-  | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes/No                  | \-                    | \-                      |

## Configuration

- *Smart-Serial Main Connection*

    This driver uses a Smart-Serial connection and requires the following input during element creation:

    SMART-SERIAL CONNECTION:

    - **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
    - **IP port**: The IP port of the device, e.g. *161*.
    - **Bus address**: The bus address of the device, e.g. *1*.

### Initialization

A configuration file must be imported with the node parameters to be polled. The file should be placed in one of the following paths:

- C:\Skyline DataMiner\Documents\Elements\XERT_III_RTU_GESTEL.xlsx
- C:\Skyline DataMiner\Documents\Protocol\XERT_III_RTU_GESTEL.xlsx

![](~/connector-help/images/Generic_Gestel_)![]()

### Redundancy

There is no redundancy defined.

## How to use

- **General**: This page shows basic information about the Remote Terminal Unit (RTU):

- Connection Status: Connected, Not Connected or Timeout.
  - Last Reboot Detected - Indicates the last time the RTU was rebooted.
  - RTU DateTime - Indicates the current RTU's datetime.
  - Stational State - Indicates whether the RTU is in summer or winter time.
  - Server DateTime - Indicates the current server's datetime.
  - Information Message - Errors and information events are displayed here.
  - Synchronization Threshold Value - Represents the maximum time difference between the server's datetime and the RTU's datetime.
  - Timeout Value- The element enters timeout if the predefined value is reached and no incoming messages are received.
  - Buttons: Station Boot, Write in Memory, SoftReset and Hard Reset

<!-- -->

- **Configuration**: The Metadata table displays the RTU's configuration after importing the file.
- **Digital I/O**: Allows the user to monitor input and output digital signals.
- **Analog I/O**: Allows the user to monitor input and output analog signals.

### Web Interface

No webinterface available.


