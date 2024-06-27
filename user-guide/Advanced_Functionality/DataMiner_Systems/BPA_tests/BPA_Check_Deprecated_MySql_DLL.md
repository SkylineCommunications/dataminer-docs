---
uid: BPA_Check_Deprecated_MySql_DLL
---

# Check Deprecated MySql DLL

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39370-->, the *MySql.Data.dll* file, located in the *C:\Skyline DataMiner\ProtocolScripts* folder, is considered deprecated and is no longer included in DataMiner upgrade packages.

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39370-->, you can run this BPA test to scan the DataMiner Agent for protocols and Automation scripts that still use this deprecated DLL file. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab).

If an [outdated *MySql.Data.dll* file is detected](#error) on your DMA, this indicates the use of an old file version, which may pose a potential security risk. In this event, always remove the DLL file.

If a [deprecated *MySql.Data.dll* file is detected](#warning) on your DMA, the file version is still up to date. However, we recommend removing the DLL file to avoid potential future problems.

## Metadata

- Name: Check Deprecated MySql DLL
- Description: Checks if any protocols and Automation scripts use the *MySql.Data.dll* file
- Author: Skyline Communications
- Default schedule: Every 7 days

## Results

### Success

Result message: `No issues detected.`

### Error

The outdated DLL file was detected in the ProtocolScripts folder.

- Result message: `Outdated MySql.Data.dll with version x.x.x.x detected in ProtocolScripts folder.`

- Impact: The outdated *MySql.Data.dll* file could pose a security risk, potentially exposing vulnerabilities in the system. It could also lead to problems in future DataMiner versions, as an upgrade may remove the DLL file.

- Corrective action:

  1. Stop the DataMiner Agent.

  1. Remove the *MySql.Data.dll* file from the *C:\Skyline DataMiner\ProtocolScripts* folder.

     > [!IMPORTANT]
     > When you remove the *MySql.Data.dll* file, we strongly recommend keeping a temporary copy and checking the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *MySql.Data.dll* file when a QAction or an Automation script was executed.

  1. Start the DataMiner Agent.

One or multiple protocols and/or Automation scripts still use the outdated DLL file.

- Result message: `Outdated MySql.Data.dll with version x.x.x.x in the ProtocolScripts folder is being used.`

- Impact: The outdated *MySql.Data.dll* file could pose a security risk, potentially exposing vulnerabilities in the system. It may also cause future DataMiner upgrades to fail when the BPA test detects that the DLL file is still in use.

- Corrective action:

  1. Click the ellipsis button ("...") next to the error message to access an overview of all protocols and Automation scripts that still use the deprecated DLL file.

     This overview contains the names and versions of the protocols that use the file, including the IDs and QActions in which this file is referenced, as well as the names of the Automation scripts that use the file.

     Example:

     ```JSON
     {"Protocols": [{"Protocol":"Generic Network Services Monitor/1.0.0.11","QActions":["3"]},{"Protocol":"iDirect Platform/10.0.1.60","QActions":["1","2"]},{"Protocol":"QA_SNMP_Trap/1.0.0.6","QActions":["2","3","4"]},{"Protocol":"Skyline Driver Passport Platform/1.0.1.4","QActions":["1"]},{"Protocol":"Skyline Driver Passport Platform/1.0.1.7","QActions":["1"]},{"Protocol":"Skyline Driver Passport Platform/1.0.1.9","QActions":["1"]},{"Protocol":"Skyline Driver Passport Platform Invest/1.0.1.3","QActions":["1"]}], "AutomationScripts": ["RT_SNMP_Trap_DuplicatedAlarms_RN13682"]}
     ```

  1. Replace every reference to the *MySql.Data.dll* file in the listed protocols and Automation scripts with a reference to the [MySql.Data Nuget](https://www.nuget.org/packages/MySql.Data).

  1. Stop the DataMiner Agent.

  1. Remove the *MySql.Data.dll* file from the *C:\Skyline DataMiner\ProtocolScripts* folder.

     > [!IMPORTANT]
     > When you remove the *MySql.Data.dll* file, we strongly recommend keeping a temporary copy and checking the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *MySql.Data.dll* file when a QAction or an Automation script was executed.

  1. Start the DataMiner Agent.

### Warning

The deprecated DLL file was detected in the ProtocolScripts folder.

- Result message: `Deprecated MySql.Data.dll detected in ProtocolScripts folder.`

- Impact: The deprecated *MySql.Data.dll* file could lead to problems in future DataMiner versions, as an upgrade may remove the DLL file.

- Corrective action:

  1. Stop the DataMiner Agent.

  1. Remove the *MySql.Data.dll* file from the *C:\Skyline DataMiner\ProtocolScripts* folder.

     > [!IMPORTANT]
     > When you remove the *MySql.Data.dll* file, we strongly recommend keeping a temporary copy and checking the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *MySql.Data.dll* file when a QAction or an Automation script was executed.

  1. Start the DataMiner Agent.

One or multiple protocols and/or Automation scripts still use the deprecated DLL file.

- Result message: `Deprecated MySql.Data.dll in the ProtocolScripts folder is being used.`

- Impact: The deprecated *MySql.Data.dll* file could lead to problems in future DataMiner versions, as DataMiner upgrades may fail when the BPA test detects that the DLL file is still in use.

- Corrective action:

  1. Click the ellipsis button ("...") next to the error message to access an overview of all protocols and Automation scripts that still use the deprecated DLL file.

     This overview contains the names and versions of the protocols that use the file, including the IDs and QActions in which this file is referenced, as well as the names of the Automation scripts that use the file.

     Example:

     ```JSON
     {"Protocols": [{"Protocol":"Generic Network Services Monitor/1.0.0.11","QActions":["3"]},{"Protocol":"iDirect Platform/10.0.1.60","QActions":["1","2"]},{"Protocol":"QA_SNMP_Trap/1.0.0.6","QActions":["2","3","4"]},{"Protocol":"Skyline Driver Passport Platform/1.0.1.4","QActions":["1"]},{"Protocol":"Skyline Driver Passport Platform/1.0.1.7","QActions":["1"]},{"Protocol":"Skyline Driver Passport Platform/1.0.1.9","QActions":["1"]},{"Protocol":"Skyline Driver Passport Platform Invest/1.0.1.3","QActions":["1"]}], "AutomationScripts": ["RT_SNMP_Trap_DuplicatedAlarms_RN13682"]}
     ```

  1. Replace every reference to the *MySql.Data.dll* file in the listed protocols and Automation scripts with a reference to the [MySql.Data Nuget](https://www.nuget.org/packages/MySql.Data).

  1. Stop the DataMiner Agent.

  1. Remove the *MySql.Data.dll* file from the *C:\Skyline DataMiner\ProtocolScripts* folder.

     > [!IMPORTANT]
     > When you remove the *MySql.Data.dll* file, we strongly recommend keeping a temporary copy and checking the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *MySql.Data.dll* file when a QAction or an Automation script was executed.

  1. Start the DataMiner Agent.

### Not Executed

`Could not execute test due to {ExceptionMessage}`

Click the ellipsis ("...") next to the result message to access more information about the exception.

## Limitations

The BPA test can only detect whether the *MySql.Data.dll* file is referenced directly. For example, if a QAction contains a reference to a particular DLL that references the *MySql.Data.dll* file, the BPA is not able to detect this.
