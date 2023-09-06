---
uid: Connector_help_General_Dynamics_Model_950A
---

# General Dynamics Model 950A

This system consists of an ACU (Antenna Control Unit) and a Power Drive Unit (PDU) containing an ACB (Antenna Control Board). The command source is normally a computer, known as the station computer. This station computer will send commands to the ACB.

This connector includes basic commands for the system.

## About

### Version Info

| **Range**            | **Key Features**                                                                                | **Based on** | **System Impact**                                                              |
|----------------------|-------------------------------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                                                | \-           | \-                                                                             |
| 1.0.1.x \[Obsolete\] | Additional commands added. Parameter descriptions changed.                                      | \-           | \-                                                                             |
| 1.0.2.x              | RF parameters page removed, and parameters added to profile page.                               | \-           | Visio files and dashboards linked to the RF page will no longer be compatible. |
| 2.0.0.x              | **Complete review:**- Profiles- RF & config parameters- Point modes- Acquire modes- Track modes | \-           | \-                                                                             |
| 2.0.1.x              | Command processing changed.                                                                     | \-           | \-                                                                             |

### Product Info

| **Range** | **Device Firmware Version**     |
|-----------|---------------------------------|
| 1.0.0.x   | N/A                             |
| 1.0.1.x   | N/A                             |
| 1.0.2.x   | N/A                             |
| 2.0.0.x   | Model 950A.2.28dModel 950A 3.0+ |
| 2.0.1.x   | N/A                             |

### Product Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: 10.52.25.161
  - **IP port**: 5001

### Initialization (Range 2.0.0.x)

By default, the receiver model is set to 520. This can be changed via the Tracking Receiver page, using the toggle button Receiver Model.

The ACU model is detected using RF parameter 21. This is only available for new models (3.0+). It is possible that specific firmware updates on the old model also provide info for parameter 21. For this reason, it is possible to overwrite the detected model back to the old one. To do so, go to the Profile page and change the ACU Model to Model 950A instead of Model 950 3.0+.

Known issues when the incorrect model is applied:

- Profile mappings to data sets are incorrect. The device info of the new model has a different meaning compared to the old.
- Saving settings can result in a bad or unknown request for the device. Request formats are different between the 2 models.

### Web Interface

The web interface is only accessible when the client machine has network access to the product. To use this functionality, you must enter a port on the **General** page.

**NOTE:** This functionality also requires that the Chromium plugin is activated. To activate this, in DataMiner Cube, go to *System Center* \> *System settings* \> *Plugins*, and set the web browser engine to Chromium. You can do so for the entire system or create an exception to do so for this protocol only.

## Usage (Range 2.0.0.x)

### General

This page displays the **Tracking Signal Level** and the **Current** **Azimuth**, **Elevation**, and **Polarization** **Position** of the antenna, as well as the values of the monitored **Power Supplies**.

It also displays the current ACB operational mode, i.e. the **Fundamental Mode**, the **Fundamental Submode**, the **Enhanced Mode**, the **Enhanced Submode**, the **Polarization Mode**, and the **Polarization Submode**.

Control buttons allow you to adjust the **Requested Azimuth**, **Elevation**,and **Polarization Position**. After you store the requested value locally by clicking the green check mark, click the **Apply Fine-Tune** button to set the value on the device.

Below this, a number of buttons allow further configuration of the tracking mode: **Manual Position**, **Stop Tracking**, **Moon**, and **Sun**. This section also contains two page buttons:

- **Preset Position:** Allows you to set the preset position to one of the 40 preset positions in the ACU. To do so, specify the preset position number and use the **Preset Position** button to move the antenna to the configured preset angles.
- **Stow:** Allows you to set the stow position. To do so, set the **stow position number** to "1" or "2" (corresponding with the two possible stow positions) and use the **Stow Position** button to make the ACB go into Stow Mode.

The page also allows you to load the **Box Limits** (i.e. **Box Limit Status**, **Configuration Location**, **Box Width**, **Box Length**, **Command Type**, **Azimuth Box Center**, and **Elevation Box Center**), as well as to enable or disable the **Axis**.

### Info Messages

Both the current **Active Fault Messages** table and the current **Active Status Messages** table are located on the Info Messages page. These tables will only show messages that are supported.

It can happen that some messages do not show up in one of the tables even though they are displayed on the device itself. In that case, you should always check the current active unsupported messages. The **Settings** page button will open a subpage where the unsupported messages are handled.

### Settings

