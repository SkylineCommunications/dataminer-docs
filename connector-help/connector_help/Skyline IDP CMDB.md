---
uid: Connector_help_Skyline_IDP_CMDB
---

# Skyline IDP CMDB

This connector is used by DataMiner Infrastructure Discovery and Provisioning (IDP) and is intended to be the central location where all information related to the CI types is stored.

## About

### Version Info

| **Range**            | **Key Features**                                               | **Based on** | **System Impact**                                                                                                                                  |
|----------------------|----------------------------------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Part of DataMiner IDP.                                         | \-           | \-                                                                                                                                                 |
| 1.0.1.x \[Obsolete\] | Support for Unicode characters.                                | 1.0.0.x      | \-                                                                                                                                                 |
| 1.0.2.x \[Obsolete\] | \- Parameters in table 600 reordered. - Parameter 413 renamed. | 1.0.1.x      | \- Existing custom reports may no longer work. - Possible impact on DMS filters, Automation scripts, Visio files, reports, DMS web API usage, etc. |
| 1.0.3.x \[Obsolete\] | Increased minimum DataMiner version to 10.0.0.0 - 9517 CU6.    | 1.0.2.x      | The DMS may need to be updated.                                                                                                                    |
| 1.0.4.x \[Obsolete\] | 1.0.3.x                                                        |              |                                                                                                                                                    |
| 1.0.5.x \[SLC Main\] | Parameter 658 renamed.                                         | 1.0.4.x      | Possible impact on DMS filters, Automation scripts, Visio files, reports, DMS web API usage, etc.                                                  |

### Product Info

| **Range**               | **Supported Firmware** |
|-------------------------|------------------------|
| 1.0.0.x 1.0.1.x 1.0.2.x | \-                     |

### System Info

| **Range**               | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-------------------------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x 1.0.1.x 1.0.2.x | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This connector can only be used as part of DataMiner IDP.

It requires all the components from DataMiner IDP in order to work, such as among others DataMinerSolutions.dll.
