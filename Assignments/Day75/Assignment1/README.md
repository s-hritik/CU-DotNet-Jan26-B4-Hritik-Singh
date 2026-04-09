This assignment is designed to guide participants through the structural hierarchy of Azure Boards. It focuses on translating project requirements into a functional backlog using the standard Agile hierarchy.

Assignment: Project Planning & Backlog Management in Azure Boards
Objective
To transform project requirements into a structured hierarchy within Azure Boards, ensuring clear traceability from high-level goals (Epics) down to individual work items (Tasks).
Prerequisites
Access to an existing Azure DevOps Project.
A pre-allocated project theme (e.g., E-Commerce Platform, Inventory Management, or Learning Management System).
Basic understanding of the Agile process template.

Task 1: Establish the Hierarchy
Navigate to Boards > Work Items and create the following structure. Ensure each child item is properly linked to its parent using the "Parent" field.

1. Create the Epic (The "Big Picture")
   Title: Create one Epic representing a major functional area of your project.
   Example: "User Authentication & Profile Management" or "Payment Gateway Integration."
   Details: Provide a high-level description and set the Priority to 1.
2. Define Features (The Deliverables)
   Create two Features that contribute to the completion of the Epic.
   Example: "Social Media Login Implementation" and "User Profile Dashboard."
   Linkage: Set the Parent of these Features to the Epic created in step 1.
3. Draft User Stories (The Requirement)
   For each Feature, create two User Stories.
   Format: Use the standard persona-based format:
   "As a [User], I want to [Action], so that [Value/Benefit]."
   Acceptance Criteria: List at least three checkboxes (using Markdown) that define when the story is considered "Done."
4. Break Down into Tasks (The Execution)
   For every User Story, define at least three technical Tasks.
   Example: "Design SQL Schema," "Create API Endpoint," "Write Unit Tests."
   Estimation: Assign Original Estimate (in hours) to each task.

Task 2: Board Configuration & Organization
Assign Ownership: Assign all Work Items to the respective team members allocated to the project.
Iteration Paths: Assign the User Stories and Tasks to Sprint 1.
Tags: Add a #MVP (Minimum Viable Product) tag to at least one User Story.
Visual Tracking: Navigate to Boards > Board and move one User Story to the "Active" column to simulate progress.

Submission Deliverables
Participants must provide:
The Hierarchy Query: A screenshot of a "Tree of Work Items" query showing the nested Epic $\rightarrow$ Feature $\rightarrow$ Story $\rightarrow$ Task relationship.
The Backlog View: A screenshot of the Backlog view with the Parents column enabled.
