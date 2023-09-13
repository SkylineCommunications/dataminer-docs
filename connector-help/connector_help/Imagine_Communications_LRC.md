---
uid: Connector_help_Imagine_Communications_LRC
---

# Imagine Communications LRC

This smart-serial connector can be used to manage an Imagine Communications Logical Router Control device. It uses Imagine Communications' LRC protocol to control the crosspoints of LRC-compatible devices. The matrix, which can consist of up to 4096 inputs by 4096 outputs, also shows the labels available on the device.

The polling of the information via LRC should only happen:

- At startup.
- Upon database changes.
- After a timeout situation.

In all other situations, the element should only listen for updates from LRC and adjust the information shown accordingly. The LRC updates will contain all the required information.

The connector requires .NET Framework 4.0 or higher, as it needs System.Web.Extensions.dll.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                | **Based on** | **System Impact**                                                                                                          |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                                                                                                 | \-           | \-                                                                                                                         |
| 1.0.1.x \[Obsolete\] | Larger matrix size, 1024x1024.                                                                                                                                                  | \-           | \-                                                                                                                         |
| 1.0.3.x              | Larger matrix size, 2048x2048.                                                                                                                                                  | 1.0.1.8      | Saved labels can get shifted when the number of inputs changes. The output labels can appear as input labels in this case. |
| 2.0.0.x              | Matrix with filtering capabilities.                                                                                                                                             | \-           | \-                                                                                                                         |
| 2.0.1.x \[SLC Main\] | Adds HTTP connection to support SDNO Controller REST API. Further development on the REST API should be implemented on the **Imagine Communications Magellan SDNO Controller**. | \-           | \-                                                                                                                         |

### Product Info

| **Range** | **Supported Firmware**                                  |
|-----------|---------------------------------------------------------|
| 1.0.0.x   | LRC 1.2, 1.3 & 1.4                                      |
| 1.0.1.x   | LRC 1.2, 1.3 & 1.4                                      |
| 1.0.3.x   | LRC 1.2, 1.3 & 1.4                                      |
| 2.0.0.x   | LRC 1.2, 1.3 & 1.4                                      |
| 2.0.1.x   | LRC 1.2, 1.3 & 1.4 REST API SDNO Controller version 1.3 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |
| 2.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 2.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Default: *52116*.
  - **Bus address**: The matrix level to be polled from the device. Range: *1* to *16*.

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: Default 80
- **Bus address**: *Bypassproxy.*

## Usage

### General

This page shows the **LRC Protocol Version**. For full compatibility with the current connector, this should be *1.2*.

The **Channels** table lists the available channels (levels) on the device. The DataMiner element **only polls** **one level** of the device, depending on the specified **bus address**.

### Matrix

The matrix on this page shows all the crosspoints on the device. The labels from the device are also available, but changes are not synchronized to the device.

### Matrix Configuration

This page shows the parameters **Matrix Inputs Regex** and **Matrix Outputs Regex**. These can be used to specify which inputs and outputs should be shown in the matrix. Regex example: *^SRC \[0-9\]+\$*.

### Configuration

By default, the matrix size is detected automatically. You can also configure it manually by setting the **Matrix** **Resize Method** to *Manual* and specifying the **Number of Inputs Visible** and **Number of Outputs Visible**.

This page also shows the **Label Policy** and **Lock Policy**. For more information on these parameters, refer to "Labels" and "Locks" below.

The **User Identifier** is a value (integer) needed to authorize some actions. Its main use is to lock or unlock outputs with that identifier.

### Labels

Both **Input Labels** and **Output Labels** are listed. The **Matrix Label** column contains the labels shown in the matrix and allows you to edit them directly. The **Labels Equality** column indicates if both labels are the same for ease of use.

Since the LRC API does not allow labels to be set, they can only be synchronized from the device to the matrix. This can happen automatically and comes with the following **Label Policy** settings:

- *Block Incoming Updates*: Polled labels will still be stored in the element, but not sent to the matrix object. This way, changes made to the element's matrix will never be overwritten.
- *Force Equality*: Label changes from the device will be forwarded to the matrix. Changes made on the element's matrix object will be reverted, so they always equal those of the device.
- *Forward Updates to Matrix*: Polled labels will be set on the element's matrix object when they are first polled from the device or when they change. Local values will be lost after element restart, so this is the least recommended option.

### Locks

The **Output Locks** reflect the lock state of the output interfaces of the matrix. The LRC API only allows output interfaces to be locked. Locks can be sent to the device, so both **State** and **Matrix State** can be toggled and synchronized to both *Matrix* and *Device*.

The **User ID** column shows the owner of a lock. Only the owner can unlock the output.

The following settings in **Lock Policy** determine how the lock state is synchronized with the device:

- *Block Incoming Updates*: Polled locks will still be stored in the element, but not sent to the matrix object or the device. This way, changes made to the element's matrix will never be overwritten.
- *Forward Updates Bidirectionally*: This element's matrix object will have the same output locks as the device. Updates from the device are set on this matrix, and updates on this matrix will be sent to the device. Note that if a request is sent to the device but fails or if the device's response fails, there may be a difference between the element matrix and the device.
- *Forward Updates to Matrix*: Polled locks will be set on the element's matrix object when they are first polled from the device or when they change. Changes made on the element will not be sent to the device. Local values will be lost after element restart, so this is the least recommended option.

### Inputs

This page displays the **Inputs** table, listing all the inputs available in the device.

Note that this page is only available in the **2.0.0.x** branch.

### Outputs

This page displays the **Outputs** table, listing all the inputs available in the device.

Note that this page is only available in the **2.0.0.x** branch.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

### Interfaces

#### Dynamic interfaces

The matrix (parameter ID 100) will create the following interfaces:

- Matrix inputs will create interfaces of type *in* named *Interface In*.
- Matrix outputs will create interfaces of type *out* named *Interface Out*.

### Connections

#### Internal Connections

- Connections are made automatically between **Interface In** and **Interface Out** when these interface are connected.
