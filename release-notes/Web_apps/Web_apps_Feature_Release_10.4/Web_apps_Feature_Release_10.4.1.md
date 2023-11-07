---
uid: Web_apps_Feature_Release_10.4.1
---

# DataMiner web apps Feature Release 10.4.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.1](xref:General_Feature_Release_10.4.1).

## Highlights

*No highlights have been selected yet.*

## New features

#### Dashboards app & Low-Code Apps - Table component: Customizing the appearance of a column [ID_37522]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When editing a table component, you can now find a *Column appearance* section in the *Layout* tab. This section allows you to customize the appearance of a column.

- To change the alignment of a column, select the column and, in the *Column appearance* section, set *Alignment* to "Left", "Center" or "Right".

- To change the appearance of a column using presets, in the *Column appearance* section, do the following:

  1. In the selection box, select the column of which you want to change the appearance.
  1. Click the preview to expand a list of available presets.
  1. Select the preset that you want to be applied to the column.

  Available presets:

  - *Left*: Align the content to the left.
  - *Center*: Align the content in the center.
  - *Right*: Align the content to the right.
  - *Icon*: Display an icon instead of text.
  - *Link*: Make the text appear as a link.
  - *Background*: Add a background color to the cell.

  To tweak the preset you selected, click the ellipsis button (*...*) and select *Edit preset*. This will open the template editor, which will allow you to fully customize the column appearance.

> [!NOTE]
>
> - To resize the columns of a table, drag the edges of the column headers, and to change the order of the columns, drag the column headers to a different position. To change the default column width, use the template editor.
> - When you add a table component to a low-code app, the template editor will also allow you to configure actions that will be executed when a shape in a column is clicked or when a row is double-clicked.
> - In the *Parameter table* component, the default column alignment is now "Left" instead of "Center".
> - The default alignment of GQI table columns is now "Left" for columns of type string and "Right" for columns of type numeric or date.

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Low-Code Apps: Panels would not stack in the correct order [ID_37696]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

Panels would not stack in the correct order. From now on, they will stack in the order in which they were opened, and panels opening as pop-up windows will always stack on top of the left/right panels.

#### Low-Code Apps: Initials would be displayed instead of user icon in edit mode [ID_37700]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

In edit mode, the user's initials would be displayed instead of the user icon.

> [!NOTE]
> In all DataMiner web apps, the user's initials will be displayed until the user icon has been retrieved.

#### Web APIs: Changes made to a user's access level would not be applied immediately [ID_37730]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When the access level of a user was changed, up to now, that change would not immediately get applied to existing Web API connections.

#### Dashboards app - Clock component: DataMiner time would be displayed instead of local time (and vice versa) [ID_37750]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When, in the settings of a *Clock* component, you had specified that it had to display the current DataMiner time (i.e. the time of the DataMiner server to which you are connected), the component would incorrectly display the local time (i.e. the DataMiner client time), and vice versa.
