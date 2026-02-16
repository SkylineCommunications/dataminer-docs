---
uid: ConnectorBestPracticesParameters
---

# Parameters

## Parameter descriptions and values

Values like "True/False" must be avoided. Rephrase the parameter description if necessary. For example, instead of defining a parameter with description "Manual Mode" and possible values 'True" and "False", it is considered better practice to use the description "Switch Mode" and values "Automatic" and "Manual".

## Unit of measure

If applicable, a unit of measure must be provided. See [Units](xref:Protocol.Params.Param.Display.Units).

## Value range

If applicable, a value range must be provided for displayed parameters (read and write). See [Range](xref:Protocol.Params.Param.Display.Range).

## Date and time values

Parameters used to hold a time, date, or datetime value should be implemented using the "date", "time", or "datetime" option.

See also [Options for measurement type *number*](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-number).

## Exceptional states

In case a device can return exceptional states (e.g., "N/A", "Unknown", etc.), these should be implemented as [Exception](xref:Protocol.Params.Param.Interprete.Exceptions.Exception) or [Other](xref:Protocol.Params.Param.Interprete.Others.Other) and have the disabled state.

## Tooltips

All displayed parameters must have a meaningful smart tag (tooltip).

## Octet values

Octet values should be implemented as bit rate.

## Error Counter values

Error counters should be made available as a rate value.
