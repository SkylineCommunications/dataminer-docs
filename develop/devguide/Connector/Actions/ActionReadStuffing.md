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

> [!NOTE]
> Only to be used for a "serial" connection type.
>
> When the value of the trailer can occur in the data of the response, do NOT define a trailer type parameter because the response will be cut off as soon as the bytes of the trailer are found inside the response data. Specify the last parameter in the response as a fixed type parameter instead of a trailer. The parameter right before the last parameter in the response needs to be a read type parameter with Interprete LengthType set to "last next param". Add a trigger that goes off before the response which first executes the "read stuffing" action, followed by a "read" action on the response. As there is not a trailer present anymore, the downside is that the response will wait until timeout time before being processed.
>
> In case of a "smart-serial" connection type, use [Advanced Stuffing](xref:Protocol.Advanced-stuffing).
