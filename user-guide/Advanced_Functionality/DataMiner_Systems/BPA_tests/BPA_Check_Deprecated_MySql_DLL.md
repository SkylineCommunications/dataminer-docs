---
uid: BPA_Check_Deprecated_DLL_Usage
---

# Check Deprecated DLL Usage

Previously known as ***Check Deprecated MySQL DLL*** from DataMiner 10.4.6/10.5.0 up to (but not including) 10.5.4/10.6.0, this BPA checks for the use of deprecated or outdated DLLs in QActions and automation scripts.
You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab).

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39370-->, the *MySql.Data.dll* file, located in the *C:\Skyline DataMiner\ProtocolScripts* folder, is considered deprecated and is no longer included in DataMiner upgrade packages.  
From DataMiner 10.5.4/10.6.0 onwards<!--RN 42057-->, the *SLDatabase.dll* file, located in the *C:\Skyline DataMiner\ProtocolScripts* or *C:\Skyline DataMiner\Files* folder is considered deprecated and should no longer be used by QActions or automation scripts. 

## Overview

Below is an overview of the DLL deprecations, including the DataMiner version in which deprecation begins and the minimum "safe" version, if applicable.
Any version lower than the specified minimum will be considered outdated, as older versions are known to pose security risks.

| Deprecated DLL       | Dataminer Version    | Minimum Safe Version |
|----------------------|----------------------|----------------------|
| MySql.Data.dll       | 10.4.6/10.5.0        | 8.0.0.0              |
| SLDatabase.dll       | 10.5.4/10.6.0        | N/A                  |

