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

- Applicable for connections of type "serial", "smart-serial" and "gpib".
- **Stuffing behavior when sending commands**

    When stuffing is configured, before the command is sent out, the following is performed.

    First, the data of the message between the start and end offset is checked for any occurrences of the sequence provided in the "stuffing" attribute. If any occurrences are detected, then for each occurrence, it is verified whether the occurrence is immediately followed by one of the entries specified in the "allowed" attribute. If this is the case, the entry will not be escaped. If it is not the case, an escape sequence (specified in the "escape" attribute) will be included just before the occurrence of the stuffing sequence.

    ![Start and end offset](~/develop/schemadoc/Protocol/images/ProtocolAdvancedStuffing.svg)

    Examples

  - stuffing="on=command;escape=0x32;stuffing=0x32;allowed=0x380x39"
  - input "0x310x320x390x33", result after performing stuffing is "0x310x320x320x390x33": stuffing is performed (i.e. the escape sequence has been inserted) because allowed sequence "0x380x39" is not found after occurrence of stuffing byte ("0x32").
  - input "0x310x320x380x390x33", result after performing stuffing is "0x310x320x380x390x33": no stuffing is performed (i.e. no escape sequence has been inserted) because allowed sequence "0x380x39" was found right after stuffing sequence.

- **Stuffing behavior when processing responses**

    When stuffing is configured, when a response is received, the following is performed related to stuffing.

    First, the data of the message between the start and end offset is checked for any occurrences of the sequence provided in the "escape" attribute. If any occurrences are detected, then for each occurrence, it is verified whether the occurrence is immediately followed by a sequence as specified by the "stuffing" attribute. If this is the case, the escape sequence will be removed. If it is not the case, the escape sequence will be left in place.

## Examples

```xml
<Advanced stuffing="on=command,response;escape=0x10;stuffing=0x10;startoffset=2;endoffset=4"/>
```
