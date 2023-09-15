---
uid: Connector_help_ARTE_Satellite_Nodal_Manager
---

# ARTE Satellite Nodal Manager

The **ARTE Satellite Nodal Manager** makes it possible for multiple users to:

- Control the antenna setup and monitor the real time signal.
- Control mobile antennas.

All of this is done through a Visio visual overview, which is essential for this connector.

## About

With the **ARTE Nodal Manager**, you can configure the current device setup. E.g. you can configure that two antennas can be used, one of which is mobile, while the other is fixed.

Once the device chain for each antenna is configured, you can organize specific settings for an antenna through a Visio visual overview. You can for instance connect an output to an input and monitor the signal with specific details.

You can also monitor an already existing connection. This way you can quickly check a signal and adapt the settings if needed.

## Installation and configuration

### Creation

This is a virtual connector, so no settings need to set during creation of the element.

### Low Band Matrix

All the connection settings are done on a Low Band matrix. The matrix element that will be used must be selected, and to validate the settings the range will be retrieved.

To find all the possible Low Band Matrices, click the **Get L-Band Element** button. You can then select the right one in the drop-down menu in **Select L-Band Matrix Element**.

### Antennas

Adding and removing antennas is done in the **Antenna** **Table**. Once a row is added in this table, it is possible to configure it the same way the real antenna is configured.

Required configurations are:

- **Name**

- **Type:** *Mobile* or *Fixed.*

- **Connection:** *Matrix* or *Device.*

- **ACU Element:** If the type is *Mobile.*

- **Polarization:** *Horizontal* or *Vertical.*

- **LNB Redundancy:** *Yes* or *No.*

- **Satellite Name:** If the type is *Fixed.*

- The linked inputs for the main and/or backups (**VLB**, **VHM**, .)

  - The column headers indicate what it represents:

    - 1st character:

      - V = Vertical
      - H = Horizontal

    - 2nd character:

      - L = Low
      - H = High

    - 3rd character:

      - M = Main (= Primary)
      - B = Backup (= Secondary)

The **Polarization Table** will automatically be updated with these settings, and the configured inputs will be added in the **Input Table**.

### Sources / Inputs

After the antennas have been configured, the linked inputs will be added in the **Input Table**. Here, the LO, Min and Max frequency need to be configured for each input.

### Destinations / Outputs

According to the limit of the L-Band, outputs can be added to the **Output Table**. When you add an output, the current connected input will be retrieved from the **L-Band Matrix element**. This way, the configuration details from the antenna will be shown in the **Output Table**. Only the link to the IRD remains, and this can be done via the **Output Element Ref** column. This will indicate the **Element** **Name** of the IRD linked to this output. You can also give this IRD output a name in the **Dst (IRD)** column.

From this IRD, multiple real-time values can be displayed in the **Output Table**. For this, the location of this value needs to be configured in the **Element Config.** To specify this location, add the protocol name used by the IRD in the **Output Element Config Table**. You can then set the parameter ID of the value you wish to retrieve. There are three fixed values:

- Eb/N0
- Sat Frequency
- LNB Frequency

And three variable values:

- User 1
- User 2
- User 3

Each of them needs to be configured using one of the following formats:

- **Parameter** ID of the **read**
- **Parameter** ID of the **write** (=**Column** ID) / **parameter** ID of the **read** (= **Table** ID) : **Column** Index : Key

  e.g. 110/100:2:1_A

When one of the items in the format does not exist it may be left empty.
E.g.: 110/100

### Satellite

The beacon frequency that will be used when monitoring a signal via a Spectrum Analyzer needs to be configured in the Satellite table.

Each satellite needs a beacon frequency for either Horizontal or Vertical, in case the satellite can be received via a mobile antenna, or both, in case of a fixed antenna.

### Spectrum

In order to create the spectrum files to monitor the signal, some items need to be configured:

- **RefLevel**: The reference level.
- **Amp Scale**: The amplitude scale.
- **VBW:** The video bandwidth.
- **RBW:** The resolution bandwidth.
- **SweepTime**: The time a trace will be taken.
- **Monitor Interval**: The interval the monitor will be executed.
- **Matrix Max Input Dimensions** (L-Band Matrix): The minimum number of inputs.
- **Matrix Max Output Dimensions** (L-Band Matrix): The maximum number of outputs.

## Usage

