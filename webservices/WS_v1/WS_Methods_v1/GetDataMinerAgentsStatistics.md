---
uid: GetDataMinerAgentsStatistics
---

# GetDataMinerAgentsStatistics

Use this method to retrieve statistics for every DMA in the DMS. These statistics include the number of elements, active elements and services per DMA.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetDataMinerAgents­StatisticsResult | Array of DMAStatistics (see [DMAStatistics](xref:DMAStatistics)) | The statistics for each of the DMAs in the DMS. |
