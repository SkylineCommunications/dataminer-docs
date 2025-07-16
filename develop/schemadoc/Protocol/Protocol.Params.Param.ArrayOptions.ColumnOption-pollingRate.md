---
uid: Protocol.Params.Param.ArrayOptions.ColumnOption-pollingRate
---

# pollingRate attribute

<!-- RN 16411 -->

The `pollingRate` attribute allows you to slow down polling for specific SNMP columns in a table by specifying a minimum interval (in milliseconds) between polling. This attribute applies only to SNMP columns.

## Content Type

unsignedInt

## Parent

[ColumnOption](xref:Protocol.Params.Param.ArrayOptions.ColumnOption)

## Remarks

Use `pollingRate` to reduce the polling frequency for columns that change infrequently or contain large amounts of data. Set the attribute to the desired interval in milliseconds.

> [!IMPORTANT]
>
> - The [`instance`](xref:ConnectionsSnmpRetrievingTables#instance-option) option must be enabled for the table.
> - When the [**GetNext**](xref:ConnectionsSnmpRetrievingTables#instance-option) polling method is used, all columns will still be polled, but the result will not be written to the column. Setting `pollingRate` has no practical effect in this case, so it is better not to use `pollingRate` with **GetNext**.

> [!NOTE]
>
> - `pollingRate` can only slow down polling. If set lower than or equal to the protocol timer interval, it has no effect; the column will be polled at the timer interval.
> - The column is skipped until its `pollingRate` interval has elapsed, ensuring that it is not polled more frequently than specified.
> - When new rows are discovered during polling, all columns for that row are polled immediately, regardless of their `pollingRate`.

## Examples

Suppose the polling timer is set to 10 seconds. Columns without a `pollingRate` are polled every 10 seconds. Columns with a `pollingRate` greater than the timer are polled at the next matching interval.

- Columns 5–8: Default polling (every 10 seconds)
- Column 1: `pollingRate` 11,000 ms (polled every 20 seconds)
- Column 2: `pollingRate` 20,000 ms (polled every 20 seconds)
- Column 3: `pollingRate` 21,000 ms (polled every 30 seconds)
- Column 4: `pollingRate` 30,000 ms (polled every 30 seconds)

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
