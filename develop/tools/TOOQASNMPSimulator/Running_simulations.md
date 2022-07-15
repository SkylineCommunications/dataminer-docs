---
uid: Running_simulations
---

# Running simulations

Once your simulation files are in the folder *C:\\QASNMPSimulations*, they will be listed in the top-left corner of the main tool in the *Available Simulation Files* box. If a simulation is not yet displayed because it has only been added to the folder recently, click the *Refresh* button below the box.

Select one or more simulation files and start the simulation(s) by clicking the *Start* button. Logging will then be displayed in the bottom section of the window.

It is also possible to run the simulator via the command line. This allows you to run the simulator unattended (e.g. via a scheduled task).

```cmd  
USAGE:
    start /min "" simulatorexe simulation[ simulation2][ simulation3]... [/d] [/s] [/forcerepair]

where
    simulatorexe      The full or relative path to the simulator executable file.
                      If the path contains spaces it should be put between double quotes.
    simulation        The filename of the simulation file including the extension.
                      If the filename contains spaces it should be put between double quotes.

    Options:
        /d            Disable logging.
        /s            Sort OIDs on load.
        /forcerepair  Force a repair of the simulation file(s).
```
