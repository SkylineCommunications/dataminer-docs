---
uid: Designing_a_matrix_tab_page_in_the_Router_Control_module
---

# Designing a matrix tab page in the Router Control module

This section consists of the following topics:

- [Adding a matrix to a configuration tab page](#adding-a-matrix-to-a-configuration-tab-page)

- [Adding a matrix represented by two table parameters](#adding-a-matrix-represented-by-two-table-parameters)

- [Creating a dynamic tab control](#creating-a-dynamic-tab-control)

- [Adding a component to a matrix tab page](#adding-a-component-to-a-matrix-tab-page)

- [Configuring a component on a matrix tab page](#configuring-a-component-on-a-matrix-tab-page)

- [Deleting a component from a matrix tab page](#deleting-a-component-from-a-matrix-tab-page)

- [Moving a component on a matrix tab page](#moving-a-component-on-a-matrix-tab-page)

- [Attaching a matrix tab page to another matrix element](#attaching-a-matrix-tab-page-to-another-matrix-element)

- [Editing the custom theme of a matrix tab page](#editing-the-custom-theme-of-a-matrix-tab-page)

- [Deleting a matrix tab page](#deleting-a-matrix-tab-page)

## Adding a matrix to a configuration tab page

1. Select the configuration by clicking its tab to the right of the “Default” tab.

1. In the top-left corner, click the “+”.

1. In the *Add matrix* dialog box, specify the matrix parameter you want to add to the configuration:

   1. In the *Name* box, enter the name of the matrix.

   1. Next to *Select matrix*, select the matrix parameter.

      Alternatively, you can configure a custom matrix in the *Advanced Configuration* section. The custom matrix is represented by 2 table parameters, instead of a matrix type parameter. See [Adding a matrix represented by two table parameters](#adding-a-matrix-represented-by-two-table-parameters).

   1. Next to *Layout*, specify whether you want to start with a pre-built default configuration (*General Default*) or an empty canvas (*Empty*).

   1. Optionally, to hide the matrix in the live overview, clear the selection from *Visible*.

      > [!NOTE]
      > This option can be useful to temporarily hide a new layout you are working on, or to hide a matrix tab instead of deleting it. You can always change the setting afterwards by right-clicking the tab header and selecting *Edit*. This will open the *Edit matrix* dialog box, with the same options as the *Add matrix* dialog box.

   1. Optionally, clear the selection from *Use output-first workflow.* When you do so, selecting an output will leave the current input selection intact. By default, the option is selected, so that selecting an output will replace the current input selection with the input that is connected to that output.

   1. Optionally, select *Override matrix labels with custom descriptions on I/O buttons*. If you do so, any custom descriptions that have been put on I/O buttons will be shown instead of the labels of the matrix inputs/outputs

   1. Optionally, select *Confirm crosspoints sets*, to enable confirmation messages when a crosspoint is set (available from DataMiner 9.5.13 onwards).

   1. Optionally, select *Direct take mode* (available from DataMiner 10.1.11/10.2.0 onwards). If this option is select, users will not need to click the *Connect* button to create or delete a crosspoint between an input and an output. When an input and an output are selected, these will automatically be connected or disconnected.

      > [!NOTE]
      > When you use direct take mode in combination with the “Use output-first workflow” option, selecting an output will not cause crosspoints to be created or deleted, and input selections will only be cleared when you select another output.

   1. Click *OK*.

> [!TIP]
> See also: [Creating a completely new Router Control configuration](xref:Managing_the_Router_Control_configurations#creating-a-completely-new-router-control-configuration)

## Adding a matrix represented by two table parameters

The Router Control module also supports matrices that are represented by two table parameters, i.e. an input and an output table, instead of a matrix parameter. This can improve performance for large matrices (512x512 and more). However, in this case an output cannot be connected to more than one input at a time.

In order to add such a matrix, do the following:

1. Add a matrix like in the procedure above, until you get to the *Advanced Configuration* section.

1. Open the *Advanced Configuration* section.

1. Enter the following syntax in the *Custom matrix* box:

   ```txt
   dmaid/elementid;inputs=tablepid,indexpid,labelpid,enabledpid,lockedpid,notespid;outputs=tablepid,indexpid,labelpid,enabledpid,lockedpid,notespid,connectedinputpid
   ```

   For example:

   ```txt
   34/505527;inputs=1000,1001,1002,1003,1004,1005;outputs=2000,2001,2002, 2003,2004,2005,2006
   ```

1. Optionally (from DataMiner 9.6.4 onwards), in the *Input filter* and *Output filter* boxes, specify a subscription filter as follows:

   - All column parameters except the table index column must be part of the relevant subscription filter. Column parameters from the input table must be part of the input filter, column parameters from the output table must be part of the output filter.

   - It is also possible to filter on rows and add additional column parameters.

   - The subscription filter syntax must be used as detailed in [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

1. Continue in the same manner as when adding a regular matrix. See [Adding a matrix to a configuration tab page](#adding-a-matrix-to-a-configuration-tab-page).

Note that the input and output tables must have at least the following read and write columns:

| Column | Description |
|--|--|
| Index | Primary key, i.e. a 1-based sequential numbering of inputs/outputs. |
| Label | Text to be displayed. |
| IsEnabled | Whether or not this input/output is currently enabled (Boolean: 0 or 1). |
| IsLocked | Whether or not this input/output is currently locked (Boolean: 0 or 1). |
| Notes | Extra information. |
| ConnectedInput | Foreign key linking to the inputs table. (Only required for the output table) |

## Creating a dynamic tab control

From DataMiner 9.0.5 onwards, when you have added a tab page representing a particular matrix, you can configure it so that a tab page will automatically be created for every input page or for every output page in the matrix.

To do so:

1. Select a tab control on the matrix tab page

   Make sure you have selected the complete tab control, and not one of the tab pages (if any). The easiest way to do this is by selecting the appropriate *TabControl* in the tree view on the right. Below the tree view panel, below *Grid Position*, the option *Link to pages* will be displayed.

1. Select *Link to pages*, and select whether the tab control should link to *Input pages* or *Output pages*.

> [!NOTE]
> Once the matrix configuration has been loaded, no tab pages will be changed when pages are added to or removed from the linked matrix.

## Adding a component to a matrix tab page

In the left-hand pane, click one of the following components, and drag it onto an empty spot in the middle pane.

| Component | Description |
|--|--|
| Border | A frame in which you can place other components. |
| Label | A fixed piece of text. |
| Grid | A grid made up of a number of rows and columns in which you can place other components. |
| TabControl | A tab control. |
| TogglePanel | A panel that the user can either enable or disable. |
| ExpandingPanel | A panel that can be collapsed and expanded. |
| I/O | A box that represents an input or an output of a matrix. |
| Action | A button to which you can assign one of the following actions:<br> - Connect an input to an output.<br> - Disconnect an input from an output.<br> - Lock/unlock an output.<br> - Undo the latest connect or disconnect action (if any). |
| InfoPanel | A panel showing information about<br> - the selected input<br> - the selected output<br> - the routed outputs |
| Timer | A timer that starts whenever an output is selected, and automatically clears the current input/output selection after a period of time (default: 60 seconds) |
| Visio | A panel that contains the Visio drawing of a DataMiner view. |

## Configuring a component on a matrix tab page

1. Select the component, or hover over the component and click the green cogwheel in the top-right corner.

1. In the properties pane in the lower right corner, make the necessary changes to the properties of the component.

> [!TIP]
> See also: [Overview of user interface component properties](xref:Overview_of_user_interface_component_properties)

## Deleting a component from a matrix tab page

1. Hover over the component and click the X in the top-left corner.

1. In the confirmation box, click *OK*.

## Moving a component on a matrix tab page

1. Hover over the component and move your cursor onto the four-way arrow.

1. Click the four-way arrow and drag the component onto its new location.

## Attaching a matrix tab page to another matrix element

1. Right-click the tab, and click *Edit...*

1. In the *Edit Matrix* dialog box, open the *Link With Matrix* selection box, and select the matrix element that you want to attach to the matrix tab page.

   > [!NOTE]
   > If you select a matrix that is smaller that the one that was attached, a warning message will appear.

1. If you want to rename the tab page, then click inside the *Name* box, and enter a new name.

1. Click *OK*.

## Editing the custom theme of a matrix tab page

1. Right-click the tab, and click *Edit custom theme...*

1. In the *Edit custom theme* dialog box, enter the theme’s XML code (Router Control themes are XAML resource dictionaries), and click *OK*.

   If syntax errors are detected, a message will appear at the bottom of the dialog box. Click the message to see more information on those errors.

> [!NOTE]
> Router Control themes can be specified on three levels: on global level (i.e. the entire Router Control module), on configuration level, and on matrix level. Themes defined on a higher level are inherited by lower levels, and themes defined on a lower level override the ones defined on a higher level.

## Deleting a matrix tab page

1. Right-click the tab, and click *Delete*

1. In the confirmation box, click *OK*.
