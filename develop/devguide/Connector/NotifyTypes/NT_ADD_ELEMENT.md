---
uid: NT_ADD_ELEMENT
---

# NT_ADD_ELEMENT (3)

Adds an element to a view.

```csharp
uint[] viewIDs = new uint[] { 10050, 10060 };

string[] elementIDs = new string[]{"346/3", "346/601"};

int result = (int) protocol.NotifyDataMinerQueued(3/*NT_ADD_ELEMENT*/ , viewIDs, elementIDs);
```

## Parameters

- viewIDs (uint[]): IDs of the view(s) to which the element needs to be added. If no view IDs are specified, the element is placed in the view of the element creating the element.
- elementIDs (string[]): Global element IDs of the elements that need to be added to the view(s).

## Return Value

- (int): Result value. 0 indicates the method call succeeded.
