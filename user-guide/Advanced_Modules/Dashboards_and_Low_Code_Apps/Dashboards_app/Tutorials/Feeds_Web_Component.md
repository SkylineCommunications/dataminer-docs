---
uid: Tutorial_Dashboards_Feeds_Web_Component
---

# Leverage feeds in a web component

In this tutorial, you will learn how to embed another webpage directly into your dashboard using a [web component](xref:DashboardWeb). You will also find out how you can configure HTML code, the language behind any web page. Furthermore, we will explore how to utilize feeds to dynamically enhance both approaches.

Expected duration: 5 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.4.5 web apps.

## Prerequisites

- A DataMiner System that is connected to dataminer.services.

- Version 10.4.5 or higher of the DataMiner web apps.

## Overview

- [Step 1: Install the dashboard web component tutorial package](#step-1-install-the-dashboard-web-component-tutorial-package)
- [Step 2: Configure static web components](#step-2-configure-static-web-components)
- [Step 3: Leverage feeds](#step-3-leverage-feeds)

> [!TIP]
> See also: [Kata #34: Leverage feeds in a web component](https://community.dataminer.services/courses/kata-34/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Step 1: Install the dashboard web component tutorial package

1. Go to <https://catalog.dataminer.services/details/7d78f8c4-323f-4d30-bc27-c9a7194c2f5f>.

1. Click the *Deploy* button to deploy the *Dashboard web component tutorial* package on your DMS.

   This package contains a "Web component tutorial" low-code app and a GQI ad-hoc data source that contains details of KATAs.

## Step 2: Configure static web components

1. Open the *Web component tutorial* low-code app, which is available on the DataMiner landing page.

1. [Edit the app](xref:Editing_custom_apps), and make sure the *Static* page of the app is open.

1. On this page, there are two assignments. Scroll down to the first assignment, which is to embed another web page.

   1. Click the [web component](xref:DashboardWeb) to select it.

   1. Go to the settings pane.

   1. Set *Type* to "Webpage".

   1. Enter the *URL* of the website you would like to embed. For example, you could use "<https://docs.dataminer.services>".

   1. Preview or publish the app to see the embedded webpage.

1. Scroll down to the second assignment, which is to enter your own HTML code.

   1. Go to the setting of the [web component](xref:DashboardWeb), and set *Type* to "Custom HTML".

   1. Enter the desired HTML code. For example, you can enter "Hello there!" in the existing *H1* tag.

   1. Preview or publish the app to see your configured content.

## Step 3: Leverage feeds

1. [Edit the app](xref:Editing_custom_apps), and make sure the *Dynamic* page of the app is open.

1. You will notice a [dropdown component](xref:DashboardDropdown) containing different KATAs.

1. In the first assignment of this page, you will use the selected item of a dropdown component in the embedded web page.

   1. Go to the setting of the [web component](xref:DashboardWeb) to see an initial URL.

   1. Place your mouse cursor at the end of the URL, so that you can extend it. Type a curly bracket ("{") to show the feed intellisense. This will guide you in configuring a placeholder that will be replaced by the corresponding feed value.

   1. Enter "{FEED."Current view"."Dropdown 2"."Selected item"."Query rows".VideoId}" to link to the *VideoId* property of the selected dropdown item.

   1. Preview or publish the app to see the selected KATA embedded in your page.

1. Now do the same for the HTML content in the second assignment of the *Dynamic* page.

   1. Go to the setting of the [web component](xref:DashboardWeb) to see some preconfigured HTML code.

   2. Replace the static "Title" in your HTML code by the following feed placeholder: "{FEED."Current view"."Dropdown 9"."Selected item"."Query rows".Title}". Do the same for the *Views* and *Duration* properties.

   3. Preview or publish the app to see the selected KATA embedded in your page.

## Learning paths

This tutorial is part of the following learning path:

- [Dashboards](xref:Tutorial_Dashboards)

## Related documentation

- [Feeds](xref:Using_dashboard_feeds)
