---
uid: LogicGroups
---

# Groups

Groups get processed by the group execution queue (see [Inner workings](xref:InnerWorkings)). A group allows the grouping of a number of items of the same type. The supported types of items in a group are:

- parameter
- pair
- action
- session
- triggers

The items of a given group must all be of the same type (e.g. it is not possible to define a group that contains two actions and a pair). When a group is executed, all items in the group will be executed sequentially.

## Group types

The following types of groups exist:

- poll
- action
- poll action
- poll trigger
- trigger

When groups are processed by timers, there is a difference between groups of type "poll action" and "action" (or "poll trigger" and "trigger").

When the type name of a group starts with "poll" (i.e. the group type is "poll", "poll action" or "poll trigger"), this indicates that the group will be added to the group execution queue of the main protocol execution thread. (For more information on the group execution queue, see [Item execution](xref:InnerWorkingsSLProtocol#item-execution).) Groups of type "action" or "trigger", however, will immediately be executed by the initiating thread. (For more details, see [Executing groups by timer threads](xref:InnerWorkingsSLProtocol#executing-groups-by-timer-threads).)

- *Timer*
  - **Group (poll action)**
- *Timer*
  - *Group (action)*

For groups that are handled by anything other than timers, there is no difference between groups of type "poll action" and "action" (or "poll trigger" and "trigger"). That is to say, to execute a group, you define an action On "group" and Type, e.g. "execute next" (or any other execute variant as explained in [Main protocol execution thread](xref:InnerWorkingsSLProtocol#main-protocol-execution-thread)). When the group is executed, it checks whether the group type is poll (i.e. the type is set to "poll"), or whether it relates to an action ("action" or "poll action") or relates to a trigger ("trigger" or "poll trigger"). Therefore, to execute a group, it does not matter if type is set to "action" or "poll action" (or similarly, "trigger" or "poll trigger").

- Trigger
  - Action (execute next)
    - **Group (poll action)**
- Trigger
  - Action (execute next)
    - **Group (action)**

Legend

- *Timer thread*
- **Group queue processing thread**

> [!NOTE]
> The default group type is "poll".
