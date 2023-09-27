---
uid: GetTopologyChainsForCPE
---

# GetTopologyChainsForCPE

Use this method to retrieve the topology chains for a particular CPE element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |

## Output

| Item                           | Format                    | Description                                                  |
|--------------------------------|---------------------------|--------------------------------------------------------------|
| GetTopologyChainsForCPEResult | Array of DMATopologyChain | The names of the topology chains for the specified element. |
