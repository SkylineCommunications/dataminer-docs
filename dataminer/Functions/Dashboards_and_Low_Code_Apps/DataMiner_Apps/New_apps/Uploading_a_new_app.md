---
uid: Uploading_a_new_app
description: Learn how to upload a new app to your DataMiner System from the landing page, and how to publish it so that other users can open it.
---

# Uploading and publishing a new app

From DataMiner 10.6.0 [CU10]/10.7.0/10.7.1 onwards<!-- RN 45878 -->, you can upload a new app to your DataMiner System from the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page). New apps are always uploaded as a draft. Once you have checked the app, you can publish it.

## Uploading a new app

To upload a new app:

1. Make sure you have a ZIP file containing the app.

   If you do not have an app yet, see [Creating a new app](xref:Creating_a_new_app).

1. On the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page), click the arrow next to the *Add* button.

   > [!NOTE]
   > Clicking the *Add* button itself will create a [low-code app](xref:Creating_custom_apps).

1. Select *Upload App*.

1. Select the ZIP file.

   The app will be added as a draft and will open automatically.

   On the DataMiner landing page, the app will be placed in the section in which you uploaded it, unless the app itself specifies other sections.

> [!NOTE]
> If the app has the same ID as an app that is already available on your DataMiner System, uploading it will deploy or overwrite the draft version of that existing app. The published version will not change until you publish the app.

The *Add* menu also allows you to browse the Catalog, so you can deploy an app from there, and to create an app in the low-code editor.

## Publishing a new app

Draft apps are not shown by default on the DataMiner landing page. After you close the app, you will only find it on the landing page if you show draft apps. See [Opening an app](xref:DataMiner_Apps#opening-an-app).

To publish a draft app:

1. Open the draft version of the app and check that it works as expected.

1. Click the *Publish app* ![Publish app icon](~/dataminer/images/Publish_App.png) icon in the upper-right corner of the header bar.

   The draft version will be published, so that users with the required permissions can open it.

> [!TIP]
> To go back to an earlier version of an app, open the options menu in the header bar of the app and select *History*.
