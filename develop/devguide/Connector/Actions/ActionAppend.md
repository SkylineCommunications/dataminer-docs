---
uid: LogicActionAppend
---

# append

This action can be executed on parameters only.

Contrary to an action of type "copy", which causes the existing value of the parameter to be overwritten, an action of type "append" adds a value of another parameter or a fixed value to an existing parameter value.

## Attributes

### On@id

Specifies the ID(s) of the destination parameter(s).

### Type@id

Specifies the ID of the source parameter.

### Type@options

(optional): Specifies append options. The appended data is the "displayed" data of the parameter (not the raw data). To append a hexadecimal value, set the options attribute to "hex". You can also use options="hex-8" to group per 8 bytes or options="hex-36" to group per 36 bytes.

## Examples

```xml
<Action id="1">
   <On id="1">parameter</On>
   <Type id="2">append</Type>
</Action>
```

Example using options attribute:

```xml
<Action id="407">
   <On id="728">parameter</On>
   <Type id="721" options="hex-4">append</Type>
</Action>
```
