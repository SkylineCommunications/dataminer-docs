---
uid: Connector_help_NBCU_SCTE_Trap_Collector
---

# NBCU SCTE Trap Collector

The purpose of the SCTE application is to verify SCTE cues that are generated in the system. SCTE data is information carried along with the video/audio stream.

The data can be used for a variety of purposes, including the insertion of commercial content.

## About

### Version Info

| **Range**            | **Key Features**      | **Based on** | **System Impact** |
|----------------------|-----------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Dynamic trap receiver | \-           | \-                |

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

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: As the allowed IPs must be configured in the driver, you can set this field to "localhost" when you create the element.
- **IP port**: Default value: 161. Like the IP address/host field, this field will not actually affect the connection.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

Several things need to be configured in the element to make sure the driver can receive traps. On the **Filters** page, the **Trap Filtering** table describes the IPs and OIDs that are allowed to be processed from the incoming traps.Also, the SCTE Event Type table allows you to define what types of SCTE events should be monitored. If traps are received with a value of something other than a value on this list, they are ignored.

After traps pass the filters above, they get processed. If all the bindings are correct, they are candidates to create a new event or update an existing one.

The event creation/update depends on the **New Event Detection Range** and **Success Window** parameters that are available on the **General** page.

You can configure automatic deletion of traps, which depends on the event, i.e. whether it was successful or not, or whether the trap could get associated to an event.
