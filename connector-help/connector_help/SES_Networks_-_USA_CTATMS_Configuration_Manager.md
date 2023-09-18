---
uid: Connector_help_SES_Networks_-_USA_CTATMS_Configuration_Manager
---

# SES Networks - USA CTATMS Configuration Manager

This connector is used as the engine of the SES CTATMS application.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                          | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version: - Import + validation of Excel file - Retrieves data from Harmonic Proview PVR7000 elements - Retrieves data from SED Decimator elements | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**          | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Visio file with application UI | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

To be able to import data from Microsoft Excel files, place the *EPPlus.dll* file in the *C:\Skyline DataMiner\ProtocolScripts\\* folder.

When a new element is created, all parameters and tables will initially be empty. To fill these in, import an Excel file containing the master data on the Import page:

1. Upload the .xlsx file to the documents folder of this protocol.

1. Go to the **Import** page of the element and click the **Refresh Files** button.

1. Select the .xlsx file.

1. Click the **Import** button.

   You will be able to follow the import process in the displayed logging, which will also indicate if any data is invalid.

The imported file needs to contain at least the following worksheets with the correct columns:

- SatelliteInfo
- Hawley Reference Carrier
- Woodbine Reference Carrier

## How to use

This connector is the engine of the SES C-Band Transition Automated Transponder Monitoring System (CTATMS) application.

The UI of the application is available in Visual Overview, based on a Visio file that is assigned to the element. To make sure data is displayed, an Excel file has to be imported (see Initialization).

The main goal of this connector is to retrieve and show data from Harmonic Proview PVR and SED Decimator devices, in order to provide an overview of the current system performance. This manager connector can also adjust settings on these devices in order to make sure all settings match the imported data from the Excel file, and to do ad-hoc investigations (deep dive).
