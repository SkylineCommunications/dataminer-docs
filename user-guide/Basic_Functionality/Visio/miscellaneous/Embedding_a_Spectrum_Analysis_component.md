---
uid: Embedding_a_Spectrum_Analysis_component
---

# Embedding a Spectrum Analysis component

From DataMiner 9.5.11 onwards, it is possible to embed a Spectrum Analysis component in Visio.

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

> [!NOTE]
>
> - These options all support dynamic placeholders. Dynamic changes to the preset or measurement points will be applied immediately. Dynamic changes to view options will only be applied when a preset is loaded.
> - Only public presets can be used in a Visual Overview, not private presets. In addition, up to DataMiner 9.6.1, the preset must have either the “(public)” suffix or “GLOBAL:” prefix.

For example:

| Shape data field | Value                                                              |
|------------------|--------------------------------------------------------------------|
| Component        | Spectrum                                                           |
| Element          | 111/333                                                            |
| ComponentOptions | Preset=\[var:PresetVar\]\|ShowRibbon=true\|Measpts=\[var:measpts\] |
