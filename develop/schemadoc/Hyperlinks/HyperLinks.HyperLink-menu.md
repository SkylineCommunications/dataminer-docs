---
uid: HyperLinks.HyperLink-menu
---

# menu attribute

Configures where in the shortcut menu (a specific submenu or the root) the item should appear.

## Content Type

string

## Parents

[HyperLink](xref:HyperLinks.HyperLink)

## Remarks

If you add a hyperlink to *Hyperlinks.xml*, by default, it will appear in the "Hyperlinks" submenu of the Alarm Console shortcut menu. However, if you want it to appear in another submenu (or in the root) of the shortcut menu, add this optional *menu* attribute to the *\<HyperLink>* tag and specify a location.

Examples:

- Enter "root" to make it appear in the root of the shortcut menu.
- Enter e.g., "root/MyLinks" to make it appear in the "MyLinks" submenu.
- Enter e.g., "root/MyLinks/Scripts" to make it appear in the "MyLinks/Scripts" submenu.

> [!NOTE]
> If you do not specify a *menu* attribute or if you do not start the value of the menu attribute with "root", the hyperlink will be added to the default "Hyperlinks" submenu.
