---
uid: KI_NATS_error_message_after_10_1_installation
---

# NATS error message after 10.1 installation

## Affected versions

DataMiner 10.1 and higher

## Cause

Introduction of inter-process communication via NATS [[ID_27496](https://community.dataminer.services/documentation/dataminer-v10-1-0-release-notes/#27496)] [[ID_28082](https://community.dataminer.services/documentation/dataminer-v10-1-0-release-notes/#28082)] [[ID_28131](https://community.dataminer.services/documentation/dataminer-v10-1-0-release-notes/#28131)] [[ID_28233](https://community.dataminer.services/documentation/dataminer-v10-1-0-release-notes/#28233)] [[ID_28660](https://community.dataminer.services/documentation/dataminer-v10-1-0-release-notes/#28660)]

## Fix

Manual firewall configuration

## Issue description

From DataMiner 10.1.0 onwards, the NATS and NAS services are automatically installed on each NATS-enabled DataMiner Agent. More information is available in the [DataMiner v10.1.0 release notes](https://community.dataminer.services/documentation/dataminer-v10-1-0-release-notes/#28082).

However, if the firewall update fails after an upgrade to DataMiner 10.1.0 or higher, this can result in the following DataMiner run-time error message:

`NATS has stopped, restarting …`

To solve this issue, manually configure the firewall settings as described in [Configuring a DataMiner Agent](xref:Configuring_a_DataMiner_Agent), or follow the steps mentioned in the answer to the question [How to solve 'NATS has stopped working, restarting…' after an upgrade?](https://community.dataminer.services/question/how-to-solve-nats-has-stopped-working-restarting-after-an-upgrade/) on DataMiner Dojo.
