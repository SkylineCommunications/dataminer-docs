---
uid: Connector_help_British_Telecom_Penalty_Box
---

# British Telecom Penalty Box

The British Telecom Penalty Box groups service-impacting alarms in the DMS and triggers the Penalty Box Configuration Automation script to display the affected service with the highest priority on the screen.

## About

The British Telecom Penalty Box retrieves a string of combined alarm information from the Penalty Box Configuration Automation script. The alarm data is extracted from this string and the alarms are individually stored in the Alarm Table. This table is periodically checked and the alarms are grouped per service in the Service Table. If a change occurs to the service with the highest priority in the Service Table, the Penalty Box Configuration Automation script is triggered for this service.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Services

This page displays the **Service Table**, which contains the following parameters:

- **Priority**
- **Service Name**
- **Service Priority**
- **Service Alarm Severity**
- **Service Network Location**
- **Service UMD Text**
- **Play Now**
- **Priority Actions:** Move Up and Move Down
- **Remove**

The **Display Video in All Quadrants** parameter allows you to configure whether the video stream will be displayed in all four quadrants. The **Service Counter** displays the number of services in the Service Table.

The **Alarm Table** page button opens the Alarm Table subpage. The Alarm Table contains all the active alarms regarding the services. The table is periodically checked for changes. You can set the time between each check in the **Time Before Alarm Processing** parameter.

The **Add Service** page button allows you to manually add a new service to the Service Table. First set the **Service Name**, **Service Priority**, **Service Network Location** and **Service UMD Text** before you press the **Add New Service** button. The new service will then be added to the table.

If the **Cycling Mode** parameter is enabled, the connector runs through the list of monitored services defined in each DataMiner Penalty Box and displays them one by one.

The **Display Duration** defines the amount of time the services will be displayed in cycling mode. The value can be between one and five minutes.

## Notes

This connector should be used together with the following Automation scripts:

- Penalty Box Alarms
- Penalty Box Configuration
- Penalty Box Clear
- Penalty Box Update Service Count
