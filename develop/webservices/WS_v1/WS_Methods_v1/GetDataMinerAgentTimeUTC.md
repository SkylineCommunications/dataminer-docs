---
uid: GetDataMinerAgentTimeUTC
---

# GetDataMinerAgentTimeUTC

Use this method to retrieve the current time of the DataMiner Agent in UTC format (milliseconds since midnight January 1, 1970 GMT).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetDataMinerAgentTimeUTCResult | Long integer | The current time of the DMA in UTC format (milliseconds since midnight January 1, 1970 GMT). |
