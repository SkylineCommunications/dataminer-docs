---
uid: Connector_help_Belgacom_TVRO_De-icing
---

# Belgacom TVRO De-icing

This connector provides an overview of the de-icing status of antennas and compares it with the expected status based on outside temperature and rain intensity.

## About

This virtual connector needs to be linked to multiple elements to get its data.

## Installation and configuration

### Creation

***Virtual connection***
This connector uses a virtual connection and does not require any input during element creation.

### Configuration of the weather station

There are 2 parameters that need to be linked to a **Belgacom Weather Station**:

- **Outside Temp**
- **Rain Intensity**

These parameters are used for the calculation of the expected de-icing status.

### Configuration of the antennas

For each antenna, 5 parameters need to be linked:

- **Auto/Man Control**: Needs to be linked to a relay of a **Beckhoff KL2622** element.
- **Reset Control**: Needs to be linked to a relay of a **Beckhoff KL2622** element.
- **De-icing Status**: Needs to be linked to an input of a **Beckhoff KL1104** element.
- **Surface Temperature**: Needs to be linked to an input of a **Beckhoff KL3202** element.
- **Mains**: Needs to be linked to an input of a **Beckhoff KL1104** element.

To be able to link an antenna, you first have to create a row in the antenna overview table and define a name.

## Usage

### Overview

This page is separated into 4 sections:

- **Temperature:** This section displays the current outside temperature and the average antenna temperature. A temperature threshold control is available to be used in the expected de-icing calculations.
- **Rain:** This section displays the current rain intensity. A control is available to set the rain threshold. This threshold is used to define if there is precipitation.
- **De-icing:** This section displays the expected de-icing status (based on the outside temperature, temperature threshold and precipitation). The **Matching de-icing status** displays the percentage of antennas for which the de-icing status matches the expected status.
- **Antennas:** This section displays a table with all the configured antennas.
