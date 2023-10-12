---
uid: EPM_6.1.7_I-DOCSIS
---

# EPM 6.1.7 I-DOCSIS

## New features

#### CCAP connector configuration and threshold settings available in visual overview [ID_34805]

For each CCAP connector, a *Configuration* and *Threshold Settings* page is now available in Visual Overview with the settings of the connector.

#### Collector configuration and threshold settings available in visual overview [ID_34805]

For the *Generic DOCSIS CM Collector* connector, a *Configuration* and *Threshold Settings* page is now available in Visual Overview with the settings of the connector.

#### New parameter to configure name Automation script responsible for notifying elements of new data to be ingested [ID_36053]

A new parameter, *Script Name*, has been added to the *Configuration* page of the Skyline EPM Platform, Arris E6000 CCAP Platform, Casa System CCAP Platform, Cisco CBR-8 CCAP Platform, CISCO CMTS CCAP Platform, and Huawei 5688-5800 CCAP Platform connectors. With this parameter, you can specify the Automation script responsible for notifying the back-end elements of new data to be ingested.

Similarly, a *Script Name* parameter has been added to the *Configuration* page of the Skyline EPM Platform DOCSIS connector, so you can specify the Automation script responsible for notifying the CCAPs/CM collector pair of new data to be ingested.

#### Passive overview pages with linked CM overview dashboards [ID_36450]

Overview pages have been added for the passive levels (node, amplifier, and tap), which display the KPIs for the selected entry and contain links to navigate to a dashboard with all cable modems associated with the selected device.

The following KPIs are included: CM MAC, IPv4 Address, DOCSIS Version, Status, Vendor, Model Number, Software Version, Last Registration Time, Uptime, US SNR Status, US Time Offset Status, US RX Power Status, US Post FEC Status, DS SNR Status, US TX Power Status, DS Post FEC Status, RTT, Jitter, Latency, Packet Loss, Memory Size, Memory Utilization, Processor Utilization, Reflection Distance, Group Delay Status, Reflection Status, DS RX Power Status, Tap Name, Amplifier Name, Node Segment Name, and Service Group Name.

#### New Automation script to add CCAP/CM pair [ID_36459]

A new Automation script, *EPM_I_DOCSIS_AddNewCcapCmPair*, is now available, which can be used to create a CCAP/CM pair from the EPM UI. The interactive script will take the user through the different steps of the configuration.

#### QAM Channels dashboard migration [ID_36684]

Information about QAM Channel instances has now been moved from the data pages of the EPM entities to dedicated dashboards (i.e. *NODE SEGMENT/01. DS QAM Channels* and *NODE SEGMENT/02. US QAM Channels*). A visual overview is also available containing the overview information for the EPM entities with links to new dashboards.

For this purpose, new scripts have also been added, which retrieve the QAM Channel-related data in order to display it in the dashboards: *EPM_I_DOCSIS_GQI_GET_ALL_DS_QAM_DATA* and *EPM_I_DOCSIS_GQI_GET_ALL_US_QAM_DATA*.

#### Cable Modem KPIs dashboard migration [ID_36686]

To improve the stability of the system, the information about Cable Modem KPIs has now been moved to a dashboard (i.e. *CM/01. CM Overview*). A Cable Modem visual overview is also available with the most important KPIs and a link to the dashboards. If you click the link, the relevant cable modem will automatically be selected in the dashboard.

For this purpose, a new script has also been added, which retrieves the CM-related data in order to display it in the dashboards: *EPM_I_DOCSIS_GQI_GET_ALL_CM_DATA*.

#### Tables with passives information added to key topology levels [ID_36719]

On the CCAP, Line Cards, Node Segment, and Service Group topology level, a tab with passive levels tables (Node, Amplifier, Tap, and Subscriber) has been added.

#### CM QAM US/DS Channels migrated to dashboards [ID_36720]

The  CM QAM US Channel and CM QAM DS Channel tabs at the CM topology level have been migrated to dedicated dashboards (i.e. *CM/03. CM US QAM Channels* and *CM/02. CM DS QAM Channels*, respectively). You can access these dashboards by clicking a button in Visual Overview at the CM Overview topology level.

To support this, the following new scripts have been added: *EPM_I_DOCSIS_GQI_GET_ALL_CM_DS_QAM_DATA*, *EPM_I_DOCSIS_GQI_GET_ALL_CM_US_QAM_DATA*, *EPM_I_DOCSIS_CM_DS_QAM_CHANNEL*, and *EPM_I_DOCSIS_CM_US_QAM_CHANNEL*.

## Changes

### Enhancements

#### Use of NuGet packages and SKIP_INITIAL_INFO_EVENT option [ID_34835]

The EPM connectors have been updated to use the *lib.common* and *lib.protocol* NuGet packages instead of the class library and QAction 63000.

