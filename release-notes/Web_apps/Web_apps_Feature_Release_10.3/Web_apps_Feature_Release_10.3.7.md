---
uid: Web_apps_Feature_Release_10.3.7
---

# DataMiner web apps Feature Release 10.3.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.7](xref:General_Feature_Release_10.3.7).

## Highlights

#### Interactive Automation scripts: New DownloadButton component [ID_35869]

<!-- MR 10.4.0 - FR 10.3.7 -->

In an interactive Automation script launched from a dashboard or a low-code app, you can now use *DownloadButton* components. These components allow you to add download buttons that will enable users to download a specified file from the server.

To add a *DownloadButton* component to an interactive Automation script, create a *UIBlockDefinition* and set its *Type* property to "UIBlockType.DownloadButton". The button can be configured and styled in same way as a regular button component. For example, you can set the *Style* property to "Style.Button.CallToAction" and the *Text* property to "Download".

To configure the download properties, assign `AutomationDownloadButtonOptions` to the *ConfigOptions* property of the *UIBlockDefinition*.

These are the supported download properties:

- **Url**: The URL of the file. This URL can be either an absolute or a relative path.

  - An absolute path must refer to a file that is publicly accessible on the internet.
  - A relative path is relative to the DMA hostname and must start with `/`, `./` or `../`.

  Examples:

  - Example of an absolute path: To download the latest Cube version from DataMiner Services, set *Url* to `https://dataminer.services/install/DataMinerCube.exe`.
  - Example of a relative path: To download the file hosted on URL `http(s)://yourDma/Documents/MyElement/MyDocument.txt` (i.e. the file *MyDocument.txt* located in the folder `C:\Skyline DataMiner\Documents\MyElement\` of the DMA), set *Url* to `/Documents/MyElement/MyDocument.txt`.

- **FileNameToSave**: The name that will be given to the file once it has been downloaded. By default, this name is identical to that of the file at the remote location.

  > [!NOTE]
  > Some browsers block overriding the file name when the file to be downloaded is not located on the DataMiner Agent. In this case, the original file name will be used.

- **StartDownloadImmediately**: If set to true (default setting is false), the download will start as soon as the component is displayed. The button will stay visible and can be clicked to download the file again.

- **ReturnWhenDownloadIsStarted**: If set to true (default default is false), the `engine.ShowUI()` method will return as soon as the download is started (either immediately or when the user clicks the button, depending on *StartDownloadImmediately*). When both *StartDownloadImmediately* and *ReturnWhenDownloadIsStarted* are set to true, the script will start the download and exit immediately (unless a new `engine.ShowUI()` call is made).

  > [!NOTE]
  > The script's UI will be visible for about half a second.

The `UIResult` now also supports the following function method, which returns true when a download button with *ReturnWhenDownloadIsStarted* set to true has started a download.

```csharp
bool WasOnDownloadStarted(string key)
```

> [!NOTE]
>
> - Modern browsers block downloads from a `file:///` URL to an HTTP(s) address. In other words, they don't allow you to download a file located on a network share. As a workaround, you can copy the file from the network share to *Documents* (or any other HTTP-reachable location), and then let the client download it from that URL.
> - The current IIS configuration does not allow all file types to be downloaded.

## Other features

*No other features yet*

## Changes

### Enhancements

#### Security enhancements [ID_36217]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

A number of security enhancements have been made.

#### External authentication using SAML: Enhanced error handling [ID_36274]

<!-- MR 10.4.0 - FR 10.3.7 -->

Instead of a generic error message, a more meaningful error message will now appear when something goes wrong while authenticating a user via SAML.

### Fixes

#### Dashboards app & Low-Code Apps - Line chart: X and Y axis labels would not show the correct text [ID_35943]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The X and Y axis labels of a line chart would not show the correct text when the data was grouped.

#### Dashboards app & Low-Code Apps: Components would prematurely consider themselves loaded [ID_36142]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

In some cases, components would incorrectly consider themselves loaded while they were still loading. As a result, it would already be possible to execute actions on those components before those actions could be properly processed.

#### Dashboards app & Low-Code Apps - Query builder: Select nodes would incorrectly not show the selected columns [ID_36251]

<!-- MR 10.4.0 - FR 10.3.7 -->

In the query builder, when a *Select* node was not in edit mode, its description would incorrectly not show the selected columns.

#### Dashboards app & Low-Code Apps: State component would incorrectly not be cleared when its input feed was cleared [ID_36261]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, a *State* component would incorrectly not be cleared when its input feed was cleared.

#### Low-Code Apps: Table actions would incorrectly be executed before the rows were fed [ID_36263]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, table actions would be executed before the rows were fed. As a result, the feed would get lost when you navigated away from the page via an action. From now on, a row will always be fed before row actions are executed.

#### Low-Code Apps: Custom icon of a low-code app without a draft version would not be displayed on the DataMiner landing page [ID_36277]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When a low-code app with a custom icon did not have a draft version, the DataMiner landing page would incorrectly not display the icon of that app.

#### Dashboards app: Height of 'DATA USED IN DASHBOARD' section would incorrectly change after collapsing and expanding it [ID_36282]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you collapsed and expanded the *DATA USED IN DASHBOARD* section of the *DATA* tab, in some cases, the height of that section would incorrectly change.

#### Dashboards app & Low-Code Apps: Updating a query would incorrectly not update the query filter component [ID_36283]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When a query was updated, the query filter component would incorrectly only get updated after a refresh.

#### Monitoring app: Surveyor items would be sorted incorrectly [ID_36303]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In the Surveyor of the Monitoring app, items of which the name contained a number would be sorted incorrectly. For example, *Element 2* would appear below *Element 11*. From now on, the items in the Surveyor of the Monitoring app will be sorted in the same way as those in the Surveyor of DataMiner Cube.
