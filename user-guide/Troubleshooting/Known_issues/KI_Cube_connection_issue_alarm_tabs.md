---
uid: KI_Cube_connection_issue_alarm_tabs
---

# Cube freezes on 'Connected!' loading screen when no alarm tabs are displayed

## Affected versions

DataMiner versions 10.3.9 and 10.3.10.

## Cause

By default, the [three default alarm tabs](xref:ChangingTheAlarmConsoleLayout#the-three-default-alarm-tabs) are displayed at startup: active alarms, information events, and masked alarms. However, when the Alarm Console settings have been configured to display no tabs in the Alarm Console, a connection issue may occur.

## Workaround

Create a default layout for the Alarm Console:

1. When the *Connected!* loading screen is displayed, click the user icon in the Cube header bar and select *Settings*.

1. On the *Alarm Console* page, navigate to *Configure Alarm Console*.

1. Right-click the *Tab pages* column, and select *Add tab page > Active alarms*.

1. Save your changes by clicking *Apply* in the lower right corner.

1. Reconnect to Cube.

## Fix

Install DataMiner 10.3.11<!--RN 37436-->.

## Description

Upon connecting to a DataMiner Agent, Cube freezes on the *Connected!* loading screen indefinitely.
