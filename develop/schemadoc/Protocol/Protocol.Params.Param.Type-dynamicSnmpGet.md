---
uid: Protocol.Params.Param.Type-dynamicSnmpGet
---

# dynamicSnmpGet attribute

Specifies what to retrieve (cell, row, etc.) and the way this request is added to the group execution queue.<!-- RN 6962 -->

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.Type)

## Remarks

This attribute allows dynamic polling of an SNMP parameter defined in the protocol. When the value of this parameter is set to a specific OID, the SNMP parameter with the specified OID will be polled.

Must be defined on the READ parameter. With this attribute it is possible to configure what to get and when.

Example:

```xml
<Param id="100">
    <Name>Dynamic Get OID</Name>
    <Description>Dynamic Get OID</Description>
    <Information></Information>
    <Type dynamicSnmpGet="true">read</Type>
</Param>
```

In case of a table parameter you do not always want to retrieve the entire table. When using the default value true, the cell will be retrieved with an "execute next" action.

To specify what needs to be retrieved, use one of the following options:

- Cell
- Row
- Column
- Table

```xml
<Type dynamicSnmpGet="cell">read</Type>
<Type dynamicSnmpGet="row">read</Type>
<Type dynamicSnmpGet="column">read</Type>
<Type dynamicSnmpGet="table">read</Type>
```

To specify when it has to be retrieved, add one of the following options to the action:

- addToExecute
- forceExecute
- executeNext
- executeOne
- executeOneTop
- executeOneNow
- execute

```xml
<Type dynamicSnmpGet="addToExecute">read</Type>
<Type dynamicSnmpGet="forceExecute">read</Type>
<Type dynamicSnmpGet="executeNext">read</Type>
<Type dynamicSnmpGet="executeOne">read</Type>
<Type dynamicSnmpGet="executeOneTop">read</Type>
<Type dynamicSnmpGet="executeOneNow">read</Type>
<Type dynamicSnmpGet="execute">read</Type>
```

The above-mentioned options (what and when) can be combined in any order, separated by a semicolon (`;`):

```xml
<Type dynamicSnmpGet="row;Execute">read</Type>
<Type dynamicSnmpGet="Execute;row">read</Type>
```

> [!NOTE]
>
> - The OIDs need to be defined on the columns and table parameters in order for the dynamic get method to find and correctly match them. In order to correctly update the table values, the column type needs to be retrieved (same as set column at once or fill array).
> - When you retrieve table data using dynamicSnmpGet or snmpSetAndGet, you can specify a multipleGet option to reduce the number of SNMP requests.<!-- RN 12409 --> In the following example, DataMiner will poll the row with a single SNMP Get request containing all OIDs of the entire row instead of retrieving each OID separately: `<Type dynamicSnmpGet="executeNext;row;multipleGet">read</Type>`.
> - This attribute renders the "dynamic snmp get" option obsolete.
> - In order to indicate that a protocol parameter should not be considered for dynamic retrieval through a parameter using the dynamicSnmpGet attribute, the [skipDynamicSNMPGet](xref:Protocol.Params.Param.SNMP.OID-skipDynamicSNMPGet) attribute can be used.
