---
uid: Protocol.Params.Param.SNMP.TrapOID-mapAlarm
---

# mapAlarm attribute

Allows an alarm to be generated when a trap is received.

## Content Type

string

## Parent

[TrapOID](xref:Protocol.Params.Param.SNMP.TrapOID)

## Remarks

The first part must be TRUE or FALSE, to enable or disable the mapping of alarms.

The order of the following items (separated by pipe characters) is irrelevant.

|Item|Description|
|--- |---|
|Severity|The “Severity” item is followed by the number of the binding that contains the severity. A mapping can then be done between the severity levels of DataMiner and the severity levels contained in the trap: `[DataMinerLevel],[TrapLevel1],[TrapLevel2],...;[DataMinerLevel],...` The severity level(s) of the trap can contain an asterisk (“*”). The order of the severity levels is irrelevant, and not all the levels must be used. The first level that matches the trap is used in the alarm, so the order could be important when using wildcards. The latest tendency, however, is to allow the DataMiner user to change the severity of an alarm by means of an alarm template. In that case, the “Severity” and the “Value” item are defined in the Protocol.Params.Param.SNMP.TrapMappings tag.|
|Value|The “Value” item is the text that is displayed in the value of the alarm. Bindings can be inserted by specifying their numbers between square brackets. Default value: an enumeration of all the bindings|
|Link|The “Link” item links alarms to each other. In the example below, all traps that have the same value for binding 1 and 2 will be linked together until a normal alarm appears. It is also possible to specify something like this: Link:1,2;3,4. Then, when a trap enters, it will look for a previously received trap with the binding combination 1,2 and it will remember the combination 3,4 of the current trap for future trap linking. In other words, you need to specify which binding or combination of bindings it can find in another trap and you need to specify where this can be found in that other trap. Negative values can be used before the binding numbers
to make groups. Example: Link:-1,3,4 will link all bindings 3 and 4 where the group is -1.|
|IgnoreSingleClear|If this predefined value is used, then, when a normal alarm enters without a critical alarm, no alarm will be generated.|

Note that it is possible to specify full OIDs instead of positions.<!-- RN 13794 -->

```xml
<TrapOID checkBindings="1.3.6.1.2=*value*|1.3.6.1.3=id:101" setBindings="1.3.6.1.2,102;1.3.6.1.3,103;1.3.6.1.4,104;1.3.6.1.5,105;1.3.6.1.6,106" ipid="100" mapAlarm="TRUE|Severity:1.3.6.1.4:Normal,Normal;Warning,Warning*;Minor,Minor,Minor low,minor high;Major,Major*;Critical,Critica*;Timeout,Timeout;Information,Information|Value:A trap is received: '[1.3.6.1.2]' and '[1.3.6.1.3]' and '[1.3.6.1.4]'|Link:1.3.6.1.5,1.3.6.1.6" type="complete">*</TrapOID>
```
