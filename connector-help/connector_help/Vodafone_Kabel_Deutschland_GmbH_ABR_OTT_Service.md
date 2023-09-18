---
uid: Connector_help_Vodafone_Kabel_Deutschland_GmbH_ABR_OTT_Service
---

# Vodafone Kabel Deutschland GmbH ABR OTT Service

The Vodafone Kabel Deutschland GmbH ABR OTT Service protocol monitors the active configuration and status of the Harmonic VOS/XOS elements per service.

## About

### Version Info

| **Range**            | **Key Features**                                                           | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version: Monitors the Active Streaming States of each XOS Encoder. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                            |
|-----------|---------------------------------------------------|
| 1.0.0.x   | N/A (Harmonic VOS protocol - Range 1.1.1.x or up) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                            | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Vodafone Kabel Deutschland GmbH Active Service Configuration Platform](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_Active_Service_Configuration_Platform) | \-                      |

## Configuration

To create a service using this service protocol:

1. In DataMiner Cube, right-click a view in the Surveyor and select **Create service**.
2. Specify the name for the service.
3. Open the advanced options and select the service protocol **Vodafone Kabel Deutschland GmbH ABR OTT Service**, with the latest version or production version.
4. Go to the **parameters** tab and include the service you want to monitor.

## How to use

The **General** page contains the overview of the active stream states per site.

The **Service Active Configuration** page contains the overview of the input and output devices configuration.

The **Alarms** page contains a toggle button to retrieve and display all active alarms for the included services and elements.

The **Elements** page contains a toggle button to enable any debug logging related to the elements or retrieval of the data.

The **General Parameters** page contains the list of parameters with important information regarding the system.

## Notes

This enhanced service protocol was designed for a specific project and is not expected to be reused in general.
