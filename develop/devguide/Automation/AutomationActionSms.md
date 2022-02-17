---
uid: AutomationActionSms
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
