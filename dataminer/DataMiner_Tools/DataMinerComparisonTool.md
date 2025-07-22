---
uid: DataMinerComparisonTool
---

# DataMiner Comparison tool

The DataMiner Comparison tool is a web application that allows you to compare the values of two string parameters on a character-by-character basis and to immediately spot the differences (additions, modifications, and deletions).

You can access the tool via the following URL:

```txt
http(s)://[DMA name]/Comparison
```

> [!NOTE]
> This tool supports SAML authentication from DataMiner 10.3.8/10.4.0 onwards.

## Working with the Comparison tool

### [From DataMiner 10.3.9/10.4.0 onwards](#tab/tabid-1)

<!-- Modified layout of the tool is introduced with RN 36747 -->

1. Make sure the settings panel on the left is expanded. If it is collapsed, you can expand it by clicking the cogwheel icon.

   ![Comparison tool UI](~/dataminer/images/Comparison_app_10_3_9.png)<br>
   *DataMiner Comparison tool in DataMiner 10.3.9*

1. In the *Original text* and *Modified text* boxes on the left, select an element and parameter (and an index if necessary), and click *Get original value* and *Get modified value*, respectively.

   > [!NOTE]
   > It is also possible to specify the two parameters in the URL of the application, using the following URL arguments:
   >
   > ```
   > parameter1=dmaID/elementID/parameterID/index
   > parameter2=dmaID/elementID/parameterID/index
   > ```
   >
   > In the URL, both arguments have to be encoded. For example: ```http://localhost/Comparison/#/?parameter1=271%2F50258%2F2%2F&parameter2=271%2F50259%2F2%2F```

1. At the bottom of the panel on the left, modify [the settings](#settings) according to your preference.

1. Compare the values displayed in the two columns of the main pane of the app.

   By default, the columns will scroll in unison. If you do not want this, deactivate the "locked scrolling" feature using the *Toggle locked scrolling* icon at the bottom of the screen.

> [!NOTE]
>
> - If you modify a parameter value in the comparison tool, the changes you made will not be sent to the DataMiner Agent. They will be lost when you close the tool.
> - To log out of the tool, click your username or icon in the top right corner and select *Log out*.

### [Earlier DataMiner versions](#tab/tabid-2)

In the parameter selection panel at the top of the screen, select two parameters:

- by manually selecting an element and a parameter (or a parameter and an index) on both sides, or
- by specifying two parameters in the URL of the application.

When you specify the parameters in the URL, use the following URL arguments:

```txt
parameter1=dmaID/elementID/parameterID/index
parameter2=dmaID/elementID/parameterID/index
```

In the URL, both arguments have to be encoded. For example:

```txt
http://localhost/Comparison/#/?parameter1=271%2F50258%2F2%2F&parameter2=271%2F50259%2F2%2F
```

If you select the parameters manually, click the *Get value* buttons to retrieve their current values. If the parameters are specified in the URL, their current values will automatically be retrieved.

By default, the two value boxes (left and right) will scroll in unison. If you do not want this, you can deactivate the "locked scrolling" feature using the *Toggle locked scrolling* icon at the bottom of the screen.

You can also configure a number of [settings](#settings) for the Comparison tool. To access these, click the cogwheel icon in the black bar on the left.

> [!NOTE]
>
> - If you modify a parameter value in the comparison tool, the changes you made will not be sent to the DataMiner Agent. They will be lost when you close the tool.
> - To log out of the tool, click your username or icon in the top right corner and select *Log out*.

***

## Settings

The following settings are available for the Comparison tool:

- **Show differences**: If this setting is selected, the differences between the two parameter values will be highlighted.

  URL argument: `diff` (default: true)

- **Align chunks**: If this setting is selected, empty lines will be inserted if necessary so that the two parameter values are aligned. If this option is not selected, no empty lines will be added, and unaligned associated differences will be connected with curved lines.

  URL argument: `align` (default: true)

- **Collapse common lines**: If this setting is selected, only lines that differ will be shown (with a common context of maximum 5 lines before and after). All identical lines will be collapsed. If you want to expand identical lines, click *...*.

  URL argument: `collapse` (default: false)

- **Semantic cleanup**: If this setting is selected, post-processing heuristics will be performed to make differences more easily readable. For example, if the word "cheese" is replaced with "whale", the highlighting algorithm will detect accidental matching characters "h" and "e". The semantic cleanup routine will try to fix this by combining these small differences in larger chunks to make them more manageable semantically.

  URL argument: `cleanup` (default: false)

- **Enable patch mode**: If this setting is selected, the two parameter values will not be compared directly. Instead, the modified text will first be reconstructed by patching the original text in the first parameter using the differences supplied in the second parameter. Finally the modified text will be displayed next to the original.

  URL parameter: `patch` (default: false)

> [!NOTE]
> If you have selected two parameters and configured the settings in the app, this is reflected in the app URL. To reuse a particular configuration, you can bookmark this URL.

## Embedding the Comparison tool in Visual Overview

The DataMiner Comparison tool can be embedded within Visual Overview by means of a shape data item of type **Link**. For more information, see [Linking a shape to a webpage](xref:Linking_a_shape_to_a_webpage).

If you want the header and the parameter selection panel to be hidden in the embedded tool, add the `embed=true` argument to the URL.
