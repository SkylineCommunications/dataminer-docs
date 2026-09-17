---
uid: System_StackOverflowException
description: "Use this connector troubleshooting entry point when recursive QAction code causes a System.StackOverflowException in SLScripting."
---

# System.StackOverflowException

Use this entry point when a connector QAction causes a stack overflow in the SLScripting process, commonly because of recursion without a terminating condition.

## Audience and prerequisites

This page is for connector developers investigating a process crash. Collect the SLScripting crash dump and the connector version that was running when the exception occurred.

## Scope and expected result

The linked procedure explains how to inspect the dump and locate the recursive method in the QAction assembly. Use the result to add or correct the terminating condition in the connector code.

## Failure and edge cases

A stack overflow can terminate the process before ordinary logging is written. If no stack-overflow exception is present in the dump, use the broader [SLScripting troubleshooting procedures](xref:Troubleshooting_SLScripting).

## Authoritative procedure

Refer to [Investigating StackOverflowException occurrences](xref:TroubleshootingSLScriptingStackOverflowException).

## Related concepts

- [QActions](xref:LogicQActions)
- [SLScripting troubleshooting](xref:Troubleshooting_SLScripting)
