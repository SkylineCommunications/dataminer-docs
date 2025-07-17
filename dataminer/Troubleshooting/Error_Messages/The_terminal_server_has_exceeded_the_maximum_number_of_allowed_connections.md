---
uid: The_terminal_server_has_exceeded_the_maximum_number_of_allowed_connections
---

# The terminal server has exceeded the maximum number of allowed connections

The following error can often be encountered when remote desktop connections are set up:

```txt
The terminal server has exceeded the maximum number of allowed connections
```

When you set up a remote connection, by default a new terminal session is started on the remote machine. The number of terminal sessions that can be open simultaneously on a machine is limited. If, on the remote machine, other users before you started a number of sessions and left them all open, you are likely to receive the above-mentioned error.

You can, however, always connect to the so-called console session.

## Connection to the console session

Execute the following command in a command prompt window to set up a remote desktop connection to the console session of a remote machine.

If that console session is being used by another user, you will be offered the possibility to disconnect that user (i.e. force a log-off).

```txt
mstsc /v:[IP address of remote machine] /admin
```

## Working with the list of open sessions in the Task Manager’s Users tab

When connected to the console session of a remote machine, you can see a list of all open terminal sessions in the Users tab of the machine’s Task Manager.

In that tab, you can disconnect or log off open sessions. You can also send messages to specific sessions.

> [!WARNING]
> Before you disconnect or log off sessions, check if no important applications are running in those sessions.

## Shadowing a Remote Desktop session

When you open a “normal” terminal session on a remote machine (i.e. no console session), you can shadow another session on that same machine, even the console session.

After having established a “normal” terminal session on a remote machine, execute the following command in a command prompt window if you want to shadow another session on that same remote machine:

```txt
shadow [Session ID]
```

To shadow the console session, enter:

```txt
shadow 0
```

If you execute the above-mentioned command, the user working in the session that you want to shadow has to grant you permission to do so. If you get permission, then both you and the other will be connected to the same session. You will be able to collaborate and explain things to each other.
