---
uid: DIS_2.13
---

# DIS 2.13

## New features

### IDE

#### C# editor: DIS Inject functionality now supports debugging of code related to enhanced services \[ID_18342\]

The DIS Inject functionality now also supports debugging of code related to enhanced services.

#### XML editor: New snippets \[ID_19147\]\[ID_19273\]

When editing a protocol XML file or QAction code block, you can now insert the following new snippets:

##### Protocol snippets

- Param \> Table ContextMenu

##### QAction snippets

- Code Library \> Get DMS
- Retry

    Example:

    ```csharp
    bool IsLoadedInSLElement = MyClass.Retry(() => protocol.IsElementLoadedInSLElement(dmaId, elementId), new TimeSpan(0, 0, 2));
    ```

#### XML editor: Checking two protocols for major changes \[ID_19288\]\[ID_19290\]

It is now possible to compare two protocols and have the major changes displayed in the *DIS Validator* pane.

To compare two protocols, do the following:

1. Open both protocols in Visual Studio.
2. At the top of the XML editor tab containing one of the protocols, open the *Validator* drop-down menu, and click *Compare*.
3. In the *Major Change Check* window, select the two protocols to be compared, and click *Check*.

> [!NOTE]
>
> - Both protocol selection boxes will contain all protocols that are currently open in the XML editor.
> - By default, the protocol in the currently selected XML editor tab will be selected in the *New protocol* box, and the protocol that best resembles it will be selected in the *Previous protocol* box.

At present, the following checks will be performed when you compare two protocols:

- Have parameter IDs been changed?
- Have parameters been removed?

#### Enhanced 'Generate Write Parameters' window \[ID_19588\]

The *Generate Write Parameters* window, which allows you to automatically generate parameters of type "write" for existing parameters of type “read”, now has two additional columns:

- **Setter**: Allows you to enable the "setter" attribute for a particular write parameter.

  If you want to enable this attribute for all non-SNMP parameters in the list, you can select the "select all" checkbox in the column header.

  > [!NOTE]
  > When the protocol does not contain any non-SNMP parameters, the "select all" checkbox will be disabled, as will all "setter" checkboxes for the SNMP parameters in the list.

- **SNMP Set and Get**: Allows you to enable the "snmpSetAndGet" attribute for a particular write parameter.

  If you want to enable this attribute for all SNMP parameters in the list, you can select the "select all" checkbox in the column header.
  
  > [!NOTE]
  > When the protocol does not contain any non-SNMP parameters, the "select all" checkbox will be disabled, as will all "SNMP Set and Get" checkboxes for the non-SNMP parameters in the list.

Also, when in the *Write ID* column a suggested parameter ID is not available, you can now click a "search for next available Write ID" button in the form of an arrow to replace the non-available ID by an available one.

#### Analysis rules for QAction projects \[ID_19726\]

DIS will now define a default set of analysis rules for QAction projects. These rules can then be used by Visual Studio extensions like e.g. SonarLint to analyze the code.

> [!NOTE]
>
> - When, in Visual Studio, your solution is in release mode, analysis is disabled for performance reasons.
> - Analysis is always disabled for the QAction_Helper and QAction_Library projects.

#### Display editor: Enhanced visualization of Data Display pages \[ID_19753\]

The *Pages* section of the display editor now visualizes data pages and popup windows in a tree view, similar to the way in which they are displayed in DataMiner Cube. Popup windows are shown as child items of the data pages in which they are defined.

Additional changes:

- When you select a web interface page, the URL defined on that page can now be edited in the *Layout* section.
- Warning icons will now appear next to pages that are empty and popup windows in which other popup windows are defined.

#### C# editor: Additional hyperlink in file tab header to return to QAction or Exe code block in protocol or Automation script \[ID_19776\]

Up to now, in the header of a file tab containing the C# code of a QAction or Exe code block, you could click a link to return to the file tab containing the associated protocol XML file or Automation script XML file at the location where the cursor was positioned when you last viewed the file.

Now, an additional link will allow you to return to the associated protocol XML file or Automation script XML file at the location where the QAction or Exe code block is found.

#### DIS Tree: Element breadcrumbs & enhanced DIS.JumpToDisTree keyboard shortcut \[ID_19810\]

At the top of the DIS Tree window, there is now a breadcrumb control that allows you to quickly navigate to a particular location inside a protocol.xml file.

This control always shows the path towards the node that is currently selected in the tree view (i.e. “Protocol \> Params \> Param”).

- If you click a breadcrumb (e.g. “Params”), the corresponding (parent) node will be selected in the tree view (e.g. “Params”).
- If you click an arrow next to a breadcrumb, a drop-down list will open, allowing you to immediately navigate to one of the child nodes.

