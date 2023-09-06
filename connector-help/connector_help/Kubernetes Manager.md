---
uid: Connector_help_Kubernetes_Manager
---

# Kubernetes Manager

This is a generic Kubernetes connector that allows full container-based operation through DataMiner. It allows the user to navigate through all Kubernetes namespaces and consult nodes, PODs, and deployments, among others.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                    | **Based on** | **System Impact**                                                                                |
|----------------------|---------------------------------------------------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version Kubelet API v1.6                                                                                    | \-           | \-                                                                                               |
| 1.1.0.x              | Kubelet API v1.7                                                                                                    | \-           | \-                                                                                               |
| 1.2.0.x              | Kubelet API v1.11Oboslete  See 1.2.2.x                                                                              | \-           | \-                                                                                               |
| 1.2.1.x              | Protocol type change from Virtual to HTTP. Added HTTP connection to the element configuration.Oboslete  See 1.2.2.x | \-           | The element will need to be adjusted to use the correct connections.                             |
| 1.2.2.x \[SLC Main\] | Parameter discrete updates for 'Conditions table'.Based on 1.2.1.5.                                                 | 1.2.1.5      | Parameter discrete updates for 'Conditions table'. Possible impact on trend and alarm templates. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Kubelet v1.6           |
| 1.1.0.x   | Kubelet API v1.7       |
| 1.2.0.x   | Kubelet API v1.11+     |
| 1.2.1.x   | Kubelet API v1.11+     |
| 1.2.2.x   | Kubelet API v1.11+     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.2.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.2.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.2.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creation (v1.0.0.x and v1.1.0.x)

#### HTTP Connection - Main

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address (default: *ByPassProxy*).

#### Serial Connection -SSHConnection (only available in range 1.0.0.x)

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

### Creation (v1.2.0.x)

In this range, a virtual connection is used with HTTPS support via QAction. DataMiner is currently not able to handle certificates issued by unknown entities.

To set up the connection, enter the Kubernetes server address and a valid bearer token on the General page, as depicted below.

### Creation (v1.2.1.x and v1.2.2.x)

#### HTTP Connection - Main

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address (default: *ByPassProxy*).

To set up the connection, enter a valid bearer token on the General page, as depicted below. If the token is valid, the Authorization State will change to "Authorized".

### Web Interface (v1.0.0.x and v1.1.0.x)

The web interface is only accessible when the client machine has network access to the product

## Usage

### General

In range **1.0.0.x and 1.1.0.x**, the General page summarizes the existing **namespaces**. It also contains a generic **HTTP Error Log** table. In range **1.0.0.x**, it also includes the **Statistics**, **PODs**, **Replica Sets**, **Deployments** and **Nodes** tables, as well as a **Kubectl** subpage from which you can send and receive any kubectl message using the SSH serial connection to the Kubernetes proxy. A **Service** subpage is also available, which is meant for SRM management purposes only. In range **1.1.0.x**, it only includes the **PODs** table.

In range **1.2.0.x, 1.2.1.x and 1.2.2.x**, the General page includes the main KPIs for the overall cluster and the login data, as depicted above. It also includes access to subpages to list **Namespaces**, **PODs**, **Containers**, **Conditions**, **Replica Controllers** and **Services**. Finally, it also allows access to the **Labels Manager** page, where you can manage labels for both nodes and PODs.

### Nodes

This page contains a tree control that allows you to navigate through the details for each of the nodes, including **Conditions**, **Images**, **Allocated Resources**, and more.

### Jobs (v1.0.0.x and v1.1.0.x)

This page contains a table summarizing all jobs and their status.

### Deployments (v1.0.0.x and v1.1.0.x)

This page contains a table summarizing each deployment and its status.

### Pods

This page contains a tree control with all **PODs** and their properties. You can navigate through **Conditions**, **Containers**,and **Events**.

### Services

This page lists all Kubernetes services and their properties, such as namespace, creation timestamp, PODs summary, etc.

### Daemon Sets (v1.0.0.x and v1.1.0.x, from 1.0.0.2 onwards)

This page contains a tree control with all **daemon sets** in the current K8S. It allows you to monitor the daemon set, including the **POD template**, with volumes and containers.
