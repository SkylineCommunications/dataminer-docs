---
uid: Connector_help_Thomson_Video_Networks_Vibe_CP6000_Encoder
---

# Thomson Video Networks Vibe CP6000 Encoder

The Vibe CP6000 is a contribution platform that enables users to transport up to eight acquisition-quality SD or HD services. It is a future-proof modular rack, with four hot-swappable slots. It is based on the ATCA telecom standard and offers the highest possible quality, flexibility and reliability. Its MPEG modules embed audio and video patterns, providing flexible error management. The Vibe CP6000 encodes and decodes up to eight stereo channels and manages Dolby E and audio uncompressed passthrough.

## About

This connector is designed to monitor the state of the audio and video for the **CP6000** **Encoder module**. It also monitors the values of the different parameters present in the input(s) and output(s) for the encoder. The connector also features transport management and profile selection for the encoder module. The different parameters of the device are displayed on multiple pages grouped by function.

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

### Encoding

On this page, you can configure the parameters for the **Video** and **Audio** **Encoding**.

### MPEG Service

This page displays the **Output Service**, **Multiplexing** and **Dpi** tables for the encoder module.

### MPEG Transport Stream

On this page, you can configure the **Encoder Transport Stream Table**.

### Transport Stream

This page contains the **Encoder Transport Stream Constitution**, **Encoder** **Transport** and **Encoder Transport IP Tx Tables**.

### Input Stream with External Component

This page contains the **Encoder External Components** and **Encoder IN Transport** table for the encoder module.

### Profile

The page displays the **Encoder Profile** and the **Profile Selection Table** for the encoder module.

### VBI & Ancillaries Management

The page contains the **Encoder Vbi**, **Encoder** **Ancillaries** and **Encoder Vbi Line Tables** for the encoder module.
