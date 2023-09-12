---
uid: Connector_help_Measat_Tie_Line_Manager_Service_Feed
---

# Measat Tie Line Manager Service Feed

The Measat Tie Line Manager Service Feed connector is a service protocol designed specifically for the Tie Lie Manager architecture. The connector extends the "Skyline Service Definition Basic" connector and makes use of InterApp communication to implement a publish-subscribe methodology. In this context, the Tie Line Manager connector can be considered a subscriber while Service Feed connectors are publishers. This means that each service update has the Service Feed connector pushing a message to the subscribed connectors.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

When you create the service, select this connector as the service protocol. For more information on how to create a service, refer to the DataMiner User Guide.

## How to use

The service will have the following data pages:

- **General**: Displays the current alarm state of the service.
- **Alarms**: Lists the alarms involved in this service in the Active Service Alarms table. To enable this table, set **Monitor Active Alarms** to *Enabled*.
- **Elements**: Lists the child elements of the service and their alarm state in the Service Element Status table. Also displays the summary alarm status of all elements and services included in this service.
- **Properties**: Displays the current values of the service properties, as well as the last sub-service that was updated.
- **Subscribers**: Lists all elements that subscribed for service updates in the Subscribers table. If an element subscribes only to a subset of data, you can see this in the "Subscriptions" column.
