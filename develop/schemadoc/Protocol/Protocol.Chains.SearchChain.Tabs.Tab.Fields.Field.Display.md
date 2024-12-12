---
uid: Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Display
---

# Display element

<!-- RN 29640, RN 29656 -->

Configures chain field display settings.

## Parent

[Field](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Visibility](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Display.Visibility)|||

## Example

```xml
<Chains>
   <SearchChain name="Search">
      <Tabs>
         <Tab tablePid="11100" name="Customer">
            <Fields>
               <Field columnPid="11102" name="Customer Name">
                  <Display>
                     <Visibility default="false">
                        <Standalone pid="10">
                           <Value>1</Value>
                           <Value>2</Value>
                        </Standalone>
                     </Visibility>
                  </Display>
               </Field>
            </Fields>
         </Tab>
      </Tabs>
   </SearchChain>
</Chains>
```
