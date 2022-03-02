---
uid: GetDataMinerAgentsLicenseInfo
---

# GetDataMinerAgentsLicenseInfo

Use this method to retrieve license information for the different DataMiner Agents in the DMS.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetDataMinerAgents­LicenseInfoResult | Array of DMALicenseInfo (see [DMALicenseInfo](xref:DMALicenseInfo)) | The license information for each of the DMAs in the DMS. |
