---
uid: KI_NATS_error_message_after_10_1_installation
---

# NATS error message after 10.1 installation

## Affected versions

DataMiner 10.1 and higher

## Cause

Introduction of inter-process communication via NATS [[ID 27496][ID 28082][ID 28131][ID 28660]](xref:General_Main_Release_10.1.0_new_features_1#gradual-introduction-of-inter-process-communication-via-nats-id-27496id-28082id-28131-id-28233id-28660)

## Fix

Manual firewall configuration

## Issue description

From DataMiner 10.1.0 onwards, the NATS and NAS services are automatically installed on each NATS-enabled DataMiner Agent. More information is available in the [DataMiner v10.1.0 release notes](xref:General_Main_Release_10.1.0_new_features_1#gradual-introduction-of-inter-process-communication-via-nats-id-27496id-28082id-28131-id-28233id-28660).

However, if the firewall update fails after an upgrade to DataMiner 10.1.0 or higher, this can result in the following DataMiner runtime error message:

`NATS has stopped, restarting …`

To solve this issue, manually configure the firewall settings as described in [Configuring a DataMiner Agent](xref:Changing_the_DMA_ID), or follow the steps mentioned in the answer to the question [How to solve 'NATS has stopped working, restarting…' after an upgrade?](https://community.dataminer.services/question/how-to-solve-nats-has-stopped-working-restarting-after-an-upgrade/) on DataMiner Dojo.
