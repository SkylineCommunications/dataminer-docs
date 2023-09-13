---
uid: Connector_help_Axon_ACP
---

# Axon ACP

The **Axon ACP** connector can be used to poll and configure the data for different types of Axon frames and the attached card types located in their different slots.

## About

Depending on the range, one or more connections are used to retrieve and configure the data for the supported **frame** and its inserted **cards**.

This connector will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors".

Depending on the used configuration within the connector related to the DataMiner DVE setup, a DVE child element will or will not be created for the corresponding device type.

### Version Info

| **Range**            | **Description**                   | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------|---------------------|-------------------------|
| 1.0.1.x              | Branch version                    | No                  | Yes                     |
| 1.0.2.x              | Change in export rules            | Yes                 | Yes                     |
| 1.0.3.x \[SLC Main\] | Change in discrete display values | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware**                                                                                       |
|-----------|--------------------------------------------------------------------------------------------------------------|
| 1.0.1.x   | **ERS118**: 0801, 0901, 1001, 1801, 1901 **RRS08**: 1801, 3400, 3600 **RRS18**: 1801, 3400, 3600             |
| 1.0.2.x   | **ERS118:** 0801, 0901, 1001, 1801, 1901, 2001 **RRS08:** 1801, 3400, 3600 **RRS18:** 1801, 3100, 3400, 3600 |
| 1.0.3.x   | **ERS118:** 0801, 0901, 1001, 1801, 1901, 2001 **RRS08:** 1801, 3400, 3600 **RRS18:** 1801, 3100, 3400, 3600 |

### Exported Connectors

For a list of the supported firmware versions within the specific connector ranges of each exported connector and the corresponding DataMiner Connectivity Framework information for each connector range, refer to the help page for the exported connector.

