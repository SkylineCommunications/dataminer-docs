---
uid: Protocol.Chains.Chain-groupingName
---

# groupingName attribute

<!-- RN 28751, RN 28834 -->

In this attribute, you can specify the name of the group to which this chain belongs.

## Content Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Chain](xref:Protocol.Chains.Chain)

## Remarks

In DataMiner Cube, EPM chains with the same value specified in this attribute will be grouped under that value in the EPM element card (side panel and tabs) and in the chains selection box located in the topology sidebar.

> [!NOTE]
>
> - Each chain can only be part of a single chain group.
> - Chains that are not part of a group will be displayed as top-level tabs (on the same level as the group tabs).

## Examples

```xml
<Protocol xmlns="http://www.skyline.be/protocol">
  <Chains>
     <Chain name="MyChain" defaultSelectionField="MyField" groupingName="MyChainGroup">
        ...
     </Chain>
  </Chains>
  ...
</Protocol>
```
