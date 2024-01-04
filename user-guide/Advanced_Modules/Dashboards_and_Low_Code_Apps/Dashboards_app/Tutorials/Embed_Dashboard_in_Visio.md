---
uid: Tutorial_Embed_Connector_Dashboard_in_Visio
---

# Tutorial: Embed Connector Dashboard in Visio

In this tutorial, you will learn how to embed a connector Dashboard into your Visio. This makes it convenient for users who are typically using DataMiner Cube as their main user interface. By making a Dashboard that relates to a single (configurable) element of a particular connector, you can automatically visualize this dashboard with the content related to that element. Of course, it is possible to embed any dashboard onto any visual overview, but here we choose to make use of dynamic inputs to automatically view the related content of a dynamic Dashboard.

Expected duration= 20 minutes

> [!TIP]
> There is a Application package available in the [Catalog](https://catalog.dataminer.services/details/package/5182) that demonstrates the outcome of this tutorial.

> [!IMPORTANT]
> When designing dynamic Dashboards (e.g. with configurable element), you should use Feeds (e.g. dropdown) which you can  dynamically assign a value if you embed this Dashboard.

## Prerequisites

> [!NOTE]
> This tutorial uses DataMiner version 10.2.0 (RN31822).

<!-- Add a bulleted list including any required software and licenses. Make sure to include the minimum DataMiner version. -->
The intention is to create a Dashboard that has a one-to-one relation to an element. Therefore, please find and select an element of interest.

## Overview

The tutorial consists of the following steps:

- [Step 1: Create Dynamic Dashboard](#step-1-create-dynamic-dashboard)
- [Step 2: Prepare URL for use in Visio](#step-2-prepare-url-for-use-in-visio)
- [Step 3: Create Visio and embed Dashboard](#step-3-create-visio-and-embed-dashboard)

## Step 1: Create Dynamic Dashboard

1. Create a Dashboard (as explained in [Creating a completely new Dashboard](xref:Creating_a_completely_new_dashboard))

1. Add a [Dropdown](xref:DashboardDropdown) to show all the elements of the selected connector.

    The data you need for this component are 'all elements'. For this you can drag 'Elements' from 'All available data'.

    Next to the data, you typically also need to specify a filter related to the connector of interest. Under 'All available data > Protocols', select the connector of your interest and apply it as filter onto your dropdown component.

1. Add extra components to your Dashboard

    First of all, we will show the name of the selected element. In order to do this, use a 'State' visualization and add the necessary date (Feeds > Dropdown > Elements).

    Secondly, we show any parameter of choice by selecting the following data: Parameters > From: Protocol. Apply the dropdown feed (see above) to your component as filter.

    ![Dynamic Dashboard](~/user-guide/images/Dashboards_Tutorial_EmbedInVisio_CreateDashboard.png)

1. Copy the URL with the Embed Query Parameter & use uncompressed URL parameters checked. (ref. [Sharing a dashboard](xref:Sharing_a_dashboard#Sharing-a-dashboard-URL)).

    <code>https://localhost/dashboard/#/db/Generic%20Dummy.dmadb?<span style="background-color: #FFFF00">data=%7B%22version%22:1,%22feed%22:null,%22components%22:%5B%7B%22cid%22:2,%22select%22:%7B%22elements%22:%5B%22172%2F82%22%5D%7D%7D,%7B%22cid%22:1,%22select%22:%7B%22elements%22:%5B%22172%2F82%22%5D%7D%7D%5D,%22feedAndSelect%22:%7B%7D%7D&embed=true</span></code>

## Step 2: Prepare URL for use in Visio

1. Now this becomes a little tricky and manual adjust You want to add some dynamic arguments that you can use in your Visual Overview, but first let's **decode the URL**. You can do this with any tool on the internet or a plugin on notepad++.

    <code>https://localhost/dashboard/#/db/Generic Dummy.dmadb?<span style="background-color: #FFFF00">data={"version":1,"feed":null,"components":[{"cid":2,"select":{"elements":["172/82"]}},{"cid":1,"select":{"elements":["172/82"]}}],"feedAndSelect":{}}&embed=true</span></code>

1. The **cid** is the ID of the component (you can find this ID back when you're in Edit Mode). Only keep the configuration related to your dynamic input (here it's only the dropdown).

    ![Component ID](~/user-guide/images/Dashboards_Tutorial_EmbedInVisio_CID.png)

    <code>https://localhost/dashboard/#/db/Generic Dummy.dmadb?data={"version":1,"feed":null,"components":[<span style="background-color: #FFFF00">{"cid":1,"select":{"elements":["172/82"]}}</span>],"feedAndSelect":{}}&embed=true</code>

1. Add dynamic element ID instead of fixed element ID.

    Practically speaking the fixed element ID (172/82) should be replaced with a Visio placeholder ([this elementID]). Next to this, we want to escape this in our URL so it correctly resolves. We can do this with the placeholder **[EscapeDataString:[this elementID]]**.

    <code>https://localhost/dashboard/#/db/Generic Dummy.dmadb?data={"version":1,"feed":null,"components":[{"cid":1,"select":{"elements":["<span style="background-color: #FFFF00">[EscapeDataString:[this elementID]]</span>"]}}],"feedAndSelect":{}}&embed=true</code>

1. Re-encode the URL

    You should **encode** the value of the data query parameter as it's a JSON. Important, you should Exclude [EscapeDataString:[this elementID]].

    <code>https://localhost/dashboard/#/db/Generic Dummy.dmadb?data=%7B%22version%22%3A1,%22feed%22%3Anull,%22components%22%3A%5B%7B%22cid%22%3A1,%22select%22%3A%7B%22elements%22%3A%5B%22<span style="background-color: #FFFF00">[EscapeDataString:[this elementID]]</span>%22%5D%7D%7D%5D,%22feedAndSelect%22%3A%7B%7D%7D&embed=true</code>

1. Add Dynamic ```<DMAIP>``` placeholder so it can be used on any DataMiner.

    '''txt
    <code>https://<span style="background-color: #FFFF00">\<DMAIP\></span>/dashboard/#/db/Generic Dummy.dmadb?data=%7B%22version%22%3A1,%22feed%22%3Anull,%22components%22%3A%5B%7B%22cid%22%3A1,%22select%22%3A%7B%22elements%22%3A%5B%22[EscapeDataString:[this elementID]]%22%5D%7D%7D%5D,%22feedAndSelect%22%3A%7B%7D%7D&embed=true</code>
    '''

## Step 3: Create Visio and embed Dashboard

1. In DataMiner Cube, go to the Visual Overview of your element.
1. Create a new Blank Visio.
1. Add one shape to your page with following shape data:

    **Link**: #https://\<DMAIP\>/dashboard/#/db/Generic Dummy.dmadb?data=%7B%22version%22%3A1,%22feed%22%3Anull,%22components%22%3A%5B%7B%22cid%22%3A1,%22select%22%3A%7B%22elements%22%3A%5B%22[EscapeDataString:[this elementID]]%22%5D%7D%7D%5D,%22feedAndSelect%22%3A%7B%7D%7D&embed=true

    **Dock**: Left|Right|Top|Bottom

    > [!NOTE]
    > The '#' in the Link shape data will allow you to see the Dashboard directly in the Visual Overview.

1. Finally you should see the dashboard nicely embedded in your Visual Overview.

    ![Result](~/user-guide/images/Dashboards_Tutorial_EmbedInVisio_Result.png)
