---
uid: Cube_Main_Release_10.3.0_CU5
---

# DataMiner Cube Main Release 10.3.0 CU5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU5](xref:General_Main_Release_10.3.0_CU5).

### Enhancements

#### Visual Overview: External connectivity updates for dynamically positioned shapes will now be applied in real time [ID_36333]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

Up to now, external connectivity updates for dynamically positioned shapes would not be applied in real time. To see the changes, you had to close the visual overview and open it again. From now on, any external connectivity updates for dynamically positioned shapes will immediately be visible.

#### Visual Overview: TextWrapping should now default to the correct value "Wrap" [ID_36363]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When a shape did not have a *TextStyle* shape data field, up to now, the *TextWrapping* option would automatically be set to "WrapWithOverflow". From now on, when a shape does not have a *TextStyle* shape data field, the *TextWrapping* option will automatically be set to "Wrap" instead.

Also, because of a number of enhancements, overall performance has increased when rendering shapes without a *TextStyle* shape data field.

### Fixes

#### Visual Overview: Problem with element or view scope of Children shapes [ID_36354]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

In some cases, when a placeholder was used in the *Element* or *View* shape data field of a *Children* shape, the scope would not be updated when changes were made to the placeholder.

From now on, the scope will be updated correctly whenever changes are made to the placeholder in the *Element* or *View* shape data field.

#### System Center: Problem with 'Show agent alarms' link [ID_36463]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you selected an agent in the *Agents* section of *System Center*, in some cases, the alarm numbers shown in the *Show agent alarms* link would not be correct.

Also, when you clicked that *Show agent alarms* link, the alarm tab listing the alarms of the selected agent would incorrectly be empty.
