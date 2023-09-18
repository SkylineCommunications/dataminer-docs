---
uid: Connector_help_Tandberg_RX_6way
---

# Tandberg RX 6way

The **Tandberg RX 6way** diversity receiver is designed to process COFDM RF signals from the same source transmitter and then combine them into a simple recovered flow that can feed its internal demodulator.

The RF signals from the antennas are mixed down with downconverters to a single UHF frequency in the range of 70 to 890 Mhz. The converted signal is fed to an internal demodulator that provides an optimum regeneration of the received signal to achieve a maximum number of MPEG packages.

## About

The remote management is possible through its internal serial interface that implements a predefined protocol structure, allowing an acceptable level of monitoring functions, including the reporting of measurement points for a spectrum type graph.

The connector implements most of the monitoring functions available in the protocol as well as a set of control parameters.

## Installation and configuration

### Creation

Follow the standard procedure for serial devices. The serial interface can normally be reached through a terminal server device (i.e. Moxa equipment). The IP address and port are defined directly by the configuration of the terminal server, while the bus address is defined directly on the RX 6way receiver.

**SERIAL CONNECTION:**

- **IP address/IP Port**: Defined by the configuration of the terminal server.
- **Bus Address**: Defined on the configuration of the RX 6way Receiver. The default value is *01*.

### Configuration

Configuration for spectrum images:

- Make sure to have created a new subfolder called *SpectrumThumbnail* under the path *C:\Skyline DataMiner\Webpages\\*
- To that folder, copy the template image file *Grid.jpg,* which should be available as part of the protocol folder in Source Safe.

## Usage

Once created, the element can be used immediately. There are four pages available.

### General

This page contains general information such as SW version, number of receivers, modulation type, tuned frequency, and Channel. There is also a button to issue a reset command to the device

### MPEG Status

This page contains MPEG-related parameters like lock condition, TS Lock indicator, Sync Lock, MPEG receiver, MPEG Protection and MPEG Div.

### Performance

This page contains the result of performance parameters for BER, MER and the RSSI and C/N for all six-receiver channels.

### Spectrum

This page contains the controls of the spectrum graph generation. The spectrum graph generation is a function (QAction) that, based on the periodically retrieved measurement points, generates a single JPG image representing the last spectrum graph.

The following control parameters are available:

- **Retrieve Spectrum:** Enables or disables the retrieval of the performance points as well as the generation of the resulting spectrum image.
- **Spectrum Antenna:** Defines the channel (1 up to 6) for which the performance points will be retrieved. The resulting spectrum image will contain an indication of the selected channel.

## Notes about the spectrum image

This connector version was coded with the following assumptions:

- The resulting directory of the JPG image is *C:\Skyline DataMiner\Webpages\SpectrumThumbnail\\* It might therefore be necessary to create that folder beforehand, as stated in the **Configuration** section of this help page.
- In the above directory, a file called *Grid.jpg* must exist, as this is the image template (the general aspect of the resulting spectrum image). As explained above, a sample of that image can be available as part of the protocol files in Source Safe.
- The resulting JPG image has a name format *spec\_\<id\>.jpg* where \<id\> corresponds to the element ID. As such, each element on the same DMA will have its own resulting spectrum image.

The image template is nothing more than a base image that the QAction uses to render the resulting graph, the frequency tuned and the configured channel. This file (*Grid.jpg)* can be changed (i.e. change the background color) but the code in the QAction assumes certain dimensions in order to correctly position the rendered part of the spectrum.

The resulting JPG image can be presented on protocol view, by using Generic Image thumbnail. A sample of this view can also be found in the protocol folder in Source Safe.
