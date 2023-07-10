---
uid: DIS_settings
---

# DIS settings

Select *DIS > Settings* in the menu to open the *DIS Settings* dialog box. In this dialog box, you can configure all the DIS-related settings.

## DMA

In the *DMA* tab, add a list of DMAs to which you want DataMiner Integration Studio to be able to connect when it has to e.g. import or publish connectors or Automation scripts, or debug connector QActions.

To add a DMA to the list:

1. Click *Add* in the upper right-hand corner of the *DIS Settings* window.
1. In the *General* tab, specify the following information:

    | Information | Description |
    |-------------|-------------|
    | Display name | In this box, enter the name of the DMA as it will appear in the list. |
    | Host | In this box, enter the IP address or server name of the DataMiner Agent using the following syntax:<br>*https://\[IP address or server name\]:\[Port\]/SLNetService*<br>Note:<br>- Both HTTP and HTTPS are supported.<br>- Specifying the IP port is optional. Default port: 8004<br>- Specifying the suffix "/SLNetService" is optional.<br>See also [If a DMA uses DataMiner configuration switching](#if-a-dma-uses-dataminer-configuration-switching) |
    | Login | Choose how you want DIS to log on to the DMA:<br>- Using the current Windows user (default)<br>- Using a specific user/password combination |
    | Group | The DMAs listed in the DMA tab can be organized in groups.<br> In this box, enter or select the name of the group to which you want the DMA to belong. |
    | Production DMA | Select this checkbox if the DMA is a production DMA.<br> When you try to publish a protocol or an Automation script to a production DMA, a confirmation box will appear to prevent you from accidentally publishing that file to it. |

1. Click *Test connection* to check whether DIS is able to connect to the DMA you configured.
1. If the DMA you are configuring is not your local DMA, then, in the *Debugging* tab, select the *Enable remote debugging* checkbox and specify the following settings if you want to be able to debug QActions while connected to this remote DMA.

    | Setting | Description |
    |---------|-------------|
    | Publish path | The network path to the shared folder on the remote DMA where DIS will upload the DLL files and the symbol files.<br>Default: \\\\remote-dma\\dis |
    | Path on DataMiner | The local path to the shared folder on the remote DMA where DIS will upload the DLL files and the symbol files.<br>Default: C:\\dis\\ |
    | Debugger qualifier | The qualifier supplied by Remote Debugging Monitor (msvsmon.exe) at start-up.<br>Format:<br>- username@dmaname (Visual Studio 2010)<br>- dmaname:ipport (as from Visual Studio 2012)<br>Default: RemoteDebug@remote-dma |

    > [!TIP]
    > See also:
    > [Debugging connectors and Automation scripts](xref:Debugging_connectors_and_Automation_scripts)

1. Click *OK* to close the *Edit DMA Connection* window.

To update a DMA in the list:

1. Right-click the DMA, and select *Edit*.
1. In the *Edit DMA Connection* window, make the necessary changes, and click *OK*.

    > [!NOTE]
    >
    > - When you change the hostname, the user name and/or the password, the current connection will be closed.
    > - After having changed the hostname, the user name and/or the password, we recommend you click the *Test connection* button to check whether DIS is able to connect to the DMA.

To delete a DMA from the list:

- Right-click the DMA, and select *Delete*.

To set a DMA as the default DMA:

- Right-click the DMA, and select *Set as Default*.

### If a DMA uses DataMiner configuration switching

If you add a DMA on which DataMiner configuration switching is enabled, you may have to change the port number in the IP address you entered in the *Host* box.

1. On the DMA in question, open C:\\Skyline DataMiner\\logging\\SLNet.txt.
1. Locate the line that contains "EndPointsManager.InternalEnableRemoting", and write down the port number specified on this line.

    ```txt
    07-14 08:42:04.374|4|EndPointsManager.InternalEnableRemoting|port 8004 is available!
    ```

1. Replace the port number in the *Host* box with the port number you found in SLNet.txt.

> [!NOTE]
> For more information on switching between DataMiner configurations, refer to the DataMiner Help.

## DLLs

In the *DLLs* tab, you can specify the DLL import locations.

### DLL Import locations

These are the folders that should contain files like *SLDatabase.dll*, *SLProtocolTools.dll* or *SLNetTypes.dll*.

- To add a folder, click *Add* and specify the folder in the newly added text box. Enter it manually or click the ellipsis ("…") button to the right of the text box and browse to the right folder.
- To delete a folder, click the red X to the right of the folder.

If you are working on a local DMA, you can keep the following default folders:

- *C:\\Skyline DataMiner\\Files*
- *C:\\Skyline DataMiner\\ProtocolScripts*

## Solutions

In the *Solutions* tab, you can specify the following default solution folders:

- Default protocol solutions folder
- Default Automation script solutions folder

## Class Library

