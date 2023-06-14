---
uid: Cube_Feature_Release_10.3.8
---

# DataMiner Cube Feature Release 10.3.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.8](xref:General_Feature_Release_10.3.8).

## Highlights

*No highlights have been selected for this release yet*

## Other new features

#### Visual Overview: New BookingData component [ID_33215] [ID_36489]

<!-- MR 10.4.0 - FR 10.3.8 -->

You can now create a special *BookingData* shape and make it display all data associated with a particular booking.

To do so, create a shape with the following shape data fields:

|Shape data field | Value |
|-------------|---------------|
| Component   | `BookingData` |
| Reservation | The ID of the booking<br>Example: `[pagevar:SRMRESERVATIONS_IDOfSelection]` |

A *BookingData* shape will show the following information:

- On the left-hand side, you will find a list of resources used by the booking.

  For every resource, this list shows the following information:
  
  - the resource name
  - an icon indicating the function of the resource
  - an icon indicating whether the resource is linked to a service definition node
  - the node label or, if no node label is defined, the name of the function definition

- On the right-hand side, you see the profile data of the node or node interface you selected in the list on the left:

  - the profile instance (if applicable), and
  - the profile parameter values that will be used (note that these values can be overridden on several levels).
  
  > [!NOTE]
  > Priority of profile parameter value overrides:
  >
  > 1. Values defined in the parameter overrides (stored in the booking)
  > 1. Values defined in the profile instance
  > 1. Values defined in the profile definition

To be able to use the *BookingData* component, you will need

- a system with an Elasticsearch database
- a service manager license
- a resource manager license
- the following user permissions:

  - Modules > Bookings > UI Available
  - Modules > Functions > UI Available
  - Modules > Profiles > UI Available
  - Modules > Resources > UI Available
  - Modules > Services > UI Available

#### Open element cards will immediately show any changes made with regard to parameters [ID_36286]

<!-- MR 10.4.0 - FR 10.3.8 -->

When an element card is open, each time a new parameter is added to the element or an existing parameter is updated, the change will be applied in real time. You will no longer need to close the card and open it again to see the changes.

## Changes

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

#### Trending: Related parameters returned by the DMA would incorrectly be empty [ID_36511]

<!-- MR 10.4.0 - FR 10.3.8 -->

When you opened a trend graph containing related parameters, in some cases, the related parameters returned by the DataMiner Agent would incorrectly be empty.
