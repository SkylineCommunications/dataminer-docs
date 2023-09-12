---
uid: Connector_help_NBCU_LEAP_Collector
---

# NBCU LEAP Collector

LEAP is a proprietary system at NBCS that provides information on event streams. The **NBCU LEAP Collector** driver can be configured to collect and report relevant data to the NBCU Event Manager using the PID for a given stream.

## About

### Version Info

| **Range**            | **Key Features**                                                   | **Based on** | **System Impact**                         |
|----------------------|--------------------------------------------------------------------|--------------|-------------------------------------------|
| 1.0.0.x \[Obsolete\] | Retrieves LEAP data through HTTP.                                  | \-           | \-                                        |
| 1.0.1.x \[SLC Main\] | Reformat to retrieve all events similar to **NBCU LEM Collector**. | 1.0.0.5      | All pages and data have been reformatted. |

### Product Info

| **Range**        | **Supported Firmware** |
|------------------|------------------------|
| 1.0.0.x, 1.0.1.x | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page of the element, the event table contains the relevant data related to events, including the PID, asset ID, Title, Description, etc.
