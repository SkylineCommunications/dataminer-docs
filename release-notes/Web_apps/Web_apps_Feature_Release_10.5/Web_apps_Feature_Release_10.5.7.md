---
uid: Web_apps_Feature_Release_10.5.7
---

# DataMiner web apps Feature Release 10.5.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.7](xref:General_Feature_Release_10.5.7).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.7](xref:Cube_Feature_Release_10.5.7).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Low-Code Apps - Interactive Automation scripts: Enhancements made to redesigned UI component 'StaticText' [ID 42662]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When the text in a redesigned `UIBlockType.StaticText` component does not fit the width of the component, it will automatically be ellipsed, and when you hover over the component, the full text will be displayed in a tooltip.

From now on, the text in a redesigned `UIBlockType.StaticText` will no longer be automatically ellipsed when it contains newline characters. In that case, similar to the legacy `UIBlockType.StaticText` component, the text will be split into multiple lines.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

### Fixes

#### Dashboards app & Low-Code Apps: No error would be returned when a parameter or an element could not be fetched [ID 42584]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

When a component tried to fetch parameters or elements, up to now, null would be returned for every parameter or element that could not be found.

From now on, for every parameter or element than cannot be found, a clear error message will be returned. Each of those error messages will then explain why a particular parameter or element could not be found.
