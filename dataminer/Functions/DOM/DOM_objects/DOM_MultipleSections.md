---
uid: DOM_MultipleSections
---

# Multiple sections

A [SectionDefinition](xref:DOM_SectionDefinition) is linked to a [DomInstance](xref:DomInstance) through either a [SectionDefinitionLink](xref:DomDefinition#sectiondefinitionlink) or a [StatusSectionDefinitionLink](xref:DOM_status_system#configuring-fields) depending on whether you use the [DOM status system](xref:DOM_status_system) or not. These links have the option to allow multiple sections of the same [SectionDefinition](xref:DOM_SectionDefinition). There are some important remarks to take into account when using this.

> [!NOTE]
> The *AllowMultipleSections* property is available from DataMiner version 10.3.3/10.3.0 onwards. In earlier DataMiner versions, it is possible to add multiple sections already, but these are not checked and cannot be used in the UI. When you upgrade to DataMiner 10.3.0/10.3.3, you will need to update any existing DOM behavior definitions or DOM definitions with multiple sections.

## Filtering

It is not possible to filter on field values scoped to one section part of multiple sections. Consider the following example:

- **DOM Instance A**:
  - Connection Section 1:
    - From: London
    - To: Helsinki
  - Connection Section 2:
    - From: Brussels
    - To: Paris

Imagine you want to create a filter to know if a DOM instance exists that has a connection from "London" to "Paris":

```csharp
DomInstanceExposers.FieldValues.DomInstanceField(FromFieldDescriptor).Equal("London")
AND
DomInstanceExposers.FieldValues.DomInstanceField(ToFieldDescriptor).Equal("Paris")
```

This filter would return DOM instance A, even though it does not have a direct connection between "London" and "Paris". The field values that are part of multiple sections are flattened and treated as a list of values: `['London', 'Brussels']`. There currently is no way of creating a filter that is scoped to a single section of a multiple sections setup.

## Remarks

- Adding a lot of sections increases the size of a `DomInstance`, impacting performance. See [Best practices](xref:DOM_best_practices#try-to-keep-the-dominstance-objects-small).

- Fields in a multiple sections setup are not available in GQI queries. In case you do want to use these fields, we suggest looking into [ad hoc data sources](xref:Get_ad_hoc_data).
