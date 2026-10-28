---
uid: Web_apps_Feature_Release_10.7.1
description: "Release notes for DataMiner web apps Feature Release 10.7.1, with new features, enhancements, and fixes planned for this preview release."
---

# DataMiner web apps Feature Release 10.7.1 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU10].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.7.1](xref:General_Feature_Release_10.7.1).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.7.1](xref:Cube_Feature_Release_10.7.1).

## Highlights

*No highlights have been selected yet.*

## New features

### DataMiner Apps: Support for uploading web applications [ID 45878]

<!-- MR 10.5.0 [CU22] / 10.6.0 [CU10] - FR 10.7.1 -->

You can now upload web applications to a DataMiner System and manage them alongside apps created in the low-code editor. Both types of apps are now referred to as **DataMiner Apps**.

On the DataMiner landing page, the *Add* menu now contains the options to upload an app, browse the Catalog, and create an app in the low-code editor. Clicking the *Add* button itself will create an app in the low-code editor.

#### Uploading and publishing an app

To upload an app, select *Add* > *Upload App* on the landing page and provide a ZIP file containing:

- All assets required to run the app, such as HTML, JavaScript, and CSS files.
- An *App.info.json* file at the root of the ZIP file, containing the following metadata:

  - `Name` (required): The display name of the app.
  - `Color` (required): The accent color, specified as a hexadecimal or RGB string.
  - `Icon` (required): An icon name prefixed with `ms-Icon--`, or a relative path to an image in the app assets.
  - `ID` (optional): A GUID identifying the app. If it identifies an existing app, uploading the package will deploy or overwrite a staging version of that app.
  - `Description` (optional): A summary of the app's functionality.
  - `DefaultDocument` (optional): The relative or virtual path to the home page in the assets folder.
  - `Manifest` (optional): The relative path to the web app manifest in the assets folder.
  - `Sections` (optional): A list of section names for the landing page. If this list is empty, the app will be placed in the section where it was uploaded.

Uploaded apps are always deployed in staging. Use the *Publish* button to publish an app to production.

DataMiner Apps share the same header bar, authentication, and DataMiner security permissions. You can access them from the landing page, the Surveyor in DataMiner Cube, and the app navigation in the web apps. They support per-user permissions, versioning, deletion, deployment from the Catalog, and export and import through DIS. Adding `?embed` to an app URL hides the header bar.

#### Hosting and app integration

Uploaded apps are deployed in `C:\Skyline DataMiner\applications` and hosted through symbolic links in `C:\Skyline DataMiner\WebPages\proxy\apps`.

The app assets run in an iframe with an isolated, opaque origin, which restricts access to browser resources. Apps can use the `postMessage` API to communicate with the hosting app framework:

- **Request API access**: Send `{"request":"token"}`. The response is `{"token":token}`. Pass this token as the connection parameter in Web API calls.
- **Update the browser URL**: Send `{"url":newURL}`. No response is returned.
- **Store client-side data**: Send `{"storage":{"write":{"key":key,"data":data}}}`.
- **Read stored client-side data**: Send `{"storage":{"read":{"key":key}}}`. The response is `{"storage":{"data":data,"key":key}}`.

> [!IMPORTANT]
> Content in `C:\Skyline DataMiner\WebPages\proxy` can only be accessed through an iframe. Opening this content directly in a browser will display an HTTP 403 error page.

#### Authentication changes

The Web API now uses an HttpOnly session cookie: `__Http-webapi-sid` for HTTPS connections or `webapi-sid` for HTTP connections. Only the authentication app can use this cookie to request access tokens for apps.

The web apps no longer pass the Web API session ID through the `DMAConnection` cookie. Instead, the authentication app grants access to each app using an app-specific HttpOnly cookie. The `DMAConnection` cookie is set to an empty GUID to indicate that the app is authenticated. The `AK` cookie is now also HttpOnly.

For backward compatibility, Web API methods still accept the connection string returned by `ConnectAppAndInfo`.

Three authentication flows are supported:

- **iframe** (default): The app loads the authentication app in an iframe over its content. After authentication, the app continues loading resources that require a connection, without having to reload its other resources.
- **redirect**: The app redirects to the authentication app and redirects back after authentication. This was the previous behavior.
- **popup**: The authentication app opens in a separate browser window. This allows embedded apps to authenticate with SAML providers that do not allow their sign-in page to be embedded. If the browser blocks the pop-up window, a fallback link is displayed.

You can configure the flow per app by setting the `SLAuthStrategy` cookie in *web.config*. For example:

```xml
<system.webServer>
  <httpProtocol>
    <customHeaders>
      <add name="Set-Cookie" value="SLAuthStrategy=iframe; path=/; secure; SameSite=strict" />
    </customHeaders>
  </httpProtocol>
</system.webServer>
```

#### Related fixes

This update also resolves the following issues:

- The splash screen icon could be missing when an app created in the low-code editor was first loaded.
- Temporary documents were not cleaned up after dashboards or apps created in the low-code editor were deployed from the Catalog, causing a memory leak.
- Signing out through the UI could briefly display an old version of the UI on slow networks.
- A sign-out button could incorrectly appear when signed in through SAML.

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

*No fixes have been added yet.*
