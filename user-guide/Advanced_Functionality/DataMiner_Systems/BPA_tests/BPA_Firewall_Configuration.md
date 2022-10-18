---
uid: BPA_Firewall_Configuration
---

# Firewall Configuration

## Best Practice

The firewall acts as a "gatekeeper", blocking and monitoring unauthorized requests to a network, server, or application. 
It is crucial to close any "gate" (better known as a port) that is not actively being used.

A firewall policy that is too lax, may allow adversaries to attack internal services.

This BPA verifies no excessive ports are allowed through in the Windows firewall.

## Metadata

- Name: Firewall Configuration
- Description: Verifies no excessive ports are allowed through the Windows firewall.
- Author: Skyline Communications
- Default Schedule: Daily

## Results

### Success

No excessive firewall ports are open.

### Warning

Too many (or too little) ports are allowed through the Windows firewall, or the firewall is completely disabled.

### Errors

This BPA does not create errors.

## Mitigation

Restrict the number of ports allowed through the Windows firewall. For more information see: [Securing the DataMiner firewall](https://community.dataminer.services/securing-dataminer-part-2-firewall/).

## Limitations

- The BPA can only check the local server.