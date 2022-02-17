---
uid: NT_SET_ALARM_STATE
---

# NT_SET_ALARM_STATE (116)

Masks or unmasks an element and allows you to provide a comment to an alarm.

## Parameters

To **mask** an element:

```csharp
uint dmaID = 346;
uint elementID = 801;
uint state = 10;
string maskType = "20";
string comment = "Comment";

object elementDetails = new uint[] {elementID, state, dmaID};

object maskDetails = new string[] {maskType, comment};

protocol.NotifyDataMiner(116 /* NT_SET_ALARM_STATE */, elementDetails, maskDetails);
```

- elementDetails (uint[]):
  - elementDetails[0]: Element ID
  - elementDetails[1]: Element state. Masked=10, unmasked=11.
  - elementDetails[2]: DMA ID
- maskDetails (string[]):
  - maskDetails[0]: mask type.
    - -2: Mask until unmasked.
    - -1: Mask until cleared.
    - x > 0: Mask x seconds.
  - maskDetails[1]: comment.

To **unmask** an element:

```csharp
state = 11;
elementDetails = new uint[] { elementID, 11, dmaID };

protocol.NotifyDataMiner(116 /* NT_SET_ALARM_STATE */, elementDetails, comment);
```

- elementDetails (uint[]):
  - elementDetails[0]: Element ID
  - elementDetails[1]: Element state. Masked=10, unmasked=11.
  - elementDetails[2]: DMA ID
- comment (string): Comment. 

To provide a comment to an alarm:

```csharp
uint alarmID = 365134;
uint status = 5;
string comment = "Comment";

object alarmDetails = new uint[] { alarmID, status };

object maskDetails = new string[] { "-1", comment };

protocol.NotifyDataMiner(116/*NT_SET_ALARM_STATE*/, alarmDetails, maskDetails);
```

- alarmDetails (uint[]):
  - alarmDetails[0]: Alarm ID.
  - alarmDetails[1]: Set to 5.
- maskDetails (string[]):
  - maskDetails[0]: Set to "-1".
  - maskDetails[1]: Comment.

## Return Value

- Does not return an object.
