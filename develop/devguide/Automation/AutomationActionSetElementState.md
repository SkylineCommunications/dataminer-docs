---
metadata_version: 1
uid: AutomationActionSetElementState
description: "Configure the 'Set element state' action to start, stop, restart, pause, mask, or unmask the element assigned to an automation script dummy."
---

# Set element state

Sets the state of a dummy in an automation script.

```xml
<Exe id="2" type="changestate">
   <Protocol>1</Protocol>
  <Type>restart</Type>
</Exe>
```

Possible values for Type:

- start
- stop
- restart
- pause
- mask
- unmask
