---
uid: DisMibBrowserToolWindow
---

# DIS MIB Browser

If you click *Tool Windows > DIS MIB Browser*, the *DIS MIB Browser* window will appear.

This tool window allows you to build [Param](xref:Protocol.Params.Param) tags based on OID data in MIB files.

By default, the *DIS MIB Browser* window will open undocked. Dock it just as you would dock any other tool window in Microsoft Visual Studio.

> [!NOTE]
> The MIB Browser currently supports adding parameters of type Gauge32, Integer, Integer32, TimeTicks and Unsigned32.

![DIS MIB browser tool window](~/develop/images/DisMibBrowserToolWindow.png)

## MIB tree

The *MIB Tree* tab shows a graphical representation of all loaded MIB files.

To automatically create a [Param](xref:Protocol.Params.Param) tag based on a particular OID in the MIB tree, drag the OID onto an open protocol XML file and, if necessary, modify the imported data (which will be highlighted).

> [!NOTE]
>
> - When you drag a table parameter from the *DIS MIB Browser* tool window onto a *protocol.xml* file, the table name will only be added in front of the name of the column parameter when it is not already included in the latter. Also, when the SNMP name of a table contains "Table", this string will be excluded from column parameters names and descriptions. This will prevent table names from being included twice in column parameter names.
> - In the MIB tree, obsolete, deprecated, and duplicate MIB nodes are indicated by a special icon.

## Files

The *Files* tab allows you to load MIB files into the MIB tree.

1. For every MIB file you want to load into the MIB tree, click *Add*, locate and select the file, and click *Open*.

1. If, for any reason, the list contains a MIB file that does not have to be loaded into the MIB tree, then clear the *Active* checkbox in front of it.

1. Click *Load Files* to load the listed MIB files into the MIB tree.

   When not all MIB files could be loaded, an error message will be shown.

When you want to remove files from the list, select them and click *Remove*. To select more than one file, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive files, click the first one in the list and then click the last one while holding down the SHIFT key.

The bottom half of the *Files* tab contains three sections:

| Section | Contents |
|---------|----------|
| *Loaded Modules* | All MIB modules that are currently loaded into the MIB tree.<br> Note: A number of modules are loaded by default and will therefore always be listed in this section. |
| *Pending Modules* | All MIB modules that cannot be loaded because they contain references to other MIB modules that cannot be found. |
| *Missing Modules* | All MIB modules that cannot be found. |

> [!NOTE]
>
> - The location of the MIB store and other MIB browser settings can be specified in the *MIB* tab of the *DIS Settings* window. See: [MIB](xref:DIS_settings#mib)
> - The MIB browser allows you to import files with the following extensions: *mib*, *smi*, and *txt*.
> - DIS by default contains most common IANA and IETF MIB files. These MIB files contain common definitions that are often used in MIB files supplied by equipment vendor.

## Compare

The *Compare* tab shows the differences between the OID data in the MIB tree and the parameter data in the protocol XML file.

- The top pane lists the OIDs that do not have a corresponding *\<Param>* tag in the protocol XML file.

- The bottom pane lists the *\<Param>* tags in the protocol XML file that do not have a corresponding OID in the MIB tree.

At the top of the *Compare* tab, you can find two buttons:

- Click the *Refresh* button to rerun the comparison.

- Click the *Copy to Clipboard* button to copy the results of the latest comparison to the Windows Clipboard.
