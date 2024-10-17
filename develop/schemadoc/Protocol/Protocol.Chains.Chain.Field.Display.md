---
uid: Protocol.Chains.Chain.Field.Display
---

# Display element

<!-- RN 29640, RN 29656 -->

Configures chain field display settings.

## Parent

[Field](xref:Protocol.Chains.Chain.Field)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Selection](xref:Protocol.Chains.Chain.Field.Display.Selection)|[0, 1]||

## Example

```xml
<Chain>
   <Field name="CDN" pid="15602">
      <Display>
         <Selection>
            <Visibility default="false">
               <Standalone pid="18">
                  <Value>1</Value>
                  <Value>2</Value>
               </Standalone>
            </Visibility>
         </Selection>
      </Display>
   </Field>
</Chain>
```
