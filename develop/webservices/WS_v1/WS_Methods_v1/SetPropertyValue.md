---
uid: SetPropertyValue
---

# SetPropertyValue

Use this method to change the value of a property of a specified object, which can be a view, a service or an element.

## Input

| Item          | Format  | Description                                           |
|---------------|---------|-------------------------------------------------------|
| connection    | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| objectType    | String  | The type of DataMiner object: view, service, element. |
| dmaID         | Integer | The DataMiner Agent ID.                               |
| objectID      | Integer | The ID of the view, service or element.               |
| propertyName  | String  | The name of the property.                             |
| propertyValue | String  | The new value of the property.                        |

## Output

None.
