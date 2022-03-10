---
uid: NT_GET_ELEMENT_NAME
---

# NT_GET_ELEMENT_NAME (144)

Gets the name of the specified element.

```csharp
uint agentId = 346;
uint elementId = 530210;
uint[] elementDetails = new uint[] { agentId, elementId };

string elementName = (string) protocol.NotifyDataMiner(144/*NT_GET_ELEMENT_NAME */, elementDetails, null);

if (elementName != null)
{
    // ...
}
```

## Parameters

- elementDetails (uint[]):
  - elementDetails[0]: The Agent ID of the element.
  - elementDetails[1]: The element ID.

## Return Value

- (string): The element name or null if no element with the specified name was found.
