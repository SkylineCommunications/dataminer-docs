---
uid: Connector_help_Evertz_HD2020-3G_Video_Passport
---

# Evertz HD2020-3G Video PassPort

The Evertz HD2020-3G Video PassPort is a high-performance 1RU video conversion and frame synchronization platform. The HD2020 integrates four paths of up-/down-/cross-conversion with a wide range of video/audio input/outputs.

## About

This protocol uses an **SNMP** connection to monitor and configure the Evertz 2020-3G Video PassPort device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | hd2020_3g-20101029-1104     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains system parameters, as well as the following page buttons:

- **Analog Video:** Displays three configurable parameters that can also be found on the Analog Video tab of the device's web interface.
- **Reference:** Allows you to configure the Reference Mode and Format parameters.

### Audio Delay

This page contains the **Audio Delay Info** and **AES SRC Control** tables.

### Embedder/De-embedder

This page contains the **Mux Info**, **Embedder Info** and **De-embedder Info** tables, which allow you to configure each clean switch output mux, each of the 32 channels for both embedders, and each channel pair for all 8 de-embedders.

### DVI

This page contains DVI format parameters, as well as the **DVI Output Info** table, which allows you to configure the window labels.

### Converter/Scaler

This page contains various converter-related tables:

- **Video I/O Info**: Contains various configurable columns related to video input/output, including the standards, the read/write select and the FS Bypass.
- **Video Processing Configuration**: Contains columns related to video processing, including gains, offsets and gamma control.
  Note: **Gains/Offsets do not have units** because that is how they are presented in VistaLink.
- **Audio Monitor Info**: Contains status information for the Audio Monitor.
- **Caption Configuration**: Contains various caption controls, such as the service controls and the CC timeout.
- **Timing Configuration**: Contains 3 timing controls: the reference and both the vertical and horizontal offsets.
- **De-interlacer Configuration**: Contains 3 de-interlacer controls: Type, IFMD Mode and Film Detection Mode.
- **Noise Reduction Info**: Contains the noise reduction General Level controls for each converter path.
- **AFD Configuration**: Contains AFD configuration columns for each converter, including the Stamp Source, SD Aspect Ratio, output enabling and more.
- **Video Monitor Info**: Contains video monitor-related controls.
  Note: These column values (apart from the video delay) are received by the DMA as hex, and have to be converted to their ASCII equivalents.

Note: Each row in all of these tables is linked to 1 of the 4 paths, a path being synonymous with the converter \# in the VistaLink.

The page also contains one page button, **Scaler Config**, which provides access to the Scaler Configuration table. This table includes various controls related to the stop/start of the horizontal and vertical slew limits and panel configuration.

### Clean Switch

This page contains the Clean Switch Input and Output Configuration tables, as well as the Source ID control and the Test Gen controls.

### Output Bus

This page contains both Output Bus and Output Connection tables.

### CVBS In

This page contains various parameter controls related to composite video input, including black/white clip levels, chroma levels, hue controls, and more.

It also includes the **Blanking Controls** page button, which provides access to the blanking control configuration for each field pair for lines 10-23.

### CVBS Out

This page contains various parameter controls related to composite video output, including the brightness, contrast, saturation and more.

### Web Interface

The web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
