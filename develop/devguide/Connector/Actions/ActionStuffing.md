---
uid: LogicActionStuffing
---

# stuffing

This action can be executed on commands and responses.

Sometimes, in the data block of a command/response, it is not allowed to use certain symbols because they are being used as control bytes in that same command/response. In that case, if you do want to use one of those symbols, it must be preceded by a redundant character to indicate that it should not be processed as a control byte but as data. This adding of redundant characters is also known as stuffing.

## On command

This action performs stuffing on the specified command(s).

### Attributes

#### On@id

The ID(s) of the commands on which to perform stuffing.

#### Type@allowed

(optional): If the byte(s) specified in the value attribute is followed by one of the characters specified in the allowed attribute, then it will not be repeated. The value can also be a hex string).

#### Type@startoffset

(optional): The start position that delimit the part of the data block inside which stuffing is performed. Default: 0.

#### Type@endoffset

(optional): The end position that delimit the part of the data block inside which stuffing is performed. Default: 0.

#### Type@value

The stuffing byte sequence. This can also be a hex string (e.g. 0xFF).

## On response

This action adds stuffing bytes on the incoming data of the specified response(s).

### Attributes

#### On@id

The ID(s) of the response(s) on which to perform stuffing.

#### Type@allowed

(optional): If the byte(s) specified in the value attribute is followed by one of the characters specified in the allowed attribute, then it will not be repeated. The value can also be a hex string).

#### Type@startoffset

(optional): The start position that delimit the part of the data block inside which stuffing is performed. Default: 0.

#### Type@endoffset

(optional): The end position that delimit the part of the data block inside which stuffing is performed. Default: 0.

#### Type@value

The stuffing byte sequence. This can also be a hex string (e.g. 0xFF).

## Examples

On command example

In the following example, an extra 0x10 character will be added in front of every 0x10 character, unless that 0x10 character is followed by 0x03 or 0x02. This means that, for example, 10023030301030301003 will become 1002303030101030301003:

```xml
<Action id="1">
   <On id="1">command</On>
   <Type value="0x10" allowed="0x030x02">stuffing</Type>
</Action>
```

On response example:

```xml
<Action id="5">
   <Name>Add Stuffing</Name>
   <On>response</On>
   <Type value="0x10" startoffset="2" endoffset="2">stuffing</Type>
</Action>
```
