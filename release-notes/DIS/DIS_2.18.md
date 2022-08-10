---
uid: DIS_2.18
---

# DIS 2.18

## New features

### IDE

#### DIS Validator pane: Information icon now indicates that more information is available for a particular error \[ID_22151\]

When, for an error listed in the DIS Validator pane, there is more information available than is being displayed, an information icon will now appear next to the description.

If you click such an information icon, the following information will appear in a popup window:

- code
- source
- category
- description
- certainty
- fix impact
- how to fix (when available)
- extra details (when available)
- code example (when available)

### Validator

#### New and updated checks and error messages \[ID_21784\]\[ID_21791\]\[ID_21793\]\[ID_21796\] \[ID_21839\]\[ID_21863\]\[ID_21934\]\[ID_21977\]\[ID_22002\]\[ID_22026\]\[ID_22133\]

The following checks and error messages have been added or updated.

| ID     | Check                              | Error message                                                                                                                       |
|--------|------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------|
| 1.19.1 | Protocol.CheckIdAttribute          | Param '{paramId}' in ParameterGroup '{parameterGroupId}' does not exist.                                                            |
| 1.19.2 | Protocol.CheckIdAttribute          | Duplicate Param '{paramId}' in ParameterGroup '{parameterGroupId}'.                                                                 |
| 1.20.1 | Protocol.CheckIdAttribute          | Missing attribute 'id' in ParameterGroup.                                                                                           |
| 1.20.2 | Protocol.CheckIdAttribute          | Empty attribute 'id' in ParameterGroup.                                                                                             |
| 1.20.3 | Protocol.CheckIdAttribute          | Untrimmed attribute 'id' in ParameterGroup.                                                                                         |
| 1.20.4 | Protocol.CheckIdAttribute          | Invalid ParameterGroup ID '{id}'.                                                                                                   |
| 1.20.5 | Protocol.CheckIdAttribute          | Out of range ParameterGroup ID '{id}'.                                                                                              |
| 1.21.1 | Protocol.CheckDefaultPageAttribute | Missing attribute 'defaultPage'.                                                                                                    |
| 1.21.2 | Protocol.CheckDefaultPageAttribute | Empty attribute 'defaultPage'.                                                                                                      |
| 1.21.3 | Protocol.CheckDefaultPageAttribute | The specified defaultPage '{pageName}' does not exist.                                                                              |
| 1.21.4 | Protocol.CheckDefaultPageAttribute | Untrimmed attribute 'defaultPage'. Current value '{attributeValue}'.                                                                |
| 1.21.5 | Protocol.CheckDefaultPageAttribute | The default page should be a page with name 'General'.                                                                              |
| 1.21.6 | Protocol.CheckDefaultPageAttribute | Unsupported popup page '{pageName}' in defaultPage attribute.                                                                       |
| 1.22.1 | Protocol.CheckPageOrderAttribute   | Missing attribute 'pageOrder'.                                                                                                      |
| 1.22.2 | Protocol.CheckPageOrderAttribute   | Empty attribute 'pageOrder'.                                                                                                        |
| 1.22.3 | Protocol.CheckPageOrderAttribute   | Untrimmed attribute 'pageOrder'. Current value '{attributeValue}'.                                                                  |
| 1.22.4 | Protocol.CheckPageOrderAttribute   | Unsupported popup page '{pageName}' in pageOrder attribute.                                                                         |
| 1.22.5 | Protocol.CheckPageOrderAttribute   | Missing page '{pageName}' on pageOrder attribute.                                                                                   |
| 1.22.6 | Protocol.CheckPageOrderAttribute   | Missing WebInterface page.                                                                                                          |
| 1.22.7 | Protocol.CheckPageOrderAttribute   | Web page '{pageName}' should be defined after all regular pages and the first web page should be preceded by a separator.           |
| 1.22.8 | Protocol.CheckPageOrderAttribute   | The specified page '{pageName}' does not exist.                                                                                     |
| 1.22.9 | Protocol.CheckPageOrderAttribute   | Page '{pageName}' has been added more than once to the pageOrder attribute.                                                         |
| 2.9.3  | Param.CheckUnitsTag                | Obsolete unit '{obsoleteUnit}'. New syntax '{newUnit}'. Param ID '{paramPid}'.                                                      |
| 2.9.4  | Param.CheckUnitsTag                | Unknown unit '{unitValue}'. Param ID '{paramPid}'.                                                                                  |
| 2.9.5  | Param.CheckUnitsTag                | Unsupported 'Units' tag for '{paramDisplayType}' Param with ID '{paramPid}'.                                                        |
| 2.9.7  | Param.CheckUnitsTag                | Missing 'Units' tag for '{paramDisplayType}' Param with ID '{paramPid}'.                                                            |
| 2.9.8  | Param.CheckUnitsTag                | Untrimmed tag 'Units' in Param '{pid}'. Current value '{untrimmedValue}'.                                                           |
| 2.11.1 | Param.CheckRangeTag                | Missing 'Range' tag for '{paramDisplayType}' Param with ID '{paramPid}'.                                                            |
| 2.11.2 | Param.CheckRangeTag                | Unsupported 'Range' tag for '{paramDisplayType}' Param with ID '{paramPid}'.                                                        |
| 2.14.3 | Param.CheckDescriptionTag          | Untrimmed tag 'Description' in Param '{pid}'. Current value '{untrimmedValue}'.                                                     |
| 2.31.2 | Param.CheckOptionsAttribute        | Missing column sorting priorities on table '{tablePid}'.                                                                            |
| 2.44.1 | Param.CheckColumnTag               | Missing tag 'Column' in Param '{pid}'.                                                                                              |
| 2.44.2 | Param.CheckColumnTag               | Empty tag 'Column' in Param '{pid}'.                                                                                                |
| 2.44.3 | Param.CheckColumnTag               | Invalid value '{tagValue}' in tag 'Column'. Possible values '{allowedValues}'.                                                      |
| 2.44.4 | Param.CheckColumnTag               | Untrimmed tag 'Column' in Param '{pid}'. Current value '{untrimmedValue}'.                                                          |
| 2.44.5 | Param.CheckColumnTag               | Unrecommended use of more than 2 columns. Page '{pageName}'. Param IDs '{paramIDs}'.                                                |
| 7.1.6  | Timer.CheckTimeTag                 | Duplicate Timer with Time '{timerTime}'. Timer IDs '{timerIDs}'.                                                                    |
| 7.1.7  | Timer.CheckTimeTag                 | Too fast Timer Time '{timerTime}'. Timer ID '{timerId}'.                                                                            |
| 7.1.8  | Timer.CheckTimeTag                 | Timer Time values too similar. Timer IDs '{timerId}'. Time values '{timerTime}'.                                                    |
| 8.1.1  | HTTP.CheckHeaders                  | Missing Header '{headerKey}' in HTTP '{verb}' request. Session ID '{sessionId}'. Connection ID '{connectionId}'.                    |
| 8.1.2  | HTTP.CheckHeaders                  | Duplicate Header '{headerKey}' in HTTP request. Session ID '{sessionId}'. Connection ID '{connectionId}'.                           |
| 8.2.1  | HTTP.CheckHeaderTag                | Untrimmed tag 'Header'. Current value '{tagValue}'.                                                                                 |
| 8.3.1  | HTTP.CheckKeyAttribute             | Invalid Header key '{headerKey}' for HTTP request. Session ID '{sessionId}'. Connection ID '{connectionId}'.                        |
| 8.3.2  | HTTP.CheckKeyAttribute             | Untrimmed Header key '{headerKey}' for HTTP request. Session ID '{sessionId}'. Connection ID '{connectionId}'.                      |
| 8.3.3  | HTTP.CheckKeyAttribute             | Missing key attribute. Session ID '{sessionId}'. Connection ID '{connectionId}'.                                                    |
| 8.3.4  | HTTP.CheckKeyAttribute             | Empty key attribute. Session ID '{sessionId}'. Connection ID '{connectionId}'.                                                      |
| 8.3.5  | HTTP.CheckKeyAttribute             | Invalid Header key '{headerKey}' for HTTP '{verb}' request. Session ID '{sessionId}'. Connection ID '{connectionId}'.               |
| 8.3.6  | HTTP.CheckKeyAttribute             | Header key '{headerKey}' is typically managed automatically by DataMiner. Session ID '{sessionId}'. Connection ID '{connectionId}'. |
| 8.3.7  | HTTP.CheckKeyAttribute             | Unsupported Header key '{headerKey}'. Session ID '{sessionId}'. Connection ID '{connectionId}'.                                     |
| 10.1.1 | Command.CheckCommandLogic          | No 'CRC' Action triggered before Command '{commandId}'. 'CRC' Param '{pid}'.                                                        |
| 11.1.1 | Response.CheckResponseLogic        | No 'CRC' Action triggered before Response '{responseId}'. 'CRC' Param '{paramPid}'.                                                 |

