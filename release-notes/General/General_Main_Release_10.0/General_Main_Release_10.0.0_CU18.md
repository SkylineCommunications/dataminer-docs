---
uid: General_Main_Release_10.0.0_CU18
---

# General Main Release 10.0.0 CU18

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Improved performance when including/excluding elements in services based on alarm or element alarm state \[ID_30303\]

Performance has improved when elements are dynamically included or excluded in a service based on alarm state or element alarm state.

#### Security enhancements \[ID_30479\] \[ID_30570\] \[ID_30597\] \[ID_30600\] \[ID_30604\] \[ID_30786\]

A number of security enhancements have been made.

#### Service & Resource Management: Interface state calculation for virtual function interfaces disabled \[ID_30537\]

As the interfaces of virtual functions are generated from a table that cannot be monitored, the interface state calculation for these interfaces is now disabled. This may result in improved performance.

#### Service & Resource Management: Improved performance when processing virtual functions \[ID_30585\]

A number of enhancements have been implemented to improve performance when processing virtual functions.

#### SLElement: Enhanced performance when looking up linked rows after a foreign key has changed \[ID_30747\]

Due to a number of enhancements, overall performance of SLElement has increased when looking up linked rows after a foreign key has changed.

### Fixes

#### Slow initial synchronization of services in DMS \[ID_30074\]

In some cases, it could occur that the initial synchronization of services in a DMS was slow because of unnecessary errors generated in the SLDMS process. Usually, an error similar to the following was logged:

```txt
2021/06/03 01:00:00.302|SLDMS.txt|SLDMS.exe 10.1.2118.668|13524|26072|CSystem::ResolveServicePaths|ERR|-1|Failed resolving hosting DMA info for 10.10.80.20 and service RT_ServiceCreationDelete_66_2021_06_03_00_58
```

#### Problem with conditional monitoring after alarm template update \[ID_30531\]

When an alarm template was refreshed in the SLElement process, e.g. because the alarm template was modified or the baseline changed, it could occur that conditional monitoring was ignored for standalone parameters. Because of this, if a parameter was not monitored because the condition for this was met, it was shown as monitored regardless.

#### Automation: CheckboxList and RadiobuttonList not decoding backslash correctly \[ID_30605\]

In an interactive Automation script, it could occur that the *CheckboxList* and *RadiobuttonList* components did not correctly decode a backslash ("\\") character.

#### Information about running elements missing in SLProtocol logging \[ID_30612\]

Since DataMiner 9.6.0/9.6.1, information about running elements could be missing in the SLProtocol logging.

#### DataMiner Cube - Spectrum Analysis: Problem when retrieved client session data contained duplicate keys \[ID_30644\]

When you open a spectrum analyzer element in Cube, it will retrieve all client sessions of that spectrum element. Up to now, when the retrieved client session data contained duplicate keys, an exception could be thrown. From now on, a log entry will be generated instead.

#### GetAlarmFilterResponse and GetTrendFilterResponse messages caused protocol buffer serialization errors \[ID_30650\]

In some cases, it could occur that the *GetAlarmFilterResponse* and *GetTrendFilterResponse* messages failed to be serialized even though these were marked as eligible for protocol buffer serialization. An error similar to the following could be displayed in the Cube logging:

```txt
Message : Index was outside the bounds of the array.
Exception : (Code: 0x80131508) Skyline.DataMiner.Net.Exceptions.DataMinerException: Index was outside the bounds of the array. ---> System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at System.Collections.Generic.List\`1.Add(T item)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.Log(String method, String text)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.ProtoBufPackMessage(DMSMessage rawMessage)
```

The scenarios where these messages cannot be serialized will now be handled better, so that they can no longer cause errors. In addition, to make it easier to troubleshoot errors with protocol buffer serialization, a new *SLProtobufSerialization.txt* log file is now available.

#### CRC parameter with LengthType 'fixed' and RawType 'other', 'text' or 'numeric text' would incorrectly always be set to 0x20 or 0x30 \[ID_30730\]

When a CRC parameter with LengthType “fixed” and RawType “other”, “text” or “numeric text” was used in a command, it would incorrectly always be set to 0x20 characters for parameter of type “string” or 0x30 characters for parameters of type “double”.

#### Problem with SLDataMiner when using alarm templates with a monitoring schedule \[ID_30732\]

In some cases, an error could occur in SLDataMiner when alarm templates with a monitoring schedule were being used.

#### Problem with SLDataMiner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded \[ID_30743\]

In some cases, an error could occur in SLDataMIner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded.

#### SLAnalytics: Problem when retrieving data at startup \[ID_30744\]

In some cases, an error could occur when SLAnalytics retrieved data from the database at startup.

#### DataMiner Cube - Visual Overview: Cube could become unresponsive while retrieving service states \[ID_30762\]

When a visual overview with at least one service shape was open when you opened a Cube, and the initial service states had not yet been received, in some cases, Cube could become unresponsive while retrieving the service states.

#### DataMiner Cube: Problem when hovering the mouse pointer over an alarm storm warning \[ID_30799\]

When, during an alarm storm, you hovered the mouse pointer over the alarm storm warning, in some cases, an exception could be thrown.

#### DataMiner Cube - Alarm Console: Comments containing a new line would be displayed incorrectly \[ID_30801\]

When an alarm contains one or more comments, you can right-click it and select “View comments” to see all comments in the alarm tree in question. In that list, up to now, comments containing a new line would not be displayed correctly.
