---
uid: Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Validation
---

# Validation element

Defines field validation.

## Parent

[Field](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[ErrorMessage](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Validation.ErrorMessage)|[0, 1]|Defines the error message to be displayed in case the input is invalid.|
|&nbsp;&nbsp;[Regex](xref:Protocol.Chains.SearchChain.Tabs.Tab.Fields.Field.Validation.Regex)|[0, 1]|Defines the regular expression defining the pattern of allowed field content.|

## Remarks

Use Validation tags if you want to check whether the user input matches some predefined format. You can also specify the error message that has to be displayed when the check returns false.

Note that users will always be able to search for a particular string, even if the validation of that string returns false.

## Examples

```xml
<Validation>
   <ErrorMessage>Not a valid MAC address</ErrorMessage>
   <Regex>([A-Fa-f0-9]{2}[:-]?){5}[A-Fa-f0-9]{2}</Regex>
</Validation>
```
