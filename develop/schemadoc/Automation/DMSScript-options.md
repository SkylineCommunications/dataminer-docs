---
uid: DMSScript-options
---

# options attribute

Specifies different options.

## Content Type

positiveInteger

## Parent

[DMSScript](xref:DMSScript)

## Remarks

The value is the decimal representation of a hexadecimal bit flag combination. The meaning of the different flags is as follows:

- 0x000: None
- 0x008: Debug Mode
- 0x010: AllowUndef
- 0x020: RequireInteractive
- 0x040: SupportsBackForward
- 0x080: SkipElementChecks
- 0x100: SavedFromCube
- 0x200: SkipInfoEventsSet
- 0x400: HasFindInteractiveClient

When creating a new Automation script from Cube, the options attribute has the decimal value “472” by default. This is “0x1D8” in hexadecimal notation, meaning that the following flags are configured by default:

- 0x008: Debug Mode
- 0x010: AllowUndef
- 0x040: SupportsBackForward
- 0x080: SkipElementChecks
- 0x100: SavedFromCube

For more information about the meaning of each flag, refer to [General script configuration](xref:General_script_configuration).
