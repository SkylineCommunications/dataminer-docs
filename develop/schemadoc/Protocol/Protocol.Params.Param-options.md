---
uid: Protocol.Params.Param-options
---

# options attribute

Specifies the options applied to this parameter.

## Content Type

string

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Possible values:

|Value|Description|
|--- |--- |
|snmpSet|When the parameter value changes, an SNMP Set command is performed.|
|snmpSetAndGetWithWait|Set the OID and wait, then get the OID and wait (and be warned about runtime errors). See also: [snmpSetAndGet](xref:Protocol.Params.Param-snmpSetAndGet).|
|snmpSetWithWait|Set the OID and wait for a response (and be warned about runtime errors). See also: [snmpSetAndGet](xref:Protocol.Params.Param-snmpSetAndGet).|

> [!NOTE]
> Using snmpSetAndGetWithWait, you will not get the entire table. You will only get one instance of the table.

## Examples

Example of a column write parameter:

```xml
<Param id="20" options="snmpSetAndGetWithWait">
  <Name>IP Address</Name>
  <Description>IP Address</Description>
  <Type>write</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>string</Type>
  </Interprete>
  <SNMP>
     <Enabled>true</Enabled>
     <OID type="complete">1.3.6.1.4.1.8691.2.8.1.5.1.1.2.1.3.*</OID>
  </SNMP>
  ...
```

Example of a table parameter:

```xml
<Param id="15" trending="false">
  <Name>Accessible IP List</Name>
  <Type id="16;17;18;19">array</Type>
  <ArrayOptions index="0"/>
  <SNMP>
     <Enabled>true</Enabled>
     <OID type="complete" options="instance;multipleGetNext"></OID>
  </SNMP>
  ...
```
