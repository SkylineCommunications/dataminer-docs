---
uid: GetTopologyChainsForCPE
---

# GetTopologyChainsForCPE

Use this method to retrieve the topology chains for a particular CPE element.

## Input

| Item       | Format  | Description                                                                      |
|------------|---------|----------------------------------------------------------------------------------|
| Connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| DmaID      | Integer | The DataMiner Agent ID.                                                          |
| ElementID  | Integer | The element ID.                                                                  |

## Output

| Item                           | Format                    | Description                                                  |
|--------------------------------|---------------------------|--------------------------------------------------------------|
| GetTopologyChains­ForCPEResult | Array of DMATopologyChain | The names of the topology chains for the specfified element. |

