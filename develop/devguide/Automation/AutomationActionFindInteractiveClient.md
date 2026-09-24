---
metadata_version: 1
uid: AutomationActionFindInteractiveClient
description: "Configure the Find interactive client action to invite a user to attach to an automation script and set how long the script waits."
---

# Find interactive client

Asks an interactive user to attach to the script.

```xml
<Exe id="2" type="findinteractiveclient">
   <Timeout>90</Timeout>
   <Message>Message</Message>
</Exe>
```

- Timeout: The timeout in s. Specifies how long the script should wait for the user to react. When this timeout expires, the script will continue and the FindInteractiveClient method returns "False".
- Message: The message that will appear in the message box.
