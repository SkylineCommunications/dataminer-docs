---
uid: Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Substitutions
---

# Substitutions element

Defines possible substitutions to be applied to the field content.

## Parent

[Field](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Substitution](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Substitutions.Substitution)|[1, *]|Defines a substitution to be applied on the field content.|

## Remarks

Use Substitution tags if you want to alter the user input using a regular expression before sending it to the DataMiner Agent.

## Examples

In the following example, a Substitution tag is used to convert MAC addresses to the correct format before sending it to the DataMiner Agent.

```xml
<Substitutions>
    <Substitution>
        <Regex>
            <Input>[A-Fa-f0-9]{2})([:-]?)(?=[A-Fa-f0-9])</Input>
            <Output>$1:</Output>
        </Regex>    
    </Substitution>
</Substitutions>
```
