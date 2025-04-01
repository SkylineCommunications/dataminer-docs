---
uid: LogicActionClear
---

# clear

This action can be executed on parameters and responses.

## On Parameter

This action erases the memory of the specified parameter, causing an incoming value always to be accepted as a new value.

A trigger set to go off when that cleared parameter is changed, will always go off when the parameter is set to a new value, even if that value is equal to the previous value.

> [!TIP]
> See also: [Change-based event handling](xref:InnerWorkingsChangeBasedEventHandling)

> [!NOTE]
>
> - In the scope of (smart-)serial communication, if you perform a "clear" action on a parameter to make sure a trigger on parameter change or a QAction goes off, you must also perform a "clear" action on the response the parameter is part of.
> - For a table parameter, the memory is also cleared client-side. There is no need to add a "clear on display" to see the result. If the parameter is not a table parameter, the memory is not cleared client-side. In that case, the extra action will be needed.

### Attributes

#### On@id

Specifies the ID(s) of the parameter(s) to clear.

## On response

This action clears the response.

By default, if a response enters more than once with the same data, the accompanying trigger will go off only once. If the "clear" action is executed, however, the trigger can go off again.

> [!NOTE]
> A clear response should always happen after the response is fully handled. For example, Trigger After Response or Trigger After Group. This is because the flow for incoming data in SLProtocol is as follows:
>
> 1. Data is received from SLPort in SLProtocol
> 1. Data is checked against PreviousData; if it matches it will stop here.
> 1. Data is matched to parameters and all QActions and triggers for those parameters will run.
> 1. PreviousData is filled in with Data.
> A clear response that happens during a QAction or trigger during step 3 will have no effect, as PreviousData is written in step 4.

### Attributes

#### On@id

Specifies the ID(s) of the response(s) to clear.

## Examples

```xml
<Action id="1">
   <On id="1">parameter</On>
   <Type>clear</Type>
</Action>
```

```xml
<Action id="1">
   <On id="1">response</On>
   <Type>clear</Type>
</Action>
```
