---
uid: Connector_help_Teleste_AC3210_Manager
---

# Teleste AC3210 Manager

This connector will read CSV files with the hostname of the devices that should be polled. The information it retrieves will be displayed in a table on the main element and on a DVE element.

The connector uses round-robin polling to poll all devices within 10 seconds. Every 10 seconds, there is also a check if the DNS is working. If it is not, the timeout parameter will indicate a DNS error. If the manager cannot retrieve any info, this parameter will indicate a timeout state.

The connector includes normalization for the ingress switches. There is a button to normalize all the ingress switches. The state is displayed in the parameters State Ingress Switch 1 or 2.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.10.3                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**        |
|-----------|---------------------|-------------------------|-----------------------|--------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Teleste AC3210 Manager - Child |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: *localhost*
- **IP port**: *161*

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

CSV files needs to be provided in the correct folder.

*C:\Skyline DataMiner\Documents\Teleste AC3210 Manager\\Element Name Manager"\_"FileName".csv*

*C:\Skyline DataMiner\Documents\Teleste AC3210 Manager\\Element Name Manager".csv*

The file name can contain an underscore "\_" so you can give it a more specific name.

The CSV has a specific layout:

> Element Name;DNS Name;DMS View
> ;;
> "Here you can start making your nodes"

The "Element Name" and "DNS Name" need to be unique.

The "DMS View" is a view in the DataMiner System.

For example:

> Element Name;DNS Name;DMS View
> ;;
> Labo Node AC3210;LaboNodeUniqueName.be;Skyline View

### Redundancy

There is no redundancy defined.

## How to use

Start by placing the CSV files in the correct folder.

Then create the element in DataMiner. It will check the path mentioned in the "Initialization" section above, start polling the CSV files and create the DVEs.

The CSV files are read every hour, so new devices may be created and existing devices may be deleted every hour based on changes in the files.
