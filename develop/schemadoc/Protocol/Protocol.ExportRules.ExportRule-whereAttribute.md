---
uid: Protocol.ExportRules.ExportRule-whereAttribute
---

# whereAttribute attribute

Allows the validation of the value of an attribute when an export rule is applied. Available from DataMiner 10.3.8/10.4.0 onwards.<!-- RN 36622 -->

For example, this can be configured as follows:

```xml
<ExportRule table="*" tag="Protocol/SNMP" attribute="includepages" value="false" whereTag="Protocol/SNMP" whereAttribute="includepages" whereValue="true"/>
```

In the example above, if the [includepages](xref:Protocol.SNMP-includepages) attribute of the [Protocol.SNMP](xref:Protocol.SNMP) element is true, the export rule will change that value to false in the exported protocol. Without the `whereAttribute`, the `whereValue` check would be performed on the value of the *Protocol.SNMP* element itself (which is usually set to "auto") instead of the value of the `includepages` attribute.

Here is another example:

```xml
<ExportRule table="*" tag="Protocol/Params/Param/Display/Positions/Position/Column" value="2" whereTag="Protocol/Params/Param" whereAttribute="level" whereValue="5"/>
```

In the example above, all *Column* elements of parameters that have a `level` attribute that is set to 5 will have this value set to 2 in the exported protocol.

## Content Type

string

## Parent

[ExportRule](xref:Protocol.ExportRules.ExportRule)