Also, the *DIS.JumpToDisTree* keyboard shortcut (i.e. CTRL+1) has been enhanced. Up to now, this shortcut allowed you to select the DIS tree node representing the element you were editing in the XML editor. From now on, it will also allow you to select the DIS tree node representing the QAction you are editing in the C# editor.

### Validator

#### Automatic error fixing \[ID_19712\]

The Validator is now able to automatically fix a number of common errors: replace all invalid characters in a parameter name with an underscore, trimming tag contents, etc.

In the *DIS Validator* pane, all errors that can be fixed will be marked by the following "wrench and screwdriver" icon:

![Wrench and screwdriver icon](~/release-notes/images/wrench_screwdriver.jpg)

To fix an error marked by a ‘wrench and screwdriver’ icon, do the following:

- Right-click the error, and select *Fix \> This error*.

  If the error has successfully been fixed, it will be removed from the *DIS Validator* pane.

If, instead of fixing just one error, you want to fix all errors of one particular type or severity, do the following:

- To fix all errors of a particular type, right-click an error, and select *Fix \> All errors of this type.*
- To fix all errors of a particular severity, right-click that severity, and select *Fix \> All errors in this category.*

#### Next-generation Validator \[ID_19714\]\[ID_19715\]\[ID_19976\]

From now on, the existing Validator and a new, next-generation Validator will run side by side until the former is retired at a later stage.

The new, next-generation Validator is extremely modular in design and allows for easy creation of a wide range of code checks and unit tests. At present, it already performs both new checks and checks that have been taken over from the existing Validator.

Also, the error messages shown in the UI have been redesigned. These now include the following additional information:

- Category (Protocol, Parameter, QAction, Group, Trigger, Action, Timer,...)
- Certainty (Certain, Uncertain)
- Fix impact (Breaking, Non-breaking)
- Severity (Critical, Major, Minor, Warning)
- Source (Validator, Major Change Checker)

> [!NOTE]
> When you hover over the columns containing this additional information, tool tips will appear, describing what is meant with e.g. “Breaking” or “Minor”.

##### List of possible error messages

| ID     | Check                               | Error message                           |
|--------|-------------------------------------|-----------------------------------------|
| 1.1.1  | Protocol.CheckProtocolTag           | MissingTag                              |
| 1.2.1  | Protocol.CheckNameTag               | MissingTag                              |
| 1.2.2  | Protocol.CheckNameTag               | EmptyTag                                |
| 1.2.3  | Protocol.CheckNameTag               | UntrimmedTag                            |
| 1.2.4  | Protocol.CheckNameTag               | InvalidChars                            |
| 1.3.1  | Protocol.CheckProviderTag           | MissingTag                              |
| 1.3.2  | Protocol.CheckProviderTag           | EmptyTag                                |
| 1.3.3  | Protocol.CheckProviderTag           | InvalidTag                              |
| 1.4.1  | Protocol.CheckSnmpTag               | MissingTag                              |
| 1.4.2  | Protocol.CheckSnmpTag               | EmptyTag                                |
| 1.4.3  | Protocol.CheckSnmpTag               | InvalidValue                            |
| 1.5.1  | Protocol.CheckIncludepagesAttribute | MissingAttribute                        |
| 1.5.2  | Protocol.CheckIncludepagesAttribute | EmptyAttribute                          |
| 1.5.3  | Protocol.CheckIncludepagesAttribute | InvalidAttribute                        |
| 1.6.1  | Protocol.CheckVersionTag            | MissingTag                              |
| 1.6.2  | Protocol.CheckVersionTag            | EmptyTag                                |
| 1.6.3  | Protocol.CheckVersionTag            | UntrimmedTag                            |
| 1.7.1  | Protocol.CheckElementTypeTag        | MissingTag                              |
| 1.7.2  | Protocol.CheckElementTypeTag        | EmptyTag                                |
| 1.8.1  | Protocol.CheckTypeTag               | MissingTag                              |
| 1.8.2  | Protocol.CheckTypeTag               | EmptyTag                                |
| 1.8.3  | Protocol.CheckTypeTag               | InvalidValue                            |
| 2.1.1  | Param.CheckIdAttribute              | MissingAttribute                        |
| 2.1.2  | Param.CheckIdAttribute              | EmptyAttribute                          |
| 2.1.3  | Param.CheckIdAttribute              | InvalidId                               |
| 2.1.4  | Param.CheckIdAttribute              | UpdatedParamId                          |
| 2.1.5  | Param.CheckIdAttribute              | OutOfRangeId                            |
| 2.1.6  | Param.CheckIdAttribute              | InvalidUseOfSpectrumIdRange             |
| 2.1.7  | Param.CheckIdAttribute              | InvalidUseOfMediationIdRange            |
| 2.1.8  | Param.CheckIdAttribute              | InvalidUseOfDataMinerModulesIdRange     |
| 2.1.9  | Param.CheckIdAttribute              | InvalidUseOfEnhancedServiceIdRange      |
| 2.1.10 | Param.CheckIdAttribute              | InvalidUseOfSlaIdRange                  |
| 2.1.11 | Param.CheckIdAttribute              | DuplicatedId                            |
| 2.1.12 | Param.CheckIdAttribute              | MissingParam                            |
| 2.2.1  | Param.CheckNameTag                  | MissingTag                              |
| 2.2.2  | Param.CheckNameTag                  | EmptyTag                                |
| 2.2.3  | Param.CheckNameTag                  | UntrimmedTag                            |
| 2.2.4  | Param.CheckNameTag                  | InvalidChars                            |
| 2.2.5  | Param.CheckNameTag                  | RestrictedName                          |
| 2.2.6  | Param.CheckNameTag                  | DuplicatedValue                         |
| 2.2.7  | Param.CheckNameTag                  | UnrecommendedChars                      |
| 2.2.8  | Param.CheckNameTag                  | UnrecommendedStartChars                 |
| 2.4.1  | Param.CheckSubtextTag               | MissingTag                              |
| 2.4.2  | Param.CheckSubtextTag               | EmptyTag                                |
| 2.9.2  | Param.CheckUnitsTag                 | EmptyTag                                |
| 2.9.3  | Param.CheckUnitsTag                 | OutdatedValue                           |
| 2.9.4  | Param.CheckUnitsTag                 | InvalidTag                              |

