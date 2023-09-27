---
uid: GetDataMinerAgentsStatistics
---

# GetDataMinerAgentsStatistics

Use this method to retrieve statistics for every DMA in the DMS. These statistics include the number of elements, active elements and services per DMA.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetDataMinerAgentsStatisticsResult | Array of [DMAStatistics](xref:DMAStatistics) | The statistics for each of the DMAs in the DMS. |
