---
uid: Connector_help_Telenor_Fiber_Link_Manager
---

# Telenor Fiber Link Manager

With this connector, it is possible to provision fiber link information from a formatted (CSV) file and generate **DataMiner resources**.

Each of these resources will represent the fiber link with a mapping to the corresponding **EPM object** found in the **Telenor EPM front-end manager**.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                           | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Reads out fiber link info from a CSV file. - Looks up matching EPM object per fiber link ID. - Creates or updates fiber link resources. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Telenor EPM Manager   | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

On the **General** \> **Config** page, Configure the provisioning file and the **DataMiner** **Element Name** for the used front-end manager.

### Redundancy

There is no redundancy defined.

## How to use

Once the provisioning file has been selected, click the **Provision** button to start the lookup of **EPM objects** and the generations of the **resources**.

The resources will be stored under the **Telenor FiberLink pool** and can be accessed via the **Resources module** in DataMiner Cube.

## Notes

This connector must be used in combination with the **Telenor EPM Manager**.

The provisioning file must be a CSV (comma-separated) containing the following header:
*Fiberlink_ID,Type,Address_1,ConPoint1,Address_2,ConPoint2*
