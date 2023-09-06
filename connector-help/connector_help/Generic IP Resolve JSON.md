---
uid: Connector_help_Generic_IP_Resolve_JSON
---

# Generic IP Resolve JSON

This device behaves like a backup DHCP. It retrieves MAC addresses that are not resolved and periodically tries to ask the DHCP for an IP.

## About

This driver receives the MAC addresses from the collectors and asks the DHCP for an existing or new corresponding IP. It will then send the IP's back to the collectors.

### Version Info

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Configuration

### Connections

#### HTTP Main Connection - Main

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP/address of the DHCP device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

## How to Use

### General

On the **General** page, you can define the configuration for the reqest flow and offloading.

Via the **Credentials** page button, you can define the **Username**, **Password** and **Internal Username**.

#### Inner flow

There are 4 important parameters that influence the inner flow for the IP requests:

- *Maximum Number of Requests*: The maximum number of IP lookup requests that will be sent to the DHCP per minute.
- *Cache Time*: The time that IP lookup results will be stored in the Cache Table until they are expired and removed from the Cache Table. In case the Cache Time is disabled, the Cache Table will be cleared, new entries will not be stored in the Cache Table and a resend can never happen.
- *Resend Time*: The time that need to be passed when the MAC address from the Cache Table can't be resolved (IP: 0.0.0.0). When this time has passed, only then a new request will be sent to the DHCP. Because this applies only to entries in the Cache Table, the Cache Time should always be longer than the Resend Time. Otherwise the entry would be removed from the Cache Table before a resend can occur.
- *Maximum Cached Items*: The maximum amount of items allowed in the Cache Table.

The Stack Table stores new requests from the collectors. The oldest request from this table will be processed first. The MAC address for this request will be looked up in the Cache Table, which contains temporary IP lookup results.If no result for this MAC address exists in the Cache Table, a new IP lookup request will be sent to the DHCP if the Maximum Number of Requests for this minute hasn't been reached yet. Once the result for the lookup is received, it will be sent to the collector, added to the Cache Table and the request will be removed from the Stack Table.If the Cache Table contains a successful result for the MAC address, the result will be sent to the collector and the request will be removed from the Stack Table.If the Cache Table contains a failed result for the MAC address, the request will be removed from the Stack Table and a new IP lookup request will be sent to the DHCP if the Maximum Number of Requests for this minute hasn't been reached yet. Once the result for the lookup is received, it will be sent to the collector and added to the Cache Table.

### Tables

This page contains the **Stack Table**, which displays the MAC addresses with their collector info.
