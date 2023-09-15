---
uid: Connector_help_Teracom_Remote_Eye_Allocation
---

# Teracom Remote Eye Allocation

The **Teracom Remote Eye Allocation** connector manages the different remote eye sessions and the resource allocation of the devices used for the remote eye.

## About

The system will filter elements based on the protocol name. Currently, elements using the **Sencore MRD 4400** protocol are supported.

The connector is used together with the following 4 scripts:

1. Remote Eye Tx In
2. Remote Eye Tx Out
3. Remote Eye He In
4. Remote Eye He Out

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page contains the **Remote Eye Session Timeout** parameter, which allows you to define after which timespan the remote eye sessions should be automatically disabled.
As soon as the timeout time for a session is reached, the linked entry will be deleted from the **Session Table** and from the **IRD Allocation Table**.

### IRD Allocation

This page contains the **IRD Allocation Table**. This table lists the IRDs available in the DMS for remote-eye sessions. It displays the **Time** when each IRD has been in use, the **Service** that was selected, the **Session**, the **Engine** that it is in use and the **Stream Source**, and it contains an option to manually **remove** the IRD.

Aside from this table, the page contains the **Add IRD** page button, which allows you to configure a **New IRD Name**, **EdgeVision** **IP** and **EdgeVision Port**.

When the scripts Remote Eye Tx In, Remote Eye Tx Out and Remote Eye He Out are run, the connector will automatically handle the initialization of the parameters mentioned above.

### Kaleido Allocation

This page displays the **Kaleido Allocation Table**, in which you can configure the parameters **Kaleido Head1** and **Head2 In Use Time**.

There is also a page button that can be used to add a Kaleido element. The parameters to create the new element are:

- New Kaleido Name
- New Kaleido Head1 EdgeVision IP
- New Kaleido Head1 EdgeVision Port
- New Kaleido Head2 EdgeVision IP
- New Kaleido Head2 EdgeVision Port

### Sessions

This page contains the **Sessions Table**.

### BridgeTech Allocation

This page displays the **BridgeTech Allocation Table**, which shows which device is currently **Locked**.

### Kaleido Services

This page displays the **Kaleido Service Lookup Table**. It also contains a button to **Import Program Feed.**
