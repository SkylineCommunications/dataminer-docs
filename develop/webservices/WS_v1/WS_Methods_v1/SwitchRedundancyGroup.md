---
uid: SwitchRedundancyGroup
---

# SwitchRedundancyGroup

Use this method to switch to another element within a redundancy group.

## Input

| Item                           | Format  | Description                                                                        |
|--------------------------------|---------|------------------------------------------------------------------------------------|
| connection                     | String  | The connection ID. See [ConnectApp](xref:ConnectApp).   |
| dmaID                          | Integer | The DataMiner Agent ID.                                                            |
| redundancyGroupID              | Integer | The redundancy group ID.                                                           |
| redundancyVirtualElementDmaID | Integer | The DMA ID of the virtual element to which the redundancy group has to switch.     |
| redundancyVirtualElementID    | Integer | The element ID of the virtual element to which the redundancy group has to switch. |

## Output

None.