| **Exported Connector**                                           | **Description**                                                                                                                               | **Range**       | **DCF Integration** |
|------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|-----------------|---------------------|
| [Axon ACP - 2GF100](xref:Connector_help_Axon_ACP_-_2GF100) | Dual-channel 3 Gb/s, HD and SD frame synchronizer with optional audio shuffler.                                                               | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - 2GU100](xref:Connector_help_Axon_ACP_-_2GU100) | Dual-channel 3 Gb/s, HD up-converter with color corrector and optional cross input audio shuffler.                                            | 1.0.3.x         | Yes                 |
| [Axon ACP - 2GU110](xref:Connector_help_Axon_ACP_-_2GU110) | Dual-channel 3 Gb/s, HD up-converter with color corrector and optional cross input audio shuffler.                                            | 1.0.3.x         | Yes                 |
| [Axon ACP - 2HF100](xref:Connector_help_Axon_ACP_-_2HF100) | Dual-channel 3 Gb/s, HD and SD frame synchronizer with optional audio shuffler.                                                               | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - 2HX10](xref:Connector_help_Axon_ACP_-_2HX10)   | Dual-channel HD/SDI integrity checking probe with clean switchover function, preview output and wings or split-screen creation capabilities.  | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - 2IX09](xref:Connector_help_Axon_ACP_-_2IX09)   | Dual-channel (enhanced) integrity checking probe with switchover function and frame synchronizer.                                             | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - 2IX10](xref:Connector_help_Axon_ACP_-_2IX10)   | Dual-channel (enhanced) integrity checking probe with switchover function and frame synchronizer.                                             | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - AAD08](xref:Connector_help_Axon_ACP_-_AAD08)   | Dual-channel 1-to-8 analog distribution amplifier.                                                                                            | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - ADP10](xref:Connector_help_Axon_ACP_-_ADP10)   | SDI embedded audio description processor.                                                                                                     | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - ADP24](xref:Connector_help_Axon_ACP_-_ADP24)   | Audio description and voiceover card.                                                                                                         | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - ARC20](xref:Connector_help_Axon_ACP_-_ARC20)   | Broadcast quality bi-directional aspect ratio converter.                                                                                      | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - CDV07](xref:Connector_help_Axon_ACP_-_CDV07)   | Analog video distribution amplifier(s).                                                                                                       | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - CDV08](xref:Connector_help_Axon_ACP_-_CDV08)   | Analog video distribution amplifier(s).                                                                                                       | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - CDV09](xref:Connector_help_Axon_ACP_-_CDV09)   | Analog video distribution amplifier(s).                                                                                                       | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - CDV29](xref:Connector_help_Axon_ACP_-_CDV29)   | Reference distribution amplifier(s).                                                                                                          | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - DAW88](xref:Connector_help_Axon_ACP_-_DAW88)   | AES/EBU audio watermark engine based on Civolution encryption technology.                                                                     | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - DBD18](xref:Connector_help_Axon_ACP_-_DBD18)   | Quad-speed Dolby-E decoder.                                                                                                                   | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - DBD28](xref:Connector_help_Axon_ACP_-_DBD28)   | Multi-format Dolby stream decoder with quad-speed audio bus and voice-over module.                                                            | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - DBE08](xref:Connector_help_Axon_ACP_-_DBE08)   | Dolby-E encoder.                                                                                                                              | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - DDE51C](xref:Connector_help_Axon_ACP_-_DDE51C) | Dolby Digital pro encoder.                                                                                                                    | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - DDP84](xref:Connector_help_Axon_ACP_-_DDP84)   | Multi-stream Dolby Digital (+) encoder with Dolby-E decoder.                                                                                  | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - DDP94](xref:Connector_help_Axon_ACP_-_DDP94)   | Quad-speed multi-channel Dolby Digital (+), Dolby HE-AAC 5.1 and Dolby Pulse 2.0 encoder with Dolby-E decoder.                                | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - DLA42](xref:Connector_help_Axon_ACP_-_DLA42)   | 8-channel (5.1/2.0) digital audio loudness control and upmixer/downmixer unit based on Linear Acoustic algorithms.                            | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - DSF66](xref:Connector_help_Axon_ACP_-_DSF66)   | Dual digital audio upmixer and downmixer based on Sound Field algorithms.                                                                     | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - GDB400](xref:Connector_help_Axon_ACP_-_GDB400) | 3 Gb/s, HD, SD 4-, 8- or 16-channel audio de-embedder.                                                                                        | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GDB990](xref:Connector_help_Axon_ACP_-_GDB990) | 3 Gb/s, HD, SD 4-, 8- or 16-channel audio de-embedder with "Twins" dual-channel function.                                                     | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GDR26](xref:Connector_help_Axon_ACP_-_GDR26)   | Dual-input 3 Gb/s distribution amplifier with 3 reclocked outputs per channel (2 x 1 to 3 amplifier).                                         | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GDR108](xref:Connector_help_Axon_ACP_-_GDR108) | 3 Gb/s, HD, SD 1-to-8 distribution amplifier with reclocked outputs (ASI/DVB compatible).                                                     | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GDR216](xref:Connector_help_Axon_ACP_-_GDR216) | 3 Gb/s, HD and SD dual-input distribution amplifier with 8 reclocked outputs per channel (ASI/DVB compatible).                                | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GDR416](xref:Connector_help_Axon_ACP_-_GDR416) | 4K, 3 Gb/s, HD and SD 4 input distribution amplifier with 4 reclocked outputs per channel.                                                    | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GDS110](xref:Connector_help_Axon_ACP_-_GDS110) | 3 Gb/s, HD and SD down-converter and synchronizer with optional audio shuffler.                                                               | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GEB800](xref:Connector_help_Axon_ACP_-_GEB800) | 3 Gb/s, HD, SD 4-, 8- or 16-channel basic audio embedder.                                                                                     | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GED100](xref:Connector_help_Axon_ACP_-_GED100) | 3 Gb/s, HD, SD embedded domain Dolby-E to Dolby Digital (+) transcoder with audio shuffler.                                                   | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GEP100](xref:Connector_help_Axon_ACP_-_GEP100) | 3 Gb/s, HD, SD embedded Dolby-E to PCM decoder with audio shuffler.                                                                           | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GFS010](xref:Connector_help_Axon_ACP_-_GFS010) | 3 Gb/s, HD, SD basic frame synchronizer.                                                                                                      | 1.0.3.x         | Yes                 |
| [Axon ACP - GFS100](xref:Connector_help_Axon_ACP_-_GFS100) | 3 Gb/s, HD and SD frame synchronizer with optional audio shuffler.                                                                            | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GFS110](xref:Connector_help_Axon_ACP_-_GFS110) | 3Gb/s, HD and SD frame synchronizer with optional audio shuffler.                                                                             | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GFT80](xref:Connector_help_Axon_ACP_-_GFT80)   | 3 Gb/s, HD and SD 8-channel electrical-to-optical converter with full fiber diagnostics and hot-swappable fiber modules (ASI/DVB compatible). | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GIX110](xref:Connector_help_Axon_ACP_-_GIX110) | Dual-channel 3 Gb/s, HD, SD integrity checking probe with optional clean audio (2 x 1) switchover function.                                   | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GNS600](xref:Connector_help_Axon_ACP_-_GNS600) | SCTE104 VANC inserter and Ethernet data-bridge for 3 Gb/s, HD and SD SDI Inputs                                                               | 1.0.3.x         | Yes                 |
| [Axon ACP - GPD100](xref:Connector_help_Axon_ACP_-_GPD100) | 3 Gb/s, HD, SD embedded domain PCM to Dolby Digital (+) encoder with audio shuffler.                                                          | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GPI16](xref:Connector_help_Axon_ACP_-_GPI16)   | Universal GPI card with 10 GPI inputs and 16 GPI outputs.                                                                                     | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GRB100](xref:Connector_help_Axon_ACP_-_GRB100) | 3 Gb/s, HD, SD dual SDI in embedded domain shuffler and re-embedder with S2020 metadata insertion.                                            | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GRB990](xref:Connector_help_Axon_ACP_-_GRB990) | 3 Gb/s, HD, SD audio de-embedder, re-embedder, embedded domain shuffler with S2020 metadata insertion.                                        | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GXG010](xref:Connector_help_Axon_ACP_-_GXG010) | 3 Gb/s, HD and SD basic up-/down-/cross-converter and synchronizer.                                                                           | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GXG110](xref:Connector_help_Axon_ACP_-_GXG110) | 3 Gb/s, HD and SD up-/down-/cross-converter and synchronizer with optional audio shuffler.                                                    | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - GXG410](xref:Connector_help_Axon_ACP_-_GXG410) | 3 Gb/s, HD and SD up-/down-/cross-converter and synchronizer with optional audio shuffler.                                                    | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - HAS20](xref:Connector_help_Axon_ACP_-_HAS20)   | 8-channel preset-based audio shuffler with 4 local AES/EBU inputs.                                                                            | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HDB20](xref:Connector_help_Axon_ACP_-_HDB20)   | HD/SD-SDI audio de-embedder.                                                                                                                  | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HDE10](xref:Connector_help_Axon_ACP_-_HDE10)   | HD/SD Dolby-E embedder (master card).                                                                                                         | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HDR07](xref:Connector_help_Axon_ACP_-_HDR07)   | Re-clocking HD-SDI distribution amplifiers.                                                                                                   | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HDR09](xref:Connector_help_Axon_ACP_-_HDR09)   | HD-SDI dual-reclocking distribution amplifier (2 x 1 to 3 amplifier).                                                                         | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HDS05](xref:Connector_help_Axon_ACP_-_HDS05)   | HD to SD down-converter with frame synchronizer.                                                                                              | 1.0.x.x         | No                  |
| [Axon ACP - HDS10](xref:Connector_help_Axon_ACP_-_HDS10)   | HD to SD down-converter with frame synchronizer.                                                                                              | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HDS110](xref:Connector_help_Axon_ACP_-_HDS110) | 3 Gb/s, HD, SD down-converter/synchronizer with optional audio shuffler.                                                                      | 1.0.3.x         | No                  |
| [Axon ACP - HEB440](xref:Connector_help_Axon_ACP_-_HEB440) | 3 Gb/s, HD, SD 4-, 8- or 16-channel basic audio embedder.                                                                                     | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - HES20](xref:Connector_help_Axon_ACP_-_HES20)   | Dolby-E aligner and frame synchronizer.                                                                                                       | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HFS010](xref:Connector_help_Axon_ACP_-_HFS010) | 3 Gb/s, HD, SD basic frame synchronizer.                                                                                                      | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HFS100](xref:Connector_help_Axon_ACP_-_HFS100) | 3 Gb/s, HD and SD frame synchronizer with optional audio shuffler.                                                                            | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HLD120](xref:Connector_help_Axon_ACP_-_HLD120) | Solid State Drive-based HD, SD SDI long time delay unit with optional bug inserter.                                                           | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - HLI20](xref:Connector_help_Axon_ACP_-_HLI20)   | HD/SD dual logo inserter.                                                                                                                     | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HNS400](xref:Connector_help_Axon_ACP_-_HNS400) | VBI/VANC line inserter/swapper (data bridge) for composite, HD and SD SDI inputs.                                                             | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HPD100](xref:Connector_help_Axon_ACP_-_HPD100) | 3 Gb/s, HD, SD embedded domain PCM to Dolby Digital (+) encoder with audio shuffler.                                                          | 1.0.3.x         | No                  |
| [Axon ACP - HRB100](xref:Connector_help_Axon_ACP_-_HRB100) | 3 Gb/s, HD, SD dual SDI in embedded domain shuffler and re-embedder with S2020 metadata insertion.                                            | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - HRB990](xref:Connector_help_Axon_ACP_-_HRB990) | 3 Gb/s, HD, SD digital or analog audio de-embedder, re-embedder, embedded domain shuffler.                                                    | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - HSI10](xref:Connector_help_Axon_ACP_-_HSI10)   | HD/SD SDI universal databridge with monitoring outputs.                                                                                       | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HSI12](xref:Connector_help_Axon_ACP_-_HSI12)   | X31 cue encoder/decoder.                                                                                                                      | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HSU10](xref:Connector_help_Axon_ACP_-_HSU10)   | High-definition up-converter with color corrector.                                                                                            | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HVD10](xref:Connector_help_Axon_ACP_-_HVD10)   | HD/SD video delay (32 frames).                                                                                                                | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HXH40](xref:Connector_help_Axon_ACP_-_HXH40)   | High-performance HD up-/down-/cross-/standards converters.                                                                                    | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - HXH41](xref:Connector_help_Axon_ACP_-_HXH41)   | High-performance HD up-/down-/cross-/standards converter.                                                                                     | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - HXT100](xref:Connector_help_Axon_ACP_-_HXT100) | Dual 3 Gb/s, HD and SD input, frame synchronizer, up-/down-/cross-converter, embedder and de-embedder.                                        | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - SDN08](xref:Connector_help_Axon_ACP_-_SDN08)   | Non-reclocking SDI distribution amplifiers.                                                                                                   | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - SDR07](xref:Connector_help_Axon_ACP_-_SDR07)   | Triple SDI reclocking 1 to 2 distribution amplifier.                                                                                          | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - SDR08](xref:Connector_help_Axon_ACP_-_SDR08)   | Reclocking SDI distribution amplifiers.                                                                                                       | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - SDR09](xref:Connector_help_Axon_ACP_-_SDR09)   | Reclocking SDI distribution amplifiers.                                                                                                       | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - SLD120](xref:Connector_help_Axon_ACP_-_SLD120) | Solid State Drive based long time delay unit with optional second output and bug inserter.                                                    | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - SVD10](xref:Connector_help_Axon_ACP_-_SVD10)   | SDI frame synchronizer with extended (24 frames) video offset delay.                                                                          | 1.0.2.x 1.0.3.x | Yes Yes             |
| [Axon ACP - U4D100](xref:Connector_help_Axon_ACP_-_U4D100) | 4K Ultra HD 4 wire to 1080p down-converter.                                                                                                   | 1.0.2.x 1.0.3.x | No No               |
| [Axon ACP - U4T100](xref:Connector_help_Axon_ACP_-_U4T100) | 4K Ultra HD 4 wire toolbox with optional Dolby-E processing.                                                                                  | 1.0.2.x 1.0.3.x | No Yes              |
| [Axon ACP - U4T140](xref:Connector_help_Axon_ACP_-_U4T140) | 4K Ultra HD 4 wire toolbox with optional Dolby-E processing.                                                                                  | 1.0.2.x 1.0.3.x | No Yes              |

