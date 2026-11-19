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

### DataMiner apps: Support for uploading web applications [ID 45878]

<!-- MR 10.5.0 [CU22] / 10.6.0 [CU10] - FR 10.7.1 -->

You can now upload web applications to a DataMiner System and manage them alongside apps created in the low-code editor. Both types of apps are now referred to as **DataMiner apps**.

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

DataMiner apps share the same header bar, authentication, and DataMiner security permissions. You can access them from the landing page, the Surveyor in DataMiner Cube, and the app navigation in the web apps. They support per-user permissions, versioning, deletion, deployment from the Catalog, and export and import through DIS. Adding `?embed` to an app URL hides the header bar.

#### Hosting and app integration

Uploaded apps are deployed in `C:\Skyline DataMiner\applications` and hosted through symbolic links in `C:\Skyline DataMiner\WebPages\proxy\apps`.

The app assets run in an iframe with an isolated, opaque origin, which restricts access to browser resources. Apps can use the `postMessage` API to communicate with the hosting app framework:

- **Request API access**: Send `{"tokens":[{"endpoint":"/API/v1/Json.asmx"}]}`. The response contains the token under `tokens["/API/v1/Json.asmx"]`. Pass this token as the connection parameter or in the `Authorization: Bearer <token>` header in Web API calls.
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

#### GQI DxM: Improved performance for inter-element table parameter queries [ID 46078]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU10] - FR 10.7.1 -->

Performance has improved for GQI queries that retrieve table parameters from multiple elements.

#### Web apps: 'Report an issue' link now includes system information [ID 46824]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

The *Report an issue* link in the help menu of the DataMiner web apps now includes the DataMiner Agent node ID, organization ID, and coordination ID as URL parameters, when available. This allows the system from which you report an issue to be identified.

The information is retrieved when you open the help menu in the header bar. The help button is temporarily disabled and displays a loading indicator until retrieval is complete. Any IDs that cannot be retrieved are omitted from the URL.

#### DataMiner apps: Updated header bar and theme settings [ID 46917]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

The header bar and app options of DataMiner apps now use the latest DataMiner controls for a more consistent experience:

- For apps created in the low-code editor, the header bar retains the app's accent color with contrasting buttons. App, user, and context menus remain light-themed.
- For uploaded apps, the theme selected in the user settings (*Light*, *Dark*, or *System*) now applies to the app shell and embedded content that supports both light and dark color schemes.

The following changes have also been made:

- The app theme setting is no longer restricted to advanced settings.
- For uploaded apps, *Production* and *Staging* have been renamed to *Published* and *Draft*.
- *Versions* in the header bar's options menu has been renamed to *History*.
- *Help* is now available in the header bar.
- The app title is now also displayed on mobile devices.

#### Web apps and Web API: Legacy Ticketing functionality removed [ID 46947]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

Following its end of life, the legacy Ticketing app and its Web API implementation have been removed. Ticketing is now reported as unavailable.

For compatibility with existing WSDL-based clients, the Ticketing methods in the [public web services](xref:Using_the_Web_Services_v1) retain their existing signatures and remain in the WSDL. However, these methods are no longer functional. Calls will now throw an `ObsoleteMethodWebApiException`.

#### DataMiner apps and Web API: Endpoint-based tokens and Authorization header support [ID 46953]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

Uploaded DataMiner apps can now request authentication tokens for multiple API endpoints in a single `postMessage` request to their parent window. For example:

```json
{"tokens":[{"endpoint":"/API/v1/Json.asmx"}]}
```

Each supported endpoint receives a separate response, with the token keyed by the requested endpoint. In this example, the token is returned under `tokens["/API/v1/Json.asmx"]`.

Currently, only relative endpoints starting with `/api/v1/` are supported, regardless of casing. Unsupported endpoints, including absolute URLs, return the error message `This endpoint is not supported.`. This contract prepares for future support for user-defined APIs, which are not yet supported by these token requests.

The Web API now also accepts a connection string in the HTTP header `Authorization: Bearer <connection string>`. Authentication is handled as follows:

- A non-empty connection parameter takes precedence over the Bearer header.
- When the connection parameter is empty or omitted, Bearer credentials are used. Invalid Bearer credentials cause authentication to fail, even if a valid authentication cookie is present.
- Existing cookie-based authentication remains available when no Bearer credentials are supplied.

Cross-origin resource sharing (CORS) now allows the `Authorization` header for sandboxed uploaded apps.

#### Web DcM: Updated PuppeteerSharp and bundled Chromium [ID 46955]

<!-- MR 10.5.0 [CU22] / 10.6.0 [CU10] - FR 10.7.1 -->

The Web DcM, which generates PDF reports, now uses PuppeteerSharp 25.15.0 instead of 21.1.1.

This update also includes Chromium 155.0.8059.84.

