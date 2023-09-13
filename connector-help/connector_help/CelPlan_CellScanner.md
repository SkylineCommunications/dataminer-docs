---
uid: Connector_help_CelPlan_CellScanner
---

# CelPlan CellScanner

This DataMiner connector can be used to collect measurements using the CelPlan CellScanner equipment on the most common mobile phone network technologies: GSM, UMTS, LTE, and 5G.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | API version 1.3-07     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation. The IP address of the device must be configured on the **Configuration** page of the element.

### Initialization

Communication with the CellScanner device happens via a DLL provided by the vendor CelPlan. Because this DLL is 64-bit and SLScripting is 32-bit, a helper process is needed to execute the code in the DLL. This helper process is started by the connector. You will never need to start it manually.

However, this helper process needs to be installed separately. You can do so by copying files to the DataMiner server.

1. Build the whole protocol solution (Rebuild All).

1. Copy the generated files:

   - Source folder: \<solution directory\>\CellScannerService\bin\x64\Release

   - Target folder: C:\Skyline DataMiner\ProtocolScripts\CellScanner

After you have created a new element with this connector, configure the **IP address of the device** on the **Configuration** page. On the same page, you can also configure whether GPS coordinates should be registered.

On the pages related to the different technologies (GSM, UMTS, LTE, 5G), you can configure from which frequencies measurements should be collected, and you can also configure additional parameters related to each technology (see "How to use").

### Redundancy

There is no redundancy defined.

## How to use

This connector can be used to do measurements on several mobile network technologies. Each technology has its own page in the element: **GSM**, **UMTS**, **LTE**, and **5G**.

The table at the top of every page is used to configure the frequencies that should be measured. You can add or remove frequencies using the right-click menu. Some technologies require additional parameters such as **Duplex Mode** and **SCS**. The **Band** and **Channel Number** columns can be filled in with any numbers of your choice. Their values will be reported as part of the measurement results to make it possible to link them with the configuration.

Results of the measurements are stored in the tables at the bottom of every page. Next to the values themselves, the time of the last measurement and GPS coordinates are added to every entry. When a channel disappears from the air, no new measurements will be received, and the last measurement time will no longer be updated. On the **Configuration** page, you can configure after how much inactivity time such entries will be removed.
