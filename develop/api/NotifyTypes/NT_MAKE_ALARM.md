---
uid: NT_MAKE_ALARM
---

# NT_MAKE_ALARM (106)

Creates an alarm.

```csharp
int elementID = 801;
int parameterID = 10;
string information = "Invalid value";

Alarm alarm = new Alarm();

string[] alarmDetails = alarm.NewAlarm(elementID, parameterID, information, AlarmSeverity.WARNING.ToString());

int alarmID = (int) protocol.NotifyDataMiner(106 /*NT_MAKE_ALARM*/, 0, alarmDetails);
```

## Parameters

- alarmDetails (string[]): Create an instance of the Alarm class and call the AddAlarm or NewAlarm method.

## Return Value

- (int): The alarmID (e.g., 365182). Note: this does not include "element ID/".

## Remarks

- The Alarm (Skyline.DataMiner.ProtocolScripts) class is defined in the SLProtocolScripts.dll assembly. Alternatively, the [Skyline.DataMiner.Utils.Alarms.Protocol](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Alarms.Protocol) NuGet can be used. It acts as a replacement for the SLProtocolScripts DLL, and you can use it without having a local DMA installed.

  ```csharp
  enum AlarmSeverity { Informational = -1, Normal, Warning, Minor, Major, Critical };
  ```
