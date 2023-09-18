---
uid: Connector_help_NPC_System_DTR500
---

# NPC System DTR500

The NEYRPICr Digital Tracking Receiver (DTR-500) is a satellite tracking receiver for tracking geostationary and orbiting satellites.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

#### Serial Connection

This connector uses a TCP/IP connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *111*).

## How to use (1.0.0.x range)

The element created using this connector contains the following pages:

- **General**: Contains an overview of the general device settings and software versions.
- **DTR**: Displays the current configuration of the device. On the **RFConfiguration** and **Configuration** subpages, you can configure the settings.
- **BDC**: Displays the start, stop and OL frequency settings for 4 BDCs.
- **Alarms**: Displays a summary of the alarms and warnings of the device.

## Notes

This connector creates a TCP client to retrieve all data from the DTR, so no data will be available in Stream Viewer.
