# DataMiner Docs Repository

DataMiner Docs is a documentation-only repository containing all documentation related to the DataMiner software. It uses docfx format with YAML TOC files.

## Repository Structure

These are the key directories within this repository:

- `dataminer`: Core documentation for DataMiner users.
- `solutions`: Documentation for solutions built using DataMiner.
- `tutorials`: Overview information on tutorials. The tutorials themselves are usually located in other directories.
- `connectors`: Only contains images used for referencing elsewhere. The actual connectors information is located in a separate repository, i.e. `SkylineCommunications/dataminer-docs-connectors`.
- `develop`: Documentation for DataMiner developers
- `src`: Contains source files for documentation that is automatically generated during the `docfx metadata` step of the workflow.
- `release-notes`: Release notes for the core DataMiner software, client software, DxMs, and various DataMiner Solutions.
- `contributing`: Instructions and tips for contributors to the documentation.

For most key directories (with the exception of `src`), all images are placed in an `images` subdirectory. This makes it possible to reuse images across different topics within the directory.

### File Patterns

- All content files use `.md` format with YAML front matter.
- Each key directory has a `toc.yml` file defining navigation structure. Sometimes additional `toc.yml` files are used for lower levels to keep the `toc.yml` files from becoming too large.
- Content files require `uid:` in front matter for cross-referencing.
- Standard format:

  ```md
  ---
  uid: Unique_Identifier
  ---
  
  # Title
  
  Content...
  ```

## Key Guidelines

1. Each `.md` file must have proper front matter including a unique `uid`.
2. Each `.md` file must have a corresponding entry in the appropriate `toc.yml` file using the matching `topicUid`. The same file must never be added to more than one `toc.yml` file.
3. Use DocFX-flavored Markdown syntax as defined in `/contributing/CTB_Markdown_Syntax.md`.
4. Follow the instructions defined in `/contributing/CTB_Tips.md`.
5. Avoid em dashes when possible.
6. One `.md` file must never contain more than 64000 characters.
7. If changes are implemented that remove all references to a specific image, that image must be removed, with the exception of any images included in the `connectors` directory.
