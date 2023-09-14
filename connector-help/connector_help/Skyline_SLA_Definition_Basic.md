---
uid: Connector_help_Skyline_SLA_Definition_Basic
---

# Skyline SLA Definition Basic

With this connector, you can track **Service Level Agreement (SLA)** compliance in real time.

## About

This connector allows the real-time tracking of SLAs. When a new alarm occurs on the underlying service, a new outage is added to the list. Other parameters are automatically updated to reflect the outages in the current time frame. This time frame can be either a fixed window or a sliding window. This way, early warnings can be generated when SLAs degrade, so that penalties can be prevented.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact**                                                                                                                                                                                                                                                                                                                                             |
|----------------------|------------------|--------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | \-               | \-           | Obsolete                                                                                                                                                                                                                                                                                                                                                      |
| 1.1.0.x              | \-               | \-           | Obsolete                                                                                                                                                                                                                                                                                                                                                      |
| 2.0.0.x              | Initial version  | 1.1.0.9      | Driver range maintained and validated by Server & QA Team.                                                                                                                                                                                                                                                                                                    |
| 3.0.0.x \[SLC Main\] | Initial version  | 2.0.0.9      | Driver range maintained and validated by Server & QA Team.                                                                                                                                                                                                                                                                                                    |
| 4.0.0.x              | Customer branch  | 3.0.0.9      | Changes in this range are not validated by Server & QA Team. Possible impact if key features inherited from range 3.0.0.x are changed. Changes implemented in 4.0.0.1: - PID 1: Added trending="true" - PID 4: Added RTDisplay true - PID 11: Added trending="true" and snapshot="true" - PID 53: Changed display range high value to 44640, instead of 10080 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 2.0.0.x   | No                  | No                      | \-                    | \-                      |
| 3.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 4.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

Create a new SLA:

1. Give the SLA a unique **Name**.
2. Select the **Service** that has to be tracked by the SLA.
3. Select the **Protocol** "*Skyline SLA Definition Basic*". For the **Version**, it is recommended to select "*Production*".
4. Select an **Alarm** and **Trend template** to monitor the SLA.

### Configuration

Once the SLA element has been created, go to the **SLA Configuration** page to configure the following settings:

- **Window settings**

  - **Type**: *Fixed Time Window* or *Sliding Time Window.*
  - **Time** and **Unit**: e.g. *1 month*.

- **Alarm settings**

  - **Violation level**: Defines from which service alarm level the SLA must indicate that it has been violated.
  - **Delay time**: A delay (in seconds) before the SLA starts indicating that it has been violated (e.g. for backup delays).
  - **Minimum outage threshold**: An initial timespan during which a new alarm is not taken into account.
  - **Violation settings**: Optional filters to modify the impact of certain types of alarms.

- **Extra settings**

  - **Admin State**: Activate or deactivate tracking of the SLA.
  - **Reset** of the counters of the SLA.
  - **Base timestamp**: Can be customized to define a fixed window that does not start at e.g. the beginning of the month.
  - **Time to keep outages**: Determines how long outages are kept in the SLA outage list.
  - **SLA validity start and end time**: The start and end time for the period during which the SLA is valid.

In addition, on the **Compliance Configuration** page, configure the following settings:

- **Total violation**: Defines for how long the SLA may be violated during the SLA window before it is considered breached. Two types of total violation can be configured: **Absolute** (e.g. 5 minutes) or **Relative** (e.g. 0.010 percent of the total window size).
- **Single violation**: Defines how long one single violation may last before the SLA is considered breached. This is configured in the same way as the total violation.
- **Violation count**: Specifies how many violations may occur before the SLA will be considered breached.

## Usage

### Main View page

This page shows **Compliance Info**, **Performance Indicators** and **General Info.**

In the Compliance Info section, the following parameters are displayed:

- **Compliance**, with the following possible values:

  - *Compliant*: The SLA has never been violated and is currently not being violated.
  - *Breached*: The SLA has been violated beyond the acceptable limits, i.e. penalties could be due.
  - *Compliant (degraded)*: The SLA has been violated, but not beyond the acceptable limits.
  - *Compliant (degrading)*: The SLA is currently being violated.

- **Predicted Compliance**

  - Violation info, such as the **Total** **and** **Single violation time left** and the **Number of violations left**.

In the Performance Indicators section, you can find the following information:

- **Availability**
- **Predicted availability**
- **Total violation time**
- **Longest violation time**
- **Number of violations**
- ...

In the General Info section, you can find the following information:

- The **Service name** and **alarm state**
- **Current outage impact**
- **Admin state**: *Tracking* or *No tracking*
- ...

### Outage list page

This page shows a history of all severity changes of the service being tracked, together with a timestamp and the SLA status.

It is possible for an administrator to correct the impact of a violation and then enter a motivation for the correction percentage.

Manual outages can be added and removed using the page buttons. In the most recent versions of the 2.0.0.x and 3.0.0.x ranges, this has been replaced by dependencies for creation and an option in the context menu for deletion. Multiple rows can be selected so they can be deleted in bulk.

### Affecting Alarms

This page shows a list of the alarms currently affecting the SLA.

### History page

This page displays compliance info for this SLA for tracking periods in the past.

### SLA Configuration page

Refer to the Configuration section above.

### Compliance Configuration page

Refer to the Configuration section above.

### Ticket Creation page

This page contains a parameter that can be picked up by an Automation script to automatically create a ticket.

### Offline window

On this page, a window can be configured when the SLA is offline.

## Notes

The "SLSLAOutageConfiguration.dll" dll must be placed in the same folder as the "protocol.xml" file, e.g. "*C:\Skyline DataMiner\Protocols\Skyline SLA Definition Basic\1.1.0.10*".