### XML Schema

#### UOM Schema: New units added \[ID_19174\]

The following units have been added to the UOM Schema:

- bits/sym
- clk
- deg/s
- Descriptors
- Fields
- fph
- fpm
- ft
- ft^3/min
- gpm
- in
- inAq
- inHg
- kVAh
- kWh
- L/s
- ops (operations per second)
- Steps
- TWH
- var
- W/m^2

#### UOM Schema: Updated units \[ID_19175\]

Following a review of the UOM Schema, the following units have been updated for reasons of consistency.

If you want to update these units in an existing protocol, open the protocol, click *Validate* at the top of the XML editor, and have these replaced automatically. See also [Automatic error fixing \[ID_19712\]](#automatic-error-fixing-id_19712).

| Original unit   | Updated unit     |
|-----------------|------------------|
| Allocation Unit | Allocation Units |
| am/wk           | am/Week          |
| am/yr           | am/Year          |
| blocks          | Blocks           |
| blocks/d        | Blocks/d         |
| blocks/h        | Blocks/h         |
| blocks/min      | Blocks/min       |
| blocks/Month    | Blocks/Month     |
| blocks/ms       | Blocks/ms        |
| blocks/ns       | Blocks/ns        |
| blocks/s        | Blocks/s         |
| blocks/us       | Blocks/us        |
| blocks/wk       | Blocks/Week      |
| blocks/yr       | Blocks/Year      |
| Cell            | Cells            |
| cm/wk           | cm/Week          |
| cm/yr           | cm/Year          |
| Column(s)       | Columns          |
| dam/wk          | dam/Week         |
| dam/yr          | dam/Year         |
| dB/wk           | dB/Week          |
| dB/yr           | dB/Year          |
| dBm/wk          | dBm/Week         |
| dBm/yr          | dBm/Year         |
| dBmV/wk         | dBmV/Week        |
| dBmV/yr         | dBmV/Year        |
| dBV/wk          | dBV/Week         |
| dBV/yr          | dBV/Year         |
| dBW/wk          | dBW/Week         |
| dBW/yr          | dBW/Year         |
| dm/wk           | dm/Week          |
| dm/yr           | dm/Year          |
| Error(s)        | Errors           |
| Error(s)/d      | Errors/d         |
| Error(s)/h      | Errors/h         |
| Error(s)/min    | Errors/min       |
| Error(s)/Month  | Errors/Month     |
| Error(s)/ms     | Errors/ms        |
| Error(s)/ns     | Errors/ns        |
| Error(s)/s      | Errors/s         |
| Error(s)/us     | Errors/us        |
| Error(s)/wk     | Errors/Week      |
| Error(s)/yr     | Errors/Year      |
| fm/wk           | fm/Week          |
| fm/yr           | fm/Year          |
| Gohm            | GOhm             |
| Gsamples        | GSamples         |
| Gsamples/d      | GSamples/d       |
| Gsamples/h      | GSamples/h       |
| Gsamples/min    | GSamples/min     |
| Gsamples/Month  | GSamples/Month   |
| Gsamples/ms     | GSamples/ms      |
| Gsamples/ns     | GSamples/ns      |
| Gsamples/s      | GSamples/s       |
| Gsamples/us     | GSamples/us      |
| Gsamples/wk     | GSamples/Week    |
| Gsamples/yr     | GSamples/Year    |
| hm/wk           | hm/Week          |
| hm/yr           | hm/Year          |
| km/wk           | km/Week          |
| km/yr           | km/Year          |
| kohm            | kOhm             |
| ksamples        | kSamples         |
| ksamples/d      | kSamples/d       |
| ksamples/h      | kSamples/h       |
| ksamples/min    | kSamples/min     |
| ksamples/Month  | kSamples/Month   |
| ksamples/ms     | kSamples/ms      |
| ksamples/ns     | kSamples/ns      |
| ksamples/s      | kSamples/s       |
| ksamples/us     | kSamples/us      |
| ksamples/wk     | kSamples/Week    |
| ksamples/yr     | kSamples/Year    |
| lines           | Lines            |
| m/wk            | m/Week           |
| m/yr            | m/Year           |
| MIB objects     | MIB Objects      |
| miles           | mi               |
| miles/d         | mi/d             |
| miles/h         | mi/h             |
| miles/min       | mi/min           |
| miles/Month     | mi/Month         |
| miles/ms        | mi/ms            |
| miles/ns        | mi/ns            |
| miles/s         | mi/s             |
| miles/us        | mi/us            |
| miles/wk        | mi/Week          |
| miles/yr        | mi/Year          |
| mm/wk           | mm/Week          |
| mm/yr           | mm/Year          |
| Mohm            | MOhm             |
| Month           | Months           |
| Msamples        | MSamples         |
| Msamples/d      | MSamples/d       |
| Msamples/h      | MSamples/h       |
| Msamples/min    | MSamples/min     |
| Msamples/Month  | MSamples/Month   |
| Msamples/ms     | MSamples/ms      |
| Msamples/ns     | MSamples/ns      |
| Msamples/s      | MSamples/s       |
| Msamples/us     | MSamples/us      |
| Msamples/wk     | MSamples/Week    |
| Msamples/yr     | MSamples/Year    |
| nm/wk           | nm/Week          |
| nm/yr           | nm/Year          |
| octets          | Octets           |
| octets/d        | Octets/d         |
| octets/h        | Octets/h         |
| octets/min      | Octets/min       |
| octets/Month    | Octets/Month     |
| octets/ms       | Octets/ms        |
| octets/ns       | Octets/ns        |
| octets/s        | Octets/s         |
| octets/us       | Octets/us        |
| octets/wk       | Octets/Week      |
| octets/yr       | Octets/Year      |
| ohm             | Ohm              |
| packets         | Packets          |
| pm/wk           | pm/Week          |
| pm/yr           | pm/Year          |
| Record(s)       | Records          |
| Record(s)/d     | Records/d        |
| Record(s)/h     | Records/h        |
| Record(s)/min   | Records/min      |
| Record(s)/Month | Records/Month    |
| Record(s)/ms    | Records/ms       |
| Record(s)/ns    | Records/ns       |
| Record(s)/s     | Records/s        |
| Record(s)/us    | Records/us       |
| Record(s)/wk    | Records/Week     |
| Record(s)/yr    | Records/Year     |
| Requests/wk     | Requests/Week    |
| Requests/yr     | Requests/Year    |
| Row(s)          | Rows             |
| samples         | Samples          |
| samples/d       | Samples/d        |
| samples/h       | Samples/h        |
| samples/min     | Samples/min      |
| samples/Month   | Samples/Month    |
| samples/ms      | Samples/ms       |
| samples/ns      | Samples/ns       |
| samples/s       | Samples/s        |
| samples/us      | Samples/us       |
| samples/wk      | Samples/Week     |
| samples/yr      | Samples/Year     |
| um/wk           | um/Week          |
| um/yr           | um/Year          |
| unit            | Units            |
| unit/d          | Units/d          |
| unit/h          | Units/h          |
| unit/min        | Units/min        |
| unit/Month      | Units/Month      |
| unit/ms         | Units/ms         |
| unit/ns         | Units/ns         |
| unit/s          | Units/s          |
| unit/us         | Units/us         |
| unit/wk         | Units/Week       |
| unit/yr         | Units/Year       |
| Week(s)         | Weeks            |
| words           | Words            |
| Year(s)         | Years            |

#### UOM Schema: New units added \[ID_19176\]

The following units have been added to the UOM Schema:

- Zb, ZB, Zib, ZiB, Yb, YB, Yib, YiB, Zbps, ZBps, ZiBps, Ybps, YBps, YiBps, ym, zm, Mm, Gm, Tm, Pm, Em, Zm, Ym
- zm/h, ym/h, Ym/h, Zm/h, Em/h, Pm/h, Tm/h, Gm/h, Mm/h, ft/h, in/h, ym/s, Ym/s, zm/s, Zm/s, in/s, ft/s, Mm/s, Tm/s, Pm/s, Em/s
- peV, feV, aeV, zeV, yeV, neV, ueV, yJ, eV, ycal, meV, zJ, ceV, zcal, deV,  aJ, acal, keV, fJ, fcal, MeV, pJ, pcal, GeV, nJ, ncal, TeV, uJ, ucal, PeV, mJ, MJ
- mcal, Mcal, cJ, ccal, dJ, EeV, EJ, Ecal, dcal, cal, kcal, ZeV, ZJ, Zcal, YeV, YJ, Ycal, Gcal, TJ,  Tcal, PJ, Pcal
- ZBd, YBd
- yHz, zHz, aHz, fHz, uHz, mHz, cHz, dHz, PHz, EHz, ZHz, YHz
- yW, zW, aW, fW, pW, cW, dW, PW, EW, ZW, YW
- yA, zA, aA, fA, pA, TA, PA, EA, ZA, YA
- yV, zV, aV, fV, pV, cV, dV, TV, PV, EV, ZV, YV
- ys, zs, as, fs, ps, cs, ds, ks, Ms, Gs, Ts, Ps, Es, Zs, Ys
- yF, zF, cF, dF, kF, MF, GF, TF, PF, EF, ZF, YF
- yC, zC, cC, dC, kC, MC, GC, TC, PC, EC, ZC, YC
- yH, zH, aH, fH, pH, cH, dH, kH, MH, GH, TH, PH, EH, ZH, YH
- yPa, zPa, aPa, fPa, pPa, nPa, uPa, TPa, PPa, EPa, ZPa, YPa
- TOhm, POhm, EOhm, ZOhm, YOhm
- Bq
- cmAq, cmHg, mmHg
- Gy, ha, ft^2, ft^3, deg R, kat, m^2, m^3, Np, R, rad, sr, yd, yd/h, yd/s, gal

#### Protocol Schema: Elements added \[ID_19865\]\[ID_19866\]\[ID_19867\]\[ID_19868\]

The following elements have been added to the protocol Schema:

- Protocol.PortSettings.SSH
- Protocol.VersionHistory

#### Protocol schema: Updated attribute rules \[ID_19869\]

The following attribute now has a fixed value “credentials”:

- Protocol.HTTP.Session@loginMethod

The following attribute now has to refer to an existing parameter:

- Protocol.ParameterGroups.Group.Params.Param@id

## Changes

### Enhancements

#### IDE - Table editor: ‘disable...’ column options no longer removed when alarm monitoring is disabled \[ID_18825\]

From now on, ‘disable...’ column options (e.g. ‘disableHistogram’) will no longer be removed when alarm monitoring is disabled.

#### IDE - XML editor: Snippet enhancements \[ID_19148\]\[ID_19730\]\[ID_19912\]

A number of snippets have been enhanced:

##### Protocol snippets

- Protocol root

  - General page is now the default page
  - Recommended timers have been added
  - A precompiled QAction has been added
  - An “After Startup” procedure has been added

> [!NOTE]
> The same changes have been made to the default protocol template.

##### QAction snippets

- All snippets that add a NotifyProtocol call

  - These now all use NotifyType Enums instead of hardcoded numbers

- All snippets that check if an element is fully started up and loaded in DataMiner processes have been optimized:

  - IsElementActiveInSLDms
  - IsElementLoadedInSLElement
  - IsElementLoadedInSLNet

#### SLNetTypes.dll updated to version 9.5.13 \[ID_19948\]

The SLNetTypes.dll file has been updated to version 9.5.13. This will prevent compatibility issues when communicating with DataMiner Agents that run a newer DataMiner feature release.

### Fixes

#### IDE: Problem with ‘Check for updates’ \[ID_19564\]

When you clicked *Check for updates...* in the *DCP* tab of the *DIS Settings* window, in some cases, the incorrect update package would be downloaded (insider build instead of main build, or vice versa).
