---
uid: Installing_a_DMA_FAQ
---

# Frequently asked questions

## How can I manually create the MySQL database?

1. Go to *Start > All Programs > MySQL > MySQL Workbench*.
1. In the *SQL Development* section, double-click the "localhost" connection to open SQL Editor.
1. Optionally, drop the test database. To do so, right-click the "test" schema in the *Object Browser*, and select *Drop Schema*.
1. Right-click anywhere in the *Object Browser*, and select *Create New Schema*.
1. In the *new_schema* dialog box, set *Name* to "SLDMADB", and click *Apply*.
1. Close SQL Editor.

## How can I boot the computer without a keyboard?

Depending on the hardware, you may need to allow the computer to be started without a keyboard connected.

To do so, when the computer is booting:

1. Go to the BIOS, e.g. by pressing *DELETE*.
1. Select *Boot Settings > Boot Settings Configuration*.
1. Set *Halt On* to "All, but Disk/Key".

## What do I do if I get the HTTP error 401.3 when trying to browse to the DMA?

When you get an HTTP error 401.3 ("Unauthorized") when trying to browse to any web page of the DataMiner Agent in question, verify the security settings of the Skyline DataMiner directory that you copied.

1. In File Explorer, go to the *C:\Skyline DataMiner* directory.
1. Right-click the directory, and click *Security*.
1. Make sure that the *Users* group has been added, and has "Read" rights.

> [!TIP]
> See also [How do I manually configure DCOM?](#how-do-i-manually-configure-dcom)

## What do I do if get HTTP error 500.19?

When you get an HTTP error 500.19 ("Internal Server Error"), set the default application pool to .NET Framework Version v2.0.

1. Choose *Start > Administrative Tools > Internet Information Services (IIS) Manager*.
1. In the *Connections* section, expand the server, and click *Application Pools*.
1. Set *DefaultAppPool* to ".NET Framework Version v2.0".

## What do I do if ASPX pages show text instead of web content?

This could be the case if IIS was installed after the .NET framework. If these two components were not installed in the right order, then proceed as follows:

1. Select *Start > Run*.
1. In the *Open* text box, type ``cmd`` and press *ENTER*.
1. At the command prompt, type the following command, and then press *ENTER*:

    ```txt
    %windir%\\Microsoft.NET\\Framework\\1.1.4322\\aspnet_regiis.exe -i
    ```

    > [!NOTE]
    > In this path, 1.1.4322 represents the version number of the .NET Framework that you installed on your server.

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
1. On the *Advanced* tab, click *Environment Variables*.
1. Select the TEMP system variable, and click *Edit*.
1. Type "C:\Windows\TEMP" in the *Variable Value* box, and click *OK*.
1. Repeat steps 5 and 6 to edit the TMP variable. Click *OK* twice.
1. Select *Start > Run*.
1. At the command prompt, type "iisreset" to reset Internet Information Services (IIS).

> [!NOTE]
> If the error message persists, restart the computer.

For more information, see <http://support.microsoft.com/kb/825791>.

## What do I do if I have backup problems on a 64-bit OS?

Problem with NTBackup

On 64-bit systems, a DataMiner backup procedure can fail with the
following message:

::: {width="100%" align="left"}
  ----------------------------------------------------------------------------------------------
  Backup job had errors!! Backup-process failed. The system cannot find the file specified.(2)
  ----------------------------------------------------------------------------------------------
:::

This error is caused by SLDMS being unable to start or locate the
ntbackup process.

To solve this problem, proceed as follows:

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}Copy the
[ntbackup.exe]{.FM_Code} file from the [C:\\WINDOWS\\system32
]{.FM_Code}directory of a 32-bit system to the [C:\\Skyline
DataMiner\\Files]{.FM_Code} directory of the 64-bit system.

Problem with DataMiner database dump

On 64-bit systems, a DataMiner backup procedure can fail the moment a
database dump has to be performed.

This error is caused by SLDMS being unable to start or locate
mysqldump.exe.

To solve this problem, proceed as follows:

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}Create a dummy
[C:\\MySQL\\bin]{.FM_Code} directory containing the mysqldump.exe file.

