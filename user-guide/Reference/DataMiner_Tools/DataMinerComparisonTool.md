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

> [!NOTE]
>
> - If you modify a parameter value in the comparison tool, the changes you made will not be sent to the DataMiner Agent. They will be lost when you close the tool.
> - To log out of the tool, click your username in the top right corner and select *Log out*.

## Options

In the *Options* panel on the left-hand side of the screen, which you can expand by clicking the small cogwheel icon, you can select a number of options. Alternatively, you can also specify them in the URL of the application. The following options are available:

- **Show differences**: If this option is selected, the differences between the two parameter values will be highlighted.

    URL argument: `diff` (default: true)

- **Align chunks**: If this option is selected, empty lines will be inserted if necessary so that the two parameter values are aligned. If this option is not selected, no empty lines will be added, and unaligned associated differences will be connected with curved lines.

    URL argument: `align` (default: true)

- **Collapse common lines**: If this option is selected, only lines that differ will be shown (with a common context of maximum 5 lines before and after). All identical lines will be collapsed. If you want to expand identical lines, click *...*.

    URL argument: `collapse` (default: false)

- **Semantic cleanup**: If this option is selected, post-processing heuristics will be performed to make differences more easily readable. For example, if the word "cheese" is replaced with "whale", the highlighting algorithm will detect accidental matching characters "h" and "e". The semantic cleanup routine will try to fix this by combining these small differences in larger chunks to make them more manageable semantically.

    URL argument: `cleanup` (default: false)

- **Enable patch mode**: If this option is selected, the two parameter values will not be compared directly. Instead, the modified text will first be reconstructed by patching the original text in the first parameter using the differences supplied in the second parameter. Finally the modified text will be displayed next to the original.

    URL parameter: `patch` (default: false)

> [!NOTE]
> If, after selecting two parameters and the necessary options, you want to reuse this particular configuration, bookmark the URL.

## Embedding the Comparison tool in Visual Overview

The DataMiner Comparison tool can be embedded within Visual Overview by means of a shape data item of type **Link**. For more information, see [Linking a shape to a webpage](xref:Linking_a_shape_to_a_webpage).

If you want the header and the parameter selection panel to be hidden in the embedded tool, add the `embed=true` argument to the URL.
