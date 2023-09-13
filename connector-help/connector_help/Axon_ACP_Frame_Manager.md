---
uid: Connector_help_Axon_ACP_Frame_Manager
---

# Axon ACP Frame Manager

The **Axon ACP Frame Manager** connector can be used to poll and configure the data for different types of Axon frames and the attached cards located in their different slots.

## About

Depending on the range, one or more connections are used to retrieve and configure the data for the supported **frame** and its inserted **cards**. Separate connectors can be added to the DMS for the cards.

This connector can create different elements based on the retrieved data. Whether an element is created for the corresponding device type depends on the device setup configuration within this connector. This is a new version of the Axon ACP connector.

### Version Info

| **Range**            | **Description** | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware**                                                                                                                                                                          |
|-----------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | **ERS118:** 0801, 0901, 1001, 1201, 1601, 1801, 1901, 2001, 2201,2301 **ERC108:** 1801,1901,2001,2101,2201 **ERC118:** 2001, 2201 **RRS08:** 1801, 3400, 3600 **RRS18:** 1801, 3100, 3400, 3600 |

### Linked Connectors

The linked connectors represent cards that are inserted in the frame. For a list of the supported firmware versions within the specific connector ranges of each linked connector and the corresponding DataMiner Connectivity Framework information for each connector range, refer to the help for each linked connector.

Below, you can also find an overview of the currently available cards and the firmware versions the connector currently supports.