In addition, the *SKIP_INITIAL_INFO_EVENT* option can now be used when a script is executed, so that no "Script started" information event is generated. To use this option, add "SKIP_STARTED_INFO_EVENT:TRUE" to the *scriptOptions* when sending a *ExecuteScriptMessage*.

For example:

```csharp
string[] scriptOptions = { "OPTIONS:0", "CHECKSETS:TRUE", "EXTENDED_ERROR_INFO", "DEFER:TRUE", "SKIP_STARTED_INFO_EVENT:TRUE", String.Format("PARAMETER:2:{0}", pairList) };
            var message = new SLNetMessages.ExecuteScriptMessage
            {
               ScriptName = "EpmBeToCcapPair",
               Options = new SLNetMessages.SA(scriptOptions),
            };
```

#### CPU Utilization, Memory Utilization, and Uptime parameters added to CCAP data pages [ID_35886]

On the CCAP data pages, the CPU Utilization, Memory Utilization, and Uptime parameters have been added. Previously, these parameters were available on the visual pages, but they were missing on the data pages.

#### Generic DOCSIS CM Collector connector performance improved [ID_35887]

To improve performance, the logic used by the Generic DOCSIS CM Collector connector has been adjusted. This will prevent possible spikes in CPU usage.

#### New trigger in Skyline EPM Platform visual overview improves DataMiner Maps loading time [ID_35952]

A new trigger has been added to the *_epmBE* card variable in the *Skyline EPM Platform* visual overview. It sets the variable to the DMA ID/element ID of the back-end element based on the CCAP name.

With this new trigger, it is no longer necessary to create a card variable for each back-end element in the system and different triggers for each of those card variables. This improves the DataMiner Maps loading time.

#### CCAPs adjusted to ingest cable modems with ASCII IP addresses [ID_35977]

The CCAP connectors have been adjusted so that they will now ingest cable modems with ASCII IP addresses. Previously, such cable modems were ignored and assigned an N/A value.

#### Filter box loading time improved by enabling partial table option [ID_36055]

To improve the loading time of the filter box that is displayed when you use the filter sections of the EPM topology chain, the partial table option has now been enabled on the following tables:

- Service group
- US and DS Service Group
- US and DS Port
- US and DS Linecard
- Node Segment
- Node, Tap, and Amplifier

#### RTDisplay set to false for columns used for aggregating/debugging [ID_36112]

To improve performance and reduce the load on SLElement, RTDisplay has now been set to false for all columns that are used for aggregating and debugging purposes.

#### Elements in EPM Solution now use inter-app calls [ID_36326]

Inter-app calls will now be used for the communication between elements used in the EPM Solution, such as the back end and the Workflow Manager (WM), resulting in faster and more efficient communication. This way, the solution no longer needs to rely on information events and alarms triggered by Automation scripts and Correlation rules.

The following changes have been done to the Skyline EPM Platform DOCSIS connector (back end):

- The connector no longer uses calls to information events to pass information.
- Inter-app calls are now aggregated to send information to the WM.
- Information from the WM is now processed through inter-app communication.

The following changes have been done to the Skyline EPM Platform DOCSIS WM connector:

- The connector no longer uses calls to information events to pass information.
- Parameters that are used to capture information events are no longer used.
- Inter-app calls are now aggregated to send information to the back-end elements.
- Information coming from the back-end elements is now processed through inter-app communication.

#### Unnecessary columns hidden on topology data pages [ID_36451]

The following columns are now by default hidden on the topology data pages, so that the pages have a cleaner look: *Network ID*, *Market ID*, *Hub ID*, *View Impact*, *CCAP Core ID*, *DS Line Card ID*, *US Line Card ID*, *DS Port ID*, *US Port ID*, *Node Segment ID*, *CM ID*, *Service Group ID*, *DS Service Group ID*, *US Service Group ID*, *Number Other DOCSIS*, *Node ID*, *Amplifier ID*, and *Tap ID*.

#### Exception values added for percentage, latitude, and longitude parameters [ID_36452]

To prevent parameters getting an incorrect negative value, exception values have been added to the Percentage Ping OK and Percentage Ping Unreachable parameters on the node and amplifier level, as well as to the latitude and longitude parameters on amplifier and tap level. These parameters will now display "N/A" when an exception occurs.

### Fixes

#### EPM front-end element threw 'process cannot access the file because it is being used by another process' exceptions [ID_34658]

In some cases, logging for the EPM front-end element could contain exceptions like the following example:

