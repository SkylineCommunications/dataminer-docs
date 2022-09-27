---
uid: Debugging_connectors_serial_communication_returning_command_echoes
---

# Debugging connectors: Serial communication returning command echoes

## About

This article details how you can investigate an issue with a matrix component used in a connector that allows monitoring and control of a router via serial communication. **Connecting or disconnecting crosspoints via the matrix component is slow**, and a check in Stream Viewer reveals that an **echo is returned** instead of the router info.

## Investigation in Stream Viewer

Check in Stream Viewer to view the outgoing and incoming information. For this use case, serial commands are expected to go out and retrieve the router information.

However, in this case you will see that the command is sent out and an echo is returned instead of the router info. Only after multiple retries will the router pass its information. This is the reason for the slow update of the matrix component. The stream also indicates extra data after the echo, which is not documented and does not make sense for the request.

Here is an example snippet from Stream Viewer:

```txt
<< 21:29:32 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 21:29:33 - Status Request
   000000  4020533F30 0D0A3E0D0A 463F300D0A 463F310D0A  @ S?0..>..F?0..F?1..
   000020  3E                                           >
<< 21:29:34 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 21:29:34 - Status Request
   000000  4020533F30 0D0A3E0D0A 463F300D0A 3E          @ S?0..>..F?0..>
<< 21:29:35 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 21:29:36 - Status Request
   000000  4020533F30 0D0A3E                            @ S?0..>
<< 21:29:36 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 21:29:39 - Status Request
   000000  4020533F30 0D0A3E                            @ S?0..>
<< 21:29:39 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 21:29:40 - Status Request
   000000  4020533F30 0D0A3E0D0A 533A30302C 35460D0A53  @ S?0..>..S:00,5F..S
   000020  3A30312C35 460D0A533A 30322C3341 0D0A533A30  :01,5F..S:02,3A..S:0
   000040  332C33420D 0A533A3034 2C33410D0A 533A30352C  3,3B..S:04,3A..S:05,
   000060  33420D0A53 3A30362C33 410D0A533A 30372C3342  3B..S:06,3A..S:07,3B
   000080  0D0A533A30 382C33410D 0A533A3039 2C33420D0A  ..S:08,3A..S:09,3B..
```

Stream Viewer will also reveal a problem with the polling cycle. If a command is sent out but the incoming data is not what the connector expects (i.e. the defined response in the *protocol.xml*), the retry mechanism will kick in, sending the command again. This means that the connector may send the command a great many times in a short period, as illustrated below.

```txt
>> 21:59:33 - Status Request
   000000  4020533F30 0D0A3E                            @ S?0..>
<< 21:59:41 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 21:59:43 - Status Request
   000000  4020533F30 0D0A3E                            @ S?0..>
<< 21:59:51 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 21:59:53 - Status Request
   000000  4020533F30 0D0A3E                            @ S?0..>
<< 22:00:01 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 22:00:03 - Status Request
   000000  4020533F30 0D0A3E                            @ S?0..>
<< 22:00:11 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 22:00:13 - Status Request
   000000  4020533F30 0D0A3E0D0A 463F300D0A 463F310D0A  @ S?0..>..F?0..F?1..
   000020  3E0D0A463A 3035462C35 462F35462C 35462C4930  >..F:05F,5F/5F,5F,I0
   000040  0D0A463A31 33462C3546 2F33462C35 462C49300D  ..F:13F,5F/3F,5F,I0.
   000060  0A463A3137 462C35462F 33462C3546 2C49300D0A  .F:17F,5F/3F,5F,I0..
   000080  3E0D0A533A 30302C3546 0D0A533A30 312C35460D  >..S:00,5F..S:01,5F.
   000100  0A533A3032 2C33410D0A 533A30332C 33420D0A53  .S:02,3A..S:03,3B..S
   000120  3A30342C33 410D0A533A 30352C3342 0D0A533A30  :04,3A..S:05,3B..S:0
…
<< 22:00:21 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 22:00:22 - Status Request
   000000  4020533F30 0D0A3E0D0A 533A30302C 35460D0A53  @ S?0..>..S:00,5F..S
   000020  3A30312C35 460D0A533A 30322C3341 0D0A533A30  :01,5F..S:02,3A..S:0
   000040  332C33420D 0A533A3034 2C33410D0A 533A30352C  3,3B..S:04,3A..S:05,
   000060  33420D0A53 3A30362C33 410D0A533A 30372C3342  3B..S:06,3A..S:07,3B
   000080  0D0A533A30 382C33410D 0A533A3039 2C33420D0A  ..S:08,3A..S:09,3B..
…
<< 22:00:31 - Status Request
   000000  4020533F30 0D                                @ S?0.
>> 22:00:34 - Status Request
   000000  4020533F30 0D0A3E0D0A 533A30302C 35460D0A53  @ S?0..>..S:00,5F..S
   000020  3A30312C35 460D0A533A 30322C3341 0D0A533A30  :01,5F..S:02,3A..S:0
   000040  332C33420D 0A533A3034 2C33410D0A 533A30352C  3,3B..S:04,3A..S:05,
   000060  33420D0A53 3A30362C33 410D0A533A 30372C3342  3B..S:06,3A..S:07,3B
   000080  0D0A533A30 382C33410D 0A533A3039 2C33420D0A  ..S:08,3A..S:09,3B..
```

## Checking the polling cycle

Though this may not be documented, when a flood of requests is sent, the equipment can have trouble managing them all. You can test if this is the case by reducing the polling cycle and verifying the impact via Stream Viewer.

You can for instance lower the speed of the polling cycle, e.g. from 1 second to 10 seconds, and disable the retry mechanism. Then keep this running for a short while and check if the router recovers from the echoes and bad responses and instead starts to respond as expected with every command that is sent.

## Adjusting the connector

The test above will reveal if the router is sensitive to sending too many commands in a short period. If this is indeed the case, to resolve the slow responding time of the matrix component when setting a crosspoint, you need to adjust the design of the connector.

For example:

- Reduce the speed of the polling cycle used to monitor the current state of the router. Make sure it is in line with the recommendations in the development guide (see [Timers](xref:Timers1)).

- When setting a crosspoint, use the router’s “SET” confirmation to refresh the matrix component instead of sending the “Status Request” again. This will avoid an overload of this command when a large number of crosspoints are set.
