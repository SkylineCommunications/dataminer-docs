---
uid: Protocol.PortSettings.BusAddress.Value
---

# Value element

Using one or more Value elements, you can specify the different values that users are allowed to enter.

## Type

string

## Parent

[BusAddress](xref:Protocol.PortSettings.BusAddress)

## Remarks

- The value specified in the DefaultValue tag does not have to be specified in a Value tag.
- When no Value tags are specified, users will only be allowed to enter the value specified in the DefaultValue tag.

Contains

Value of type string

In the following example, the user can enter the values 10 and 16:

```xml
<Value>10</Value>
<Value>16</Value>
```

The following wildcards can be used:

- \*: A series of characters
- ?: A single character

In the following example, users have to enter a value containing a dot (e.g., 10.5, 2.3, 245.63, etc.):

```xml
<Value>*.*</Value>
```
