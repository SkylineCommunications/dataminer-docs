---
uid: Creating_a_new_app
description: Learn how to create a new app for your DataMiner System with AI assistance, from the Catalog, or as a developer, before you upload and publish it.
---

# Creating a new app

From DataMiner 10.6.0 [CU10]/10.7.0/10.7.1 onwards<!-- RN 45878 -->, you can add [New Apps](xref:New_apps) to your DataMiner System. New apps are built outside DataMiner. Once you have an app, you can [upload and publish it](xref:Uploading_a_new_app).

You can get a new app in the following ways:

- [Create it with AI assistance](#creating-an-app-with-ai-assistance)
- [Deploy it from the Catalog](#deploying-an-app-from-the-catalog)
- [Build it as a developer](#building-an-app-as-a-developer)

## Creating an app with AI assistance

With the DataMiner App Builder, you can describe the app you want, and an AI agent will build it for you. The DataMiner App Builder is an AI agent that builds static frontend applications that can be deployed in DataMiner. It knows how apps connect to DataMiner and how to retrieve the data you want to show.

> [!IMPORTANT]
> The DataMiner App Builder is experimental. You remain responsible for reviewing and testing the generated app before you use it in a production environment.

To create an app with the DataMiner App Builder:

1. Install the DataMiner App Builder in a supported AI client.

   For the prerequisites and installation steps, see [AI Agent marketplace](xref:AIAgentMarketplace).

1. Select the DataMiner App Builder agent.

1. Describe the app you want, for example which data it should show and how you want it to look.

   Do not include passwords, API keys, or other secrets in your description.

1. Review and test the generated app.

1. Make sure the app is packaged as a ZIP file with an *App.info.json* file at its root.

   If you cannot create the ZIP file yourself, ask the agent to do so.

You can then [upload the ZIP file to your DataMiner System](xref:Uploading_a_new_app).

## Deploying an app from the Catalog

You can deploy an existing app from the Catalog. To do so, click the arrow next to the *Add* button on the DataMiner landing page and select the option to browse the Catalog.

## Building an app as a developer

If you want to build an app yourself, see [Web application projects](xref:skyline_dataminer_sdk_web_application_project). This page describes how to create a web application project, configure the *App.info.json* file, and package the app so that you can upload it.
