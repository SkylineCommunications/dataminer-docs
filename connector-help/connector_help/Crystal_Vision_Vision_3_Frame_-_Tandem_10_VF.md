---
uid: Connector_help_Crystal_Vision_Vision_3_Frame_-_Tandem_10_VF
---

# Crystal Vision Vision 3 Frame - Tandem 10 VF

This **exported connector** shows data from a TANDEM10-VF module in a Crystal Vision Vision 3 Frame.

TANDEM10-VF provides a solution for audio embedding and de-embedding for use with Vision rack frames from Crystal Vision.
It has a single SDI video path with a de-embedder and an embedder, which allow the extraction and insertion of up to 16 channels (four groups) of audio.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2.0                  |

## Configuration

This SNMP connector is used by DVE child elements that are **automatically created** by the parent connector [Crystal Vision Vision 3 Frame](xref:Connector_help_Crystal_Vision_Vision_3_Frame).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

- **General:** Displays status information related to the DVE, as well as information about video, sub PCB type and audio.

- **Video**: Allows you to configure video parameters related to delay and output, RGB processing (including color gain and lift), YUV processing, VANC blank enabling and fiber input.

- **Audio:**

- Contains the **DeEmbedded Input Table** and **Discrete Inputs Table**, which allow you to enable or disable parameters like **Invert**, **Dolby** or **ReSample** for each audio group or discrete input.
  - Contains the **Delays Table** for de-embedded inputs and discrete inputs, where you can enable parameters such as **Frame Delay** and **User Delay**.
  - Allows you to configure **PCM Audio Delay** and **AES Inputs/Outputs**.
  - The **Audio** **Gains** subpage allows you to configure gains for de-embedded inputs and for discrete inputs.

- **Audio Router**:

- Allows you to enable the outputs for the different audio groups and configure the embedder mode.
  - The **Mutes** subpage allows to mute each of the embedded channels and AES outputs individually.

- **Presets Default Alarms:**

- Allows you to select, store and recall presets, or return to a default preset.
  - Allows you to configure **alarm delays** for Video Black, Video Frozen, Audio Silence and Audio Silence Level.