The **Display Mode** dropdown box determines which **message type** is displayed. It allows you to request the **readable** messages (Default) or the **binary** messages (Detailed). Note that different firmware versions can return a different set of data. In other words, the same bit can represent a different message. To make the connector as generic as possible, a custom list of supported messages was compiled. A message will only show up in the Active Fault Messages table or the Active Status Messages table if it is present in this list.

All returned messages that are not present in the list of supported messages can be logged at any time. Click the **Log Msgs** button on the Settings page to print the current active unsupported messages in the element log. The purpose of logging these unsupported messages is to turn them into supported messages by adding them in the code and in the alarm template if applicable. You can find a video about this on our Dojo Community website: [General Dynamics Model 950A and Model 1xx Support Undocumented Messages](https://community.dataminer.services/use-case/general-dynamics-model-950a-and-model-1xx-support-undocumented-messages/).

To make a message supported:

- Adjust the *Protocol.xml* file:

- If the unsupported message is a **status** message, add the following *Discreet* tag under the Protocol.Params.Param.Measurement.Discreets tag of parameter ID **5102**.
  - If the unsupported message is a **fault** message, add the following *Discreet* tag under the Protocol.Params.Param.Measurement.Discreets tag of parameter ID **5002**.

> *\<Discreet\> *\<Display\>MY MESSAGE\</Display\> *\<Value\>MY MESSAGE\</Value\>*\</Discreet\>****
>
> Replace "MY MESSAGE" with the message you logged earlier.

- Adjust *QAction_3161.cs*: Add a new MessageData object in the GetAllSupportedUndocumentedMessages property of the BinaryMessageParser class.

- For default messages, the byte and bit numbers are set to -1 as they are not part of the vendor documentation:

  - - *new MessageData { ByteNumber = -1, BitNumber = -1, Message = "MY MESSAGE", Type = MessageType.Fault },*

<!-- -->

- For detailed messages, set the byte and bit number to the value that is printed, and provide a message that you want to see when this bit is returned by the ACU:

  - - *new MessageData { ByteNumber = 5, BitNumber = 0, Message = "MY MESSAGE", Type = MessageType.Fault },*

If you have any questions about modifications to the code, contact <squad.deploy-sphinx@skyline.be>

Note that the parameters **Unsupported Fault Messages** and **Unsupported Status Messages** will show *N/A* when the *Detailed Display Mode* is selected. Since these messages are unsupported and thus not listed in the connector, it cannot determine whether an unsupported detailed message is a status message or a fault.

### Detailed Status

This page displays status parameters regarding the Azimuth and Elevations. These parameters will only be filled in if **Display Mode** is set to **Detailed.**

### Software Limits

This page shows the software travel limit values in the ACB. The **Apply Limits** commands are only accepted while in Stop Mode and POL Stop (for POL systems). The polarization travel limits will be zero if there is no polarization axis.

### Power Supply

The ACB will transmit the values of the power supplies that it monitors, as well as the temperature. These are the same values as are displayed in the Power Supplies Monitor Window on the ACU front-panel screen.

### Tracking Receiver

The parameters on this page are meaningful only if a **Model 500 Series Tracking Receiver** is used in the system. The ACB will transmit values of the tracking receiver parameters it monitors. These are the same values as are displayed in the Tracking Receiver Monitor Window on the ACU front-panel screen.

### Profile

This page displays the Current **Active Profile**, Pointing Mode, Acquire Mode, and Tracking Mode. When **Edit Mode** is set to *Write Only*, user data of a specific profile can be modified.

The page also allows you to view the RF parameters for the current or desired profile and to change the values before you activate a new profile.

### Point Mode - Geo Position

This page lists the preset LAT/LON positions in the **GEO Preset Position Info** table. You can also set the **Longitude** and **Latitude**.

### Point Mode - Intelsat

The **Intelsat Information** table shows several Intelsat parameters. If the station computer is not in control of the ACB, the ACB will reject load commands. If the ACB is not in control of the antenna, the ACB will reject load commands. Recall commands are allowed at any time, but they will be rejected if the data set does not exist (i.e. has not been loaded). The following load command allows the data set, including the set in use, to be changed while in Intelsat Mode. Set deletion is not allowed on the set in use.

This page also allows you to manage the **Ephemeris Number**, as well as to configure the Intelsat parameters **Lm0**, **Lm1**, **Lm2**, **Lonc**, **Lonc1**, **Lons**, **Lons1**, **Latc**, **Latc1**, **Lats**, **Lats1**, **Epoch Time**, **Latitude**, **Longitude**, **Check Time**, **Intelsat Set**, **Configuration**, and **Name**.Finally, you can also **erase** the selected **Ephemeris Number**.

### Store Intelsat

To add an entry to the **Intelsat Information** table, you can configure the parameters on the Store Intelsat page before saving them.

### Point Mode - Norad

This page contains general information related to the Norad object. It also allows you to set the NORAD tracking mode by configuring the **Object**, **Cable Wrap**,and **Start** and **Stop Time** (day, month, year, hour, minutes, and seconds).

### Point Mode - Pos Designate

This page displays the **manual offset** of the **azimuth**, **elevation**,and **polarization** parameters. Buttons allow you to add a specific amount to the offset for each of these parameters. Below this, the **Azimuth, Elevation, and Polarization Offset** parameters allow you to specify a new offset. You can also configure the **Azimuth** **Position**, **Elevation Position**, **Azimuth Velocity**, **Elevation Velocity**, **Time**, and **Cable Wrap**.

### Point Mode - Optrack

This page allows you to manage the **Optrack Data Set**. You can also load the Optrack parameters **Data Set**, **Recycle**, **Scan Cycle Time**, **Configuration, Track Type**, and **Name**, and charge the Optrack Data **N1** and **N2**. Finally, you can also **clear** the selected **data set**.

### Point Mode - Star Track

This page allows you to manage the **Star to Track**, with the parameters **Location**, **Right Ascension**, **Declination**, **Epoch Type**, **Epoch**, **Configuration**, **Cable Wrap**, and **Name**. It also contains a number of buttons that allow you to add a specific amount to the **Star Track** **Azimuth** **Offset**, **Star Track Elevation Offset**,and **Star Track** **Time** **Offset**. You can also specify a new **Azimuth Offset, Elevation** **Offset**,and **Time Offset**,as well as a **Location**.

### Track Mode - Steptrack

This page allows you to manage the **Data Set**, **Scan Pattern**,and **Scan Number** through the Steptrack Mode. You can also configure the Steptrack **Data Set, Recycle, Integration Time, Box Step Size, Data, Scan Cycle Time, Gain, Park, Limit, Scan Pattern, Scan Number**,and **Name**.

From here, you can also cancel the enhanced mode using the **Cancel Enh. Mode** button.

### RF Parameters

This page allows you to load the **RF Parameters**, i.e. **Parameter Number**, **Center Frequency**, **Bandwidth**, **Slope**, **Offset**, **Active Search**, **Feed Offset Elevation**, **Feed Offset in Cross Elevation**, **Path**, **Sweep Width**, **Name**, **Secondary Path**,and **Block Downconverter Frequency**.

You can also select the **Beacon Frequency** here.

### Configuration Parameters

The configuration parameters are listed in the **Configuration Parameters** table. The current **Active Config Parameter** can be found at the top of this page. To activate a parameter, click the **Execute** button in the **Activation** column. By default, only basic information will be polled and columns such as **Box Center Mode**, **Longitude Box Center**, etc. will stay empty (Not initialized). In order to retrieve data related to box and slot limit, select an appropriate **Limit Configuration**. Note that the Limit Configuration can only be changed when the corresponding Config Parameter is active.

### Pol Mode

This page allows you to set the **Polarization Position**, **Polarization Velocity**,and **UTC Time.** You can also select the polarization tracking modes, such as **Auto**, **Intelsat**,**Optrack**,and **Stop**. Via the **Preset Position** page button, you can set the preset position number to one of the 40 polarization preset positions in the ACU.

## Usage (Range 1.0.0.x, 1.0.1.x or 1.0.2.x)

### General

This page displays the **Tracking Signal Level** and the **Current** **Azimuth**, **Elevation**, and **Polarization** **Position** of the antenna, as well as the values of the monitored **Power Supplies**.

It also displays the current ACB operational mode, i.e. the **Fundamental Mode**, the **Fundamental Submode**, the **Enhanced Mode**, the **Enhanced Submode**, the **Polarization Mode**, and the **Polarization Submode**.

Control buttons allow you to adjust the **Current Azimuth**, **Elevation** and **Polarization Position**. Below this, a number of buttons allow further configuration of the tracking mode: **Cancel Enhanced Mode**, **Manual Position**, **Stop Tracking**, **Moon**, and **Sun**. This section also contains two page buttons:

- **Preset Position**: Allows you to set the preset position to one of the 40 preset positions in the ACU. To do so, specify the preset position number and click the **Preset Position** button to move the antenna to the configured preset angles.
- **Stow**: Allows you to set the stow position. To do so, set the **stow position number** to "1" or "2" (corresponding with the two possible stow positions) and click the **Stow Position** button to make the ACB go into Stow Mode.

The page also allows you to load the **Box Limits** (i.e. **Box Limit Status**, **Configuration Location**, **Box Width**, **Box Length**, **Command Type**, **Azimuth Box Center**,and **Elevation Box Center**), as well as to enable or disable the **Axis**.

### Alarming

This page displays the various possible faults of the device, with a list of parameters that either display *Fault* or *OK*. In addition, it also displays the status of multiple features of the device, listing whether these are active or not.

### Manual Position

This page displays the **manual offset** of the **azimuth**, **elevation**,and **polarization** parameters. Buttons allow you to add a specific amount to the offset for each of these parameters.

Below this, the **Azimuth, Elevation, and Polarization Offset** parameters allow you to specify a new offset.

### Position Designate

On this page, you can configure the **Azimuth** **Position**, **Elevation Position**, **Azimuth Velocity**, **Elevation Velocity**, **Time**, and **Cable Wrap**.

### GEO

On this page, you can set the **Longitude** and **Latitude** using the **GEO Designate** command and the **GEO Preset Position Number**.

You can also load the GEO Preset Position **Number**, **Latitude**, **Longitude**, **Configuration**, and **Name**.

### Optrack Mode

This page allows you to manage the **Optrack Data Set**. You can also load the Optrack parameters **Data Set**, **Recycle**, **Scan Cycle Time**, **Configuration, Track Type**, and **Name**, and charge the Optrack Data **N1** and **N2**.

Finally, you can also **clear** the selected **data set**.

### Intelsat Pointing Mode

This page allows you to manage the **Ephemeris Number**. It also allows you to configure the Intelsat parameters **Lm0**, **Lm1**, **Lm2, Lonc**, **Lonc1**, **Lons**, **Lons1**, **Latc**, **Latc1**, **Lats**, **Lats1**, **Epoch Time**, **Latitude**, **Longitude**, **Check Time**, **Intelsat Set**, **Configuration**, and **Name.**

Finally, you can also **erase** the selected **Ephemeris Number**.

### Star Track Mode

This page allows you to manage the **Star to Track**, with the parameters **Location**, **Right Ascension**, **Declination**, **Epoch Type**, **Epoch**, **Configuration**, **Cable Wrap**, and **Name**.

It also contains a number of buttons that allow you to add a specific amount to the **Star Track** **Azimuth** **Offset**, **Star Track Elevation Offset**,and **Star Track** **Time** **Offset**. You can also specify a new **Azimuth Offset**, **Elevation** **Offset** and **Time Offset**, as well as a **Location**.

### Steptrack Mode

This page allows you to manage the **Data Set**, **Scan Pattern** and **Scan Number** through the Steptrack Mode. You can also configure the Steptrack **Data Set**, **Recycle**, **Integration Time**, **Box Step Size**, **Data**, **Scan Cycle Time**, **Gain**, **Park**, **Limit**, **Scan Pattern**, **Scan Number**,and **Name**.

### RF Parameters

This page allows you to load the **RF Parameters**, i.e. Parameter Number, Center Frequency, Bandwidth, Slope, Offset, Active Search, Feed Offset Elevation, Feed Offset in Cross Elevation, Path, Sweep Width, Name, Secondary Path, and Block Downconverter Frequency.

You can also select the **Beacon Frequency** here.

### Polarization Mode

This page allows you to set the **Polarization Position**, **Polarization Velocity**,and **UTC Time.** You can also select the polarization tracking modes, such as **Auto**, **Intelsat**,**Optrack**,and **Stop**.

Via the **Preset Position** page button, you can set the preset position number to one of the 40 polarization preset positions in the ACU.

### NORAD

This page allows you to set the NORAD tracking mode by configuring the **Object**, **Cable Wrap**,and **Start** and **Stop Time** (day, month, year, hour, minutes, and seconds).

### Acquisition and Pointing

On this page, you can set the **Box Scan Mode** and the **Geo Scan Mode** by configuring the **Manual Scan Parameter**.

### Profile

This page displays the **Current Active Profile** and allows you to select a different user profile with the **Select Profile** parameter.
