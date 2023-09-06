---
uid: Connector_help_Miteq_NSUN
---

# Miteq NSUN

The Miteq NSUN (New Switchover Unit - N) is designed to provide improved reliability for advanced satellite communications systems. The NSU consists of a control unit, switch modules, and frequency converters. The control unit monitors the status of up to twelve primary frequency converters and one backup frequency converter. The NSUN is a one-rack-high control unit that is expandable up to a 1:12 configuration with external Redundancy Switch Modules (RSMs).

## About

### Version Info

| **Range**            | **Key Features**                                                           | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. Converter Settings table with forward control capability. | \-           | \-                |

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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The Miteq NSUN connector communicates over **SNMP**, both for polling and setting data and for receiving traps from the connected element.

### SNMP Settings

The SNMP Settings page is a subpage of the **General** page. The **Trigger Test Trap** parameter on this page allows you to send an SNMP set command to the device using the *trapTest* OID. The device will process this set and respond by sending a test trap to the **Trap Destination** configured on the device.

### Status

On the Status page, you can set the **Redundancy Mode** to *Manual* or *Automatic*.

To perform any SNMP sets on the Converter State, the **Redundancy Mode** must be set to *Manual*.

### Alarms

The Alarms page shows current alarms retrieved from the device during polling. These alarms must be included in an alarm template to generate DataMiner alarms. They have been configured with default alarm thresholds/values for that purpose.

### Converter Settings

The Converter Settings page includes a table with information related to the converters that may be attached to this device.

To retrieve this information, DataMiner must first set the value of the index (position of the converter) to the *cvsel* OID. Upon polling the *status*, *mute*, and *ans swtype* OIDs, the values for these respective OIDs will be returned for the converter specified in the *cvsel* OID. This is also required to perform any SNMP sets for a particular converter. This is also explained in the Miteq NSU MIB files.

Note that position/index **Zero (0)** in the converter table is reserved for the backup converter, while 1-12 are reserved for primary converters.

You can **Mute** or **Unmute** the individual converters, and you can set the state of individual converters to *Online* or *Standby*.

## Notes

SNMP v3 is currently not supported by this device. This connector is compatible with both SNMP v1 and v2.
