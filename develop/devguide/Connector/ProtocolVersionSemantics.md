---
uid: ProtocolVersionSemantics
---

# Protocol version semantics

Versioning of a DataMiner protocol provides users with visibility on changes, fixes, new features, the possible impact of changes, and compatibility requirements. Versioning also allows users to identify which version ranges are maintained in parallel.

The version of a protocol is indicated using a specific format, as explained below.

## Composition of a protocol version number

A protocol version number consists of 4 numbers separated by periods. Each of the numbers has a distinct purpose.

A.B.C.D

- A = Branch
- B = System version
- C = Major change
- D = Minor change

For example: 1.0.0.1

The combination of the first 3 numbers identifies the protocol version range.

It is possible that different version ranges are maintained in parallel but we should always try to keep this to a minimum.

### Branch

- A new branch number is used to support multiple versions that contain distinct differences (e.g. different protocol types, subsets of a driver, etc.).
- Different branch ranges are maintained in parallel unless a range is explicitly marked as obsolete.
- Range: [1 ... n]
- Examples:

  - 1.0.0.1 = Initial branch.
  - 2.0.0.1 = New branch containing a subset of features.
  - Both ranges are maintained.

### System version

- A new system version number is used when a system dependency has increased, and it is not possible to keep the driver compatible with previous versions. For example, the data source with which the connector communicates has a new firmware version which is not backwards compatible.

- Different data source ranges are maintained in parallel unless a range is explicitly marked as obsolete.
- Range: [0 ... n]
- Examples:

  - 1.0.0.1 = Initial version supporting device firmware 10.0.x - 10.1.x.
  - 1.1.0.1 = New range to support device firmware range 10.2.x.
  - Typically, we will always try to only maintain the last range. Exceptions are made when, for example, a hardware version is still commonly used (and supported by the vendor) and only supports up to firmware version 10.1.x not allowing us to migrate corresponding elements to the new 1.1.0.x range.

### Major change

- A new major change version number is used when the change may have an impact on the DMS platform and an action by the user might be required when a driver is upgraded to this range. For example:

  - Another connection is added, and the user needs to configure an IP address on existing elements.
  - Parameter descriptions have been changed, so that any Visio drawings and Automation scripts referencing these descriptions may need to be updated.

- Different major change ranges are not maintained in parallel, unless this is exceptionally agreed upon.
- Range: [0...n]
- Examples:

  - 1.0.0.1 = Initial version.
  - 1.0.1.1 = New range containing an extra connection.
  - Range 1.0.0.x becomes obsolete by default and will not be maintained.

### Minor change

- A new minor change version number indicates an iteration in the driver range consisting of new features, fixes and/or changes.
- This number is not included in the driver version range as previous iterations are never maintained in parallel.
- Range:  [1 ... n]
- If the suffix _Bx is added, where x is a number in the range [1...n], this indicates a version build that is still being developed. For example: 1.0.0.5_B1.
- Examples:

  - 1.0.0.1 = Initial version.
  - 1.0.0.2 = Second iteration containing extra features.
  - Version 1.0.0.1 becomes obsolete.

## Update Center

When a connector is installed in a DMS, you can retrieve new versions from the same branch through Update Center. For more detailed information, refer to [Updating protocols with the Update Center](xref:Adding_a_protocol_or_protocol_version_to_your_DataMiner_System#updating-protocols-with-the-update-center).

In Update Center, detailed information is included in the version history overview, including:

- What has been implemented in a version.
- What the reason is for a possible range change and which possible actions need to be taken.
