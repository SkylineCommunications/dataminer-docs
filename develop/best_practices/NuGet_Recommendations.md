---
uid: NuGet_Recommendations
---

# Recommendations for providing NuGet packages for your solution

When developing DataMiner solutions, creating NuGet packages can significantly enhance code reusability, maintainability, and extensibility. This page provides general recommendations on when and how to provide NuGet packages for your solution.

## When to create NuGet packages

Consider creating NuGet packages for your solution when:

- **Shared functionality**: You have code that is used across multiple components within your solution (e.g., shared between Automation scripts, connectors, or low-code apps).

- **Reusability across solutions**: The functionality could be valuable for other solutions or custom implementations.

- **Optional modules**: You are building optional modules or extensions for a Standard Solution that need to reference the core solution's assemblies without duplicating them.

- **API exposure**: You want to expose APIs for integration with other DataMiner components or external systems.

- **Version management**: You need to manage versioning of shared components independently from the main solution deployment.

## Standard NuGets vs. Custom Dev Packs

### Standard NuGet packages

Use standard NuGet packages when:

- The assemblies should be **installed** with the consuming solution.
- You want to distribute standalone functionality that does not depend on a pre-installed solution.
- The package provides utilities, helpers, or data source integrations.

Follow the naming conventions in [Producing NuGet packages](xref:Producing_NuGet).

### Custom Dev Packs

Use [Custom Dev Packs](xref:TOODataMinerDevPackages#custom-dev-packs) when:

- Your solution provides core assemblies that should **not be duplicated** when optional modules or extensions consume them.
- You want to ensure there is only one version of the assemblies (from the main solution) at runtime.
- You are preventing version conflicts between the main solution and its optional modules.

For Standard Solutions delivered by Skyline Communications, use [Solution Dev Packs](xref:TOODataMinerDevPackages#solution-dev-packs) with the `Skyline.DataMiner.Dev.Utils.Solutions.*` naming convention.

> [!TIP]
> Custom Dev Packs showcase the power of Standard Solutions: any custom implementation can leverage the backbone of a Standard Solution without duplicating assemblies, promoting reusability while maintaining version consistency.

## Code organization best practices

### Separate concerns

- **Create separate projects** for different aspects of your solution:
  - `.Common`: Shared code that can run in multiple contexts.
  - `.Automation`: Automation-specific implementations.
  - `.GQI`: GQI-specific implementations.
  - `.Protocol`: Connector-specific implementations.

### Follow naming conventions

- Ensure your NuGet package name **matches the repository name** for consistency.
- Follow the established [naming conventions](xref:Producing_NuGet#naming-conventions).
- Use clear, descriptive names that indicate the package's purpose.

## Documentation and discoverability

### Document your packages

- Always include a **README.md** file explaining:
  - Purpose and scope of the package
  - Code entry points and usage examples
  - Minimum DataMiner version requirements
  - Dependencies and prerequisites

- Use [XML documentation comments](xref:Xml_Documentation_Comments) to provide IntelliSense support for consumers.

### Register relevant packages

When your Custom Dev Pack is **relevant and generic** enough for broader use:

- Add it to the [Skyline NuGet packages](xref:SkylineNuGetPackages) documentation list.
- This is especially important for Solution Dev Packs intended for wider adoption.

## Versioning and maintenance

### Follow semantic versioning

Adhere to [Semantic Versioning](xref:Producing_NuGet#versioning-conventions):

### Plan for stability

- Consider the **stability** of your APIs before publishing.
- Once published, maintain **backward compatibility** whenever possible.
- Clearly communicate any breaking changes in release notes.

## Publishing strategy

### Internal vs. public packages

- **Internal packages**: Useful during development within your organization.
- **Public packages** (nuget.org): Consider publishing if the package could benefit the broader DataMiner community.

### Use CI/CD pipelines

Leverage automated pipelines for consistent package creation:

- [Producing NuGet packages via GitHub](xref:Producing_NuGet_GitHub)

## See also

- [Producing NuGet packages](xref:Producing_NuGet)
- [DataMiner Dev Packs](xref:TOODataMinerDevPackages)
- [Naming conventions](xref:Producing_NuGet#naming-conventions)
- [XML documentation comments](xref:Xml_Documentation_Comments)
