---
uid: Connector_help_Adtec_RD-71
---

# Adtec RD-71

Adtec Digital's RD-71 is an SD, HD and 1080P59.94/50 IRD supporting MPEG-2 and MPEG-4 AVC/H.264, multi-CHROMA 4:2:0/4:2:2 and 10-bit. With support for very low latency decoding, an array of IP transport capabilities and DVB-S2X demodulation, the RD-71 is both versatile and reliable.

## About

This connector was designed for use with the device **Adtec RD-71**. The connector retrieves and sets information from/on the device via SNMP. To support profiles, the connector uses a serial connection (Telnet).

### Version Info

| **Range**                        | **Description**                                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|-----------------------------------------|----------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x (Obsolete)                      | Initial version.                                                                                                                 | No                  | Yes                     |
| 1.0.1.x (Obsolete)                      | Added DVE support to the connector.                                                                                                 | No                  | Yes                     |
| 1.0.2.x (Obsolete)                      | Applied conditional pages instead of DVEs.                                                                                       | No                  | Yes                     |
| 1.0.3.x (based on 1.0.2.x)              | Fixed PK duplicate issue in the 2050 table.                                                                                      | No                  | Yes                     |
| 1.0.4.x (based on 1.0.3.2)              | Added support for profiles by adding a new serial connection (Telnet). For more information, refer to the "Notes" section below. | No                  | Yes                     |
| 1.1.0.1 (based on 1.0.3.2) \[SLC Main\] | Compatible with new firmware 2.02.21 and higher. Added reset/reboot buttons.                                                     | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | v 2.02.06                   |
| 1.0.1.x          | v 2.02.11                   |
| 1.0.2.x          | v 2.02.11                   |
| 1.0.3.x          | v 2.02.11                   |
| 1.0.4.x          | v 2.02.11                   |
| 1.1.0.x          | v 2.02.21                   |

### Exported connectors (only in range 1.0.1.x)

| **Exported Connector**                                            | **Description**                                  |
|------------------------------------------------------------------|--------------------------------------------------|
| [Adtec RD-71 - PRX](xref:Connector_help_Adtec_RD-71_-_PRX) | Adtec RD-71 with the PRX model demodulator board |
| [Adtec RD-71 - LB](xref:Connector_help_Adtec_RD-71_-_LB)   | Adtec RD-71 with the LB model demodulator board  |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial Connection

This connector uses a serial connection to set/retrieve profile information and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.

## Usage - 1.0.0.x

### Main View

This page contains important information about the device. The **System Up Time** is the total time the device has been up and running. **Status**, **Source**, **Source Status**, **Local Oscillator**, **Input Transmux Rate** and **Status Transmux Rate** are other important parameters displayed on this page.

### General

This page contains general information about the device, such as the **Product Type, Product Name** and **Product Version**.

You can also find the **Temperature**, **Status**, **Source**, **Source Status**, **Program**, **PCR**, **PMT**, **STC**, **Input Transmux Rate** and **Video Transmux Rate** on this page.

### IRD

This page displays the **LBN1 and LBN2 Availability**, allowing you to enable or disable power on the input connector to the power of the LNB. The **Polarity** control allows you to select LNB polarization. The **Tone** parameter can be used to route the high or low band from either polarity to the IRD.

Other parameters displayed on this page are among others:

- **Carrier Frequency Offset**
- **Manual Local Oscillator**: Allows you to manually enter the LNB frequencies provided either for C: Manual or Ku: Manual.
- **Oscillator**
- **Low Band**: Allows you to enter the L-band frequency.
- **Symbol Rate:** Displays the number of symbols transmitted per second.

### Input

This page contains information about the active inputs and demodulator parameters.

The following parameters related to the active inputs can be found on the left-hand side of the page:

- **Oscillator:** Specifies the frequency of the LNB local oscillator.
- **Manual Local Oscillator:** Allows you to enter the LNB local oscillator frequency manually, provided that either C: Manual or Ku: Manual is selected.
- **Downlink**: Allows you to enter the satellite downlink frequency.
- **Acquisition Range**
- **Low Band**: Allows you to enter the L-band frequency.

On the right-hand side, you can find the following parameters related to the demodulator:

- **Type:** Allows you to select the mod type.
- **Mode:** Allows you to select the modulation mode and FEC code rate.
- **Rolloff**
- **Frame Type**
- **Symbol Rate**
- **Pilot:** Allows you to reduce the data rate by approximately 3.0%.

### Video

