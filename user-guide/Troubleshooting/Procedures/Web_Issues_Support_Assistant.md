---
uid: Web_Issues_Support_Assistant
---

# Web Support Assistant Chrome Extension

## Introduction

This documentation provides an overview of the DataMiner Web Support Assistant, a Chrome extension designed to assist users of DataMiner web apps on Chromium browsers. The purpose of this extension is to facilitate the reporting of bugs, enabling users to report their issues accurately and efficiently, while also streamlining the bug-fixing process for the development team.

## How to install the Extension

Adding the DataMiner Web Support Assistant extension to the Google Chrome browser can be done by opening this [link](https://chromewebstore.google.com/detail/dataminer-web-support-ass/nofmcbgpolhjblmafpfbffjnganhapge) and click "Add to Chrome."

After adding the extension, users can verify its addition was successful by clicking the puzzle icon in the top right corner of their browser in Chrome. The extension should be listed among their other installed extensions.

> [!Warning]
> After adding the extension for the first time, users should ensure to refresh the tab they want to record or restart the Chrome browser entirely. This step is only necessary when using the extension for the first time.

## Creating a recording

![Web Support Assistant icon and popup](~/user-guide/images/Web_Support_Assistant_icon_popup.png)

> [!Note]
> To simplify creating a recording, it is highly recommended to pin the extension. To do this, click the puzzle icon in the top right corner of the browser and then click the pin icon next to the extension. The extension's icon should now be visible next to the puzzle piece.

With the extension successfully added, follow these simple steps to create a recording:

1. Navigate to the tab where you are experiencing an issue with a DataMiner web app.

1. Click the puzzle icon in the top-right corner of your browser and select *DataMiner Web Support Assistant* from the list of available extensions.

1. Click the large red record button to start the recording. The extension will minimize, indicating that the recording has begun. The maximum duration for a recording is 10 minutes.

1. Replicate the process that led to encountering the bug or issue in the web app.

1. When the issue has been successfully replicated, reopen the extension and click the red *END* button to stop the recording.

1. Allow the extension to finish processing the data. This will be indicated by a loading screen. Do not close the extension during this process.

   Once the recording is ready, a green checkmark will be displayed.

1. Click *Download* to download the ZIP file containing all the necessary data. This concludes the recording process..

> [!IMPORTANT]
> The extension only collects data from the tab in which the recording was started. Ensure to stay within that tab to accurately recreate the issue.

### Settings

![Web Support Assistant settings](~/user-guide/images/Web_Support_Assistant_icon_settings.png)

The extension allows enabling or disabling a few settings. All these settings are however recommended to be enabled to provide as much data as possible to the team investigating the issue. 

| Setting | Description |
|--|--|
| Include console logs    | Capture any logs shown in the console during recording. |
| Include local storage   | Capture a snapshot of localStorage for the current tab (DataMiner Web Apps). |
| Include network traffic | Record a HAR of all incoming and outgoing network requests. |
| Include video recording | Record the browser tab’s screen during the session. |
| Reload tab on start     | Automatically refresh the tab when recording begins to include all necessary data. |