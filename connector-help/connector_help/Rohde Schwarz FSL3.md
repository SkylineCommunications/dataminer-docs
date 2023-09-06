---
uid: Connector_help_Rohde_Schwarz_FSL3
---

# Rohde Schwarz FSL3

The Rohde Schwarz FSL3 is alightweight and compact spectrum analyzer with the functionality of high-end instruments. It features a tracking generator up to 18 GHz and can analyze signals with a bandwidth of 28 MHz., operating at frequencies up to 18 GHz, and supporting applications in the microwave range. This driver communicates with the spectrum analyzer using serial communication (TCP/IP).

## About

### Version Info

| **Range** | **Key Features**                                                            | **Based on** | **System Impact** |
|-----------|-----------------------------------------------------------------------------|--------------|-------------------|
| 1.1.0.x   | Initial version.Version **1.1.0.8** supports a maximum frequency of 18 GHz. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.1.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

#### GPIB main connection

This driver uses a serial connection and requires the following input during element creation:

GPIB CONNECTION:

- Interface connection:

- **Device address**: The polling device address of the device.
  - **I/O API**: The I/O API of the device.

## Usage

On the **Spectrum Analyzer** page, you can find the spectrum analyzer user interface. For more information on how to work with this, refer to the [DataMiner Help](https://help.dataminer.services/dataminer/#t=DataMinerUserGuide/part_4/SpectrumAnalysis/Working_with_spectrum_analyzer_elements.htm%23XREF_82474_36_2_Working_with).

On the **General** page, you can find device information such as the Manufacturer, Model, Serial Number, Firmware Version and Display Status. The **DMS Spectrum Measurements** toggle button allows you to put the spectrum analyzer in automatic sweep mode.
