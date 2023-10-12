---
uid: Configuring_alarm_template_information_message
---

# Configuring an alarm template to generate information messages

In the *Info* column, select the checkbox and enter a value to define when you want to generate an information message related to the value of a parameter:

- For a discrete parameter, a selection box is available with all possible values for that parameter. Select all values for which you want to generate an information message whenever the parameter gets that value.

- For an analog parameter, you can enter any value, and an information message will be generated each time a parameter value change occurs that crosses this boundary. The information message will indicate the change with *Dropped below* or *Escalated above*.

- For parameters of type string or double, from DataMiner 10.2.2/10.3.0 onwards, you can enter values that contain a wildcard (\* or ?).

> [!NOTE]
> You do not need to select the checkbox for alarm triggering to generate these information messages.
