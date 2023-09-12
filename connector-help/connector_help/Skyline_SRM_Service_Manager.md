---
uid: Connector_help_Skyline_SRM_Service_Manager
---

# Skyline SRM Service Manager

This is a generic connector that supports service creation based on a service template.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

The connector exposes a receiver parameter (**Reservation JSON Receiver**, **PID 1**) that should receive a JSON Serialized **Service General** object.

This object will be deserialized and all info will be extracted. Once this is successful, an entry will be created in the **SRM Service Table** (on the General page), and a corresponding **service** will be created using the provided **service template**.

Each row in the SRM Service Table represents a service in the system. When a row gets added to this table (based on a request coming from LSO), a service creation request is executed, and the result of this request (Success or Failure) is shown in the **Creation State column**.

The **Service Action** buttons allow you to manipulate a service.
