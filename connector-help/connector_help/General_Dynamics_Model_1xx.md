---
uid: Connector_help_General_Dynamics_Model_1xx
---

# General Dynamics Model 1xx

Monitoring and control of the Antenna control system for models in the 100 range.

## About

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x [SLC Main]</td>
<td><ul>
<li>Key Params (RF / Config)</li>
<li>Point Modes</li>
<li>Track Modes</li>
<li>Scan Modes</li>
</ul></td>
<td>Developed to have a similar usage (where possible) as the 950A Model.</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Models 100/133         |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |



## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

- Adjust the protocol.xml

- Adjust QAction_3161.cs

### Initialization

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

## How to use

### Info Messages

Both the current **Active Fault Messages** table and the current **Active Status Messages** table are located at the Info Messages page. These tables will only show messages which are supported. It can happen that some messages won't show up in one of the tables even though they are displayed on the device itself. In such case you should always check the current active unsupported messages! The "Settings..." pagebutton at the top right will bring you to the Settings page where the unsupported messages are handled.

### Settings

The **Display Mode** is the most important dropdown of the Settings page since it will select which messagetype is displayed. With this dropdown it is possible to request the readable messages (Default) or the binary messages (Detailed). Please be aware that different firmware versions can return a different set of data. In other words, the same bit can represent a different message. To make the protocol as generic as possible, we compiled our own list of supported messages. A message will only show up in the Active Fault Messages table or the Active Status Messages table if it is present in this list.

All returned messages that are not present in the list of supported messages can be logged at any time. Pressing the "Log Msgs" button on the Settings page will print the current active unsupported messages in the element log. The intention to log these unsupported messages is to turn them into supported messages by adding them in the code and in the alarm template if applicable. A video can be found on our Dojo Community: [General Dynamics Model 950A and Model 1xx Support Undocumented Messages - DataMiner Dojo](https://community.dataminer.services/use-case/general-dynamics-model-950a-and-model-1xx-support-undocumented-messages/)

How to make a message supported:

- Adjust the protocol.xml

> Add the following Discreet tag under the Protocol.Params.Param.Measurement.Discreets tag of parameter id=5002 in case of faults. In case of status the tag should be added to parameter id=5102.
>
> \<Discreet\>

> > \<Display\>MY MESSAGE\</Display\>
>
> > \<Value\>MY MESSAGE\</Value\>

> \</Discreet\>
>
> Please replace "MY MESSAGE" by the message you have logged earlier.

- Adjust QAction_153.cs

> Add a new MessageData object in the GetAllSupportedUndocumentedMessages property of the BinaryMessageParser class.
>
> For default messages: the byte and bit numbers are set to -1 as they are not part of the vendors documentation:new MessageData{

> > ByteNumber = -1,
>
> > BitNumber = -1,
>
> > MessageDetail = new\[\]
>
> > {

> > > new MessageDetail { Model = MessageModel.Any, Message = "MY MESSAGE", Type = MessageType.Fault },
>
> > > new MessageDetail { Model = MessageModel.M100, Message = "MY MESSAGE", Type = MessageType.Fault, SupportedSpeeds = new\[\] { MessageSupportedSpeed.Any, MessageSupportedSpeed.Single, MessageSupportedSpeed.Dual} },
>
> > > new MessageDetail { Model = MessageModel.M133, Message = "MY MESSAGE", Type = MessageType.Fault, SupportedSpeeds = new\[\] { MessageSupportedSpeed.Any}}

> > }

> }

>
> For detailed messages: set the byte and bit number to the value that is printed and provide a Message that you want to see when this bit is returned by the ACU:
> new MessageData
> {
>
> > ByteNumber = 5,BitNumber = 0,
> > MessageDetail = new\[\]{
>
> > > new MessageDetail { Model = MessageModel.Any, Message = "MY MESSAGE", Type = MessageType.Fault },
> >
> > > new MessageDetail { Model = MessageModel.M100, Message = "MY MESSAGE", Type = MessageType.Fault, SupportedSpeeds = new\[\] { MessageSupportedSpeed.Any, MessageSupportedSpeed.Single, MessageSupportedSpeed.Dual} },
> >
> > > new MessageDetail { Model = MessageModel.M133, Message = "MY MESSAGE", Type = MessageType.Fault, SupportedSpeeds = new\[\] { MessageSupportedSpeed.Any}}
>
> > }
>
> }
>

When in doubt to make modifications to the code, please contact squad.deploy-sphinx@skyline.be

Note that the parameters **Unsupported Fault Messages** and **Unsupported Status Messages** will show N/A when the Detailed Display Mode is selected. Since these messages are unsupported and thus not listed in the protocol, we cannot distinguish if an unsupported detailed message is a status message or a fault.


### Point Mode - Intelsat

INTELSAT is a fixed formatted definition. When there is no data available the table will remain empty even when device allows a set of items. (e.g. max 10 entries) To add INTELSAT records use the **Store Intelsat ...** page button.
