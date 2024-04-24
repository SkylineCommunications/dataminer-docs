---
uid: Best_Practices_When_Creating_Correlation_Rules
---

# Best practices when creating Correlation rules

## Avoid lengthy Correlation rules

Lengthy Correlation rules are rules of which the actions take a long time to complete. While those actions are being executed, DataMiner Correlation cannot perform other tasks. This has a negative impact on the system.

### Impact

Lengthy Correlation rules can have the following consequences:

- Other Correlation rules may encounter delays in accessing data that interests them because of the prolonged execution of lengthy rules. Consequently, these rules may execute their actions later than anticipated.

- When lengthy Correlation Rules are running, it can lead to the occurrence of run-time errors (RTEs).

### Possible improvements

- When a Correlation rule executes an Automation script that contains sleep actions, check if it is possible to reduce or even remove these. Whether this is possible depends entirely on the context and the purpose of those sleep actions.

- When you define a Correlation rule to run a script, you can disable the option *Wait for the script to finish before continuing*. If this option is disabled, the rule will not wait before proceeding with other actions. While this may enhance the speed at which actions are scheduled, it is important to note that not all Automation scripts or Correlation rules are suitable for this adjustment. Disabling this feature could potentially lead to other system issues depending on the setup and the intended purpose of the script. Exercise caution when making this decision. It may be worth tweaking the rule for better overall performance, or considering alternative approaches to achieve your objectives.

> [!NOTE]
> If you have discovered other solutions or workarounds while troubleshooting, feel free to [propose your changes](xref:CTB_Quick_Edit) to this guide.
