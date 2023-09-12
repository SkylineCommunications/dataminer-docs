---
uid: Connector_help_Harmonic_Spectrum_X
---

# Harmonic Spectrum X

The Spectrum X combines file, baseband and transport stream ingest with comprehensive integrated channel playout capabilities including graphics, branding and DVE.

The Harmonic Spectrum X driver is used to configure and monitor Harmonic products that support the **Oxtel** protocol.

## About

### Version Info

| **Range**            | **Key Features**                                                         | **Based on** | **System Impact**                                                |
|----------------------|--------------------------------------------------------------------------|--------------|------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                         | \-           | \-                                                               |
| 1.0.1.x \[SLC Main\] | Serial connection changed to smart-serial connection to support tallies. | 1.0.0.1      | Existing elements must be reconfigured to adjust the connection. |

### Product Info

| **Range** | **Supported Firmware**        |
|-----------|-------------------------------|
| 1.0.0.x   | 1.18 (Oxtel protocol version) |
| 1.0.1.x   | 1.18 (Oxtel protocol version) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

To set some of the parameters, you need to set other parameters first (some are mandatory and others are optional). This means that you must fill in the required parameters first before attempting to set the other parameters. You can find more information about this below.

On the **Graphic Layers** page:

- Before you set the **Fade Keyer**, fill in the **Keyer Rate**; otherwise, the **Transition Duration** value will be used as the rate value.
- Before you set the **Template Animation** to **Stop**, set the **Stop Flag**.
- Before you set the **Text Field String** and **Preloaded Text Field String**, set the **Text Field Number** and **Text Flag** fields.
- Before you update the text field using the **Update** button of the **Render Box** column, fill in the **Text Field Number** and set the Text Field String.
- Before you change the text field image file name in the **Text Field Image Filename** column, fill in the **Text Field Number**.
- Before you apply the **Stop, Restart** or **Pause** animation for the text field, fill in the **Text Field Number**. In addition, you also need to set the **Stop Flag** before you apply the **Stop** animation action.
- If the **Keyer Direction** and **Loaded Image** columns are *Not Initialized* or do not have updated data, **disabling** and then **enabling the** **Video Tally State** parameter will update the columns. This is because when the tally is enabled, the device will send this information.
- If the **Play State** column is *Not Initialized* or does not have updated data, **disabling** and then **enabling the** **Play** **State** **Tally** parameter will update the column. This is because when the tally is enabled, the device will send this information.

On the **A/B Mixer** page:

- Before you apply the fade actions using the **Fade to A**, **Fade to B** and **Fade AB** buttons and setting **Fade Destination**, fill in the **Fade Duration**.
- Before you apply the asymmetric V-fade action using the **V-Fade AB** button and setting the **Transition Destination**, fill in the **Down Duration** and **Up Duration**.
- When you set the **Video Source A** and **Video Source B**, you can include an optional ARC parameter by setting **Include ARC** to Yes and specifying the **ARC** value.

On the **Audio** page:

- Before you try to set the Audio Loudness parameters, select the **SDI Source** and the **Audio Channel**. In addition, before you set the **Audio Program**, fill in the **Junger Preset** and vice versa.