### XML Schema

#### UOM Schema: New units added \[ID_21569\]\[ID_21950\]

The following units have been added to the UOM Schema:

- %RH (relative humidity)
- A_AC (Ampere alternating current)
- A_DC (Ampere direct current)
- Attempts/h (attempts per hour)
- barG (bar gauge pressure)
- Base Units
- bps/Hz (bits per second per hertz)
- Bursts/s (bursts per second)
- Connections (connections)
- dBuV/min (decibel microvolt per minute)
- DU (Dobson Unit)
- g (gram)
- g/m^3 (gram per cubic meter)
- hdln (HD lines)
- hdpx (HD pixels)
- Hits/cm^2 (hits per square centimeter)
- Hits/cm^2/h (hits per square centimeter per hour)
- Hits/in^2 (hits pr square inch)
- Hits/in^2/h (hits per square inch per hour)
- kbarG (kilobar gauge pressure)
- kg/h (kilogram per hour)
- kg/m^3 (kilogram per cubic meter)
- kW/h (kilowatt per hour)
- lb_m/ft^3 (pount-mass per cubic foot)
- MbarG (megabar gauge pressure)
- mbarG (millibar gauge pressure)
- mg/m^3 (milligram per cubic meter)
- mW/cm^2 (milliwatt per square centimeter)
- ppb (parts per billion)
- ppb/s (parts per billion per second - drift)
- Programs
- rps (revolutions per second)
- Segments
- Slots (slots)
- Slots/s (slots per second)
- Tables/s (tables per second)
- Tickets (tickets)
- Ticks (ticks)
- umol/m^2/s (micromole per square meter per second)
- V_AC (volt alternating current)
- V_DC (volt direct current)
- V_RMS (volt root mean square)

