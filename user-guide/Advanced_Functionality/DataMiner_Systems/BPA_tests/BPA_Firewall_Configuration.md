---
uid: BPA_Firewall_Configuration
---

# Firewall Configuration

The firewall acts as a "gatekeeper", blocking and monitoring unauthorized requests to a network, server, or application. It is crucial that a "gate" (i.e. a port) is closed if it is not actively being used.

A firewall policy that is too lax may allow adversaries to attack internal services.

This BPA test verifies that no excessive ports are open in the Windows firewall.

> [!NOTE]
> This BPA is available from DataMiner version 10.2.12 and 10.3.0 onwards.

## Metadata

- Name: Firewall Configuration
- Description: Verifies that no excessive ports are open in the Windows firewall
- Author: Skyline Communications
- Default Schedule: Daily

## Results

### Success

No excessive firewall ports are open.

### Warning

Too many (or too few) ports are allowed through the Windows firewall, or the firewall is completely disabled.

### Errors

This BPA does not create errors.

## Mitigation

Restrict the number of ports allowed through the Windows firewall. For more information see: [Securing the DataMiner firewall](https://community.dataminer.services/securing-dataminer-part-2-firewall/).

## Limitations

- The BPA can only check the local server.
