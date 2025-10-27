---
uid: LowCodeApps_organizing_landing_page
---

# Organizing the apps on the landing page in sections

It is possible to organize the apps on the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page) in different sections.

![Organizing apps](~/dataminer/images/Organizing_Apps.gif)<br>*DataMiner landing page in DataMiner 10.5.9*

At present, it is only possible to [create new sections](#creating-a-new-app-under-an-existing-section) by changing the configuration of the apps in JSON. However, you can [add new apps to existing sections](#creating-a-new-app-under-an-existing-section) directly from the DataMiner landing page.

## Creating a new app under an existing section

To create a new app in an existing section on the DataMiner landing page:

- From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43226-->:

  1. Open the tab in which you want the app to appear.

  1. In the top-right corner of the low-code apps section, click *Create app*.

     The app will be added to the selected section automatically.

- In previous versions:

  1. Hover over the title of the section where you want to add the app.

  1. Click the "+" icon.

     The app will be added to the selected section automatically.

## Adding an app to a new section

To add a low-code app to a new section that will appear on the DataMiner landing page, follow the procedure below:

1. On the DMA, go to the app folder: `C:\Skyline DataMiner\applications\[APP_ID]`

   > [!NOTE]
   > To find out which app ID corresponds with which low-code app, check the URL displayed in the browser when you open an app via the DataMiner landing page.

1. Open the file *App.info.json*.

1. Add the section names to the *Sections* array and save the file.

   For example:

   ```json
   {
      "__type":"Skyline.DataMiner.Web.Common.v1.DMAApplicationVersionInfo",
      "PublicVersion":1,
      "DraftVersion":0,
      "Sections": [
         "My section 1",
         "My section 2"
      ],
      "Security":{
         "__type":"Skyline.DataMiner.Web.Common.v1.Dashboards.DMAApplicationSecurityConfig",
         "AllowView":[],
         "AllowEdit":[]
      }
   }

> [!NOTE]
> From DataMiner 10.2.9/10.3.0 onwards, these different sections will also be displayed in the apps pane in DataMiner Cube.<!-- RN 33944 -->
