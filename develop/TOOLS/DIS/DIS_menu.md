---
uid: DIS_menu
---

# DIS menu

After you have installed the DIS extension, the Microsoft Visual Studio menu bar will have a DIS menu.

The following sections provide more information on the DIS menu:

- [DMA](#dma)
- [Administration \> Open Driver Help](#administration--open-driver-help)
- [Protocol \> Generate QAction helper code](#protocol--generate-qaction-helper-code)
- [Protocol \> Convert to Solution...](#protocol--convert-to-solution)
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
- [Tool Windows \> DIS Parameter Update Locations](xref:DisParameterUpdateLocationsToolWindow)
- [Settings](xref:DIS_settings)
- [Send feedback](#send-feedback)
- [Check for updates...](#check-for-updates) (removed from DIS v3.0 onwards)
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

## Administration \> Open Driver Help

If a connector help page is available on [DataMiner Connector Documentation](https://docs.dataminer.services/connector/index.html), selecting *Open Driver Help* will open that page in the default web browser.

If no matching page can be found, you will be directed to a page explaining [how to add new connector documentation pages](xref:Connector_help_pages#adding-new-connector-documentation-pages).

## Protocol \> Generate QAction helper code

C# helper classes are automatically added or updated each time you switch from an XML editor tab to a C# editor tab (or vice versa). If, however, you want to force an ad hoc update of all C# helper classes, you can select *Protocol \> Generate QAction Helper Code*.

## Protocol \> Convert to Solution

If you want to convert the standalone protocol XML file you opened in the XML editor to a protocol solution, select *Protocol \> Convert to Solution...*

## Send feedback

If you want to send feedback to Skyline Communications, for example because you have encountered an issue in DIS, select *Send Feedback*.

## Check for updates

> [!IMPORTANT]
> This feature has been removed from DIS v3.0 onwards. DIS is now available on the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=skyline-communications.DataMinerIntegrationStudio).

If you click *Check for updates…*, the *DIS Update* dialog box will appear. This dialog box will indicate whether or not a new DIS version is available.

## Help

If you click *Help*, the DataMiner Integration Studio documentation will open in a browser window.
