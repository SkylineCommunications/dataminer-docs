---
uid: DOM_Using_DOM_Viewer
---

# Using the DOM Viewer

> [!TIP]
> To get to know this tool, you can [follow Kata #54 on DataMiner Dojo](https://community.dataminer.services/courses/kata-54/) and deploy the tutorial package [Tutorial - DOM Viewer](https://catalog.dataminer.services/details/fea99fc7-63fc-40da-85fb-db1ca914986a) from the Catalog. This package includes the DOM Viewer itself as well as the example modules used in Kata #54.

The DOM Viewer application consists of several pages:

- [SDM Modules](#sdm-modules): Displays the Standard Data Model (SDM) modules in an interactive graph.

- [All Modules](#all-modules): Displays all modules found in the DataMiner System in an interactive graph.

- [All Descriptors](#all-descriptors): Allows you to easily find and visualize field descriptors across any module, definition, or section.

- [Tools](#generating-markup): Allows you to generate markup code to document a DOM module.

## SDM Modules

This page shows the Standard Data Model if it is present in your DataMiner System. The Standard Data Model is a single unified DOM model to capture a wide range of business and operational data. Several low-code apps available in the [Catalog](https://catalog.dataminer.services/), including all [MediaOps applications](xref:MediaOps), are built on this model.

> [!NOTE]
> The DOM Viewer will only be able to display the SDM information if the Standard Data Model is present in your DataMiner System.

### Working with the module overview graph

In the node-edge graph, **DOM definitions** are represented as nodes. If you hover over a node, general information will be displayed such as the DOM module and the number of sections and field descriptors.

![Definition Hover Panel](~/solutions/images/DOM_Viewer_Definition_Hover_Menu.png)

The displayed pop-up panel contains two buttons:

| Button | Description |
|--|--|
| ![Open Definition Table button](~/solutions/images/DOM_Viewer_Open_Definition_Table.png) | Open Definition Table button. Displays a table with all field descriptors that are part of that definition, grouped by sections displayed as tabs at the top. For example:<br> ![Table Definition](~/solutions/images/DOM_Viewer_Definition_Table_Definition.png) |
| ![Open State Transitions button](~/solutions/images/DOM_Viewer_Open_State_Transitions.png) | Open State Transitions button. Displays a state transitions graph, which shows which states an instance of the definition can move through (i.e. the behavior definition). For example:<br> ![Behavior Definition](~/solutions/images/DOM_Viewer_Definition_Behavior_Definition.png) |

The edges in the graph show the relationships between the definitions. If you hover over an edge, a pop-up panel will show which field descriptor is referencing the other DOM definition.

![Relationship Hover Panel](~/solutions/images/DOM_Viewer_Definition_Relationship_Hover_Menu.png)

## All Modules

The *All Modules* page contains an interactive graph similar to that on the *SDM Modules* page, which can be used in [the same way](#working-with-the-module-overview-graph). This graph will display all DOM modules found in your DataMiner System.

You can also filter on specific DOM modules and/or DOM definitions with the filter boxes on the left, so that only these are displayed in the graph.

![All Modules](~/solutions/images/DOM_Viewer_All_Modules.png)

## All Descriptors

This page lists all the available field descriptors.

You can filter the list by module, definition, and section using the filter boxes on the left, in order to quickly reach the field descriptor you are looking for.

Different field descriptors can be viewed simultaneously across different modules.

![Field Descriptors](~/solutions/images/DOM_Viewer_Field_Descriptors.png)

## Generating markup

The DOM Viewer application was also designed to aid with documentation. As models grow and change, documentation needs to keep up, which can be challenging, especially if you need to do this manually.

This is why on the *Tools* page of the DOM Viewer, you can have markup tables generated automatically by selecting the modules you want to document and clicking the *Generated .md tables* button.

![Generate Markup](~/solutions/images/DOM_Viewer_Markup.png)