[8.8[]{.FMAutoNumber_1
style="padding-left: 58pt;"}]{.FM_SLC_Light_Blue}[]{#XREF_17029_7_10_How_do_I}How
do I configure IIS 6 on a 64-bit system?

Problems with an incorrect IIS configuration

When IIS is incorrectly configured, the following problems may occur:

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}When browsing to the
DMA:

::: {width="100%" align="left"}
  ---------------------
  Service Unavailable
  ---------------------
:::

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}Errors coming from
W3SVC-WP in the event viewer of the DMA:

::: {width="100%" align="left"}
+-----------------------------------------------------------------------+
| Id 2268: Could not load all ISAPI filters for site/service. Therefore |
| startup aborted.                                                      |
|                                                                       |
| Id 2274:                                                              |
| C:\\WINDOWS\\Microsoft.NET\\Framework\\v2.0.50727\\aspnet_filter.dll  |
| could not be loaded due to a configuration problem \[\...\]           |
|                                                                       |
| Id 1062: It is not possible to run different versions of ASP.NET in   |
| the same IIS process. Please use the IIS Administration tool to       |
| reconfigure you server to run the application in a separate process.  |
+-----------------------------------------------------------------------+
:::

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}When browsing to ASP.NET
applications (Dashboards):

::: {width="100%" align="left"}
+-----------------------------------------------------------------------+
| 404 (Not Found)                                                       |
|                                                                       |
| 403 (Forbidden)                                                       |
+-----------------------------------------------------------------------+
:::

To avoid these problems, first of all make sure that the following
programs/frameworks are installed:

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}IIS

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}.NET Framework 3.5

If they are, make sure IIS has been correctly configured. See [Correctly
configuring IIS 6](#XREF_46268_Correctly).

[]{#XREF_46268_Correctly}Correctly configuring IIS 6

To correctly configure IIS, on top of the standard DataMiner Agent
installation, do the following:

1.[]{.FMAutoNumber_1 style="padding-left: 12pt;"}Open a command prompt
window, by going to [Start]{.FM_Emphasis} > [Run]{.FM_Emphasis} and
entering [cmd]{.FM_Code}.

::: {width="100%" align="left"}
  ------- -----------------------------------------------------------------
  NOTE:   It is advisable to run [cmd.exe]{.FM_Code} as an Administrator.
  ------- -----------------------------------------------------------------
:::

2.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Type the following
command, and then press [Enter]{.FM_Code}:

::: {width="100%" align="left"}
+-----------------------------------------------------------------------+
| Cscript %SYSTEMDRIVE%\\inetpub\\adminscripts\\adsutil.vbs             |
|                                                                       |
| SET W3SVC/AppPools/Enable32bitAppOnWin64 1                            |
+-----------------------------------------------------------------------+
:::

3.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Type the following
command, and then press [Enter]{.FM_Code}:

::: {width="100%" align="left"}
  -------------------------------------------------------------------------
  %SYSTEMROOT%\\Microsoft.NET\\Framework\\v1.1.4322\\aspnet_regiis.exe -i
  -------------------------------------------------------------------------
:::

4.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Type the following
command, and then press [Enter]{.FM_Code}:

::: {width="100%" align="left"}
  --------------------------------------------------------------------------
  %SYSTEMROOT%\\Microsoft.NET\\Framework\\v2.0.50727\\aspnet_regiis.exe -i
  --------------------------------------------------------------------------
:::

5.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Open IIS Manager.

6.[]{.FMAutoNumber_1 style="padding-left: 10pt;"}In the Web Service
Extensions list (see left tree pane), set the following extensions to
[Allowed]{.FM_Emphasis}:

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}ASP.NET version 1.1.4322

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}ASP.NET version
2.0.50727

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}Active Server Pages

7.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In File Explorer,
execute [C:\\Skyline DataMiner\\Tools\\ConfigureIIs.js]{.FM_Code}. When
the execution is ready, a message box will appear.

8.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In the left pane of the
IIS Manager, open the website and verify that the Dashboards item is an
application (cogwheel icon).

If it is not, proceed as follows:

