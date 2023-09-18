---
uid: Connector_help_Avid_Interplay_PAM
---

# Avid Interplay PAM

This connector retrieves the folder structure from the Avid Interplay Production Asset Manager (PAM) solution and allows the user to define the access rules of the DataMiner user groups for these folders.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.1.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                  | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Avid Interplay PAM (Automation script) | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The address of the host that is hosting the Avid Interplay PAM service.
- **IP port**: The port on which the Avid Interplay PAM service is listening.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

When a new element is created, the **username and password** of the Avid Interplay user should be entered on the **Configuration** page. These credentials are sent with each request to the service. On the Configuration page, you will also need to define the **root folder** of the interplay workgroup. The default folder is "interplay://DevWorkgroup/".

### Redundancy

No redundancy is defined in the connector.

## How to Use

There are two ways to retrieve folders from the Avid Interplay Production Asset Manager (PAM). On the **General** page, the **Polling Mode** parameter allows you to switch between these two modes: ***Active Polling*** or ***Request Based***.

### Active Polling

With active polling, the connector will request the **folder structure** of the Avid Interplay PAM service at 30-minute intervals using HTTP POST requests. Each request contains the Avid Interplay user credentials and the path of an Avid Interplay folder. The response then contains the subfolders of the provided folder.

Every 30 minutes, the connector will request the DataMiner **users and user groups**. These can be used to **assign access** of a user group to a specific folder in the form of access rules. When a user group has access to a folder, they also have access to all underlying folders.

The folder structure that a **specific user** has access to can be retrieved via an **Automation script** by sending a JSON request to the **External Access Rules Request** parameter (PID 1621). An entry is added to the Access Rules Requests table with the status *Pending* when the request is received. When the request is handled by the connector, the status is updated to either *Completed* or *Failed* and the response becomes available in the Response column of the table. The requests and responses should have the following structure:

| **Request**                         | **Response**                                                                                                                                        |
|-------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------|
| { "Id": string, "Username": string} | { "Id": string, "Folders": \[ { "URL": string, "Children": \[ { "URL": string, "Children": \[ (0 or more folders) \] } (0 or more folders) \] } \]} |

### Request Based

The folder structure that a **specific user** has access to (filtering based on the user group the user belongs to) can be retrieved via an **Automation script** by sending a JSON request to the **External Folder Request** parameter (PID 1720). An entry is added to the Folder Requests table with the status *Pending* when the request is received. When the request is handled by the connector, the status is updated to either *Completed* or *Failed* and the response becomes available in the Response column of the table. The requests and responses should have the following structure:

