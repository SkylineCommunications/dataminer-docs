---
metadata_version: 1
uid: UIComponentsTitle
description: "Describe the DataMiner connector development topic Title, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Title

Allows you to display a title in the UI.

To define a title, create a parameter of type "fixed". In the Measurement tag, set Type to "title". To add a line below the title, use the options attribute.

```xml
<Param id="280" trending="false">
  <Name>TitleSoftwareManagement</Name>
  <Description>TitleSoftwareManagement</Description>
  <Type>fixed</Type>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type options="begin">title</Type>
  </Measurement>
</Param>
```

![DataMiner Cube title](~/develop/images/uititle.png)

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Measurement.Type: title](xref:Protocol.Params.Param.Measurement.Type#title)
- [Options for measurement type “title”](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-title)
