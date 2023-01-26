---
uid: Installing_a_DMA_FAQ
---

# Frequently asked questions

Questions in this section:

- [How can I manually create the MySQL database?](#how-can-i-manually-create-the-mysql-database)
- [How can I boot the computer without a keyboard?](#how-can-i-boot-the-computer-without-a-keyboard)
- [What do I do if I get the HTTP error 401.3 when trying to browse to the DMA?](#what-do-i-do-if-i-get-the-http-error-4013-when-trying-to-browse-to-the-dma)
- [What do I do if get HTTP error 500.19?](#what-do-i-do-if-get-http-error-50019)
- [What do I do if ASPX pages show text instead of web content?](#what-do-i-do-if-aspx-pages-show-text-instead-of-web-content)
- [What do I do when I get a Dashboards error saying that the directory name is not valid?](#what-do-i-do-when-i-get-a-dashboards-error-saying-that-the-directory-name-is-not-valid)
- [What do I do if I have backup problems on a 64-bit OS?](#what-do-i-do-if-i-have-backup-problems-on-a-64-bit-os)
- [How do I configure IIS 6 on a 64-bit system?](#how-do-i-configure-iis-6-on-a-64-bit-system)
- [What do I do if there is an error when the MySQL service is started?](#what-do-i-do-if-there-is-an-error-when-the-mysql-service-is-started)
- [What do I do if I get a 'Trust not granted' error when opening Cube?](#what-do-i-do-if-i-get-a-trust-not-granted-error-when-opening-cube)
- [What do I do if I get an 'unauthorized access exception' after saving annotations?](#what-do-i-do-if-i-get-an-unauthorized-access-exception-after-saving-annotations)
- [How do I manually configure Windows Firewall?](#how-do-i-manually-configure-windows-firewall)
- [How do I manually configure DCOM?](#how-do-i-manually-configure-dcom)

## How can I manually create the MySQL database?

1. Go to *Start > All Programs > MySQL > MySQL Workbench*.
1. In the *SQL Development* section, double-click the "localhost" connection to open SQL Editor.
1. Optionally, drop the test database. To do so, right-click the "test" schema in the *Object Browser*, and select *Drop Schema*.
1. Right-click anywhere in the *Object Browser*, and select *Create New Schema*.
1. In the *new_schema* dialog box, set *Name* to "SLDMADB", and click *Apply*.
1. Close SQL Editor.

## How can I boot the computer without a keyboard?

Depending on the hardware, you may need to allow the computer to be started without a keyboard connected.

To do so, when the computer is booting:

1. Enter the BIOS settings, e.g. by pressing *DELETE*.
1. Select *Boot Settings > Boot Settings Configuration*.
1. Set *Halt On* to "All, but Disk/Key".

## What do I do if I get the HTTP error 401.3 when trying to browse to the DMA?

When you get an HTTP error 401.3 ("Unauthorized") when trying to browse to any web page of the DataMiner Agent in question, verify the security settings of the Skyline DataMiner directory that you copied.

1. In *File Explorer*, go to the *C:\Skyline DataMiner* directory.
1. Right-click the directory, and click *Security*.
1. Make sure that the *Users* group has been added, and has "Read" rights.

> [!TIP]
> See also [How do I manually configure DCOM?](#how-do-i-manually-configure-dcom)

## What do I do if get HTTP error 500.19?

When you get an HTTP error 500.19 ("Internal Server Error"), set the default application pool to .NET Framework Version v2.0.

1. Choose *Start > Administrative Tools > Internet Information Services (IIS) Manager*.
1. In the *Connections* section, expand the server, and click *Application Pools*.
1. Set *DefaultAppPool* to ".NET Framework Version v2.0".

## What do I do if ASPX pages show text instead of web content?

This could be the case if IIS was installed after the .NET framework. If these two components were not installed in the right order, then proceed as follows:

1. Select *Start > Run*.
1. In the *Open* text box, type `cmd` and press *ENTER*.
1. At the command prompt, type the following command, and then press *ENTER*:

   ```txt
   %windir%\Microsoft.NET\Framework\1.1.4322\aspnet_regiis.exe -i
   ```

   > [!NOTE]
   > In this path, "1.1.4322" represents the version number of the .NET Framework that you installed on your server.

For more information, see <http://support.microsoft.com/kb/306005/>.

## What do I do when I get a Dashboards error saying that the directory name is not valid?

In some cases, the following Dashboards error may appear:

```txt
CS001X: COULD NOT WRITE TO OUTPUT FILE fC:\...\TEMPORARY ASP.NET FILES\...f.
THE DIRECTORY NAME IS INVALID.
```

If so, do the following:

1. Check if a *C:\Windows\temp* directory exists. If it does not, create it.
1. For this directory, grant full permissions to the ASPNET or NETWORK SERVICE user accounts.
1. Right-click *My Computer*, and click *Properties*.
1. On the *Advanced* tab, click *Environment Variables*.
1. Select the TEMP system variable, and click *Edit*.
1. Type "C:\Windows\TEMP" in the *Variable Value* box, and click *OK*.
1. Repeat steps 5 and 6 to edit the TMP variable. Click *OK* twice.
1. Select *Start > Run*.
1. At the command prompt, type "iisreset" to reset Internet Information Services (IIS).

> [!NOTE]
> If the error message persists, restart the computer.

For more information, see <http://support.microsoft.com/kb/825791>.

## What do I do if I have backup problems on a 64-bit OS?

### Problem with NTBackup

On 64-bit systems, a DataMiner backup procedure can fail with the following message:

```txt
Backup job had errors!! Backup-process failed. The system cannot find the file specified.(2)
```

This error is caused by SLDMS being unable to start or locate the ntbackup process.

To solve this problem, proceed as follows:

- Copy the *ntbackup.exe* file from the *C:\WINDOWS\system32* directory of a 32-bit system to the *C:\Skyline DataMiner\Files* directory of the 64-bit system.

### Problem with DataMiner database dump

On 64-bit systems, a DataMiner backup procedure can fail the moment a database dump has to be performed.

This error is caused by SLDMS being unable to start or locate *mysqldump.exe*.

To solve this problem, proceed as follows:

- Create a dummy *C:\MySQL\bin* directory containing the *mysqldump.exe* file.

## How do I configure IIS 6 on a 64-bit system?

### Problems with an incorrect IIS configuration

When IIS is incorrectly configured, the following problems may occur:

- When browsing to the DMA:

    ```txt
    Service Unavailable
    ```

- Errors coming from W3SVC-WP in the event viewer of the DMA:

    ```txt
    Id 2268: Could not load all ISAPI filters for site/service. Therefore startup aborted.
    Id 2274: C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_filter.dll could not be loaded due to a configuration problem [...]
    Id 1062: It is not possible to run different versions of ASP.NET in the same IIS process. Please use the IIS Administration tool to reconfigure you server to run the application in a separate process.
    ```

- When browsing to ASP.NET applications (Dashboards):

    ```txt
    404 (Not Found)
    403 (Forbidden)
    ```

To avoid these problems, first of all make sure that the following programs/frameworks are installed:

- IIS
- .NET Framework 3.5

If they are, make sure IIS has been correctly configured. See [Correctly configuring IIS 6](#correctly-configuring-iis-6).

### Correctly configuring IIS 6

To correctly configure IIS, on top of the standard DataMiner Agent installation, do the following:

1. Open a command prompt window, by going to *Start > Run* and entering `cmd`.

   > [!NOTE]
   > It is advisable to run *cmd.exe* as an Administrator.

1. Type the following command, and then press *ENTER*:

   ```txt
   Cscript %SYSTEMDRIVE%\inetpub\adminscripts\adsutil.vbs
   SET W3SVC/AppPools/Enable32bitAppOnWin64 1
   ```

1. Type the following command, and then press *ENTER*:

   ```txt
   %SYSTEMROOT%\Microsoft.NET\Framework\v1.1.4322\aspnet_regiis.exe -i
   ```

1. Type the following command, and then press *ENTER*:

   ```txt
   %SYSTEMROOT%\Microsoft.NET\Framework\v2.0.50727\aspnet_regiis.exe -i
   ```

1. Open IIS Manager.

1. In the Web Service Extensions list (see left tree pane), set the following extensions to "Allowed":

   - ASP.NET version 1.1.4322
   - ASP.NET version 2.0.50727
   - Active Server Pages

1. In *File Explorer*, execute `C:\Skyline DataMiner\Tools\ConfigureIIs.js`. When the execution is ready, a message box will appear.

1. In the left pane of the IIS Manager, open the website and verify that the Dashboards item is an application (cogwheel icon).

   If it is not, proceed as follows:

   1. Right-click > *Properties*
   1. Click *Create Application*.
   1. On the *Documents* tab, make sure that the default document is "default.aspx".
   1. On the *Directory Security* tab, click *Edit* (next to *Authentication and access control*), and make sure that "Integrated Windows Authentication" is selected.

1. Restart IIS:

   - In the left pane, right-click COMPUTERNAME and select *All Tasks > Restart IIS*.
   - Alternatively, you can run the `iisreset` command from a command prompt.

## What do I do if there is an error when the MySQL service is started?

After installing MySQL, the following error may occur when the MySQL service attempts to start:

```txt
MySQL service cannot start (event viewer error message: Default storage engine <InnoDB> is not available)
```

To resolve this issue, proceed as follows:

1. Go to the MySQL Server installation directory:

   - On an x86 machine: *C:\Program Files\MySQL\MySQL Server x.x\Data*
   - On an x64 machine: *C:\Program Files(86)\MySQL\MySQL Server x.x\Data*

1. Remove the following files:

   - ib_logfile0
   - ib_logfile1
   - ibdata1

1. Start the MySQL service manually.

For more information, see <http://forums.mysql.com/read.php?22,58270,122989#msg-122989>.

## What do I do if I get a 'Trust not granted' error when opening Cube?

Install the necessary certificates.

For more information, see <http://[DMA]/tools/>.

## What do I do if I get an 'unauthorized access exception' after saving annotations?

On Windows 7, the following error may occur after saving annotations:

```txt
SYSTEM.UNAUTHORIZEDACCESSEXCEPTION: RETRIEVING THE COM CLASS FACTORY FOR COMPONENT WITH CLSID...
```

This is because the IIS_IUSRS group has not been granted "Local Activation" permission on SLDMS.

> [!TIP]
> See also: [How do I manually configure DCOM?](#how-do-i-manually-configure-dcom)

## How do I manually configure Windows Firewall?

Normally, Windows Firewall is configured automatically when you install DataMiner. However, if you want to configure it manually, do the following:

1. Go to *Start > Control Panel > System and Security > Windows Defender Firewall*.

1. Click *Advanced Settings*.

1. On the *Inbound Rules* tab page, the following ports will need to be added:

   |Name | Port number | Protocol |
   |-----| ----------- | -------- |
   | HTTP Port | 80 | TCP |
   | HTTPS Port | 443 | TCP |
   | NATS Ports | 4222<br>6222 | TCP |
   | SLNet Remoting Port | 8004 | TCP |
   | NAS Port | 9090 | TCP |

   To do so, for each of the ports, do the following:

   1. Click *New rule*.
   1. In the wizard, select *Port* and click *Next*.
   1. Select whether the rule applies to *TCP* or *UDP*, add the port and click *Next*.
   1. Make sure *Allow the connection* is selected and click *Next* until you reach the last step of the wizard.
   1. Enter the name of the rule, as specified in the table above, and click *Finish*.

If the computer will be polled by a DataMiner element running the Microsoft Platform protocol driver, the following three additional steps have to be executed:

1. Select *Start > Run*.

1. In the *Open* text box, type `netsh firewall set service RemoteAdmin`, and press *ENTER*.

   A message box will appear, notifying you that the firewall changes have successfully been applied.

1. Exit the command prompt window.

## How do I manually configure DCOM?

Normally, DCOM is configured automatically when you install DataMiner. However, if you want to configure it manually, do the following:

1. Select *Start > Run*.

1. Enter `dcomcnfg`, and click *OK*.

1. Double-click *Component Services*, and then double-click *Computers* to expand the *Component Services* tree.

1. Double-click *My Computer* and *DCOM Config* to expand the *Component Services* tree.

1. In the *Component Services* tree, right-click *SLASPConnection*, and click *Properties*.

1. Click the *Security* tab.

1. In the *Launch and Activations Permissions* pane, click *Customize*, and then click *Edit*.

1. Grant an additional permission to the following accounts:

   | Account | Additional permission |
   |---------|---------|
   | \[ComputerName\]IUSR_\[ComputerName\] | Allow Local Activation |
   | \[ComputerName\]Users | Allow Local Activation |

   If these accounts are not listed even though they exist, see [Adding an account to the Group or User names list](#adding-an-account-to-the-group-or-user-names-list) for instructions on how to add them to the Group or user names list.

   > [!NOTE]
   > If the above-mentioned accounts do not exist on your system, you do not need to create them.

1. Click *OK* on the open dialog boxes until you are back in the *DCOM Config* node of the *Component Services* tree.

1. In the *Component Services* tree, right-click *SLDMS*, and click *Properties*.

1. Click the *Security* tab.

1. In the *Launch and Activations Permissions* pane, click *Customize*, and then click *Edit*.

1. Grant an additional permission to the following accounts:

   | Account | Additional permission |
   | ------- | --------------------- |
   | \[ComputerName\]ASPNET | Allow Local Activation |
   | \[ComputerName\]Network Service | Allow Local Activation |
   | \[ComputerName\]IIS_WPG | Allow Local Activation |
   | \[ComputerName\]IIS_IUSRS | Allow Local Activation |
   | IIS APPPOOLDefaultAppPool | Allow Local Activation |

   If these accounts are not listed even though they exist, see [Adding an account to the Group or User names list](#adding-an-account-to-the-group-or-user-names-list) for instructions on how to add them to the Group or user names list.

   > [!NOTE]
   > If the above-mentioned accounts do not exist on your system, you do not need to create them.

1. Close the *Component Services* window.

### Adding an account to the Group or User names list

1. On the *Security* tab of the *Launch and Activation Permission* dialog box, click *Add*.
1. In the *Select Users, Computers, or Groups* dialog box, click *Advanced*.
1. In the *Select Users, Computers, or Groups* dialog box, click *Locations*.
1. In the *Locations* dialog box, select "\[ComputerName\]", and click *OK*.
1. Back in the *Select Users, Computers, or Groups* dialog box, click *Find Now*.
1. In the search results, select the required account (e.g. "IUSR_\[ComputerName\]"), and click *OK*.
1. In the *Select Users, Computers, or Groups* dialog box, click *OK*.
