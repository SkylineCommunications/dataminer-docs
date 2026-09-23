---
metadata_version: 1
uid: AutomationActionSms
description: "Configure the SMS action to send a Short Message Service notification from an automation script to a specified destination."
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