#### Web apps: Information message when an app manages its own theme [ID 46973]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When an app manages its own theme, the user settings now display the message "Theme setting is managed by the app." above the *Theme* setting. This clarifies why your selected theme does not affect that app.

The message is not shown in apps that support this setting, such as Assistant, the DataMiner landing page, and uploaded DataMiner apps.

#### GQI DxM: Legacy Ticketing data source removed [ID 47037]

<!-- MR 10.6.0 [CU10] / 10.7.0 [CU0] - FR 10.7.1 -->

Following the end of life of Ticketing in DataMiner 10.6.0, the legacy Ticketing data source has been removed from the GQI DxM.

Queries that still use this data source can no longer be executed. In low-code apps, for example, they will fail with the error `GQI error: An unknown error occurred in GQI: Failed parsing request: Invalid ID: 'Ticketing'.`.

#### DataMiner upgrade: DataMiner Assistant DxM installed on every Agent [ID 47047]

<!-- MR 10.7.0 - FR 10.7.1 -->

DataMiner web-only upgrades will now install the DataMiner Assistant DxM on every DataMiner Agent being upgraded, even if the DxM was not previously installed. Previously, upgrades would only update the DxM on Agents where it was already installed.

If a newer version of the DataMiner Assistant DxM is already installed, it will not be downgraded.

#### Web apps: Clearer sign-in screens and improved connection recovery [ID 47070]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

The sign-in and application authorization screens now show the target system and application more clearly. More compact sign-in dialogs are used when applications request API access.

Also, expired connections will now trigger connection recovery. Access-denied responses will no longer unnecessarily interrupt an otherwise valid session.

#### Web apps: System-wide DataMiner Intelligence setting [ID 47084]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

A new *DataMiner Intelligence* setting in the web apps' *System settings* allows you to enable or disable DataMiner Intelligence for the entire DataMiner System.

- Changing the setting requires both the *Access* permission under *DataMiner Intelligence* and the *Admin tools* permission. Without both permissions, the setting is read-only.
- Enabling the setting requires DataMiner server version 10.7 or higher and a dataminer.services connection. If either requirement is not met, you cannot enable the setting, and a tooltip explains why.
- The setting and permission labels use your configured product name.

Changes take effect immediately, without reloading the page. Disabling DataMiner Intelligence removes the Assistant app from the app menu and apps overview. If the Assistant app is already open, it displays a "page not found" message. Enabling DataMiner Intelligence makes the app available again.

The *Specialized agents* setting in the Assistant app now also saves changes immediately, without reloading the page. The chat, agent overview, and agent editor update right away. If the selected agent becomes unavailable, the chat switches to the default agent. Changing this setting requires the *Admin tools* permission.

#### DataMiner apps: Custom header buttons and menus for uploaded apps [ID 47099]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

Uploaded DataMiner apps can now add buttons, nested menus, spacers, and separators to the application header through the `postMessage` API. Button labels, icons, tooltips, loading states, and disabled states can be updated without replacing the controls.

##### Configuring header controls

Send the following message from the app's iframe to configure its header controls:

```json
{
  "header": {
    "set": [
      { "label": "Save", "icon": "save", "identifier": "save" },
      { "type": "separator" },
      { "icon": "refresh", "title": "Refresh data", "identifier": "refresh" },
      { "type": "spacer" },
      {
        "label": "Export",
        "children": [
          { "label": "Export PDF", "identifier": "export-pdf" },
          {
            "label": "More formats",
            "children": [
              { "label": "Export CSV", "identifier": "export-csv" }
            ]
          }
        ]
      }
    ]
  }
}
```

Button and menu items support `label`, `title` (tooltip), `icon`, `identifier`, and `children`:

- Top-level buttons require a non-blank label, or both an icon and a title. Child menu items always require a non-blank label.
- Items without children require a non-blank identifier. Selecting them sends `{"header":{"identifier":"<selected identifier>"}}` back to the iframe.
- Items with children open a menu without sending an action message. They can have an identifier for presentation updates.
- Top-level buttons and leaf menu actions support the boolean fields `isLoading` and `isDisabled`. Either state prevents activation. Nested submenu parents do not support these fields.
- Spacers and separators are supported only at the top level and cannot contain fields other than `type`.

Each `set` replaces the previous custom controls and closes the active context menu. Send `{"header":{"set":[]}}` to remove custom controls without removing the framework header.

##### Updating header controls

To update existing controls, send an array of updates targeting controls by a unique identifier:

```json
{
  "header": {
    "update": [
      { "identifier": "save", "label": "Saving", "isLoading": true },
      { "identifier": "export-pdf", "isDisabled": true }
    ]
  }
}
```

Updates can change `label`, `title`, `icon`, `isLoading`, and `isDisabled`, but not identifiers, children, or layout. Set a label, title, or icon to `null` to clear it, provided the resulting item still meets its presentation requirements. Set a loading or disabled state to `false` to clear it.

