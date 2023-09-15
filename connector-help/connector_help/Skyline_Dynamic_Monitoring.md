---
uid: Connector_help_Skyline_Dynamic_Monitoring
---

# Skyline Dynamic Monitoring

This connector is a service definition and can be used to enhance services in a DataMiner System.

## About

This connector allows the dynamic monitoring of elements included in a specific service. It makes it possible to toggle the monitoring of a specific element within the service based on certain conditions, which can be at service or element level, for example if the element is in timeout because of a known issue. In such cases, custom descriptions can be assigned to parameters of the target elements, and their monitoring can be toggled based on keywords (e.g. **uAu** for monitor and **uNu** for do not monitor). This way, with just one click, operators can disable or enable the monitoring of elements included in a service.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

This connector is a service definition. When you create or edit a service, you can assign the connector to the service to enhance its functionalities.

## Usage

By default, each service has a **Devices** section, listing the elements and parameters included in the service, using the element aliases specified in the service configuration. If the Skyline Dynamic Monitoring service definition has been assigned to a service, it also has a **Summary** section, which contains the enhancements included in this service definition. Within this section, you will find the pages detailed below. The **Activation** page is the most important of the pages and contains the core functionalities of the service definition.

### General

This page displays the **Service Severity**, which is the overall alarm severity of the service.

### Alarms

At the top of this page, you can find the **Monitor Active Alarms** toggle button, which determines if active alarms are listed in the **Active Service Alarms Table** below it. If the toggle button is enabled, the table will provide an overview of the different properties of the current alarms (e.g. Alarm ID, Severity, Time, etc.)

### Elements

This page contains the **Service Element Status** table, which displays information about the elements in the service (e.g. Alias, Element Name, Severity, etc.).

### Activation

This page includes all relevant parameters taken into account for the **dynamic monitoring** of elements.

- **Service Status**: This parameter toggles the monitoring of elements.

  - ***Active***: Element parameters that are part of the service should be monitored and they should influence the alarm status of the service.
  - ***Inactive***: Element parameters that are part of the service should not be monitored and they should not influence the alarm status of the service.
  - Note that these actions will only be applied to those element parameters listed in the **Profile Summary Table** (see below).

- **Active Label**: This parameter indicates which string determines if parameters are monitored. If the target parameter belongs to a table row of which the index contains the Active Label, that cell will be monitored. The value of this label is currently hard coded in the connector as **uAu**.

- **Inactive Label**: This parameter indicates which string determines if parameters should not be monitored. If the target parameter belongs to a table row of which the index contains the Inactive Label, that cell will not be monitored. The value of this label is currently hard coded in the connector as **uNu**.

- **Profile Name**: This is the name of the **Profile Manager definition** that will be used to populate the **Profile Summary Table**. Below this, there are two buttons:

  - **Reload**: This button will update the Profile Name drop-down box with all the existing DataMiner Profile Manager definitions. You then need to select the definition that will work with the connector in the drop-down box.
  - **Apply**: This button will apply the content of the selected definition to the **Profile Summary Table**.

- **Profile Summary Table**: This table contains the information used to apply the **Service Status** (see above). For the table to be populated with useful data, the following conditions need to be met:

  1. **DataMiner Profile Manager**: For each element of interest in the service, a parameter needs to be created in the **Profile Manager** app. The **Name** of this parameter must be the same as the **Alias** assigned to the specific element in the service. The Profile Manager parameter **Linked With** section will be used to extract the information needed to populate the fields of the Profile Summary Table.
  1. **Service**: The target elements need to be currently **included** in the service for them to be considered by the logic.
  1. **Element**: The target parameters should include the **Active/Inactive Label** for them to be considered by the logic.