## Configuration

### Connections

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td><p>1.0.1.x 1.0.2.x 1.0.3.x</p></td>
<td><h4 id="serial-main-connection">Serial Main connection</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: Does not need to be configured. By default, this is set as the fixed <strong>2071</strong> IP port.</li>
</ul></li>
</ul>
<h4 id="serial-broadcast-connection">Serial Broadcast connection</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: Has to be configured as the fixed value '<strong>any</strong>'.</li>
<li><strong>IP port</strong>: Does not need to be configured. By default, this is set as the fixed <strong>2071</strong> IP port.</li>
</ul></li>
</ul></td>
</tr>
</tbody>
</table>

## Usage (1.0.1.x, 1.0.2.x, 1.0.3.x)

### Overview

The **Overview** table provides an overview of the device configuration. More specifically, it indicates which device type and firmware is inserted in which slot of the frame.
For each detected device, you can change the following settings:

- **Refresh:** Refresh all data for the device type inserted in the corresponding slot, depending on the firmware.
- **DVE Name:** If you change the DVE Name, the name of any corresponding child element will be changed. However, if there already is a DataMiner element that uses the inserted value, the configuration will not be executed.
- **DVE View:** If you change the DVE View, the corresponding child element will be moved to the specified DataMiner view. However, if no DataMiner view can be found that corresponds to the inserted value, the configuration will not be executed.
- **DVE Export:** With this setting, you can select whether creation of a corresponding DVE is allowed, regardless of other DVE Reflection settings.

