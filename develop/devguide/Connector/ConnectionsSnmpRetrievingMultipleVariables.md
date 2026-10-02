---
uid: ConnectionsSnmpRetrievingMultipleVariables
description: "Retrieve multiple SNMP variables in one Get request by enabling multipleGet, and understand how unavailable variables affect each SNMP version."
---

# Retrieving multiple variables

It is possible to retrieve multiple variables in a single get request. To do so, set the [multipleGet](xref:Protocol.Groups.Group.Content-multipleGet) attribute of the `Group.Content` tag to "true". This will result in a single get request being sent containing multiple variable bindings.

Keep in mind that `Group.Content@multipleGet` should only be used for **individual parameters** in an SNMP Get request. For parameters of type `array`, use the table-specific [SNMP OID options](xref:Protocol.Params.Param.SNMP.OID-options) retrieval methods instead.

```xml
<Group id="19100">
  <Name>SNMP General System Parameters Group</Name>
  <Type>poll</Type>
  <Content multipleGet="true">
     <Param>19100</Param>
     <Param>19101</Param>
     <Param>19102</Param>
  </Content>
</Group>
```

> [!NOTE]
> According to the SNMPv1 specification (RFC1157), as soon as one object in the variable bindings field of a get request is not available in the MIB view, the value of the error status field of the corresponding response will be set to "noSuchName". Consequently, none of the requested variables will be shown in DataMiner. In SNMPv2 (and SNMPv3), this behavior has changed (RFC3416), and this no longer results in a "noSuchName" error. Therefore, for SNMPv2 and SNMPv3, the other requested variables (i.e., the ones that are available) will be shown in DataMiner.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Groups.Group.Content](xref:Protocol.Groups.Group.Content)
