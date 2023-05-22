---
uid: TCPView
---

# TCPView

TCPView is a Windows program that can be useful to check which process is using which port. When troubleshooting, this can be especially useful to check why a certain process (e.g. SLNet, Cassandra, etc.) is not able to listen on a specific port.

To use this tool:

1. Download the tool from the [Microsoft website](https://docs.microsoft.com/en-us/sysinternals/downloads/tcpview).

1. Extract the zip file and run *Tcpview.exe* as Administrator.

The tool will then display an overview of the various processes in your system with the port they are using.

To free up a specific port, right-click the process using the port and select *Close Connection*.
