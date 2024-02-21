---
uid: Monitoring_Processed_Traps
---

# Monitoring Processed Traps

Once at least one trap processor element has been configured to process traps from a valid source which is actively generating events, the processed events and heartbeats can be monitored by navigating to the *Processed Traps* page.

![Smart Trap Processor Homepage](~/user-guide/images/TrapProcessor_Overview.png)

The following information is provided for each trap processor element and its corresponding processed traps:

- Total number of available trap processors available for monitoring.

- Each available trap processor element will be displayed in a grid view and is selectable. Selecting a processor will filter the data below the grid to information that only applies to that processor element. Information provided in each element block includes element name, state, current alarm status, trap IP sources, Max age of events, Keep Alive setting, protocol name, and protocol version.

Based on element selection:

- Number of Active events on the Processed Messages table.

- Number of Cleared events on the Processed Messages table.

- Number of Events matching various alarm severities (Critical, Major, Minor, Warning)

- Processed Messages Table:

  - *Alarm Description*: values corresponding to the Alarm Set and Alarm Clear parameters on the Rules table.

  - *Event State*: The event state will report as Active or Cleared depending if the last processed trap for the row matched the Set or Clear OID defined on the Rules table

  - *Timestamp*: Timestamp corresponding to when the last event was processed for a row.

  - *Trap Count*: Total number of traps that have been processed for a row.

  - *Source IP*: the IP address for which the trap events originated

  - *Source IP Name*: The name specified for the IP source on the Source IP Names table.

  - *Source Name*: The name specified for the event source on the Source Names table.

  - *Unique Entry*: The Unique entry value specified on the Rules table.

  > [!NOTE]
  > Events are sorted first by Active events to the top, then second by descending timestamp.

- Heartbeat Traps Table:

  - *Unique Entry*: The Unique entry value specified on the Rules table.

  - *Source IP*: the IP address for which the trap events originated

  - *Source IP Name*: The name specified for the IP source on the Source IP Names table.

  - *Heartbeat Status*: The heartbeat status will report as FAIL or OK depending if the time since last heartbeat exceeds the expected interval as set on the Rules table.

  - *Time Since Last Heartbeat*: The time since last heartbeat is calculated by comparing current time against the timestamp for the last processed heartbeat trap for a row.

  - *Heartbeat Interval*: The expected interval of heartbeats from a source as defined on the Rules table.

  - *Trap Count*: Total number of traps that have been processed for a row.

> [!NOTE]
> Default alarm and trend templates are provided upon installation of the Smart Trap Processor Tool. The default templates enable alarming and trending on the Event State and Heartbeat Status parameters. If more complex alarming thresholds are required beyond the defaults, refer to [About the alarm template editor](https://docs.dataminer.services/user-guide/Basic_Functionality/Protocols_and_templates/Alarm_templates/Configuring_alarm_templates/About_the_alarm_template_editor.html).