If an [outdated DLL file is detected](#error) on your DMA, this indicates the use of an old file version, which may pose a potential security risk. In this event, always remove the DLL file.

If a [deprecated DLL file is detected](#warning) on your DMA, the file version is still up to date. However, we recommend removing the DLL file to avoid potential future problems.

## Metadata

- Name: Check Deprecated DLL Usage
- Description: Checks if any protocols and Automation scripts use deprecated DLLs (MySql.Data.dll or SLDatabase.dll)
- Author: Skyline Communications
- Default schedule: Every 7 days

## Results

### Success

Result message: `No issues detected.`

### Error

The outdated DLL file was detected.

- Result message: `Outdated X.dll (version x.x.x.x) at Y detected.`

- Impact: The outdated *X.dll* file could pose a security risk, potentially exposing vulnerabilities in the system. It could also lead to problems in future DataMiner versions, as an upgrade may remove the DLL file.

- Corrective action:

  1. Stop the DataMiner Agent.

  1. Remove the *X.dll* file from the *Y* folder.

     > [!IMPORTANT]
     > When you remove the *X.dll* file, we strongly recommend keeping a temporary copy and checking the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *X.dll* file when a QAction or an Automation script was executed.

  1. Start the DataMiner Agent.

One or multiple protocols and/or Automation scripts still use the outdated DLL file.

- Result message: `Outdated X.dll (version x.x.x.x) detected, along with the use of the deprecated Y.dll`

- Impact: The outdated *X.dll* file could pose a security risk, potentially exposing vulnerabilities in the system. It may also cause future DataMiner upgrades to fail when the BPA test detects that the DLL file is still in use.

- Corrective action:

  1. Click the ellipsis button ("...") next to the error message to access an overview of all protocols and Automation scripts that still use the deprecated DLL file.

     This overview contains the names and versions of the protocols that use the file, including the IDs and QActions in which this file is referenced, as well as the names of the Automation scripts that use the file.

     Example:

     ```JSON
      {
         "Protocols": [
            {
               "Protocol": "Generic Network Services Monitor/1.0.0.11",
               "QActions": [
               {
                  "Id": "3",
                  "Deprecated DLLs": [
                     "MySql.Data.dll"
                  ]
               }
               ]
            },
            {
               "Protocol": "iDirect Platform/10.0.1.60",
               "QActions": [
               {
                  "Id": "1",
                  "Deprecated DLLs": [
                     "SLDatabase.dll",
                     "MySql.Data.dll"
                  ]
               },
               {
                  "Id": "2",
                  "Deprecated DLLs": [
                     "SLDatabase.dll"
                  ]
               }
               ]
            }
         ],
         "AutomationScripts": [
            {
               "Name": "DeprecatedDllScript",
               "Deprecated DLLs": [
               "SLDatabase.dll",
               "MySql.Data.dll"
               ]
            },
            {
               "Name": "CheckDatabaseConfiguration",
               "Deprecated DLLs": [
               "MySql.Data.dll"
               ]
            }
         ]
      }
      ```

  1. Replace every reference to a deprecated DLL with a NuGet, see [Replacing Deprecated DLLs with NuGet Packages](#replacing-deprecated-dlls-with-nuget-packages).

  1. Stop the DataMiner Agent.

  1. Remove the outdated DLL file from their folder (mentioned in the result message).

     > [!IMPORTANT]
     > When you remove a DLL file, we strongly recommend keeping a temporary copy and checking the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *X.dll* file when a QAction or an Automation script was executed.

  1. Start the DataMiner Agent.

### Warning

The deprecated DLL file was detected in the ProtocolScripts folder.

- Result message: `Deprecated X.dll at Y detected.`

- Impact: The deprecated *X.dll* file could lead to problems in future DataMiner versions, as an upgrade may remove the DLL file.

- Corrective action:

  1. Stop the DataMiner Agent.

  1. Remove the *X.dll* file from the *C:\Skyline DataMiner\ProtocolScripts* folder.

     > [!IMPORTANT]
     > When you remove the *X.dll* file, we strongly recommend keeping a temporary copy and checking the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *X.dll* file when a QAction or an Automation script was executed.

  1. Start the DataMiner Agent.

One or multiple protocols and/or Automation scripts still use the deprecated DLL file.

- Result message: `Deprecated X.dll used.`

- Impact: The deprecated *X.dll* file could lead to problems in future DataMiner versions, as DataMiner upgrades may fail when the BPA test detects that the DLL file is still in use.

- Corrective action:

  1. Click the ellipsis button ("...") next to the error message to access an overview of all protocols and Automation scripts that still use the deprecated DLL file.

     This overview contains the names and versions of the protocols that use the file, including the IDs and QActions in which this file is referenced, as well as the names of the Automation scripts that use the file.

     Example:

     ```JSON
      {
         "Protocols": [
            {
               "Protocol": "Generic Network Services Monitor/1.0.0.11",
               "QActions": [
               {
                  "Id": "3",
                  "Deprecated DLLs": [
                     "MySql.Data.dll"
                  ]
               }
               ]
            },
            {
               "Protocol": "iDirect Platform/10.0.1.60",
               "QActions": [
               {
                  "Id": "1",
                  "Deprecated DLLs": [
                     "SLDatabase.dll",
                     "MySql.Data.dll"
                  ]
               },
               {
                  "Id": "2",
                  "Deprecated DLLs": [
                     "SLDatabase.dll"
                  ]
               }
               ]
            }
         ],
         "AutomationScripts": [
            {
               "Name": "DeprecatedDllScript",
               "Deprecated DLLs": [
               "SLDatabase.dll",
               "MySql.Data.dll"
               ]
            },
            {
               "Name": "CheckDatabaseConfiguration",
               "Deprecated DLLs": [
               "MySql.Data.dll"
               ]
            }
         ]
      }
      ```

  1. Replace every reference to a deprecated DLL with a NuGet, see [Replacing Deprecated DLLs with NuGet Packages](#replacing-deprecated-dlls-with-nuget-packages).

### Not Executed

`Could not execute test due to {ExceptionMessage}`

Click the ellipsis ("...") next to the result message to access more information about the exception.

## Limitations

The BPA test can only detect whether the *X.dll* file is referenced directly. For example, if a QAction contains a reference to a particular DLL that references the *X.dll* file, the BPA is not able to detect this.

## Replacing Deprecated DLLs with NuGet Packages

### MySql.Data.dll
The *MySql.Data.dll* can be replaced by the [MySql.Data Nuget](https://www.nuget.org/packages/MySql.Data).
This NuGet should be a drop-in replacement as it exposes the same namespace and functions.

### SLDatabase.dll
Depending on the database that SLDatabase was used to communicate with a different NuGet package is necessary.
The QAction or automation script will need to be adapted as each NuGet exposes different functions and ways to interact with a database.

The following list of NuGet packages can be a good start for replacing the SLDatabase.dll:
- [Cassandra](https://www.nuget.org/packages/cassandracsharpdriver/)
- [MS SQL](https://www.nuget.org/packages/microsoft.data.sqlclient)
- [MySQL](https://www.nuget.org/packages/MySql.Data)
- [ODBC](https://www.nuget.org/packages/System.Data.Odbc/)
- [Oracle](https://www.nuget.org/packages/Oracle.ManagedDataAccess)