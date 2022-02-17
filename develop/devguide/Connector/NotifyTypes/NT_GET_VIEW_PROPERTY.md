---
uid: NT_GET_VIEW_PROPERTY
---

# NT_GET_VIEW_PROPERTY (350)

Retrieves the value of the specified view property.

```csharp
int viewId = 10046;

string propertyName = "myViewPropertyName";

string result = (string) protocol.NotifyDataMiner(350 /* NT_GET_VIEW_PROPERTY */, viewId,  propertyName);
```

## Parameters

- viewId (int): The view ID.
- propertyName (string): The name of the property.

## Return Value

- (string) The property value. In case the property was not found, an empty string is returned.
