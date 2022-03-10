---
uid: Protocol.Responses.Response.Content-optional
---

# optional attribute

Specifies that no error will occur if they are not found in the response received from the device.

## Content Type

string

## Parent

[Content](xref:Protocol.Responses.Response.Content)

## Remarks

Parameters included in a response definition can be marked as optional. This means that no error will occur if they are not found in the response received from the device.

If a parameter matches, DataMiner will simply go on to the next parameter and check that one.

If an optional parameter does not match, the following special characters can be included in the optional attribute of the Protocol.Responses.Response tag to tell DataMiner what to do:

- \+ : Tells DataMiner to skip the next parameter. Multiple “+” characters can be entered to have several parameters skipped.
- \* : Tells DataMiner to skip the parameters in the response until it reaches the next optional parameter.

> [!NOTE]
> In this attribute, refer to the parameters using their 0-based position in the response.

## Examples

Take a look at the following example:

```xml
<Content optional="0+++++++;1;2;3;4;5;6;7;8*;10*;13+++">
	...
</Content>
```

This example tells DataMiner ...

- 0 is an optional parameter. If no match, skip 7 parameters.
- 1 is an optional parameter. If no match, do nothing special.
- 2 is an optional parameter. If no match, do nothing special.
- 3 is an optional parameter. If no match, do nothing special.
- 4 is an optional parameter. If no match, do nothing special.
- 5 is an optional parameter. If no match, do nothing special.
- 6 is an optional parameter. If no match, do nothing special.
- 7 is an optional parameter. If no match, do nothing special.
- 8 is an optional parameter. If no match, skip to the next optional parameter.
- 10 is an optional parameter. If no match, skip to the next optional parameter.
- 13 is an optional parameter. If no match, skip 3 parameters.
