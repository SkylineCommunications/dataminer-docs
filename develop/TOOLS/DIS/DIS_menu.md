---
uid: DIS_menu
---

# DIS menu

After you have installed the DIS extension, the Microsoft Visual Studio menu bar will have a DIS menu.

The following sections provide more information on the DIS menu:

- [DMA](#dma)
- [Protocol \> Generate QAction helper code](#protocol--generate-qaction-helper-code)
- [Protocol \> Generate Class Library code](#protocol--generate-class-library-code) (removed from DIS v2.41 onwards)
- [Protocol \> Convert to Solution...](#protocol--convert-to-solution)
- [Automation script \> Generate Class Library code](#automation-script--generate-class-library-code) (removed from DIS v2.41 onwards)
- [Plugins \> Generate driver help](xref:DisPlugins#generate-driver-help)
- [Plugins \> Add After Startup](xref:DisPlugins#add-after-startup)
- [Plugins \> Add matrix...](xref:DisPlugins#add-matrix)
- [Plugins \> Add SNMP System Info...](xref:DisPlugins#add-snmp-system-info)
- [Plugins \> Add SNMP Trap Receiver...](xref:DisPlugins#add-snmp-trap-receiver)
- [Plugins \> Add Table Context Menu...](xref:DisPlugins#add-table-context-menu)
- [Tool Windows \> DIS Tree View](xref:DisTreeViewToolWindow)
- [Tool Windows \> DIS Mappings View](xref:DisMappingViewToolWindow)
- [Tool Windows \> DIS Macros](xref:DisMacrosToolWindow)
- [Tool Windows \> DIS Inject](xref:DisInjectToolWindow)
- [Tool Windows \> DIS MIB Browser](xref:DisMibBrowserToolWindow)
- [Tool Windows \> DIS Grid View](xref:DisGridViewToolWindow)
- [Tool Windows \> DIS Diagram](xref:DisDiagramToolWindow)
- [Tool Windows \> DIS Validator](xref:DisValidatorToolWindow)
- [Tool Windows \> DIS Comparer](xref:DisComparerToolWindow)
- [Settings](xref:DIS_settings)
- [Check for updates...](#check-for-updates)
- [Help](#help)

## DMA

In the *DMA* submenu, you can find the following commands:

- Connect

  The *Connect* submenu lists all the DMAs configured in the *DMA* tab of the *DIS Settings* window. In the list, click the DMA to which you want DataMiner Integration Studio to connect. See [DMA](xref:DIS_settings#dma)

- Disconnect

  If you click *Disconnect*, DataMiner Integration Studio will disconnect from the DMA to which it was connected. See [DMA](xref:DIS_settings#dma)

- Import Protocol

  If you click *Import Protocol*, the *Import Protocol* dialog box will allow you to import a copy of an existing protocol XML file found on the DMA to which DIS is connected. In order to make a clear distinction between main protocols and DVE protocols, the *Import Protocol* dialog box lists all available protocols in a three-level tree structure:

  - Level 1: Main protocols
  - Level 2: Protocol versions
  - Level 3: DVE protocols

  You can import multiple protocols at once (even a combination of main protocols and DVE protocols). Select the protocols you want to import, and click *Import*. Each protocol will be opened in a separate tab.

  > [!NOTE]
  >
  > - Use the filter box in the top-right corner to filter the list of protocols.
  > - In order to prevent users from accidentally publishing a DVE protocol, it is not possible to publish a DVE protocol from inside DIS. When DIS detects that the *Protocol/Name* tag contains a *parentProtocol* attribute and that it is not empty, publishing will fail and a warning message will appear.
  > - When DIS connects to a DataMiner Agent, it always uses polling.
  > - If this *Import Protocol* command is unavailable, you are not connected to a DMA. In the *DMA* menu, go to *Connect*, and click the DMA to which you want DIS to connect. See [DMA](xref:DIS_settings#dma)

- Import Automation script

  If you click *Import Automation script*, the *Import Automation Script* dialog box will allow you to import a copy of an existing Automation script XML file found on the DMA to which DIS is connected.

  You can import multiple Automation scripts at once. Select the scripts you want to import, and click *Import*. Each script will be opened in a separate tab.

  > [!NOTE]
  >
  > - Use the filter box in the top-right corner to filter the list of Automation scripts.
  > - When DIS connects to a DataMiner Agent, it always uses polling.
  > - If this *Import Automation script..* command is unavailable, you are not connected to a DMA. In the *DMA* menu, go to *Connect*, and click the DMA to which you want DIS to connect. See [DMA](xref:DIS_settings#dma)

> [!NOTE]
>
> - When, in the DIS menu, you select *DMA > Import Protocol* while an Automation script solution is open, a pop-up window will appear, saying that it is impossible to import a protocol while an Automation script solution is open.
> - When, in the DIS menu, you select *DMA > Import Automation Script* while a protocol solution is open, a pop-up window will appear, saying that it is impossible to import an Automation script while a protocol solution is open.
> - When, in the DIS menu, you select *DMA > Import Automation Script* while an Automation script solution is open, a pop-up window will appear, asking you whether you want the script to be imported into the open Automation script solution.

## Protocol \> Generate QAction helper code

C# helper classes are automatically added or updated each time you switch from an XML editor tab to a C# editor tab (or vice versa). If, however, you want to force an ad hoc update of all C# helper classes, you can select *Protocol \> Generate QAction Helper Code*.

## Protocol \> Generate Class Library code

> [!IMPORTANT]
> The class library generation feature has been removed from DIS v2.41 onwards in favor of NuGet packages. If you have a connector or Automation script that makes use of the official class library, replace it with the corresponding NuGet package(s). For more information, refer to [Class library introduction](xref:ClassLibraryIntroduction). If you have a connector or Automation script that makes use of a community package, we recommend turning this into a NuGet package (For more information on how to create a NuGet package, refer to [Producing NuGet packages](xref:Producing_NuGet)). Alternatively, you can put all the code from the community library zip file in a QAction/Exe block.

If you want to force an ad hoc regeneration of the Class Library QAction 63000 and the Class Library EXE blocks, you can click Generate Class Library Code.

DIS contains a class library with reusable C# code, such as classes and methods that can be used for e.g. creating elements and services, processing DVEs, etc. Code from this library can be used in QActions and Automation scripts without having to copy/paste code from an external source into a protocol or a script.

The advantage of this approach is that no additional DLL files need to be copied to the DataMiner installation folder when a protocol or script is put into use. All necessary code is included in the protocol or script itself. By including all code in the protocol or the script, we also prevent future code library updates from rendering a protocol or script inoperable.

If, in the Class Library tab of the DIS Settings window, you selected the *Automatically generate Class Library code* option, DIS will automatically detect whether you are using any code from the Class Library in a QAction or Automation script, and copy all used classes, methods, etc. (along with all dependencies) from the class library to a generic QAction (with ID 63000) or Automation script EXE block. If you want to force an ad hoc regeneration of the Class Library QAction 63000 or Class Library EXE blocks, you can select *Protocol \> Generate Class Library Code* in the main DIS menu.

See also: [Class Library](xref:DIS_settings#class-library)

## Protocol \> Convert to Solution...

If you want to convert the standalone protocol XML file you opened in the XML editor to a protocol solution, select *Protocol \> Convert to Solution...*

## Automation script \> Generate Class Library code

See [Protocol \> Generate Class Library code](#protocol--generate-class-library-code).

## Check for updates...

If you click *Check for updates…*, the *DIS Update* dialog box will appear. This dialog box will indicate whether or not a new DIS version is available.

## Help

If you click *Help*, the DataMiner Integration Studio user guide will open in a browser window.
