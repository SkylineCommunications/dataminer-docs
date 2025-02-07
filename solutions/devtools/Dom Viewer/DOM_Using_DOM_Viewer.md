---
uid: DOM_Using_DOM_Viewer
---

# Using the Dom Viewer

In this guide, you will learn the purpose of the Dom Viewer by walking through the application.

This guide is broken down in the following topics, each correspinding to a page in the app:

- SDM Modules: View the Standard Data Model (SDM) modules in an interactive graph.

- All Modules: View all modules found in the DataMiner System in an interactive graph.

- Field Descriptors: Easily find and visualize field descriptors across any module, definition or section.

- Generating Markup code to document a DOM Module.

Estimated duration: 5 minutes.

> [!NOTE]
> The content and screenshots for this guide have been created in DataMiner version 10.5.1.

## Prerequisites

- DataMiner version 10.3.10 or higher

- A DataMiner System with an [indexing database](xref:Indexing_Database)

- Basic knowledge of DataMiner Object Models (DOM)

- The package [Tutorial - Dom Viewer](https://catalog.dataminer.services/details/fea99fc7-63fc-40da-85fb-db1ca914986a) (version 1.0.7 or higher) installed. Includes  the DOM Viewer app and the DOM modules showcased in this guide.

## Overview

- [What is?](#what-is)

- [SDM Modules](#sdm-modules)

- [All Modules](#all-modules)

- [Field Descriptors](#field-descriptors)

- [Generate Markup](#generate-markup)


## What is?

Unlike Dom Editor that lets you build the model through dialog forms or DataMiner Objects Tool that comprehensively focuses on querying instances, the Dom Viewer quickly displays definitions and their relationships through an interactive graph. After that, you can drill down on it if necessary. It is designed to help you not just see, but also to understand the model through visualization.

## SDM Modules

This page shows the Standard Data Model if it's present in your dataminer system.
The Standard Data Model is a single unified DOM model to capture a wide range of business and operational data. 
It is the model on top of which DataMiner Standard Apps are built on.

> [!NOTE]
> The SDM Modules first need to be present in your Dataminer System in order to be displayed by the DOM Viewer.


### DOM Definitions

In the node-edge graph, DOM definitions are represented as nodes. When you select a node, a hover menu will appear displaying general information like DOM module, amount of sections and amount of field descriptors. 

![Definition Hover Panel](~/user-guide/images/DOM_Viewer_Definition_Hover_Menu.png)

Furthermore, there will be two buttons available: "Open definition table" and "Open behavior definition":

- Open Definition Table: Displays a table with all Field Descriptors that are part of that definition, grouped by sections displayed as tabs on top.

![Table Definition](~/user-guide/images/DOM_Viewer_Definition_Table_Definition.png)

- Open Behavior Definition: Displays a window with the state machine graph that describes the different states that an instance from that definition can move through.

![Behavior Definition](~/user-guide/images/DOM_Viewer_Definition_Behavior_Definition.png)

### Relationships

By hovering over the relationships (edges in the interactive graph) and hover panel will appear indicating which field descriptor is referrencing the other DOM definition.

![Relationship Hover Panel](~/user-guide/images/DOM_Viewer_Definition_Relationship_Hover_Menu.png)

## All Modules

The "All Modules" page contains another interactive graph that operates similarly to the "SDM Modules" page, except it will display all DOM modules found in your DataMiner System. Additionally, it contains a couple of filters. This allows you to filter on DOM Modules and/or DOM Definitions that you're interested in seeing at that time.

![All Modules](~/user-guide/images/DOM_Viewer_All_Modules.png)

## Field Descriptors

This page immediately shows all field descriptors. 
You can filter by Module, Definition and Section to reach at the field descriptor you're looking for.
You can view different field descriptors simultaneously across different modules even.
If you don't know where the field descriptor is, you can use the table's extensive filtering capabilities to quickly find it.

![Field Descriptors](~/user-guide/images/DOM_Viewer_Field_Descriptors.png)

## Generate Markup

The DOM Viewer application was also designed to aid with documentation. As models grow and change, documentation needs to keep up which  can be challenging, specially if done manually. You can automatically generate markup tables by selecting whichever modules you want to document. 

![Generate Markup](~/user-guide/images/DOM_Viewer_Markup.png)
