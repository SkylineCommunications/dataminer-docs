---
uid: Connector_help_Rohde_Schwarz_FSC3
---

# Rohde Schwarz FSC3

The Rohde Schwarz FSC3 is a spectrum analyzer device.

This connector interfaces with the spectrum analyzer and allows you to monitor the spectrum of any connected signal. It also allows for basic configuration of the device.

The connector communicates with the spectrum analyzer using the VISA (Virtual Instrument Software Architecture) API.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.40                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

This connector requires that the VISA library is installed on the DataMiner Agent. The installer for the library can be downloaded from the [Rohde-Schwarz website](https://www.rohde-schwarz.com/us/driver-pages/remote-control/3-visa-and-tools_231388.html).

*RsInstrument.dll* must also be present in the *C:\Skyline DataMiner\ProtocolScripts* folder of the DataMiner Agent.

## How to Use

On the **General** page, the **IP Address** parameter must be filled in order for the polling to start. That page also displays generic information like the **Serial Number** and the **Firmware**.

The spectrum can be observed on the **Spectrum** **Analyzer** page.
