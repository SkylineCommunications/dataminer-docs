---
uid: Web_apps_Feature_Release_10.6.9
---

# DataMiner web apps Feature Release 10.6.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU6].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.9](xref:General_Feature_Release_10.6.9).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.9](xref:Cube_Feature_Release_10.6.9).

## Highlights

*No highlights have been selected yet.*

## New features

#### GQI - Extensions: Persistent scoped services [ID 45635]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When using the GQI DxM, extension developers can now define persistent services: reusable, injectable dependencies that live beyond a single query execution. This allows extensions to keep expensive setup work, cached data, helper clients, and shared state alive for the right scope instead of rebuilding everything every time a query runs.

Services are registered by annotating a class with a scope attribute:

- `[GQIWorkerService]`: one shared instance per extension worker process.
- `[GQISecurityService]`: one shared instance per unique security context.
- `[GQIUserService]`: one shared instance per user.

Services can optionally configure `IdleExpirationMinutes`. When a service has been idle for that duration, it is automatically disposed. This helps reduce memory usage while still allowing frequently used services to stay warm.

Services and extensions can now receive dependencies directly through their constructors. Extension developers no longer need to manually create or look up common dependencies during lifecycle methods. Constructor parameters can include:

- Other registered services, resolved automatically by type or registered service contract.
- `GQILazy<T>` for dependencies that should only be created when first used.
- `IConnection` and `IGQIDMSInterface` for DataMiner access.
- `IGQILogger`, `IGQIOnInitInputArgs`, and other standard GQI types.

## Changes

### Enhancements

#### GQI components / Web API: Discrete column values will now be objects containing possible values and an 'IsStrict' flag [ID 45388] [ID 45835]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

From now on, discrete column values in a GQI query result will no longer be arrays of possible values. Instead, they will be objects containing possible values and an `IsStrict` flag.

This change will only have a functional impact when columns are requested for parameter trend data of discrete parameters using GQI via SLHelper. In that case, discrete columns containing discrete values that do not match the column type will no longer be available in the client.

> [!NOTE]
> The `IsStrict` flag will be applied by default where discrete column values can be selected: template overrides, conditional coloring, table column filters, and the Query filter component. Discrete values that are strict will only show checkbox inputs. In case of a string column, no text input will be shown, and in case of a number/date column, no range input will be shown.

#### Web apps: Redesigned datetime controls now fully support custom time zones set by the client [ID 45687]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Because of a number of enhancements, the redesigned datetime controls will now fully support any custom time zones set by the client.

This also means that these controls will now be better able to deal with transitions to and from daylight saving time.

#### GQI DxM - 'Get parameters for elements where': Possible to select either a full table or a subset of columns [ID 45692]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, when you selected the parameter(s) for the *Get parameters for elements where* data source, it would only be possible to select standalone parameters and table parameters. It was not possible to select specific columns of a table.

From now on, when selecting a table parameter, it will be possible to select either the full table or a subset of columns.

> [!NOTE]
> It is not possible to mix columns from different tables or to combine a table with standalone parameters.

#### Dashboards/Low-Code Apps: New inputs implemented in components [ID 45693]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

New input components have been implemented in dashboards and low-code apps, replacing the previous input implementations:

- *Button* component: Now includes a new *Type* setting that allows you to choose between call to action, subtle, normal, or danger styles.
- *Dropdown* component: Now includes a new *Placeholder* setting.
- *Text*, *Search*, and *Number* components: Typing is now from left to right instead of the previous right-to-left behavior.

  The *Number* component now also supports scientific notation.

> [!NOTE]
>
> - When a large number is fed to a numeric input, scientific notation is used (e.g., 1000000000000000000000 becomes 1e+21).
> - When a number does not fit within the min and max values of the receiving component, the default value is used instead.

#### Web apps: About box will now also show the version of the DataMiner Assistant DxM [ID 45833]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

From now on, the About box will also show the version of the DataMiner Assistant DxM.

If this DxM is not installed or not enabled, "Not installed" will be displayed instead of the version.

#### Web apps - Help menu: Feedback command replaced by a feedback submenu [ID 45853]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In the help menu of the web apps, the *Feedback* command has been replaced by a submenu with the following two commands:

- [Share your experience](https://aka.dataminer.services/help-feedback-root)
- [Report an issue](https://aka.dataminer.services/ReportAnIssue)

#### GQI DxM: Improved performance when all DOM data is requested [ID 45866]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When GQI requests DOM data, it now checks whether all data is required instead of relying on the client-requested page size.

When all data is required, e.g., for prefetch join operations or when *Filter assistance* is enabled on a query filter, GQI now requests data with a larger page size. This reduces request overhead and improves performance.

#### Dashboards/Low-Code Apps: No longer possible to link the Select query operator to data [ID 45991]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

From now on, it is no longer possible to link the [Select](xref:GQI_Select) query operator to data.

### Fixes

#### Dashboards/Low-Code Apps - Table component: Correct column widths would not be applied after the table had been resized or updated [ID 45765]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In some rare cases, a *Table* component would incorrectly not apply the correct column widths after the table had been resized or updated. This led to columns being hidden when they had to be visible.

#### GQI DxM could become unrecoverable when the initial DataMiner state subscription failed [ID 45830]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When the GQI DxM established an SLNet connection but failed to set up the initial DataMiner state subscription, it could remain in an unrecoverable state.

Now, the subscription step is treated as part of connection establishment. If that step fails, the connection is considered failed and is retried.

#### Low-Code Apps - Line chart: Hovered data point could be incorrect after position changes [ID 45905]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In some cases, a GQI line chart in a low-code app could highlight the wrong data point when you hovered over the chart after its position changed.

This issue mainly occurred when the chart was in a movable panel that had been dragged to a different location.

Now, the hovered position correctly maps to the expected data point after position changes.

#### Dashboards/Low-Code Apps: Code blocks no longer rendered correctly in the rich text editor and Web component [ID 45946]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In dashboards and low-code apps, in some cases, code blocks would be displayed incorrectly after a recent UI update. Inline code would appear as a separate box, and block codes would no longer take the full display width.

From now on, code blocks will again render with the intended styling in the rich text editor and Web component.

#### Dashboards/Low-Code Apps: Filters for numeric columns with strict discrete values could incorrectly stay disabled [ID 45992]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In the *Query filter* component, and in conditional coloring and template conditions, the filters for numeric columns with strict discrete values could incorrect stay disabled.

From now on, it will again be possible to use these filters.
