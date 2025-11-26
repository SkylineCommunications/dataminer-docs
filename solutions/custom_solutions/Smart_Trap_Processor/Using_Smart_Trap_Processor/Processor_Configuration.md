---
uid: Processor_configuration
---

# Configuring processing rules

To configure a processor element, you can either use DataMiner Cube or the Smart Trap Processor tool (on the *Processor Configuration* page). The configuration described below is the same regardless of which interface is used. The only difference is that the *Processed Traps* table in the tool is called the *Processed Messages* table in the processor element in Cube.

## Trap IP Sources configuration

Before you define any rules for trap processing, you first have to specify the IP address from which traps will be sent that will be received by the DataMiner Agent hosting the processor element.

To do so, set the *Trap IP Sources* parameter to the IP address corresponding with the source of the SNMP traps sent to the DataMiner System.

This could for example be the IP address of an SNMP manager that aggregates traps for many devices, or it could be the IP address corresponding to a single device. In the screenshot below, the loopback address is used, meaning that the traps come from the DataMiner Agent itself.

![Smart Trap Processor IP Sources](~/dataminer/images/TrapProcessor_IPSources.png)

You can also specify multiple IP addresses, using a comma as separator.

When a trap source IP has been configured, proceed to the rest of the processing configuration in the [Rules Table](#rules-table-configuration), [Source Name Table](#source-name-table-configuration), [Source IP Name Table](#source-ip-name-table-configuration), and [Auto Clear Configuration section](#auto-clear-configuration).

## Rules Table configuration

The rules defined in the Rules Table determine which traps from the source are processed to be displayed and monitored in the *Processed Traps* table and *Heartbeat Traps* table.

![Trap Processor Rules Table](~/dataminer/images/TrapProcessor_RulesTable.png)

- **Rule Status**: If a row should be considered when processing a trap, set this to *Enabled*; otherwise, set it to *Disabled*.

- **Rule Type**: Set this to *Regular* for traps that should be displayed in the *Processed Traps* table, or to *Heartbeat* for traps that should be displayed in the *Heartbeat Traps* table.

- **Heartbeat Interval**: The expected interval of time between heartbeats that has been configured in the trap manager or device outside of DataMiner. The tool uses the interval you specify here to calculate the heartbeat status by comparing the interval to the time since the last heartbeat.

- **Priority**: The priority for the rule. The received trap will be processed according to the first matching rule.

- **Event State Method**: Set this to *OID* to use the OID to determine if a trap is an alarm/clear event, or to *Binding* to use a binding value instead.

- **Event State Binding**: If *Event State Method* is set to *Binding*, this is the binding index containing the value that will be used to determine if a trap is an alarm or clear event. For example, for binding 4, specify `$4`.

- **Event Value Set**: If *Event State Method* is set to *Binding*, this is the value that determines if the received trap is an alarm. Supports wildcard matching.

- **Event Value Clear**: If *Event State Method* is set to *Binding*, this is the value that determines if the received trap is a clear event. Supports wildcard matching.

- **Raw OID Set**: The OID of a trap representing the raised/alarm state of a trap event.

- **Raw OID Clear**: The OID of a trap representing the cleared state of a trap event. If this is the same as the *Raw OID Set* value, *Event State Method* must be set to *Binding* to specify set and clear values.

- **Unique Entry**: Enter a value to define a unique entry for each row in the *Processed Traps* table, for example `$4/$9/$2`.

  This value must be something that always matches the raised and cleared traps for a particular type of event. This way, the raised/cleared events can be correlated via a matching unique entry, resulting in a single row in the *Processed Traps* table. The event state can then be tracked and monitored depending on whether the last processed trap was a raised or cleared condition.

  You can use the following **placeholders** in this value:

  - Binding n: `$n`

  - Severity: `$SEV`

  - Source IP: `$IP`

  - Source IP name: `$IPN`

  - Source name: `$SN`

- **Alarm Set**: Enter a value to define the format and content used for the alarm parameter in the *Processed Traps* table, for example `$1`.

  If the last received trap corresponds to a raised state, the value defined here will be displayed in the *Processed Traps* table.

  You can use the following **placeholders** in this value:

  - Binding n: `$n`

  - Severity: `$SEV`

  - Source IP: `$IP`

  - Source IP name: `$IPN`

  - Source name: `$SN`

- **Alarm Clear**: Enter a value to define the format and content used for the alarm parameter in the *Processed Traps* table, for example `$1`.

  If the last received trap corresponds to a cleared state, the value defined here will be displayed in the *Processed Traps* table.

  You can use the following **placeholders** in this value:

  - Binding n: `$n`

  - Severity: `$SEV`

  - Source IP: `$IP`

  - Source IP name: `$IPN`

  - Source name: `$SN`

- **Clear After**: Optional. In case traps without distinct set and clear OIDs are being processed, the interval set here determines the amount of time that an event can remain active before it is cleared. Leave this parameter blank if you do not need it.

- **Severity**: Enter a value to determine the severity for a matching trap.

  The defined value will be used to determine the content of the `$SEV` placeholder if it is used in the *Unique Entry*, *Alarm Set*, and *Alarm Clear* columns.

  You can use the following **placeholder** in this value:

  - Binding n: `$n`

- **Binding 1-20 Filter**: Here you can define a wildcard filter for the data in the bindings of a trap. Each binding has its own filter (binding 1-20). If a filter is specified, traps will only be processed by the rule if the information in the binding matches the filter.

   The filters are case-sensitive. The following wildcard functionality is available: `value*`, `*value`, `*value*`, `value?`, `?value`, `?value?`.

- **Delete**: Click this button to delete the rule.

- **Duplicate**: Click this button to duplicate the rule with a different priority.

## Source Name Table configuration

In this table, you can optionally define the names that should be used for the *Source Name* parameter in the *Processed Traps* table.

You can use this to give each event row in the *Processed Traps* table a description of the related device or system. For example, if the traps processed in a particular row correspond to a temperature alarm in rack #1 of the data center, the source name defined could be "Temp Sensor – Rack #1".

The source name definition can also utilize binding placeholders rather than a hard-coded string, so that the displayed source name is dynamic based on the processed trap. In most cases, this should be set to something that will always match both the raised and cleared event states.

> [!NOTE]
> You do not have to configure this table for traps to be processed properly. It is especially useful if a single trap processor element is used to process traps for more than one device.

![Trap Processor Source Name Table](~/dataminer/images/TrapProcessor_SourceNameTable.png)

- **Priority**: The priority for the source name rule. The received trap will be processed according to the first matching source name rule.

- **IP Address**: The IP address from which the traps must originate. This needs to match at least one of the IP addresses defined in the [*Trap IP Sources* parameter](#trap-ip-sources-configuration).

- **Source Name**: Enter the value that should be displayed as the *Source Name* in the *Processed Traps* table.

  You can enter a hard-coded string, or you can use the following placeholder:

  - Binding n: `$n`

- **Binding 1-20 Filter**: Here you can define a wildcard filter for the data in the bindings of a trap. Each binding has its own filter (binding 1-20). If a filter is specified, traps will only be processed by the rule if the information in the binding matches the filter.

   The filters are case-sensitive. The following wildcard functionality is available: `value*`, `*value`, `*value*`, `value?`, `?value`, `?value?`.

- **Delete**: Click this button to delete the rule.

- **Duplicate**: Click this button to duplicate the rule with a different priority.

## Source IP Name Table Configuration

In this table, you can optionally define the values that should be used for the *Source IP Name* parameter in the *Processed Traps* table.

The value you specify should describe the device or system corresponding to the IP address set in the *Trap IP Sources* parameter. For example, If the source IP corresponds to a Compass brand trap management system, you could enter the source IP name "Compass Manager".

> [!NOTE]
> You do not have to configure this table for traps to be processed properly

![Trap Processor Source IP Name Table](~/dataminer/images/TrapProcessor_SourceIPNameTable.png)

- **IP Address**: The IP address from which the traps must originate. This needs to match at least one of the IP addresses defined in the [*Trap IP Sources* parameter](#trap-ip-sources-configuration).

- **Source IP Name**: Enter the value that should be displayed as the *Source IP Name* in the *Processed Traps* table.

- **Delete**: Click this button to delete the rule.

## Auto-Clear Configuration

In the auto-clear section, you can configure parameters that will determine the maximum number of rows and the maximum time that traps will remain in the *Processed Traps* table.

![Auto Clear Settings](~/dataminer/images/TrapProcessor_AutoClear.png)

- **Event Cleanup Timer**: The interval at which the cleanup logic runs for the event tables.

- **Maximum Age of Events**: The maximum age of events before these are removed from the tables. The timespan entered is compared to the latest timestamp of each row in the event tables to determine if a row should be removed.

- **Keep Active**: If you enable this option, rows that have the event state “Active” will never be removed from the event table regardless of how old the active trap is.

- **Max Processed Messages**: The maximum number of entries to keep in the *Processed Traps* table.

- **Max Received Traps**: The maximum number of entries to keep in the *Received Traps* table.
