---
uid: Configuring_the_landing_page
---

# Configuring the landing page of a DMA

In the file *Config.manual.asp*, located in the folder *C:\\Skyline DataMiner\\WebPages\\*, you can specify what happens when a user browses directly to the IP address of hostname of the DMA.

> [!NOTE]
>
> - If the *Config.manual.asp* file does not exist on a DMA, it is automatically created during DataMiner startup.
> - The file is NOT automatically synchronized with other DMAs in the DMS.

## Configuring whether the landing page is displayed

You can configure whether the landing page is displayed or instead the Monitoring app is opened when a user browses to a DMA.

1. Open *C:\\Skyline DataMiner\\WebPages\\config.manual.asp* in a text editor.

1. Set the variable *defaultHTMLApp* to one of the following values:

   - No value (default): The landing page will be displayed.
   - **HTML5**: The DataMiner Monitoring app to be opened.

   For example, if the following configuration is applied, the landing page will be displayed:

   ```txt
   var defaultHTMLApp = "";
   ```

   > [!NOTE]
   > In case you intend to use Edge in IE compatibility mode, you will need to configure the *defaultApp* variable instead. If you set this variable to *Cube* or an empty value, DataMiner Cube is opened. If you set it to *HTML5*, the Monitoring app is opened.

## Showing the company logo on the landing page

It is possible to customize the landing page so that the company logo is displayed.

1. Open *C:\\Skyline DataMiner\\WebPages\\config.manual.asp* in a text editor.

1. Set the setting *showCustomerLogo* to *true*. This setting is set to false by default.

   ```txt
   var showCustomerLogo = true;
   ```

> [!NOTE]
> To set your company logo in DataMiner Cube, go to *System Center > Agents > System > System Logo*.

## Removing applications from the landing page

It is possible to customize the landing page so that certain applications are not listed on it.

1. Open *C:\\Skyline DataMiner\\WebPages\\config.manual.asp* in a text editor.

1. Specify the applications that should not be displayed in the *disallowed* setting.

   For example, in the following configuration, the landing page will not show the possibility to install the DataMiner Cube desktop app or to open the Monitoring app:

   ```txt
   var disallowed = ["InstallCube","HTML5"];
   ```

## Making users download the Microsoft .NET Framework from an internal server

When a user selects the *Install DataMiner Cube* option from the landing page, a setup program will first check whether Microsoft .NET Framework 4 is installed. If this is not the case, the user will be redirected to `http://dmaip/Tools/InstallNet4.asp`, where the Microsoft .NET Framework 4.6 installer can be downloaded.

By default, the online installer will be downloaded from the Microsoft website. However, if users do not have public internet access, you can allow them to download the offline installer from an internal server (e.g. the DataMiner Agent) instead.

To make users download the installer from an internal server:

1. Download the offline .Net Framework 4.6 installer:

   - <https://www.microsoft.com/en-US/download/details.aspx?id=48137>

1. Place the offline installer in a server folder, and make sure your users are allowed access to it.

1. Specify the internal download URL in the *urlOfflineNetFrameworkInstaller* setting of the *config.manual.asp* file. Make sure to use a “http://” or “https://” address.

   ```txt
   var urlOfflineNetFrameworkInstaller = "http://myServer/myFolder/NDP46-KB3045557-x86-x64-AllOS-ENU.exe";
   ```

1. Make sure that, on all necessary computers, the browser security settings allow users to download the file you specified in step 3.

## Example of a config.manual.asp file

```xml
<%
/*
    * Default application to launch
    * Values: "Cube", "SystemDisplay", "SystemDisplayNU", "SystemDisplayNSU", "HTML5"  or empty to show the landing page.
*/
var defaultApp = "Cube";
/*
    * If operators not have access to a public Internet connection, then specify the internal url to download the offline Microsoft .NET Framework installer
    * Leave empty to download the online installer from the Microsoft website.
*/
var urlOfflineNetFrameworkInstaller = "";
/*
    * Which applications should not be shown on the landing page
    * Array containing values: "Cube", "InstallCube", "HTML5" (multiple values can be filled in separated by a comma)
*/
var disallowed = [];
/*
    * Show the customer logo on the DataMiner landing page.
    * Default: false
*/
var showCustomerLogo = false;
/*
 * Default application to launch when not using Internet Explorer
 * Values: "HTML5" or empty to show the landing page
*/
var defaultHTMLApp = "";
%>
```
