---
uid: ConnectionsSnmpDynamicallyRetrievingAVariable
---

# Dynamically retrieving a variable

Since DataMiner version 7.5, it is possible to dynamically perform a get of an SNMP parameter.

```xml
<Param id="50011" trending="false" save="true">
   <Name>Dynamic Polling OID</Name>
   <Description>Dynamic Polling OID</Description>
   <Type options="dynamic snmp get">read</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
   <Display>
      <RTDisplay>true</RTDisplay>
   </Display>
   <Measurement>
      <Type>string</Type>
   </Measurement>
</Param>
```

When setting this parameter with an OID value (e.g. "1.3.6.1.4.1.290.9.3.3.21.13.1.16.1.72") DataMiner will search the protocol and find the closest matching read parameter with an SNMP tag containing this OID.

After finding this parameter, DataMiner will create a temporary dynamic group to "get" this parameter, and add it to the group execution queue. If the OID links back to a column of a table, it will refresh the entire table.

The search procedure to find the correct parameter in the protocol will view dynamic OID pieces (using an '*') as a wildcard. For example, if you set the Dynamic SNMP Get with value "1.3.6.1.4.1.290.9.3.3.21.1.1.12.0" and there is a parameter in the driver that has OID "1.3.6.1.4.1.290.9.3.3.21.*", it will regard this parameter as the one that needs refreshing.

When you divide a large SNMP table into 2 different SNMP tables (for example, to poll table 1 faster than table 2), it is important you do not specify an OID on the table parameters when trying to use this Dynamic SNMP Get. If you fail to remove these OIDs, the search algorithm will find the first table in the protocol as a match and will stop searching for anything else, even if the requested OID is part of the second table.

The group will be added to the end of the group execution queue as it was added by a timer or an "add to execute" action.

> [!NOTE]
> This should not be used to force a get after a set as the OID needs to be set in the parameter of the dynamic SNMP. The feature was created because a device did not send the updated value(s) via traps, but only the OID(s) of the parameter(s) for which the value had changed. By capturing this OID and using this NF, it is possible to poll the new data without any delay.

Since, when there are different parameters with the same OID, one of them will be used randomly for the get, from DataMiner version 8.0 onwards, it is possible to skip certain parameters to be evaluated if they need to be retrieved via dynamic SNMP get.

```xml
<SNMP>
  <OID type="complete" ipid="201" skipDynamicSNMPGet="true">1.3.6.0</OID>
</SNMP>
```

The dynamic group will be added to the end of the group execution queue (similar to if it was added by a timer or by an "add to execute" action).

DataMiner version 8.0.7. also introduces a new attribute to improve the Dynamic SNMP Get. Previously this was defined in the options, which still can be used. However, the new improvements are only configurable in this new attribute. (This must be defined on the read parameter.)

You can configure what to get and when to get it:

```xml
<Param id="100">
  <Name>Dynamic Get OID</Name>
  <Description>Dynamic Get OID</Description>
  <Information></Information>
  <Type dynamicSnmpGet="true">read</Type>
</Param>
```

In case of table parameters you do not always want to retrieve the full table, so you will be able to specify what to get and when to get it.

Default values with attribute value "true", you will get the cell and the get will be added to the group execution queue (execute next).

What to get:

```xml
<Type dynamicSnmpGet="cell">read</Type>
<Type dynamicSnmpGet="row">read</Type>
<Type dynamicSnmpGet="column">read</Type>
<Type dynamicSnmpGet="table">read</Type>
```

Position in the group execution queue (same as defined in action):

```xml
<Type dynamicSnmpGet="addToExecute">read</Type>
<Type dynamicSnmpGet="forceExecute">read</Type>
<Type dynamicSnmpGet="executeNext">read</Type>
<Type dynamicSnmpGet="executeOne">read</Type>
<Type dynamicSnmpGet="executeOneTop">read</Type>
<Type dynamicSnmpGet="executeOneNow">read</Type>
<Type dynamicSnmpGet="execute">read</Type>
```

Combination (can be in any order):

```xml
<Type dynamicSnmpGet="row;Execute">read</Type>
```

Is the same as:

```xml
<Type dynamicSnmpGet="Execute;row">read</Type>
```

How tables are retrieved:

- cell/row: Single Gets
- column: Default MultipleGetNext (first column instance, then column PKs, then specified column)/MultipleBulk when specified in the table (MULTIPLEGETBULK:X in the options)
- table: Like before on dynamic get (instance column first, then rest via multipleGetNexts or MultipleGetBulk if specified in table options).

Depending on the precision of the requested dynamic OID and the type of retrieval, the get will be performed with the following scenarios:

Requested cell OID: 1.3.6.1.4.1.8691.2.8.1.5.1.1.2.1.4.5

Defined in the protocol:

- CELL -> Retrieve CELL
- ROW -> Retrieve ROW
- COLUMN -> Retrieve COLUMN
- TABLE -> Retrieve TABLE

Requested row OID: 1.3.6.1.4.1.8691.2.8.1.5.1.1.2.1.*.5

- CELL -> Retrieve ROW
- ROW -> Retrieve ROW
- COLUMN -> Retrieve TABLE
- TABLE -> Retrieve TABLE

Requested COLUMN OID: 1.3.6.1.4.1.8691.2.8.1.5.1.1.2.1.4

- CELL -> Retrieve COLUMN
- ROW -> Retrieve TABLE
- COLUMN -> Retrieve COLUMN
- TABLE -> Retrieve TABLE

Requested TABLE OID:

1.3.6.1.4.1.8691.2.8.1.5.1.1.2

1.3.6.1.4.1.8691.2.8.1.5.1.1.2.1

- CELL -> Retrieve TABLE
- ROW -> Retrieve TABLE
- COLUMN -> Retrieve TABLE
- TABLE -> Retrieve TABLE

> [!NOTE]
> The OIDs need to be defined on the columns and table parameters in order for the dynamic get method to find and correctly match them.
