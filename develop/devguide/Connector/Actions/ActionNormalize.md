---
uid: LogicActionNormalize
---

# normalize

This action can be executed on parameters only.

When the action is executed, the specified parameter will be normalized. In other words, either the last received value for that parameter or the current value of some other parameter will be set as the parameter’s normal value.

The ID of that other parameter (which can even be a dynamic table column) can be specified in the id attribute of the Type tag.

## Attributes

### On@id

Specifies the parameter(s) to normalize.

### Type@id

(optional): The value of the parameter referred to by this attribute is used as the parameter's normal value. Otherwise, the last received value of the parameter itself (i.e., the parameter specified in On@id) is used as the parameter's normal value.

## Examples

In the following example, the last received value for parameter 98 will be set as the nominal value of parameter 98:

```xml
<Action id="1">
  <On id="98">parameter</On>
  <Type>normalize</Type>
</Action>
```

In the following example, the current value of parameter 302 will be set as the nominal value of parameter 98:

```xml
<Action id="1">
  <On id="98">parameter</On>
  <Type id="302">normalize</Type>
</Action>
```

> [!NOTE]
> Instead of using this “normalize” action to normalize a parameter, try to use the type attribute of the Protocol.Params.Param.Alarm tag as much as possible.
