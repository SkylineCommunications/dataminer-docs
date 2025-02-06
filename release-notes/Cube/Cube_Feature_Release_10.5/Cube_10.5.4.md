---
uid: Cube_Feature_Release_10.5.4
---

# DataMiner Cube Feature Release 10.5.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.4](xref:General_Feature_Release_10.5.4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.4](xref:Web_apps_Feature_Release_10.5.4).

## Highlights

*No highlights have been selected yet.*

## New features

#### Elements can now be configured to run in isolation mode [ID 41758]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

When you are editing an element, you can now indicate that it should run in isolation mode, i.e. in its own SLProtocol and SLScripting process.

To do so, go to *Advanced element settings*, and select the *Run in isolation mode* option.

When, in either the *protocol.xml* file or the *DataMiner.xml* file, the element in question is forced to run in isolation mode, the *Run in isolation mode* option will already be selected. In that case, clearing the option will not be possible.

For more information about running elements in isolation mode, see [Elements can now be configured to run in isolation mode [ID 41757]](xref:General_Feature_Release_10.5.4#elements-can-now-be-configured-to-run-in-isolation-mode-id-41757).

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Visual Overview: Problem when updating element shapes that are linked to service elements via aliases [ID 41730]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Elements that are part of a service can be given an alias within that service context. Element data within a visual overview can then contain such an element alias to make sure a particular shape is linked to the element referred to by the alias.

Up to now, when a service containing different elements was updated, and those elements had aliases that were used in element shapes, those shapes would not get updated because they would incorrectly be linked to the actual elements instead of the aliases.

From now on, when services are updated, element shapes will reflect the element to which the alias in the shape data refers to at the time of the update.

#### Visual Overview: Shapes displaying the name of a service or a view would not be updated when the name was changed [ID 41769]

<!-- MR 10.4.0 [CU13] / 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, when the name of a service or a view was updated, shapes displaying that name would incorrectly not be updated.

From now on, shapes that display the name of an object using an asterisk in the shape text and a shape data field of type *Info* set to "NAME" will automatically be updated when the name of that object changes.

> [!NOTE]
> The "[Name]" placeholder does not update in real time, only shape data fields of type *Info* set to "NAME" will.
