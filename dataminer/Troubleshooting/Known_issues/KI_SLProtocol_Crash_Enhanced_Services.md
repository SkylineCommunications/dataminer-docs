---
uid: KI_SLProtocol_Crash_Enhanced_Services
---

# SLProtocol crashes when enhanced service protocol is missing table 100

## Affected versions

- All DataMiner versions

## Cause

The enhanced service alarm monitoring feature is not completely disabled when the enhanced service protocol is missing table 100. This can lead to access violations when alarm monitoring is enabled (PID 198) and elements are restarted.

## Fix

No fix is available yet. <!--Task ID: 252936-->

## Workaround

1. Stop the DataMiner Agent.

1. Run *Change Element States Offline.exe* as Administrator.

   This tool is available on the DMA in the folder `C:\Skyline DataMiner\Tools` or `C:\Skyline DataMiner\Tools\Change Element States Offline`, depending on the DataMiner version. For more information , see [Change Element States Offline](xref:Change_Element_States_Offline).

1. Go to the *Elements by Protocol* tab.

1. Select all protocols.

   > [!CAUTION]
   > Older versions of this tool may also include **service protocols** in this list. These should **never be stopped** and should therefore be excluded from the mentioned selection. Service protocols have the type *service* in their *protocol.xml*.

1. In the *Desired state for selected elements* dropdown box, select *Stopped*.

1. Click the *SET STATE* button.

1. Start the DataMiner Agent.

1. In each enhanced service, set PID 198 to *disabled*, *0*, or *false* (depending on the protocol).

   > [!NOTE]
   > The name and location of this parameter can differ between protocols. Check the *protocol.xml* file to find the name, values, and location.

1. Start the elements.

## Issue description

In a DataMiner System where one or more enhanced service protocols are used with alarm monitoring, when an element is restarted, SLProtocol can stop functioning correctly. Depending on the DataMiner version, this can cause DataMiner to restart unexpectedly, or it can cause all elements hosted by the relevant SLProtocol process to be in error.