### L-Band Matrix Element Page

On this page, you can select the L-Band DataMiner element that represents the matrix where settings will be applied. This matrix is the main item of the functionality of this connector. Its inputs and outputs are set according to the configurations made by the user via the Visio visual overview.

Once the L-Band DataMiner element is selected, the referenced DataMiner ID and element ID are displayed, as is the number of inputs and outputs.

You can only select L-Band Matrix elements using the **Novotronik MAS1000** connector with the **Production** version. This is already limited via the **Get L-Band Element** button.

### L-Band Matrix Antennas Page

This page gives an overview of the configured antennas. These will be available for use via the Visio visual overview.

The configuration of this table is explained in the section *Installation and configuration*.

The values in the table will result in the correct setting of the actions requested via the Visio visual overview. E.g. when the Vertical Low Backup needs to be used, the connector will select the setting in the **Antenna VLB Input ID** in order to know the **L-Band Matrix** **Input**.

### L-Band Matrix Antenna Alerts Page

This page displays the **Satellite Source Table** in the Visio visual overview.

When you configure the **Antenna Table**, the link to the polarization, satellite and ACU are automatically made. The result is displayed on this page.

For each antenna referred via its name and polarization type, a row will be shown. Next to this, the satellite and, in case of a mobile antenna, the DataMiner ID and element ID of the linked ACU element are shown.

In addition, you can also create a DataMiner view using the name set in the **Polarization View Name** column. It will also contain the alarm state of each view.

### L-Band Matrix Sources Page

This page displays a list of all the inputs found on the L-Band element and the fixed antenna. When settings are configured in the **Antenna Table**, the link to the **Antenna Polarization**, **Input Band** and **Input Redundancy** is automatically set.

The configuration of the LO Frequency with its minimum and maximum, as explained in *Installation and Configuration*, needs to be done manually. These values are needed in order for the connector to select the correct input when for example a Spectrum Analyzer has to monitor a specific signal requested by the '*Aligner'* request in the Visio visual overview.

### L-Band Matrix Destinations Page

This page displays the main table to configure antennas via the Visio visual overview, the **Output Table**. It contains a list of all L-Band outputs with their currently connected inputs. You can configure the linked device with the **DataMiner** **Element Name** to each output. The type of this device, e.g. *IRD* or *SA* for Spectrum Analyzers, can be set via the **Output Element Type** column.

These linked devices can be given an alias that is displayed in the Visio visual overview for easier use. The current linked antenna and satellite are again retrieved automatically according to the configurations made in the **Antenna Table**.

Some useful data from the ACU can be retrieved as well, such as the Eb/N0, but also some custom items. These will be displayed in the **User** columns. In order to retrieve this data, the location needs to be configured in the **Output Element Config Table** as described in the section *Installation and configuration.*

The **Sync Matrix** button will retrieve the current connections in the L-Band matrix and refresh them in the **Output Table**. You can also have this done every 5s by setting **Matrix Auto Sync** to *Enabled*.

### Satellites Page

This page displays a list of all the satellites that are available for use. This list consists of manually added satellites and retrieved satellites of the configured **ACU elements**.

Manually added satellites can be removed when they are no longer found in any of the **ACU** **elements**. If a satellite was not manually added and is not in any of the **ACUs,** it will be removed automatically.

### Destination Configuration Page

Via the Visio visual overview, it is possible to save a configuration of an output. This is saved in the **Destination Config Table.**

It is also possible to add and remove such a configuration with the **Add Destination** and **Delete Destination** buttons.

### Spectrum Monitors Page

This page displays all the created Spectrum Monitors per user.

You can configure a **Cleanup Time** to remove the monitors of users that no longer exist, or remove them all with the **Remove All** button.

Via the **Config SA.** page button, you can configure the spectrum settings.

### Device Antenna Page

This page displays an overview of the equipment used by an antenna.

## Notes

The Low Band Matrix must use the **Novotronik MAS1000** connector with the **Production** version.

The ACUs must use the **Andrew** **APC100** connector with the **Production** version.

The connector supports following commands in the Visio visual overview:

- *AFFECTER*
- *LIBERER*
- *COMMUTER*
- *ALIGNER*
- *ALIGNER_BEACON (input = satellite name from mobile antenna)*
- *ALIGNER_BEACON (input = fixed antenna name)*
- *SAVE*
