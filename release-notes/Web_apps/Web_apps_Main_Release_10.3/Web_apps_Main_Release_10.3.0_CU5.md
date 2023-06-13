---
uid: Web_apps_Main_Release_10.3.0_CU5
---

# DataMiner web apps Main Release 10.3.0 CU5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU5](xref:General_Main_Release_10.3.0_CU5).

### Enhancements

#### Low-Code Apps - Action editor: 'Which scheduler?' button has now been renamed to 'Which timeline?' [ID_36530]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

In the action editor, the *Which scheduler?* button has now been renamed to *Which timeline?*.

### Fixes

#### Low-Code Apps: Application would be updated each time you hit a key after changing a page name [ID_36479]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you changed the name of a low-code app page, the application would incorrectly be updated each time you hit a key. From now on, the application will be updated 250 ms after the last keystroke.

#### Dashboards app & Low-Code Apps: Problem when migrating a query to the current GQI version [ID_36552]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When you opened a query that was created using an older GQI version, and that query was configured to start from another query recursively in combination with joins, in some cases, it would incorrectly be migrated to the current GQI version.

#### Dashboards app & Low-Code Apps: Problem when sending updates to the Web API when the user did not have edit rights [ID_36571]

<!-- MR 10.3.0 [CU5] - FR 10.3.7 [CU0] -->

When a pie chart or a bar chart had its settings changed automatically, in some cases, an update would be triggered in the background, causing the Web API to throw an error when the user did not have edit rights. From now on, when the user does not have edit rights, updates will no longer be sent to the Web API.

#### Dashboards app & Low-Code Apps: Problem with large tables in PDF reports [ID_36616]

<!-- MR 10.3.0 [CU5] - FR 10.3.7 [CU0] -->

When you generated a PDF report of a dashboard that contained a large table, in the PDF report, the table would incorrectly not contain all rows. Moreover, the rows in the table would all show a loading state.
