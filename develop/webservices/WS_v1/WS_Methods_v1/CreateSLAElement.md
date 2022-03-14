---
uid: CreateSLAElement
---

# CreateSLAElement

Use this method to create a new SLA element.

Available from DataMiner 9.0.5 onwards.

## Input

| Item          | Format                      | Description                                                                               |
|---------------|-----------------------------|-------------------------------------------------------------------------------------------|
| Connection    | String                      | The connection string. See [ConnectApp](xref:ConnectApp).                                 |
| DmaID         | Integer                     | The DataMiner Agent ID.                                                                   |
| ViewIDs       | Array of Integer            | The IDs of the views in which the element should be created.                              |
| Configuration | DMASLAElementCon­figuration | See [DMASLAElementConfiguration](xref:DMASLAElementConfiguration). |

> [!NOTE]
> When you create an SLA element, the “State” property of the DMASLAElementConfiguration object should be *Active*, *Paused* or *Stopped*.

## Output

| Item                    | Format          | Description                                             |
|-------------------------|-----------------|---------------------------------------------------------|
| CreateSLAElement­Result | Array of string | The DataMiner ID and element ID of the new SLA element. |
