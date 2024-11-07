---
uid: KI_SLProtocol_Crash_Enhanced_Services
---

# SLProtocol crashes when Enhanced Service protocol is missing table 100

## Affected versions

- All DataMiner versions

## Cause

Enhanced service Alarm monitoring feature is not completely disabled when the enhanced service protocol is missing table 100. Leading to access violations when Alarm Monitoring is enabled (PID 198) and elements are restarted.

## Workaround

- Stop the DataMiner agent
- Run *Change Element States Offline.exe* as Administrator (found in C:\Skyline DataMiner\Tools or C:\Skyline DataMiner\Tools\Change Element States Offline)
- Go to the *Elements by Protocol*-tab
- Select all protocols
    > [!CAUTION]
    > Older versions of this tool may also include Service-protocols in this list, these should never be stopped and thus be excluded from the mentioned selection.
    > Enhanced service protocols have the type *service* in the protocol.xml
- In the *Desired state for selected elements*-dropdown select *Stopped*
- Click the *SET STATE* button
- Start the DataMiner
- On each Enhanced Service, set PID 198 to disabled/0/false
    > [!NOTE]
    > The name and location of this parameter can differ between protocols. Please refer to the protocol.xml for the name, values and location.
- Start the elements
  
## Issue description

Alarm Monitoring feature not properly disabled when parameters are missing from the protocol, leading to access violations.