This page displays the genlock status and settings. It contains parameters such as **Lock State**, **Detected Reference Format**, **Out Video Standard**, **Cross Reference**, **Decode Status**, **Number Lock Lost**, **Reference Lost**, **Video Skips**, **Video Repeats**, **Genlock Settings**, **Mode**, **Horizontal Adjust**, **Vertical Adjust**, **Pixel Phase**, **CVBS**, **OSD Mode**, **Service Lines**, **Service Blink**, **Color Bar Mode**, **Type** and **OSD Size**.

### Audio

This page contains the **Audio Table**, where you can find parameters such as **PID Input**, **Offset** (which adjusts each individual pair of audio sync) and **Current**.

### CAS

This page contains information about the **CAS Mode**, **Key String A** and **Key String B**.

### Transport Service

This page displays all the information related to the **Transport Service Table** and **Services Tables**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage - 1.0.1.x

### General

This page contains information regarding the installed demodulator board and the DVE controls.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage - 1.0.2.x/1.0.3.x/1.1.0.x

In these versions of the connector, conditional pages are used. These pages are shown or hidden depending on the device type (L-band vs. PRX). The pages are the same for these different ranges, except that in range 1.1.0.x the suffix "L-Band" was renamed to "LB".

### Main View PRX / Main View L-Band / Main View LB

This page contains important information about the device. The **System Up Time** is the total time the device has been up and running. **Status**, **Source**, **Source Status**, **Local Oscillator**, **Input Transmux Rate** and **Status Transmux Rate** are other important parameters displayed on this page.

### General PRX / General L-Band / General LB

This page contains general information about the device, such as the **Product Type, Product Name** and **Product Version**.

You can also find the **Temperature**, **Status**, **Source**, **Source Status**, **Program**, **PCR**, **PMT**, **STC**, **Input Transmux Rate** and **Video Transmux Rate** on this page.

In the 1.1.0.x range, there are also buttons to reset the separate inputs, such as **Reset RF1**, **Reset RF2**, **Reset ASI** and **Reset IP**, and a **Reboot System** button to reboot the system.

### IRD PRX / IRD L-Band / IRD LB

This page displays the following parameters:

- **Manual Local Oscillator**: Allows you to enter the LNB frequencies provided either for C: Manual or Ku: Manual.
- **Oscillator**
- **Low Band**: Allows you to enter the L-band frequency.
- **Symbol Rate:** Displays the number of symbols transmitted per second.

### Input PRX / Input L-Band / Input LB

This page contains information about the active inputs and demodulator parameters.

The following parameters related to the active inputs can be found on the left-hand side of the page:

- **Oscillator:** Specifies the frequency of the LNB local oscillator.
- **Manual Local Oscillator:** Allows you to enter the LNB local oscillator frequency manually, provided that either C: Manual or Ku: Manual is selected.
- **Downlink**: Allows you to enter the satellite downlink frequency.
- **Acquisition Range**
- **Low Band**: Allows you to enter the L-band frequency.

On the right-hand side, you can find the following parameters related to the demodulator:

- **Type:** Allows you to select the mod type.
- **Mode:** Allows you to select the modulation mode and FEC code rate.
- **Rolloff**
- **Frame Type**
- **Symbol Rate**
- **Pilot:** Allows you to reduce the data rate by approximately 3.0%.

### Video

This page displays the genlock status and settings. It contains parameters such as **Lock State**, **Detected Reference Format**, **Out Video Standard**, **Cross Reference**, **Decode Status**, **Number Lock Lost**, **Reference Lost**, **Video Skips**, **Video Repeats**, **Genlock Settings**, **Mode**, **Horizontal Adjust**, **Vertical Adjust**, **Pixel Phase**, **CVBS**, **OSD Mode**, **Service Lines**, **Service Blink**, **Color Bar Mode**, **Type** and **OSD Size**.

### Audio

This page contains the **Audio Table**, where you can find parameters such as **PID Input**, **Offset** (which adjusts each individual pair of audio sync) and **Current**.

### CAS

This page contains information about the **CAS Mode**, **Key String A** and **Key String B**.

### Transport Service

This page displays all the information related to the **Transport Service Table** and **Services Tables**.

### Network

This page displays all the information related to the **Entity IP Address Table**. It contains parameters such as **Broadcast Address** and **Net Mask**.

### Chassis

This page contains tables with information about the **Power Supply** and the **Fans**.

### Tuner Status PRX / Tuner Status L-Band / Tuner Status LB

This page contains information about the **Tuner**. It includes parameters such as **Roll-off**, **Tuner Lock** and **Spectral Inversion**.

### Sat Feed PRX / Sat Feed L-Band / Sat Feed LB

This page contains information about the **Satellite Feed**. It includes parameters such as **Downlink**, **Symbol Rate**, **ISI**, etc.

