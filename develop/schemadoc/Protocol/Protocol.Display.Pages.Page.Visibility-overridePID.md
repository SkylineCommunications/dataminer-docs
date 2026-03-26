---
uid: Protocol.Display.Pages.Page.Visibility-overridePID
---

# overridePID attribute

Specifies the ID of the parameter that is used to compare its value against the value specified in the "value" attribute.

## Content Type

unsignedInt

## Parent

[Visibility](xref:Protocol.Display.Pages.Page.Visibility)

## Remarks

Specifies the ID of the parameter of which the parameter value is compared against the value specified in the value attribute.

> [!NOTE]
>
> - In case the parameter referred to by the overridePID attribute is a parameter that is displayed on a page (i.e., the user can control the page visibility), make sure this parameter is displayed on a page that is always visible.
> - If the default page is hidden, the first non-hidden page will be selected.
> - If all pages are hidden, a message will appear to inform the user that there are no available data pages.
> - When the DATA tree item is selected in a card's navigation pane while no pages are visible, as soon as a page becomes visible, it will automatically be selected.
