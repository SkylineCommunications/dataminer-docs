---
uid: Connector_help_TAG_Video_Systems_MCR-6000
---

# TAG Video Systems MCR-6000

The **MCR-6000** Internet Radio Gateway enables live transcoding of internet audio streams, such as radio stations, and the encapsulating of such streams into MPEG-2 transport streams.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | FW: 1.0.3 / SW: 2.2.6  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

Credentials are needed before the device can be successfully polled. You can specify these via **General** \> **Security** \> **Login**.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

- Channels:

- Channels can be edited/added/removed via the right-click menu of the Channels Table.
  - You can also link streams and sources to a channel via the right-click menu of the Channels Table.

- Sources:

- Sources can be edited/added/removed via the right-click menu of the Sources Table.

- Streams:

- Streams can be edited/added/removed via the right-click menu of the Streams Table.

## Notes

The connector contains a hidden debug page that you can enable by doing a **multiple set** on the parameter **DEBUG Page Visibility**, setting it to the value ***Shown***.

On the debug page, you can enable or disable debug logging.
