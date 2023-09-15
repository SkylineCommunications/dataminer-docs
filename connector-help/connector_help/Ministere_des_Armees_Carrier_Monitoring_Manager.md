---
uid: Connector_help_Ministere_des_Armees_Carrier_Monitoring_Manager
---

# Ministere des Armees Carrier Monitoring Manager

This connector is used for an application that allows you to create new carriers for the Rohde Schwarz FSL3 spectrum analyzer driver. With this application, you can also easily maintain the presets and monitors for multiple carriers in the system.

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

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

On the **General** page, you can add/update/delete the carriers in the **Carriers** table. This page also displays spectrum information such as the **Spectrum Elements**, **Spectrum Measurement Points** and **Spectrum Monitors** configured in the system.

On the **Configuration** page, you can define the default parameter values used in the creation of the carrier.

## Notes

This connector runs in conjunction with an Automation script (*Carrier Configurations.xml*).
