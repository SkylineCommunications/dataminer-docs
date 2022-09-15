---
uid: GetDataMinerCustomerInfo
---

# GetDataMinerCustomerInfo

Use this method to retrieve the system info for DataMiner. This is the information that can be configured in DataMiner Cube via *System Center* > *Agents* > *System*.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetDataMinerCustomerInfoResult | Array of string | The name, logo, address, telephone number, fax number, email and website configured for the DataMiner System. |