| **Card Connector** | **Range** | **Firmware Version**                                             |
|--------------------|-----------|------------------------------------------------------------------|
| Axon ACP 2GF100    | 1.0.0.x   | 6034, 6040                                                       |
| Axon ACP 2GU100    | 1.0.0.x   | 7498                                                             |
| Axon ACP 2GU110    | 1.0.0.x   | 1418, 7498, 7504                                                 |
| Axon ACP 2HF100    | 1.0.0.x   | 6034, 6040                                                       |
| Axon ACP 2HS10     | 1.0.0.x   | 3130                                                             |
| Axon ACP 2HX10     | 1.0.0.x   | 3335, 3337                                                       |
| Axon ACP 2IX08     | 1.0.0.x   | 2834                                                             |
| Axon ACP AAD08     | 1.0.0.x   | 0200, 0300, 0400                                                 |
| Axon ACP ADP10     | 1.0.0.x   | 0101, 0203, 0304, 0305, 0306, 0407                               |
| Axon ACP ADP24     | 1.0.0.x   | 0101, 0202, 0203, 0304, 0405, 0406, 0507, 0608                   |
| Axon ACP ARC20     | 1.0.0.x   | 2316, 2417, 2517, 2617, 2717, 3217, 3418, 3518                   |
| Axon ACP CDV07     | 1.0.0.x   | 0100, 0200, 0300                                                 |
| Axon ACP CDV08     | 1.0.0.x   | 0500, 0600, 0700, 0800, 0900                                     |
| Axon ACP CDV09     | 1.0.0.x   | 0500                                                             |
| Axon ACP CDV29     | 1.0.0.x   | 0100, 0200, 0300, 0400                                           |
| Axon ACP DAW88     | 1.0.0.x   | 0101, 1711, 2111                                                 |
| Axon ACP DBD18     | 1.0.0.x   | 0101, 0201, 0302, 0402, 0403, 0503                               |
| Axon ACP DBD28     | 1.0.0.x   | 0905                                                             |
| Axon ACP DBE08     | 1.0.0.x   | 1417, 1418, 1518                                                 |
| Axon ACP DDE51C    | 1.0.0.x   | 0810                                                             |
| Axon ACP DDP24     | 1.0.0.x   | 0605                                                             |
| Axon ACP DDP84     | 1.0.0.x   | 0903, 0904                                                       |
| Axon ACP DDP94     | 1.0.0.x   | 0506                                                             |
| Axon ACP DEE28     | 1.0.0.x   | 0807                                                             |
| Axon ACP DIO88     | 1.0.0.x   | 0206                                                             |
| Axon ACP DLA41     | 1.0.0.x   | 2213                                                             |
| Axon ACP DLA42     | 1.0.0.x   | 1811                                                             |
| Axon ACP DSF66     | 1.0.0.x   | 0502, 0702                                                       |
| Axon ACP GAW300    | 1.0.0.x   | 1917                                                             |
| Axon ACP GDB400    | 1.0.0.x   | 1416                                                             |
| Axon ACP GDB990    | 1.0.0.x   | 1416                                                             |
| Axon ACP GDK100    | 1.0.0.x   | 1011                                                             |
| Axon ACP GDR26     | 1.0.0.x   | 0700                                                             |
| Axon ACP GDR108    | 1.0.0.x   | 0500, 0600, 0800                                                 |
| Axon ACP GDR216    | 1.0.0.x   | 0600, 0800                                                       |
| Axon ACP GDR416    | 1.0.0.x   | 0100, 0200, 0300                                                 |
| Axon ACP GDS110    | 1.0.0.x   | 6893, 7499                                                       |
| Axon ACP GEB800    | 1.0.0.x   | 1820                                                             |
| Axon ACP GED100    | 1.0.0.x   | 3128                                                             |
| Axon ACP GEE200    | 1.0.0.x   | 0807                                                             |
| Axon ACP GEP100    | 1.0.0.x   | 3128                                                             |
| Axon ACP GFS010    | 1.0.0.x   | 6038, 6042                                                       |
| Axon ACP GFS100    | 1.0.0.x   | 6034, 6038, 6040, 6246                                           |
| Axon ACP GFS110    | 1.0.0.x   | 6034, 6038, 6040                                                 |
| Axon ACP GFT80     | 1.0.0.x   | 0701                                                             |
| Axon ACP GIX110    | 1.0.0.x   | 1010, 1113, 1515, 1616, 1925                                     |
| Axon ACP GJA420    | 1.0.0.x   | 0706                                                             |
| Axon ACP GNS600    | 1.0.0.x   | 1407, 2109                                                       |
| Axon ACP GPD100    | 1.0.0.x   | 2522, 3128                                                       |
| Axon ACP GRB100    | 1.0.0.x   | 0811                                                             |
| Axon ACP GRB550    | 1.0.0.x   | 1413                                                             |
| Axon ACP GRB990    | 1.0.0.x   | 1413                                                             |
| Axon ACP GXG010    | 1.0.0.x   | 6893, 7499, 7509                                                 |
| Axon ACP GXG110    | 1.0.0.x   | 6893, 7499, 7713                                                 |
| Axon ACP GXG400    | 1.0.0.x   | 0606                                                             |
| Axon ACP HAF900    | 1.0.0.x   | 0505                                                             |
| Axon ACP HAS20     | 1.0.0.x   | 1415                                                             |
| Axon ACP HDB20     | 1.0.0.x   | 0711, 0713, 0814, 0816                                           |
| Axon ACP HDK200    | 1.0.0.x   | 0915                                                             |
| Axon ACP HDR07     | 1.0.0.x   | 0200, 0300, 0400                                                 |
| Axon ACP HDR09     | 1.0.0.x   | 0400                                                             |
| Axon ACP HDS10     | 1.0.0.x   | 2627                                                             |
| Axon ACP HDV080    | 1.0.0.x   | 1010                                                             |
| Axon ACP HES20     | 1.0.0.x   | 0607                                                             |
| Axon ACP HFS010    | 1.0.0.x   | 6034, 6040                                                       |
| Axon ACP HFS100    | 1.0.0.x   | 6040                                                             |
| Axon ACP HIX010    | 1.0.0.x   | 1010, 1011, 1113, 1616, 1718                                     |
| Axon ACP HIX100    | 1.0.0.x   | 1925                                                             |
| Axon ACP HLD120    | 1.0.0.x   | 1515, 1920, 2019                                                 |
| Axon ACP HLI20     | 1.0.0.x   | 2009, 2210, 2310, 2511, 2611, 2711, 2911, 3011, 3111, 3112       |
| Axon ACP HLI100    | 1.0.0.x   | 1508                                                             |
| Axon ACP HNS400    | 1.0.0.x   | 1218                                                             |
| Axon ACP HRB100    | 1.0.0.x   | 0811                                                             |
| Axon ACP HSI10     | 1.0.0.x   | 1516                                                             |
| Axon ACP HSU10     | 1.0.0.x   | 2322, 2324                                                       |
| Axon ACP HVD10     | 1.0.0.x   | 0608, 1315                                                       |
| Axon ACP HXH40     | 1.0.0.x   | 1824, 1926                                                       |
| Axon ACP HXT100    | 1.0.0.x   | 7350                                                             |
| Axon ACP HXT150    | 1.0.0.x   | 8163                                                             |
| Axon ACP MGG200    | 1.0.0.x   | 1614                                                             |
| Axon ACP SDN08     | 1.0.0.x   | 0800, 0900                                                       |
| Axon ACP SDR08     | 1.0.0.x   | 0500, 0600, 0800, 0900, 1000                                     |
| Axon ACP SDR09     | 1.0.0.x   | 0600                                                             |
| Axon ACP SDR108    | 1.0.0.x   | 0900                                                             |
| Axon ACP SLD100    | 1.0.0.x   | 1512                                                             |
| Axon ACP SLD120    | 1.0.0.x   | 1210, 1512, 1913                                                 |
| Axon ACP SSD20     | 1.0.0.x   | 0400, 0500                                                       |
| Axon ACP SVD10     | 1.0.0.x   | 0707                                                             |
| Axon ACP U4D100    | 1.0.0.x   | 1014, 1215, 1316, 1417, 1418                                     |
| Axon ACP U4T100    | 1.0.0.x   | 0406, 0914, 1017, 1320, 1321, 2028, 2230, 2233                   |
| Axon ACP U4T140    | 1.0.0.x   | 0510, 0611, 0712, 1017, 1321, 1424, 2028, 2129, 2230, 2233, 2435 |
| Axon ACP U4T200    | 1.0.0.x   | 2129, 2233                                                       |
| Axon ACP U4T240    | 1.0.0.x   | 1525                                                             |
| Axon ACP UXU410    | 1.0.0.x   | 1720                                                             |

