---
uid: SwarmingPrepare
---

# Preparing your system for Swarming (Alarm ID ranges)

When the Swarming feature is enabled, alarm references need to be globally unique within the cluster. For that reason, alarm IDs will be generated in a different way than in a system without Swarming. It is important to make sure that scripts and connectors are compatible with this to be able to successfully work with a Swarming-enabled setup.

> [!NOTE]
> The changes mentioned on this page require **DataMiner 10.5.1/10.5.0 or higher**. Note that while legacy alarm references may still be used in DataMiner 10.5.1 or higher, they must not be used on systems where the Swarming feature is enabled.

## Terminology

- **Alarm Event**: An object indicating that either a new alarm came up, an existing event was updated (severity changed, properties updated, acknowledged, ...) or was cleared.
- **Root Event**: Initial alarm event, as one is created when there was previously no alarm but now there is.
- **Alarm Tree**: A logical alarm, combining a history of alarm events for the same alarm. A tree will always have a root alarm event plus zero or more alarm event updates that have happened over time. Each update links back to the original root alarm event as well as to the previous alarm event and has a unique alarm ID number (e.g. `444`) within that tree.
- **Alarm Tree ID**: Reference which can be used to uniquely refer to an alarm tree without having to refer to individual alarm events. For example, when adding a comment to an alarm tree, one can send the alarm tree ID to the server to apply the update to the most recent state of that alarm tree. An ID looks like `111/222/333` where `111/222` is a reference to the element involved. The Alarm Tree ID is the preferred way to reference alarm trees.
- **Root Alarm ID**: Legacy number (e.g. `333`) indicating a specific alarm tree. Not guaranteed to be unique across elements or agents.
- **Alarm ID**: Number referencing an alarm event within an alarm tree (e.g. `444`). Not to be used on its own. Can be used in combination with an alarm tree ID in cases where an individual alarm event needs to be referenced. Try to avoid these ([more info](#alarmid-references)). For root alarm events, the alarm ID is identical to the root alarm ID.
- **Hosting Agent ID**: DataMiner ID of the agent on which the element owning the alarm event/tree is currently hosted.

## Context

Up to DataMiner 10.4, the combination `HostingAgentID/RootAlarmID` was typically being used to refer to an alarm tree.

When elements are being migrated between agents ([DELT](xref:Migrating_elements_in_a_DataMiner_System)) or swarmed from one agent to another, this combination of fields is inadequate as it is not unique nor fixed.

While DataMiner will still try to resolve these references where it can, new code should be using `AlarmTreeID` references instead. These combine the `DataMinerID/ElementID/RootAlarmID` fields to end up with a unique reference. Existing code should also be updated to ensure future compatibility.

As long as the Swarming feature has not been enabled, legacy calls will remain functional. However, once the Swarming feature is enabled, multiple elements will start generating the same Root Alarm ID value because of switching to an id-range per element instead of a range per DataMiner agent and using full alarm tree references is required. For Swarming configurations, elements `1/2` and `1/3` can generate unique tree references `1/2/555` and `1/3/555` even though the old system would see these as the same reference (`1/555`).

This document assists in updating code for this. Typically, methods, fields or properties marked as obsolete will also contain guidance in their message.

> [!NOTE]
> Applying these changes is currently only available when already having access to 10.5.1 or 10.5.0 code base. The updated/extended requests only exist in these newer versions. In most cases, they can be used to communicate with older server versions.

> [!NOTE]
> As long as a DataMiner agent has not been upgraded to become a Swarming setup, the 10.5.1 and 10.5.0 versions can still deal with old style alarm references without risk.

## Using `AlarmEventMessage`

A number of properties in the `AlarmEventMessage` class have been marked as obsolete. Below are some scenarios and how to adapt these.

| Case | Guidance |
| -- | -- |
| `alarm.RootAlarmID` | Use `alarm.TreeID` instead. |
| `alarm.HostingAgentID` combined with `alarm.RootAlarmID` | Use `alarm.TreeID` instead. |
| `alarm.HostingAgentID` | Avoid using at all. Client applications should generally not care where the element is hosted. |
| `alarm.BaseAlarms` | Use `CorrelationBaseAlarmReferences` instead. |
| `alarm.CorrelationReferences` | Use `CorrelationBaseAlarmReferences` instead. |
| `alarm.RootAlarmGuid` | Use `alarm.TreeID` instead. |
| `alarm.RootAlarmID == alarm.AlarmID` | Use `alarm.IsTreeRoot` instead. |
| `new AlarmEventMessage(int dmaId, int eid, int pid, int rootKey)` | Use the overload that takes `AlarmTreeID` instead. |
| `alarm.AlarmID` | [Avoid using directly](#alarmid-references). If you do need to, consider using `new AlarmID(alarm)` and use `.EventID` on there. |

## Using `CorrelationDetailsEventMessage`

A number of properties in the `CorrelationDetailsEventMessage` class have been marked as obsolete. Below are some scenarios and how to adapt these.

| Case | Guidance |
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

Often, alarm tree references are being stored internally in dictionaries, lists etc.

Be sure to update these in such a way that they deal with `AlarmTreeID` rather than raw root alarm ids.

Some examples:

| Before | After | Notes |
| -- | -- | -- |
| `Dictionary<int, List<int>>` | `List<AlarmTreeID>` | Scenarios where a list of root alarm ids (int) was kept per DMA ID (int) can be replaced by a single `List` or `HashSet` of `AlarmTreeID` |
| `Dictionary<int, X>` | `Dictionary<AlarmTreeID, X>` | Scenario where a root alarm id (int) was mapped to something else (X) |

Some possible difficulties:

- Code which previously had a list of alarm trees per hosting agent and gets updated might lose the ability to drop all alarm events for a certain agent (e.g. on disconnect). These scenarios will need to be solved differently, e.g. by looking up the relevant alarm trees that have their element hosted on that agent.
- Be aware of performance. Some dictionaries might have previously been optimized for certain types of lookups. Try to keep these lookups fast.

## Communication with server

When communicating with the server, make sure to always pass along the `TreeID`

| Before | After |
| -- | -- |
| `new SetAlarmStateMessage(dmaid, rootalarmid, ...)` | `new SetAlarmStateMessage(treeid, ...)` |
| `new GenerateAlarmMessage(..., rootalarmid, ...)` | `new GenerateAlarmMessage(..., treeToUpdate, ...)` |
| `new GetAlarmTreeDetailsMessage(dmaid, rootAlarmID)` | `new GetAlarmTreeDetailsMessage(AlarmTreeID)` |
| `GetAlarmDetailsMessage` | Use `.Trees` |
| `new CorrelateNowRequest(...)` | Use incident tracking / alarm grouping functionaly instead |
| `GetCorrelationBaseAlarmDetailsMessage` | Use `AlarmEventID` instead of `AlarmID` |
| `GetAlarmLinksMessage` | Do not use. |

## String references

Often, tree references get stored in a string variable as `HostingAgentID + "/" + RootAlarmID`.

- If possible, replace the `string` variable/field by an object of type `AlarmTreeID`.

- Bring the `AlarmTreeID` as close to the location where an actual string reference is required.

- If the receiver of the string reference is known to be capable of dealing with the updated types of references, use `treeID.SerializeToString()` (generates a string `"dmaid/eid/rootalarmid"`).

If you control both sides of a string ID exchange, combine methods `treeID.SerializeToString` and the static `AlarmTreeID.DeserializeFromString` to update both sides.

> [!NOTE]
> Always look into whether legacy `"hostingagentid/rootalarmid"` references still need to remain supported in your code. The `AlarmID.DeserializeFromString` and `SerializeToString` calls allow passing in an `allowLegacy` parameter to be able to convert these to and from `AlarmTreeID` objects (with the element ID then set to `ElementID.MissingValue` and `IsLegacy` set to `true`). This can be useful for cases where an old reference might get loaded from old database or configuration data.

## `.AlarmID` references

Sometimes code currently uses the `AlarmID` property of `AlarmEventMessage`. These usages should be reconsidered. In general, it is always recommended referring to an alarm tree using the `TreeID`.

| Case | Guidance |
| -- | -- |
| using `alarm.AlarmID == alarm.RootAlarmID` to check whether an alarm event is the root/initial event of its tree | Use `alarm.IsTreeRoot` instead. |
| Using `AlarmID` to pass along to the server to trigger some kind of alarm update | Use `TreeID` instead. One can only update the most recent state of an alarm tree anyway. |
| Using `AlarmID` for sorting the events within one tree | Can still be used. Alarm IDs for individual alarm events within an alarm tree will only ever go up |
| Using `AlarmID` to know whether more recent events have already been received within an alarm tree | Can still be used. Alarm IDs for individual alarm events within an alarm tree will only ever go up |
| Using `AlarmID` to know whether more recent events have already been received from a particular agent | This can no longer be relied upon. Try looking into alternatives and think about whether this check is really needed |
| Using `AlarmID` to be sure that the event has passed by already. e.g. when creating an alarm event and wanting to be sure that the event has actually been created. | This can no longer be relied upon. Try looking into alternatives and think about whether this check is really needed |
| Using `AlarmID` + `HostingAgentID` to reference one specific alarm event in a tree | Us the `Skyline.DataMiner.Net.Messages.SLDataGateway.AlarmID` type (`new AlarmID(alarmEventMessage)`). Consider if the reference can be replaced by an alarm tree reference. |

## Performance considerations

As `AlarmTreeID` combines more fields than the legacy `HostingAgentID/RootAlarmID` references, be aware that there will be a performance hit when comparing alarm event objects. This might be more visible if the data structure in which the references are kept is not optimal (e.g. a `List` instead of a `Dictionary`)

Additionally, more memory will be used when keeping a lot of these references in memory, as each reference contains extra data.

## Legacy references and `AlarmTreeID`

In some cases, you might come across legacy input references to alarm trees. These are references in the format `dmaid/rootalarmid` which do not contain info on the element id of the element involved. Below is some guidance on how to deal with these.

| Use case | Guidance |
| --- | --- |
| I need an `AlarmTreeID` instance but have a legacy reference | Use `var treeLegacy = AlarmTreeID.BuildLegacy(dmaid, rootalarmid)`. Be aware that this key might need special handling further down in the code. |
| I have an input string that might be one of `dmaid/rootalarmid` or `dmaid/eid/rootalarmid` and need to make an `AlarmTreeID` from it. | Use `var potentialLegacyRef = AlarmTreeID.DeserializeFromString(str, allowLegacy: true)` |
| I have a `Dictionary`, `List`, `HashSet`, ... with fully specified `AlarmTreeID` instances on which I want to do a best-effort `Contains` action using a potential legacy `AlarmTreeID` instance | Use `collection.Contains(tree, AlarmTreeIDComparisonOptions.AllowLegacy)`. Similar extension methods exist for `TryGetValue`, `ContainsKey` and `Remove`. |

An example is below:

```csharp
var list = new List<AlarmTreeID>();
list.Add(new AlarmTreeID(new ElementID(123, 456), 789));
list.Contains(AlarmTreeID.BuildLegacy(123, 789), AlarmTreeIDComparisonOptions.AllowLegacy); // true
list.Contains(AlarmTreeID.BuildLegacy(123, 789)); // false
```

There's also a class `AlarmTreeIDLegacyEqualityComparer` available which can be used to configure classes like `Dictionary` and `HashSet` to always be able to map to and from legacy references. Do be aware that it is not recommended mixing both legacy and non-legacy values/keys in the same collection. Prefer sticking to either legacy or full objects in your dictionary or collection (preferably full object) and limit the use of the other type to a minimum. Also be aware that legacy lookups are always best-effort. If multiple full keys match, only one will be returned.

```csharp
var set = new HashSet<AlarmTreeID>(new AlarmTreeIDLegacyEqualityComparer());
set.Add(new AlarmTreeID(new ElementID(123, 456), 789));
set.Contains(AlarmTreeID.BuildLegacy(123, 789)); // true
```

## Enhanced Service Connectors

As service elements can have an *Active Service Alarms* table which uses alarm references and these tables are being filled out by DataMiner with alarm references, a connector update might be required before that enhanced service is compatible with a Swarming-enabled system.

> [!NOTE]
> Running enhanced services using non-compatible drivers is being actively blocked when the Swarming feature has been enabled on the system. Having such enhanced services present will block the migration towards a Swarming-enabled system.

> [!NOTE]
> Not all connectors require an update: an update is only required if the current connector defines a parameter 4 (`raw_alarm_input`). Connectors without this parameter do not have an *Active Service Alarms* table and do not need an update.

- Updating the driver starts by adding a new parameter 7 (`raw_alarmid_input`). Note that the name is different from the name of parameter 4.

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

    When this parameter 7 is present, the driver will update the *Active Service Alarms* table using full alarm references on DataMiner versions 10.5.1 or up.

- If you have a QAction triggering on parameter 4, create an extra QAction triggering on the new parameter 7. This QAction will receive full alarm event references (formatted like `dmaid/eid/rootalarmid/alarmid`).

- If you want to keep supporting DataMiner versions before 10.5.1 / 10.6, keep the previously existing parameter 4 and make sure that your QActions can deal with both scenarios (legacy alarm references through parameter 4 or full alarm references through parameter 7)

- If you only need to support DataMiner versions higher than 10.5.1 / 10.6, the parameter 4 and associated QActions can be removed.

- In any case, if any QActions or code relies on the IDs as stored in the *Active Service Alarms* table, make sure that they can deal with either full or legacy type references depending on the DataMiner version they will run on.
