---
uid: Protocol.Params.Param.SNMP.OID-options
---

# options attribute

Specifies a number of options (separated by semicolons).

## Content Type

string

## Parent

[OID](xref:Protocol.Params.Param.SNMP.OID)

## Remarks

In the options attribute, you can specify the following options (separated by semicolons).

### bulk

In this option, you can specify the size of the different gets to be executed on the SNMP agent.

If, for example, you specify Bulk:20, then 20 cells will be retrieved at a time.

Use this option if the values to be retrieved are large strings that would cause the SNMP packet to become too large. If you do not specify this option, the default get bulk is 50 cells.

### column

This option is only required when you retrieve one column from an SNMP table using `options=instance` and `type=complete`.

If you do not specify this option, the first column (the instance) is not filled in, and the first row is missing. As this is a rather strange way to retrieve a table, it was decided to introduce a new attribute (column), so that the original way of retrieving tables could remain untouched.

### instance

Specify this option if you want to retrieve an extra column containing the instance. Refer to [Instance option](xref:ConnectionsSnmpRetrievingTables#instance-option) for more information about this table retrieval option.

### multipleGetNext

Specifies that the "multipleGetNext" table retrieval method should be used. Refer to [MultipleGetNext](xref:ConnectionsSnmpRetrievingTables#multiplegetnext) for more information about this table retrieval method.

### multipleGetBulk

Specifies that the "multipleGetBulk" table retrieval method should be used. Refer to [MultipleGetBulk](xref:ConnectionsSnmpRetrievingTables#multiplegetbulk) for more information about this table retrieval method.

### partialSNMP

When polling large SNMP tables, you can use the partialSNMP:x option to fetch only “x” rows at a time. This allows you to perform sets in-between and to prevent timeout errors.

The get method can be getNext + multipleGet (“bulk”), multipleGetNext or multipleGetBulk. If the protocol type is snmpV1 and you specified multipleGetBulk, then multipleGetNext will be used.

Example:

```xml
<OID type="complete" options="instance;partialSNMP:3">
```

> [!NOTE]
>
> - The partialSNMP:x option always has to be used together with the instance option.
> - The partialSNMP:x option cannot be used to fetch data from subtables or filtered rows.
> - The displayed table will be updated only when the entire table has been fetched.
> - When the multipleGetBulk retrieval method is used in combination with the partialSNMP option, the value for the partialSNMP option will take precedence over the value for the multipleGetBulk option. For example, the configuration `<OID type="complete" options="instance;partialSNMP:12;multipleGetBulk:24">` will result in the value 12 being used by DataMiner.

*Feature introduced in DataMiner 8.5.1 (RN 8162).*

### subtable

To avoid excessive gets for large SNMP tables, subtables can be used.

A subtable is a reduced SNMP table, based on an instance filter (defined in the parameter of which the ID is specified in the id attribute).

To use this option with a set of instances, please follow the steps described in [how to implement the subtable feature](xref:How_to_implement_the_subtable_feature).

The instance filter has two operating modes.

- An instance filter with a single value will act as a wildcard that accepts any row where the instance starts with the filter value. Using the instance option in this case also does not add an additional column to the result.

  As of DataMiner version 10.3.7, 10.3.0 [CU5] and 10.2.0 [CU16], it is also possible to use a "\*" wildcard. For example:

  - "1.2" will accept values like "1.2.1" and "1.2.2", but will reject "1.3.1" and "2.2".
  - "1.*" will accept values like "1.1" and "1.2.3", but will reject "1" and "2.1.2".
  - "*.1" will accept values like "2.1" and "2.1.2", but will reject "1.1" and "1.2.1".

- An instance filter with multiple values separated by commas will poll those specific instances, and expects all the instances to be complete and valid. In this case, the instance option does add an additional column to the result.
