---
uid: Running_simulations
---

# Running simulations

Once your simulation files are in the folder *C:\\QASNMPSimulations*, they will be listed in the top-left corner of the main tool in the *Available Simulation Files* box. If a simulation is not yet displayed because it has only been added to the folder recently, click the *Refresh* button below the box.

Select one or more simulation files and start the simulation(s) by clicking the *Start* button. Logging will then be displayed in the bottom section of the window.

## Options

A number of options are available to tweak the behavior of the running simulations:

- *Bad Network Simulation*: Enabling this option allows you to simulate less than ideal network conditions. Available options are:

  - *Packet Loss*: The percentage of packets that should be dropped.

  - *Delay*: The delay in ms that should be applied to responses to requests and the percentage of packets that the delay should be applied to.

- *DB max values per OID*: This option lets you configure the maximum number of OIDs that should be kept in memory when running realistic dynamic (database) simulations.

> [!NOTE]
>
> - The *DB max values per OID* option is applied when a simulation is started. Changing this option will not have any effect on already running simulations.
> - The *DB max values per OID* option is available as of version 2.0.0.0 of the device simulator, which is available from DataMiner 10.2.12/10.3.0 onwards.

## Running via the command line

It is also possible to run the simulator via the command line. This allows you to run the simulator unattended (e.g. via a scheduled task).

```cmd  
USAGE:
    start /min "" simulatorexe simulation[ simulation2][ simulation3]... [/d] [/s] [/forcerepair] [/packetloss packetloss_percentage] [/delayms delay_in_ms] [/delaypct delay_percentage] [/dbmaxvaloid max_nbr_of_values_per_oid]

where
    simulatorexe      The full or relative path to the simulator executable file.
                      If the path contains spaces it should be put between double quotes.
    simulation        The filename of the simulation file including the extension.
                      If the filename contains spaces it should be put between double quotes.

    Options:
        /d            Disable logging.
        /s            Sort OIDs on load.
        /forcerepair  Force a repair of the simulation file(s).
        /packetloss   The percentage of packets that should be dropped.
        /delayms      The delay that should be applied to responses to requests.
        /delaypct     The percentage of packets that the delay specified in delayms should be applied to.
        /dbmaxvaloid  The maximum number of OIDs that should be kept in memory when running realistic dynamic (database) simulations.
```

> [!NOTE]
> The *packetloss*, *delayms*, *delaypct*, and *dbmaxvaloid* options are available as of version 2.0.0.0 of the device simulator, which is available from DataMiner 10.2.12/10.3.0 onwards.
