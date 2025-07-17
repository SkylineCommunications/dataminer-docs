---
uid: KI_NATS_not_starting_special_chars
---

# NATS not starting if DMS name contains special characters

## Affected versions

From DataMiner 10.1.0/10.1.2 onwards.

## Cause

If the DMS name starts with a special character, and the base64 encoding of the special character starts with a number, NATS cannot handle this name and will not start up.

## Fix

No fix is available yet.

## Issue description

If a DataMiner System has a name starting with a special character, e.g. "♣ DMS ♣", each time ResetNATSCustodianRequest runs, NATS refuses to start up.
