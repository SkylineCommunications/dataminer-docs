---
uid: Concepts1
---

# Concepts

> [!NOTE]
> The concepts explained in this section are the main concepts used within the core SRM functionality. If you intend to work with the SRM framework, which builds on the core DataMiner SRM functionality to provide a versatile toolset to manage services and resources, see [SRM framework concepts](xref:srm_concepts).

To understand the core DataMiner SRM functionality, the following concepts are important:

- **Resource**: A resource is any thing that can be used and planned. Resources can have a limited “concurrency”, determining how many bookings are possible for the resource at the same time, and a limited capacity. They can also be collected in so-called **resource pools**.

    > [!TIP]
    > See also: [Configuring pools of resources](xref:Configuring_pools_of_resources)

- **Virtual platform**: A logical collection of resource pools.

- **Virtual function definition**: The definition of a function that a specific data source can expose. This includes the definition of the parameters, interfaces, etc. of the corresponding virtual function resource. This is contained in a functions XML file, which is linked to a particular protocol.

    > [!TIP]
    > See also: [Functions XML files](xref:Functions_XML_files)

- **Virtual function resource** or **virtual function instance**: The instantiation of a virtual function definition. A protocol could for instance have several functions or several elements that conform to the same virtual function definition, in which case several corresponding virtual function resources/instances can be generated. Virtual function resources are represented in DataMiner as a specific type of virtual elements, i.e. virtual function elements.

    > [!TIP]
    > See also: [Adding a virtual function as a resource](xref:Configuring_pools_of_resources#adding-a-virtual-function-as-a-resource)

- **Booking instance** or **reservation instance**: A definition of which resources are used, how much of them is used, and when they are used. With booking instances, you can indicate which resources are in use at any point in time. Booking instances are indicated on the occupancy timeline in the *Resources* module.

    Booking instances can have “sub-bookings”, which in turn are also booking instances, making it possible to create more complex bookings. While the time slot for booking instances is defined in UTC format, the timing of sub-bookings is determined relative to that of the parent booking instance.

- **Service booking instance** or **service reservation instance**: A service booking instance is a booking instance that will create a matching DataMiner service while it is active. In most cases, the service booking instance will use function resources and it is possible to automatically set it up with DCF connections.

- **Booking definition** or **reservation definition**: The “pattern creator” for all booking instances that are grouped in a recurring pattern. The booking definition is linked to the created instances and will automatically create a subset of the full recurring pattern in order to match incoming requests, scheduling and planning. It also takes care of the creation of a new booking instance for one time slot in a recurring pattern and of the creation of booking instances with override data, keeping track of the generated booking instances.

    Like booking instances, booking definitions can also have sub-bookings, which take the form of other booking definitions. Like for booking instances, the timing of sub-bookings is determined relative to that of the parent booking definition.

- **Service booking definition** or **service reservation definition**: A booking definition that can create service booking instances.

- **Booking event** or **reservation event**: An action that can happen while a booking instance is active. This is usually an Automation script that has to be executed at a specific time.

- **Profile definition**: A definition of a profile, containing parameters and scripts.

    > [!TIP]
    > See also: [Configuring profile definitions](xref:Configuring_profile_definitions)

- **Profile instance**: An instance of a profile, with particular values assigned to each of the parameters in the profile definition.

    > [!TIP]
    > See also: [Configuring profile instances](xref:Configuring_profile_instances)

- **Service definition**: The definition of how various function definitions are linked to one another, and what a service using these functions should look like. A service definition can for example link a satellite receiver to a transcoder function and back to a satellite transmission station to make a video downcast channel for a particular feed. Service definitions can be defined in the *Services* module.

    > [!TIP]
    > See also: [The Services module](xref:The_Services_module)
