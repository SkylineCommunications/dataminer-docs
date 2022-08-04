---
uid: Protocol.Display
---

# Display element

Defines the layout and the order of the Data Display pages.

## Parent

[Protocol](xref:Protocol)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[defaultPage](xref:Protocol.Display-defaultPage)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)||Defines the page that will be shown by default.|
|[pageOptions](xref:Protocol.Display-pageOptions)|string||Used for EPM (formerly known as CPE) elements in order to disable the possibility to open the Data Display page of the element.|
|[pageOrder](xref:Protocol.Display-pageOrder)|string||Defines the order of the pages.|
|[type](xref:Protocol.Display-type)|[EnumDisplayType](xref:Protocol-EnumDisplayType)||See the tooltips of the different options.|
|[wideColumnPages](xref:Protocol.Display-wideColumnPages)|string||Defines the pages that have only one column. Page names are separated by a semicolon (”;”).|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Pages](xref:Protocol.Display.Pages)|[0, 1]|Allows to define pages and specify their configuration (e.g. configure the visibility).|

## Examples

```xml
<Display wideColumnPages="page1;page2" defaultPage="General" pageOrder="General;page2;page1"/>
```
