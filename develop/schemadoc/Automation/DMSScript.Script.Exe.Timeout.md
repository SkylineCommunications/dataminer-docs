---
metadata_version: 1
uid: DMSScript.Script.Exe.Timeout
description: "Use the Timeout element to set seconds for findinteractiveclient actions or milliseconds for sleep actions in an automation script."
---

# Timeout element

Specifies the timeout value (in s or ms depending on the action in which it is used).

## Type

positiveInteger

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Remarks

Used with script actions of type "findinteractiveclient" and "sleep". The unit depends on the action:

| Action type | Unit |
|---|---|
| `findinteractiveclient` | Seconds to wait for a user to attach. |
| `sleep` | Milliseconds to pause the script. |

This element does not set the timeout of a C# code block. For that timeout, use the `IEngine.Timeout` property in the C# code.

## Examples

```xml
<Timeout>90</Timeout>
```