> [!IMPORTANT]
> The class library generation feature has been removed from DIS v2.41 onwards in favor of NuGet packages. If you have a connector or Automation script that makes use of the official class library, replace it with the corresponding NuGet package(s). For more information, refer to [Class library introduction](xref:ClassLibraryIntroduction). If you have a connector or Automation script that makes use of a community package, we recommend turning this into a NuGet package (For more information on how to create a NuGet package, refer to [Producing NuGet packages](xref:Producing_NuGet)). Alternatively, you can put all the code from the community library zip file in a QAction/Exe block.

In the *Class Library* tab, you can select a base package (shipped with DIS) and specify the location of one or more custom/community packages, which will typically contain code written specifically for a particular vendor or project and maintained by a dedicated team of developers.

Apart from a number of C# files, class library packages include a manifest.xml file that contains the name and the version of the package as well as any dependencies to other packages. When a Class Library QAction 63000 or a Class Library EXE block is generated, all information about the packages that were used to build the class library packages used by that QAction or EXE block will be added to it. This will allow DIS to check the included packages each time it generates the QAction or EXE block, alert the user whenever it notices package inconsistencies (different base package, updated community packages, etc.), and offer the user the opportunity to either allow or block the QAction or EXE block update.

DIS will automatically reload the class library packages when packages have been modified on disk or when any settings in this *Class Library* tab have been changed.

For more information on Class Library packages, see [Class Library packages](xref:Class_Library_packages)

### Enable Class Library feature

> [!IMPORTANT]
> The class library generation feature has been removed from DIS v2.41 onwards in favor of NuGet packages. If you have a connector or Automation script that makes use of the official class library, replace it with the corresponding NuGet package(s). For more information, refer to [Class library introduction](xref:ClassLibraryIntroduction). If you have a connector or Automation script that makes use of a community package, we recommend turning this into a NuGet package (For more information on how to create a NuGet package, refer to [Producing NuGet packages](xref:Producing_NuGet)). Alternatively, you can put all the code from the community library zip file in a QAction/Exe block.

Clear the *Enable Class Library feature* option if you want to disable the Class Library feature.

### Automatically generate Class Library code

> [!IMPORTANT]
> The class library generation feature has been removed from DIS v2.41 onwards in favor of NuGet packages. If you have a connector or Automation script that makes use of the official class library, replace it with the corresponding NuGet package(s). For more information, refer to [Class library introduction](xref:ClassLibraryIntroduction). If you have a connector or Automation script that makes use of a community package, we recommend turning this into a NuGet package (For more information on how to create a NuGet package, refer to [Producing NuGet packages](xref:Producing_NuGet)). Alternatively, you can put all the code from the community library zip file in a QAction/Exe block.

If you select the *Automatically generate Class Library code* option, DIS will automatically regenerate the Class Library QAction 63000 and the Class Library EXE blocks whenever references to class library items have been added, changed or removed.

If you want to force an ad hoc regeneration of the Code Library QAction 63000 and the Code Library EXE blocks, you can click the *Protocol \> Generate Class Library Code* command in the DIS menu.

