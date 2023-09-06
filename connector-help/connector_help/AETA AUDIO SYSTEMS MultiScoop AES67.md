---
uid: Connector_help_AETA_AUDIO_SYSTEMS_MultiScoop_AES67
---

# AETA AUDIO SYSTEMS MultiScoop AES67

The AETA AUDIO SYSTEMS MultiScoop Manager is a solution that allows you to manage AETA codecs in order to manage your calls on various networks (IP/ISDN/phone/mobile).

This connector uses **SNMP** to poll data from AETA AUDIO SYSTEMS MultiScoop AES67 and AETA AUDIO SYSTEMS ScoopTeam codec cards based on the web interface layout of the codec cards.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                  |
|-----------|---------------------------------------------------------|
| 1.0.0.x   | 1.06.01 (MultiScoop Devices) / 1.15 (ScoopTeam Devices) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

#### SNMP Connection - MultiScoop Devices

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: 161X (X being the Codec card slot number).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### SNMP Connection - ScoopTeam Devices

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: 161X (X being the Codec card slot number).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Contains general system information such as the system name, location, and firmware version.
- **System Capabilities:** Allows you to check the device capabilities, for example if AoIP transmission, ISDN transmission and Wi-Fi are available.
- **Status:** Contains the Transmission Interface Codec 1, Codec 2, AoIP (SIP) and Connection Status parameters.
- **Connections:** Contains connection statistics and connection state parameters.
- **Coding**: Allows you to modify the Codec 1 and Codec 2 configuration, including the Bit Rate and Sample Rate.
- **Network:** Allows you to check the Primary Network and select the Secondary Network. The **AoIP Settings** subpage displaysSIP parameters such as SIP User, Status and more. You can also reset SIP profiles and return SIP accounts to the factory settings.
- **Alarms:** Contains the Alarms Table and Alarm Counter.
