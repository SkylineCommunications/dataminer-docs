---
uid: SetPropertyValue
---

# SetPropertyValue

Use this method to change the value of a property of a specified object, which can be a view, a service or an element.

## Input

| Item          | Format  | Description                                                                      |
|---------------|---------|----------------------------------------------------------------------------------|
| Connection    | String  | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| ObjectType    | String  | The type of DataMiner object: view, service, element.                            |
| DmaID         | Integer | The DataMiner Agent ID.                                                          |
| ObjectID      | Integer | The ID of the view, service or element.                                          |
| PropertyName  | String  | The name of the property.                                                        |
| PropertyValue | String  | The new value of the property.                                                   |

## Output

None.

