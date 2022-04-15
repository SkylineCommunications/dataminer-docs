---
uid: CreateSLAElement
---

# CreateSLAElement

Use this method to create a new SLA element.

Available from DataMiner 9.0.5 onwards.

## Input

| Item          | Format                      | Description                                                                               |
|---------------|-----------------------------|-------------------------------------------------------------------------------------------|
| connection    | String                      | The connection string. See [ConnectApp](xref:ConnectApp).                                 |
| dmaID         | Integer                     | The DataMiner Agent ID.                                                                   |
| viewIDs       | Array of Integer            | The IDs of the views in which the element should be created.                              |
| configuration | DMASLAElementCon­figuration | See [DMASLAElementConfiguration](xref:DMASLAElementConfiguration). |

> [!NOTE]
> When you create an SLA element, the “State” property of the DMASLAElementConfiguration object should be *Active*, *Paused* or *Stopped*.

## Output

| Item                    | Format          | Description                                             |
|-------------------------|-----------------|---------------------------------------------------------|
| CreateSLAElement­Result | Array of string | The DataMiner ID and element ID of the new SLA element. |
