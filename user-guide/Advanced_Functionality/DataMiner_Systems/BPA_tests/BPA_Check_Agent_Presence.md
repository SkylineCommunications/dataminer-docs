---
uid: BPA_Check_Agent_Presence
---

# Check Agent Presence Test In NATS

NATS serves as an inter-Dataminer message broker this means that every agent should be able to reach every other agent over NATS.

This BPA will scan the NATS info as seen by this agent to verify if it finds a route to every agent it is aware of and performs a NATS client connection test to each agent.

This BPA test is available on demand. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab). From DataMiner 10.3.12 onwards, it is available by default.

## Metadata

* Name: Check Agent Presence In Nats
* Description: Polls the NATS routes, checks if every agent is represented and performs a NATS client connection test
* Author: Skyline Communications
* Default Schedule: Every day

## Results

### Success

* "No issues Detected*

Every agent's IP was found as a route in the NATS server and the NATs client connection to every agent succeeded

### Error

* "Possible issues with NATS nodes or NATS client communication between DataMiners in the cluster. See Details."


### Warning

Possible issues with NATS nodes or NATS client communication between DataMiners in the cluster. See Details."

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons, and cannot provide a conclusive report because of this:

* "Could not execute test (*[message]*)" (on unexpected exceptions). 

In the message above, the exception message is included (e.g. "Access Denied"). The test result details contain the full exception text, if available.

## Impact when issues detected

* Impact: RTE and errors might occur
* Corrective Action: Check the NATS config on all agents: see https://docs.dataminer.services/user-guide/Troubleshooting/Procedures/Investigating_NATS_Issues.html

## Limitations

* NATS info is collected, and the connection tests for the NATS client are performed using the address localhost:8222, if the local NATS node is not part of the setup, the BPA will not be able to verify the results.
* This BPA does not work for setups that have the NATSForceManualConfig option enabled.
