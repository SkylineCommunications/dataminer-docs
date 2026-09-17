---
metadata_version: 1
uid: UIComponentsTreeControlAdvancedHierarchy
description: "Describe the DataMiner connector development topic Advanced hierarchy, including its purpose, behavior, implementation guidance, and relevant constraints."
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

# Advanced hierarchy

It is possible to choose a different hierarchy path based on the cell value of the parent row. In order to use the advanced structure, the path attribute must be omitted or empty.

![DataMiner Cube tree control advanced hierarchy example](~/develop/images/uiX_-_advanced_hierarchy.png)

```xml
<TreeControl parameterId="10" readOnly="false">
  <Hierarchy>
    <Table id="1000" />
    <Table id="2000" parent="1000" condition="1002:People" />
    <Table id="3000" parent="1000" condition="1002:Cars_EUR" />
    <Table id="3000" parent="1000" condition="1002:Cars_USA" />
    <Table id="4000" parent="3000" />
    <Table id="5000" parent="1000" />
  </Hierarchy>
  <ReadonlyColumns />
  <OverrideDisplayColumns />
  <OverrideIconColumns />
</TreeControl>
```
