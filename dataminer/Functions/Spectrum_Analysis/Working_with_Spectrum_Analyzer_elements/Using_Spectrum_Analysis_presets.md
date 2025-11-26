---
uid: Using_Spectrum_Analysis_presets
---

# Using Spectrum Analysis presets

## About presets

Spectrum Analysis presets can be used to reload settings, to reload a set of markers, to save and reload a trace image, to load a reference trace, etc. The following information can be stored in a preset:

- Settings, e.g. start frequency, stop frequency

- Display settings, including the trace visibility

- A reference trace

- Marker positions

- Reference lines

- Threshold information

- Measurement cycles

- The ID of the measurement point for which the trace is measured

Presets can be saved publicly (i.e. shared) or privately:

- Public: Anybody can access, use and modify these presets. Commonly used presets will typically be saved as “public” so that everybody performs the same measurement with the same settings, and store a reference trace image.

- Private: Private presets are only available for the user account that created them. Other users will not be able to see or use these presets.

## Saving presets

In order to save a configuration, a preset must already exist that you can save the configuration into.

To save a preset in DataMiner Cube:

1. Go to the *SAVE* section of the *Presets* tab in the settings pane.

1. In the dropdown list, select the preset you want to save the configuration into.

1. Click *Save*.

## Loading presets

To load a preset in DataMiner Cube:

1. Go to the *LOAD* section of the *Presets* tab in the settings pane.

1. To show public presets as well as private presets, select *Show shared presets*.

1. In the list of available presets, select the one you wish to load.

   If the selected preset has a description, this will be displayed below the list of presets.

1. In the *Preset contents* section, select the checkboxes corresponding to the preset content you want to load.

   > [!NOTE]
   > Depending on the content of the preset, some checkboxes may not be available.

1. Click the *Load* button.

> [!NOTE]
> When a reference trace has been loaded from a preset, it will be added in the list of traces in the info pane, with the corresponding trace color.
>
> - You can change the reference trace color in the *trace* tab of the ribbon, by clicking *Color* > *Reference trace*, and selecting the new color.
> - To hide the reference trace, in the *trace* tab of the ribbon, clear the selection from *Show reference*.

## Creating new presets

To create a new preset in DataMiner Cube:

1. In the settings pane, at the bottom of the *Presets* tab, click the *Manage* button.

1. Click the *New* button.

1. Enter a name for the preset and, optionally, a description.

1. Optionally, to create a public preset, select *Share preset with other users*. If you do not do so, the preset will by default be considered a private preset.

1. Optionally, make the preset protected by selecting *Save as protected*. Protected presets can only be edited by the user who made them or by users with the user permission *Edit/Delete Protected Presets*.

1. Click *OK*.

   The preset will be added to the list of available presets.

## Editing presets

For more information on how to save different information in a preset, see [Saving presets](#saving-presets).

To edit the settings, name or description for a preset:

1. In the settings pane, at the bottom of the *Presets* tab, click the *Manage* button.

1. Click the *Edit* button.

1. Edit the name, description and settings as needed, in the same way as when creating the preset.

1. Click *OK*.

> [!NOTE]
> Shared presets can be used in scripts, so modifications could cause a script to malfunction. Therefore, a warning will be shown when you attempt to modify a preset that is currently used by a script.

## Deleting presets

To delete a preset in DataMiner Cube:

1. In the settings pane, at the bottom of the *Presets* tab, click the *Manage* button.

1. Click the preset you want to delete in order to select it.

1. Click the *Delete* button below the list of presets.
