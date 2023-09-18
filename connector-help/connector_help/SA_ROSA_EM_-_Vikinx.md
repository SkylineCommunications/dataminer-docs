---
uid: Connector_help_SA_ROSA_EM_-_Vikinx
---

# SA ROSA EM - Vikinx

The Rosa EM - Vikinx connector will display information related to a **Vikinx** device connected to the ROSA EM device. The displayed information is organized according to the Rosa EM web application. In addition, this connector also provides the possibility to perform sets on Vikinx devices.

## About

The ROSA EM - Vikinx connector is used to obtain information from Vikinx devices connected to the Rosa EM device. An **SNMP** connection is used in order to successfully retrieve and configure the device's information.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and Configuration

## Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address**: The polling IP of the Rosa device, e.g. *10.55.48.31*.
- **Device address**: The device address can be found on the page **Vikinx Devices** of the connector Rosa EM.

SNMP Settings:

- **Port number**: The port connected to the device (by default *161*).
- **Get Community String**: The community string needed to read from the device. The default value is *public*.
- **Set Community String**: The community string needed to set to the device. The default value is *private*.

## Usage

Each element created for a Vikinx device connected to Rosa EM will contain the following pages:

- **Input Output Settings:** Matrix representation for input/output setting.
- **Input Output Settings Table:** Output values from matrix displayed as normal parameters.
- **Vikinx - Alarms:** Alarms for the Vikinx device.
- **Vikinx - Properties:** Properties for the Vikinx device.
- **Vikinx - Status:** Status parameters for the Vikinx device.
