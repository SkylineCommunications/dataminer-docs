---
uid: SetRedundancyGroupMaintenance
---

# SetRedundancyGroupMaintenance

Use this method to set a redundancy group element either in maintenance or out of maintenance.

## Input

| Item              | Format  | Description                                                                            |
|-------------------|---------|----------------------------------------------------------------------------------------|
| connection        | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                                  |
| dmaID             | Integer | The DataMiner Agent ID.                                                                |
| redundancyGroupID | Integer | The redundancy group ID.                                                               |
| elementDmaID      | Integer | The DataMiner Agent ID that is linked to the element.                                  |
| elementID         | Integer | The element ID.                                                                        |
| setInMaintenance  | Boolean | Whether the element has to be set in maintenance (TRUE) or out of maintenance (FALSE). |

## Output

None.
