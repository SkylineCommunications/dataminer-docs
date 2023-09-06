---
uid: Connector_help_Verizon_DSM_RDS
---

# Verizon DSM RDS

This driver imports information of different subscribers from the **Verizon Reports and Dashboards Solutions** driver, which will be used in the **inter-element communication** to gather important data that will be exported to a location used by the Verizon Reports and Dashboards Solutions driver to process reports and dashboards.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

As this driver is mainly a system driver, not much user interaction is required. Below you can find more information on the different functionalities within the driver.

### General

Clicking the **update** button will perform a **full update of the system**. It will:

- Get the latest subscribers from the **Verizon Reports and Dashboards Solutions** driver.
- Retrieve the data from these subscribers.
- Export information for the subscribers to the location entered in **File Path.**

### Configuration

#### Export Configuration

The following functionalities are available within this section:

- **Suffix Removal**:Allows you to remove the **tier identifier pattern (-#)** at the end of the Remote name if applicable.
- **File Handling**: Allows you to control the file **importing/exporting** for the **Verizon Reports and Dashboards Solutions** driver.
- **File Path**: Contains the **path** where thefile is **imported/exported.**
- **Processing Time**: Allows you to control how **frequently** the system will gather new data to be exported.
- **Apply**: Allows you to do a **manual update** of the **import/export** logic.
