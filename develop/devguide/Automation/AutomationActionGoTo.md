---
metadata_version: 1
uid: AutomationActionGoTo
description: "Configure the 'Go to' action to transfer automation script execution directly to the statement identified by a specified label."
---

# Go to

Unconditionally transfers control to the statement labeled by the specified identifier.

```xml
<Exe id="2" type="goto">
  <Value>label</Value>
</Exe>
```

- Value: The label.
