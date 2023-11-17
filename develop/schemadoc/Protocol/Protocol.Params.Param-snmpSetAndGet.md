---
uid: Protocol.Params.Param-snmpSetAndGet
---

# snmpSetAndGet attribute

Performs a set and get on a "write" parameter.

## Content Type

string

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

When defined on columns with the default value true, cells are retrieved via an Execute Next. The get will not be executed when the set failed.

For a list of possible values, see [dynamicSnmpGet](xref:Protocol.Params.Param.Type-dynamicSnmpGet).

*Feature introduced in DataMiner 8.0.7 (RN 6962).*

> [!NOTE]
>
> - From DataMiner 9.0.1 (RN 12017) onwards, the SnmpSetAndGet method can be triggered by means of a button inside a table cell. When the button is clicked, the value of the button will be sent along with an SNMP Set command.
>
> - From DataMiner 9.0.2 (RN 12409) onwards, you can specify a multipleGet option when retrieving table data using dynamicSnmpGet or snmpSetAndGet, allowing a reduction of the number of SNMP requests. For more information see dynamicSnmpGet.
>
> - In case the SNMP connection through which this set and get operation must be performed is not the main connection, make sure to specify the connection ID in the "connection" options:
>
>    ```xml
>    <Param id="1282" snmpSetAndGet="executeNext">
>      ...
>      <Type options="connection=1">write</Type>
>    </Param>
>     ```

## Examples

```xml
<Param id="4" trending="false" snmpSetAndGet="true">
  <Name>sysContact</Name>
  <Description>System Contact</Description>
  <Type>write</Type>
</Param>
```

When this option is used in a column, the table must use the instance option in the SNMP OID tag, because otherwise the RowKey to retrieve the value is not known.

Example:

In the example below, param 100 is the table using the instance option, and param 203 is the Write column using a Get of the row after the Set. The group that will do the Get is added to the queue via an executeNext.

```xml
<Param id="100" trending="false">
  <Name>Table 1</Name>
  <Description>Table 1</Description>
  <Type>array</Type>
  <ArrayOptions index="0">
  ...
  <SNMP>
    <Enabled>true</Enabled>
    <OID type="complete" options="instance;multipleGetNext">1.3.6.1.2.1.1.8</OID>
  </SNMP>
  ...
<Param id="203" snmpSetAndGet="row;executeNext">
  <Name>snmpSetAndGet Row</Name>
  <Description>snmpSetAndGet Row</Description>
  <Type>write</Type>
  ...
```
