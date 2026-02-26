---
uid: SwarmingPrepare
---

# Preparing scripts and connectors for Swarming

When the [Swarming](xref:Swarming) feature is enabled, alarm references need to be globally unique within the cluster. For that reason, alarm IDs will be generated in a different way than in a system without Swarming. It is important to make sure that scripts and connectors are compatible with this to be able to successfully work with a Swarming-enabled setup.

> [!NOTE]
> The changes mentioned on this page require **DataMiner 10.5.1/10.5.0 or higher**. Note that while legacy alarm references may still be used in DataMiner 10.5.1 or higher, they must not be used on systems where the Swarming feature is enabled.

## About the alarm ID changes

In order to implement the necessary changes to prepare for Swarming, you first need to understand what the alarm ID changes are that get introduced with Swarming and what their consequences are.

For this purpose, you need to be familiar with the following terminology:

- **Alarm event**: An object indicating that either a new alarm came up, an existing event was updated (severity changed, properties updated, acknowledged, etc.), or an existing event was cleared.
- **Root event**: Initial alarm event, when an alarm is created where previously there was no alarm.
- **Alarm tree**: A logical alarm, combining a history of alarm events for the same alarm. A tree will always have a root alarm event. Any alarm event updates that have happened over time will be added to this. Each update links back to the original root alarm event as well as to the previous alarm event and has a unique alarm ID number (e.g., `444`) within that tree.
- **Alarm tree ID**: Reference that can be used to uniquely refer to an alarm tree without having to refer to individual alarm events. For example, a comment is added to an alarm tree, the alarm tree ID can be sent to the server to apply the update to the most recent state of that alarm tree. An ID has the format `111/222/333`, where `111/222` is a reference to the element involved. The Alarm tree ID is the preferred way to reference alarm trees.
- **Root alarm ID**: Legacy number (e.g., `333`) indicating a specific alarm tree. This is not guaranteed to be unique across elements or DMAs.
- **Alarm ID**: Number referencing an alarm event within an alarm tree (e.g., `444`). This should not be used on its own, but it can be used in combination with an alarm tree ID in cases where an individual alarm event needs to be referenced. Try to avoid such [alarm ID references](#alarmid-references)). For root alarm events, the alarm ID is identical to the root alarm ID.
- **Hosting Agent ID**: The DataMiner ID of the DMA where element was hosted at the time the alarm event/tree was created.

In DataMiner versions prior to DataMiner 10.5.0/10.5.1, the combination `HostingAgentID/RootAlarmID` is typically used to refer to an alarm tree. When elements are [migrated between DMAs](xref:Migrating_elements_in_a_DataMiner_System) or swarmed from one DMA to another, this combination of fields is inadequate as it is not unique or fixed.

While DataMiner will still try to resolve these references where it can, new code should use `AlarmTreeID` references instead. These combine the `DataMinerID/ElementID/RootAlarmID` fields to end up with a unique reference. Existing code should also be updated to ensure future compatibility.

As long as the Swarming feature has not been enabled yet, legacy calls will remain functional. However, once the Swarming feature is enabled, multiple elements will start generating the same root alarm ID value because DataMiner will switch to using an ID range per element instead of a range per DataMiner Agent. Using full alarm tree references therefore becomes required. For Swarming configurations, elements `1/2` and `1/3` can generate the unique tree references `1/2/555` and `1/3/555`, while the old system would see these as the same reference (`1/555`).

This means that code in automation scripts and connectors may need updates to account for this change. You can find more information about the required changes below. Typically, methods, fields, or properties marked as obsolete will also contain guidance in their message.

> [!NOTE]
>
> - Keep in mind that you will need to have access to the DataMiner 10.5.1 or 10.5.0 code base to apply these changes, as otherwise the updated/extended requests will not be available yet. You will be able to use these updated/extended requests to communicate with older server versions.
> - As long as Swarming has not been enabled yet, DataMiner will still be able to deal with old-style alarm references without any risk, even if you have upgraded to a version where Swarming is supported.

## Obsolete Engine methods

The following Engine methods are obsolete and should not be used. Instead, use the corresponding new methods:

| Obsolete method | New method |
| -- | -- |
| GetAlarmProperty(int, int, string) | GetAlarmProperty(AlarmID*, string) |
| SetAlarmProperty(int, int, string, string) | SetAlarmProperty(AlarmTreeID, string, string) |
| SetAlarmProperties(int, int, string[], string[]) | SetAlarmProperties(AlarmTreeID, string[], string[]) |
| AcknowledgeAlarm(int, int, string) | AcknowledgeAlarm(AlarmTreeID, string) |

* Note that by `AlarmID`, we here refer to the `AlarmID` type which includes both the Alarm tree ID and the Alarm ID.

## Obsolete properties in the AlarmEventMessage class

A number of properties in the `AlarmEventMessage` class have been marked as obsolete. If these are currently used in your code, you will need to adjust this.

Below you can find an overview of how these should be adapted.

| Case | How to adapt |
| -- | -- |
| `alarm.RootAlarmID` | Use `alarm.TreeID` instead. |
| `alarm.HostingAgentID` combined with `alarm.RootAlarmID` | Use `alarm.TreeID` instead. |
| `alarm.HostingAgentID` | Avoid using this at all. Client applications should generally not care where the element is hosted. |
| `alarm.BaseAlarms` | Use `CorrelationBaseAlarmReferences` instead. |
| `alarm.CorrelationReferences` | Use `CorrelationBaseAlarmReferences` instead. |
| `alarm.RootAlarmGuid` | Use `alarm.TreeID` instead. |
| `alarm.RootAlarmID == alarm.AlarmID` | Use `alarm.IsTreeRoot` instead. |
| `new AlarmEventMessage(int dmaId, int eid, int pid, int rootKey)` | Use the overload that takes `AlarmTreeID` instead. |
| `alarm.AlarmID` | Avoid using this directly (see [.AlarmID references](#alarmid-references)). If you do need this, consider using `new AlarmID(alarm)` with `.EventID`. |

## Obsolete properties in the CorrelationDetailsEventMessage class

A number of properties in the `CorrelationDetailsEventMessage` class have been marked as obsolete. If these are currently used in your code, you will need to adjust this.

Below you can find an overview of how these should be adapted.

| Case | How to adapt |
| -- | -- |
| `details.RootAlarmID` | Use `details.AlarmTreeID` instead. |
| `details.HostingAgentID` combined with `details.RootAlarmID` | Use `details.AlarmTreeID` instead. |
| `details.RootAlarmID == details.AlarmID` | Use `alarm.IsAlarmTreeRoot` instead. |
| `new CorrelationDetailsEventMessage(..., int rootKey)` | Use the overload that takes `AlarmTreeID` instead. |
| `details.BaseAlarms` | Use `details.BaseAlarmTrees` instead. |
| `details.CorrelationDetails` | Use `details.BaseAlarmTrees` instead. |
| `details.MissingAlarmIds` | Use `details.MissingBaseAlarmTrees` instead. |
| class `CorrelationReference` | Use class `AlarmTreeID` instead. |

## Internal data structures

Often, alarm tree references are stored internally in dictionaries, lists, etc. Be sure to update these in such a way that they deal with `AlarmTreeID` rather than raw root alarm IDs.

Some examples:

| Before | After | Notes |
| -- | -- | -- |
| `Dictionary<int, List<int>>` | `List<AlarmTreeID>` | Scenarios where a list of root alarm IDs (int) was kept per DMA ID (int) can be replaced by a single `List` or `HashSet` of `AlarmTreeID`. |
| `Dictionary<int, X>` | `Dictionary<AlarmTreeID, X>` | Scenario where a root alarm ID (int) was mapped to something else (X). |

Some possible difficulties:

- Code that previously had a list of alarm trees per hosting Agent and gets updated might lose the ability to drop all alarm events for a certain Agent (e.g., on disconnect). These scenarios will need to be solved differently, e.g., by looking up the relevant alarm trees that have their element hosted on that Agent.
- Keep the [impact of your changes on performance](#performance-considerations) in mind. Some dictionaries might have previously been optimized for certain types of lookups. Try to keep these lookups fast.

## Communication with the server

When communicating with the server, make sure to always pass along the `TreeID`:

| Before | After |
| -- | -- |
| `new SetAlarmStateMessage(dmaid, rootalarmid, ...)` | `new SetAlarmStateMessage(treeid, ...)` |
| `new GenerateAlarmMessage(..., rootalarmid, ...)` | `new GenerateAlarmMessage(..., treeToUpdate, ...)` |
| `new GetAlarmTreeDetailsMessage(dmaid, rootAlarmID)` | `new GetAlarmTreeDetailsMessage(AlarmTreeID)` |
| `GetAlarmDetailsMessage` | Use `.Trees`. |
| `new CorrelateNowRequest(...)` | Use the [alarm grouping](xref:Automatic_alarm_grouping) functionality instead. |
| `GetCorrelationBaseAlarmDetailsMessage` | Use `AlarmEventID` instead of `AlarmID`. |
| `GetAlarmLinksMessage` | Do not use. |

## String references

Often, tree references get stored in a string variable as `HostingAgentID + "/" + RootAlarmID`.

- If possible, replace the `string` variable/field by an object of type `AlarmTreeID`.

- Bring the `AlarmTreeID` as close as possible to the location where an actual string reference is required.

- If the receiver of the string reference is known to be capable of dealing with the updated types of references, use `treeID.SerializeToString()` (generates a string `"dmaid/eid/rootalarmid"`).

If you control both sides of a string ID exchange, combine the methods `treeID.SerializeToString` and the static `AlarmTreeID.DeserializeFromString` to update both sides.

> [!NOTE]
> Always look into whether legacy `HostingAgentID/RootAlarmID` references still need to remain supported in your code. The `AlarmID.DeserializeFromString` and `SerializeToString` calls allow you to pass an `allowLegacy` parameter to be able to convert these to and from `AlarmTreeID` objects (with the element ID then set to `ElementID.MissingValue` and `IsLegacy` set to `true`). This can be useful for cases where an old reference might get loaded from old database or configuration data.

## AlarmID references

Sometimes code uses the `AlarmID` property of `AlarmEventMessage`. This usage should be reconsidered. In general, we recommend referring to an alarm tree using the `TreeID`.

| Case | How to adapt |
| -- | -- |
| Using `alarm.AlarmID == alarm.RootAlarmID` to check whether an alarm event is the root/initial event of its tree. | Use `alarm.IsTreeRoot` instead. |
| Using `AlarmID` to pass along to the server to trigger some kind of alarm update. | Use `TreeID` instead. In any case, only the most recent state of an alarm tree can be updated. |
| Using `AlarmID` for sorting the events within one tree. | Can still be used. Alarm IDs for individual alarm events within an alarm tree will only ever go up |
| Using `AlarmID` to know whether more recent events have already been received within an alarm tree. | Can still be used. Alarm IDs for individual alarm events within an alarm tree will only ever go up |
| Using `AlarmID` to know whether more recent events have already been received from a particular Agent. | This can no longer be relied upon. Try looking into alternatives and think about whether this check is really needed |
| Using `AlarmID` to be sure that the event has passed already, e.g., when creating an alarm event, to be sure that the event has actually been created. | This can no longer be relied upon. Try looking into alternatives and think about whether this check is really needed |
| Using `AlarmID` + `HostingAgentID` to reference one specific alarm event in a tree. | Us the `Skyline.DataMiner.Net.Messages.SLDataGateway.AlarmID` type (`new AlarmID(alarmEventMessage)`). Consider if the reference can be replaced by an alarm tree reference. |

## Performance considerations

As `AlarmTreeID` combines more fields than the legacy `HostingAgentID/RootAlarmID` references, be aware that there will be a performance hit when comparing alarm event objects. This might be more visible if the data structure in which the references are kept is not optimal (e.g., a `List` instead of a `Dictionary`).

Additionally, more memory will be used when a lot of these references are kept in memory, as each reference contains extra data.

## Legacy references and AlarmTreeID

In some cases, you might come across legacy input references to alarm trees. These are references in the format `dmaid/rootalarmid` that do not contain info on the element ID of the element involved. Below you can find several use cases where this occurs and how you can deal with these.

| Use case | Solution |
| --- | --- |
| I need an `AlarmTreeID` instance but have a legacy reference. | Use `var treeLegacy = AlarmTreeID.BuildLegacy(dmaid, rootalarmid)`. Keep in mind that this key might need special handling further down in the code. |
| I have an input string that might be of `dmaid/rootalarmid` or `dmaid/eid/rootalarmid` format and need to make an `AlarmTreeID` based on this. | Use `var potentialLegacyRef = AlarmTreeID.DeserializeFromString(str, allowLegacy: true)`. |
| I have a `Dictionary`, `List`, `HashSet`, etc. with fully specified `AlarmTreeID` instances on which I want to do a best-effort `Contains` action using a potential legacy `AlarmTreeID` instance. | Use `collection.Contains(tree, AlarmTreeIDComparisonOptions.AllowLegacy)`. Similar extension methods exist for `TryGetValue`, `ContainsKey`, and `Remove`. |

Example:

```csharp
var list = new List<AlarmTreeID>();
list.Add(new AlarmTreeID(new ElementID(123, 456), 789));
list.Contains(AlarmTreeID.BuildLegacy(123, 789), AlarmTreeIDComparisonOptions.AllowLegacy); // true
list.Contains(AlarmTreeID.BuildLegacy(123, 789)); // false
```

A class `AlarmTreeIDLegacyEqualityComparer` is also available, which can be used to configure classes like `Dictionary` and `HashSet` to always be able to map to and from legacy references. However, keep in mind that mixing legacy and non-legacy values/keys in the same collection is not recommended. If at all possible, stick to either legacy or (preferably) full objects in your dictionary or collection, and limit the use of the other type to a minimum. Note also that legacy lookups are always best-effort. If multiple full keys match, only one will be returned.

```csharp
var set = new HashSet<AlarmTreeID>(new AlarmTreeIDLegacyEqualityComparer());
set.Add(new AlarmTreeID(new ElementID(123, 456), 789));
set.Contains(AlarmTreeID.BuildLegacy(123, 789)); // true
```

## Enhanced service connectors

As service elements can have an *Active Service Alarms* table that uses alarm references, and these alarm references get added to the table by DataMiner, enhanced service connectors may also need to be updated to make sure the enhanced services are compatible with a Swarming-enabled system.

Once the Swarming feature has been enabled, running enhanced services using non-compatible connectors will not be possible. It is also not possible to enable Swarming as long as such enhanced services are present in the system.

> [!NOTE]
> Not all connectors may require an update: an update is only required if the connector defines a parameter 4 (`raw_alarm_input`). Connectors without this parameter do not have an *Active Service Alarms* table and do not need an update.

- Updating the protocol.xml starts by adding a new parameter 7 (`raw_alarmid_input`). Note that the name is different from the name of parameter 4.

    ```xml
    <Param id="7">
      <Name>raw_alarmid_input</Name>
      <Description>raw_alarmid_input</Description>
      <Type>read</Type>
      <Interprete>
        <RawType>other</RawType>
        <LengthType>next param</LengthType>
        <Type>string</Type>
      </Interprete>
      <Measurement>
        <Type>string</Type>
      </Measurement>
    </Param>
    ```

    When this parameter 7 is present, the connector will update the *Active Service Alarms* table using full alarm references from DataMiner 10.5.1/10.6.0 onwards.

- If you have a QAction triggering on parameter 4, create an extra QAction triggering on the new parameter 7. This QAction will receive full alarm event references (in the format `dmaid/eid/rootalarmid/alarmid`).

- If you want to keep supporting DataMiner versions prior to 10.5.1/10.6.0, keep the previously existing parameter 4 and make sure that your QActions can deal with both scenarios (legacy alarm references through parameter 4 or full alarm references through parameter 7). If you only need to support DataMiner versions higher than 10.5.1/10.6.0, the parameter 4 and associated QActions can be removed.

- In any case, if any QActions or code rely on the IDs as stored in the *Active Service Alarms* table, make sure that they can deal with either full or legacy type references depending on the DataMiner version they will run on.
