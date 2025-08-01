---
uid: KI_SLDataMiner_problem_generating_MIB
---

# Error in SLDataMiner when generating MIB file

## Affected versions

- DataMiner 10.4.2 and 10.4.3
- DataMiner 10.4.0 [CU0]
- DataMiner 10.3.0 [CU11] and [CU12]

## Cause

Generating a MIB file from a protocol caused an error in SLDataMiner.

## Fix

Install DataMiner 10.3.0 [CU13], 10.4.0 [CU1], or 10.4.4.<!-- RN 39120 -->

## Issue description

When a MIB file was generated from a protocol (with the *Get MIB file* option in the Protocols & Templates app), DataMiner stopped working.

The *errorlog.txt* next to the crash dump files contained the following line: `Exception handler called in CDataMiner::GetMib.`
