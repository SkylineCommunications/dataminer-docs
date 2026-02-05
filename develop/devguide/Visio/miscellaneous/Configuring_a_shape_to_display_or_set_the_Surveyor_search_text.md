---
uid: Configuring_a_shape_to_display_or_set_the_Surveyor_search_text
---

# Configuring a shape to display or set the Surveyor search text

You can configure a shape to display the most recently used search entry in the Surveyor, or to trigger a search in the Surveyor with a particular search entry. This can be done with the *SurveyorSearchText* variable. The scope of the variable always has to be set to the current workspace.

For instance, if the following shape data are configured for a shape containing an asterisk, the shape will display the most recent search text:

| Shape data | Value              |
|------------|--------------------|
| Variable   | SurveyorSearchText |
| Options    | WorkspaceVariable  |

Alternatively, you can set the *SurveyorSearchText* variable to a particular text in order to trigger a search. For example, if you configure the shape data as specified below, a shape can be used to set the search text to "Visio" and trigger a search for this word in the Surveyor:

| Shape data | Value                    |
|------------|--------------------------|
| SetVar     | SurveyorSearchText:Visio |
| Options    | WorkspaceVariable        |
