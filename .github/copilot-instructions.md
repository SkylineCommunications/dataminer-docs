# DataMiner Docs Repository

DataMiner Docs is a documentation-only repository containing all documentation related to the DataMiner software. It uses docfx format with YAML TOC files.

## Validation of Changes

### Bootstrap and Validate the Repository

- Clone repository: `git clone https://github.com/SkylineCommunications/dataminer-docs.git`
- Install validation tools:
  - `npm install -g markdownlint-cli` - for markdown linting
  - `pip3 install yamllint` - for YAML validation
- Validate markdown files: `markdownlint . --ignore node_modules`
- Validate YAML files: `find . -name "*.yml" -exec yamllint {} \;`
- Attempt to fix issues caused by the current changes. Do not reformat existing content.

### Test the Build

- Install docfx: `dotnet tool update -g docfx`
- Run a build: 
  - `dotnet restore "src/NuGetPackages"` - to restore NuGet packages
  - `docfx metadata` - to restore metadata
  - `docfx build` - to run the build itself
- If warnings or errors are introduced during the `docfx build` step, try to fix them.

## Repository Structure

These are the key directories within this repository:

- `dataminer`: Core documentation for DataMiner users.
- `solutions`: Documentation for solutions built using DataMiner.
- `tutorials`: Overview information on tutorials. The tutorials themselves are usually located in other directories.
- `connectors`: Only contains images used for referencing elsewhere. The actual connectors information is located in a separate repository, i.e., `SkylineCommunications/dataminer-docs-connectors`.
- `develop`: Documentation for DataMiner developers
- `src`: Contains source files for documentation that is automatically generated during the `docfx metadata` step of the workflow.
- `release-notes`: Release notes for the core DataMiner software, client software, DxMs, and various DataMiner Solutions.
- `contributing`: Instructions and tips for contributors to the documentation.

For most key directories (with the exception of `src`), all images are placed in an `images` subdirectory. This makes it possible to reuse images across different topics within the directory.

### File Patterns

- All content files use `.md` format with YAML front matter.
- Each key directory has a `toc.yml` file defining navigation structure. Sometimes additional `toc.yml` files are used for lower levels to keep the `toc.yml` files from becoming too large.
- Content files require `uid:` in front matter for cross-referencing. This is followed by a unique identifier that must not contain any spaces or special characters. Ideally, the unique identifier is identical to the file name.
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
8. Avoid adding pages that only contain links to underlying pages but no actual content of their own.
9. When referring to changes introduced by a specific release note, make sure the Main Release version and Feature Release version introducing the changes are mentioned on the page.
10. Use sentence casing for titles.

## Spelling and Style Conventions

### Capitalization

- **Correlation** and **Automation**: Only capitalize when referring directly to the DataMiner modules (e.g., "the Correlation module", "the Automation module"). Use lowercase in general usage (e.g., "correlation rule", "automation script").

### Punctuation

- **i.e.** and **e.g.**: Always follow with a comma (e.g., "i.e., this is an example", "e.g., use this format").

### Compound Words

Use the following compound words as single words (no spaces or hyphens):

- **dataset** (not "data set")
- **frontend** (not "front end" or "front-end")
- **backend** (not "back end" or "back-end")
- **runtime** (not "run time" or "run-time") - except when explicitly referring to the duration of execution
- **dropdown** (not "drop-down")
- **checkbox** (not "check box")
- **scrollbar** (not "scroll bar")
- **livestream** (not "live stream")
- **multithreaded** (not "multi-threaded")
