---
metadata_version: 1
uid: AutomationActionInformation
description: "Use the Information action to create a clear information event from an automation script and distinguish it from diagnostic logging."
---

# Information

Creates an information event with the text in the `Message` element.

```xml
<Exe id="2" type="information">
   <Message>This is a test</Message>
</Exe>
```

> [!TIP]
> Keep operator-facing messages concise. For diagnostic details, use the [Log action](xref:AutomationActionLog).