```txt
2022/04/16 00:32:09.380|SLManagedScripting.exe|ManagedInterop|ERR|0|18|QA29|WriteCsvFile|Error writing csv file:System.IO.IOException: The process cannot access the file 'C:\DataMiner EPM\DOCSIS\Passive Relation\EP\26446_7_PASSIVERELATION_EP.csv' because it is being used by another process.
   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
   at System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
   at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize, FileOptions options, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
   at System.IO.StreamWriter.CreateFile(String path, Boolean append, Boolean checkHost)
   at System.IO.StreamWriter..ctor(String path, Boolean append, Encoding encoding, Int32 bufferSize, Boolean checkHost)
   at System.IO.StreamWriter..ctor(String path)
   at Skyline.Protocol.Generic.ProvisioningHelp.WriteCsvFile(SLProtocolExt protocol, List`1 lines, String path)
```

To prevent this, the Skyline EPM Platform connector will now retry three times to edit a CSV file, with a 1-second delay.

#### Arris E6000 CCAP Platform: Incorrect US QAM Ch Utilization values [ID_34660]

In the US QAM Channel table for the Arris E6000 CCAP Platform, it could occur that the US QAM Ch Utilization showed incorrect values.

#### CCAP platform connectors: Exception because file is being used by another process [ID_34780]

After a CCAP platform element started up, it could occur that an exception similar to the following was thrown:

```txt
2022/09/19 05:28:24.499|SLManagedScripting.exe|ManagedInterop|ERR|0|211|QA213|DecompressTopicFile|Not able to perform decompression on file. Error: System.IO.IOException: The process cannot access the file 'C:\Skyline DataMiner\Documents\DOCSIS\ActiveQAMChannels\114404_10_DSQAM_CH.gz' because it is being used by another process.
```

Retry logic has now been added to all CCAP platform connectors to prevent this issue.

#### Run-time error caused by CCAP connector [ID_35599]

In some cases, CCAP connectors could cause run-time errors. To prevent this, the *partialSNMP* option has been added to all SNMP tables in order to divide the polling over several smaller groups.

#### Invalid ID in passive tables [ID_35659]

When there were no passive files to be processed, there could be an empty row with ID -1 in the Tap table. This happened when source elements contained an exception value that was used for grouping during merge actions. To prevent this, the table keys are now added first, and merge action results are limited so that no other keys are added afterwards.

In addition, the passive tables are now only filled in when the CCAP/collector pairs in the Registration table are present and CCAP elements are running. This way tables do not get updated with data from inactive elements or invalid CCAP/collector data.

#### CCAP visual pages not loading correctly [ID_35953]

When the name of CCAP elements contained a hyphen, the CCAP page of the *Skyline EPM Platform* and *Skyline EPM Platform DOCSIS* visual overviews did not load correctly, because this character was also used as a separator in those visual overviews. To resolve this issue, a dollar sign is now used as separator instead.

#### Skyline EPM Platform DOCSIS: Incorrect default value for average percentage US and DS utilization [ID_36096]

Up to now, the default value of the average percentage of US and DS utilization for the Skyline EPM Platform DOCSIS back-end connector was incorrectly indicated as "0". This has now been corrected to the exception value "-1".

#### Too many cable modems report to have other DOCSIS version [ID_36317]

A problem with the aggregating actions used to count the number of CMS with other DOCSIS versions could cause some CCAPs to incorrectly report a high number of cable modems with other DOCSIS versions.

To resolve this, a number of changes were implemented to the Generic CM Collector connector:

- CMs that have DOCSIS version 1.0, 1.1, or "Not initialized" will now be considered to have an unknown DOCSIS version.
- Exception values have been added to several columns in the cable modem table.
- Instead of the previous table cleanup method, the cable modem table is now cleaned up when the element starts up.

In the Skyline EPM Platform and Skyline EPM Platform DOCSIS connectors, exception values were also added to several columns of the cable modem overview table.

In addition, for the Skyline EPM Platform DOCSIS connector, the *SetEmptyColumns* method will now set exception values for the latitude and longitude parameters.

#### Group Delay or Reflection Status incorrectly calculated based on NMTTER threshold [ID_36344]

Up to now, the Group Delay or Reflection Status parameter was not calculated correctly, because it was calculated based on the NMTTER threshold. To address this issue, new logic has been implemented: If either the Group Delay Status or the Reflection Status is marked as out of specification (OOS), the Group Delay or Reflection Status parameter will also be marked as out of specification (OOS). If both the Group Delay Status and the Reflection Status are marked as OK, the parameter will be marked as OK.

#### CM missing on map [ID_36448]

It could occur that CMs were missing on the maps in the EPM Solution even if geo localization was available for them. The filters of the XML files controlling the maps (i.e. *EPM_MAPS_AMPLIFIER_CPE*, *EPM_MAPS_NODE_CPE*, *EPM_MAPS_NODE_SEGMENT_CPE*, and *EPM_MAPS_TAP_CPE*) have been adjusted to correct this issue.
