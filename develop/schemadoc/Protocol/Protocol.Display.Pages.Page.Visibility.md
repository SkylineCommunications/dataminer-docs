---
uid: Protocol.Display.Pages.Page.Visibility
---

# Visibility element

Specifies the page visibility configuration.

## Parent

[Page](xref:Protocol.Display.Pages.Page)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Required|Description|
|--- |--- |--- |--- |
|[default](xref:Protocol.Display.Pages.Page.Visibility-default)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)|Yes|Specifies the default visibility of the page.|
|[overridePID](xref:Protocol.Display.Pages.Page.Visibility-overridePID)|unsignedInt|Yes|Specifies the ID of the parameter that is used to compare its value against the value specified in the "value" attribute.|
|[value](xref:Protocol.Display.Pages.Page.Visibility-value)|string|Yes|Specifies the value the parameter referred to by the overridePID attribute should have in order to swap the visibility.|

## Remarks

- In case the parameter referred to by the overridePID attribute is a parameter that is displayed on a page (i.e. the user can control the page visibility), make sure this parameter is displayed on a page that is always visible.
- If the default page is hidden, the first non-hidden page will be selected.
- If all pages are hidden, a message will appear to inform the user that there are no available data pages.
- When the DATA tree item is selected in a card’s navigation pane when no pages are visible, as soon as a page becomes visible, it will automatically be selected.

## Examples

```xml
<Visibility default="true" overridePID="100" value="0" />
```

The example should be interpreted as follows: "By default, this page is visible, and will disappear when the parameter with ID 100 is set to 0"
