---
uid: Best_Practices_For_Correlation
---

# Best practices for Correlation

## Avoid lengthy Correlation rules

Lengthy Correlation rules are rules of which the actions take a long time to complete. While those actions are being executed, DataMiner Correlation cannot perform other tasks. This has a negative impact on the system.

### Impact

Lengthy Correlation rules can have the following consequences:

- Other correlation rules may encounter delays in accessing data that interests them because of the prolonged execution of lengthy rules. Consequently, these rules may execute their actions later than anticipated.

- When lengthy correlation rules are running, it can lead to the occurrence of runtime errors (RTEs).

### Possible improvements

- When a correlation rule executes an automation script that contains sleep actions, check if it is possible to reduce or even remove these. Whether this is possible depends entirely on the context and the purpose of those sleep actions.

- When you define a correlation rule to run a script, you can disable the option *Wait for the script to finish before continuing*. If this option is disabled, the rule will not wait before proceeding with other actions, which will improve the speed at which actions are scheduled.

  > [!NOTE]
  > While disabling this option is the best thing to do in most cases, for some automation scripts or correlation rules this could cause issues. This is specifically the case if an action on a first alarm needs to be completed before the action on a second alarm can be executed, or if a lengthy script is invoked and the correlation rule triggers the script too often. In this last case, the script requests towards the Automation engine will start piling up. To prevent such issues, consider tweaking the correlation rule or consider alternative approaches to achieve your objectives.

> [!TIP]
> If you have discovered other solutions or workarounds while troubleshooting, feel free to [propose your changes](xref:CTB_Quick_Edit) to this guide.

## Avoid keeping correlated alarms open for a long time

See [Keep alarm trees from growing too large](xref:Best_practices_for_assigning_alarm_severity_levels#keep-alarm-trees-from-growing-too-large).
