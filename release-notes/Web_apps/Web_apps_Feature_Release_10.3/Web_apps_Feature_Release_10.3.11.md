---
uid: Web_apps_Feature_Release_10.3.11
---

# DataMiner web apps Feature Release 10.3.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.11](xref:General_Feature_Release_10.3.11).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Dashboards app - Web component: Embedded website would not function correctly [ID_37207]

<!-- MR 10.4.0 - FR 10.3.11 -->

When, on a dashboard, a website was embedded using a Web component, in some cases, the embedded website would not function correctly.

#### GQI: Problem when retrieving logger table data from an Elasticsearch database [ID_37251]

<!-- MR 10.4.0 - FR 10.3.11 -->

When a GQI query retrieved logger table data from an Elasticsearch database, the row keys would be filled in incorrectly. As a result, not all rows would have a unique key.

#### Dashboards app/Low-Code Apps: Problem with custom time zones [ID_37278]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When a custom time zone was used, in some cases, that time zone would not be processed correctly.

For example, when you set a custom time zone in a *Clock* component, the current time of that custom time zone would not be identical to the current time of the local time zone.

> [!NOTE]
> This problem would mostly occur when using a time zone that no longer observed daylight saving time (e.g. Altai Standard Time).

#### Problem with the IIS web server when redirecting the user to the login page [ID_37288]

<!-- MR 10.4.0 - FR 10.3.11 -->

In some cases, an error could occur in the IIS web server when redirecting the user to the login page.
