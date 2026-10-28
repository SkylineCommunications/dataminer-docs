---
uid: Web_apps_Feature_Release_10.6.12
description: "Release notes for DataMiner web apps Feature Release 10.6.12, with new features, enhancements, and fixes planned for this preview release."
---

# DataMiner web apps Feature Release 10.6.12 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU9].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.12](xref:General_Feature_Release_10.6.12).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.12](xref:Cube_Feature_Release_10.6.12).

## Highlights

*No highlights have been selected yet.*

## New features

### Web API: OpenAPI and AsyncAPI specifications will now be available on each DataMiner Agent [ID 46653]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

On each DataMiner Agent, OpenAPI 3.1 and AsyncAPI 3.1 specifications will now be available in the following files:

- `C:\Skyline DataMiner\WebPages\API\docs\http.json`
- `C:\Skyline DataMiner\WebPages\API\docs\ws.json`

The specifications describe supported HTTP operations, request and response schemas, enum values, WebSocket messages, and subscriptions.

The files are also available over the web at `https://DmaNameOrIpAddress/API/docs/`.

### Interactive automation scripts: Grid layout now supported in web apps [ID 46716]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Interactive automation dialogs in the DataMiner web apps now support a Grid layout. Components retain the row and column positions defined in the script, while TAB navigation follows the order in which blocks are added using `UIBuilder.AppendBlock`. This allows you to align keyboard navigation with an operational workflow without changing the dialog's visual arrangement.

To enable the Grid layout, set `WebUILayout` when creating a `UIBuilder`:

```csharp
var uiBuilder = new UIBuilder
{
    WebUILayout = WebUILayout.Grid
};
```

For example, to make TAB navigation move down the first column before continuing in the second, append all blocks in the first column from top to bottom, followed by the blocks in the second column.

The existing Table layout remains the default, preserving the layout and navigation behavior of scripts that do not set this property.

> [!NOTE]
>
> - This feature will only work in conjunction with DataMiner server version 10.7.0/10.6.12 or newer. See also [Interactive Automation scripts: New WebUILayout property [ID 46602]](xref:General_Feature_Release_10.6.12#interactive-automation-scripts-new-webuilayout-property-id-46602).
> - Unlike the Table layout, the Grid layout does not automatically resolve overlapping components or adjust spans. It also does not reserve extra space for validation messages.

## Changes

### Enhancements

#### Security enhancements [ID 45477] [ID 46697]

<!-- 45477: MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->
<!-- 46697: MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

A number of security enhancements have been made.

#### GQI DxM - Parameter table: Support added for OR filtering [ID 46606]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

For the *Parameter table by ID* data source and the *Get parameters for elements where* data source, GQI will now optimize filters using the `In` operator. Where supported, the filter values will be forwarded to the server instead of being processed by GQI.

#### Web apps: 'Keep me signed in' option removed from the login page [ID 46714]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

The *Keep me signed in* checkbox has been removed from the authentication page.

If you want to remain signed in after a client or server restart, we recommend that you use external authentication via SAML instead.

> [!NOTE]
>
> - The legacy *Maps* app can no longer log in automatically. To prevent users from having to authenticate each time they navigate to a map, we recommend that you embed the maps in a dashboard or a low-code app instead.
> - The `API/v1/Json.asmx/ReconnectAppAndInfo` call and the `DMAConnectAndInfo.Cookie` property are now obsolete.

#### Web apps: A number of popup windows have been redesigned [ID 46766]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

In the different DataMiner web apps, a number of popup windows have been redesigned.

#### Dashboards/Low-Code Apps - EPM picker component: Updated dropdown input [ID 46787]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

The *EPM picker* component now uses the updated dropdown input for consistency with other components.

#### GQI DxM: Maximum number of concurrent sessions is now configurable [ID 46819]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

You can now configure the maximum number of concurrent GQI sessions using `GQIOptions.MaxSessionCount` in *appsettings.custom.json*. The default remains 500, and supported values range from 1 to 10000.

For example, the following configuration sets the session limit to 1000:

```json
{
  "GQIOptions": {
    "MaxSessionCount": 1000
  }
}
```

> [!CAUTION]
> Change this setting at your own risk. Allowing too many resource-intensive query sessions can overload the system.

### Fixes

#### GQI DxM: PaToken DOM Instance IDs could not be filtered correctly [ID 46616]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, when the PaToken data source was queried using the GQI DxM, the DOM Instance ID column would incorrectly return the string representation of a `DomInstanceId` object instead of the GUID value. As a result, filtering on this column did not work correctly.

From now on, the column will expose the correct GUID value and will support filtering for PaTokens both with and without a DOM Instance ID.

#### Dashboards/Low-Code Apps - Time range component: Time range could revert after a trigger was activated [ID 46685]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a *Trigger* component was linked to a *Time range* component, up to now, when the *Trigger* component was activated, the *Time range* component could revert to an older range. A manually entered range could also change.

From now on, when a *Trigger* component is activated, the time range specified in the linked *Time range* component will be preserved.

#### Dashboards/Low-Code Apps - Pivot component: Error appeared in settings before parameter was fetched [ID 46774]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, when a parameter used in a *Pivot* component had not yet been fetched, an error could appear in the component settings.

#### Interactive automation scripts in web apps: Date-only controls could show an incorrect initial date [ID 46814]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a custom time zone was configured for an interactive automation script in a web app, date-only controls could show an incorrect initial date, typically the day before the specified date.

#### Web apps: Incorrect error message when a request timed out via dataminer.services [ID 46826]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a request via dataminer.services took 30 seconds or longer and failed with an HTTP 504 timeout, the web apps would incorrectly display the following error message: "You are no longer connected with DataMiner Cloud, please refresh."

From now on, the following message will be displayed instead: "The request timed out because the server did not respond in time."
