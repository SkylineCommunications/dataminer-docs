---
uid: Specifying_the_background_of_Visual_Overview_pages
---

# Specifying the background of Visual Overview pages

> [!TIP]
>
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[misc > COLORS]* page.
> - For a how-to video, see [Visio – Adding a background](https://community.dataminer.services/video/visio-adding-a-background/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Specifying background pages in Visio

In Visio, it is possible to configure a page as a background page, and configure other pages to use it as a background. The background page itself will not be displayed in Visual Overview.

To set a page as a background page in Visio:

1. Right-click the page tab of the background page at the bottom of the window, and select *Page setup*.
1. In the *Page Properties* tab, next to *Type*, select *Background*.
1. Click *OK* to close the *Page Properties* window.

To configure a page to use a particular background page as its background:

1. Right-click the page tab of the page, and select *Page setup*.
1. In the *Page Properties* tab, next to *Background*, select the background page you wish to use.
1. Click *OK* to close the *Page Properties* window.

## Specifying the background color of Visual Overview pages

In Visio drawings, two page-level shape data fields can be used to specify the background color of the Visual Overview pages in DataMiner.

- Use a shape data field of type **InnerBackground** to set the background color of a particular page of a Visio drawing.
- Use a shape data field of type **OuterBackground** to set the background color of the entire card.

### Configuring the shape data fields

Add a shape data field of type **InnerBackground** or **OuterBackground** to the page, and set its value to a valid ARGB value.

The alpha value, which indicates the opacity (i.e. level of transparency) of the color, is optional.

### Examples

```txt
#FFFF00 (without alpha value)
#FF99CCFF (with alpha value)
```

## Priority of background pages vs. background colors

It is possible to combine the use of a background page with the use of background colors. In that case, the following order will be applied to determine which background is displayed (from back to front):

1. OuterBackground setting on Visio background page.
1. OuterBackground setting on default Visio page.
1. Drawing on Visio background page.
1. InnerBackground setting on Visio background page.
1. InnerBackground setting on default Visio page.
1. Drawing on default Visio page.
