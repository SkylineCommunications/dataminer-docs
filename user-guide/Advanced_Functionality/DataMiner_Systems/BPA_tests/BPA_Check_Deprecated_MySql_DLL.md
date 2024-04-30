---
uid: BPA_Check_Deprecated_MySql_DLL
---

# Check Deprecated MySql DLL

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39370-->, the *MySql.Data.dll* file, located in the *C:\Skyline DataMiner\ProtocolScripts* folder, is considered deprecated and is no longer included in DataMiner upgrade packages.

From DataMiner 10.4.6/10.5.0 onwards<!--RN 39370-->, you can run this BPA test to scan the DataMiner Agent for protocols and Automation scripts that still use this deprecated DLL file. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab).

> [!IMPORTANT]
> The BPA test *Check Deprecated MySql DLL* is only able to detect whether the *MySql.Data.dll* file is referenced directly. For example, if a QAction would contain a reference to a particular DLL that references the *MySql.Data.dll* file, the BPA will not be able to detect this.

## Metadata

- Name: Check Deprecated MySql DLL
- Description: Checks if any protocols and Automation scripts use the deprecated *MySql.Data.dll* file
- Author: Skyline Communications
- Default schedule: Every 7 days

## Results

### Success

Result message:

### Error

Result message: Outdated MySQL.Data.dll with version 1.0.10.1 detected in ProtocolScripts folder.

### Warning

### Not Executed

## Impact when issues detected

- Impact:

- Corrective action:

  1. Replace every reference to the *MySql.Data.dll* file in the listed protocols and Automation scripts with a reference to the [MySql.Data Nuget](https://www.nuget.org/packages/MySql.Data).

     > [!NOTE]
     > To access an overview of all protocols and Automation scripts that are using the deprecated DLL file, click the ellipsis button ("...") next to the error message. This overview contains the names and versions of the protocols that use the file, including the IDs and QActions in which this file is referenced, and the names of the Automation scripts that use the file.

  1. Stop the DataMiner Agent.

  1. Remove the *MySql.Data.dll* file from the *C:\Skyline DataMiner\ProtocolScripts* folder.

     > [!IMPORTANT]
     > When you remove the *MySql.Data.dll* file, we strongly recommend keeping a temporary copy and to check the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *MySql.Data.dll* file when a QAction or an Automation script was executed.

  1. Start the DataMiner Agent.
