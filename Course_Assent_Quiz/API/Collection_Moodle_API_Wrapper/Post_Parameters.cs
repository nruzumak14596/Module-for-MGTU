using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
	public class Post_Parameters
	{
		public static Dictionary<string, string> URL = new Dictionary<string, string>
		{
			{ "username", "username" },
			{ "password", "password" },
			{ "service", "service" },
			{ "wstoken", "wstoken" },
			{ "wsfunction", "wsfunction" },
			{ "moodlewsrestformat", "moodlewsrestformat" },
			{ "userid", "userid" },
            { "useridto", "useridto"},
			{ "groupid", "groupid" },
			{ "courseid", "courseid" },
			{ "forumid", "forumid" },
            { "choiceid", "choiceid" },
			{ "discussionid", "discussionid"},
			{ "courseids[0]", "courseids[0]"},
            { "responses[0]", "responses[0]"},
			{ "assignid", "assignid"},
            { "bookid", "bookid"}

		};
	}
}