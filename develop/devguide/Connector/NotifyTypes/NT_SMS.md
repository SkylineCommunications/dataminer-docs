---
uid: NT_SMS
---

# NT_SMS (1)

Sends an SMS.

```csharp
string phoneNumber = "+3251313569";
string message = "Message";

string[] sms = { phoneNumber, message };

protocol.NotifyDataMiner(1, sms, null);
```

## Parameters

- sms (string[]):
  - sms[]: Phone number
  - sms[]: Message

## Return Value

- TBD
