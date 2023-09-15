---
uid: Connector_help_Nec_PNMS_Generic_Link
---

# Nec PNMS Generic Link

This connector will receive traps sent from the Nec PNMS system.

## About

With this connector, you can receive and process traps sent from the Nec PNMS system. The connector has some default settings to process these traps, but it is also possible to configure existing and additional settings and thus extend the protocol support.

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the NEC PNMS System.
- **Device address**: The IP address of the corresponding network element. This IP will be used to filter the traps.

SNMP Settings:

- **Port number**: Not applicable.
- **Get community string**: Not applicable.
- **Set community string**: Not applicable.

## Usage

### General

This page displays the **Parameters Table**. When a trap is received and correctly processed, the corresponding value will be introduced in this table depending on the Mapping configuration.

Depending on the parameter, alarm monitoring is possible on the values in this table.

### Configuration

On this page, you can add/edit/remove settings in the connector configuration.

In the **Mapping Table**, you can configure the corresponding parameter definitions for each OID (optionally using wildcards):

- **OID**: OID of the parameter.
- **Name**: Name of the parameter.
- **Type**: Discreet, Double or String.
- **Received Value**: If the type is 'Discreet', this parameter should be filled in with the value received from the device.
- **Mapping Value**: If the type is 'Discreet', this parameter should be filled in with the value to display in DataMiner.
- **Calculation**: If the type is 'Double', this parameter can indicate what calculation to perform.
- **Units**: If the type is 'Double', this parameter indicates the unit.

In the **Trap Configuration Table**, you can configure the traps that will be processed:

- **Trap OID**: OID of the trap.
- **Parameter OID Binding Number**: Should be filled in with the binding number that contains the parameter OID.
- **Parameter Value Binding Number**: Should be filled in with the binding number that contains the parameter value.

Note: The configuration of this table is done through a context menu. You cannot edit the parameters directly, but should instead right-click the table and select the appropriate option.
