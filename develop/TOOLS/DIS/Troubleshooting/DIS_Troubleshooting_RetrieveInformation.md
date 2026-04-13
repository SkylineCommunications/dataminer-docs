---
uid: DIS_Troubleshooting_RetrieveInformation
keywords: dis logging
---

# Retrieving information in case a problem occurs

When you encounter an issue with DIS, you should gather as much information as needed so that the DIS team can efficiently debug and figure out what is going wrong.

To investigate the issue, they will need [basic information](#basic-information), [Visual Studio output logging](#visual-studio-output-logging), and the relevant [Visual Studio solution](#visual-studio-solution).

## Basic information

- DIS version: *Extensions* > *DIS* > *Settings* > *[Info](xref:DIS_settings#info)*

- Visual Studio version: *Help* > *About Microsoft Visual Studio*

- DataMiner version: Only useful when you have trouble interacting with DataMiner (publishing, DIS Inject, etc.). In DataMiner Cube, you can find this by clicking the user icon and selecting *About*.

## Visual Studio output logging

1. In Visual Studio, go to the *View* menu.

1. Select the *Output* item.

   This will open the [Output window of Visual Studio](https://learn.microsoft.com/en-us/visualstudio/ide/reference/output-window).

1. In the dropdown box, select the relevant DIS items and copy the logging.

   You can select several output panes in the dropdown box (e.g., *Build*, *Build Order*, *DIS*, *Tests*, etc.). Some of these come from Visual Studio, the others from extensions you have installed. Not all of these may be shown, as they only appear when there is any logging for them. Several items can be selected for DIS:

   - *DIS*

   - *DIS - Validator*

   - *DIS - Plugins*

   - ...

   This list may expand in the future, but the format stays the same: *DIS - {topic}*.

> [!IMPORTANT]
> Make sure to copy/paste the complete contents of the output panes, because if e.g., exceptions occur, the stack trace can be quite long, and with a screenshot not everything will be visible. We recommend copying the content to a text file with the same name as the output pane. This way, it will be clear for the DIS team where the issue occurred, which will help point their investigation in the right direction.

## Visual Studio Solution

When for example an issue occurs while publishing or running the validator, generally something within the solution is causing the issue.

Make sure to include the solution in the information you provide to the DIS team, as this will make debugging the problem a lot easier.
