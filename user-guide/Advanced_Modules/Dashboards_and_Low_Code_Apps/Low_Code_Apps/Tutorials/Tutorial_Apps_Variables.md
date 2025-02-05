---
uid: Tutorial_Apps_Variables
---

# Using variables in a low-code app

In this tutorial, you will learn how to create a [variable](xref:Variables), and dynamically change its value through a headerbar, so that it can be used as an element state filter inside a query.

By the end of this tutorial, you will have a functional low-code app that allows users to filter elements dynamically based on their state.

> [!NOTE]
> This tutorial uses DataMiner web version 10.5.1. DataMiner web version 10.4.12 introduced variable creation, while 10.5.1 added support for dynamic value changes.

## Prerequisites

- DataMiner server 10.4.0 or higher and DataMiner web 10.5.1 or higher.

## Overview

- [Using variables in a low-code app](#using-variables-in-a-low-code-app)
  - [Prerequisites](#prerequisites)
  - [Overview](#overview)
  - [Step 1: Create a variable](#step-1-create-a-variable)
  - [Step 2: Create an Element query filtered by the variable](#step-2-create-an-element-query-filtered-by-the-variable)
  - [Step 3: Change the value of the variable to dynamically filter the list of elements](#step-3-change-the-value-of-the-variable-to-dynamically-filter-the-list-of-elements)

## Step 1: Create a variable

1. [Create an app](xref:Tutorial_Apps_Creating_And_Publishing#step-1-create-an-app).

1. Open the *Data* pane on the right, expand the *Variables* item and click the "+" icon to start creating a new variable.

1. Enter a meaningful name for the variable in the *Name* box.

1. Select "Text" as the *Type* of the variable.

1. Ensure the *Read-only* flag remains unchecked so that its value can be changed over time.

1. Leave the *Default value* empty or enter an initial value to filter on.

## Step 2: Create an Element query filtered by the variable

In this step, you will create and visualize a query that shows the elements in your system that are filtered through the variable created in [step 1](#step-1-create-a-variable).

1. [Create a query](xref:Creating_GQI_query).

1. Select the *[Get elements](xref:Get_elements)* data source.

1. Add a *[Filter](xref:GQI_Filter)* operator on the *State* column and [link it to the variable](xref:Controls_Feeds_Query#step-4-replace-the-static-filter-value-with-a-feed).

1. Create a *[Table](xref:Table_component)* to [visualize the query](xref:Configuring_components).

## Step 3: Change the value of the variable to dynamically filter the list of elements

This final step will add an entry point to the app where the value of the variable can be overwritten so that the query automatically applies a new value for the filter.

1. [Add a headerbar](xref:Tutorial_Apps_Using_A_Headerbar) with two buttons.

1. Configure the first button to [change the variable](xref:LowCodeApps_event_config) to "Active".

1. Configure the second button to set the variable to "Stopped".

That's it! After [publishing the app](xref:Tutorial_Apps_Creating_And_Publishing#step-2-publish-the-app), it will display an overview of the elements in your system. Clicking one button will narrow the list to active elements, while clicking the other will show only stopped elements.