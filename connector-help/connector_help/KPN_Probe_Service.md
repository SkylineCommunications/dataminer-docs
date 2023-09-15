---
uid: Connector_help_KPN_Probe_Service
---

# KPN Probe Service

This service protocol makes it possible to generate alarms based on the alarm states of the elements included in the service.

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

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the **Source Destination Config** page, you can configure up to three sources and destinations of what is included in the service. Then you can configure in which cases alarms need to be generated on the **Alarm Configuration** page.

If the **Customer** property is configured to one of the known users for this protocol (NPO, RTL or Discovery), the configuration will automatically be pushed when the expected service elements are available.

## How to Use

Based on the configuration (see Initialization), alarms will be generated in the Alarms table. If no configuration is available, this will be indicated by an alarm.

## Notes

This protocol was developed for specific users for the B2B project.
