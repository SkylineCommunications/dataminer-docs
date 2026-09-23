---
metadata_version: 1
uid: AutomationActionGoTo
description: "Describe the DataMiner Automation development topic Go to, including its purpose, behavior, implementation guidance, and relevant constraints."
content_type: conceptual
applies_to:
  - DataMiner
---

# Go to

Unconditionally transfers control to the statement labeled by the specified identifier.

```xml
<Exe id="2" type="goto">
  <Value>label</Value>
</Exe>
```

- Value: The label.
