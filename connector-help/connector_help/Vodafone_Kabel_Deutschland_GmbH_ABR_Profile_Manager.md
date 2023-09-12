---
uid: Connector_help_Vodafone_Kabel_Deutschland_GmbH_ABR_Profile_Manager
---

# Vodafone Kabel Deutschland GmbH ABR Profile Manager

The ABR Profile Manager is a virtual connector that collects data from existing OTT-related elements and displays which encoding and destination profiles are used by which services.

### Version Info

| **Range**            | **Key Features**                                | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Harmonic VOS profiles and services integration. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the **Configuration** page, you can configure the polling interval to retrieve all details.

## How to use

On the **General** page of this connector, you can find a list of all the services present on the OTT encoder devices and the encoding profiles used by these services.

On the **Configuration** page, you can configure the polling interval and view the last poll time.
