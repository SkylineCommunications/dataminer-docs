---
uid: Service_templates
---

# Service templates

Service templates allow you to create entire series of almost identical services with just a few clicks. Creating a large number of very similar services can be a time-consuming and tedious job. However, by creating all services in one go [with a service template](xref:Creating_a_service_template), you can save a lot of time.

## What is specified in a service template?

In a service template, you have to specify

- The input data, i.e. all data that has to be supplied to the template (user input, element parameters, element properties, etc.)

- The child elements of the services to be created

- The properties of the services to be created

- Whether an SLA has to be linked to the services to be created

- The view to which to link the services to be created

## Concept

The moment you [apply a service template](xref:Applying_service_templates), it will collect all data that has been specified as input data, process it, and automatically create the services.

![Service template concept](~/user-guide/images/ServiceTemplateConcept.jpg)

## Examples

Below you will find examples of how to define a service template that will automatically create a service for every row in a dynamic table parameter of a certain type of element. The examples start from the following premise: for each of your Microsoft Platform elements, you want to create a service for every process of which the name starts with "SL". Each of those services, named *\[computer model\]\_\[process\]*, has to include the CPU and the memory usage of the process in question.

- [Example of creating a service template](xref:ST_example_ST_creation)

- [Example of applying a service template](xref:Applying_service_templates#example-of-applying-a-service-template)

> [!TIP]
> See also:
>
> - [Service templates](https://community.dataminer.services/video/service-templates/) ![Video](~/user-guide/images/video_Duo.png)
> - [Getting Started with Service Templates](https://community.dataminer.services/video/getting-started-with-service-templates/) ![Video](~/user-guide/images/video_Duo.png)