### LNB

This page displays the **LNB1 and LNB2 Availability**, allowing you to enable or disable power on the input connector to the power of the LNB. The **Polarity** control allows you to select **LNB polarization**. The **Tone** parameter can be used to route the high or low band from either polarity to the IRD.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage - 1.0.4.x

In this range, conditional pages are used. These pages are shown or hidden depending on the device type (L-band vs. PRX).

### Main View PRX / Main View L-Band

This page contains important information about the device. The **System Up Time** is the total time the device has been up and running. **Status**, **Source**, **Source Status**, **Local Oscillator**, **Input Transmux Rate** and **Status Transmux Rate** are other important parameters displayed on this page.

### General PRX / General L-Band

This page contains general information about the device, such as the **Product Type, Product Name** and **Product Version**.

You can also find the **Temperature**, **Status**, **Source**, **Source Status**, **Program**, **PCR**, **PMT**, **STC**, **Input Transmux Rate** and **Video Transmux Rate** on this page.

### IRD PRX / IRD L-Band

This page displays the following parameters:

- **Manual Local Oscillator**: Allows you to manually enter the LNB frequencies provided either for C: Manual or Ku: Manual.
- **Oscillator**
- **Low Band**: Allows you to enter the L-band frequency.
- **Symbol Rate:** Displays the number of symbols transmitted per second.

### Input PRX / Input L-Band

This page contains information about the active inputs and demodulator parameters.

The following parameters related to the active inputs can be found on the left-hand side of the page:

- **Oscillator:** Specifies the frequency of the LNB local oscillator.
- **Manual Local Oscillator:** Allows you to enter the LNB local oscillator frequency manually, provided that either C: Manual or Ku: Manual is selected.
- **Downlink**: Allows you to enter the satellite downlink frequency.
- **Acquisition Range**
- **Low Band**: Allows you to enter the L-band frequency.

On the right-hand side, you can find the following parameters related to the demodulator:

- **Type:** Allows you to select the mod type.
- **Mode:** Allows you to select the modulation mode and FEC code rate.
- **Rolloff**
- **Frame Type**
- **Symbol Rate**
- **Pilot:** Allows you to reduce the data rate by approximately 3.0%.

### Video

This page displays the genlock status and settings. It contains parameters such as **Lock State**, **Detected Reference Format**, **Out Video Standard**, **Cross Reference**, **Decode Status**, **Number Lock Lost**, **Reference Lost**, **Video Skips**, **Video Repeats**, **Genlock Settings**, **Mode**, **Horizontal Adjust**, **Vertical Adjust**, **Pixel Phase**, **CVBS**, **OSD Mode**, **Service Lines**, **Service Blink**, **Color Bar Mode**, **Type** and **OSD Size**.

### Audio

This page contains the **Audio Table**, where you can find parameters such as **PID Input**, **Offset** (which adjusts each individual pair of audio sync) and **Current**.

### CAS

This page contains information about the **CAS Mode**, **Key String A** and **Key String B**.

### Transport Service

This page displays all the information related to the **Transport Service Table** and **Services Tables**.

### Network

This page displays all the information related to the **Entity IP Address Table**. It contains parameters such as **Broadcast Address** and **Net Mask**

### Chassis

This page contains tables with information about the **Power Supply** and the **Fans**.

### Tuner Status PRX / Tuner Status L-Band

This page contains information about the **Tuner**. It includes parameters such as **Roll-off**, **Tuner Lock**, **Spectral Inversion**.

### Sat Feed PRX / Sat Feed L-Band

This page contains information about the **Satellite Feed**. It includes parameters such as **Downlink**, **Symbol Rate**, **ISI**, etc.

### LNB

This page displays the **LNB1 and LNB2 Availability**, allowing you to enable or disable power on the input connector to the power of the LNB. The **Polarity** control allows you to select **LNB polarization**. The **Tone** parameter can be used to route the high or low band from either polarity to the IRD.

### Profiles

This page contains the **Profiles Table**, which lists all the available profiles along with a button to load each profile.

The **Profiles Last Update** parameter indicates when the Profiles table was last updated. To refresh the table, click the **Refresh Profiles** button.

### Telnet Credentials

On this page, you can specify the credentials for the Telnet communication in the **Username** and **Password** fields.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

When you move to range 1.0.4.x, existing elements need to be recreated before the new connection will be used. This is because connection changes (adding or removing a connection) do not take effect when you upgrade an existing element to the new protocol version. The connections are only created when the element is created.

**Actions to be taken**: DMS element reconfiguration.

**Advised method**: Bulk configuration can be performed using export/import functionality.
