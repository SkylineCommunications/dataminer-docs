---
uid: upgrading_a_dataminer_probe
---

# Upgrading a DataMiner Probe

When you run a regular DataMiner upgrade in a DMS, DMPs will not be included in the upgrade process. This is because a DMP does not function as one of the DataMiner nodes in a DataMiner System, but instead as a standalone gateway or proxy between its devices and the DMS. As a consequence, it should be upgraded in a different way from a a regular DataMiner Agent.

Follow the steps below to upgrade a DMP:

1. Open a remote session towards each server.

1. Download and unpack the [CLI package](https://github.com/nats-io/natscli/releases/) on each server.

1. Open the NATS credentials file `C:/Skyline DataMiner/SLCloud.xml` and copy the value from within the *NatsCredsFile* tag.

1. Open a command line window and navigate to the NATS CLI folder.

1. Initialize the subscribers:

   ```txt
   nats --creds="C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds" sub cli.demo
   ```

   The subscribers will now listen to the subject "cli.demo"

1. Initialize the publisher:

   ```txt
   nats --creds="C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds" pub cli.demo "test connectivity"
   ```

   This will publish the string "test connectivity" onto the cli.demo channel

1. Verify that the message was received on each subscriber command line

> [!TIP]
> For more information on the publish-subscribe principle, see [Publish-Subscribe](https://docs.nats.io/nats-concepts/core-nats/pubsub) in the NATS documentation.
