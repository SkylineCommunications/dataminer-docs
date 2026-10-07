---
uid: MediaOps_Live_1.2.0
description: Highlights of the features, enhancements, and fixes included in the MediaOps Live 1.2.0 release, including improved CSV encoding.
---

# MediaOps Live 1.2.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.11/10.7.0 or higher.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.2.5 or higher.

> [!TIP]
> Installing [MediaOps Plan](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) alongside MediaOps Live allows you to schedule orchestration events. This requires MediaOps Plan **1.5.0** or higher.

## Enhancements

### DevPack: Asynchronous orchestration event execution [ID 46394]

The MediaOps Live DevPack now supports asynchronous execution of previously saved orchestration events. You can use the new `ExecuteEventsNowInBackground` methods on `OrchestrationHelper` to start event execution without blocking the calling script.

You can provide the event IDs:

```csharp
IEnumerable<Guid> eventIds =
[
    firstEventId,
    secondEventId,
];

orchestrationHelper.ExecuteEventsNowInBackground(eventIds);
```

Alternatively, you can provide the corresponding `OrchestrationEvent` objects directly:

```csharp
orchestrationHelper.ExecuteEventsNowInBackground(orchestrationEvents);
```

The DevPack will launch the `ORC-AS-EventOrchestration` automation script as a deferred fire-and-forget task and immediately return control to the caller. You must save the events before calling either method because the background script retrieves them by ID.

When you start an event scheduled for the future this way, its scheduled task will be removed to prevent duplicate execution. Failures during background execution will continue to be reported in the state of the associated job.

### Support for orchestration scripts with dynamic inputs [ID 46654]

Up to now, an orchestration script always asked for the same fixed list of input arguments, and every argument had to be a profile parameter. When the arguments a script needed depended on another choice, for example the number of destinations or the selected transport mode, the only option was to create a separate script, and therefore a separate resource pool, for each combination.

Orchestration scripts can now define dynamic inputs: inputs that adapt to the values that have already been provided. This means that a single script can now cover use cases that previously required several scripts. For example:

- Changing the number of destinations adds or removes destination inputs.
- Selecting a mode can show additional settings that only apply to that mode.
- Selecting a band can narrow the allowed frequency range, and selecting an antenna can limit the satellites you can choose from.

Dynamic inputs belong to the script itself. Creating or maintaining profile parameters for them is not needed, and they are not used when resources are matched based on their capabilities or capacities.

Inputs can be organized in groups, so settings that belong together are shown together and in a meaningful order. The following input types are supported: text, number, dropdown, date and time, and duration. Each input can have its own range, step size, unit, options, and default value, and can be marked as required. The script can also report a value as invalid with its own message, for example when two destinations use the same endpoint.

The values configured for an orchestration event are stored with that event:

- When an event is saved or confirmed, its values are validated. If a required value is missing or a value is not valid, the event is rejected with a message indicating which input needs attention.
- When you run a script manually and a value is missing or not valid, you are asked to provide it.
- The event information now shows the dynamic inputs of an event together with their values.

Existing orchestration scripts continue to work without any changes.

To get started, take a look at the *MediaOps_Live_Example_DynamicOrchestration* example script, which is included in the MediaOps Live demo package. For more information on how to create a script with dynamic inputs, refer to the [orchestration script documentation](xref:MediaOpsLive_OrchestrationScript).

## Fixes

### CSV import and export could handle special characters incorrectly [ID 46381]

When importing endpoint or virtual signal group data from CSV files, special characters such as the degree symbol (°) could be parsed incorrectly, especially in files saved using the legacy Microsoft Excel CSV format.

CSV imports now support both UTF-8 and Windows-1252 encoding, preserving special characters during import and provisioning. CSV exports now use UTF-8 encoding with a byte order mark (BOM), allowing Microsoft Excel to detect the encoding correctly when opening exported files.

### Orchestration failed when script used profile definition with capability or capacity parameters [ID 46686]

When an orchestration script used a profile definition containing capability or capacity parameters, every scheduled or manual orchestration of that script failed with an "Object reference not set to an instance of an object" null reference exception, even when the parameter values were linked to the node's capabilities and capacities.

Orchestration scripts now run as expected for these profile definitions. In addition, values stored in profile instances for capability and capacity parameters are now also picked up: they appear as preset values and are used when a profile instance is passed to the script as input.
