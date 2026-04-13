---
uid: Updating_the_value_of_a_write_parameter
---

# Updating the value of a write parameter

The way you can change the value of a write parameter depends on the type of parameter:

- [Updating discrete parameters](xref:Updating_discrete_parameters)

- [Updating analog parameters](xref:Updating_analog_parameters)

- [Updating hybrid parameters](xref:Updating_hybrid_parameters)

- [Updating dynamic table parameters](xref:Updating_dynamic_table_parameters)

Regardless of the type of parameter, when you have changed the value of any write parameter:

- Click the green check mark to apply the change. If you make several parameter changes without clicking the check mark, a message will appear at the bottom of the card, asking you to confirm your changes.

- If a parameter is dependent on another parameter, you may need to update the value of that other parameter as well. See [Parameter dependencies](xref:Parameter_dependencies).

> [!NOTE]
> When you update the value of a write parameter, DataMiner always checks the new value before sending it to the device. If validation fails, a message box will be shown explaining why the new value is not valid.
>
> - In case of analog parameters, both the range and the step size will be validated.
> - In case of string parameters, both the format (e.g., capitalization) and the length will be validated.

By default, a confirmation box will be shown when you update the value of a write parameter. In the user settings, you can specify whether you want this confirmation box to be shown or not. See [User settings](xref:User_settings).

Updates of some write parameters, however, always have to be confirmed:

- Within a protocol, you can specify that a confirmation box always has to be shown when users update a particular parameter. This will typically be the case for special functions like reset, reboot, etc. Those confirmation boxes will often also contain a custom message, defined in the protocol, that warns users about the consequences.

- Updates to matrix parameters always have to be confirmed.

> [!TIP]
> See also: [Configuring matrix parameters](xref:Configuring_matrix_parameters)
