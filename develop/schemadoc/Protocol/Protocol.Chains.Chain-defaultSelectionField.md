---
uid: Protocol.Chains.Chain-defaultSelectionField
---

# defaultSelectionField attribute

<!-- RN 28751, RN 28846 -->

Specifies the name of the field for which default selection should be applied.

## Content Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Chain](xref:Protocol.Chains.Chain)

## Remarks

If the specified selection filter only has one item, then it will automatically be selected.

The selection is done automatically when the chain tab is opened in the EPM element, and after all filters are cleared.

> [!NOTE]
> This option should only be set on filters where the number of results is always very limited.

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
