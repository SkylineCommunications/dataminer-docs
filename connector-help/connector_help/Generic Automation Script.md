---
uid: Connector_help_Generic_Automation_Script
---

# Generic Automation Script

This driver can be used to launch Automation scripts and get status information for those Automation scripts.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This driver allows you to launch Automation scripts and check information on those Automation scripts.

To use the driver, set the parameter **Request** with a block of JSON code to start the script, for example:*{"ScriptName": "ExtractMaterials","ScriptParams": {"ContentXml": "Test"},"ScriptDummies":{"FunctionDve":{"DmaId":123,"ElementId":456}}}*

## Notes

The DLL **ProcessAutomation.dll** must be available in the system.
