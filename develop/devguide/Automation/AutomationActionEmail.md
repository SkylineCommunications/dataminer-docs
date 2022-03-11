---
uid: AutomationActionEmail
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
