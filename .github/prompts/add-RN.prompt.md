---
agent: 'agent'
description: 'This prompt is used to retrieve a release note from SkylineApi and add it on docs'
---

Can you ask me a release note ID, and then retrieve that release note from SkylineApi and document it in the correct markdown file in `dataminer-docs/release-notes`

When creating a new release-note page, include complete version 1 metadata from `contributing/metadata/documentation-metadata-v1.schema.json`, set `content_type: release-note`, and use only the release version confirmed by the source. Do not invent owner, applicability, or review values.

<!-- To use this prompt, you will first have to make sure you are connected to the Collaboration MCP Server. To do so, in VS Code, press Ctrl + Shift + P and select "MCP: List Servers". If the server is not listed yet, select "+ Add Server", then select HTTP, and then enter the URL "https://collaboration-mcp-server.thankfulsea-26bd4902.westeurope.azurecontainerapps.io/mcp", and select "Global". Note that this will only work for Skyline employees. -->
