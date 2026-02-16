---
uid: Cube_Feature_Release_10.5.6
---

# DataMiner Cube Feature Release 10.5.6

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU15] and 10.5.0 [CU3].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.6](xref:General_Feature_Release_10.5.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.6](xref:Web_apps_Feature_Release_10.5.6).

## Highlights

- [View cards: New 'Isolation mode' column in element list [ID 42562]](#view-cards-new-isolation-mode-column-in-element-list-id-42562)

## New features

#### View cards: New 'Isolation mode' column in element list [ID 42562]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

In view cards, the element list now has a new *Isolation mode* column, which displays the isolation mode of each element in the list.

By default, this column will be hidden. To add this column to the list, right-click a column header, and *select Add/Remove setting column > Isolation Mode*.

These are the possible values that can be displayed in the *Isolation mode* column:

| Value | Description |
|-------|-------------|
| None               | Not applicable. E.g. When viewing the *All* page of a service. |
| Disabled           | The element is not running in isolation mode. |
| Enabled (protocol) | The element is running in isolation mode because of a setting configured in the *protocol.xml* file, which applies to all elements that are using this protocol version. |
| Enabled (element)  | The element is running in isolation mode because of a setting configured in the element itself. |
| Enabled (DMA)      | The element is running in isolation mode because of a setting configured on DMA level, which applied to all elements that are using this protocol. |

## Changes

### Enhancements

#### Trending: SPI log entry containing the loading times of the trend graph labels will be added to SLClient.txt [ID 42514]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

When you open a trend graph, from now on, an SPI entry containing the loading times of the trend graph labels (including metadata like loaded trend data points, etc.) will be added to the *SLClient.txt* log file.

#### Relational anomaly detection: Link to RAD Manager app in Augmented Operations alarm settings window [ID 42645]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

In the *Augmented Operations alarm settings* window, which you can access in the alarm template editor by clicking the button in the *Analytics* or *Anomalies* column for a given parameter, you can now find a link to the *RAD Manager* app.

If already installed on your system, the app will open. If not, you will be referred to the [RAD Manager page in the Catalog](https://catalog.dataminer.services/details/174b9848-43c8-470d-afc2-1b1722f05e74).

> [!NOTE]
> This link will only be available if the DataMiner server uses DataMiner 10.5.4/10.6.0 or higher.

#### DataMiner Cube desktop app: Enhanced behavior when selecting "HTTP or HTTPS" [ID 42716]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

In the DataMiner Cube desktop app, you can configure whether Cube should connect to a specific DMS using HTTPS only ("HTTPS only") or whether it can fall back to HTTP if HTTPS is not available ("HTTP or HTTPS").

Up to now, when you had selected "HTTP or HTTPS", first, an HTTP request would be sent with a default timeout of 100 seconds. If that request failed, an HTTPS request would then be sent.

From now on, both an HTTP request and an HTTPS request will be sent in parallel, each with a timeout of 60 seconds.

- When the request that completes first is successful, the remaining request will be canceled.
- When the request that completes first returns an empty response, the system will fall back on the remaining request.

Also, a number of additional enhancements have been made to improve overall connection stability.

#### Logging: All Cube log entries sent to a DataMiner Agent will now include the ConnectionID dimension [ID 42721]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

Up to now, all SPI log entries sent to a DataMiner Agent included the *ConnectionID* dimension, which allows the corresponding connection to be traced.

From now on, apart from the SPI log entries, all other Cube log entries sent to a DataMiner Agent will also include the *ConnectionID* dimension.

#### Miscellaneous enhancements [ID 42730]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

A number of minor enhancements have been made, especially with regard to calculating durations included in SPI logging.

#### Enhancements with regard to retrieving data from EPM element managers [ID 42731]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

A number of enhancements have been made with regard to retrieving data from EPM element managers.

### Fixes

#### Visual Overview: Problem when processing shape conditions or creating shape properties [ID 42436]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

In some cases, an *Object reference not set to an instance of an object* exception could be thrown when processing shape conditions or creating shape properties.

#### Matrices would not display correct values [ID 42585]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

In some cases, it could occur that a matrix did not display the correct values. This could for example happen with a matrix shown in a virtual primary element in a redundancy group. The way matrices are updated has been optimized to prevent this.

#### 'Augmented operations alarm settings' window would not open in popped-out alarm template editor window [ID 42749]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

When the alarm template editor was shown in a separate window (e.g., after you had click the pop-out icon in the top-right corner of an alarm template), up to now, when you clicked the button in the *Analytics* or *Anomalies* column, the *Augmented Operations alarm settings* window would incorrectly open inside the main window instead of the alarm template editor window.

#### Visual Overview: Problem when information about impacted services displayed in an element shape was updated [ID 42786]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

When information about the impacted services was displayed in an element shape, in some rare cases, DataMiner Cube could stop working when that information was updated.

#### Alarm Console: Linked alarm tab with more than 50 active correlation alarms would not show all correlation alarms matching the selected card [ID 42796]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

When a linked alarm tab contained more than 50 active correlation alarms, in some rare cases, not all correlation alarms matching the selected card would be shown.
