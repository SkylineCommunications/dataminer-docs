---
uid: Protocol.Params.Param.ArrayOptions.ColumnOption-pollingRate
---

# pollingRate attribute

<!-- RN 16411 -->

Specifies the polling rate of this column (in ms).

## Content Type

unsignedInt

## Parent

[ColumnOption](xref:Protocol.Params.Param.ArrayOptions.ColumnOption)

## Remarks

As data in some columns (e.g. interface name) may be expected to change less frequently than data in other columns, it is possible to configure a slower poll cycle for specific columns.

To specify a column-specific poll cycle for a specific column, add a pollingRate attribute, and set its value to a number of milliseconds.

Note that the polling rate that will eventually be used for the column also takes into account the corresponding timer interval of the table.

**SNMP instance must be stored in the table**

For this feature to work, the SNMP instance must be stored in the table. This way, it is possible to keep track of the instances that have already been polled. Also, if a new instance is added to the SNMP table, all columns for that specific instance can immediately be polled in order to retrieve all information available for a particular instance.

In order to have the SNMP instance stored in the index column, go to the `<SNMP>` tag of the table parameter, and add the "instance" option to the options attribute of the `<OID>` tag. For example:

```xml
<Param>
  ...
   <SNMP>
      <Enabled>true</Enabled>
      <OID type="complete" options="instance;multipleGetNext">1.3.6.1.2.1.2.2</OID>
   </SNMP>
  ...
</Param>
```

> [!NOTE]
> When, during a particular poll, a new instance is discovered in the table, the entire row will be polled instead of only the columns that had to be polled at that moment.

## Examples

In the following example, every 10 seconds a protocol timer executes the group in which the table is polled.

- Columns 5, 6, 7 and 8 do not have a column-specific poll cycle and will therefore be polled every 10 seconds.
- Column 1 has a column-specific poll cycle of 11 seconds, but as the protocol timer is set to 10 seconds, it will be polled every other poll cycle, i.e. every 20 seconds.
- Column 2 has a column-specific poll cycle of 20 seconds, and will be polled every 20 seconds.
- Column 3 has a column-specific poll cycle of 21 seconds and column 4 has a column-specific poll cycle of 30 seconds. Both will be polled every 30 seconds.

```xml
<ArrayOptions index="0">
  <ColumnOption idx="0" pid="1001" type="snmp" options=""/>
  <ColumnOption idx="1" pid="1002" type="snmp" pollingRate="11000" options=""/>
  <ColumnOption idx="2" pid="1003" type="snmp" pollingRate="20000" options=""/>
  <ColumnOption idx="3" pid="1004" type="snmp" pollingRate="21000" options=""/>
  <ColumnOption idx="4" pid="1005" type="snmp" pollingRate="30000" options=""/>
  <ColumnOption idx="5" pid="1006" type="snmp" options=""/>
  <ColumnOption idx="6" pid="1007" type="snmp" options=""/>
  <ColumnOption idx="7" pid="1008" type="snmp" options=""/>
  <ColumnOption idx="8" pid="1009" type="snmp" options=""/>
  <ColumnOption idx="9" pid="1010" type="retrieved" options=";save"/>
</ArrayOptions>
```
