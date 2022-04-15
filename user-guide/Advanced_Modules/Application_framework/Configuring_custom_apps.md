---
uid: Configuring_custom_apps
---

# Configuring custom applications

> [!NOTE]
> To add, edit, delete, or publish custom applications, you need to have the necessary user permissions under [Modules > User-definable apps](xref:DataMiner_user_permissions#modules--user-definable-apps).

## Customizing the icon and color of an app

To customize the color and icon for the app, select the icon in the top-left corner.

You can then:

- Select any of the displayed icons to use that icon instead.

- Click the upload button to upload a custom icon of your own.

- Use the color picker to specify a different color for the app.

To close the color and icon editor, click the icon in the top-left corner again.

## Configuring a page of a custom app

Custom apps can consist of one or more pages. To configure a page in a custom app:

1. Make sure the page is selected in the leftmost pane of the app editor. This will open the page configuration pane to the right.

1. At the top of the page configuration pane, specify a name for the page.

1. In the *icon* section, select an icon for the page.

1. To configure a header bar for the page, see [Configuring the header bar of a custom app page](#configuring-the-header-bar-of-a-custom-app-page).

1. Click the pencil icon to configure the components on the page. Configuring these components is done in a very similar same way as configuring components in the Dashboards app. See [Configuring dashboard components](xref:Configuring_dashboard_components). For a list of the available components, refer to [Available visualizations](xref:Available_visualizations) in the Dashboards section.

1. If one or more actions should be triggered when the page is loaded, in the page configuration pane, open the *Events* section and click the configuration button next to *On page load*. Then configure the action(s) that should be triggered. See [Configuring custom app events](#configuring-custom-app-events)

> [!NOTE]
> To delete a page, click the garbage can icon next to the page name in the pane on the left, and then click the confirmation icon.

## Configuring a panel of a custom app

In addition to pages, panels can be configured in custom apps. These contain secondary content that can be shown on top of pages. Panels can be shown or hidden via actions, for example when a user clicks a button.

1. While you are editing a page, in the page configuration pane, open the *panels* section.

1. To add a new panel, click the "+" button in this section, and then specify a name for your panel.

1. To configure a panel, click the pencil icon next to the panel. This will open the panel configuration pane.

1. To configure a header bar for the panel, follow the same steps as to configure this for a page. See [Configuring the header bar of a custom app page](#configuring-the-header-bar-of-a-custom-app-page).

1. Click the pencil icon to configure the components on the panel. Configuring these components is done in the same way as configuring components in the Dashboards app. See [Configuring dashboard components](xref:Configuring_dashboard_components). For a list of the available components, refer to [Available visualizations](xref:Available_visualizations) in the Dashboards section.

> [!NOTE]
> To delete a panel, click the garbage can icon next to the panel name in the page configuration pane, and then click the confirmation icon.

## Configuring the header bar of a custom app page

1. Click the *headerbar* toggle button.

1. Click the "+" icon on the left or right side of the page header bar, depending on where you want to add a button to the header bar.

1. Enter a name for the button. You can do so directly on the button in the header bar, or in the page configuration pane.

1. In the page configuration pane, expand the *Icon* section to select an icon for the button.

1. If you want the button to be a drop-down box, click the ![Set as drop-down](~/user-guide/images/AppSetAsDropdown.png) icon.

1. To configure what will happen when a user clicks the button:

   1. Expand the *Events* section for the header bar in the page configuration pane, and click the configuration button to the right of *On click*.

   1. Select and configure the action(s) that should be triggered when the button is clicked. See [Configuring custom app events](#configuring-custom-app-events).

1. Add and configure additional buttons if needed.

> [!NOTE]
> To delete a button, click the garbage can icon next to that button in the page configuration pane, and then click the confirmation icon.

## Configuring custom app events

At present two types of events can be configured in the DataMiner Application Framework:

- *On page load*: This event takes place when a page is loaded. (See [Configuring a page of a custom app](#configuring-a-page-of-a-custom-app).)
- *On click*: This event takes place when a user clicks a button. (See [Configuring the header bar of a custom app page](#configuring-the-header-bar-of-a-custom-app-page).)

For each of these events, you can configure actions as follows:

- To launch a script, select *Launch a script* and select the script. If the script requires input such as dummies and parameters, configure these as well. The *Use feed* checkbox allows you to link a parameter to an existing feed. Optionally, click the *Show settings* button to configure [script execution options](xref:Script_execution_options).

- To navigate to a URL, select *Navigate to a URL* and specify the URL.

- To open another page of the dashboard, select *Open a page* and specify the page.

- To open a panel, select *Open a panel* and specify the panel. You can then select whether the panel should be opened in a pop-up window, on the left or on the right, you can configure the width of the panel, and you can specify whether it should be opened as an overlay. If it is opened as an overlay, the background for the panel is slightly blurred, and the panel is automatically hidden as soon as the user clicks outside it.

- To close a panel, select *Close a panel* and specify the panel.

- To open another app, select *Open an app* and select the app. You can select any of the custom apps that have been published in your DMS.

- To execute an action for a specific component, select *Execute component action* and specify which action should be executed. This option is only displayed if there is a component action that can be executed. For example, if you configure this action for a [Table](xref:DashboardTable) component, you can select the options *Clear selection*, *Fetch the data*, or *Select an item*.

- After you have configured an action, you can click *Upon completion* to configure another action that should occur as soon as the previous action is completed. Alternatively, you can configure another action that should happen at the same time with the *Add action* button in the lower right corner.

- To remove an action, in the action configuration window, click the garbage can icon in the top-right corner of the section for that action, and then click the confirmation icon.

> [!TIP]
> Actions can be combined and chained to create more complex behavior. For example, an *Open a page* action can be followed by an *Open a panel* action to open a panel on a specific page. While the panel is being opened, a *Launch a script* action can execute an Automation script that updates parameters that will be displayed on that panel. All of this can be triggered from a header bar button, for example on the initial page.

## Configuring custom app security

To configure which users can access and/or edit an app:

1. In the app editor, click the user icon in the top-right corner and select *Settings*.

1. In the *Allowed to view the application* box, specify the names of the users and/or groups that should be allowed to view the app.

1. In the *Allowed to edit the application* box, specify the names of the users and/or groups that should be allowed to edit the app.

1. Close the *Settings* window with the X in the top-right corner.

## Retrieving an earlier version of a custom app

When you make changes to an existing custom app, the previous version will be kept in the system. Up to 15 versions of an app can be stored this way.

To go back to a previous version of a custom app:

1. Open the application from the DataMiner landing page (see [Accessing custom applications](xref:Accessing_custom_apps)).

1. Click the user icon in the top-right corner and select *Versions*. This will show the version history of the app.

1. Click the version you want to go back to. You can also click the pencil icon next to that version in the list to immediately start editing it.

> [!NOTE]
> There can only be one published version of a specific application at the same time. If you publish a different version, the previous version will no longer be published.

## Organizing the apps on the landing page in sections

It is possible to organize the custom apps on the landing page in different sections. However, at present this is only possibly by changing the configuration of the apps in JSON.

To do so:

1. On the DMA, go to the app folder: `C:\Skyline DataMiner\applications\[APP_ID]`
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
