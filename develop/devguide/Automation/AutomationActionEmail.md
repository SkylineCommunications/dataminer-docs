---
metadata_version: 1
uid: AutomationActionEmail
description: "Describe the DataMiner Automation development topic Email, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Email

Sends an email to the specified destination.

```xml
<Exe id="12" type="notification">
   <Message>#message</Message>
   <Destination type="email" title="subject" cc="cc@cc.com;" bcc="bcc@bcc.com;">to@to.com;
</Destination>
</Exe>
```

- Message: The content of the email
- Destination: The recipients.
- Destination@type: Indicates this action is a notification by email.
- Destination@title: The subject of the email.
- Destination@cc: The carbon copy recipients.
- Destination@bcc: The blind carbon copy recipients.

Required items:

- Destination
- Destination@title
- Destination@type="email"

## Remarks

> [!NOTE]
> To indicate plain text, prepend the message with the # character.
