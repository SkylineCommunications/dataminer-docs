---
uid: LogicActionReplaceData
---

# replace data

This action can be executed on parameters, commands and responses.

This action allows you to replace specific bytes by other bytes.

## On parameter

### Attributes

#### On@id

Specifies the ID(s) of the parameter(s) on which to perform this action.

#### Type@options

Specifies the replacement(s). This is formatted using a semicolon as follows:

*oldValue(s)*;*newValue(s)*

Optionally, a third item can be provided, "use_offset" ("*oldValue(s)*;*newValue(s)*;use_offset"), to indicate that the replacement should be performed on the first x bytes (as denoted in the startoffset attribute) and the last y bytes (as denoted in the endoffset attribute) (see example below).

It is also possible to specify multiple replacements. To specify multiple replacements, separate these by hyphens ("-").

*oldValue1*-*oldValue2*;*newValue1*-*newValue2*

The number of old values specified must match the number of new values specified.

> [!NOTE]
> In case the number of old values does not match the number of new values (or the incoming data is smaller than the sum of the specified start and end offset), the element log will contain the following log line (Debug logging, Level 5), followed by the incoming data:
>
> `CAction::ReplaceData|DBG|5|After replace`

The old and new value must be a hex string, optionally prefixed with "0x" or "0X" (e.g. 0x0F0E).

#### Type@startoffset

(optional): The first byte in the data string that can be replaced (0-based value, starting from the beginning of the data string). Default: 0.

#### Type@endoffset

(optional): The last byte in the data string that can be replaced (0-based value, starting from the end of the data string). Default: 0.

## On command

### Attributes

#### On@id

Specifies the ID(s) of the command(s) on which to perform this action.

#### Type@options

Specifies the replacement(s). This is formatted using a semicolon as follows:

*oldValue(s)*;*newValue(s)*

Optionally, a third item can be provided, "use_offset" ("*oldValue(s)*;*newValue(s)*;use_offset"), to indicate that the replacement should be performed on the first x bytes (as denoted in the startoffset attribute) and the last y bytes (as denoted in the endoffset attribute) (see example below).

It is also possible to specify multiple replacements. To specify multiple replacements, separate these by hyphens ("-").

*oldValue1*-*oldValue2*;*newValue1*-*newValue2*

The number of old values specified must match the number of new values specified.

> [!NOTE]
> In case the number of old values does not match the number of new values (or the incoming data is smaller than the sum of the specified start and end offset), the element log will contain the following log line (Debug logging, Level 5), followed by the incoming data:
>
> `CAction::ReplaceData|DBG|5|After replace`

The old and new value must be a hex string, optionally prefixed with "0x" or "0X" (e.g. 0x0F0E).

#### Type@startoffset

(optional): The first byte in the data string that can be replaced (0-based value, starting from the beginning of the data string). Default: 0.

#### Type@endoffset

(optional): The last byte in the data string that can be replaced (0-based value, starting from the end of the data string). Default: 0.

## On response

### Attributes

#### On@id

Specifies the ID(s) of the response(s) on which to perform this action.

#### Type@options

Specifies the replacement(s). This is formatted using a semicolon as follows:

*oldValue(s)*;*newValue(s)*

Optionally, a third item can be provided, "use_offset" ("*oldValue(s)*;*newValue(s)*;use_offset"), to indicate that the replacement should be performed on the first x bytes (as denoted in the startoffset attribute) and the last y bytes (as denoted in the endoffset attribute) (see example below).

It is also possible to specify multiple replacements. To specify multiple replacements, separate these by hyphens ("-").

*oldValue1*-*oldValue2*;*newValue1*-*newValue2*

The number of old values specified must match the number of new values specified.

> [!NOTE]
> In case the number of old values does not match the number of new values (or the incoming data is smaller than the sum of the specified start and end offset), the element log will contain the following log line (Debug logging, Level 5), followed by the incoming data:
>
> `CAction::ReplaceData|DBG|5|After replace`

The old and new value must be a hex string, optionally prefixed with "0x" or "0X" (e.g. 0x0F0E).

#### Type@startoffset

(optional): The first byte in the data string that can be replaced (0-based value, starting from the beginning of the data string). Default: 0.

#### Type@endoffset

(optional): The last byte in the data string that can be replaced (0-based value, starting from the end of the data string). Default: 0.

## Examples

Example on parameter:

```xml
<Action id="47">
  <On id="63">parameter</On>
  <Type options="0x090D0A;0x49" startoffset="10">replace data</Type>
</Action>
```

In the following example, the replace will be performed on the first 7 bytes and the last 2 bytes.

```xml
<Action id="128">
  <On id="130">parameter</On>
  <Type startoffset="7" endoffset="2" options="0x25;0x2525;use_offset">replace data</Type>
</Action>
```

Example on command:

```xml
<Action id="12">
  <On>command</On>
  <Type options="02;1BC2" startoffset="1">replace data</Type>
</Action>
```

Example on response:

In the following example, 1BC2 will be replaced by 02. The first and the last byte in the data string will be left unchanged:

```xml
<Action id="10">
  <On>response</On>
  <Type options="1BC2;02" startoffset="1" endoffset="1">replace data</Type>
</Action>
```

In the following example, throughout the data string, 1BC2 will be replaced by 02 and 1BC3 will be replaced by 03:

```xml
<Action id="10">
  <On>response</On>
  <Type options="1BC3-1BC2;03-02" startoffset="1" endoffset="1">replace data</Type>
</Action>
```
