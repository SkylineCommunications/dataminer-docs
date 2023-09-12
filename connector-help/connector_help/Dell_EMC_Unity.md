---
uid: Connector_help_Dell_EMC_Unity
---

# Dell EMC Unity

**Dell EMC Unity** is a family of unified storage platforms designed to deliver speed, efficiency and multi-cloud support. This driver leverages the **Unisphere Management REST API** to manage Unisphere**-**compliant devices.

## About

### Version Info

| **Range**            | **Key Features**                           | **Based on** | **System Impact** |
|----------------------|--------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. Only includes monitoring. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unisphere version 5.x  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: 443).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

The element communicates with the data source using the **Unisphere Management REST API**. In order enable this communication, you need to fill in the **HTTP Username** and **HTTP Password** parameters on the **Communication** page.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### Communication

When the credentials have been specified on the Communication page as detailed above, the element will execute a GET request using these credentials. If they are correct, the element will receive a token from the data source so that it can remain logged in and continue to execute calls for the **Polling Configuration Table**.

Every time a request is being sent, the **Request Status** column will be set to *Sending* and the **HTTP State** parameter will change from *Idle* to *Busy.*

After a response is received, the **HTTP State** parameter changes to *Idle*, and if the response is processed successfully, the **Request Status** for that particular call will change to *Success.* If any error is found when processing the response, the **Request Status** will change to *Fail.*

## Notes

### Version 1.0.0.1 Limitations

As an initial version, version 1.0.0.1 only allows monitoring of the data source. To perform any configuration, you need to access the web UI.

The requests performed to get the information displayed in the element can be seen in the **Polling Configuration** **Table** on the **Communication** page.

Some pages also contain tables that are incomplete and only show the key and name/description:

- Block Page

- Consistency Groups - ID 1400

- VMware Storage Page

- Capability Profiles - ID 3200

- Hosts Page

- Hosts - ID 3700

- VMware Access Page

- vCenters - ID 5000
  - ESXi Hosts - ID 3900
  - Virtual Drives - ID 5200

- Initiators Page

- Initiators - ID 5300
  - Initiator Paths - ID 5400

- Snapshot Schedule Page

- Snapshot Schedules - ID 5500

- Replication Page

- Replication Sessions - ID 5600
  - Replication Connections - ID 5700

- Interfaces Page

- Replication Interfaces - ID 5800

### Byte Conversions

The Unisphere Management REST API returns all byte-related information with the bytes unit. This means that this connector takes care of the conversions from bytes to kB/MB/GB/TB. According to the International System of Units, 1 kB is 1000 B, 1 MB is 1000 kB and so on. Therefore, conversions are done by multiplying the value with a factor of 1000. All the byte-related conversions in the driver are done using this definition. However, these values do not match the byte-related values displayed in the web UI, because instead of using the factor of 1000, the web UI uses the factor of 1024. This means that the web UI considers 1 kB to be 1024 B and 1MB to be 1024 kB, which does not follow the International System of Units definition. This definition is actually what defines another set of units, KiB/MiB/GiB/TiB, where 1 KiB is 1024 B, 1 MiB is 1024 KiB, and so on.
