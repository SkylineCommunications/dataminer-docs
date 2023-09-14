---
uid: Connector_help_Generic_DOCSIS_eMTA_Collector
---

# Generic DOCSIS eMTA Collector

This connector will poll info from embedded multimedia terminal adapters (eMTA) via SNMP.

## About

This connector uses SNMP on the standard DOCSIS mibs to collect info from eMTAs. This data is polled multithreaded. This data should be aggregated and displayed by a CPE Manager. It's not the intention that an operator consults the data directly, hence the data side is not accessible.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          |                             |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection to connect to the CMs and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: 127.0.0.1 (random)

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. Default value : *public*.
- **Set community string**: The community string used when setting values on the device. Currently no sets are done from the connector. Default value : **private*.*

### Configuration of Provisioning

After creating the collector element, all configuration should be done by the CPE Manager element.

## Usage

As mentioned before, it's not the intention that the operator has access to the data side so there are no parameters available that can be configured. All should be done through a CPE Manager element.
