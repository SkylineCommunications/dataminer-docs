# An error occurred in the application you were using

#### Symptom

When you open DataMiner Cube (or a custom-made DataMiner XAML browser application) in Internet Explorer, the following error message is displayed:

```txt
An error occurred in the application you were using.
```

If, in the page showing this error message, you click *More Information*, you see the following notice:

```txt
This application type has been disabled.
```

#### Cause

In the security settings of MS Internet Explorer, XAML browser applications (“XBAPs”) have been disabled for the security zone in which you are currently working (“Internet”, “Local intranet”, “Trusted sites”, ...).

#### Resolution

Do one of the following:

- Add the address of the DataMiner client application to the list of “Local intranet” sites, or

- In the security settings of the zone in which you are currently working, set XAML browser applications to “Enabled”:

    1. While seeing the page showing the above-mentioned error message, go to *Internet Options \> Security*.

    2. Click *Custom level*.

    3. Go to the XAML browser applications setting (located in the .NET Framework section), and select “Enabled”.
