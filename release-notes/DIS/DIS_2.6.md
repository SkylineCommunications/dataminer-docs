---
uid: DIS_2.6
---

# DIS 2.6

## New features

### IDE

#### Table editor: 'All Columns' section now has a 'Foreign Key' column \[ID_16305\]

In the table editor, the *All Columns* section now has a *Foreign Key* column. In this column, you can select another table to which you want a particular table column to be linked.

The table you select will be specified in the “foreignKey=” option of the \<ColumnOption> tag in question.

Default setting: “None”

> [!NOTE]
> In an index column, it is not possible to specify a foreign key. Hence, the selection box in the *Foreign Key* column will be unavailable.

#### Protocol editor: Automatic linking of read and write parameters \[ID_16391\]

Next to certain parameters, you find a button in the shape of a paper clip. When you hover over this paper clip, a list box will appear, listing all items that are in some way linked to the parameter in question. From now on, in case of a read parameter with an associated write parameter, that list box will also contain a reference to the write parameter (and vice versa).

Also, when you click a write parameter in the Protocol Tree window (i.e. a parameter marked with “\[W\]”), then the associated read parameter will appear in the “linked items” list box at the bottom.

#### Table editor: Buttons to automatically adjust column widths \[ID_16415\]

When you open the table editor, DIS will check whether there are columns that are too narrow for their description to fit. If this is the case, then you can do the following:

- Click the drop-down button next to the warning sign at the top of the *Tables* section, and select *Fix Column Widths* to automatically adjust the widths of all columns that are too narrow.
- In the *Displayed Columns Layout* section, click the red *Fix* button in the *Width* column of a particular table column to automatically adjust the width of that column.

> [!NOTE]
> Hidden columns, i.e. columns of which the width was set to 0, are ignored.

## Changes

### Enhancements

#### MIB browser: Enhancements \[ID_16226\]

A number of improvements have been made to the MIB browser, especially with regard to the way in which table index information is displayed in the MIB tree and the way in which table parameters are generated based on MIB data.

#### Table editor: Unrecognized ColumnOption types will no longer be updated automatically \[ID_16554\]

In the table editor, ColumnOption types unknown to DIS will no longer be updated automatically. From now on, when DIS encounters an unknown ColumnOption type, it will display a warning.

### Fixes

#### Display editor: Problem when dragging a parameter to a page with an empty left-hand column \[ID_16294\]

In some cases, an exception could be thrown when you dragged a parameter to a page of which the left-hand column was empty. This problem has now been fixed.

#### QAction editor: Problem with synchronization of a QAction C# project linked to a protocol.xml file \[ID_16503\]

In some rare cases, a QAction C# project linked to a protocol.xml file would no longer be synchronized correctly. Changes made to the QAction would be applied incorrectly in the protocol.xml file and vice versa. This problem has now been fixed.

#### Protocol editor: Problem when unselected a pair in a \<Command> tag \[ID_16508\]

When you unselect a pair in the *Include in Pair* shortcut menu item of a command, the command will automatically be removed from the pair. In some cases, however, when a command was removed from a pair, part of the \<Content> tag of that pair was incorrectly removed as well. When you subsequently tried to add the command again, an exception could occur. This problem has now been fixed.
