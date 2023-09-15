---
uid: Connector_help_Ateme_KFE
---

# Ateme KFE

With this connector, you can gather and view information from the multi-codec/multi-format file-based video transcoding software **Ateme KFE.** This software supports distributed-network configurations. Different modules run on different hosts and are controlled by the Supervisor Engine.

## About

This is an HTTP REST protocol that is used to monitor the **Ateme KFE** video transcoding software.

## Installation and configuration

### Creation

**HTTP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.64.31.16.*
- **Bus Address**: Default value is *byPassProxy.*

## Usage

### Overview page

This page displays a tree control with an overview of the configured jobs in the servers.

### General page

This page displays general information about the software.

### Presets page

This page displays the currently available presets on the software. The preset usually describes several media tracks (audio, video and data) and how they are multiplexed together.

### Jobs page

This page displays all available jobs. The job file indicates the files that are used as sources and includes an encoding preset that contains the configuration for pre-processing, encoding, and multiplexing.

### Segments pages

There are three **Segments** pages:

- **Segments**: Displays all available segments. A segment can be composed of a video, a set of audio and a set of data. Trimming is possible inside each segment, as well as cropping and adding a logo.
- **Segments - Audio**: Displays the audio information of the segments.
- **Segments - Video**: Displays the video information of the segments.

### Audio Tracks page

This page displays the audio tracks.

### Video Tracks pages

There are six **Video Tracks** pages:

- **Video Tracks**: Displays the video tracks.
- **Video Tracks - Input**: Displays information about the video track inputs.
- **Video Tracks - Logo**: Displays the logo information about video tracks.
- **Video Tracks - Crop**: Displays the crop information about video tracks.
- **Video Tracks - Prefs**: Displays the video track preferences.
- **Video Tracks - AVC**: Displays the AVC information of video tracks.

### Probe Segments pages

There are three **Probe Segments** pages:

- **Probe Segments**: Displays the probe segments.
- **Probe Segments - Audio**: Displays the audio information of the probe segments.
- **Probe Segments - Video**: Displays the video information of the segments.

### Muxer

This page displays information about the muxer parameters.

### Output

This page displays the output information of the jobs.
