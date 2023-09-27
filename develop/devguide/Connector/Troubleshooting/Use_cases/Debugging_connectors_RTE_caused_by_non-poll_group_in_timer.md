---
uid: Debugging_connectors_RTE_caused_by_non-poll_group_in_timer
---

# Debugging connectors: RTE caused by non-poll group in timer

In this use case, we will investigate an issue with the CP6000 connector. When this connector was used, after several minutes, an RTE was thrown.

## Investigation

We noticed the following behavior when the elements using this connector were activated: After around 7 minutes, the following RTE was thrown on all elements that are in timeout: “The main protocol-stack contains more than 1000 groups to be executed.”

In most of the log files (*SLWatchdog2.txt, SLErrorsInProtocol.txt, SLDataMiner.txt*, etc.) no relevant information could be found. The only notice of the problem seemed to be logged in the *SLSNMPAgent.txt* log file. When the protocol log file level was increased to “Developer”, we could see the following lines:

```txt
2022/01/25 10:59:33.338|SLProtocol - 23220 - Cp6k|2176|CTimer::TimerThreadFunc|DBG|6|Resetting last group
2022/01/25 10:59:33.338|SLProtocol - 23220 - Cp6k|2176|CTimer::Execute|DBG|6|16 groups to execute
2022/01/25 10:59:33.339|SLProtocol - 23220 - Cp6k|2176|CTimer::Execute|DBG|6|Last group is not a poll group.
2022/01/25 10:59:33.339|SLProtocol - 23220 - Cp6k|2176|CGroup::Execute|DBG|6|Start executing group 54003 (interval = -1) (depth=7)
2022/01/25 10:59:33.339|SLProtocol - 23220 - Cp6k|2176|CParameter::RunQActions|DBG|5|Find QAction 54003
2022/01/25 10:59:33.339|SLProtocol - 23220 - Cp6k|2176|CParameter::RunQActions|DBG|5|Run QAction 54003
2022/01/25 10:59:33.339|SLProtocol - 23220 - Cp6k|2176|CQAction::Run|INF|2|QAction [54003]
2022/01/25 10:59:33.340|SLProtocol - 23220 - Cp6k|2176|CParameter::RunQActions|DBG|5|QAction 54003 finished
2022/01/25 10:59:33.340|SLProtocol - 23220 - Cp6k|2176|CGroup::Execute|DBG|6|Finished executing group 54003
2022/01/25 10:59:33.340|SLProtocol - 23220 - Cp6k|2176|CTimer::TimerThreadFunc|DBG|6|Waiting for last group to be finished.
2022/01/25 10:59:33.340|SLProtocol - 23220 - Cp6k|2176|CTimer::TimerThreadFunc|DBG|6|Last group finished.
```

It seems that there are 16 groups in this timer, of which one triggers a QAction (54003). All these actions seem to be completed within 2 milliseconds, which looks suspicious. Notice how the third line states “Last group is not a poll group”. Let’s look at this specific timer.

```xml
<Timer id="4">
    <Name>FastPollTables</Name>
    <Time initial="true">5000</Time>
    <Interval>75</Interval>
    <Content>
        <Group>13000</Group>
        <Group>11000</Group>
        <Group>22000</Group>
        <Group>55000</Group>
        <Group>61000</Group>
        <Group>62000</Group>
        <Group>63000</Group>
        <Group>49000</Group>
        <Group>57000</Group>
        <Group>50000</Group>
        <Group>51000</Group>
        <Group>58000</Group>
        <Group>60000</Group>
        <Group>53000</Group>
        <Group>60100</Group>
        <Group>54003</Group>
    </Content>
</Timer>
```

In this timer, all groups are poll groups, except for the last one, which is of type action:

```xml
<Group id="54003">
    <Name>UpdateForeignKeys</Name>
    <Description>Update all foreign keys</Description>
    <Type>action</Type>
    <Content>
        <Action>48</Action>
    </Content>
</Group>
```

When we changed this group to type *poll action*, the issue was solved. But why? To clarify this, we need to delve a little deeper into the inner workings of DataMiner.

## How do timers process groups?

When a timer executes groups, this is what happens:

- The line “X groups to execute” is logged (DEBUG logging, level 6), where X is the number of groups.

- The timer iterates over each group. If the group is of type *poll*, *poll action* or *poll trigger*, the group is added to the group execution queue. If the *makeCmdByProtocol* option is enabled, the group is prepared. Once it is prepared, the group gets added to the group execution queue.

- If the group is not a poll group, the group is now executed by the timer thread. Note that the Protocol object has a member *m_csBusy*, which represents a lock to indicate that the protocol is busy. When the timer thread executes the group, this lock is taken, and it is released again after the group is executed.

For the **last group** of the timer content, additional logic is in place because the timer thread needs to have a way to determine if the last group is executed before the timer groups are added again.

- If the last group is a **poll group**, then the protocol thread that will execute the group must signal to the timer when this group is executed. This is done by passing a handle to an event (*m_hLastGroupFinished*) to be set by the protocol thread.

- If the last group is **not a poll group**, the following line will be logged (DEBUG logging, level 6): “Last group is not a poll group.”, and the group will be executed by the timer thread, which will also set the event indicating that the last group has been executed.

## What does this mean for this use case?

When the element is in timeout, the poll groups can take a long time to process (timeout time * (retries + 1)). In this case, it would take 60 seconds to process the poll groups in the timer, which is set to 5 seconds.

This would be the internal process:

1. The timer goes off.

1. The poll groups are put on the group execution queue. This will take 60 seconds.

1. The last group is handled in the timer thread and is finished in milliseconds. The flag is set to “not busy”.

1. 5 seconds later, the timer goes off again, the flag is checked, and as it is not busy, the groups are put on the stack.

After 60 seconds, the first groups are processed, but in the meantime the timer has added 12 times as many groups. This leads to a huge number of groups in the queue in no time.

When we change the type of the last group to a poll group, the busy flag is only set to “not busy” after all groups are processed. This is why this fixes the issue.
