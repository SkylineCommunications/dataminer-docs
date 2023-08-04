---
uid: Managing_the_Router_Control_configurations
---

# Managing the Router Control configurations

## Creating a completely new Router Control configuration

1. Go to the middle pane, and click the “+” box to add a configuration tab page next to the “Default” tab.

1. In the *Add Configuration* box, enter the name of the new Router Control configuration, and click *OK*.

1. To the configuration, add the necessary matrix tab pages. See [Designing a matrix tab page in the Router Control module](xref:Designing_a_matrix_tab_page_in_the_Router_Control_module).

1. Click *Backup* to save the configuration to a compressed XML file on the client machine, or click *Upload* to upload the current configuration to the DMS.

## Changing the design of an existing Router Control configuration

1. Go to the middle pane, and click a configuration tab (either “Default” or one of the custom configurations).

1. Make the necessary modifications to the matrix tab pages of the selected configuration. See [Designing a matrix tab page in the Router Control module](xref:Designing_a_matrix_tab_page_in_the_Router_Control_module).

1. Click *Backup* to save the configuration to a compressed XML file on the client machine, or click *Upload* to upload the current configuration to the DMS.

## Editing the global theme of the Router Control module

1. Go to the middle pane, right-click any tab representing a configuration, and select *Edit global theme*.

1. In the *Edit global theme* dialog box, enter the theme’s XML code (Router Control themes are XAML resource dictionaries), and click *OK*.

   If syntax errors are detected, a message will appear at the bottom of the dialog box. Click the message to see more information on those errors.

> [!NOTE]
> Router Control themes can be specified on three levels: on global level (i.e. the entire Router Control module), on configuration level, and on matrix level. Themes defined on a higher level are inherited by lower levels, and themes defined on a lower level override the ones defined on a higher level.

## Editing the custom theme of a Router Control configuration

1. Go to the middle pane, right-click the tab representing the configuration of which you want to edit the theme, and select *Edit custom theme*.

1. In the *Edit custom theme* dialog box, enter the theme’s XML code (Router Control themes are XAML resource dictionaries), and click *OK*.

   If syntax errors are detected, a message will appear at the bottom of the dialog box. Click the message to see more information on those errors.

> [!NOTE]
> Router Control themes can be specified on three levels: on global level (i.e. the entire Router Control module), on configuration level, and on matrix level. Themes defined on a higher level are inherited by lower levels, and themes defined on a lower level override the ones defined on a higher level.

## Deleting a Router Control configuration

1. Go to the middle pane, right-click the tab representing the configuration you want to delete (either “Default” or one of the custom configurations), and select *Delete*.

1. In the confirmation box, click *OK*.

## Renaming a Router Control configuration

1. Go to the middle pane, right-click the tab representing the configuration you want to rename (either “Default” or one of the custom configurations), and select *Rename*.

1. In the *Rename Configuration* box, enter the new name, and click *OK*.
