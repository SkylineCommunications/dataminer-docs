---
uid: AutomationActionAssignTemplate
---

# Assign template

Assigns an alarm or trend template to a dummy.

```xml
<Exe id="2" type="settemplate">
   <Protocol>1</Protocol>
   <Type>alarm</Type>
   <Value>Template1</Value>
</Exe>
<Exe id="2" type="settemplate">
   <Protocol>1</Protocol>
   <Type>alarm</Type>
   <Value ref="param1"></Value>
</Exe>
```

Required items:

- Protocol
- Type "alarm" for alarm template, "trending" for trend template
- Value for pre-determined template or Value@ref when determined by script parameter.
