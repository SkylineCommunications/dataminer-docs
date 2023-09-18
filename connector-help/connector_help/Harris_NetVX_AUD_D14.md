---
uid: Connector_help_Harris_NetVX_AUD_D14
---

# Harris NetVX AUD D14

The **Harris NetVX AUD D14** connector is an **SNMP** connector that is **Audio Converter**.

## About

The **Harris NetVX AUD D14** is an overview of **Encoders** and **Decoders** configuration parameters that make it easier to configure this **Audio Converter**. Also the status of the **Encoders** and **Decoders** are shown.

## Installation and configuration

The **Harris NetVX AUD D14** connector has an **SNMP** Connection:

- **Port:** 161
- **Bus Address:** The slot number of the **Audio Converter.**
- **IP Address:** The IP of the Device
- **Get community string:** public
- **Set community string:** private

## Usage

### General

Here you see some **General Slot Configuration** parameters, where you can make some basic changes to the **Audio Converter** and you also have the **General Slot Status** parameters that shows you some basic information about the **Audio Converter.** So you have some **small overview** already about the connector on this page.

### Ctl Configuration

**Certificate Trust List Configuration** this presents all the trusted **Coders** for this slot. You can choose their **Function** (Decode/Encode/Off) and set their **Mode** (Standalone/Associated).

### Encoder Configuration

This page has a **TreeControl** that shows you the **Configuration** of every **Encoder** on this **slot**. Each of these **Encoders** have an **Audio Advanced Configuration**, **Audio Configuration**, **Event Configuration**, **New Event Configuration**, **Program Configuration** and **Router Control Configuration**. These overviews shows you all **details** about the specific **Encoder** and gives you the possibility to make changes to the configuration.

### Decoder Configuration

This page has a **TreeControl** that shows you the **Configuration** of every **Decoder** on this **slot**. Each of these **Decoders** have an **Audio Configuration**, **Program Configuration** and **Router Control Configuration**. These overviews shows you all **details** about the specific **Decoder** and gives you the possibility to make changes to the configuration.

### Encoder Status

This page has e **TreeControl** that shows you the **Status** of every **Encoder** on this **slot**. Each of these **Encoders** have an **Audio Status** and a **Program Status**.

### Decoder Status

This page has e **TreeControl** that shows you the **Status** of every **Decoder** on this **slot**. Each of these **Decoders** have an **Audio Status** and a **Program Status**.

## Notes

It could happen that you make a new element of the connector and the **TreeControls** are **empty**, just **recreate / reopen** the element card and the **problem** is **fixed**.
