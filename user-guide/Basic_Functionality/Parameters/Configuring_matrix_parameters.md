---
uid: Configuring_matrix_parameters
---

# Configuring matrix parameters

## Connecting a matrix input and output

1. Click the crosspoint cell of the input and output.

1. Click *Yes* in the confirmation box.

> [!NOTE]
>
> - When the mouse pointer passes over an input, a tooltip will appear indicating what output the input is connected to. The same also goes for outputs.
> - If more than the maximum number of inputs/outputs is connected to an output/input, an error message appears.

## Locking or unlocking a matrix input or output

To lock an input or output:

- Right-click the input or output and select *Lock*.

  > [!NOTE]
  > Inputs and outputs that are locked have gray crosspoints to indicate that they are not available.

To unlock an input or output:

- Right-click the input or output and select *Unlock*.

You can also lock or unlock several inputs or outputs at once:

1. Select several inputs or outputs by pressing Ctrl or Shift while you click.

1. Right-click one of the inputs or outputs and select *Lock all* or *Unlock all*

## Configuring the follow mode for a matrix output

When you enable follow mode for a particular output and set this output as the slave of another output, it will automatically connect to the same input as its master.

To enable follow mode:

1. Right-click the output and select *Enable follow mode*.

1. Right-click the output again and select *Slave of \> \[Output label\]*, or right-click a different output and select *Master of –> \[Output label\]*.

To disable follow mode, right-click an output for which it has been enabled, and select *Disable follow mode*.

You can also enable or disable follow mode for several outputs at once:

1. Select several outputs by pressing Ctrl or Shift while you click.

1. Right-click one of the outputs and select *Enable follow mode (all)* or *Disable follow mode (all)*.

## Disabling or enabling certain matrix inputs or outputs

1. Right-click the matrix parameter and select *Edit*.

1. To disable or enable outputs, go to the *outputs* tab.

1. In the editor window, clear the selection boxes for the inputs or outputs to disable them. To enable the inputs or outputs, select the boxes again.

1. Click *OK*.

## Renaming a matrix input or output

1. Right-click the matrix parameter and select *Edit*.

1. For an output, go to the *outputs* tab.

1. Click the current input or output name in the *description* column, and enter a new name.

1. Click *OK*.

## Specifying the allowed inputs for an output and vice versa

1. Right-click the matrix parameter and select *Edit*.

1. For outputs, go to the *outputs* tab.

1. Select the output or input for which you wish to configure the allowed inputs or outputs, and click the ... button in the *Allowed* column.

1. In the pop-up window, select the allowed inputs or outputs.

   > [!NOTE]
   > At the bottom of the window, you can also click *select all* to select all inputs or outputs, or click *none* to clear the current selection.

## Exporting and importing a matrix configuration

To export a matrix configuration:

1. Right-click the matrix parameter and select *Export to CSV*.

1. Enter a file name, choose a file location and click *Save*.

    This will export the entire matrix configuration: labels, enabled states, locked states, page names, etc.

To import a previously exported matrix configuration file:

1. Right-click the matrix parameter and select *Import from CSV*.

1. Browse to the CSV file with the matrix configuration and click *Open*.

1. In the confirmation box, click *Yes*.

   > [!NOTE]
   > If you import a CSV for a matrix with a different size, a warning message will appear. If you choose to import anyway, the overlapping inputs and outputs will be imported, but the rest will be ignored.

## Saving and loading matrix crosspoints

To save crosspoints:

1. Right-click the matrix parameter and select *Save crosspoints*.

1. Enter a file name and choose which of the outputs you want to save: “all” or a custom selection. By default, the current output selection is suggested.

1. Click *OK*.

To load crosspoints:

1. Right-click the matrix parameter and select *Load crosspoints*.

1. Select a crosspoint file. If no files are available, no crosspoints have been saved.

1. Choose which of the outputs you want to load: “all” or a custom selection.

   A status message will indicate whether the operation succeeded or failed.

> [!NOTE]
> Matrix crosspoint files are saved in the following folder: <br>*C:\\Skyline DataMiner\\Documents\\\[Protocol Name\]\\Backups*.

## Filtering the inputs and outputs in a matrix parameter

To quickly find a particular input or output in a matrix parameter, you can use the filter functionality:

1. Click the magnifying glass icon above the inputs column.

1. To filter the outputs, fill in a piece of text in the *Output* box.

1. To filter the inputs, fill in a piece of text in the *Input* box.

## Working with matrix parameters divided in pages

The inputs and outputs of a matrix parameter can be grouped in pages, with a gray square representing each page in the main view of the matrix. By default, any matrix larger than 64x64 will be divided in pages of 16x16, though this can be defined differently in the protocol.

- Click a gray square representing a page to expand it and see the separate inputs and outputs.

- Click the small gray square above the inputs column to collapse an expanded page.

- If all pages are collapsed, click that same gray square to expand all pages.

  > [!NOTE]
  > If there are more than 1000 inputs and outputs, the button to expand all pages at once is not available.

To organize inputs or outputs on different pages:

1. Right-click the matrix parameter and select *Edit*.

1. For outputs, go to the *outputs* tab.

1. Enter a page name in the *Page* column for each input or output that you want to place on that page.

1. Click *OK*.

## Copying a matrix parameter

To copy a matrix parameter to the clipboard as an image, right-click the matrix and select:

- *Copy expanded pages*, if you want to copy only the expanded pages.

- *Copy all pages*, if you want to copy the entire matrix.
