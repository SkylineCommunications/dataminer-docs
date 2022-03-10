---
uid: Protocol.Chains.SearchChain.Display
---

# Display element

Configures search chain display settings.

## Parent

[SearchChain](xref:Protocol.Chains.SearchChain)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Visibility](xref:Protocol.Chains.SearchChain.Display.Visibility)|||

## Remarks

Feature introduced in DataMiner 10.1.6 (RN 29640, RN 29656).

## Examples

```xml
<Chain>
   <Display>
      <Visibility default="false">
         <Standalone pid="8">
            <Value>1</Value>
            <Value>2</Value>
         </Standalone>
      </Visibility>
   </Display>
</Chain>
```
