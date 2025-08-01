---
uid: KI_DCOMConfig_flagged_as_virus
---

# DCOMConfig flagged as virus causing upgrade issues

## Affected versions

DataMiner 10.5.5/10.4.0 [CU14]/10.5.0 [CU2]

Note that it is possible for the issue to occur in earlier DataMiner versions as well, but this is considerably less likely.

## Cause

DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 includes an improvement to the file `C:\Skyline DataMiner\tools\DcomConfig.exe`. For some reason, this change can cause some antivirus software to flag this file as a virus and remove it from the system. This causes DataMiner upgrades to fail.

## Fix

Install DataMiner 10.4.0 [CU15], 10.5.0 [CU3], or 10.5.6.<!-- RN 42979 -->

## Workaround

Add the folder `C:\Skyline DataMiner\` to the exclusions of the antivirus software, and run the upgrade again.

## Issue description

Upgrading DataMiner fails, with the following lines in the logging:

```txt
notice|Executing 'dcomConfig.exe' failed: Not found in upgrades, tools, files or windows system dir
step|Executing on-failure steps due to failure...
error|Upgrade failed: Execute failed: Not found in upgrades, tools, files or windows system dir
```
