---
uid: CTB_Reviewing_Contribution
---

# Reviewing a contribution from someone else

Most contributions to the documentation are added in the form of "pull requests", i.e., requests to pull specific changes into the repository. The pull requests are listed under <https://github.com/SkylineCommunications/dataminer-docs/pulls>.

Until a pull request is merged, everyone can review it and add comments of their own. To do so:

Before reviewing the details, identify the affected D6.1 workstream and change pattern. Check the `authority`, `content_type`, and `owner` values against [Documentation governance and review cadence](xref:CTB_Documentation_Governance). An `unknown` owner or authority is an explicit follow-up, not a reason to invent a handle or silently approve a contract.

1. Open the pull request, for instance by selecting it in the list of pull requests or by using a direct link to the pull request.

1. Go to the *Files changed* tab. This will show an overview of all the changes in the pull request.

1. Check the changes in each file. For larger modifications, you may need to click *Load diff* first.

1. To add a comment, hover the mouse pointer over the relevant line and click the blue "+" button.

   ![Button to add a comment](~/images/Contrib_PlusButton.png)

1. Write your comment and click *Add single comment* or *Start a review*, depending on whether you want to add more comments or not.

   ![Adding a comment](~/images/Contrib_Comment.png)

1. If you started a review, when you have reviewed everything, click the *Finish your review* button at the top. Optionally, instead of the default *Comment* option, select *Approve* to indicate that you approve the changes in the pull request or *Request changes* to indicate that you think further changes are necessary before the pull request can be merged. Then click *Submit review*.

   ![Submitting a review](~/images/Contrib_SubmitReview.png)

> [!NOTE]
> You can also submit a review without adding comments directly in a file, by only clicking the green review button and using the window displayed above.

> [!TIP]
> If the Markdown source looks confusing, and you would prefer to see a preview of a file, in the *Files changed* tab, click "..." in the upper-right corner of the box representing the file, and select *View file*. However, note that it is not possible to submit comments in this preview.

If reviewers find conflicting sources, record the conflict in the pull request. A confirmed canonical source takes precedence. If authority is equal or unresolved, do not approve a new normative claim until the Docs Writing Team has documented the decision. For generated API or schema output, request a source regeneration and provenance check rather than a manual edit to the generated page.
