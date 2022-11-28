---
uid: Investigating_slow_device_control_using_dotTrace
---

# Investigating slow device control using dotTrace

## Introduction

When testing a matrix connector on a production environment we noticed that creating crosspoints took around  2s on average to be set. We expected it to be a lot faster so we wanted to investigate this and find the root cause behind it.
Due to some limitations on the live environment we were unable to make connector changes for example to add logging or even to duplicate existing elements. These limitations make the investigation of the connectors performance more difficult. However using an automation script, Wireshark and performance profiling we were able to get a pretty good picture of the performance of the system and the connector.

## 1 Automation script

We created a simple automation script that performs a set on a live element with the approval of the system operators. This script works as followed:

1. Save the timestamp just before the SetParameter
2. Make the crosspoint on the write parameter
3. Enter a retry loop to check if the read parameter has been updated every 20ms
4. If the correct value from set 2 has been retrieved save a time stamp
5. Print the timestamps

This gives an overview of the beginning and the end of the action. In our case we noticed that 2s were lost in the overall process. We wanted to investigate this further to see why.

## 2 Wireshark

With Wireshark we were able to visualize the communication between dataminer and the device.. Using the timestamps from the automation script and the timestamps form Wireshark we were able to see that 60ms was lost between making the crosspoint on the write parameter of the element and the transmission of the message to the device to execute this. The device took 200ms to respond. The remaining +/-1.7s were used in dataminer to process the response message.
At this stage we could start adding timestamps in a debug version of the connector to see in which QAction/method the most time gets spend. But, as said, we couldn’t do any of these approaches on this live environment.

## 3 Performance Profiling

The only way to look further into the performance of the QActions was to turn to performance profiling. This can be achieved by taking a snapshot of the SLScripting process since this is the process where the QAction are running in. Of course the QAction responsible for handling the device response needs to be running while we are taking the snapshot. To take these snapshots we used dotTrace.

1. To start taking snapshots of the process we had check on which server the element was hosted. After that we had to place the [dotTrace Command-Line Profiler](https://www.jetbrains.com/help/profiler/Performance_Profiling__Profiling_Using_the_Command_Line.html) on this server and unzip it.

1. Open a Command Prompt as Administrator and navigate to the location where you placed the command line profiler, e.g.:

    >*cd :\Skyline_Data\JetBrains.dotTrace.CommandLineTools.windows-x64.2022.2.3>*

1. After this you can start inputting commands. Before we did this we needed the SLScripting process ID. This is easily obtained via the Task Manager:

    ![TaskManager Process ID](~/develop/images/Taskmanager_process_id.png)

There are 4 of different ways to take a snapshot of a process. There are [3 Performance Profiling](https://www.jetbrains.com/help/profiler/Performance_Profiling.html) types and a [Timeline Profiling](https://www.jetbrains.com/help/profiler/Concurrency_Profiling_Timeline_.html) type.
In our use case Timeline profiling might have been the best profiling type since it would show in which order the calls are made. But the server didn’t allowed this. It manifested as an error when starting the profiling command. Normally you could circumvent this by rebooting the sever but in production this isn’t an option.
The other profiling types could impact performance, except for Sampling profiling. So we tried using the Sampling profiling  which was accepted by the server, the command would look like this:
dottrace attach 37392 --profiling-type=Sampling --timeout=60s
This command attaches to the Process with id 37392 with the sampling profiling type and the snapshot will be taken over a duration of 60 seconds. By default the snapshot files will be saved under the command-line tool file structure. Note that none of these files can be renamed, otherwise they can’t be opened. More information about the commands can be found in the [command-line tool manual](https://www.jetbrains.com/help/profiler/Performance_Profiling__Profiling_Using_the_Command_Line.html#console_profiler).

The resulting snapshot will look like this:

![DotTraceFiles](~/develop/images/DotTraceFiles.png)

These files need to be moved to a location where [dotTrace](https://www.jetbrains.com/profiler/download/#section=web-installer) is installed and is activated.
Now we want to investigate how.
Open the main file. By default, the [Threads Tree](https://www.jetbrains.com/help/profiler/Studying_Profiling_Results__Threads_Tree.html) is displayed. Showing all the treads that were created during the sampling time. But for us the [Call Tree](https://www.jetbrains.com/help/profiler/Studying_Profiling_Results__Call_Tree.html) is a lot more useful to see a representation of all function calls in all threads. Change this by clicking on the Call Tree button on the left:

![DotTraceCallTree](~/develop/images/DotTraceCallTree.png)

Using “Ctrl+F” you can search for method names in the snapshot giving you an indication how long a method or call took to complete. In our case we looked for the ApplyChanges of the Outputs.
![DotTraceCallTreeZoom](~/develop/images/DotTraceCallTreeZoom.png)

An important limitation of sampling is that we can’t see how many times a method was executed or when.
However we are able to see in a blink of an eye where most time is spent in the execution of the QActions. This is the biggest advantage of using this tool.
In our use case, looking to the printscreen above we see that serialization and the Output.ApplyChanges takes the most amount of time. Now that we know where most time is spent we can focus our efforts on these sections in the connector code.