The **DVE Settings** subpage provides an overview of all the supported device types within the protocol.

### Frame

This page provides an overview of the frame's generic information, such as **Card Name**, **SW Rev.**, **HW Rev.**, **Serial Number**, etc.

On the subpages, such as **Status**, **PSU**, **FAN**, **MIB**, **Network** and **Alarm Priority**, you can find the related frame status and/or configuration parameters.

### Cards

This page provides an overview of subpages representing the supported device types within the protocol.

On each of the subpages, you can find the **DVE** and **DATA** tables for the device types of that specific subpage.

## DVE Reflection

DVE Reflection determines how the DVE setup in DataMiner mirrors the actual device setup.

In some cases, inconsistencies between the device setup and the DataMiner DVE setup can occur.
For example, when a card is removed from a frame because of a hardware malfunction, if the related DataMiner DVE child element were to be removed as well, this would result in the loss of all trend and alarm information that has been stored for that element.
However, if the child element is not removed, an inconsistency occurs between the device and the setup in DataMiner.

Situations like this, where potential inconsistencies occur between the device setup and the DVE setup, are handled by DVE Reflection based on a number of settings that can be defined by the user. The section below provides an overview of these settings and of the DVE Reflection logic.

#### Device Overview

The **Overview** table provides an overview of the device configuration and displays the **Reflect Status** that results from the DVE Reflection algorithm.

