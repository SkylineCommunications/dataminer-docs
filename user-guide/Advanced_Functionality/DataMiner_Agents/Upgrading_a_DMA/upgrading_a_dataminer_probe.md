---
uid: upgrading_a_dataminer_probe
---

# Upgrading a DataMiner Probe

Upgrading a DataMiner Probe differs from upgrading a regular DataMiner Agent.
A DMP is not part of the DMS, it functions as a standalone gateway or proxy between its devices and the DMS.
Because of this, when upgrading the cluster, DMPs are not included in the upgrade process.

More information on the publish-subscribe principle can be found [here](https://docs.nats.io/nats-concepts/core-nats/pubsub).

## Prerequisites
- You'll need to [download](https://github.com/nats-io/natscli/releases/) and unpack the CLI package on each server.
- The location of the NATS credential file
This can be found in C:/Skyline DataMiner/SLCloud.xml, use the value within the NatsCredsFile tag.

## Procedure
1. Open an remote session towards each server
2. Open a command line window and navigate to the NATS CLI folder
3. Initialize the subscribers
	```
	nats --creds="C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds" sub cli.demo
	```
	The subscribers will now listen to the subject "cli.demo"
4. Initialize the publisher
	```
	nats --creds="C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds" pub cli.demo "test connectivity"
	```
	This will publish the string "test connectivity" onto the cli.demo channel
5. Verify that the message was received on each subscriber command line
