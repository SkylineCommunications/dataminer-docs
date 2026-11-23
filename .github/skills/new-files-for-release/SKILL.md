---
name: new-files-for-release
description: 'Use when asked to Make new release files or create the Cube, General, and Web release-note files and navigation entries for a new release cycle.'
argument-hint: '10.5.0 [CU19] / 10.6.0 [CU7] / 10.6.10'
---

# Create new release files

Create and update Markdown files and `toc.yml` files for a new release cycle.

1. Read `.github/instructions/release-notes-writing.instructions.md` and the applicable repository instructions. Use the release versions supplied in the request; ask for missing Main Release/CU or Feature Release versions. The versions below are examples, not defaults.

1. For this new release cycle, create the following files for each of Cube, General, and Web apps release notes, for nine files in total. The files should be created in the appropriate directories under `release-notes/`.

   - Two main release files (for example, `Cube_10.5.0_CU19.md` and `Cube_10.6.0_CU7.md`)
   - One feature release file (for example, `Cube_10.6.10.md`)

   Check for existing destination files first. Do not overwrite existing release content or create duplicate navigation entries.

1. Check the files of the previous release and make sure the new files already contain the same introductory text and the necessary empty sections. Adapt version-specific text and front matter to the new versions, with a unique `uid` matching each filename. Do not copy previous release-note entries.

1. Include a preview label in the level-one title of every new file.

1. Add the new files to the correct `toc.yml` file, with the preview label:

   - Main release files should be added *below* the latest previous main release, feature release files should be added *above* the latest previous feature release.
   - Existing preview labels must remain untouched. It is OK if this means that several successive files have a preview label.

1. Verify all nine destination files, version metadata, empty sections, preview titles, navigation order, and matching `topicUid` values. Report the created files, any files already present, and updated navigation files.
