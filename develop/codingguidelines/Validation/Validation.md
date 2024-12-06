---
uid: ConnectorBestPracticesValidation
---

# Validation

## General

- Verify that parameter get and set operations succeed. Verify that each configurable parameter of the device is set correctly.

  Try to verify the parameter value using the web interface of the device or another tool. If this is not possible, try to verify the format of these settings using Stream Viewer for a locally created element.

- In order to verify the communication with the device, you must verify displayed parameters that are not initialized. Parameters should not have exceptions by default to avoid being not initialized.

- No errors or issues must occur when the device is not reachable and communication should still be initiated.

## Spelling

The [Visual Studio spell checker](xref:Visual_Studio_spell_checker) must be used to verify that the protocol is using US spelling, and all valid errors should be fixed.

## DIS validator

The [DIS validator](xref:Overall_concept_of_the_DataMiner_Integration_Studio) needs to be executed, and all notifications must be handled.

## Stream Viewer

No problems may be indicated in Stream Viewer.

## Log files

The element log file or other log files do not contain problems related to an element running the implemented protocol.

## Alarm Console

The [Alarm Console](xref:Working_with_the_Alarm_Console) does not indicate any problems related to an element running the implemented protocol.
