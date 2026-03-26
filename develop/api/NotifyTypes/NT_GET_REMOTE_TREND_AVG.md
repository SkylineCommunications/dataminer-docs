---
uid: NT_GET_REMOTE_TREND_AVG
---

# NT_GET_REMOTE_TREND_AVG (260)

Gets the average trend data of a view table column.

```csharp
uint elementId = 1530;
uint columnId = 5002;
uint columnPos = UInt32.MaxValue; // Means not specified.
uint isDirectView; // 0=false, 1=true.
uint agentId = 400;

uint[] elementDetails = new uint[] { elementId, columnId, columnPos, isDirectView, agentId };

string primaryKey = "1";
string dateTime = "2017-01-20 00:00:00"; //YYYY-MM-DD HH:mm:SS);

string[] options = new string[] { primaryKey, dateTime };

object result = protocol.NotifyDataMiner(260 /* NT_GET_REMOTE_TREND_AVG */, elementDetails, options);
```

## Parameters

- elementDetails (uint[]):
  - elementDetails[0]: The element ID.
  - elementDetails[1]: The column ID.
  - elementDetails[2]: The column position. Only required when elementDetails[1] specifies the table ID. Otherwise set to UInt32.MaxValue.
  - elementDetails[3]: 0 in case it is not a direct view table, 1 in case it is a direct view table
  - elementDetails[4]: The Agent ID of the element.
- options (string[]):
  - options[0]: The primary key.
  - options[1]: The starting timestamp as of which the trend data should be returned. Format: YYYY-MM-DD HH.mm:SS. This is optional (i.e., when all trend data should be returned, provide a string array of size one holding just the primary key).

## Return Value

- object[] result:
  - result[0]: string array, denoting the meaning of the cells (e.g., `["dtFirst","chValueAvg","chValueMin","chValueMax","iStatus"]`).
  - result[1]: string array containing the trend data.

    string[] data = (string[]) result[1];

    where

    - data[i*5] = dtFirst value
    - data[i*5+1] = chValueAvg value
    - data[i*5+2] = chValueMin value
    - data[i*5+3] = chValueMax value
    - data[i*5+4] = iStatus value

## Remarks

- The use of this call is **deprecated**. Instead, the [GetTrendDataMessage](xref:Skyline.DataMiner.Net.Messages.GetTrendDataMessage) SLNet message should be used.
