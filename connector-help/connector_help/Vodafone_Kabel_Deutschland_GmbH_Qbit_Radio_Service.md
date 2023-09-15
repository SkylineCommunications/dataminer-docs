---
uid: Connector_help_Vodafone_Kabel_Deutschland_GmbH_Qbit_Radio_Service
---

# Vodafone Kabel Deutschland GmbH QBit Radio Service

The Vodafone Deutschland GmbH QBit Radio service protocol monitors the active configuration of the QBit element per service.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                            | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Vodafone Kabel Deutschland GmbH Active Service Configuration Platform](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_Active_Service_Configuration_Platform) | \-                      |

## Configuration

To create a service using this service protocol:

1. In DataMiner Cube, right-click a view in the Surveyor and select **Create service**.
2. Specify the name for the service.
3. Open the advanced options and select the service protocol **Vodafone Kabel Deutschland GmbH QBit Radio Service**, with the latest version or production version.
4. Go to the **parameters** tab and include the service you want to monitor.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page contains the overview of the active stream states per site.

The **Alarms** page contains a toggle button to retrieve and display all active alarms for the included services and elements.

The **Elements** page contains a toggle button to enable any debug logging related to the elements or retrieval of the data.

## Notes

This enhanced service protocol was designed for a specific project and is not expected to be reused in general.
