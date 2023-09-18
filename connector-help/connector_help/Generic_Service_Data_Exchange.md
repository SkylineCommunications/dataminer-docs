---
uid: Connector_help_Generic_Service_Data_Exchange
---

# Generic Service Data Exchange

The **Generic Service Data Exchange** connector can be used to gather all parameter values of all elements that are included in a **service**.

## About

DataMiner currently doesn't support replication of a service in another DMS cluster. This connector gathers all parameter values of all elements that are included in a service. Then this element can be replicated in another cluster, allowing the users to access the service data in that other cluster.

This connector uses a virtual connection, and doesn't poll any information from a device. **SLNet subscriptions** are used to be notified when a parameter value has changed.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of the linked service

After creating an element with this protocol, a service needs to be selected on the configuration page. After selecting a service, the connector will load all elements and parameters that are included in the service.

## Usage

### Overview

Contains a treeview that displays the information on the pages below, in a more structured way. The top level in the treeview are the elements, the second level the parameters, and the third level the parameter instances (rows).

### Elements

Displays a table with all elements that are included in the selected service.

### Parameters

Contains a table with the parameters from the elements in the service. The parameter filters from the service configuration are taken into account. When the filter doesn't contain parameters, alle parameters are added.

With the **Update Parameters** button on top, you can refresh the data in this table.

### Parameter Values

In the table on this page the current value of each parameter can be found. When the parameter is a table columns, a row is added for each instance.

### Configuration

On this page the user has the possibility to configure the service, from which all data is copied in this element. Use the **Update Service List** button, to update the list with available services in the cluster.
