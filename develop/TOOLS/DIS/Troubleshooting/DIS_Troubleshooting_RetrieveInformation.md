---
uid: DIS_Troubleshooting_RetrieveInformation
keywords: dis logging
---

# Retrieve Information

When you have an issue with DIS, generally it's a good idea to gather as much information needed so that the DIS team can efficiently debug and figure out what is going wrong.

## Basic Information

- DIS version: *Extensions* > *DIS* > *Settings...* > *[Info](xref:DIS_settings#info)*
- Visual Studio version: *Help* > *About Microsoft Visual Studio*

Situational information:

- DataMiner version: Only useful when you have trouble with interacting with DataMiner (publishing, DIS Inject, ...)

## Visual Studio Output Logging

In Visual Studio go to the *View* menu, in there you'll find the *Output* item. This will open the [Output window of Visual Studio](https://learn.microsoft.com/en-us/visualstudio/ide/reference/output-window).
In the dropdown you can see several output panes (e.g.: 'Build', 'Build Order', 'DIS', 'Tests', ...). Some of these come from Visual Studio, the others from extensions you have installed.

DIS has also several of them:

- *DIS*
- *DIS - Validator*
- *DIS - Plugins*
- ...

This list can always expand in the future, but the format stays the same: *DIS - {topic}*. Not all of them are visible at first as they only appear when there is any logging for them.

> [!IMPORTANT]
> Make sure to copy paste the contents of those output panes as if e.g. exceptions occur, the stack trace can be quite long and with a screenshot this is not visible then.
> The easiest way is to copy paste them in a text file and mention in the filename the name of the output pane. This way we know where the issue occurred which helps us point in the right direction.

## Visual Studio Solution

When for example an issue occurs whilst publishing or running the validator, generally it's something within the solution that is causing issues.
Having access to the solution, makes debugging the problem a lot easier.
