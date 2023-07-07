---
uid: Packet_interval_schedule
---

# Packet interval schedule

![](~/develop/images/QADS_TrapSenderIntervalSchedule.png)
<br>Trap Sender packet interval schedule

The main options are:

- *Original*: Use this option if you want the time between the sending of each trap to be equal to the time detected in the PDML or CSV file, i.e. when it should be the same as for the original traps.

- *Fixed*: Use this option if you want a fixed time between the sending of each trap, i.e. the amount of time specified in the box next to this option.

- *Random*: Use this option if you want a random time between the sending of each trap. The amount of time will be a random number between the lower and upper bound specified in the boxes next this option (in milliseconds).

- *Rate*: Use this option if you want to send a specified number of packets in 1 second, and repeat this after a specified number of seconds.

  > [!NOTE]
  > If you want to use the *Rate* option, make sure that either the *Loop* or *Random loop* option is selected, as otherwise this feature will not work.

Additional options:

- *Loop*: Use this option if you want to repeat sending the traps, so that the first trap is sent again after the last trap has been sent.

- *Random loop*: Use this option if you want the sender to pick a random trap from the list each time.

- No additional option (i.e. *Loop* and *Random loop* not selected): If neither of the above loop options are selected, trap sending will stop after the last trap in the list has been sent.
