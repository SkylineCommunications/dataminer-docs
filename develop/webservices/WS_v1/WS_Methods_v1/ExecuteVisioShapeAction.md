---
uid: ExecuteVisioShapeAction
---

# ExecuteVisioShapeAction

Use this method to execute an action on a Visio shape.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| objectType | String | The type of DataMiner object: view, service, element. |
| dmaID | Integer | The DataMiner Agent ID. |
| objectID | Integer | The ID of the view, service or element. |
| pageID | Integer | The ID of the Visio page. |
| shapeUniqueID | Integer | The ID of the Visio shape. |
| actionID | String | The ID of the region action to be executed (returned by a GetVisioFor... method). |
| extraData | String | The contents of the ExtraData field associated with the specified ActionID (returned by a GetVisioFor... method). |

## Output

None.
