---
uid: SetRedundancyGroupMaintenance
---

# SetRedundancyGroupMaintenance

Use this method to set a redundancy group element either in maintenance or out of maintenance.

## Input

| Item              | Format  | Description                                                                            |
|-------------------|---------|----------------------------------------------------------------------------------------|
| Connection        | String  | The connection ID. See [ConnectApp](xref:ConnectApp).       |
| DmaID             | Integer | The DataMiner Agent ID.                                                                |
| RedundancyGroupID | Integer | The redundancy group ID.                                                               |
| ElementDmaID      | Integer | The DataMiner Agent ID that is linked to the element.                                  |
| ElementID         | Integer | The element ID.                                                                        |
| SetInMaintenance  | Boolean | Whether the element has to be set in maintenance (TRUE) or out of maintenance (FALSE). |

## Output

None.
