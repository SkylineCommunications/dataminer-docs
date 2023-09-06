---
uid: Connector_help_Sony_CNA-1
---

# Sony CNA-1

The CNA-1 camera control network adaptor allows third-party system products to control Sony system cameras over IP networks. The CNA-1 works as a protocol converter, translating the original 700PTP protocol of Sony cameras to and from Simple Protocol to allow the cameras to work easily with third-party devices.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**          |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Sony CNA-1 - RCPSony CNA-1 - CCU |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *7800*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages described below.

### CCU Status Info

On this page, you can find information related to all the CCUs. The **maximum** and **minimum** values for **CCU** **numbers** are displayed at the top of the page.

**CCU Select Retries** shows the number of retries the CNA driver will attempt in order to select a CCU or to send the command to the CCU. When the retries are done, the driver will wait for an interval determined by the **Back Off Wait Time CCU Buffers** parameter and the next CCU will be selected in the meantime. When the CCU is selected again, the driver checks if the back-off time has passed. If it has, the driver will try to send the command one last time.

A **CCU Status** **table** is also available, listing the detected CCUs are listed.

### RCP Status Info

This page displays information related to all the RCPs. The **maximum** and **minimum** values for **RCP** **numbers** are displayed at the top of the page.

An **RCP** **Status** **table** is also available, listing the detected RCPs are listed.

### DVEs Configuration

This page contains the logic and tables used for **DVE** creation and management.

### NMI

On this page, the **NMI** table allows you to check which NMI element is connected to which CCU.

The **Resubscribe** button can be used to reset all the created subscriptions.

## Notes

DVE creation is possible for each available RCP and CCU. DVEs are also created for all RCPs that are assigned to a CCU, even if the RCP is "Not Available".
