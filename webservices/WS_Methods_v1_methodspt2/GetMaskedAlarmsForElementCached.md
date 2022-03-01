---
uid: GetMaskedAlarmsForElementCached
---

# GetMaskedAlarmsForElementCached

Use this method to retrieve only masked element alarms added or changed since a particular point in time.

> [!NOTE]
> Using this method, you can e.g. request masked element alarms in batches in order to minimize loading time.

## Input

| Item         | Format       | Description                                                                                                                                                                                                                                                        |
|--------------|--------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                                                                                                                   |
| DmaID        | Integer      | The DMA ID.                                                                                                                                                                                                                                                        |
| ElementID    | Integer      | The element ID.                                                                                                                                                                                                                                                    |
| Index        | Integer      | The point from which to start returning alarms.                                                                                                                                                                                                                    |
| Count        | Integer      | The number of alarms to be returned.                                                                                                                                                                                                                               |
| OrderBy      | String       | The Alarm Console column(s) by which to order the alarms (separated by semicolons).                                                                                                                                                                                |
| CacheDateUTC | Long integer | If you enter a timestamp in UTC format (milliseconds since midnight January 1, 1970 GMT), then the method will return only masked element alarms that were added or changed since that particular point in time.<br> If you enter -1, there will be no date check. |

## Output

| Item                                   | Format                                           | Description                                                                   |
|----------------------------------------|--------------------------------------------------|-------------------------------------------------------------------------------|
| GetMaskedAlarmsFor­ElementCachedResult | [DMACache](xref:DMACache) | The masked element alarms added or changed since the specified point in time. |

> [!NOTE]
> In this case, the DMACache object (see [DMACache](xref:DMACache)) will contain an array of DMAAlarm objects (see [DMAAlarm](xref:DMAAlarm)).

