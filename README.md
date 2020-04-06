<div id="page-content" class="row no-gutters page-main-content">
            <div id="region-main-box">
                <section id="region-main">
                  <span class="notifications" id="user-notifications"></span>
                  <div role="main" id="yui_3_17_2_1_1582818651653_32"><span id="maincontent"></span><h2 id="yui_3_17_2_1_1582818651653_33">Work Item Management System</h2><div class="box py-3 generalbox center clearfix card-content" id="yui_3_17_2_1_1582818651653_31"><div class="no-overflow" id="yui_3_17_2_1_1582818651653_30"><p>
Trello board: https://trello.com/b/7PI0mT8d/oop-teamtk
</p><h3>Functional Requirements</h3>

<p>
    Application should support multiple teams. Each team has name, members and boards.
</p>
<br>
<p>
    <b>Member</b> has name, list of work items and activity history.
    </p><ul>
        <li>Name should be unique in the application.</li>
        <li>Name is a string between 5 and 15 symbols.</li>
    </ul>
<p></p>

<p>
    <b>Board</b> has name, list of work items and activity history.
    </p><ul>
        <li>Name should be unique in the team.</li>
        <li>Name is a string between 5 and 10 symbols.</li>
    </ul>
<p></p>

<p>
    There are 3 types of work items: <b>Bug</b>, <b>Story</b> and <b>Feedback</b>.
</p>
<br>
<p>
    <b>Bug</b> has ID, title, description, steps to reproduce, priority, severity, status, assignee, comments and
    history.
    </p><ul>
        <li>Title is a string between 10 and 50 symbols.</li>
        <li>Description is a string between 10 and 500 symbols.</li>
        <li>Steps to reproduce is a list of strings.</li>
        <li>Priority is one of the following: [High, Medium, Low]</li>
        <li>Severity is one of the following: [Critical, Major, Minor]</li>
        <li>Status is one of the following: [Active, Fixed]</li>
        <li>Assignee is a member from the team.</li>
        <li>Comments is a list of comments (string messages with author).</li>
        <li>History is a list of all changes (string messages) that were done to the bug.</li>
    </ul>
<p></p>

<p>
    <b>Story</b> has ID, title, description, priority, size, status, assignee, comments and history.
    </p><ul>
        <li>Title is a string between 10 and 50 symbols.</li>
        <li>Description is a string between 10 and 500 symbols.</li>
        <li>Priority is one of the following: [High, Medium, Low]</li>
        <li>Size is one of the following: [Large, Medium, Small]</li>
        <li>Status is one of the following: [NotDone, InProgress, Done]</li>
        <li>Assignee is a member from the team.</li>
        <li>Comments is a list of comments (string messages with author).</li>
        <li>History is a list of all changes (string messages) that were done to the story.</li>
    </ul>
<p></p>

<p>
    <b>Feedback</b> has ID, title, description, rating, status, comments and history.
    </p><ul>
        <li>Title is a string between 10 and 50 symbols.</li>
        <li>Description is a string between 10 and 500 symbols.</li>
        <li>Rating is an integer.</li>
        <li>Status is one of the following: [New, Unscheduled, Scheduled, Done]</li>
        <li>Comments is a list of comments (string messages with author).</li>
        <li>History is a list of all changes (string messages) that were done to the feedback.</li>
    </ul>
<p></p>

<p>
    <b>Note:</b>
    </p><p>IDs of work items should be unique in the application i.e. if we have a bug with ID X then we can't have
        Story of Feedback with ID X.
    </p>
<p></p>
<br>
<p>
    Application should support the following operations:
    </p><ul>
        <li>Create a new person</li>
        <li>Show all people</li>
        <li>Show person's activity</li>
        <li>Create a new team</li>
        <li>Show all teams</li>
        <li>Show team's activity</li>
        <li>Add person to team</li>
        <li>Show all team members</li>
        <li>Create a new board in a team</li>
        <li>Show all team boards</li>
        <li>Show board's activity</li>
        <li>Create a new Bug/Story/Feedback in a board</li>
        <li>Change Priority/Severity/Status of a bug</li>
        <li>Change Priority/Size/Status of a story</li>
        <li>Change Rating/Status of a feedback</li>
        <li>Assign/Unassign work item to a person</li>
        <li>Add comment to a work item</li>
        <li>List work items with options:</li>
        <ul>
            <li>List all</li>
            <li>Filter bugs/stories/feedback only</li>
            <li>Filter by status and/or assignee</li>
            <li>Sort by title/priority/severity/size/rating</li>
        </ul>
    </ul>
<p></p>

<h3>General Requirements</h3>
<p>
    </p><ul>
        <li><b>Follow the OOP best practices:</b></li>
        <li>
            <ul>
                <li>Use data encapsulation</li>
                <li>Properly use inheritance and polymorphism</li>
                <li>Properly use interfaces and abstract classes</li>
                <li>Properly use static members</li>
                <li>Properly use enums</li>
                <li>Follow the principles of strong cohesion and loose coupling</li>
            </ul>
        </li>
        <li>Use LINQ Extension methods</li>
        <li>Implement proper user input validation and display meaningful user messages</li>
        <li>Implement proper exception handling</li>
        <li>Use Git to keep your source code and for team collaboration </li>
    </ul>
<p></p>

<h3>Teamwork Requirements &amp; Guidelines</h3>
<p>Use the <a href="https://learn.telerikacademy.com/mod/page/view.php?id=4422">Teamwork Requirements &amp; Guidelines Page</a> for instructions on how to better plan and prioritize features with your teammate.</p>
<br>

<h3>Teamwork Defense</h3>
<p>Prepare a list of commands to demonstrate how the program works.</p></div></div>