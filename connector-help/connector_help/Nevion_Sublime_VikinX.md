---
uid: Connector_help_Nevion_Sublime_VikinX
---

# Nevion Sublime VikinX

The Nevion Sublime VikinX connector enables seamless integration and control of Nevion Sublime VikinX devices within a larger system. It provides a comprehensive interface to manage and monitor the functionalities of the Sublime VikinX devices, facilitating efficient media transport and routing.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *4381*).
  - **Bus address**: The bus address of the device.

## How to use

The **General** page provides configuration options for the displayed matrix. You can define the **number of inputs and outputs** here. The maximum number of inputs and outputs that can be configured is 32. If the response received from the device does not match the configured settings, a warning will be displayed.

On the same page, you can also select the **type of view** you prefer for the device. The following options are available:

- *Matrix*: This option removes the Table View page and displays only the matrix itself, showcasing all the crosspoints within it.
- *Table*: This option removes the Matrix View page and shows two tables, one for inputs and another for outputs, containing comprehensive information about each input and output.
- *Matrix and Table*: This option includes both the Matrix View and Table View pages.

The **Matrix View** page visualizes the device connections by means of a matrix. Each square in the matrix corresponds to a connection between an input and an output. A black square indicates an active connection.

To **establish a connection**, click the desired square. You will then have to confirm that you indeed want to create the connection.

You can also **lock specific inputs or outputs**, preventing further editing of the connection. To lock an input or output, right-click the corresponding label and select **Lock**. When an input or output is locked, its squares will be grayed out, and a lock symbol will be displayed next to the label. To unlock, right-click the label and select **Unlock**.

The **names/labels of inputs and outputs** can also be customized. To do so, right-click the matrix and select **Edit**. This will open a window with three different sections. In the inputs and outputs section, you can modify the input and output names, while in the layout section you can adjust the positioning of both outputs and inputs.

The **Table View** page offers the same functionalities for changing the state and connections. To modify a connection, edit the corresponding row in the table for the desired output or input. To add a new connection, click the pencil icon in the **Connected Input** column of the output table and add or remove the desired input numbers.
