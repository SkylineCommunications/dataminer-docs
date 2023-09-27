---
uid: GetTopologyFieldsForCPEChain
---

# GetTopologyFieldsForCPEChain

Use this method to retrieve the topology fields of a particular chain of a CPE element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DataMiner Agent ID.                                                          |
| elementID  | Integer | The element ID.                                                                  |
| chain      | String  | The name of the chain.                                                           |

## Output

| Item | Format | Description |
|--|--|--|
| GetTopologyFieldsForCPEChainResult | Array of [DMATopologyChainsField](xref:DMATopologyChainsField) | The topology fields and related information for the specified chain. |
