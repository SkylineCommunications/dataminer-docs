---
uid: DisMibBrowserToolWindow
---

# DIS MIB Browser

This tool window allows you to build [Param](xref:Protocol.Params.Param) tags based on OID data in MIB files.

> [!NOTE]
> The MIB Browser currently supports adding parameters of type Gauge32, Integer, Integer32, TimeTicks and Unsigned32.

![DIS MIB browser tool window](~/develop/images/DisMibBrowserToolWindow.png)

## MIB tree

The *MIB Tree* tab shows a graphical representation of all loaded MIB files.

> [!NOTE]
> In the MIB tree, obsolete, deprecated, and duplicate MIB nodes are indicated by a special icon.

## Files

The *Files* tab allows you to load MIB files into the MIB tree.

The bottom half of the *Files* tab contains three sections:

| Section | Contents |
|---------|----------|
| *Loaded Modules* | All MIB modules that are currently loaded into the MIB tree.<br> Note: A number of modules are loaded by default and will therefore always be listed in this section. |
| *Pending Modules* | All MIB modules that cannot be loaded because they contain references to other MIB modules that cannot be found. |
| *Missing Modules* | All MIB modules that cannot be found. |

> [!NOTE]
>
> - The location of the MIB store and other MIB browser settings can be specified in the *MIB* tab of the *DIS Settings* window. See: [MIB](xref:DIS_settings#mib)
> - DIS by default contains most common IANA and IETF MIB files. These MIB files contain common definitions that are often used in MIB files supplied by equipment vendor.

## Compare

The *Compare* tab shows the differences between the OID data in the MIB tree and the parameter data in the protocol XML file.

- The top pane lists the OIDs that do not have a corresponding *\<Param>* tag in the protocol XML file.

- The bottom pane lists the *\<Param>* tags in the protocol XML file that do not have a corresponding OID in the MIB tree.

## See also

- [Getting Started with the DIS MIB Browser](xref:DIS_MIB_Browser).
