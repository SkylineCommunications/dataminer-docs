---
uid: NT_GET_ALARM_INFO
---

# NT_GET_ALARM_INFO (48)

Gets the alarm info of the specified standalone parameter(s).

```csharp
uint dmaId = 346;
uint elementId = 527643;
uint[] elementInfo = new uint[] { dmaId, elementId };
uint[] parameterIds = new uint[] { 100, 300 };

object[] result = (object[]) protocol.NotifyDataMiner(48 /* NT_GET_ALARM_INFO */, elementInfo, parameterIds);
```

## Parameters

- elementInfo (uint[]): Specifies the element
  - elementInfo[0]: The DMA ID of the element.
  - elementInfo[1]: The element ID of the element.
- parameterIds (uint[]): The IDs of the standalone parameters for which the alarm info is to be retrieved.

## Return Value

- (object[]): Object array containing an uint[] array for each parameter.

```csharp
uint[] entry = (uint[]) result[i];
```

The structure of an entry in the result array is as follows:

- entry[0]: parameter ID.
- entry[1]: current alarm state.
- entry[0]: current alarm ID (optional).

## Remarks

- In case you want to retrieve the alarm info of a single standalone parameter, you can specify an int instead of an uint[] for the second parameter. For example:

  ```csharp
  int parameterId = 1000;

  object[] result = (object[]) protocol.NotifyDataMiner(48 /* NT_GET_ALARM_INFO */, elementInfo, parameterId);
  ```

- In case you want to retrieve the alarm info of all monitored standalone parameters, you can specify a null reference for the second argument. For example:

  ```csharp
  object[] result = (object[]) protocol.NotifyDataMiner(48 /* NT_GET_ALARM_INFO */, elementInfo, null);
  ```
