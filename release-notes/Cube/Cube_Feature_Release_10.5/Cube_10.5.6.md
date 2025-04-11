---
uid: Cube_Feature_Release_10.5.6
---

# DataMiner Cube Feature Release 10.5.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.6](xref:General_Feature_Release_10.5.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.6](xref:Web_apps_Feature_Release_10.5.6).

## Highlights

*No highlights have been selected yet.*

## New features

#### View cards: New 'Isolation mode' column in element list [ID 42562]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

In view cards, the element list now has a new *Isolation mode* column, which displayed the isolation mode of each element in the list.

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

#### Matrices: All input and output options will now be reset before a matrix update is applied [ID 42585]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

When a matrix was updated, up to now, only input and output options included in the updated would be changed. Options not included in the updated would be left unchanged.

From now on, when a matrix is updated, all input and output options will first be reset to their default values before the changes included in the update are applied.

#### Relational anomaly detection: Link to RAD Manager app in Augmented Operations alarm settings window [ID 42645]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

In the *Augmented Operations alarm settings* window, which you can access in the alarm template editor by clicking the button in the *Analytics* or *Anomalies* column for a given parameter, you can now find a link to the *RAD Manager* app.

If already installed on your system, the app will open. If not, you will be referred to the [RAD Manager page in the DataMiner Catalog](https://catalog.dataminer.services/details/174b9848-43c8-470d-afc2-1b1722f05e74).

### Fixes

#### Visual Overview: Problem when processing shape conditions or creating shape properties [ID 42436]

<!-- MR 10.4.0 [CU15] / 10.5.0 [CU3] - FR 10.5.6 -->

In some cases, an *Object reference not set to an instance of an object* exception could be thrown when processing shape conditions or creating shape properties.
