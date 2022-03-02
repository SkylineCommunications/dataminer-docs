---
uid: CreateElement
---

# CreateElement

Use this method to create a new element on the specified DataMiner Agent.

## Input

| Item          | Format                   | Description                                                                         |
|---------------|--------------------------|-------------------------------------------------------------------------------------|
| Connection    | String                   | The connection string. See [ConnectApp](xref:ConnectApp) .                            |
| DmaID         | Integer                  | The DataMiner Agent ID.                                                             |
| ViewIDs       | Array of Integer         | The IDs of the views in which the element should be created.                        |
| Configuration | DMAElementConfigu­ration | See [DMAElementConfiguration](xref:DMAElementConfiguration). |

> [!NOTE]
> -  When you create an element, the “State” property of the DMAElementConfiguration object should be *Active*, *Paused* or *Stopped*.
> -  From DataMiner 9.5.5 onwards, it is possible to specify a different SNMP version than is configured in the protocol.

## Output

| Item                | Format          | Description                                         |
|---------------------|-----------------|-----------------------------------------------------|
| CreateElementResult | Array of string | The DataMiner ID and element ID of the new element. |

