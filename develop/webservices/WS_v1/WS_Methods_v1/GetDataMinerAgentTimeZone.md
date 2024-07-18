---
uid: GetDataMinerAgentTimeZone
---

# GetDataMinerAgentTimeZone

Use this method to retrieve the current time zone of the DataMiner Agent.

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|------|--------|-------------|
| GetDataMinerAgentTimeZoneResult | [DMATimeZoneInfo](xref:DMATimeZoneInfo) | The current time zone of the DataMiner Agent. |
