---
uid: Connector_help_Thomson_Video_Networks_Vibe_CP6000_Decoder
---

# Thomson Video Networks Vibe CP6000 Decoder

The Vibe CP6000 is a contribution platform that enables users to transport up to eight acquisition-quality SD or HD services. It is a future-proof modular rack, with four hot-swappable slots. It is based on the ATCA telecom standard and offers the highest possible quality, flexibility and reliability. Its MPEG modules embed audio and video patterns, providing flexible error management. The Vibe CP6000 encodes and decodes up to eight stereo channels and manages Dolby E and audio uncompressed passthrough.

## About

This connector is designed to monitor the state of the audio and video for the **CP6000** **Decoder** **module**. It also monitors the values of the different parameters present in the input(s) and output(s) for the decoder, and allows the user to manage transport for the decoder module. The different parameters of the device are displayed on multiple pages grouped by function.

This connector is generated automatically by the connector **Thomson Video Networks Vibe CP6000**.

### Version Info

| **Range** | **Description**                                                                                                            | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                                                           | No                  | No                      |
| 1.0.1.x          | New feature - translated table for multicast IP address and port + fixed problem with Alarm Table.                         | Yes                 | Yes                     |
| 1.0.2.x          | \- Changed layout. - Fixed linking between tables. - Alarm monitoring on PID bitrates returns a user-friendly description. | Yes                 | Yes                     |
| 1.0.3.x          | Table display keys changed to avoid duplicate naming.                                                                      | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | CP6000 04.20.02             |

## Installation and configuration

### Creation

This connector is used by DVEs that are **automatically created** by the parent element. No user input is required.

## Usage

### Decoding

On this page, you can configure the parameters for the **Video** and **Audio** **Decoding**.

### Service Config & Demultiplex

This page contains the **Input Service**, **Output** and **Ancillaries Vbi** tables for the decoder module.

### Transport Management

This page contains the **Transport** and **Transport IP Rx** **Table** for the decoder module.

### Redundancy

This page displays the **Redundancy** **Table**.
