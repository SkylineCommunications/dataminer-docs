---
uid: Connector_help_Generic_Carrier_Monitor_Manager
---

# Generic Carrier Monitor Manager

The **Generic Carrier Monitor Manager** automatically performs sets on demodulator elements and retrieves the measurements.

## About

This connector can load measurement settings for carriers from a .csv file or database. Then these settings are executed on demodulator elements. When the demodulator can lock the signal, the measurement results are returned to the manager element. After that, the manager performs the settings for the next carrier to be measured on the demodulator element and so on.

In the 2.x.x.x range of the connector, DVEs are created using the **Generic Carrier Monitor Manager Device** protocol, which contain the measurements per demodulator element.

Current supported demodulator connectors are: Tandberg RX1290, Ericsson RX8330 and Newtec EL970.

### Version Info

| **Range** | **Description**                 |
|------------------|---------------------------------|
| 1.0.0.x          | Initial version                 |
| 2.0.0.x          | Import through DB, creates DVEs |

### Exported connectors

| **Exported Connector**                  | **Description**                 |
|----------------------------------------|---------------------------------|
| Generic Carrier Monitor Manager Device | Only supported in range 2.0.0.x |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not require any input during element creation.

### Configuration of the demodulator elements

To configure the demodulator elements:

1. Open the **General** page and click the **Settings** page button.

1. Click the **Refresh** button to find all the demodulator elements in the DMS.

1. Select an element in the **Add Element** parameter.

   This will add a new row to the **Element Table**. A DVE will also be created.

1. In this table, the following parameters should be configured:

   - **Element Alias**: Fill in a unique name. This will be used to refer from the **Measurement Table** to this element.

   - **Timeout Measurement**: This is the total amount of time that the manager should wait for results from the demodulator elements. If no results are returned within this time, the measurement row for this carrier is placed in timeout and the next carrier will be tested.

### Configuration of the .csv file

The **Measurement Table** will either be filled in by the .csv file or through the database. However, it is not possible to use both.

To configure the .csv file:

1. Fill in the parameter **File Path** with the directory where the .csv file can be found.

   - If this parameter is empty, the default path is *C:\Skyline DataMiner\Documents\Generic Carrier Monitor Manager\\*

   - If only a name is entered, e.g. *Test,* the path will be *C:\Skyline DataMiner\Documents\Generic Carrier Monitor Manager\Test\\*.

   - A full path can also be specified.

1. Fill in the parameter **File Name** with the name of the .csv file that contains the measurements.

1. Click the **Load** button to read out the .csv file and load it into the **Measurement Table**.

The .csv file must have the structure below. The first line will always be skipped to make it possible to add a description at the top.

- *CarrierID;CarrierName;Location;DownlinkFrequency;LNBLOFrequency;DownlinkPolarization;SymbolRate;FECRate;Modulation;RollOff;LNBMode*

### Configuration of the database

The **Measurement Table** will either be filled in by the .csv file or through the database. However, it is not possible to use both.

To configure the database:

1. Fill in the **Server** parameter with the server IP address.

1. Fill in the parameters **Username**, **Password** and **Database Name**.

1. Click the **Load DB** button to read out the database and load it into the **Measurement Table**.

## Usage

### General

This page contains the **Settings** page button. For information on the settings accessible through that button, refer to the Configuration sections above.

The **Measurement Table** is also displayed on this page. This table contains all the settings that are set on the device, but also the measurement results that can be monitored.

Important columns in this table are:

- **Location**: This is the link with the **Element Alias**. When this is equal, these settings will be executed on that element.
- **Enabled**: Measurements can be skipped when this parameter is set to *disabled*.