a.[]{.FMAutoNumber_1 style="padding-left: 10pt;"}Right-click \>
Properties

b.[]{.FMAutoNumber_1 style="padding-left: 10pt;"}Click [Create
Application]{.FM_Emphasis}.

c.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}On the
[Documents]{.FM_Emphasis} tab, make sure that the default document is
"default.aspx".

d.[]{.FMAutoNumber_1 style="padding-left: 10pt;"}On the [Directory
Security]{.FM_Emphasis} tab, click [Edit]{.FM_Emphasis} (next to
Authentication and access control), and make sure that Integrated
Windows Authentication is selected.

9.[]{.FMAutoNumber_1 style="padding-left: 10pt;"}Restart IIS:

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}In the left pane,
right-click COMPUTERNAME and select [All Tasks]{.FM_Emphasis} > [Restart
IIS]{.FM_Emphasis}.

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}Alternatively, you can
run the [iisreset]{.FM_Code} command from a command prompt.

[8.9[]{.FMAutoNumber_1
style="padding-left: 58pt;"}]{.FM_SLC_Light_Blue}What do I do if there
is an error when the MySQL service is started?

After installing MySQL, the following error may occur when the MySQL
service attempts to start:

::: {width="100%" align="left"}
+-----------------------------------------------------------------------+
| MySQL service cannot start (event viewer error message:               |
|                                                                       |
| Default storage engine \<InnoDB> is not available)                    |
+-----------------------------------------------------------------------+
:::

To resolve this issue, proceed as follows:

1.[]{.FMAutoNumber_1 style="padding-left: 12pt;"}Go to the MySQL Server
installation directory:

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}On an x86 machine:
[C:\\Program Files\\MySQL\\MySQL Server x.x\\Data]{.FM_Code}.

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}On an x64 machine:
[C:\\Program Files(86)\\MySQL\\MySQL Server x.x\\Data]{.FM_Code}.

2.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Remove the following
files:

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}ib_logfile0

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}ib_logfile1

•[]{.FMAutoNumber_1 style="padding-left: 14pt;"}ibdata1

3.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Start the MySQL service
manually.

