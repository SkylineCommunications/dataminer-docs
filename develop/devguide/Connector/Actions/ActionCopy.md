---
uid: LogicActionCopy
---

# copy

This action can be executed on parameters only.

This action copies the value of the source parameter to the destination parameter(s).

> [!NOTE]
>
> - The existing value of the destination parameter will be overwritten.
> - When a copy action is executed on a read parameter, a parameter change event will only be raised if the value actually changes. So for example copying value "A" to a read parameter that already has value "A" will not cause a parameter change event to be raised. This is different from QAction SetParameter calls, which will always cause a parameter change event to be raised.

## Attributes

### On@id

Specifies the ID(s) of the destination parameter(s).

### Type@id

(optional): Specifies the ID of the source parameter.

> [!NOTE]
> When the action is executed via a trigger that triggers on a parameter, the use of the Type@id attribute is not required. In this case, when the Type@id attribute is not present, DataMiner will use the trigger parameter (i.e., the parameter referred to in the On element of the trigger) as the source parameter.

## Examples

In the following example, the content of the parameter with ID 6 is copied to the parameter with ID 17:

```xml
<Action id="1">
  <On id="17">parameter</On>
  <Type id="6">copy</Type>
</Action>
```

The Value tag of a parameter contains an ASCII value. If you want to copy the value of a fixed unsigned number parameter to another unsigned number parameter, and you define the following in the fixed parameter ...

```xml
<Interprete>
  <RawType>unsigned number</RawType>
  <LengthType>fixed</LengthType>
  <Length>1</Length>
  <Type>double</Type>
  <Value>1</Value>
</Interprete>
```

... then after the copy operation, the other parameter will display “49” (i.e., the ASCII value of 1). In the example above, you would have to specify <Value>0x01</Value> to display 1 or you would have to set RawType to “numeric text”.

> [!NOTE]
> When you copy a parameter that contains “0x00”, the copy operation will stop when it reaches “0x00”. If there are bytes after “0x00”, they will not be copied. If you want them to be copied, then in a QAction execute a “getparameter” followed by a “setparameter”.
