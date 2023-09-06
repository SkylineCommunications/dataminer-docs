---
uid: Connector_help_Kordia_FMS_Manager
---

# Kordia FMS Manager

This connector executes logic for the provisioning of elements and enhanced services. It is intended to be used in combination with a Process Automation setup.

## About

### Version Info

| **Range**            | **Key Features**         | **Based on** | **System Impact** |
|----------------------|--------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | FMS element provisioning | \-           | \-                |

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

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page contains the **Request Log Table** along with refresh and configuration buttons. The **Request Log Config** button opens a subpage with the configuration parameters for the **Request Log Table** (i.e. the Request Log Table Age Limit and Request Log Table Row Limit).

The **PA Debug** page contains information regarding the data imported into DataMiner regarding the different HTTP requests that are done. These parameters contain the information of the latest applicable request.

In the Log Table, the status column indicates how the request was evaluated: *Successful* or*Failed*.
