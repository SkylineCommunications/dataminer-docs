---
uid: Connector_help_Crystal_Vision_Multilogo_V132
---

# Crystal Vision Multilogo V132

The Crystal Vision MultiLogo V132 is an HD/SD three-layer logo keyer with 8 GB of internal storage for up to 500 graphics with full audio processing.

## About

The Crystal Vision MultiLogo V132 connector is used to view and monitor a Crystal Vision MultiLogo V132 card. All the settings of the device can be modified using this connector.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: The number of a specific card of the device, e.g. *5*.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Status Page

The **Status** page displays multiple blocks of data:

- Input Present,
- Key Status 1 to 3,
- Input Audio Status 1 to 4.

Each of these blocks contain parameters that display if the specific parameter is *Active* or *Inactive* (*Present* or *Not Present*).

### Ram 1 and 2 Page

The **Ram 1 and 2** page displays four blocks of data for Ram 1 and Ram 2:

- **Animation**: Allows the user to view and modify the **Play** **Mode** and **Type.**
- **Stills**: Allows the user to set the **Still** **Type** and perform an action by pressing one of the four available buttons.
- **Marks**: Provides three buttons related to the marks.
- **Position**: Displays the **Left** and **Top** position of the Ram.

### Ram 3 and 4 page and Ram 5 and 6 page

This page contains the same blocks of data as the **Ram 1 and 2** page, but now with regard to Ram 3 and 4, and Ram 5 and 6.

### Recorders

This page contains 4 blocks of data:

- **Mask**: Allows the user to set the four parameters for the mask of the recorder between *0* and *1080.*
- **Length**: Allows the user to set the length of the frames between *0* and *1000.*
- **Control**: Allows the user to set the **Record** **Mode**, and also contains a button to perform the **Record** action.
- **Source**: Allows the user to select the source for the **Fill** and the **Key**.

### Key 1 page

The **Key** **1** page displays six blocks of data:

- **Key Control**: Allows the user to view or modify the controls for the **Key**.
- **Key Mask**: Allows the user to set the four masks as preferred.
- **Key Source**: Allows the user to specify which source to take for the **Fill** and the **Key**.
- **Key Processing**: Allows the user to set the **Offset**, **Gain** and **Opacity.**
- **Key Transition**: Allows the user to set the **Fade** and **Fade** **Rate**, and also contains two buttons.
- **Key Fades**: Contains four buttons that each perform a certain action.

### Key 2 page and Key 3 page

These two pages are identical to the **Key** **1** page, but now with regard to **Key 2** and **Key 3**.

### Mixer page

This page contain four blocks of data:

- **Background**: Allows the user to choose what to take for the **Program** and **Preview**.
- **Matte**: Allows the user to modify the RGB-values for the Matte.
- **Mix Transition**: Allows the user to specify the **Fade** and enable the **Preview.** There is also a button available to perform a cut.
- **Fade To Black**: Allows the user to set the **Fade** **to** **Black**, and also contains a button to perform a cut.

### Audio page

The **Audio** page enables the user to view and modify the settings for **Audio 1**, **Audio 2** and the **Ancillary Data Output**.

### Audio Mixer

The **Audio Mixer** page has five page buttons available that will each open a pop-up page. This pop-up page allows the user to *enable*/*disable* different channels of different groups for the specified page button.
This page also allows the user to monitor and set the **Audio** **Controls** and **Audio** **Fades**.

### GPIs page

This page allows the user to modify the GPI assignments for:

- GPI 1 to 4
- GPI Presets
- Tally 1 to 3

There are also four page buttons available that will open a pop-up page where the transitions can be enabled for the selected GPI.

In the **GPI and Preset Enables** section, the user can *enable*/*disable* the **Enable** **GPI** **inputs** and the **Trigger** **Players**.

### Engineering page

The **Engineering** **page** allows the user to view/modify the settings for the **Timing**. It also contains three buttons that can be used to perform specific reset actions.

### Presets page

This page displays three blocks of data. However, note that the **Partial Preset** data block is in fact divided in two sections.

- **Preset Control**: Allows the user to set the **Preset** **Select** to a value between *0* and *255,* and also contains two buttons.
- **Partial Preset**: Allows the user to set the save for multiple parameters to *True* or *False*.
