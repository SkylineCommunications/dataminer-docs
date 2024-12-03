---
uid: NT_GET_VIEW_PROPERTIES
---

# NT_GET_VIEW_PROPERTIES (316)

Gets the properties of a view.

```csharp
int viewID = 2;

object[] viewProperties = (object[])protocol.NotifyDataMiner(316 /*NT_GET_VIEW_PROPERTIES*/, viewID, 0);

foreach (string[] viewProperty in viewProperties)
{
    string propertyKey = viewProperty[0];
    // The value of viewProperty[1] always equals 46, indicating this is a view property.
    string propertyValue = viewProperty[2];
    string accesType = viewProperty[3];
    string owningViewID = viewProperty[4];
}
```

## Parameters

- viewID (int): ID of the view for which the properties need to be obtained.

## Return Value

- viewProperties (object[]): Object array containing string arrays for each view property.

  string[] viewProperty = viewProperties[i];
  
  - viewProperty[0]: Key of the property.
  - viewProperty[1]: 46 (indicates this is a view property).
  - viewProperty[2]: Value of the property.
  - viewProperty[3]: Access type.
  - viewProperty[4]: Owning view ID.
