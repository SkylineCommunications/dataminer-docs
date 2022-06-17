---
uid: An_error_occurred_in_the_application_you_were_using
---

# An error occurred in the application you were using

## Symptom

When you open the DataMiner Cube browser app (or a custom-made DataMiner XAML browser application) in Edge in IE compatibility mode, the following error message is displayed:

```txt
An error occurred in the application you were using.
```

If in the page showing this error message, you click *More Information*, you see the following notice:

```txt
This application type has been disabled.
```

## Cause

In the security settings of your internet options, XAML browser applications ("XBAPs") have been disabled for the security zone where you are currently working ("Internet", "Local intranet", or "Trusted sites").

## Resolution

Make sure your browser is configured to allow XBAPs for the relevant URL. See [Configuring Microsoft Edge to run DataMiner Cube](xref:Configuring_Microsoft_edge_to_run_Cube)
