---
uid: UIComponentsVisualization
---

# Visualizing UI components

A protocol defines a number of pages in a specific order. This is specified by the "pageOrder" attribute of the Display tag. It contains a semicolon-separated list of page names. The default page that is displayed when opening the element is specified using the "defaultPage" attribute.

By default, a page consists of two columns. It is possible to specify that a page should only consist of one column (e.g. when the page holds a table) using the "wideColumnPages" attribute.

In order to visualize a UI component on a page, the RTDisplay tag of the component must be set to true. Setting RTDisplay to "true" results in the parameter being loaded in the SLElement process.

In addition, a position for the component must be specified. This is done via the Position tag. This tag allows you to specify on which page the parameter needs to be displayed and at which location on this page (i.e. the 0-based row and column).

```xml
<Display>
  <RTDisplay>true</RTDisplay>
  <Positions>
     <Position>
        <Page>General</Page>
        <Row>0</Row>
        <Column>0</Column>
     </Position>
  </Positions>
</Display>
```

> [!NOTE]
>
> - For the sake of brevity, in most of the examples within the UI components sections of this help, only tags required for the visualization of the element are shown. However, keep in mind that all elements should be validated in actual use cases.
> - There are other use cases for which RTDisplay of a parameter must be set to true, even when it is not visualized on a specific page. For more information, see RTDisplay.

## See also

DataMiner Protocol Markup Language:

- [Protocol.Display](xref:Protocol.Display)
- [Protocol.Params.Param.Display.Positions](xref:Protocol.Params.Param.Display.Positions)
