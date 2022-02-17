---
uid: LogicActionReadStuffing
---

# read stuffing

This action can be executed on responses only.

Sometimes, in the data block of a command, it is not allowed to use certain symbols because they are being used as control bytes in that same command.

In that case, if you do want to use one of those symbols, it has to be preceded by a redundant character to indicate that it should not be processed as a control byte but as data. This adding of redundant characters is also known as stuffing.

The “read stuffing” action allows you to remove those redundant characters when a response is received.

## Attributes

### On@id

Specifies the ID(s) of the response(s) on which the action needs to be performed.

### Type@allowed

If the byte specified in the value attribute is followed by one of the characters specified in the allowed attribute, then it will not be repeated.

### Type@startoffset

(optional): The start position that delimits the part of the data block inside which stuffing is performed. Default: 0.

### Type@endoffset

(optional): The end position that delimits the part of the data block inside which stuffing is performed. Default: 0.

### Type@value

The stuffing character.

## Examples

```xml
<Action id="5">
  <Name>Remove Stuffing</Name>
  <On>response</On>
  <Type value="0x10" startoffset="2" endoffset="2">read stuffing</Type>
</Action>
```
