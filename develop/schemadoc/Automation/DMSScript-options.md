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

|Value  |Name  |Description  |
|---------|---------|---------|
|0x000     |None         |Indicates that no options are set.         |
|0x008     |DebugMode         |If this flag is present, comment type statements will be logged as information events. (Equivalent to a comment with "debug=true" as first script statement.)         |
|0x010     |AllowUndef         |Allows GetParameter to return `null` when parameter value is undefined.         |
|0x020     |RequireInteractive         |If present, the script can only be executed in interactive mode.         |
|0x040     |SupportsBackForward         |If present, interactive portions in the script can be controlled by back/forward buttons.         |
|0x080     |SkipElementChecks         |If present, parameter sets on elements will not be checked. (Equivalent to comment with "skipElementChecks == true".)         |
|0x100     |SavedFromCube         |`true` if script was saved from Cube.        |
|0x200     |SkipInfoEventsSet         |`true` if information events should not be generated for parameter sets executed from the Automation script.         |
|0x400     |HasFindInteractiveClient         |Present if the script has a FindInteractiveClient call.         |

Some of these options can be set via the Automation script editor in Cube. For more information, refer to [General script configuration](xref:General_script_configuration).

When creating a new Automation script from Cube, the options attribute has the decimal value “472” by default. This is “0x1D8” in hexadecimal notation, meaning that the following flags are configured by default:

- 0x008: Debug Mode
- 0x010: AllowUndef
- 0x040: SupportsBackForward
- 0x080: SkipElementChecks
- 0x100: SavedFromCube
