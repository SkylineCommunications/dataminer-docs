---
uid: Connector_help_Imagine_Communications_SelenioFlex
---

# Imagine Communications SelenioFlex

**SelenioFlex live-to-file ingest** solutions provide efficient multiformat capture and **encoding** from live sources or tapes and **transcoding** from file-based sources. Combining superior output quality, format flexibility and the industry's deepest feature set, the SelenioFlex ingest system is the ideal gateway to **file-based** production and archive workflows and today's vast array of multi-screen distribution opportunities.

This connector can be used to monitor, trend and control the encoder.

## About

The connector uses an **HTTP connection** to communicate with the encoder.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.6                         |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the SNP Manager, starting with the *https://* prefix.
- **IP port**: The IP port of the device, by default *XXXX.*
- **Bus address**: By default *byPassProxy*.

### Configuration

The HTTP connection status can be monitored on the **General** page.

## Usage

### General

This page displays the **HTTP Communication Status**, along with other important device information such as **Manager**, **Zenim**, **Build**, **Time Zone** etc.

### Transcode

On this page, the **Transcode Tasks** table displays information related to the transcode tasks. With the two buttons above the table, you can also **Get All Transcode Tasks** and **Get Job Info**.

### Media Properties

This page contains the **Media Properties** table, with information regarding media properties, and the **All Transcode Media Properties** table, which displays all the transcode media properties.

The **Metadata Video Properties** page button displays four tables with **Meta Data Video Values**, **MXF Metadata Video Values** and their respective **All Transcode** **Video** values.

Similarly, the **Metadata Audio Properties** page button displays four tables with **Meta Data Audio Values**, **MXF Metadata Audio Values** and their respective **All Transcode Audio** values.

### Transcode Settings

This page allows you to configure important transcode settings. You can among others set the task priority by clicking on the **Set Transcode Task Priority** button and changing the **Transcode Task ID for Priority** and the **Priority**. If you click the **Move Snap Shot File** button after you have set parameters such as **New Full Path**, **Move Physical File** etc., you can move the snap shot file.

Via the **Submit Transcode Task** page button you can add video and audio sources to the respective tables. With the buttons **Add Video Source**, **Add Audio Source** and **Submit Transcode Task**, the task can be submitted to the device. In addition to this, various other parameters such as **Transcode Asset ID**, **Transcode Metadata Type** and **Asset Piece ID** can be set on this page.

### Jobs

This page contains **Jobs for Transcode Task** information. Via the **Job Settings** page button, you can set the **Delete Scheduled Job ID** parameter and then delete the scheduled job with the button below the parameter.

### Lists

This page contains several tables with general information regarding the devices: the **Watch Folder List**, **Resource List**, **Project List**, **Agent List** and **Group List** tables.

Via the **Resource Settings** page button, you can set information related to the resource such as the **Resource ID to Group, Group ID, Number of Resources**, etc. You can also **Add Resource to Group, Create Resource On Agent** or **Set Resource Online** by clicking on the respective buttons.

Via the **Group Settings** page button, you can create a group by setting parameters such as **Group Name, Group Resource Name**, etc. and clicking on the **Create Group** button. In addition, you can set up the group runtime environment using the buttons **Set Group Runtime Environment** and **Set Runtime Environment for Group** respectively.

### Asset

This page contains **Asset** **Properties** setup information, including settings such as **Delete Asset ID**, **Asset Properties Metadata Value**, **Add Asset**, **Modify Asset**, **Export Asset**, etc.

## Notes

No web interface is available.
