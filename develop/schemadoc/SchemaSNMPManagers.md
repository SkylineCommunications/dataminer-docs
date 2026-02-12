---
uid: SchemaSNMPManagers
---

# SNMP Managers schema

SNMP Managers XML schema.

## Root element

[SNMP](xref:SNMP)

## Example

This is an example of a *SNMP Managers.xml* file:

```xml
<SNMP xmlns="http://www.skyline.be/config/snmpmanagers">
  <Configuration>
    <Agent id="232" type="Octets"value="3e:e4:7d:1b:16:30:41:f4:b0:aa:2a:13:30:85:b8:75">
      <AuthoritativeEngineID>80:00:22:6d:05:3e:e4:7d:1b:16:30:41:f4:b0:aa:2a:13:30:85:b8:75</AuthoritativeEngineID>
      <EngineBoots>5</EngineBoots>
    </Agent>
    <Agent id="237" type="Text" value="MyAgent">
      <AuthoritativeEngineID>80:00:22:6D:04:4D:79:41:67:65:6E:74</AuthoritativeEngineID>
      <EngineBoots>11</EngineBoots>
    </Agent>
  </Configuration>
  <SnmpManagers>
    ...
  </SnmpManagers>
</SNMP>

```

## Remarks

For more information, refer to [SNMP Managers XML](xref:SNMP_Managers_xml).
