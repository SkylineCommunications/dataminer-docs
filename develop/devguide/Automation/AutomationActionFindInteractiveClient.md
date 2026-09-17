---
metadata_version: 1
uid: AutomationActionFindInteractiveClient
description: "Describe the DataMiner Automation development topic Find interactive client, including its purpose, behavior, implementation guidance, and relevant constr."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
