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

[byte(s) to be replaced];[new byte(s)]. To specify multiple bytes, separate these by hyphens ("-"). Optionally, a third item can be provided ("[byte(s) to be replaced];[new byte(s)];use_offset"), to indicate that the replacement should be performed on the first x bytes and the last y bytes (see example below).

#### Type@startoffset

(optional): The first byte in the data string that can be replaced (0-based value, starting from the beginning of the data string). Default: 0.

#### Type@endoffset

(optional): The last byte in the data string that can be replaced (0-based value, starting from the end of the data string). Default: 0.

## On command

### Attributes

#### On@id

Specifies the ID(s) of the command(s) on which to perform this action.

#### Type@options

[byte(s) to be replaced];[new byte(s)]. To specify multiple bytes, separate these by hyphens ("-"). Optionally, a third item can be provided ("[byte(s) to be replaced];[new byte(s)];use_offset"), to indicate that the replacement should be performed on the first x bytes and the last y bytes.

#### Type@startoffset

(optional): The first byte in the data string that can be replaced (0-based value, starting from the beginning of the data string). Default: 0.

#### Type@endoffset

(optional): The last byte in the data string that can be replaced (0-based value, starting from the end of the data string). Default: 0.

## On response

### Attributes

#### On@id

Specifies the ID(s) of the response(s) on which to perform this action.

#### Type@options

[byte(s) to be replaced];[new byte(s)]. To specify multiple bytes, separate these by hyphens ("-"). Optionally, a third item can be provided ("[byte(s) to be replaced];[new byte(s)];use_offset"), to indicate that the replacement should be performed on the first x bytes and the last y bytes.

#### Type@startoffset

(optional): The first byte in the data string that can be replaced (0-based value, starting from the beginning of the data string). Default: 0.

#### Type@endoffset

(optional): The last byte in the data string that can be replaced (0-based value, starting from the end of the data string). Default: 0.

## Examples

Example on parameter

```xml
<Action id="47">
  <On id="63">parameter</On>
  <Type options="0x090x0D0x0A;0x49" startoffset="0">replace data</Type>
</Action>
```

In the following example, the replace will be performed on the first 7 bytes and the last 2 bytes.

```xml
<Action id="128">
  <On id="130">parameter</On>
  <Type startoffset="7" endoffset="2" options="0x25;0x250x25;use_offset">replace data</Type>
</Action>
```

Example on command

```xml
<Action id="12">
  <On>command</On>
  <Type options="02;1BC2" startoffset="1">replace data</Type>
</Action>
```

Example on response

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