Updates appear in place in the header and the first-level open menu. An already-open deeper submenu must be reopened to show its updated presentation or state.

Update batches are applied atomically: an invalid update, or an unknown or duplicated identifier, leaves all controls unchanged. Repeated updates targeting the same uniquely identified control are merged in order, and each intermediate result must remain valid.

##### Validation and menu interaction

A header command must contain exactly one of `set` or `update`. The former array-only format, `{"header":[...]}`, is not accepted. Invalid requests return the following messages without changing existing controls:

- Invalid commands: `{"message":"Invalid header command."}`
- Invalid configurations: `{"message":"Invalid header configuration."}`
- Invalid updates: `{"message":"Invalid header update."}`
- Unknown or duplicated update identifiers: `{"message":"Unknown or ambiguous header button identifier."}`

Clicking outside a context menu over the app's iframe dismisses the menu without activating the iframe content underneath. Custom controls are cleared when the host application model changes.

#### GQI DxM: 'Get alarms' data source now includes alarm focus information [ID 47109]

<!-- MR 10.6.0 [CU10] / 10.7.0 [CU0] - FR 10.7.1 -->

The *Get alarms* data source now includes two additional columns with alarm focus information:

- *Alarm likelihood*: The likelihood estimated by alarm focus, displayed as a percentage. A low likelihood indicates an unexpected alarm. This is unrelated to the alarm's severity.
- *Is focus alarm*: True when the alarm likelihood is below 70%, indicating an unexpected alarm that deserves your attention. False when the likelihood is 70% or higher. This 70% limit is also the limit used by Cube.

Alarm focus information is only available for active alarms. All alarms in an alarm tree show the current alarm focus information for that tree. The columns are empty for cleared alarms and alarms without an assigned likelihood, such as correlation alarms. They are also empty when alarm focus is disabled or not supported on the DataMiner System.

Filtering the *Get alarms* data source on *Is focus alarm* equal to true retrieves only active alarms from the DataMiner System.

#### Web apps: Remaining support for legacy Annotations removed [ID 47115]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

The remaining support for the legacy Annotations module has been removed from the DataMiner web apps. This support had been retained for backward compatibility with DataMiner 10.5.0 servers, but the module has reached end of life.

### Fixes

#### Web API: GetUsers could return an empty user list [ID 46942]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When the DataMiner security or view configuration changed while a `GetUsers` Web API call was being processed, the call could incorrectly return an empty list. This could happen, for example, when an element was created or deleted.

As a result, users with access to a dashboard or a DataMiner app could be shown as "User not found" in its access settings.

#### Web API: WebSocket deadlock could prevent clients from receiving messages [ID 46946]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When many WebSocket messages were sent in a very short time, a deadlock could occur in the Web API, preventing clients from receiving any further messages.

#### Dashboards app: Preselected parameter values missing from PDF reports [ID 46972]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When a PDF report was generated from a dashboard with stacked components, parameter selectors could fail to display their preselected values. This affected reports generated from the Dashboards app as well as scheduled reports.

Parameter selectors now correctly display the preselected values. Some selectors may take up slightly more space in the report.

#### GQI DxM: Parameter table queries could deadlock during paging with live updates [ID 46998]

<!-- MR 10.7.0 [CU0] / 10.6.0 [CU10] - FR 10.7.1 -->

When live updates were enabled for a parameter table query, a deadlock could occur if a table update notification arrived while GQI was fetching rows. Paging and update delivery could then wait indefinitely for each other, also blocking unrelated queries and session cleanup.

#### Dashboards app: Input component values missing from non-stacked PDF reports [ID 47036]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When a non-stacked PDF report was generated from a dashboard, values from *Dropdown*, *Text input* (including multiline text), *Numeric input*, and *Search input* components could be missing. These values will now be included in the report.

Stacked reports remain unchanged.

#### Dashboards app: GQI tables could stop loading rows and receiving live updates [ID 47054]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When a GQI table in a dashboard was opened before its WebSocket connection was ready, scrolling could stop loading additional rows and live updates could stop appearing after the connection became available.

#### Dashboards app: GQI table updates could exceed the JSON size limit [ID 47066]

<!-- MR 10.6.0 [CU10] - FR 10.7.1 -->

When live updates were enabled for a GQI table in a dashboard, duplicated data in row updates could cause the JSON size limit to be exceeded. As a result, the table could stop loading additional rows.

Unnecessary duplication in table updates has now been removed, reducing the amount of data sent to the dashboard.

#### GQI DxM: Live updates could overwrite unchanged cells in other rows [ID 47068]

<!-- MR 10.6.0 [CU10] / 10.7.0 [CU0] - FR 10.7.1 -->

When a real-time update affected multiple rows, values from an earlier row could be copied into subsequent rows, overwriting cells that had not changed. This could cause incorrect values in live query results or in rows retrieved on later pages.

Real-time updates will now preserve unchanged cells in each row.
