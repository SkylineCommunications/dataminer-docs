---
uid: Web_Issues_Support_Assistant
description: The DataMiner Web Support Assistant is a Chrome extension designed to assist users of DataMiner web apps on Chromium browsers.
---

# Web Support Assistant

The DataMiner Web Support Assistant is a **Chrome extension** designed to assist users of DataMiner web apps on Chromium browsers. The purpose of this extension is to facilitate the reporting of bugs, allowing you to report issues accurately and efficiently, while also streamlining the bug-fixing process for the development team.

## Installing the extension

To add the DataMiner Web Support Assistant extension to your Chromium browser:

1. Open [this link](https://chromewebstore.google.com/detail/dataminer-web-support-ass/nofmcbgpolhjblmafpfbffjnganhapge) and click the button to deploy the extension.

1. If a confirmation box appears, click *Add extension*.

1. Click the puzzle icon in the top-right corner of your browser to check if the extension is listed among the other installed extensions.

1. Optionally, click the pin icon next to the extension in the extension overview.

   ![Pin the Web Support Assistant in the header bar](~/dataminer/images/Web_Support_Assistant_pin.png)

   While this step is optional, we highly recommend it as it will make the extension icon visible in the browser header bar, making it easier to create a recording later.

1. Before you use the extension for the first time, **refresh the tab** you want to record or restart your browser.

## Creating a recording

When you have followed the steps above and the extension has been successfully added, follow these steps to create a recording:

1. Navigate to the tab where you are experiencing an issue with a DataMiner web app.

   > [!IMPORTANT]
   > If this is the first time you are using the extension, make sure you have refreshed the tab or restarted the browser before you continue.

1. If you pinned its icon earlier, click the DataMiner Web Support Assistant icon.

   If you did not pin the icon, click the puzzle icon in the top-right corner of the browser and select *DataMiner Web Support Assistant* from the list of available extensions.

   This will open the following pane:

   ![Web Support Assistant icon and popup](~/dataminer/images/Web_Support_Assistant_icon_popup.png)

1. Click the large red record button to start the recording.

   The extension will minimize, indicating that the recording has begun. The maximum duration for a recording is 10 minutes.

1. Replicate the process that led to encountering the bug or issue in the web app.

   > [!IMPORTANT]
   > The extension only collects data from the tab where the recording was started. Make sure to stay within that tab to accurately recreate the issue.

1. When the issue has been successfully replicated, reopen the extension and click the red *END* button to stop the recording.

1. Allow the extension to finish processing the data.

   This will be indicated by a loading screen. Do not close the extension during this process.

   Once the recording is ready, a green checkmark will be displayed.

1. Click *Download* to download the ZIP file containing all the necessary data.

   This concludes the recording process.

## Extension settings

Via the cogwheel button of the extension, you can enable or disable a number of settings. However, we recommend keeping all of these settings enabled to provide as much data as possible to the team investigating the issue.

![Web Support Assistant settings](~/dataminer/images/Web_Support_Assistant_icon_settings.png)

The following settings are available:

| Setting | Description |
|--|--|
| Include console logs    | Captures any logs shown in the console during recording. |
| Include local storage   | Captures a snapshot of local storage for the current tab (DataMiner Web Apps). |
| Include network traffic | Records a HAR file of all incoming and outgoing network requests. |
| Include video recording | Records the browser tab's screen during the session. |
| Reload tab on start     | Automatically refreshes the tab when recording begins to include all necessary data. |