For more information, see
[<http://forums.mysql.com/read.php?22,58270,122989#msg-122989>]{.FM_Hyperlink}

[8.10[]{.FMAutoNumber_1
style="padding-left: 52pt;"}]{.FM_SLC_Light_Blue}What do I do if I get a
"Trust not granted" error when opening Cube?

Install the necessary certificates.

For more information, see [http://\[DMA\]/tools/]{.FM_Hyperlink}.

[8.11[]{.FMAutoNumber_1
style="padding-left: 52pt;"}]{.FM_SLC_Light_Blue}What do I do if I get
an "unauthorized access exception" after saving annotations?

On Windows 7, the following error may occur after saving annotations:

::: {width="100%" align="left"}
  ---------------------------------------------------------------------------------------------------
  SYSTEM.UNAUTHORIZEDACCESSEXCEPTION: RETRIEVING THE COM CLASS FACTORY FOR COMPONENT WITH CLSID\...
  ---------------------------------------------------------------------------------------------------
:::

This is because the IIS_IUSRS group has not been granted "Local
Activation" permission on SLDMS.

::: {width="100%" align="left"}
  ----------- ----------------------------------------------------------------
  See also:   [How do I manually configure DCOM?](#XREF_83871_7_16_How_do_I)
  ----------- ----------------------------------------------------------------
:::

[8.12[]{.FMAutoNumber_1
style="padding-left: 52pt;"}]{.FM_SLC_Light_Blue}[]{#XREF_48738_8_14_How_do_I}How
do I manually configure Windows Firewall?

Normally, Windows Firewall is configured automatically when you install
the Skyline software by means of the installation CD.

However, if you want to configure it manually, do as follows:

1.[]{.FMAutoNumber_1 style="padding-left: 12pt;"}Go to
[Start]{.FM_Emphasis} > [Control Panel]{.FM_Emphasis} > [Windows
Firewall]{.FM_Emphasis}.

2.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Click [Allow an app or
feature through Windows Firewall]{.FM_Emphasis}.

3.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Click the [Allow
another app\...]{.FM_Emphasis} button.

4.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Next to
[Path]{.FM_Emphasis}, click the [Browse]{.FM_Emphasis} button and browse
to [C:\\Program Files (x86)\\Internet
Explorer\\ieexplore.exe]{.FM_Emphasis}.

5.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Click
[Add]{.FM_Emphasis}.

6.[]{.FMAutoNumber_1 style="padding-left: 10pt;"}Go back to the [Windows
Firewall]{.FM_Emphasis} page of the control panel and click [Advanced
Settings]{.FM_Emphasis}.

7.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}On the [Inbound
Rules]{.FM_Emphasis} tab page, the following ports will need to be
added:

::: {width="100%" align="left"}
+-----------------------+-----------------------+-----------------------+
| Name                  | Port number           | Protocol              |
+=======================+=======================+=======================+
| HTTP Port             | 80                    | TCP                   |
+-----------------------+-----------------------+-----------------------+
| NATS Ports            | 4222                  | TCP                   |
|                       |                       |                       |
|                       | 6222                  |                       |
|                       |                       |                       |
|                       | 8222                  |                       |
+-----------------------+-----------------------+-----------------------+
| SLNet Remoting Port   | 8004                  | TCP                   |
+-----------------------+-----------------------+-----------------------+
| NAS Port              | 9090                  | TCP                   |
+-----------------------+-----------------------+-----------------------+
:::

To do so, for each of the ports, do the following:

1.[]{.FMAutoNumber_1 style="padding-left: 12pt;"}Click [New
rule]{.FM_Emphasis}

2.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In the wizard, select
[Port ]{.FM_Emphasis}and click [Next.]{.FM_Emphasis}

3.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Select whether the rule
applies to [TCP]{.FM_Emphasis} or [UDP]{.FM_Emphasis}, add the port and
click [Next:]{.FM_Emphasis}

4.[]{.FMAutoNumber_1 style="padding-left: 11pt;"} Make sure [Allow the
connection]{.FM_Emphasis} is selected and click [Next]{.FM_Emphasis}
until you reach the last step of the wizard.

5.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Enter the name of the
rule, as specified in the table above, and click [Finish]{.FM_Emphasis}.

If the computer will be polled by a DataMiner element running the
Microsoft Platform protocol driver, the following three additional steps
have to be executed:

1.[]{.FMAutoNumber_1 style="padding-left: 12pt;"}Select
[Start]{.FM_Emphasis} > [Run]{.FM_Emphasis}.

2.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In the
[Open]{.FM_Emphasis} text box, type [netsh firewall set service
RemoteAdmin]{.FM_Code}, and press [Enter]{.FM_Code}.

A message box will appear, notifying you that the firewall changes have
successfully been applied.

3.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Exit the Command Prompt
window.

## How do I manually configure DCOM?

Normally, DCOM is configured automatically when you install DataMiner by
means of the installation CD.

However, if you want to configure it manually, do the following:

1.[]{.FMAutoNumber_1 style="padding-left: 12pt;"}Select
[Start]{.FM_Emphasis} > [Run]{.FM_Emphasis}.

2.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Enter
[dcomcnfg]{.FM_Code}, and click [OK]{.FM_Emphasis}.

3.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Double-click [Component
Services]{.FM_Emphasis}, and then double-click
[Computers]{.FM_Emphasis} to expand the [Component
Services]{.FM_Emphasis} tree.

4.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Double-click [My
Computer]{.FM_Emphasis} and [DCOM Config]{.FM_Emphasis} to expand the
[Component Services]{.FM_Emphasis} tree.

5.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In the [Component
Services]{.FM_Emphasis} tree, right-click
[SLASPConnection]{.FM_Emphasis}, and click [Properties]{.FM_Emphasis}.

6.[]{.FMAutoNumber_1 style="padding-left: 10pt;"}Click the
[Security]{.FM_Emphasis} tab.

7.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In the [Launch and
Activations Permissions]{.FM_Emphasis} pane, click
[Customize]{.FM_Emphasis}, and then click [Edit]{.FM_Emphasis}.

8.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Grant an additional
permission to the following accounts:

::: {width="100%" align="left"}
  Account                                  Additional permission
  ---------------------------------------- ------------------------
  \[ComputerName\]IUSR\_\[ComputerName\]   Allow Local Activation
  \[ComputerName\]Users                    Allow Local Activation
:::

If these accounts are not listed even though they exist, see [Adding an
account to the Group or User names list](#XREF_88950_Adding_an_account)
for instructions on how to add them to the Group or user names list.

::: {width="100%" align="left"}
  ------- ----------------------------------------------------------------------------------------------
  NOTE:   If the above-mentioned accounts do not exist on your system, you do not need to create them.
  ------- ----------------------------------------------------------------------------------------------
:::

9.[]{.FMAutoNumber_1 style="padding-left: 10pt;"}Click
[OK]{.FM_Emphasis} on the open dialog boxes until you are back in the
[DCOM Config]{.FM_Emphasis} node of the [Component
Services]{.FM_Emphasis} tree.

10.[]{.FMAutoNumber_1 style="padding-left: 6pt;"}In the [Component
Services]{.FM_Emphasis} tree, right-click [SLDMS]{.FM_Emphasis}, and
click [Properties]{.FM_Emphasis}.

11.[]{.FMAutoNumber_1 style="padding-left: 8pt;"}Click the
[Security]{.FM_Emphasis} tab.

12.[]{.FMAutoNumber_1 style="padding-left: 7pt;"}In the [Launch and
Activations Permissions]{.FM_Emphasis} pane, click
[Customize]{.FM_Emphasis}, and then click [Edit]{.FM_Emphasis}.

13.[]{.FMAutoNumber_1 style="padding-left: 7pt;"} Grant an additional
permission to the following accounts:

::: {width="100%" align="left"}
  Account                           Additional permission
  --------------------------------- ------------------------
  \[ComputerName\]ASPNET            Allow Local Activation
  \[ComputerName\]Network Service   Allow Local Activation
  \[ComputerName\]IIS_WPG           Allow Local Activation
  \[ComputerName\]IIS_IUSRS         Allow Local Activation
  IIS APPPOOLDefaultAppPool         Allow Local Activation
:::

If these accounts are not listed even though they exist, see [Adding an
account to the Group or User names list](#XREF_88950_Adding_an_account)
for instructions on how to add them to the Group or user names list.

::: {width="100%" align="left"}
  ------- ----------------------------------------------------------------------------------------------
  NOTE:   If the above-mentioned accounts do not exist on your system, you do not need to create them.
  ------- ----------------------------------------------------------------------------------------------
:::

14.[]{.FMAutoNumber_1 style="padding-left: 7pt;"}Close the [Component
Services]{.FM_Emphasis} window.

[]{#XREF_88950_Adding_an_account}Adding an account to the Group or User
names list

1.[]{.FMAutoNumber_1 style="padding-left: 12pt;"}On the
[Security]{.FM_Emphasis} tab of the [Launch and Activation
Permission]{.FM_Emphasis} dialog box, click [Add]{.FM_Emphasis}.

2.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In the [Select Users,
Computers, or Groups]{.FM_Emphasis} dialog box, click
[Advanced]{.FM_Emphasis}.

3.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In the [Select Users,
Computers, or Groups]{.FM_Emphasis} dialog box, click
[Locations]{.FM_Emphasis}.

4.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In the
[Locations]{.FM_Emphasis} dialog box, select \[ComputerName\], and click
[OK]{.FM_Emphasis}.

5.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}Back in the [Select
Users, Computers, or Groups]{.FM_Emphasis} dialog box, click [Find
Now]{.FM_Emphasis}.

6.[]{.FMAutoNumber_1 style="padding-left: 10pt;"}In the Search results,
select the required account (e.g. IUSR\_\[ComputerName\]), and click
[OK]{.FM_Emphasis}.

7.[]{.FMAutoNumber_1 style="padding-left: 11pt;"}In the [Select Users,
Computers, or Groups]{.FM_Emphasis} dialog box, click
[OK]{.FM_Emphasis}.

 
:::

