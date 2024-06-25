---
uid: Minimum_DMA_version
---

# Minimum DMA version

The following list indicates the minimum required DMA version for specific features:

- Params

  1. DefaultValue tag: 8.5.3 (RN 8776)

     - Only supported by standalone parameters.

  1. DisplayKey: 8.5.2.4

     - On big dynamic tables: 9.0 CU6

     - If using AddRow/DeleteRow: 9.0 CU9

  1. snmpSetAndGet: 8.5.7.2 (RN 10007)

     - On buttons: 9.0 CU1 (RN 12017)

     - Does not work yet if a sequence is defined on the parameter.

  1. snmpSetAndGetWithWait: 8.0.7.4

     - This should be avoided as it causes RTEs

  1. Exception values with decimals: 8.5.1 (RN 7794)

     - For previous versions, add the Decimals tag to the Interprete tag.

- QActions

  1. NT_UPDATE_DESCRIPTION_XML (127): 9.0 CU2 (RN 12553)

  1. ShowInformationMessage(): 8.5.6.5 (RN 10017)

  1. SetParameters(): 8.0.8 (RN 7058)

  1. Precompile option: 8.0.5 (RN 6457)

- Triggers

- Actions

- HTTP

  1. Multiple connections in a session: 9.0 CU6

- Pairs

  1. Conditions: 8.5.0 (RN 7996)

- Groups

  1. Conditions: 9.0 (RN 12624)

- Timers

- DCF: 8.5.8.5 (SW added the "#define DCFv1" preprocessor directive to all QActions + Advanced Naming Fixes: RN 10060, RN 10830, RN 10062)

  1. Multiple ParameterGroups pointing to the same table: \> 9.0.0 CU5 (RN 13174)

  1. Combination of ParameterGroups to DVE table and to non-DVE table: \> 9.0 CU9 (RN 14030)

  1. Advanced Naming: 8.5.8.5.