#### Protocol Schema: New elements and attributes \[ID_21930\]

The Protocol XML schema now supports the following elements and/or element attributes:

| Element                                                      | Attribute |
|--------------------------------------------------------------|-----------|
| Protocol.Topologies.Topology.Cell.Exposer                    |           |
| Protocol.Topologies.Topology.Cell.Exposer                    | enabled   |
| Protocol.Topologies.Topology.Cell.Exposer.LinkedIds          |           |
| Protocol.Topologies.Topology.Cell.Exposer.LinkedIds.LinkedId |           |
| Protocol.Topologies.Topology.Cell.Exposer.LinkedIds.LinkedId | columnPid |

## Changes

### Enhancements

#### Class Library: SetParameterMessage messages will no longer generate information events \[ID_22296\]

From now on, SetParameterMessage messages will no longer generate information events.

#### Class Library: Property type is now passed along when updating element properties \[ID_22299\]

When an SLNet message is sent to update the value of a writable element property, from now on, the property type will be passed along.

#### Class Library: ‘Name’ and ‘HostName’ properties added to IDma interface \[ID_22301\]

Two new properties have been added to the IDma interface:

- Name
- HostName

#### Class Library: New classes to easily parse trap information \[ID_22302\]

The class library now includes classes to easily parse the trap information when using the allbindinginfo option.

### Fixes

#### Errors thrown by validator and protocol comparison checks \[ID_21983\]

In some cases, the CheckOptionsAttribute and CheckDisplayTag checks would throw an exception.

#### IDE - Table editor: Extra options ';xpos' and ';ypos' would incorrectly be considered as unknown options \[ID_22131\]

In some cases, the “;xpos” and “;ypos” column options would incorrectly be considered as unknown options.

#### IDE - Table editor: Warning messages would incorrectly appear for hidden columns \[ID_22146\]

In the table editor, warning messages would appear, mentioning errors found in hidden columns. From now on, errors in hidden columns will be disregarded.

#### Class Library: GetAgents (IDms) would fail if the response contained a DataMiner Agent ID equal to 0 \[ID_22297\]

In some cases, the GetAgents (IDms) method would fail if the response contained a DataMiner Agent ID equal to 0.
