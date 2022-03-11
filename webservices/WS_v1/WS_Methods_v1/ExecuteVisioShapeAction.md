---
uid: ExecuteVisioShapeAction
---

# ExecuteVisioShapeAction

Use this method to execute an action on a Visio shape.

## Input

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| ObjectType | String | The type of DataMiner object: view, service, element. |
| DmaID | Integer | The DataMiner Agent ID. |
| ObjectID | Integer | The ID of the view, service or element. |
| PageID | Integer | The ID of the Visio page. |
| ShapeUniqueID | Integer | The ID of the Visio shape. |
| ActionID | String | The ID of the region action to be executed (returned by a GetVisioFor... method). |
| ExtraData | String | The contents of the ExtraData field associated with the specified ActionID (returned by a GetVisioFor... method). |

## Output

None.
