---
uid: Connector_help_Generic_IP_Resolve_JSON
---

# Generic IP Resolve JSON

This device behaves like a backup DHCP. It retrieves MAC addresses that are not resolved and periodically tries to ask the DHCP for an IP.

The connector receives the MAC addresses from the collectors and asks the DHCP for an existing or new corresponding IP. It will then send the IPs back to the collectors.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### HTTP Main Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP/address of the DHCP device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

## How to Use

### General

On the **General** page, you can define the configuration for the request flow and offloading.

Via the **Credentials** page button, you can define the **Username**, **Password**, and **Internal Username**.

#### Inner flow

There are four important parameters that influence the inner flow for the IP requests:

- *Maximum Number of Requests*: The maximum number of IP lookup requests that will be sent to the DHCP per minute.
- *Cache Time*: The time that IP lookup results will be stored in the Cache Table until they are expired and removed from that table. In case the Cache Time is disabled, the Cache Table will be cleared, new entries will not be stored in the Cache Table, and a resend can never happen.
- *Resend Time*: The time that need to have passed when the MAC address from the Cache Table cannot be resolved (IP: 0.0.0.0). Only when this time has passed, will a new request be sent to the DHCP. Because this applies only to entries in the Cache Table, the Cache Time should always be longer than the Resend Time. Otherwise the entry would be removed from the Cache Table before a resend could occur.
- *Maximum Cached Items*: The maximum number of items allowed in the Cache Table.

The Stack Table stores new requests from the collectors. The oldest request from this table will be processed first. The MAC address for this request will be looked up in the Cache Table, which contains temporary IP lookup results.

- If no result for this MAC address exists in the Cache Table, and the Maximum Number of Requests for this minute has not been reached yet, a new IP lookup request will be sent to the DHCP. Once the result for the lookup is received, it will be sent to the collector, it will be added to the Cache Table, and the request will be removed from the Stack Table.
- If the Cache Table contains a successful result for the MAC address, the result will be sent to the collector, and the request will be removed from the Stack Table.
- If the Cache Table contains a failed result for the MAC address, and the Maximum Number of Requests for this minute has not been reached yet, the request will be removed from the Stack Table, and a new IP lookup request will be sent to the DHCP. Once the result for the lookup is received, it will be sent to the collector and added to the Cache Table.

### Tables

This page contains the **Stack Table**, which displays the MAC addresses with their collector info.
