---
uid: Connector_help_Newtec_HUB_SatLink_Manager
---

# Newtec HUB SatLink Manager

The **Newtec HUB SatLink Manager** connector implements a small subset of requests from the **Newtec** **SLM HUB Controller API**.

## About

The Newtec HUB SatLink Manager uses the **SOAP** API to request and provision information. Only a small subset of requests from the API is implemented.

This connector can specifically be used to **book**, **start** and **cancel** **reservations** (SLM 1.0) or **links** (SLM 2.1), which is part of the **reservation interface** or **link interface** (depending on the API version). The connector also implements a subset of the provisioning interface to retrieve the **terminals** and their available **modulators** and **demodulators**. Only the modulators can be provisioned (edited) using the connector.

### Version Info

| **Range** | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                           | No                  | No                      |
| 1.1.0.x          | New firmware based on 1.0.0.5 (see below) | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | SLM 1.0                     |
| 1.1.0.x          | SLM 2.1                     |

## Installation and configuration

### Creation

#### Main connection

This connector uses an **HTTP** connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### Book Reservation (1.0.0.x only)

This page is only available in the 1.0.0.x range of the connector and can be used to **book** and **start** a **reservation**. This was added as a test and has been omitted in the later versions of the connector.

### Reservations (1.0.0.x only)

This page contains the **Reservation Table**, which provides an overview of the reservations that have been made in the SLM.

The **Find Reservations** page button can be used to access a page where you can retrieve reservations from the SLM that were booked during a specific timespan.

### Terminals

This page contains the **Terminals** table, which displays all terminals that are **provisioned** in the SLM. The terminals are also **distributed** (via data distribution) to the **EBU FNRMN HUB Manager**.

### Service Class

The **Service Classes** table on this page is used to map a more user-friendly name to the actual Service Class name in the SLM. It is used when there is an update in the SLM config.

## Notes

The **Newtec HUB SatLink Manager** connector is created to be used in combination with the **EBU FNRMN HUB Manager** connector.

The EBU FNRMN HUB Manager element will perform sets on the Newtec HUB SatLink Manager element to book and start reservations/links and the result will be passed back.