For each device, you can select whether creation of a corresponding DVE is allowed, regardless of other settings.

The **Reflect Status** for each device can be the following:

- **Ok:** The DataMiner setup reflects the device setup.
- **Detected:** The corresponding device type is not supported in the protocol.
- **Changed:** The device type has been changed since the last polling.
- **Removed:** The device has been removed since the last polling.
- **Error:** It is not possible to create the corresponding DVE.

#### DVE Configuration Modes

Depending on the selected mode and on the other configuration settings, the DVE Reflection algorithm will have a different result.

Three modes are available:

- **Manual (default):**

  - When a new device is added, the corresponding DVE will be created if the configuration settings allow it.

  - When a device is replaced by a device of a different type:

    - The existing DVE will be deleted if the configuration settings allow it.
    - A new DVE will be created if the configuration settings allow it.

  - When a device is removed, the existing DVE will not be deleted.

- **Semi-Automatic:**

  - When a new device is added, the corresponding DVE will be created if the configuration settings allow it.

  - When a device is replaced by a device of a different type:

    - The existing DVE will be deleted.
    - A new DVE will be created if the configuration settings allow it.

  - When a device is removed, the existing DVE will not be deleted.

- **Automatic:**

  - When a new device is added, the corresponding DVE will be created if the configuration settings allow it.

  - When a device is replaced by a device of a different type:

    - The existing DVE will be deleted.
    - A new DVE will be created if the configuration settings allow it.

  - When a device is removed, the existing DVE will be deleted.

#### DVE Export Settings

The protocol contains a table with an overview of all the supported device types.

By changing the **State** for a specific device type, you can determine whether a DVE can be created for this device type.

- **On (default):** DVE creation is allowed for this device type.
- **Off:** DVE creation is not allowed for this device type.
- **NA:** The setting cannot be changed, as it is embedded in the core logic of the protocol. This can for instance be because the device type is supported in the protocol, but not implemented as a DVE protocol.

#### Reflect (All)

After the configuration of the device is initiated via polling, the DVE Reflection algorithm is run.

However, if changes have been implemented, you may want to run the DVE Reflection algorithm again without waiting for the timer that controls polling.
In that case, by using the **Reflect** or **Reflect All** buttons, you can run the DVE Reflection algorithm for one device or for all detected devices, respectively.
