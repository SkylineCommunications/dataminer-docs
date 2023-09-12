---
uid: Connector_help_Generic_Service_Alarming
---

# Generic Service Alarming

This service protocol can be used to perform advanced alarm monitoring on services. Based on a configuration table, alarms can be created depending on the alarms available on the children of the service.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

When you have created the enhanced service, on the **Children Configuration** page, map which service children should be used.

After this, on the **Alarms Configuration** page, configure when alarms should be generated. This page contains a configuration table with rows representing specific states of the service children, together with a priority, case, severity, description, and target UI. When a new alarm update is detected on one of the service children, the protocol will evaluate all the rows in the table. A row is valid if the state of the service child is equal to or greater than the configured severity. Alarms will then be generated for the highest priority (i.e. the lowest value) for every case. These alarms will have the configured severity, description, and target UI (for alarm filtering).

## How to Use

On the General page, you can see an overview of all service children.

The Alarms table displays all alarms generated based on the alarms configuration (see Initialization).

## Notes

If a default configuration needs to be pushed (when no configuration is available), a custom version of this protocol must be used.
It is possible to clear the configuration via a context menu or by setting parameter 2097 (in an Automation script).
