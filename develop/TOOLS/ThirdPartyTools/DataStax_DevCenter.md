---
uid: DataStax_DevCenter
description: DataStax DevCenter allows you to perform CQL queries or run scripts on a Cassandra database. It can be used on any server using a Cassandra database.
---

# DataStax DevCenter

> [!NOTE]
> The recommended setup for DataMiner storage is [Storage as a Service](xref:STaaS).

This tool allows you to perform CQL queries or run scripts on a Cassandra database. It can be used on any server using a Cassandra database.

Older DataMiner installers included this tool, but recent DataMiner installers (v10.2 or higher) do not deploy this tool and do not set the JAVA_HOME variable during installation, which means you will need to install it yourself and [set the JAVA_HOME variable](#setting-the-java_home-variable).

> [!TIP]
>
> - To install this tool, see [Installing DataStax DevCenter](https://docs.datastax.com/en/archived/developer/devcenter/doc/devcenter/dcInstallation.html).
> - For general information on how to use this tool, see [Using DataStax DevCenter](https://docs.datastax.com/en/archived/developer/devcenter/doc/devcenter/dcToc.html).

If the tool has been installed on the DMA, to open the tool, go to the folder `C:\Program Files\Cassandra\DevCenter\` and double-click *Run DevCenter.lnk*.

![DataStax_DevCenter](~/develop/images/DataStax_DevCenter.png)

## Setting the JAVA_HOME variable

To be able to use this tool, the JAVA_HOME variable must be set. You can set this variable by either [creating a shortcut](#creating-a-shortcut) or [changing the system variable](#changing-the-system-variable).

### Creating a shortcut

1. Create a shortcut of `C:\Program Files\Cassandra\DevCenter\DevCenter.exe`.

1. In the properties of that shortcut, fill in the following target:

   ```txt
   %windir%\System32\cmd.exe /c "set JAVA_HOME=C:\PROGRA~1\CASSAN~1\Java && set PATH=C:\PROGRA~1\CASSAN~1\Java\bin;%PATH% && start C:\PROGRA~1\CASSAN~1\DEVCEN~1\DEVCEN~1.EXE"
   ```

### Changing the system variable

1. Open a command prompt as administrator and set the environment variable as follows:

   ```txt
   setx /m JAVA_HOME "C:\Program Files\Cassandra\Java"
   ```

1. Verify if the system variable has been set correctly by opening a new command prompt and entering the following command:

   ```txt
   echo %JAVA_HOME%
   ```

   The result should show the configured path.