## Configuration

### Connections

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td><h4 id="serial-main-connection">Serial Main connection</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: Does not need to be configured. By default, this is set to the fixed IP port <strong>2071</strong>.</li>
</ul></li>
</ul>
<h4 id="serial-broadcast-connection">Serial Broadcast connection</h4>
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: Has to be configured as the fixed value "<strong>any</strong>".</li>
<li><strong>IP port</strong>: Does not need to be configured. By default, this is set as the fixed IP port <strong>2071</strong>.</li>
<li><strong>Bus Address</strong>: The bus address needs to be set to "<strong>any</strong>". This is necessary to be able to retrieve information about all inserted cards.</li>
</ul></li>
</ul></td>
</tr>
</tbody>
</table>

## Usage

### Overview

The **Overview** table provides an overview of the device configuration. More specifically, it indicates which device type and firmware is inserted in which slot of the frame.
For each detected device, you can change the following settings:

- **Refresh**: Refresh all data for the device type inserted in the corresponding slot, depending on the firmware.
- **Element Name**: If you change the Element Name, the name of any corresponding child element will be changed. However, if there already is a DataMiner element that uses the inserted value, the configuration will not be executed.
- **Element View**: If you change the Element View, the corresponding child element will be moved to the specified DataMiner view. However, if no DataMiner view can be found that corresponds to the inserted value, the configuration will not be executed.
- **Element Export**: With this setting, you can select whether creation of a corresponding element is allowed, regardless of other element reflection settings.
- **Reflect**: This button will execute the reflection algorithm for the corresponding element.

