---
uid: Protocol.Chains.SearchChain.Tabs.Tab.Display
---

# Display element

<!-- RN 29640, RN 29656 -->

Configures chain tab display settings.

## Parent

[Tab](xref:Protocol.Chains.SearchChain.Tabs.Tab)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Visibility](xref:Protocol.Chains.SearchChain.Tabs.Tab.Display.Visibility)||Configures chain tab visibility settings.|

## Example

```xml
<Chains>
   <SearchChain name="Search">
      <Tabs>
         <Tab tablePid="11100" name="Customer">
            <Display>
               <Visibility default="false">
                  <Standalone pid="10">
                     <Value>1</Value>
                     <Value>2</Value>
                  </Standalone>
               </Visibility>
            </Display>
         </Tab>
      </Tabs>
   </SearchChain>
</Chains>
```
