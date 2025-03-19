---
uid: MO_Satellite
---

# Satellite

The Satellite Data & Capacity Management provides the tools to efficiently allocate and monitor the usage of satellite transponders and bandwidth to ensure optimal performance and availability. Effective management ensures that satellite resources are used efficiently, minimizes downtime, and maximizes service quality for all users.

The following pages are available in the app:

- [*Satellites*](#satellites)
- [*Beams*](#beams)
- [*Transponders*](#transponders)
- [*Transponder Plans*](#transponder-plans)
- [*About*](#about)

## Satellites

The Satellite Management Page provides is the interface for overseeing satellite resources. It includes tools for creating, managing and retiring Satellites used in the MediaOps system. The Satellite record is the main object that stores details about the satellite itself and stores such information as the: Satellite Name, an abbreviation for the satellite used in various parts of the system, hemisphere, orbit, azimuth and more.

## Beams

Beams are a focused transmission of radio signals directed to a specific geographic area, enabling communication and data transfer within that region. The Beams page allow you to create and manage the basic information about a Beam including which Satellite it belongs to.

## Transponders

A transponder on a satellite receives signals from the ground, amplifies them, and retransmits them back to Earth, facilitating communication and data exchange. The Transponder records allow for the storage of key information like the satellite the transponder is on, the band and frequency range of the transponder and more. The Transponder is a major component of MediaOps Transponder Management solution that provides guaranteed reservation of transponder space. For a Transponder to be used as part of the Transponder Management solution, it is important that the Start and Stop Frequencies are filled out for the Transponder record. While these fields are not mandatory to create a Transponder record, they are required for the Transponder Plan to successfully create Transponder Slot Resources. Seethe Transponder Plans documentation for more information.

## Transponder Plans

For scheduling Occasional Use Satellite space, typically only a portion of a transponder is used per Job. Additionally, the space on the transponder can be broken up into “slots” of different sizes. When booking a slot, a certain amount of the capacity of the transponder will be consumed. However, it is also important to know where in the frequency range that booking will be to ensure other bookings do not overlap the used frequency at any given time. To do this MediaOps uses Transponder Plans allowing you to quickly and easily define Slot Definitions with just a few bits of information. When a Transponder Plan is assigned to a Transponder, MediaOps will then automatically generate the bookable Slot Resources to be used in the Scheduling system. This is explained in more detail under [Transponder Plan](xref:MO_Sat_Transponder_Plan). The Transponder Plans page allows you to to manage the transponder plans.

## About

The About page provides information on the version of MediaOps package.
