---
uid: GetTopologyFieldsForCPEChain
---

# GetTopologyFieldsForCPEChain

Use this method to retrieve the topology fields of a particular chain of a CPE element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |
| Chain      | String  | The name of the chain.                                                           |

## Output

| Item | Format | Description |
|--|--|--|
| GetTopologyFields­ForCPEChainResult | Array of DMATopologyChains­Field (see [DMATopologyChainsField](xref:DMATopologyChainsField)) | The topology fields and related information for the specified chain. |
