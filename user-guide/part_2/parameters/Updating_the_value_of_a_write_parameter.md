# Updating the value of a write parameter

The way you can change the value of a write parameter depends on the type of parameter:

- [Updating discrete parameters](Updating_discrete_parameters.md)

- [Updating analog parameters](Updating_analog_parameters.md)

- [Updating hybrid parameters](Updating_hybrid_parameters.md)

- [Updating dynamic table parameters](Updating_dynamic_table_parameters.md)

Regardless of the type of parameter, when you have changed the value of any write parameter:

- Click the green check mark to apply the change. If you make several parameter changes without clicking the check mark, a message will appear at the bottom of the card, asking you to confirm your changes.

- If a parameter is dependent on another parameter, you may need to update the value of that other parameter as well. See [Parameter dependencies](Parameter_dependencies.md).

> [!NOTE]
> When you update the value of a write parameter, the DMS always checks the new value before sending it to the device. If validation fails, a message box will appear explaining why the new value is not valid.
> -  In case of analog parameters, both the range and the step size will be validated.
> -  In case of string parameters, both the format (e.g. capitalization) and the length will be validated.

By default, a confirmation box will appear when you update the value of a write parameter. In the user settings, you can specify whether you want this confirmation box to appear. See [User settings](../../part_1/GettingStarted/User_settings.md).

Updates of some write parameters, however, always have to be confirmed:

- Within a DMS Protocol, you can specify that a confirmation box always has to appear when users update a particular parameter. This will typically be the case for special functions like reset, reboot, etc. Those confirmation boxes will often also contain a custom message, defined in the protocol, that warns users about the consequences.

- Updates to matrix parameters always have to be confirmed.

> [!TIP]
> See also:
> [Configuring matrix parameters](Configuring_matrix_parameters.md)
