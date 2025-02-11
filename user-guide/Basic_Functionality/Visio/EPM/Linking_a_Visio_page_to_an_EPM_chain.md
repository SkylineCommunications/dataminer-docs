---
uid: Linking_a_Visio_page_to_an_EPM_chain
---

# Linking a Visio page to an EPM chain

Using a shape data field of type **Chain**, you can link a page of a Visio drawing to a particular chain (i.e. tab page) of an EPM element (formerly known as CPE Manager).

> [!TIP]
> See also: [Linking a Visio page to an EPM filter section field](xref:Linking_a_Visio_page_to_an_EPM_filter_section_field)

## Configuring the shape data field

Add a shape data field of type **Chain** to the shape, and set its value to the name of the chain (i.e. EPM tab).

To specify more than one chain, use a pipe character ("\|") as separator between the chain names.

For example:

| Shape data field | Value                              |
|------------------|------------------------------------|
| Chain            | olt (limited)\|cmts topology\|maps |
