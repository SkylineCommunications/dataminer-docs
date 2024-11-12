---
uid: Cube_Feature_Release_10.5.1
---

# DataMiner Cube Feature Release 10.5.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.5.1](xref:General_Feature_Release_10.5.1).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### System Center - Users/Groups: Tooltip of 'Admin tools' permission has been enhanced [ID 40983]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When you hover over the information icon next to the *Modules > System configuration > Tools > Admin tools* user permission, a tooltip appears, showing more information on this permission. The text of this tooltip has now been enhanced.

#### Cards: Enhancements to prevent view cards from showing a 'Loading' message when opened [ID 41162]

<!-- MR 10.3.0 [CU22] / 10.4.0 [CU10] - FR 10.5.1 -->

A number of enhancements have been made to prevent view cards from showing a "Loading" message when opened.

#### Alarm templates: Text in 'Augmented Operations alarm settings' pop-up window has been made more translation-friendly [ID 41254]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

In the *Augmented Operations alarm settings* pop-up window, the text has been adjusted to allow a more natural translation to other languages.

#### Redundancy groups: Configuration enhancements [ID 41315]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

A number of enhancements have been made with regard to the configuration of redundancy groups and redundancy group templates:

- When a block is loading in the *Switching detection* section, a "Loading" message will now be displayed on top of that block, making it impossible to make changes to the settings in that block until all settings have been loaded.

- The blocks in the *Switching detection* section will now initially be in an error state instead of a valid state. This will prevent users from saving an invalid configuration when data is still being loaded or when certain blocks contain invalid or corrupted data.

- More validation checks will now be done when scanning the changes made to the configuration. The outcome of those checks will determine whether the Apply button get enabled or not.

- When a validation scan detects invalid data, an entry will be added to the SLClient server logging. However, that entry will only be visible in the Logging module when the *Show debug logging* option is enabled. Also, in that case, no update message will be sent to the server. The user will receive a message saying that a problem occurred and that more details can be found in the Logging module.

### Fixes

#### Visual Overview: Shape data values starting with '[property:' and ending with ']' would be parsed incorrectly [ID 41047]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

When a shape linked to an element or a view contained shape data of which the value started with "[property:" and ended with "]", up to now, the entire value would be interpreted as a property, even when it included other types of placeholders.

#### Resources app: Quarantine warning would always appear when something went wrong while adding or updating a resource [ID 41201]

<!-- MR 10.3.0 [CU22] / 10.4.0 [CU10] - FR 10.5.1 -->

When, in the *Resources* app, you added or updated a resource, up to now, a pop-up window showing a quarantine warning would appear whenever something went wrong.

From now on, a pop-up window showing a quarantine warning will only appear in cases where quarantine applies.
