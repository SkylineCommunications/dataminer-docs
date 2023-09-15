---
uid: Connector_help_Ziggo_Incident_Gateway
---

# Ziggo Incident Gateway

The **Ziggo Incident Gateway** connector will generate an SNMP trap to register an event to the SAM system.

## About

The **Ziggo Incident Gateway** receives info that is collected by the MICA interactive automation script. This script makes it possible to initiate an incident without the existence of alarms.
The connector will process this information and will generate an SNMP trap to the SAM System.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Undetermined                |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

On the CSV Configuration page the parameters **MICA Issus FIle Path** and **MICA ServiceGroups File Path** will need to be set to the corresponding CSV files. The **Issues Table** and **Service Group table** are filled in based on this CSV files.

The **Trap OID** and **Destination IP** need to be provided on the **Trap Configuration** page to generate the traps correctly.

## Usage

This connector consists of the pages below.

### General

This page displays the **Send Trap History Table.** In this table you can see the last X send traps by the connector. You can adjust the number of rows in the table with the **Maximum Number of Traps** parameter.

### CSV Configuration

On this page it is possible to set the parameters **MICA Issus File Path** and **MICA ServiceGroups File Path** to the respective CSV file. This CSV files are used to fill up the **Issue Table** and **Service Group Table**.

### Trap Configuration

On this page, you can provide the **Trap OID** and the **Destination IP** of the generated SNMP trap. In the **Trap Configuration Table** it is possible to adjust the OIDs of the trap bindings.

## Notes

The MICA IAS gets data from the **Issues Table** and **Service Group table.**
