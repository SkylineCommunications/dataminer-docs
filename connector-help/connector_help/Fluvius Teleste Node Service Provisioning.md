---
uid: Connector_help_Fluvius_Teleste_Node_Service_Provisioning
---

# Fluvius Teleste Node Service Provisioning

This driver allows you to check for changes in the manager elements that previously used the Kathrein VGP drivers and now use the Teleste AC3210 and AC8810 devices. The driver lists the changes that were detected, and then allows the services to be recreated with the new service template, thereby replacing the Kathrein VGP with the Teleste AC3210 and AC8810. For a new service to be created, it is only necessary that the Teleste AC8810 exists; the Teleste AC3210 is optional.

This is a virtual driver.

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

No initialization is necessary

## How to Use

The **General** page allows you to monitor and control the semi-automatic upgrade progress. This page contains two **buttons**: **Detect Changes** and **Convert Services**. You can find more information on these buttons below.

The **Create Manually** page allows you to create a service with the new service template for **Teleste AC8810** and **AC3210** devices that were never part of the old service template.

### General - Detect Changes

When the **Detect Changes** button is used, the driver will scan for added and removed AC3210 and AC8810 devices.

First, it will check that all nodes of the cluster are up and running, in order to avoid synchronization issues. Then it will compare the current list of managers with the previous time the system was scanned.

In several tables on the page, information will be displayed:

- In the **Manager Changes Table**,the AC3210 and AC8810 Managers that were added or removed will be listed, together with their state (*Added* or *Removed*).
- The Teleste **AC3210 Devices Changes Table** will list theTeleste AC3210 devices that were added or removed, the **manager element** they belong to, and their state (*Added* or *Removed*).
- The Teleste **AC8810 Devices Changes Table** will list theTeleste AC8810 devices that were added or removed, the **manager element** they belong to, and their state (*Added* or *Removed*).

The progress of the change detection process is indicated by a **progress bar**.

### General - Convert Services

After the change detection process is complete, to convert the services, the **Convert Services** button must be used within **2 minutes**. This time limit is implemented to make sure that the information is still up to date during the conversion.To see how much time is left, you can check the **Time Allowed to Apply Changes** parameter, which will count down to 0.

If the button **Convert Services** is used in time, all services that have at least a **Teleste AC8810** device will be converted to the new **service template**. The driver will read out the old data, delete the old service, and recreate the new service with the service template. Services that have the **Teleste AC3210** but lack the **Teleste AC8810** device will not be converted.

Services that have been successfully converted will be listed in the **Successfully Converted Services** **Table**, which mentions the **Service Name** and the **Manager Element** for each service.

The services that failed to be converted are listed in the **Failed Converted Services Table**. This table contains the name of the service, its manager element, the view, the address information, the type of error message, the date and time when the conversion failed and a **Retry** button. This **Retry** button can be used to retry the conversion process from the point where it failed.

A service can fail to be converted for three reasons: The system was unable to retrieve the information from the old service, the system was unable to delete the old service, or the system was unable to create the new service. In case this occurs, the service should be created manually.

### Create Manually - Detect Unassigned AC8810s

When the **Detect Unassigned AC8810s** button is used, the driver will scan for **Teleste AC8810** devices that are not part of a service with that name, excluding the AC8810 part.

First, it will check that all nodes of the cluster are up and running, in order to avoid synchronization issues. Then it will fill the **Manual Creation Services Table** with the list of detected **Teleste AC8810 devices**.

For unassigned **Teleste AC8810** devices, a service can be created manually. For this, the system will need the **View Name**, and the **Address1** and **Address2** lines, which can be specified in the **Manual Creation Services Table**. Once you have entered this information, use the **Create** button to create the service with the specified parameters, using the service template.

## Notes

The driver will only function if all nodes in the cluster are online. Otherwise, a warning will be displayed.
