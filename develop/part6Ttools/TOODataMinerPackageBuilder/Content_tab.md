---
uid: Content_tab
---

# Content tab

After startup, the Application Package Builder UI provides an overview of the content of the application package in the *Content* tab. Initially, this tab will by default be empty.

To add or remove content, click the *Edit Content* button.

A tree control will be displayed, with items you can select/deselect to be included/excluded in the package. By default, the application will read out the local DataMiner folder location (*C:\\Skyline DataMiner*) and display the folder contents in the tree control.

> [!NOTE]
> For options to change startup behavior, refer to [DMAppBuilderConfig.xml](xref:DMAppBuilderConfig_xml#dmappbuilderconfigxml).

The *Protocol Production Only* check box can be used to only display the protocols in the tree that are set to production.

The *Filter* text box allows you to do a quick search for a specific file or set of files by filtering on contents of a file name. The filter will be applied when you press the *Filter* button.

The *Remove Path* button allows you to remove a previously included location.

## Mapping (legacy packages only)

When you add content from a DMS, selected content will automatically be mapped in the correct package structure and shown in the *Content* tab page.

Intelligence has been added during selection of content for the package.

- When an element is selected to be included, the *Update Elements* step will automatically be added in *Update Content*.

- When an element is selected to be included, the element *id* attribute will be set to -1.

- When an element is selected to be included, the corresponding protocol will also be included by default.

- When a Protocol.xml is selected, the *Update Protocols* step will automatically be added in *Update Content*.

- When the Production link of a protocol is selected, the link and the file it points to will be included.

- When an Automation script is selected, the *Update Scripts* step will automatically be added in *Update Content* and the *ElementUsage* tag will automatically be removed.

- When a Visio file with extension .vsdx or .zip is added, the *Sync Startup Action* for this file will automatically be added.

- When a report template or dashboard (.aspx) is added, the update webpages step will automatically be added in *Update Content*.

After you have selected the desired content and defined the configuration parameters on the *DMAPP Configuration* tab page, you can click the *Build DMAPP* button, which will open a dialog box where you can specify the location and name of the resulting application package.

After you have specified the name and clicked the *Save* button, the application package will be generated.
