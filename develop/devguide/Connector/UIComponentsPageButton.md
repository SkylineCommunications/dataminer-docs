---
uid: UIComponentsPageButton
---

# Page button

A page button allows a user to open a popup page.

To define a page button:

1. Create a parameter of type "write" and set Type to "pagebutton".
1. Add a Discreets tag. Each Discreet tag that is added will introduce an additional page button. The display text is the text that will appear on the button. The value text is the page that will be opened when a user clicks the button. (Note: This page is not shown in the page selection box of the element).
1. Specify the width of the page button (the value must at least be 110).

> [!NOTE]
> To distinguish a page button from an ordinary button, always add an ellipsis (i.e. three dots) to the value displayed on the button (without a space between the value and the ellipsis).

```xml
<Param id="220">
  <Name>DetailsPageButton</Name>
  <Description></Description>
  <Type>write</Type>
  <Interprete>
    <RawType>other</RawType>
    <Type>string</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type width="110">pagebutton</Type>
    <Discreets>
      <Discreet>
        <Display>Details...</Display>
        <Value>Details</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
```

![alt text](../../images/uipagebutton.png "DataMiner Cube page button")

> [!NOTE]
> 
> - Typically, the description tag is left empty when a toggle button is defined.
> - Page buttons are typically used to display a limited amount of data. A pop-up window opened by means of a page button should contain either data of less importance or data that should remain visible while users are working on other pages.
> - A pop-up page opened by means of a page button should not contain page buttons. In other words, nesting of page buttons should be avoided.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Measurement.Type: pagebutton](xref:Protocol.Params.Param.Measurement.Type#pagebutton)
