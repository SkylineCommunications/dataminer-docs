---
uid: LowCodeApps_organizing_landing_page
---

# Organizing the apps on the landing page in sections

It is possible to organize the apps on the Low-Code Apps landing page in different sections. However, at present this is only possibly by changing the configuration of the apps in JSON.

To do so:

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
