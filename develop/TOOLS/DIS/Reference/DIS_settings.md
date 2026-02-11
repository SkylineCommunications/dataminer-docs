---
uid: DIS_settings
---

# DIS settings

Select *DIS > Settings* in the menu to open the *DIS Settings* dialog box. In this dialog box, you can configure all the DIS-related settings.

## DMA

In the *DMA* tab, add a list of DMAs to which you want DataMiner Integration Studio to be able to connect when it has to e.g. import or publish connectors or automation scripts, or debug connector QActions.

To add a DMA to the list:

1. Click *Add* in the upper right-hand corner of the *DIS Settings* window.
1. In the *General* tab, specify the following information:

   | Information | Description |
   | ----------- | ----------- |
   | Display name | In this box, enter the name of the DMA as it will appear in the list. |
   | Host | In this box, enter the IP address or server name of the DataMiner Agent using the following syntax:<br>`https://[IP address or server name]:[Port]/SLNetService`<br>Note:<br>- Both HTTP and HTTPS are supported.<br>- Specifying the IP port is optional. Default port: 8004<br>- Specifying the suffix "/SLNetService" is optional.<br>See also [If a DMA uses DataMiner configuration switching](#if-a-dma-uses-dataminer-configuration-switching) |
   | Login | Choose how you want DIS to log on to the DMA:<br>- Using the current Windows user (default)<br>- Using a specific user/password combination |
   | Group | The DMAs listed in the DMA tab can be organized in groups.<br> In this box, enter or select the name of the group to which you want the DMA to belong. |
   | Production DMA | Select this checkbox if the DMA is a production DMA.<br> When you try to publish a protocol or an automation script to a production DMA, a confirmation box will appear to prevent you from accidentally publishing that file to it. |

1. Click *Test connection* to check whether DIS is able to connect to the DMA you configured.
1. If the DMA you are configuring is not your local DMA, then, in the *Debugging* tab, select the *Enable remote debugging* checkbox and specify the following settings if you want to be able to debug QActions while connected to this remote DMA.

   | Setting | Description |
   | ------- | ----------- |
   | Publish path | The network path to the shared folder on the remote DMA where DIS will upload the DLL files and the symbol files.<br>Default: \\\\remote-dma\\dis |
   | Path on DataMiner | The local path to the shared folder on the remote DMA where DIS will upload the DLL files and the symbol files.<br>Default: C:\\dis\\ |
   | Debugger qualifier | The qualifier supplied by Remote Debugging Monitor (msvsmon.exe) at startup.<br>Format: dmaname:ipport |

   > [!TIP]
   > See also:
   > [Debugging connectors and automation scripts](xref:Debugging_connectors_and_Automation_scripts)

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

- `C:\Skyline DataMiner\Files`
- `C:\Skyline DataMiner\ProtocolScripts`

## Solutions

In the *Solutions* tab, you can specify the following default solution folders:

- Default protocol solutions folder
- Default automation script solutions folder

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

### Automatically sync solution folders

Select the *Automatically sync solution folders* option if you want the physical solution folders in Windows file explorer to automatically be synchronized whenever you add, move or delete a file in the Visual Studio solution explorer.

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

- the name of the user who is currently signed in,
- the current [Skyline API](https://api.skyline.be) connection status,
- the current [Skyline API](https://api.skyline.be) authentication status, and
- the current account status.

Also, a button allows you to sign out (and sign in again).

## Templates

In the *Templates* tab, you can indicate whether you want DataMiner Integration Studio to automatically check for template updates when Visual Studio starts and install these when updates are available.

In the *Templates Nuget package ID* text box, you can specify the ID of the NuGet package you want to use in Visual Studio. This NuGet package contains the solution and project templates you can use to create new solutions and projects.

The update button allows you to manually trigger an update.

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
