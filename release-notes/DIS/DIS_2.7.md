---
uid: DIS_2.7
---

# DIS 2.7

## New features

### IDE

#### Enhanced ‘Import Protocol’ window \[ID_17026\]

If, in the *DIS* menu, you click *DMA \> Import Protocol…*, the *Import Protocol* dialog box will allow you to import a copy of an existing *Protocol.xml* file found on the DMA specified in the *DMA* tab of the *DIS Settings* window.

In order to make a clearer distinction between main protocols and DVE protocols, the *Import Protocol* dialog box now lists all available protocols in a three-level tree structure:

- Level 1: Main protocols
- Level 2: Protocol versions
- Level 3: DVE protocols

Also, it is now possible to import multiple protocols at once (even a combination of main protocols and DVE protocols). To import a series of protocols, select the protocols you want to import, and click *Import*. Each protocol will be opened in a separate tab.

> [!NOTE]
> In order to prevent users from accidentally publishing a DVE protocol, it is not possible to publish a DVE protocol from inside DIS.
>
> When DIS detects that the *Protocol/Name* tag contains a *parentProtocol* attribute and that it is not empty, publishing will fail and a warning message will appear.

#### IDE: QAction projects are now compiled against Microsoft .NET Framework 4.5 \[ID_17027\]

From now on, QAction projects are compiled against Microsoft .NET Framework 4.5.

## Changes

### Enhancements

#### IDE: Enhanced loading of MIB browser \[ID_17066\]

Due to a number of enhancements, overall performance has increased when loading the MIB browser.

#### RTDisplay check now also supports conditional syntax in dependencyValues attribute \[ID_17172\]

Up to now, when the dependencyValues attribute of a Discreet tag contained conditional syntax (e.g. “123?” or “123?:\[value:123\]”), an exception was thrown and all other RTDisplay checks were ignored. From now on, the RTDisplay check will support conditional syntax in dependencyValues attributes.

### Fixes

#### IDE: Problem when importing a protocol.xml file from the connected DataMiner Agent \[ID_16961\]

When using Visual Studio 2017, it was not possible to import a *protocol.xml* file from the connected DataMiner Agent. This problem has now been fixed.

#### Validator: Problem when loading UOM.xsd file \[ID_17068\]

When the Validator was run, in some cases, it was not able to find the *UOM.xsd* schema file. As a result, an error was thrown. This problem has now been fixed.

#### Validator: Incorrect warnings were issued when enableHeatmap and enableHistogram were used in the options attribute of a ColumnOption tag \[ID_17070\]

The Validator would issue incorrect warnings when *enableHeatmap* and *enableHistogram* were used in the *options* attribute of a *ColumnOption* tag. This problem has now been fixed.

#### Validator: Incorrect errors were issued when view table columns were created using the duplicateAs option \[ID_17076\]

When view table columns were created using the *duplicateAs* option, the Validator would issue incorrect errors stating that columns were missing in the *ColumnOption* tags. This problem has now been fixed.
