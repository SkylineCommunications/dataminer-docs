---
uid: AutomationActionUi
description: "Use the UI action to present a response dialog from an automation script and distinguish dialog input from script control flow."
---

# UI

Displays a dialog to collect input from an interactive user. The `Value` element contains the dialog definition. To branch based on a condition instead, use the [If action](xref:AutomationActionIf).

```xml
<Exe id="2" type="ui">
   <Value><![CDATA[...]]></Value>
</Exe>
```

> [!NOTE]
> The `...` in the example is a placeholder. Replace it with the dialog definition your script needs; an incomplete definition can prevent the expected controls or response from being available.