The **Card Settings** subpage provides an overview of all the supported device types within the protocol. This list is shown in the **Protocols** table. You can populate this table by clicking Refresh Protocols. This should be done each time a new connector version or a completely new connector is uploaded. The table will read out the relevant properties to populate the table. The table is also used as a reference to create the element based on the polled firmware version.

The **Insert Card** subpage can be used to insert an existing card element into the frame manager and update the connected DataMiner ID in the inserted card. The inserted card must have the IP address and bus address of the location where the card is inserted. The card element must also be on the same DataMiner Agent in the DataMiner System as the frame element.

### Frame

This page provides an overview of the frame's generic information, such as **Card Name**, **SW Rev.**, **HW Rev.**, **Serial Number**, etc.

On the subpages, such as **Status**, **PSU**, **FAN**, **MIB**, **Network** and **Alarm Priority**, you can find the related frame status and/or configuration parameters.

### Element Reflection

Element reflection determines how the element setup in DataMiner mirrors the actual device setup.

In some cases, inconsistencies between the device setup and the DataMiner element setup can occur.
For example, when a card is removed from a frame because of a hardware malfunction, if the related DataMiner element were to be removed as well, this would result in the loss of all trend and alarm information that has been stored for that element.
However, if the child element is not removed, an inconsistency occurs between the device and the setup in DataMiner.

Situations like this, where potential inconsistencies occur between the device setup and the element setup, are handled by element reflection based on a number of settings that can be defined by the user. The section below provides an overview of these settings and of the element reflection logic.

#### Device Overview

The **Overview** table provides an overview of the device configuration and displays the **Reflect Status** that results from the element reflection algorithm.

For each device, you can select whether creation of a corresponding element is allowed, regardless of other settings.

The **Reflect Status** for each device can be the following:

- *Ok*: The DataMiner setup reflects the device setup.
- *Detected*: The corresponding device type is not supported in the protocol.
- *Changed*: The device type has been changed since the last polling.
- *Removed*: The device has been removed since the last polling.
- *Error*: It is not possible to create the corresponding element.

#### Element Configuration Modes

Depending on the selected mode and on the other configuration settings, the element reflection algorithm will have a different result.

Three modes are available:

- **Manual (default):**

  - When a new device is added, the corresponding element will be created if the configuration settings allow it.

  - When a device is replaced by a device of a different type:

    - The existing element will be deleted if the configuration settings allow it.
    - A new element will be created if the configuration settings allow it.

  - When a device is removed, the existing element will not be deleted.

- **Semi-automatic:**

  - When a new device is added, the corresponding element will be created if the configuration settings allow it.

  - When a device is replaced by a device of a different type:

    - The existing element will be deleted.
    - A new element will be created if the configuration settings allow it.

  - When a device is removed, the existing element will not be deleted.

- **Automatic:**

  - When a new device is added, the corresponding element will be created if the configuration settings allow it.

  - When a device is replaced by a device of a different type:

    - The existing element will be deleted.
    - A new element will be created if the configuration settings allow it.

  - When a device is removed, the existing element will be deleted.

#### Element Export Settings

The protocol contains a table with an overview of all the supported device types.

By changing the **State** for a specific device type, you can determine whether an element can be created for this device type.

- *On (default)*: Element creation is allowed for this device type.
- *Off*: Element creation is not allowed for this device type.
- *NA*: The setting cannot be changed, as it is embedded in the core logic of the protocol. This can for instance be because the device type is supported in the protocol.

#### Reflect (All)

After the configuration of the device is initiated via polling, the element reflection algorithm is run.

However, if changes have been implemented, you may want to run the element reflection algorithm again without waiting for the timer that controls polling.
In that case, by using the **Reflect** or **Reflect All** buttons, you can run the algorithm for one device or for all detected devices, respectively.
