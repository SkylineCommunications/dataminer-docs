---
uid: DataStax_DevCenter
---

# DataStax DevCenter

> [!NOTE]
> - The recommended setup for DataMiner storage is [Storage as a Service](xref:STaaS).
> - Since Dataminer Installer v10.2, this tool is not automatically deployed anymore, nor does it set the JAVA_HOME variable anymore.

> [!TIP]
> - To download the tool, see [Downloading DataStax DevCenter](https://downloads.datastax.com/#devcenter).
> - To install the tool, see [Installing DataStax DevCenter](https://docs.datastax.com/en/archived/developer/devcenter/doc/devcenter/dcInstallation.html).
> - To use this tool, see [Using DataStax DevCenter](https://docs.datastax.com/en/archived/developer/devcenter/doc/devcenter/dcToc.html).


This tool allows you to perform CQL queries or run scripts on a Cassandra database.

The tool can be used on any DMA using a Cassandra local database. 

To open the tool, go to the folder `C:\Program Files\Cassandra\DevCenter\` on the DMA server and double-click *Run DevCenter.lnk*.

![DataStax_DevCenter](~/develop/images/DataStax_DevCenter.png)

## JAVA_HOME variable

Setting the JAVA_HOME variable can be done in 2 ways.

### Creating a shortcut

Create a shortcut of `C:\Program Files\Cassandra\DevCenter\DevCenter.exe`.

In the properties of that shortcut, fill in the following Target.
`%windir%\System32\cmd.exe /c "set JAVA_HOME=C:\PROGRA~1\CASSAN~1\Java && set PATH=C:\PROGRA~1\CASSAN~1\Java\bin;%PATH% && start C:\PROGRA~1\CASSAN~1\DEVCEN~1\DEVCEN~1.EXE"`

### Changing the system variable

Open the Command Prompt as administrator and set the environment variable as follows:
`setx /m JAVA_HOME "C:\Program Files\Cassandra\Java"`

You can verify if all was set properly by restarting the Command Prompt and use following command:
`echo %JAVA_HOME%`

The result should show the configured path.
