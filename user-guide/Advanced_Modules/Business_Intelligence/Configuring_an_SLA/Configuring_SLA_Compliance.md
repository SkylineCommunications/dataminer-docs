---
uid: Configuring_SLA_Compliance
---

# Configuring SLA Compliance

To configure how many violations are allowed in an SLA or what duration these may have, it is necessary to configure SLA Compliance.

To configure SLA compliance, go to the *Compliance Configuration* page of the SLA element in DataMiner Cube. There, you can configure the settings detailed below.

## Setting the total violation limit

Under *Total violation*, you can specify how long the SLA may be violated during the SLA window before it is considered breached. Two types of total violation can be configured:

- Relative: e.g. 0.010 percent of the total window size

- Absolute: e.g. 5 minutes

To set a relative limit:

1. Set *Maximum Total Violations Type* to Relative, using the drop-down list.

1. Enter the desired percentage under *Maximum Total Violations Percentage*.

1. Confirm your settings.

   The maximum total violation time will appear as a percentage next to *Maximum Total Violation Time*.

To set an absolute limit:

1. Set *Maximum Total Violations Type* to Absolute, using the drop-down list.

1. Enter a unit and value under *Maximum Total Violations Unit* and *Maximum Total Violations Value* respectively.

1. Confirm your settings.

   The maximum total violation time will appear next to *Maximum Total Violation Time*.

## Setting the violation count limit

Under *Violation count*, you can specify how many violations may occur before the SLA will be considered breached. For example, if *Violation count* is set to 2, the SLA will only be considered breached when 3 violations have occurred.

To set a maximum number of violations, enter the desired number in the box under *Total Violations Before Breach*.

> [!NOTE]
> By default, this field is set to *Not used*. To return the field to the default value, use the *Not used* checkbox.

## Setting the limit for a single violation

Under *Single violation*, you can specify how long one single violation may last before the SLA is considered breached. As with the total violation limit, you can set either a relative or an absolute limit.

To set a relative limit:

1. Set *Maximum Single Violation Type* to *Relative*, using the drop-down list.

1. Enter the desired percentage under *Maximum Single Violation Percentage*.

1. Confirm your settings.

   The maximum total violation time will appear as a percentage next to *Maximum Single Violation Time*.

To set an absolute limit:

1. Set *Maximum Single Violation Type* to *Absolute*, using the drop-down list.

1. Enter a unit and value under *Maximum Single Violation Unit* and *Maximum Single Violation Value* respectively.

1. Confirm your settings.

   The maximum total violation time will appear next to *Maximum Single Violation Time*.
