---
uid: Tutorial_Dashboards_Feeds_Web_Component
---

# Leveraging feeds in a web component

In this tutorial, you will learn how to embed another webpage directly into a dashboard or low-code app using a [web component](xref:DashboardWeb). You will also find out how you can configure HTML code, the language behind any web page, and you will explore how to utilize feeds to dynamically enhance both approaches.

In the tutorial, a low-code app is used, but this component works in exactly the same way in a dashboard.

Expected duration: 5 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.4.5 web apps.

> [!TIP]
> See also: [Kata #34: Leverage feeds in a web component](https://community.dataminer.services/courses/kata-34/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is connected to dataminer.services.

- Version 10.4.5 or higher of the DataMiner web apps.

## Overview

- [Step 1: Install the tutorial package](#step-1-install-the-tutorial-package)
- [Step 2: Configure static web components](#step-2-configure-static-web-components)
- [Step 3: Leverage feeds](#step-3-leverage-feeds)

## Step 1: Install the tutorial package

1. Go to <https://catalog.dataminer.services/details/7d78f8c4-323f-4d30-bc27-c9a7194c2f5f>.

1. Click the *Deploy* button to deploy the *Dashboard web component tutorial* package onto your DMS.

   This package contains a *Web component tutorial* low-code app and a GQI ad hoc data source with information about DataMiner katas.

## Step 2: Configure static web components

1. Go to your DataMiner landing page (e.g., <https://myDataMiner/root/>), and click the *Web component tutorial* low-code app.

1. Go to [edit mode](xref:Editing_custom_apps).

1. Make sure you are on the *Static* page. Depending on your DataMiner version, you may need to click the pencil icon next to the title "Static" on the left.

   On this page, you will find two assignments.

1. Scroll down to the first assignment, which is to embed a web page by specifying a static URL:

   1. Click the [web component](xref:DashboardWeb) to select it.

   1. On the right, open the *Settings* pane.

   1. Set *Type* to *Webpage*.

   1. Enter the URL of the website you would like to embed.

      For example, you could use `https://docs.dataminer.services`.

   1. Preview or publish the app to see the embedded webpage.

1. Go back to edit mode and make sure you are again on the *Static* page. Depending on your DataMiner version, you may need to click the pencil icon next to "Static".

1. Scroll down to the second assignment, which is to embed a web page by specifying custom HTML code:

   1. Click the [web component](xref:DashboardWeb), and open the *Settings* pane.

   1. Set *Type* to *Custom HTML*, and enter the desired HTML code.

      For example, you could enter `<h1>Hello there!</h1>`.

   1. Preview or publish the app to see your configured content.

## Step 3: Leverage feeds

1. Go to [edit mode](xref:Editing_custom_apps).

1. Go to the *Using feeds* page of the low-code app. Depending on your DataMiner version, you may need to click the pencil icon next to the title "Using feeds" on the left.

   On this page, you will find a [table component](xref:DashboardTable) containing different katas and two assignments.

1. In the first assignment, you will make sure the video linked to the item selected in the dropdown component is visualized in the web component:

   1. Click the [web component](xref:DashboardWeb), and open the *Settings* pane.

      You will notice a partial URL has already been entered.

   1. Place your mouse cursor at the end of the URL so that you can extend it, and type a curly bracket ("{") to show the feed intellisense.

      This will guide you in configuring a placeholder that will be replaced by the corresponding feed value.

   1. Enter `{FEED."Current view"."Dropdown 2"."Selected item"."Query rows".VideoId}` to link to the *VideoId* property of the item selected in the dropdown component.

   1. Preview or publish the app to see the selected kata embedded in the page.

1. In the second assignment, you will make sure that in your HTML code, the title, the number of views, and the length of the video will be replaced by the title, the number of views, and the length of the video for the item selected in the dropdown component.

   1. Click the [web component](xref:DashboardWeb), and open the *Settings* pane.

      In the *HTML* box, you will see preconfigured HTML code.

   1. Make the following changes to the preconfigured HTML code:

      - In the `<h1>` tag, replace the static `Title` by the following feed placeholder: `{FEED."Current view"."Dropdown 9"."Selected item"."Query rows".Title}`.

      - In the `<h2>` tag, replace the static `Views` by the following feed placeholder: `{FEED."Current view"."Dropdown 9"."Selected item"."Query rows".Views}`.

      - In the `<h2>` tag, replace the static `Duration` by the following feed placeholder: `{FEED."Current view"."Dropdown 9"."Selected item"."Query rows".Length}`.

   1. Preview or publish the app to see the selected kata embedded in the page.

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps tutorials](xref:Tutorial_Apps)

## Related documentation

- [Component data](xref:Component_Data)
