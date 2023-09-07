---
uid: Gerrit
---

# Gerrit

Git repositories are hosted by [Gerrit Code Review](https://www.gerritcodereview.com/), a software package used for code reviewing, managing and serving Git repositories, etc. (<https://gerrit.skyline.be>).

In Gerrit, you can see whether the CI/CD pipeline for your development succeeded. In the *Work in Progress* or *Outgoing Reviews* section of the review dashboard, select the item of which you want to see the status. This will open a new page that shows a Jenkins tag:

![](~/develop/images/GerritReviewDashboard.png)<br>
*Gerrit review dashboard*

If the pipeline succeeded, Jenkins will provide a +1 vote for the Jenkins tag.

Gerrit can also be used to perform a code review. However, there are other alternatives for code reviews, such as using the Visual Studio Compare Commits feature, which may be preferable. Using Gerrit for code reviews has the downside of forcing us to squash all the commits, which can in some cases cause your GIT client to get confused about non-existing conflicts.

For more information about Gerrit code reviews, refer to the FAQs:

- [I have finished development of a feature and want this to get reviewed. How do I do this?](xref:FAQ#i-have-finished-development-of-a-feature-and-want-this-to-get-reviewed-how-do-i-do-this)

- [I received an email stating that I should perform a code review. How do I do this?](xref:FAQ#i-received-an-email-stating-that-i-should-perform-a-code-review-how-do-i-do-this)

- [I received an email notifying me that a code review failed. How do I continue?](xref:FAQ#i-received-an-email-notifying-me-that-a-code-review-failed-how-do-i-continue)

- [I received an email notifying me that a code review succeeded. How do I continue?](xref:FAQ#i-received-an-email-notifying-me-that-a-code-review-succeeded-how-do-i-continue)
