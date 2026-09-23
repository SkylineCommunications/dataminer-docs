---
metadata_version: 1
uid: AutomationActionLabel
description: "Configure the Label action to identify a statement in an automation script so a Go to action can transfer execution directly to it."
---

# Label

Provides a label to enable transferring program control directly to the specified statement using a goto statement.

```xml
<Exe id="2" type="label">
   <Value>myLabel</Value>
</Exe>
```

- Value: The label.
