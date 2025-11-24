---
uid: Protocol.Params.Param.SNMP.TrapOID-checkBindings
---

# checkBindings attribute

Specifies basic filtering on the trap bindings.

## Content Type

string

## Parent

[TrapOID](xref:Protocol.Params.Param.SNMP.TrapOID)

## Remarks

This attribute performs basic filtering on the bindings. You can compare a certain binding to a fixed string (which optionally contains wildcards), or you can compare it to the value of another parameter.

Checks must be separated by pipe characters.

In the example below, binding 2 of the trap must contain *display* and binding 3 must match the value of Parameter 102 (which can also contain wildcards). If both conditions are true, DataMiner will process the trap.

```xml
<TrapOID checkBindings="2=*display*|3=id:102"  setBindings="1,1012;2,1045" ipid="205" mapAlarm="TRUE|Severity:4:Normal,Normal;Warning,Warning*;Minor,Minor,Minor low,minor high;Major,Major*;Critical,Critica*;Timeout,Timeout;Information,Information|Value:A trap is received from '[1]': Parameter '[2]' has value '[3]'|Link:1,2" type="wildcard">1.3.6.1.4.1.8813.*</TrapOID>
```

It is also possible to specify full OIDs instead of positions.<!-- RN 13794 -->

```xml
<TrapOID checkBindings="1.3.6.1.2=*value*|1.3.6.1.3=id:101" setBindings="1.3.6.1.2,102;1.3.6.1.3,103;1.3.6.1.4,104;1.3.6.1.5,105;1.3.6.1.6,106"  ipid="100" mapAlarm="TRUE|Severity:1.3.6.1.4:Normal,Normal;Warning,Warning*;Minor,Minor,Minor low,minor high;Major,Major*;Critical,Critica*;Timeout,Timeout;Information,Information|Value:A trap is received: '[1.3.6.1.2]' and '[1.3.6.1.3]' and '[1.3.6.1.4]'|Link:1.3.6.1.5,1.3.6.1.6" type="complete">*</TrapOID>
```
