---
uid: Monitoring_Processed_Traps
---

# Monitoring Processed Traps

Once at least one trap processor element has been configured to process traps from a valid source that is actively generating events, you can monitor the processed events and heartbeats on the *Processed Traps* page of the Smart Trap Processor tool.

![Smart Trap Processor home page](~/dataminer/images/TrapProcessor_Overview.png)

- At the top, you can find the total number of trap processors available for monitoring.

- Each available trap processor element is displayed in a grid view. You can select an element in the grid to filter the data below the grid so that only information for that processor element is shown.

- Each element block in the grid shows the element name, state, current alarm status, trap IP sources, maximum age of events, *Keep Alive* setting, protocol name, and protocol version.

- When an element is selected, the following information is shown above the *Processed Traps* table:

  - The number of active events in the *Processed Traps* table.

  - The number of cleared events in the *Processed Traps* table.

  - The number of events matching various alarm severities: Critical, Major, Minor, Warning.

- When an element is selected, you will find the following information in the *Processed Traps* table:

  - **Alarm Description**: Values corresponding to the *Alarm Set* and *Alarm Clear* parameters in the [Rules table](xref:Processor_configuration#rules-table-configuration).

  - **Event State**: This can be *Active* or *Cleared*, depending on whether the last processed trap for the row matched the Set or Clear OID defined in the [Rules table](xref:Processor_configuration#rules-table-configuration).

  - **Timestamp**: The time when the last event was processed for a row.

  - **Trap Count**: The total number of traps that have been processed for a row.

  - **Source IP**: The IP address from which the trap events originated.

  - **Source IP Name**: The name specified for the IP source in the [Source IP Name table](xref:Processor_configuration#source-ip-name-table-configuration).

  - **Source Name**: The name specified for the event source in the [Source Name table](xref:Processor_configuration#source-name-table-configuration).

  - **Unique Entry**: The unique entry value specified in the [Rules table](xref:Processor_configuration#rules-table-configuration).

  > [!NOTE]
  > Active events are shown at the top of the table. Aside from this, the events are sorted by descending timestamp.

- When an element is selected, you will find the following information in the *Heartbeat Traps* table:

  - **Unique Entry**: The unique entry value specified in the [Rules table](xref:Processor_configuration#rules-table-configuration).

  - **Source IP**: The IP address from which the trap events originated.

  - **Source IP Name**: The name specified for the IP source in the [Source IP Name table](xref:Processor_configuration#source-ip-name-table-configuration).

  - **Heartbeat Status**: Can be *FAIL* or *OK*, depending on whether the time since the last heartbeat exceeds the expected interval set in the [Rules table](xref:Processor_configuration#rules-table-configuration).

  - **Time Since Last Heartbeat**: The time since the last heartbeat, calculated by comparing the current time with the timestamp for the last processed heartbeat trap for a row.

  - **Heartbeat Interval**: The expected interval of heartbeats from a source as defined in the [Rules table](xref:Processor_configuration#rules-table-configuration).

  - **Trap Count**: The total number of traps that have been processed for a row.
