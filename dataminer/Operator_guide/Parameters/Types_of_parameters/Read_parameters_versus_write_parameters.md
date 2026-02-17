---
uid: Read_parameters_versus_write_parameters
---

# Read parameters versus write parameters

### Read parameters

Read parameters display a read-only value that has been retrieved from a device.

![Read parameters](~/dataminer/images/Read_Parameters.png)<br>*Read parameter in DataMiner 10.4.5*

The way this value is displayed depends on whether it is a discrete or an analog value.

- Discrete values can only be displayed as text.

- Analog values can be displayed as text, LED bars, oscilloscopes, or colored tubes.

> [!NOTE]
>
> - Sometimes parameter values are only retrieved when a particular button is clicked (e.g., Refresh, Load, etc.). This is common practice for less important parameters.
> - Unavailable read parameters are always shown in gray.

> [!TIP]
> See also: [Changing the way parameters are displayed](xref:Changing_the_way_parameters_are_displayed)

### Write parameters

The value of write parameters can be updated by a user and sent back to the device.

![Write parameters](~/dataminer/images/Write_Parameter.png)<br>*Read and associated write parameter in DataMiner 10.4.5*

The way the DataMiner user interfaces allow users to change those values depends on the type of parameter.

> [!NOTE]
> Most write parameters will have an associated read parameter.

> [!TIP]
> See also: [Updating the value of a write parameter](xref:Updating_the_value_of_a_write_parameter)
