---
uid: Configuring_app_actions_and_behavior_via_URL
---

# Configuring app actions and behavior via the URL

## Executing actions via the app URL

From DataMiner 10.3.6/10.4.0 onwards<!-- RN 35979 -->, you can make an app execute one or more actions by adding the action configuration to the app URL. This can for instance be used to make an app embedded in Visual Overview execute actions.

### Configuration

1. Configure the actions in the action editor.

1. Click the *Copy actions* button to copy the action configuration to the clipboard as a JSON object.

1. Add `#{"actions": }` to the URL, and paste the copied JSON object between the colon (`:`) and the closing bracket (`}`).

The actions you have added will immediately be executed when the URL is loaded.

As soon as the actions have been executed, the action configuration will be removed from the URL, so that they do not get executed multiple times.

> [!NOTE]
>
> - Making an app execute actions by adding a configuration to its URL does not work while that app is in edit mode.
> - Currently, the following actions cannot be executed this way for security reasons:
>
>   - *Launch a script*
>   - *Execute component action: delete current instance/save current changes*
>   - *Navigate to a URL*

> [!IMPORTANT]
> To guarantee support across all browsers and prevent possible issues, the URL value should be encoded. If, for example, the JSON structure contains any ampersands ("&"), this will not work unencoded.

### Example

In this example, an *Open a panel* action is added to an app URL:

```txt
https://myDMA/APP_ID/PAGE_NAME#{"actions":[{"Type":6,"__type":"Skyline.DataMiner.Web.Common.v1.DMAApplicationPagePanelAction","Panel":"4507edc7-fcee-47bd-985c-f40d844e72cb","Position":"Center","Width":30,"AsOverlay":true}]}
```

> [!NOTE]
> For the example above, this is the encoded equivalent: `https://myDMA/APP_ID/PAGE_NAME#%7B%22actions%22%3A%5B%7B%22Type%22%3A6%2C%22__type%22%3A%22Skyline.DataMiner.Web.Common.v1.DMAApplicationPagePanelAction%22%2C%22Panel%22%3A%224507edc7-fcee-47bd-985c-f40d844e72cb%22%2C%22Position%22%3A%22Center%22%2C%22Width%22%3A30%2C%22AsOverlay%22%3Atrue%7D%5D%7D`

## Configuring app behavior via the URL

You can modify the behavior of an app by adding specific parameters to the URL.

- `showAdvancedSettings=true`: Enables access to advanced settings, including:

  - [Page/Panel configuration > *Lazy load components* setting](xref:Changing_low-code_app_settings)

  - [*Join* query operator > *Row by row* option](xref:GQI_Join)

  - [Line & area chart > Parameter table filter](xref:LineAndAreaChart#configuring-the-component)

  - [Node edge graph > *Enable tooltip* setting](xref:DashboardNodeEdgeGraph#basic-component-configuration)

  - [Node edge graph > *Show metric* setting](xref:DashboardNodeEdgeGraph#basic-component-configuration)

  - [Parameter picker > Parameter table filter](xref:DashboardParameterPicker#configuring-the-component)

  - [Parameter picker > *Index filter separator* setting](xref:DashboardParameterPicker#configuring-the-component)

- `useNewIASInputComponents=true`: Available from DataMiner 10.4.0 [CU11]/10.5.2 onwards<!--RN 41495-->. Allows you to control whether the latest version of the interactive Automation script UI is used for IAS components or when launching an interactive Automation script via the *Launch a script* event. When this parameter is set to "false" or omitted, the app uses the old UI. <!--Expanded by the following RNs: 41188 , 41529, 42032, 42009, 42007, 41891, 41838, 42132, 42210, 42231, 42279, 42401, 42641, 42440, 42826, 42781-->

  > [!NOTE]
  >
  > - From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42009-->, when you add `useNewIASInputComponents=true` to the app URL, some UI components that are still using the previous design may be disabled.
  > - From DataMiner 10.4.0 [CU15]/10.5.0 [CU3]/10.5.6 onwards<!--RN 42440-->, when a default time zone is configured for the web apps, calendar and time input fields consistently use that time zone both for displaying values and for returning the selected date/time. In previous versions, calendar and time input fields display values based on the web session's time zone, but return a date/time in the configured default time zone.
