---
uid: Web_apps_Feature_Release_10.3.8
---

# DataMiner web apps Feature Release 10.3.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.8](xref:General_Feature_Release_10.3.8).

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No other features have been added yet*

## Changes

### Enhancements

#### Monitoring app: Parameter values that are URLs will now be rendered as clickable hyperlinks [ID_36423]

<!-- MR 10.4.0 - FR 10.3.8 -->

From now on, when a parameter value is a URL starting with one of the following prefixes it will be rendered as a clickable hyperlink:

- file://
- ftp://
- http://
- https://
- mailto://

### Fixes

#### Dashboards app & Low-Code Apps: Only one of the tables sharing an empty query would show a visual replacement [ID_36233]

<!-- MR 10.4.0 - FR 10.3.8 -->

When an empty query was used by more than one table component, in some rare cases, only one of those components would display a visual replacement.

#### Low-Code Apps: A blank screen would appear when users without permission to access a low-code app tried to log on [ID_36422]

<!-- MR 10.4.0 - FR 10.3.8 -->

When users without permission to access a low-code app tried to log on to that app, an error would be thrown and a blank screen would appear. From now on, when users without permission to access a low-code app try to log on to that app, an appropriate message will appear instead.
