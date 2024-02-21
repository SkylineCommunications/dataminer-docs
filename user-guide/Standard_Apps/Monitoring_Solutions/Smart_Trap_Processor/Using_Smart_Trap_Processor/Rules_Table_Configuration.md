---
uid: Rules_table_configuration
---

# Rules Table Configuration

The rules defined in the Rules Table will dictate which traps from the source will be processed to be displayed and monitored on the *Processed Messages* table and *Heartbeat Traps* table.

![Trap Processor Rules Table](~/user-guide/images/TrapProcessor_RulesTable.png)

- *Rule Status*: Togglable between Enabled or Disbaled to control is a row should be considered when processing a trap.
- *Rule Type*: Type can be set to Regular or Heartbeat. Regular rules dictate which traps are processed and displayed on the Processed Messsages table. Heartbeat rules dictate which traps are processed and displayed on the Heartbeat Traps table. 
- *Heartbeat Interval*: The expected interval of time between heartbeats that has been configured on the trap manager or device outside of DataMiner. The interval set on this parameter is used to calculate the heartbeat status by comparing the interval to the time since last heartbeat.
- *Priority*: Defines the priority for the rule. The received trap will be processed by the fist matching rule.
- *Raw OID Set*: The OID of a trap representing the raised/alarmed state of a trap event.
- *Raw OID Clear*: The OID of a trap representing the cleared state of a trap event.
- *Unique Entry*: The format specified here is used to define a unique entry for each row on the processed messages table. It is important that the Unique Entry be set to something that will always match between the raised and cleared traps for a particular type of event. This mechanism of correlating the raised/cleared events via a matching Unique Entry results in a single row on the Processed Messages table. In doing so, the event state can then be tracked and monitored depending if the last processed trap was a raised or cleared condition. 

    > [!NOTE]
    > the value entered can utilize the following place holders:
    > - Binding n: $n
    > - Severity: $SEV
    > -	Source IP: $IP
    > -	Source IP Name: $IPN
    > -	Source Name: $SN
    >
    > Example: $4/$9/$2

- *Alarm Set*: The value entered here determines the format and content used for the alarm parameter on the Processed Messasges table. If the last received trap corresponds to a raised state, the value defined on Alarm Set will be displayed on the Processed messages table.

    > [!NOTE]
    > the value entered can utilize the following place holders:
    > - Binding n: $n
    > - Severity: $SEV
    > -	Source IP: $IP
    > -	Source IP Name: $IPN
    > -	Source Name: $SN
    >
    > Example: $1

- *Alarm Clear*: The value entered here determines the format and content used for the alarm parameter on the Processed Messasges table. If the last received trap corresponds to a cleared state, the value defined on Alarm Clear will be displayed on the Processed messages table. 

    > [!NOTE]
    > the value entered can utilize the following place holders:
    > - Binding n: $n
    > - Severity: $SEV
    > -	Source IP: $IP
    > -	Source IP Name: $IPN
    > -	Source Name: $SN
    >
    > Example: $1

- *Clear After*: In the case that traps without distinct set and clear OIDs are being processed, the interval set here determines the amount of time that an event can remain active before being cleared.

    > [!NOTE]
    > A Clear After value is not required to be specified. This parameter can be left blank if it is not needed.

- *Severity*: Defines the severity for a matching trap. The value and format defined is used to determine content of the $SEV placeholder if it is used on Unique Entry, Alarm Set, Alarm Clear. 

    > [!NOTE]
    > the value entered can utilize the following place holders:
    > - Binding n: $n

- *Binding 1-20 Filter*: Wildcard filters can be defined for any of the data present in a trap’s bindings. Each binding has its own filter (binding 1-20). If a filter is specified, traps will only be processed by the rule if the information in the binding matches the filter.

    > [!NOTE]
    > the Filters are case sensitive and the following wildcard functionality is available: value*, *value, *value*, value?, ?value, ?value?.

- *Delete*: When pressed, the rule will be deleted.
- *Duplicate*: When pressed, the rule will be duplicated wth a different priority. 