See also: [Protocol \> Generate Class Library code](xref:DIS_menu#protocol--generate-class-library-code)

## Interface

In the *Interface* tab, you can change a number of settings pertaining to mouse behavior, highlighting and the file tab search box.

### Scroll at mouse cursor

If you select the *Scroll at mouse cursor* option, hovering with your mouse over a user interface section of DataMiner Integration Studio will suffice to be able to scroll in that section using the mouse wheel.

This means that you will be able to scroll in one section while keeping the keyboard focus on another section.

### Smart highlighting: case sensitivity

This setting controls whether or not the "smart highlighting" feature is case sensitive.

| If you select... | then... |
|------------------|---------|
| Case sensitive | instances of the selected word will be highlighted throughout the entire XML file only if their casing exactly matches that of the word you selected. |
| Ignore case | instances of the selected word will be highlighted throughout the entire XML file regardless of casing. |

### Highlighting filter box - Case sensitivity

This setting controls whether or not the full-text search feature in the file tabs is case sensitive.

| If you select... | then, when you open a new file tab, ... |
|------------------|-----------------------------------------|
| Case sensitive | the full-text search feature will be case sensitive. |
| Ignore case | the full-text search feature will not be case sensitive. |
| Remember last used | The full-text search feature will inherit the current case sensitivity setting.<br> Example: If, just before opening a new file tab, you chose *Ignore case* in an open file tab, then the full-text search feature of the newly opened file tab will be set to *Ignore case* as well. |

The value you specify in this system setting is the default setting. If you want to override this default setting in a particular file tab, you can switch between *Case sensitive* and *Ignore case* by clicking the *aA* button to the right of the search box.

### Highlighting filter box - Wildcard characters (\* and ?)

This setting controls whether or not the full-text search feature will interpret the wildcard characters \* and ? as wildcards or not.

| If you select... | then, when you open a new file tab,... |
|------------------|----------------------------------------|
| Treat as literal string | the full-text search feature will interpret \* and ? characters in the search box as characters instead of wildcards.<br> Tip: Use this option if you want to search for strings like "\*\*\*". |
| Interpret as wildcards | the full-text search feature will interpret \* and ? characters in the search box as wildcards instead of characters. |
| Remember last used | The full-text search feature will inherit the current wildcard interpretation setting.<br> Example: If, just before opening a new file tab, you chose *Interpret as wild-cards* in an open file tab, then the full-text search feature of the newly opened file tab will be set to *Interpret as wildcards* as well. |

The value you specify in this system setting is the default setting. If you want to override this default setting in a particular file tab, you can switch between *Treat as literal string* and *Interpret as wildcards* by clicking the *\*?* button to the right of the search box.

### Disable C# syntax highlighting in XML documents

If you select the *Disable C# syntax highlighting in XML documents* option, the C# code inside *\<QAction>* and *\<Exe>* tags will be displayed without syntax highlighting.

### DIS tree view: Show description instead of name

Select this option if you want the *DIS Tree* window to display parameter descriptions instead of parameter names.

See the following example. If you select the *DIS tree view: Show description instead of name* option, the *DIS Tree* window will display the parameter in question as "System Name" instead of "sysName".

```xml
<Param>
  <Name>sysName</Name>
  <Description>System Name</Description>
  ...
</Param>
```

### Disable highlighting of selected text in XML documents

By default, if you select a text string in an XML file, all identical text strings in that file will also be highlighted. If you do not want this, select the *Disable highlighting of selected text in XML documents* option.

### Hide virtual comments in protocol

Select the *Hide virtual comments in protocol* option if you do not want virtual comments to be shown in the XML editor.

> [!TIP]
> See also:
> [Virtual comments](xref:XML_editor#virtual-comments)

### Only show unresolved links

Select the *Only show unresolved links* option if you only want to see the virtual comments that cannot be resolved.

> [!TIP]
> See also:
> [Virtual comments](xref:XML_editor#virtual-comments)

### Task URL String Format

In this box, you can configure the format of the task references, which, in the Version editor, you can link to protocol versions.

In the format string, you can use the "{ref}" placeholder. When, in the Version editor, you click the link button of a particular reference, that placeholder will then be replaced by the contents of the *Reference* column.

> [!TIP]
> See also:
> [Version editor](xref:Version_editor)

### Reference URL String Format

In this box, you can configure the format of the generic references, which, in the Version editor, you can link to protocol versions.

In the format string, you can use the "{ref}" placeholder. When, in the Version editor, you click the link button of a particular reference, that placeholder will then be replaced by the contents of the *Reference* column.

> [!TIP]
> See also:
> [Version editor](xref:Version_editor)

## MIB

In the *MIB* tab, you can specify the location of your MIB store.

### Search missing modules in the MIB store

If you select this option, whenever you load a MIB file into the *DIS MIB Browser*, DataMiner Integration Studio will search the MIB store folder for any referenced MIB module that cannot be found.

### Save loaded modules in the MIB store

If you select this option, whenever you load a MIB file into the *DIS MIB Browser*, DataMiner Integration Studio will save that file in the MIB store folder.

## Account

In the *Account* tab, you can see

- the name of the user who is currently signed in, and
- the current license status.

Also, a button allows you to sign out (and sign in again).

## Updates

In the *Updates* tab, you can indicate whether you want DataMiner Integration Studio to automatically check for updates.

- If you select the *Check for plug-in updates* option, DataMiner Integration Studio will check once every hour whether a more recent version of the *DataMinerIntegrationStudio.vsix* extension file is available. If so, an update banner will appear at the top of the editor window.

- If you select the *Get insider builds* option, DataMiner Integration Studio will not only check for main builds (i.e. the official release versions), but also for insider builds (i.e. pre-release versions for testing purposes).

    > [!NOTE]
    > It is advised to always install official release versions.

## Templates

In the *Templates* tab, you can indicate whether you want DataMiner Integration Studio to automatically check for template updates when Visual Studio starts and install these when updates are available.

In the *Templates Nuget package ID* text box, you can specify the ID of the NuGet package you want to use in Visual Studio. This NuGet package contains the solution and project templates you can use to create new solutions and projects.

The update button allows you to manually trigger an update.

> [!NOTE]
> This tab is only available in Visual Studio 2022.

## Other

### Hide warnings about UTF-8 encoding

If you select the *Hide warnings about UTF-8 encoding* option, no UTF-8 encoding errors will be displayed in the error list.

### Fix default XML encoding

Click *Fix default XML encoding* if you want DataMiner Integration Studio to change the encoding of Visual Studio’s "New XML file" template, which, by default, contains the UTF-8 signature header.

> [!NOTE]
>
> - DIS automatically saves XML files using the following encoding:
>   - Unicode (UTF-8 with signature) - Codepage 65001
> - XML files with an UTF-8 signature header can only be uploaded to DataMiner using DataMiner Cube.

## Info

In the *Info* tab, you can find the version of the currently installed DataMiner Integration Studio.

- If you click *Release notes*, the release note document will open in the default PDF viewer.
- If you click *License Agreement*, the license agreement will open in the default text editor.
