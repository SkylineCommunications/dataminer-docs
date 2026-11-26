---
uid: AIAgent_App_Agent_Deploying
description: "Deploy an app built with the DataMiner App Agent to your DataMiner System, add it to the landing page, and learn about the current limitations."
---

# Deploying a DataMiner App Agent app

When the [DataMiner App Agent](xref:AIAgent_App_Agent) has finished a build, it tells you the name of the **build folder** in your workspace, e.g., `site-overview`. That folder contains everything the app needs. This page explains how to add it to your DataMiner System.

> [!NOTE]
> At present, deploying an app is a manual procedure: there is no upload button in DataMiner, and apps do not automatically appear on the DataMiner landing page. See [Current limitations](#current-limitations).

## Step 1: Check the build folder

Before you deploy, check the build folder in your workspace:

- It contains an `index.html` file at the top level, together with an `assets` subfolder.
- It only contains static files (HTML, JavaScript, CSS, fonts, and images).
- Its name is the same as the name in the app's base path. Open `vite.config.ts` in the project and check the `base` setting. For example, for the folder `site-overview`, the setting must be:

  ```ts
  base: '/public/site-overview/',
  ```

> [!IMPORTANT]
> If the folder name on the DataMiner Agent and the `base` setting do not match, the app loads a blank page because the browser cannot find its JavaScript and CSS files. Do not rename the folder after the build. To change the name, ask the agent to rebuild the app with the new name.

## Step 2: Copy the build folder to the DataMiner Agent

1. Connect to the DataMiner Agent, e.g., using Remote Desktop.

1. Copy the complete build folder to `C:\Skyline DataMiner\Webpages\Public`.

   For example, the result should be `C:\Skyline DataMiner\Webpages\Public\site-overview\index.html`.

1. If users can connect to more than one DataMiner Agent in the cluster, repeat this on every DataMiner Agent they connect to.

## Step 3: Open the app

Open the app via the DataMiner sign-in page, using the following URL:

```text
https://<dma>/auth/?url=%2Fpublic%2F<build-folder>%2Findex.html
```

For example:

```text
https://my-dma/auth/?url=%2Fpublic%2Fsite-overview%2Findex.html
```

In this URL, `%2F` is the encoded form of `/`. After you sign in, DataMiner opens the app.

> [!NOTE]
> If you open `https://<dma>/public/<build-folder>/index.html` directly without being signed in, the app has no session and redirects you to the sign-in page. Share the sign-in URL above with your users.

## Step 4 (optional): Add the app to the DataMiner landing page

Apps built with the App Agent do not appear on the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page) by themselves. As a workaround, you can create a low-code app that shows your app full screen. That low-code app then appears on the landing page like any other app, and you can use its security settings to control who sees it.

1. On the DataMiner landing page, [create a new low-code app](xref:Creating_custom_apps), and give it the same name as your app.

1. In the edit mode of the low-code app, add a [web component](xref:DashboardWeb) to the page, and resize it so that it fills the entire page.

1. In the *Settings* pane of the web component, configure the following settings:

   - *Type*: `Webpage`.
   - *URL*: The relative URL of your app, e.g., `/public/site-overview/index.html`.
   - *Isolate* (or *Open in sandbox* in older DataMiner versions): Disabled.

   Because the low-code app already runs in a signed-in session, your app uses the same session, and no second sign-in is needed. Isolation must be disabled for this, which is acceptable because the app is hosted in the DataMiner `Public` folder.

1. Leave the [header bar](xref:LowCodeApps_header_config) of the page disabled, so that only the header of your own app is shown.

1. Configure who can see the app with the [security settings](xref:LowCodeApps_security_config) of the low-code app.

1. Publish the low-code app.

Users can now open your app from the landing page. To place it in a specific section of the landing page, see [Organizing the apps on the landing page in sections](xref:LowCodeApps_organizing_landing_page).

## Updating an app

1. Ask the agent for the change, and wait until the new build is ready and the tests pass.

1. Optionally, make a copy of the current folder on the DataMiner Agent, so that you can roll back if needed.

1. Replace the contents of the folder in `C:\Skyline DataMiner\Webpages\Public` with the contents of the new build folder.

1. Reload the app in the browser. If you still see the old version, clear the browser cache or press Ctrl+F5.

## Removing an app

1. Delete the build folder from `C:\Skyline DataMiner\Webpages\Public` on every DataMiner Agent where you copied it.

1. If you added the app to the landing page, also [delete the low-code app](xref:Deleting_custom_apps) that shows it.

## Current limitations

The App Agent is available now so you can start building apps while these limitations are addressed in upcoming updates. Planned improvements include Model Context Protocol (MCP) tools for automatic deployment and better data discovery. Until these improvements are available, follow the current deployment steps and limitations below.

- **Manual deployment**: There is no built-in way to upload or publish an app from DataMiner or from the agent. You need file system access to each DataMiner Agent to copy the build folder.

- **No native landing page entry**: The app only appears on the landing page if you wrap it in a low-code app as described in [step 4](#step-4-optional-add-the-app-to-the-dataminer-landing-page).

- **Public folder**: All files in the `Public` folder can be downloaded without signing in. The data the app shows is protected by the user's session, but the app code itself is not. Never put secrets or sensitive data in the app code.

- **Sign-in URL**: Users need to open the app via the `/auth/?url=` sign-in URL or via a low-code app. Opening the `index.html` file directly only works if the user is already signed in.

- **Fixed folder name**: The folder name on the DataMiner Agent must match the base path the app was built with.

- **No version management**: DataMiner does not keep track of versions of the app. Use version control for the source, and keep a copy of the previous build folder if you want to be able to roll back.

- **Server-side items**: The agent only builds the frontend. Automation scripts, connectors, ad hoc data sources, and DOM definitions that the app uses must be created and deployed separately.
