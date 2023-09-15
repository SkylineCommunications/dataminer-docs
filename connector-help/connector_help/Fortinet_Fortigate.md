---
uid: Connector_help_Fortinet_Fortigate
---

# Fortinet Fortigate

The FortiGate series delivers next-generation firewall capabilities for mid-sized to large enterprises, with the flexibility to be deployed at a campus or enterprise branch. It protects against cyber threats with security processor-powered high performance, security efficacy, and deep visibility.

This connector uses both an SNMP and a serial connection.

## About

### Version Info

| **Range**            | **Key Features**                                                                              | **Based on** | **System Impact**                                                                                    |
|----------------------|-----------------------------------------------------------------------------------------------|--------------|------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                              | \-           | \-                                                                                                   |
| 1.0.1.x              | New firmware based on 1.0.0.x (see below).                                                    | \-           | \-                                                                                                   |
| 1.0.2.x              | Cassandra compliance.                                                                         | 1.0.1.19     | Trend history data                                                                                   |
| 1.0.3.x              | Additional firewall policy rates.                                                             | 1.0.2.3      | Custom reports or scripts calling Firewall Policy Statistics table IDX or displayed columns directly |
| 1.0.4.x \[Obsolete\] | DCF integration added. New display key format used in interfaces table.                       | 1.0.3.1      | \-                                                                                                   |
| 1.0.5.x              | HA Statistics table primary key and display key changed. HA Statistics table columns renamed. | 1.0.4.10     | Custom reports or scripts calling HA Statistics table IDX or displayed columns directly              |

### Product Info

| **Range**                               | **Supported Firmware** |
|-----------------------------------------|------------------------|
| 1.0.0.x                                 | \-                     |
| 1.0.1.x 1.0.2.x 1.0.3.x 1.0.4.x 1.0.5.x | 4.0.x 5.6.8            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | No                      | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.3.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.4.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.5.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: 161.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: 23.
  - **Bus address**: Not required.

### Initialization

In order to be able to remove an SSL VPN tunnel, click the **Credentials** page button and fill in the **Fortinet Username** and **Fortinet Password**.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Contains general information about the device.
- **Threat Management**: Contains some of the settings available in the device.
- **HTTP Statistics**: Contains metrics related to HTTP services running through the firewall.
- **IM Statistics**: Contains metrics related to the instant messaging services running through the firewall.
- **IM Proxy Statistics**: Contains metrics related to the instant messaging proxy services running through the firewall.
- **Explicit Proxy Statistics**: Contains metrics related to the explicit proxy services running through the firewall.
- **IMAP Statistics**: Contains metrics related to Instant Message Access Protocol packets that are sent through the firewall.
- **NNTP Statistics**: Contains metrics related to Network News Transfer Protocol packets that are sent through the firewall.
- **P2P Statistics**: Contains metrics related to P2P services running through the firewall.
  **POP3 Statistics**: Contains metrics related to POP3 messages sent through the firewall.
- **Scan Unit Statistics**: Contains metrics related to the scan units present in the firewall.
- **SIP Statistics**: Contains metrics related to Session Initiation Protocol packets sent through the firewall.
- **SMTP Statistics**: Contains metrics related to Simple Mail Transfer Protocol packets sent through the firewall.
- **VoIP Statistics**: Contains metrics related to Voice-over-IP packets sent through the firewall.
- **WAN Optimization Statistics**: Contains metrics related to techniques used by the firewall to maximize the efficiency of data flows across a Wide Area Network.
- **Web Cache Statistics**: Contains metrics related to web files cached on the firewall.
- **Web Filter Statistics**: Contains metrics related to web files filtered by the firewall.
- **FTP Statistics**: Contains information related to File Transfer Protocol messages sent through the firewall.
- **Fnbam Statistics**: Contains metrics related to the Fnbam service of the firewall.
- **Interface**: Contains information on the interfaces present in the device. You can reduce the SNMP load of the interface table by filtering the polled interfaces. You can enable use of 32-bit counters for all interfaces with the "Use 32 Bit Counters" toggle button.
- **Firewall**: Contains general information about the firewall features of the device.
- **Anti-virus**: Contains metrics about the antivirus service running on the firewall.
- **IPS/IDS**: Contains metrics about the Intrusion Prevention and Intrusion Detection Systems available on the firewall.
- **VPN**: Contains information about the VPNs tunneling through the firewall.
- **Wireless Control**: Contains information about the wireless features of the firewall.
- **LTE Modem**: Contains information about the optionally connected LTE modem.
- **NPU**: Contains metrics about the Network Processing Unit present in the firewall.
- **Web Interface**: Provides access to the built-in device web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
