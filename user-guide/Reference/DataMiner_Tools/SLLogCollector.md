---
uid: SLLogCollector
---

# SLLogCollector

SLLogCollector is a tool that can be used to easily collect log information and memory dumps from a DataMiner Agent. It can be very useful to troubleshoot issues in DataMiner.

This tool is available on every DMA from DataMiner 10.0.5 onwards. It is located in the folder `C:\Skyline DataMiner\Tools\SLLogCollector`. From DataMiner 9.6.0 CU23, 10.0.0 CU13, 10.1.0 CU2 and 10.1.5 onwards, you can also access it from the shortcut menu of the [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility).

> [!NOTE]
> This tool requires .Net Framework 4.6 or higher.

## Running the tool

To use the SLLogCollector tool:

1. In the folder mentioned above, double-click `SL_LogCollector.exe`.

1. Configure the necessary options:

    - To only collect logging for the period since DataMiner was last started, select *Exclude logging of previous run of DataMiner*.

    - To collect memory dumps as well as logging, select *Include memory dump*. Then select for which process(es) memory dumps should be collected and when these should be collected.
    
        > [!NOTE]
        > When you select the option to collect memory dumps and one or more run-time errors are present, processes affected by these run-time errors are automatically selected.

    - Use the radio buttons to select what should be done with the collected information:
    
        - If an internet connection is available on the DMA, the collected information can be uploaded to Skyline. In that case, by default an email is sent to <techsupport@skyline.be>, but you can specify a different address. Note that this option is no longer available from DataMiner 10.0.0 CU20, 10.1.0 CU9 and 10.1.11 onwards.
        
        - Alternatively, you can select to save the information in a folder on the desktop or in a custom folder.

1. When the configuration is complete, click *Start*.

1. To view information on the actions of the tool, expand the *Console* section at the bottom of the window. For more detailed information, click the *Show detailed log* button.

## Running the tool via command line

From DataMiner 10.1.11/10.2.0 onwards, you can also run the tool via command line, using the options listed below.


| Option | Description |
|--------| ----------- |
| `-c`<br>`--console` | Runs the console version of the tool. Always specify this option if you want to run the tool via command line. |
| `-h`<br>`-?`<br>`--help` | Shows help. |
| `-f=VALUE`<br>`--folder=VALUE` | Determines the folder where the logging should be saved.<br>Default: `C:\Skyline_Data\` |
| `-d=VALUE`<br>`--dumps=VALUE` | Allows you to specify the process names or IDs for which dumps should be taken. "VALUE" should be a comma-separated list of names or IDs. |
| `-m=VALUE`<br>`--memory=VALUE` | If this option is added, an additional dump will be taken after the process reaches the amount of memory (in MB) specified as "VALUE". |

For example:

```txt
SL_LogCollector.exe -c -d=25784,2319
SL_LogCollector.exe -c -h
```
