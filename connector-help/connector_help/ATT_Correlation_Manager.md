---
uid: Connector_help_ATT_Correlation_Manager
---

# ATT Correlation Manager

The ATT Correlation Manager protocol is a custom-made connector for AT&T responsible for creating custom correlation alarms when certain conditions are met in the system.

## About

When an alarm is raised in one of the monitored parameters, a correlation rule executes an automation script that forward the alarm information to the Correlation Manager element. The Correlation Manager element places the received alarm information from the automation script in one of the five buffers based on the kind of the alarm. The protocol defines five different threads to handle the five different buffers. Depending on the alarm, the protocol check the state of certain parameters in other elements in the system and some custom properties of the impacted services. Based on the value of those parameters and properties a new correlation alarm with a custom value, severity and base alarms is raised.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

The **General** page displays the **Alarm Queue** table. This table includes all the alarm notifications that are waiting to be processed. Each row in the table represent one alarm. For each alarm, the table displays the following parameters: **ID**, **Element**, **Parameter**, **Index**, **Severity**, **Value**, **Timestamp** and **Impact**.

The **General** page also includes the **Clear Queue** button. Clicking this button clears the **Alarm Queue** table and all thread buffers.

From this page the user can access the **Threads** pop-up page by means of a page button. The **Threads** page displays the status of the five threads. Each thread can be in two states: **Idle** or **Polling**. This pop-up page also displays the **Thread Statistics** table. This table includes the average time each thread needs to process a single alarm. This aggregated statistics are calculated using the **Alarm History** table data.

### History

The **History** page displays the **Alarm History** table. This table includes all the alarm notifications that were processed by the ATT Correlation Manager element. Each row in the table represent one processed alarm. For each processed alarm, the table displays the following parameters: **ID,** **Element,** **Parameter,** **Index,** **Severity,** **Value,** **Received** **Timestamp,** **Processed Timestamp**, **Correlation Result** and **Impact.**

The **History** page also includes the **Clear History** button. Clicking this button clears the **Alarm History** table.

From this page the user can access the Auto Clear pop-up page by means of the page button. Thre Auto Clear page allows to enable/disable the auto clear feature and it includes the following parameters: **Clean Up Method,** **Maximum Rows**, **Maximum Age** and **Clear Amount.**

### Configuration

The **Configuration** page displays the **Alias** table. This table allows to define an alias for each of the main service blocks. Depending on the service template used to create the impacted services, the service blocks of interest could have different aliases. Using a context menu, new entries can be added or removed from the table.

The **Configuration** page also displays a set of toggle buttons used to enable/disable the different rules as defined by the customer's requirements.

## Revision History

DATE VERSION AUTHOR COMMENTS25/05/2018 1.0.0.1 AIG , Skyline Initial Version

## Notes

This connector is used in combination with a correlation rule that receives alarm events and an automation script (ATT Correlation Alarm Notificator) that forward the alarm information to the ATT Correlation Manager protocol.
