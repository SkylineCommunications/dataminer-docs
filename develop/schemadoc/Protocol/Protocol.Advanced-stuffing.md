---
uid: Protocol.Advanced-stuffing
---

# stuffing attribute

This attribute can contain one or more of the following settings, separated by semicolons.

|Option|Description|
|--- |--- |
|allowed|Specifies the allowed sequence(s). When a command is sent, when a sequence corresponding with the sequence specified in the "stuffing" attribute is immediately followed by any sequence defined in the "allowed" attribute, no escape sequence will be inserted. To provide multiple allowed sequences, separate these by a comma.|
|on|Whether stuffing has to be performed on a command, a response, or both (separated by a comma).on=commandon=responseon=command,response|
|escape|The escape sequence (this can be more than one byte). Should be formatted in hexadecimal notation (e.g. escape=0x10).|
|stuffing|The stuffing sequence (this can be more than one byte). Should be formatted in hexadecimal notation (e.g. stuffing=0x10).|
|startoffset|This is an integer value specifying the start offset. This is the number of bytes, when starting to count from the start of the message, to ignore when performing stuffing. Default value: 0.|
|endoffset|This is an integer value specifying the end offset. This is the number of bytes, when starting to count from the end of the message, to ignore when performing stuffing. Default value: 0.|

## Content Type

string

## Parent

[Advanced](xref:Protocol.Advanced)

## Remarks

- **Stuffing behavior when sending commands**

    When stuffing is configured, before the command is sent out, the following is performed.

    First, the data of the message between the start and end offset is checked for any occurrences of the sequence provided in the "stuffing" attribute. If any occurrences are detected, then for each occurrence, it is verified whether the occurrence is immediately followed by one of the entries specified in the "allowed" attribute. If this is the case, the entry will not be escaped. If it is not the case, an escape sequence (specified in the "escape" attribute) will be included just before the occurrence of the stuffing sequence.

    ![Start and end offset](~/develop/schemadoc/Protocol/images/ProtocolAdvancedStuffing.svg)

    Examples

  - stuffing="on=command;escape=0x32;stuffing=0x32;allowed=0x380x39"
  - input "0x310x320x390x33", result after performing stuffing is "0x310x320x320x390x33": stuffing is performed (i.e. the escape sequence has been inserted) because allowed sequence "0x380x39" is not found after occurrence of stuffing byte ("0x32").
  - input "0x310x320x380x390x33", result after performing stuffing is "0x310x320x380x390x33": no stuffing is performed (i.e. no escape sequence has been inserted) because allowed sequence "0x380x39" was found right after stuffing sequence.

- **Stuffing behavior when processing responses**

    When stuffing is configured, when a response is received, the following is performed by SLPort related to stuffing before data is forwarded to SLProtocol.

    First, the data of the message between the start and end offset is checked for any occurrences of the sequence provided in the "escape" attribute. If any occurrences are detected, then for each occurrence, it is verified whether the occurrence is immediately followed by a sequence as specified by the "stuffing" attribute. If this is the case, the escape sequence will be removed. If it is not the case, the escape sequence will be left in place.

    When the trailer is found, data will be forwarded to SLProtocol.

## Examples

```xml
<Advanced stuffing="on=command,response;escape=0x10;stuffing=0x10;startoffset=2;endoffset=4"/>
```

> [!NOTE]
> Only applicable for connections of type "smart-serial" and "gpib".
>
> Always specify a trailer type parameter. Do NOT add the [headerTrailerLink](xref:Protocol.Params.Param.Type-options#headertrailerlink) option. When there is a header trailer link with advanced stuffing, SLPort will consider this as if no trailer were defined, and it will forward all received data to SLProtocol. This implies that if there were to be multiple responses inside the same data packet, SLProtocol would only process the first response found.
>
> As a trailer is specified without header trailer link, this implies that only one trailer can be defined in the connection, and all responses need to adhere to this structure. Data packets that do not contain a trailer will be dropped.
>
> When the value of the trailer can occur in the data of the response, the parameter right before the trailer parameter in the response needs to be a read type parameter with Interprete LengthType set to "last next param". Add a trigger that goes off before the response that executes a read response action.
>
> In case of a "serial" connection type, use a "read stuffing" [action](xref:LogicActionReadStuffing) executed by a trigger that goes off before the response.
