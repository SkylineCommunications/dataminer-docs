---
uid: Managing_Automation_scripts
---

# Managing Automation scripts

To manage the Automation scripts in a DMS, you need to open the Automation module (via apps \> *Automation*). When you do so, a card is opened that consists of two panes:

- A pane on the left, where all scripts are represented in a tree view. A search box at the top of the pane allows you to quickly find a particular script.

- A pane with script details on the right, where scripts can be viewed and edited.

  > [!NOTE]
  > The script details can also be viewed in a separate card. To do so, right-click the script and select *Open in new card* or *Open in new undocked card*.

Managing Automation scripts, e.g. adding and deleting scripts or organizing them in folders, is done in the pane on the left:

- [Collapsing and expanding Automation script folders](#collapsing-and-expanding-automation-script-folders)

- [Adding a new Automation script](#adding-a-new-automation-script)

- [Adding a new Automation script folder](#adding-a-new-automation-script-folder)

- [Moving Automation scripts or folders](#moving-automation-scripts-or-folders)

- [Deleting an Automation script or folder](#deleting-an-automation-script-or-folder)

- [Renaming an Automation script folder](#renaming-an-automation-script-folder)

- [Importing and exporting Automation scripts](#importing-and-exporting-automation-scripts)

## Collapsing and expanding Automation script folders

You can collapse or expand folders in the tree view:

- By clicking the triangle in front of the folder.

- By right-clicking the tree view and selecting *Collapse all* or *Expand all*.

- By selecting the folder, clicking the More... button at the bottom of the pane, and selecting *Collapse all* or *Expand all*.

  > [!NOTE]
  > If you select *Collapse all*, the root folder will not be collapsed.

## Adding a new Automation script

To add a new script:

- Select the folder where you want to add the script, and click the *Add script* button at the bottom of the pane, or

- Right-click the folder where you want a new script and select *Add script*.

You can also add a new script by duplicating an existing script and then changing this duplicate as required.

- To duplicate a script, right-click the script and select *Duplicate*.

  Alternatively, you can also select the script, click the More... button at the bottom of the pane, and select *Duplicate*.

> [!NOTE]
> You cannot create two Automation scripts with the same name.

To create a functional new script, you will then need to configure it further. For more information, see [Designing Automation scripts](xref:Designing_Automation_scripts).

## Adding a new Automation script folder

To add a new folder:

- Click the *New Folder* button at the bottom of the pane, or

- Right-click the folder where you want a new folder and select *New folder*.

> [!NOTE]
> If you create a new folder, it will only be saved if a script is added to it. Empty folders are automatically deleted when you close the *Automation* module.

## Moving Automation scripts or folders

To move scripts or folders in the Automation tree view:

- Drag the script or folder and drop it in the new location in the tree view.

## Deleting an Automation script or folder

To delete a script or folder:

- Select the script or folder, and select the *Delete* button at the bottom of the pane, or

- Right-click the script or folder and select *Delete* in the right-click menu.

> [!NOTE]
> When you delete a folder, you delete all scripts in that folder.

## Renaming an Automation script folder

You can change the name of a folder in the following ways:

- Right-click the folder, and select *Rename*.

- Select the folder and press *F2*.

- Select the folder, click the More... button at the bottom of the pane, and select *Rename*.

> [!NOTE]
> From DataMiner version 8.5.2 onwards, it is possible to use a dot in the name of a folder. However, the dot cannot be placed at the beginning or the end of the name.

## Importing and exporting Automation scripts

- To upload a locally stored XML file containing a script and add it to a folder, right-click the folder and select *Import*.

- To download a script as an XML file, right-click the script and select *Export*.

  Alternatively, you can also select the folder or script, click the More... button at the bottom of the pane, and select the *Import* or *Export* option there.

> [!NOTE]
> To import Automation scripts, you need the user permission *Automation: Add*. To export Automation scripts, you need the user permission *Automation: Edit*. See [DataMiner user permissions](xref:DataMiner_user_permissions).
