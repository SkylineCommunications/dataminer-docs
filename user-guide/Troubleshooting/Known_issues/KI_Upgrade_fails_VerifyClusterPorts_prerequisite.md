---
uid: KI_Upgrade_fails_VerifyClusterPorts_prerequisite
---

# Upgrade fails because of VerifyClusterPort.dll prerequisite

## Affected versions

10.2.0 CU1 up to 10.2.0 CU5 and 10.2.4 up to 10.2.8

## Cause

In two-node DataMiner System setups, for example with two single DMAs or with one Failover pair, the VerifyClusterPorts upgrade prerequisite checks the ports for both nodes. However, only one NATS node is actually used in this case. This means that a misconfiguration or problem with the other node will not have any impact on DataMiner functionality, but the prerequisite check will nevertheless block the upgrade if it detects this.

## Fix

Install DataMiner 10.2.0 CU6 or 10.2.9.

## Workaround

Temporarily disable the prerequisite check. See [Upgrade BPA test](xref:Upgrading_a_DataMiner_Agent#upgrade-bpa-test).

## Issue description

Upgrading a cluster consisting of a Failover pair or of two single DMAs is blocked because the VerifyClusterPorts prerequisite fails.
