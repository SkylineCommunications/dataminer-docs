---
uid: Assistant_UserContext
---

# Adding custom user context

> [!IMPORTANT]
> DataMiner Assistant is an upcoming feature that is not yet available in current DataMiner versions. The information below provides a preview of what will be available in a future release.

To help DataMiner Assistant interpret information accurately within your organization's environment, you will be able to provide a dedicated context file named **UserContext.md**.

This file will contain organization-specific information such as system structure, naming conventions, and operational rules. The Assistant will use this information to adapt its reasoning and responses accordingly.

The *UserContext.md* file will complement [Skyline's default context](xref:Assistant_Context), which includes system instructions, general data descriptions, and other baseline information. It will add insights that are specific to your environment.

The file must be named `UserContext.md` and written in [Markdown](xref:CTB_Markdown_Syntax). The Assistant will interpret the file hierarchically based on Markdown headings, so structure the file logically.

This context may include, for example:

- A description of your organization and services.

- Custom naming schemes for elements, services, or parameters.

- Information about your DMA structure.

- Information about your role within the organization.

- A glossary with terms and acronyms specific to your organization.

Once added, this custom user context will become part of the Assistant's session context. This means the Assistant will automatically take it into account when interpreting your questions, alongside the general Skyline-provided context files.

## Best practices

- Avoid complex language and unnecessary information.

- Be clear. If the content is confusing, the Assistant may misinterpret it.

- Avoid redundant explanations. The Assistant already understands general DataMiner concepts.

- Focus on what is specific to your environment (names, systems, structures, priorities).

- Keep sections short and structured. Lists and tables help.

- Avoid including too many examples. This may limit the Assistant's flexibility in reasoning.

## Example structure

Below is a complete example of the structure of a *UserContext.md* file. Note that the company and scenarios in this example are fictional and provided for illustrative purposes only. They do not reflect real organizations or environments.

```md
# User context

## Organization

Lumen Media Services operates regional OTT streaming and satellite distribution platforms.
Our infrastructure spans three main regions (Europe, the Americas, and Asia), with each region managed by its own Network Operations Center (NOC).

Core services include:
- Live broadcast distribution
- VOD content delivery
- Contribution uplinks
- Monitoring and reporting across all feeds

## User role

Network Operations Engineer; responsible for:

- Monitoring system health and service availability.
- Investigating alarms and reporting incidents.
- Generating daily health summaries.
- Coordinating with field engineers during outages.

## System landscape

This DMA contains multiple views, each representing a region:

- Europe: includes sites in London, Paris, and Berlin.
- Americas: includes sites in New York, Los Angeles, and São Paulo.
- Asia: includes sites in Singapore, Tokyo, and Mumbai.

Each site view contains subviews for different device types:

- Encoders
- Transmitters
- Network devices

## Surveyor structure

- Top-level views represent regions: Europe, Americas, Asia.
- Each regional view contains subviews per site.
- Elements are grouped under their site view.
- Each site view includes:
  - One "Encoders" subview
  - One "Transmitters" subview
  - One "Network devices" subview

## Naming conventions

- **View names:** Regions (e.g. `EUR`)
- **Element names:** `XXX-TTT-###`
  - `XXX`: Location/site
  - `TTT`: Type of device
  - `###`: Numeric ID

  Example: `NYC-ENC-011` → New York, Encoder, device 11

  | Abbreviation | Type of device |
  |--|--|
  | ENC | Encoder |
  | TRX | Transmitter |
  | NET | Network device |

## Rules

- Treat any element or service with prefix `TEST-` as non-production. 
- Flag alarms under "OTT Distribution" as high priority.
- ...

## Situations and response rules

### Situation: Health overview requests

**Trigger**: When the user asks about the health of the system.

**Instructions**:

- Check if the question refers to a specific region or site.
- If unspecified, provide a general status summary for all regions.

### Situation: Test environment queries

**Trigger**: When the user mentions "test environment" or "stages".

**Instructions**:

- Limit results to elements and services starting with `TEST-`.

```
