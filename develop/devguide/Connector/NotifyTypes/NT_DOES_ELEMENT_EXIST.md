---
uid: NT_DOES_ELEMENT_EXIST
---

# NT_DOES_ELEMENT_EXIST (323)

Checks if an element, service or redundancy group exists in the cluster.

```csharp
string elementName = "Generic Trap Sender";
object result = protocol.NotifyDataMiner(323 /*NT_DOES_ELEMENT_EXIST*/ , elementName, null);

if (result != null)
{
    int[] elementDetails = (int[])result;
    int dmaID = elementDetails[0];
    int elementID = elementDetails[1];
}
```

## Parameters

- elementName (string): Name of the element. 

## Return Value

- elementDetails (int[]):
  - elementDetails[0]: DataMiner Agent ID
  - elementDetails[1]: Element ID
  - elementDetails[2]: DataMiner Agent ID

A null reference is returned in case there is no element with the given name.
