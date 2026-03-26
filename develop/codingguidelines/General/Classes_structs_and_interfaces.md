---
uid: Classes_structs_and_interfaces
---

# Classes, structs and interfaces

- PascalCasing should be used for names of classes and structs.

- Classes and structs should be named with nouns or noun phrases (e.g., Alarm, Service, TransportStreamParser).

- Interfaces should be named with adjective phrases (or occasionally with nouns or noun phrases) (e.g., ISortable).

- Interface names should be prefixed with the letter "I" ([SA1302](https://github.com/Visual-Stylecop/Visual-StyleCop/wiki/SA1302)). This clearly indicates that the type is an interface.

- When a class-interface pair is defined where the class is a standard implementation of the interface, the class and interface name should only differ by the prefix "I".

- When generic type parameters are used, a single letter "T" should be used as the name in case the meaning is completely clear. In case the meaning is not clear, a more descriptive name should be used and this name should start with a prefix "T".
