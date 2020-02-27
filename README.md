<div id="page-content" class="row no-gutters page-main-content">
            <div id="region-main-box">
                <section id="region-main">
                  <span class="notifications" id="user-notifications"></span>
                  <div role="main" id="yui_3_17_2_1_1582818651653_32"><span id="maincontent"></span><h2 id="yui_3_17_2_1_1582818651653_33">Work Item Management System</h2><div class="box py-3 generalbox center clearfix card-content" id="yui_3_17_2_1_1582818651653_31"><div class="no-overflow" id="yui_3_17_2_1_1582818651653_30"><h3>Functional Requirements</h3>

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
<p>Prepare a list of commands to demonstrate how the program works.</p></div></div><div class="modified">Last modified: Tuesday, 4 February 2020, 8:51 PM</div></div>
                  <div class="course-footer-nav">

    <hr class="hr">

<div class="row">
    <div class="col-sm-12 col-md">        <div class="pull-left">
                <a href="https://learn.telerikacademy.com/mod/workshop/view.php?id=4413&amp;forceview=1" id="prev-activity-link" class="btn btn-link btn btn-secondary" title="Agency (Home)">← Agency (Home)</a>

        </div>
</div>
    <div class="col-sm-12 col-md-2">        <div class="mdl-align">
            <div class="urlselect">
    <form method="post" action="https://learn.telerikacademy.com/course/jumpto.php" class="form-inline" id="url_select_f5e57e2f26b59612">
        <input type="hidden" name="sesskey" value="2yoRjOh0RL">
            <label for="jump-to-activity" class="sr-only">
                Jump to...
            </label>
        <select id="jump-to-activity" class="custom-select urlselect" name="jump">
                    <option value="" selected="">Jump to...</option>
                    <option value="/mod/page/view.php?id=3941&amp;forceview=1">Intro to the Alpha Program</option>
                    <option value="/mod/page/view.php?id=3869&amp;forceview=1">Version Control</option>
                    <option value="/mod/page/view.php?id=3870&amp;forceview=1">Git</option>
                    <option value="/mod/page/view.php?id=3871&amp;forceview=1">Version Control Systems</option>
                    <option value="/mod/page/view.php?id=3872&amp;forceview=1">Git Demo 1</option>
                    <option value="/mod/page/view.php?id=3873&amp;forceview=1">Git Demo 2</option>
                    <option value="/mod/page/view.php?id=3874&amp;forceview=1">Git Demo 3</option>
                    <option value="/mod/page/view.php?id=4056&amp;forceview=1">Git Extensions</option>
                    <option value="/mod/resource/view.php?id=3876&amp;forceview=1">Git In-class Activity</option>
                    <option value="/mod/page/view.php?id=4057&amp;forceview=1">Multidimensional Arrays</option>
                    <option value="/mod/page/view.php?id=4058&amp;forceview=1">Multidimensional Arrays</option>
                    <option value="/mod/page/view.php?id=3888&amp;forceview=1">Getting Started</option>
                    <option value="/mod/page/view.php?id=4074&amp;forceview=1">Strings</option>
                    <option value="/mod/page/view.php?id=3894&amp;forceview=1">Strings</option>
                    <option value="/mod/page/view.php?id=4257&amp;forceview=1">Working with methods</option>
                    <option value="/mod/page/view.php?id=4256&amp;forceview=1">Working with methods</option>
                    <option value="/mod/page/view.php?id=4164&amp;forceview=1">Defining Classes</option>
                    <option value="/mod/page/view.php?id=4165&amp;forceview=1">Defining Classes</option>
                    <option value="/mod/page/view.php?id=4166&amp;forceview=1">Cosmetics 1</option>
                    <option value="/mod/resource/view.php?id=4167&amp;forceview=1">Cosmetics 1</option>
                    <option value="/mod/workshop/view.php?id=4222&amp;forceview=1">Cosmetics 1</option>
                    <option value="/mod/page/view.php?id=4255&amp;forceview=1">Cosmetics 1 (Walk-through)</option>
                    <option value="/mod/page/view.php?id=4225&amp;forceview=1">Active Learning - Presentation</option>
                    <option value="/mod/page/view.php?id=4224&amp;forceview=1">Learning How To Learn_Free Course</option>
                    <option value="/mod/page/view.php?id=4226&amp;forceview=1">Inside the mind of a master procrastinator | Tim Urban</option>
                    <option value="/mod/page/view.php?id=4227&amp;forceview=1">Music and Memory - article</option>
                    <option value="/mod/page/view.php?id=4228&amp;forceview=1">The Speed Camera Lottery - The Fun Theory</option>
                    <option value="/mod/page/view.php?id=4229&amp;forceview=1">The Happiness Advantage: Linking Positive Brains to Performance | TEDxBloomington</option>
                    <option value="/mod/page/view.php?id=4230&amp;forceview=1"> Matt Cutts: Try something new for 30 days | TED</option>
                    <option value="/mod/page/view.php?id=4231&amp;forceview=1">Flash Cards for Programmers</option>
                    <option value="/mod/page/view.php?id=4304&amp;forceview=1">Classes - Part 2</option>
                    <option value="/mod/page/view.php?id=4303&amp;forceview=1">Classes - Part 2</option>
                    <option value="/mod/page/view.php?id=4305&amp;forceview=1">Exceptions</option>
                    <option value="/mod/page/view.php?id=4306&amp;forceview=1">Exceptions</option>
                    <option value="/mod/page/view.php?id=4295&amp;forceview=1">Description (Creatures)</option>
                    <option value="/mod/resource/view.php?id=4296&amp;forceview=1">Creatures</option>
                    <option value="/mod/workshop/view.php?id=4298&amp;forceview=1">Creatures</option>
                    <option value="/mod/page/view.php?id=4301&amp;forceview=1">Generic Collections</option>
                    <option value="/mod/page/view.php?id=4302&amp;forceview=1">Generic Collections</option>
                    <option value="/mod/page/view.php?id=4323&amp;forceview=1">Personal Effectiveness  - Presentation</option>
                    <option value="/mod/page/view.php?id=4333&amp;forceview=1">Productivity Hacks - Buddy Group Presentation</option>
                    <option value="/mod/page/view.php?id=4334&amp;forceview=1">How to Make Stress Your Friend | Kelly McGonigal</option>
                    <option value="/mod/page/view.php?id=4331&amp;forceview=1">Resources</option>
                    <option value="/mod/page/view.php?id=4344&amp;forceview=1">Generic List</option>
                    <option value="/mod/resource/view.php?id=4343&amp;forceview=1">Generic List</option>
                    <option value="/mod/workshop/view.php?id=4345&amp;forceview=1">Generic List (In Class)</option>
                    <option value="/mod/workshop/view.php?id=4346&amp;forceview=1">Generic List (Home)</option>
                    <option value="/mod/page/view.php?id=4368&amp;forceview=1">Encapsulation</option>
                    <option value="/mod/page/view.php?id=4369&amp;forceview=1">Inheritance</option>
                    <option value="/mod/page/view.php?id=4365&amp;forceview=1">Abstraction</option>
                    <option value="/mod/page/view.php?id=4366&amp;forceview=1">Polymorphism</option>
                    <option value="/mod/page/view.php?id=4367&amp;forceview=1">Abstraction &amp; Polymorphism</option>
                    <option value="/mod/page/view.php?id=4370&amp;forceview=1">Polymorphism Exercise</option>
                    <option value="/mod/page/view.php?id=4358&amp;forceview=1">Cosmetics 2</option>
                    <option value="/mod/resource/view.php?id=4359&amp;forceview=1">Cosmetics 2</option>
                    <option value="/mod/workshop/view.php?id=4377&amp;forceview=1">Cosmetics 2 (In Class)</option>
                    <option value="/mod/workshop/view.php?id=4378&amp;forceview=1">Cosmetics 2 (Home)</option>
                    <option value="/mod/resource/view.php?id=4360&amp;forceview=1">Project Solution (Cosmetics - Part 2)</option>
                    <option value="/mod/feedback/view.php?id=4363&amp;forceview=1">Survey</option>
                    <option value="/mod/page/view.php?id=4389&amp;forceview=1">Agile Thinking - Presentation</option>
                    <option value="/mod/quiz/view.php?id=4385&amp;forceview=1">OOP Knowlege Check</option>
                    <option value="/mod/url/view.php?id=4384&amp;forceview=1">Technical Questions</option>
                    <option value="/mod/page/view.php?id=4391&amp;forceview=1">Olympics</option>
                    <option value="/mod/url/view.php?id=4408&amp;forceview=1">Olympics - Skeleton</option>
                    <option value="/mod/url/view.php?id=4410&amp;forceview=1">Olympics - Solution</option>
                    <option value="/mod/page/view.php?id=4411&amp;forceview=1">Olympics - Tutorial</option>
                    <option value="/mod/workshop/view.php?id=4393&amp;forceview=1">Olympics (In Class)</option>
                    <option value="/mod/workshop/view.php?id=4394&amp;forceview=1">Olympics (Home)</option>
                    <option value="/mod/page/view.php?id=4415&amp;forceview=1">Agency</option>
                    <option value="/mod/url/view.php?id=4420&amp;forceview=1">Agency - Skeleton</option>
                    <option value="/mod/url/view.php?id=4419&amp;forceview=1">Agency - Solution</option>
                    <option value="/mod/workshop/view.php?id=4412&amp;forceview=1">Agency (In Class)</option>
                    <option value="/mod/workshop/view.php?id=4413&amp;forceview=1">Agency (Home)</option>
                    <option value="/mod/page/view.php?id=4422&amp;forceview=1">Teamwork Guidelines</option>
                    <option value="/mod/resource/view.php?id=4421&amp;forceview=1">Work Item Management System Class Diagram</option>
                    <option value="/mod/page/view.php?id=4539&amp;forceview=1">Extension Methods, Delegates &amp; Deep Dive</option>
                    <option value="/mod/page/view.php?id=4540&amp;forceview=1">Extension Methods &amp; Delegates</option>
                    <option value="/mod/page/view.php?id=4541&amp;forceview=1">Deep Dive</option>
                    <option value="/mod/page/view.php?id=4538&amp;forceview=1">Lambda &amp; LINQ</option>
                    <option value="/mod/page/view.php?id=4542&amp;forceview=1">Lambda &amp; LINQ</option>
                    <option value="/mod/url/view.php?id=4544&amp;forceview=1">Description and Project Template</option>
        </select>
            <noscript>
                <input type="submit" class="btn btn-secondary" value="Go">
            </noscript>
    </form>
</div>

        </div>
</div>
    <div class="col-sm-12 col-md">        <div class="pull-right">
                <a href="https://learn.telerikacademy.com/mod/page/view.php?id=4422&amp;forceview=1" id="next-activity-link" class="btn btn-link btn btn-secondary" title="Teamwork Guidelines">Teamwork Guidelines →</a>

        </div>
</div>
</div>
</div>
                  
                </section>
            </div>
        </div>