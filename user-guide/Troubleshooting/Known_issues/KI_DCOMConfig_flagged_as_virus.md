---
uid: KI_DCOMConfig_flagged_as_virus
---

# DCOMConfig flagged as virus causing upgrade issues

## Affected versions

- Feature Release versions from DataMiner 10.5.5 onwards.
- Main Release versions from DataMiner 10.4.0 [CU14]/10.5.0 [CU2] onwards.

Note that it is possible for the issue to occur in earlier DataMiner versions as well, but this is considerably less likely.

## Cause

DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 includes an improvement to the file `C:\Skyline DataMiner\tools\DcomConfig.exe`. For some reason, this change can cause some antivirus software to flag this file as a virus and remove it from the system. This causes DataMiner upgrades to fail.

## Fix

Install DataMiner 10.4.0 [CU16], 10.5.0 [CU4], or 10.5.7.<!-- RN 42979 -->

## Workaround

Add the folder `C:\Skyline DataMiner\` to the exclusions of the antivirus software, and run the upgrade again.

## Issue description

Upgrading DataMiner fails, with the following lines in the logging:

```txt
notice|Executing 'dcomConfig.exe' failed: Not found in upgrades, tools, files or windows system dir
step|Executing on-failure steps due to failure...
error|Upgrade failed: Execute failed: Not found in upgrades, tools, files or windows system dir
```
