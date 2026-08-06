---
uid: Embedding_a_Spectrum_Analysis_component
---

# Embedding a Spectrum Analysis component

It is possible to embed a Spectrum Analysis component in Visio.

> [!NOTE]
> Alternatively, it is also possible to embed a spectrum thumbnail. See [Linking a shape to an element parameter](xref:Linking_a_shape_to_an_element_parameter).

## Configuring the shape data fields

Configure the following shape data fields on the shape that is to contain the Spectrum Analysis component:

- Shape data field: **Element**

  The value of this shape data field should indicate the spectrum element of which the interface should be loaded.

- Shape data field: **Component**

  The value of this shape data field should be set to *Spectrum*, to indicate that a spectrum component should be created.

- Shape data field: **ComponentOptions**

  This is an optional shape data field, which can contain the following options, separated by pipe ("\|") characters.

  | Option     | Description |
  |------------|-------------|
  | Preset=    | Should be followed by a preset name. Indicates that a particular preset should be loaded. It is also possible to specify an inline preset, using the same syntax as for the *preset=inline* URL parameter. See [preset=inline](xref:Options_for_opening_DataMiner_Cube#presetinline). However, note that combining an inline preset with one or more measurement points is only supported from DataMiner 10.1.0 [CU11]/10.2.2 onwards. |
  | Measpts=   | Should be followed by one or more measurement point IDs, separated by semicolons. |
  | ViewOptions= | Should be configured in the same way as the *options=* URL parameter. See [options=](xref:Options_for_opening_DataMiner_Cube#options). |
  | ShowSettingsPanel= | Available from DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!--RN 45947-->. Determines whether the settings panel is shown when the component is initialized.<br>- `ShowSettingsPanel=True`: The settings panel is shown.<br>- `ShowSettingsPanel=False`: The settings panel is hidden.<br>If this option is not specified, the settings panel is shown using its last saved state. |
  | ShowInfoPanel= | Available from DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!--RN 45947-->. Determines whether the information panel is shown the component is initialized.<br>- `ShowInfoPanel=True`: The info panel is shown.<br>- `ShowInfoPanel=False`: The info panel is hidden.<br>If this option is not specified, the visibility of the information panel is determined by the ribbon setting. |
  | ShowRibbon= | Available from DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!--RN 45725-->. Determines whether the ribbon is displayed in the Spectrum Analysis component.<br>- `ShowRibbon=true`: The ribbon is shown.<br>- `ShowRibbon=false`: The ribbon is hidden.<br>In existing shapes, this option cannot be toggled dynamically. |
  | SaveLastSessionPreset= | Available from DataMiner 10.5.0 [CU8]/10.6.0 [CU6]/10.6.9 onwards<!--RN 46106-->. Controls whether the last session preset is saved when the shape is initialized.<br>- `SaveLastSessionPreset=True`: The last session preset is saved (default behavior).<br>- `SaveLastSessionPreset=False`: The last session preset is not saved. |

> [!NOTE]
>
> - These options all support dynamic placeholders. Dynamic changes to the preset or measurement points will be applied immediately. Dynamic changes to view options will only be applied when a preset is loaded.
> - Only public presets can be used in a Visual Overview, not private presets.
> - The `ShowSettingsPanel=`, `ShowInfoPanel=`, `ShowRibbon=`, and `SaveLastSessionPreset=` options are only applied when the shape is initialized and cannot be toggled dynamically.

For example:

| Shape data field | Value                                                              |
|------------------|--------------------------------------------------------------------|
| Component        | Spectrum                                                           |
| Element          | 111/333                                                            |
| ComponentOptions | Preset=\[var:PresetVar\]\|ShowRibbon=true\|Measpts=\[var:measpts\] |
