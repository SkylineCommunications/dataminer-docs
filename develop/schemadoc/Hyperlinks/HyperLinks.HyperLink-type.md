---
uid: HyperLinks.HyperLink-type
---

# type attribute

Specifies the hyperlink type.

## Content Type

| Item | Facet Value | Description |
| --- | --- | --- |
| ***string restriction*** |  |  |
| &#160;&#160;Enumeration | url | Opens a URL in a web browser. |
| &#160;&#160;Enumeration | execute | Runs an executable file. |
| &#160;&#160;Enumeration | script | Runs an Automation script. |
| &#160;&#160;Enumeration | openview | Opens a DataMiner view in a new card. If the [VID] placeholder is used in the <Hyperlink> tag, the view of the selected alarm is opened. |
| &#160;&#160;Enumeration | openservice | Opens a DataMiner service in a new card. If the [SID] placeholder is used in the <Hyperlink> tag, the service of the selected alarm is opened. |
| &#160;&#160;Enumeration | openelement | Opens a DataMiner element in a new card. If the [EID] placeholder is used in the <Hyperlink> tag, the element of the selected alarm is opened. |
| &#160;&#160;Enumeration | openparameter | Opens a DataMiner parameter in a new card. If the [PID] placeholder is used in the <Hyperlink> tag, the parameter of the selected alarm is opened. |
| &#160;&#160;Enumeration | reference | Refers to a legacy hyperlink. |

## Parents

[HyperLink](xref:HyperLinks.HyperLink)

## Remarks

The following types are supported:

- **url**: Opens a URL in a web browser.
- **execute**: Runs an executable file.
- **script**: Runs an Automation script. For information on how to specify the script to be run, see [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script).

  > [!NOTE]
  > It is not necessary to use the "Script:" prefix in a second-generation hyperlink, as the *type* attribute already makes it clear an Automation script is referred to.

- **openview**: Opens a DataMiner view in a new card. If the \[VID\] placeholder is used in the \<Hyperlink> tag, the view of the selected alarm is opened.
- **openservice**: Opens a DataMiner service in a new card. If the \[SID\] placeholder is used in the \<Hyperlink> tag, the service of the selected alarm is opened.
- **openelement**: Opens a DataMiner element in a new card. If the \[EID\] placeholder is used in the \<Hyperlink> tag, the element of the selected alarm is opened.
- **openparameter**: Opens a DataMiner parameter in a new card. If the \[PID\] placeholder is used in the \<Hyperlink> tag, the parameter of the selected alarm is opened.
- **reference**: Refers to a legacy hyperlink. See [Upgrading legacy hyperlinks to second-generation hyperlinks](xref:Hyperlinks_xml#upgrading-legacy-hyperlinks-to-second-generation-hyperlinks) for more information.

> [!TIP]
> See also: [Content of the Hyperlink tag](xref:HyperLinks.HyperLink)
