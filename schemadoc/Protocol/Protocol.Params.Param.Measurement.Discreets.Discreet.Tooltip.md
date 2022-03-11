---
uid: Protocol.Params.Param.Measurement.Discreets.Discreet.Tooltip
---

# Tooltip element

Specifies the tooltip to be displayed when the mouse pointer hovers over the icon displayed in a table cell containing the discrete parameter value to which it is linked.

## Type

string

## Parent

[Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)

## Remarks

> [!NOTE]
>
> - When you define tooltips for discrete values, note that, within a given \<Discreets\> tag, all \<Discreet\> tags should have a \<Tooltip\> tag. If no value should be defined for a particular \<Discreet\> tag, leave the \<Tooltip\> tag empty.
> - If you defined a tooltip for a particular discrete value, you cannot set the displayIconAndLabel attribute to "true".
> - For the list of placeholders that can be used inside the text of a tooltip, refer to [Placeholders](xref:UIComponentsCustomTableContextMenu#placeholders).

## Examples

In the following example, a tooltip was defined that displays data found in other columns of the same table (see also the note regarding placeholders below).

```xml
<Discreets>
    <Discreet iconRef="CAT">
        <Display>Two</Display>
        <Value>2</Value>
        <Tooltip>Number '{pid:1003}'\ndateTime '{pid:1004}'</Tooltip>
</Discreet>
...
