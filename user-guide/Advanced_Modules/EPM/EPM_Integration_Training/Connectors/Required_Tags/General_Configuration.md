---
uid: ConnectorsRequiredTagsGeneralInformation
---

# EPM Manager Connector Configuration

When working with an EPM solution, it's required to configure the header of the EPM Manager connector. Below are the key configurations:

## Type Configuration

| Tag            | Attribute          | Value                          | Description                                                                                   |
|----------------|--------------------|--------------------------------|-----------------------------------------------------------------------------------------------|
| `<Type>`       | `options`          | `disableViewRefresh`           | Disables updates of view tables and partial subscriptions                                      |
| `<Type>`       | `databaseOptions`  | `partitionedTrending`          | Activates partitioning on trending tables.                                                    |

### Example

`<Type relativeTimers="true" options="disableViewRefresh" databaseOptions="partitionedTrending">virtual</Type>`

> **_NOTE:_** The connector is defined as virtual, as it does not require any communication settings.

## Display Configuration

| Tag            | Attribute          | Value                          | Description                                                                                   |
|----------------|--------------------|--------------------------------|-----------------------------------------------------------------------------------------------|
| `<Display>`    | `type`             | `element manager`              | Enables the EPM interface.                                                                   |
| `<Display>`    | `pageOptions`      | `*;CPEOnly`                    | Data pages are no longer displayed in the element.                                |

### Example

`<Display type="element manager" pageOptions="*;CPEOnly" defaultPage="General" pageOrder="General" wideColumnPages="">`