---
uid: Protocol.Params.Param.SNMP-options
---

# options attribute

Specifies a dynamic get or set community string for a particular connection.

## Content Type

string

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Remarks

In the Param tag of the parameter that will contain the GetCommunity string to be used whenever an SNMP Get command has to be performed on connection 0 (i.e. the first connection), specify the following SNMP tag:

```xml
<SNMP options="GetCommunity:0">
```

In the Param tag of the parameter that will contain the SetCommunity string to be used whenever an SNMP Set command has to be performed on connection 0 (i.e. the first connection), specify the following SNMP tag:

```xml
<SNMP options="SetCommunity:0">
```

> [!NOTE]
> If a parameter configured to contain a GetCommunity or SetCommunity string is either not initialized or empty, the default GetCommunity or SetCommunity string (as specified in the Element Wizard) will be used instead. The community string is only changed at runtime. So, after a restart of the element, the parameters configured to contain the community strings will be flushed.
