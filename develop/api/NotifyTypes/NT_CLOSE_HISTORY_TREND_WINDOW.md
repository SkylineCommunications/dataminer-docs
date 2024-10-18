---
uid: NT_CLOSE_HISTORY_TREND_WINDOW
---

# NT_CLOSE_HISTORY_TREND_WINDOW (374)

Closes all previous trend windows that are still open and have already passed since the specified time.

```csharp
string primaryKey = "Row 1";
int columnID = 1002;
DateTime now = DateTime.Now;

object[] settings = new object[] { columnID, primaryKey, now };

protocol.NotifyProtocol(374 /*NT_CLOSE_HISTORY_TREND_WINDOW*/, settings, null);
```

## Parameters

- settings (object[]):
  - settings[0] (int): Column parameter ID.
  - settings[1] (string): Parameter IDX.
  - settings[2] (DateTime): Date that you want to perform the "set". Note that all possible previous windows will be closed.

## Return Value

- Does not return an object.

## Remarks

- For history set parameters, average trending is generated based on the parameter sets that occur, so a history set window gets closed when another parameter set occurs. However, you can also use this call to close a history set window without a new parameter set.<!-- RN 7288 -->

- Regardless of which date and time you provide, it is not possible to close a window that has not completely passed yet. For example, if it is currently 02:04 PM, and you want to close the 02:00 PM to 02:05 PM average window, you need to wait until after 02:05 PM to send this request.

- For this call to work, the historySet attribute of the parameter needs to be set to true. If this is not the case, the following logging will be shown in the element log file when you try to execute this call:<!-- RN 9686 -->

  ```txt
  `SLElement.exe|10232|CElement::NotifyFunc|ERR|-1|Error closing trend windows with timestamp VT_DATE : [TIMESTAMP]
  Parameter [Parameter Name] is not marked for history sets.`
  ```
