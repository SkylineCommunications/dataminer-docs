---
uid: Connector_help_General_Dynamics_SW-1000
---

# General Dynamics SW-1000

The driver is a virtual driver used to monitor and configure the General Dynamics SW-1000.

## About

The General Dynamics SW-1000 Switch Controller is used in conjunction with a redundant LNA system or redundant SSPA system. The Switch Controller drives an external switch which may be used, for example, to insert test signals, or to switch between polarizations.

## Installation and configuration

### Creation

This driver is a virtual driver, and upon creating an element you need to define for each of the 4 input parameters from which Dataminer element and from which parameter the Status information will be received, and also for the 2 output parameters, to which Dataminer Element and to which parameter the data will be sent.These parameters are linked to :

Input Position 1 Status (Read) = input parameterInput Position 1 Status (Write) = output parameterInput Position 2 Status (Read) = input parameterInput Position 2 Status (Write) = output parameterLocal Status = input parameterRemote Status = input parameter

## Usage

### General

This page gives you the option to see the status of the **Input Position**, and of the **Status.**The **Input Position** can also be toggled here.
