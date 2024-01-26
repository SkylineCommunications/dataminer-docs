---
uid: DMS_ELEMENT_ALARM_STATE
---

# DMS_ELEMENT_ALARM_STATE (83)

> [!WARNING]
>
> - The use of DMS Notify types is deprecated. Use types from [Class library](xref:ClassLibraryIntroduction) instead.

Gets the alarm state of an element.

```csharp
uint dmaID = 346;
uint elementID = 601;

int type = 83;
int subType = 0;

uint[] ids = new uint[] { dmaID, elementID };
object result = new object();

DMS dms = new DMS();
dms.Notify(type/*DMS_ELEMENT_ALARM_STATE*/ , subType, ids, null, out result);

int alarmState = (int) result;
```
## Parameters:

- type (int): Specifies the notify type. To perform a DMS_ELEMENT_ALARM_STATE call, set this to 83.
-subType (int): Specifies the sub type. Not applicable for DMS_ELEMENT_ALARM_STATE calls. Set this to 0.
  - ids (uint[]):
    - ids[0]: DataMiner Agent ID
    - ids[1]: Element ID
  - result (object): Element alarm state as integer. Possible values:
    - 0: No alarm
    - 1: Normal
    - 2: Warning
    - 3: Minor
    - 4: Major
    - 5: Critical
    - 6: Error
    - 7: Timeout