---
uid: srm_scripting
---

# SRM scripting

This section explains the main kinds of scripting used in the SRM framework.

## Profile-Load Script (PLS)

A Profile-Load Script (PLS) is an Automation script that is used to apply profile instances or values onto a virtual function resource. This script is executed when a booking enters a specific state. For example, at the start time of the booking, a PLS is used to apply a profile instance.

A PLS is typically linked to a specific virtual function. The name of the PLS can therefore be added to the profile definition connected to the virtual function. As multiple connectors can expose the same virtual function, multiple PLSs can be linked to the same profile definition. A PLS requires a "FunctionDve" dummy linked to the connector exposing the virtual function, which ensures that the correct PLS will automatically be executed.

For example, different connectors can expose the same "Encoding" virtual function. As it is the same virtual function, one profile definition will be used for the virtual function. The Profile-Load Scripts for the various connectors can be linked to this profile definition. When the booking is orchestrated, the correct PLS will be executed.

## Life cycle Service Orchestration (LSO) script

## Data Transfer Rules (DTR)

## Custom events

## Contributing conversion script

## Created booking script
