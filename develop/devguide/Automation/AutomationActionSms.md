---
metadata_version: 1
uid: AutomationActionSms
description: "Describe the DataMiner Automation development topic SMS, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# SMS

Sends a Short Message Service (SMS) message to the specified destination.

```xml
<Exe id="9" type="notification">
   <Message>MyMessage</Message>
   <Destination type="sms">MyDestination;</Destination>
</Exe>
```

Required items:

- Message
- Destination
- Destination@type="sms"
