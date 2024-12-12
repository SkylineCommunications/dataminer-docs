---
uid: NT_GET_ACTIVATED_LICENSE_COUNTERS
---

# NT_GET_ACTIVATED_LICENSE_COUNTERS (353)

Retrieves the number of activated elements, spectrum elements, protocol names and the number of elements using the protocol.<!-- RN 5492 -->

```csharp
string[] result = (string[])protocol.NotifyDataMiner(353 /*NT_GET_ACTIVATED_LICENSE_COUNTERS*/, null, null);
```

## Parameters

- This method call does not need any additional parameters.

## Return Value

- result (string[]): The result array contains strings in one of the following formats:
  - ELEMENTS|x (with x being the number of activated elements)
  - SPECTRUMELEMENTS|x (with x being the number of activate spectrum elements)
  - PROTOCOL|y|x (y = name of the protocol, x = number of elements using this protocol)
