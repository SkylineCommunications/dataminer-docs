---
uid: Connect_to_cloud_with_failover
---

# Connecting to the cloud with failover agent(s)

Often times our users have one or more failover agents in their setup to provide redundancy. Depending on the architecture of your DataMiner System you will need to take these failover pairs into consideration to ensure the connection towards the cloud does not get interrupted.

## Failover pair is not hosting the Cloud Connection

If the failover pair does not have the Cloud Pack installed and is not hosting the connection towards the DataMiner Cloud Platform you do not need to take any additional actions.

## Failover pair is hosting the Cloud Connection

If the active agent of the failover pair is responsible for hosting the connection towards the DataMiner Cloud Platform you will need to install the Cloud Pack on bot agents of the failover pair. This will ensure that the backup agent can maintain the connection towards the DataMiner Cloud Platform when a failover switch happens.
