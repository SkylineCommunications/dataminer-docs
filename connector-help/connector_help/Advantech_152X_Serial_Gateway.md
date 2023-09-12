---
uid: Connector_help_Advantech_152X_Serial_Gateway
---

# Advantech 152X Serial Gateway

The EKI-152X models are industrial-grade network-based serial device servers that allow you to connect up to 8 or 16 serial RS-232/422/485 devices, such as CNCs, PLCs, scales, and scanners, directly to a TCP/IP network. The EKI-152X models feature two independent Ethernet ports and MAC addresses to provide a redundant network mechanism, guaranteeing Ethernet network reliability. The models can be configured via Windows utility, web browser, serial console, or Telnet console, so that it is easy to manage many EKI-152X or serial devices in your network.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.1 \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.1   | 1.05, revision 5972    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.1   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: 161

SNMP Settings:

- **Get community string**: public
- **Set community string**: private

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The following data pages are available in the element:

- **General**: Displays general device information such as the time.
- **Ethernet** **Configuration**: Contains Ethernet settings.
- **Port Configuration**: Contains UART port settings.
- **Operation Mode**: Contains settings for the ports based on the type of mode of the ports (VCOM, USDG Data, USDG Control, or RFC 2217).
- **Monitor**: Contains bandwidth details for the port and peer connection.
- **Tools**: Allows you to reboot the system.
- **Alarm**: Allows you to configure alarm settings for SMTP and mail addresses.
