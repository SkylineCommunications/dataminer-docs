---
uid: Connector_help_Viavi_Solutions_ONA-800
---

# Viavi Solutions ONA-800

The ONA-800 is a modular communications test and measurement instrument that can be used both indoors and outdoors.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device is not required.

### Initialization

The connector can support multiple features of the device. On the **General** page, you can enable the features you need and disable the unwanted features. This way, less polling is needed.

On the device itself, the **pages of the supported features must be opened**. If the pages are not opened directly on the device itself, it blocks the calls to these features.

### Redundancy

No redundancy is defined in the connector.

## How to Use

On the **General** page of the element, you can find the basic device information. This page also allows you to enable and disable features of the device. Polling only happens for the enabled features.

On the **Preset** page of the element, you can set a preset for the NR5G Beam Analyzer feature. This sets the device to the specified **Center Frequency**, **Bandwidth**, **SSB** and **Channel Number**.

On the subpage **NR 5G Beam Analyzer History**, you can see the history of all data received for the Beam Analyzer. You can also configure the automatic cleaning of the table here. This can be enabled using the parameter **Activation History Removal**. If it is activated, the table will remove entries based on how much time has passed since the last update. You can set the removal time delay with the parameter **History Remove Time**.

Note: For the connector to function successfully, the corresponding pages must be opened on the device. If this is not the case, the data cannot be polled correctly.

## Notes

This connection is a combination of modules. Each module is to be used individually. The current functionality also needs to be open on the device interface for the connector to function properly.
