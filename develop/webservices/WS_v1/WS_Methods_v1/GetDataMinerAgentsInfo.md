---
uid: GetDataMinerAgentsInfo
---

# GetDataMinerAgentsInfo

Use this method to retrieve the list of DataMiner Agents in the DataMiner System.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetDataMinerAgentsInfoResult | Array of [DMAInfo](xref:DMAInfo) | The list of all the DMAs in the DMS. |
