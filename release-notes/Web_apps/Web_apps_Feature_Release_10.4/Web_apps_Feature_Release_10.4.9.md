---
uid: Web_apps_Feature_Release_10.4.9
---

# DataMiner web apps Feature Release 10.4.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.9](xref:General_Feature_Release_10.4.9).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps: New 'Interactive Automation script' component [ID_39969]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In low-code apps, you can now use *Interactive Automation script* components.

An *Interactive Automation script* component allows you to launch a preset interactive Automation script (ad hoc, on view, or after an event has occurred) and to display its UI. It also allows you to select a script and launch it, or to abort the script that is being run.

When you launch a new script while another is being run, the new script will start once the other script has finished.

In the settings of the component, you can also opt to have the component either show or hide the name of the script.

> [!NOTE]
>
> - The component cannot be used to launch Automation scripts that are not interactive.
> - The component will not ask for any missing parameters or dummies. It expects them to be filled in either in its settings or via feeds. When input is missing, the script will not be launched and the component will be blank.
> - By default, scripts will time out after 15 minutes. If a script times out, an error will be displayed in the component.

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Web apps: Users would not get logged in after pressing ENTER on the authentication page [ID_39961]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, on a mobile device, you entered your credentials on the authentication page of a DataMiner web app and pressed ENTER, you would incorrectly not be logged in. Instead, the authentication page would simply refresh.
