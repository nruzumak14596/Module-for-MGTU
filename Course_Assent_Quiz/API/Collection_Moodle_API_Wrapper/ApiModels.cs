using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    public class ApiModels
    {
        public interface IDataModel{}

        public interface ICloneable
        {
            object Clone();
        }


        #region Assign

        #region Mod_assign_get_assignments

        public class Core_files_upload : ICloneable
        {
            public int contextid { get; set; }
            public string component { get; set; }
            public string filearea { get; set; }
            public int itemid { get; set; }
            public string filepath { get; set; }
            public string filename { get; set; }
            public string url { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Core_files_upload( int contextid, string component, string filearea, int itemid,
                                        string filepath, string filename, string url )
            {
                this.contextid = contextid;
                this.component = component;
                this.filearea = filearea;
                this.itemid = itemid;
                this.filepath = filepath;
                this.filename = filename;
                this.url = url;
            }
        }

        public class Onlinetext_editor
        {
            public string text;
            public int format;
            public int itemid; 
        }

        public class Plugindata
        {
            public Assignfeedbackcomments_editor assignfeedbackcomments_editor { get; set;}
            public Onlinetext_editor onlinetext_editor { get; set; }
            public int files_filemanager { get; set; }
        }

        public class Assignfeedbackcomments_editor
        {
            public string text;
            public int format;
        }

        public class Core_user_get_user : ICloneable, IDataModel
        {
            public List<Users> users { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Core_user_get_user( List<Users> users, List<Object> warnings )
            {
                this.users = users;
                this.warnings = warnings;
            }
        }

        public class Comment : ICloneable, IDataModel
        {
            public int id { get; set; }
            public string content { get; set; }
            public int format { get; set; }
            public int timecreated { get; set; }
            public string strftimeformat { get; set; }
            public string profileurl { get; set; }
            public string fullname { get; set; }
            public string time { get; set; }
            public string avatar { get; set; }
            public int userid { get; set; }
            //public int delete { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Comment( int id, string content, int format, int timecreated, string strftimeformat,
                              string profileurl, string fullname, string time, string avatar, int userid)
            {
                this.id = id;
                this.content = content;
                this.format = format;
                this.timecreated = timecreated;
                this.strftimeformat = strftimeformat;
                this.profileurl = profileurl;
                this.fullname = fullname;
                this.time = time;
                this.avatar = avatar;
                this.userid = userid;
                //this.delete = delete;
            }
        }
        public class Users : ICloneable
        {
            public int id { get; set; }
            public string fullname { get; set; }
            public string profileimageurlsmall { get; set; }
            public string profileimageurl { get; set; }
            public string type { get; set; }
            public string value { get; set; }
            public string name { get; set; }
            public string shortname { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Users( int id, string fullname, string profileimageurlsmall, string profileimageurl, string type, string value,
                           string name, string shortname )
            {
                this.id = id;
                this.fullname = fullname;
                this.profileimageurlsmall = profileimageurlsmall;
                this.profileimageurl = profileimageurl;
                this.type = type;
                this.value = value;
                this.name = name;
                this.shortname = shortname;
            }
        }
        public class Core_comment_get_comments : ICloneable, IDataModel
        {
            public List<Comment> comments { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Core_comment_get_comments(List<Comment> comments, List<object> warnings )
            {
                this.comments = comments;
                this.warnings = warnings;
            }
        }

        public class Config : ICloneable, IDataModel
        {
            public string plugin { get; set; }
            public string subtype { get; set; }
            public string name { get; set; }
            public string value { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Config(string plugin, string subtype, string name, string value)
            {
                this.plugin = plugin;
                this.subtype = subtype;
                this.name = name;
                this.value = value;
            }
        }
        public class Introattachments : ICloneable, IDataModel
        {
            public string filename { get; set; }
            public string filepath { get; set; }
            public int filesize { get; set; }
            public string fileurl { get; set; }
            public int timemodified { get; set; }
            public string mimetype { get; set; }
            public bool isexternalfile { get; set; }
            public string repositorytype { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Introattachments(string filename, string filepath, int filesize,
                                string fileurl, int timemodified, string mimetype,
                                bool isexternalfile, string repositorytype)
            {
                this.filename = filename;
                this.filepath = filepath;
                this.filesize = filesize;
                this.fileurl = fileurl;
                this.timemodified = timemodified;
                this.mimetype = mimetype;
                this.isexternalfile = isexternalfile;
                this.repositorytype = repositorytype;
            }
        }
        public class Introfiles : ICloneable, IDataModel
        {
            public string filename { get; set; }
            public string filepath { get; set; }
            public int filesize { get; set; }
            public string fileurl { get; set; }
            public int timemodified { get; set; }
            public string mimetype { get; set; }
            public bool isexternalfile { get; set; }
            public string repositorytype { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Introfiles(string filename, string filepath, int filesize,
                                string fileurl, int timemodified, string mimetype,
                                bool isexternalfile, string repositorytype)
            {
                this.filename = filename;
                this.filepath = filepath;
                this.filesize = filesize;
                this.fileurl = fileurl;
                this.timemodified = timemodified;
                this.mimetype = mimetype;
                this.isexternalfile = isexternalfile;
                this.repositorytype = repositorytype;
            }
        }
       
        public class Mod_assign_get_submission_status : ICloneable, IDataModel
        {
            public Gradingsummary gradingsummary { get; set; }
            public Lastattempt lastattempt { get; set; }
            public Feedbackattempt feedback { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_get_submission_status( Gradingsummary gradingsummary,Lastattempt lastattempt,
                                                       Feedbackattempt feedback, List<object> warnings)
            {
                this.gradingsummary = gradingsummary;
                this.lastattempt = lastattempt;
                this.feedback = feedback;
                this.warnings = warnings;
            }
        }

        public class Filearea2 : ICloneable
        {
            public string area { get; set; }
            public List<object> files { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Filearea2(string area, List<object> files)
            {
                this.area = area;
                this.files = files;
            }
        }

        public class Plugins : ICloneable
        {
            public string type { get; set; }
            public string name { get; set; }
            public List<Editorfield> editorfields { get; set; }
            public List<Filearea> fileareas { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Plugins( string type, string name, List<Editorfield> editorfields, List<Filearea> fileareas )
            {
                this.type = type;
                this.name = name;
                this.editorfields = editorfields;
                this.fileareas = fileareas;
            }
        }

        public class Gradeattempt : ICloneable
        {
            public int id { get; set; }
            public int assignment { get; set; } 
            public int userid { get; set; }
            public int attemptnumber { get; set; }
            public int timecreated { get; set; }
            public int timemodified { get; set; }
            public int grader { get; set; } 
            public string grade { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Gradeattempt(int id, int assignment, int userid, int attemptnumber, int timecreated,
                                  int timemodified, int grader, object grade)
            {
                this.id = id;
                this.assignment = assignment;
                this.userid = userid;
                this.attemptnumber = attemptnumber;
                this.timecreated = timecreated;
                this.timemodified = timemodified;
                this.grader = grader;
                if (grade != null)
                {
                    this.grade = Convert.ToString(grade);
                }
                    
            }
        }

        public class Feedbackattempt : ICloneable
        {
            public Gradeattempt grade { get; set; } 
            public string gradefordisplay { get; set; }
            public int gradeddate { get; set; }
            public List<Plugins> plugins { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Feedbackattempt(Gradeattempt grade, object gradefordisplay, object gradeddate, List<Plugins> plugins)
            {
                if ( gradefordisplay != null )
                {
                    this.gradefordisplay = Convert.ToString(gradefordisplay);
                }
                if ( gradeddate != null )
                {
                    this.gradeddate = Convert.ToInt32(gradeddate);
                }
                this.grade = grade;
                this.plugins = plugins;
            }
        }

        public class Lastattempt : ICloneable //последняя попытка
        {
            public Submission submission { get; set; }
            public List<object> submissiongroupmemberswhoneedtosubmit { get; set; }
            public bool submissionsenabled { get; set; }
            public bool locked { get; set; }
            public bool graded { get; set; }
            public bool canedit { get; set; }
            public bool caneditowner { get; set; }
            public bool cansubmit { get; set; }
            //public int extensionduedate { get; set; }
            public object extensionduedate { get; set; }
            public bool blindmarking { get; set; }
            public string gradingstatus { get; set; }
            public List<int> usergroups { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Lastattempt(Submission submission, List<object> submissiongroupmemberswhoneedtosubmit, bool submissionsenabled,
                                 bool locked, bool graded, bool canedit, bool caneditowner, bool cansubmit, object extensionduedate,
                                 bool blindmarking, string gradingstatus, List<int> usergroups)
            {
                this.submission = submission;
                this.submissiongroupmemberswhoneedtosubmit = submissiongroupmemberswhoneedtosubmit;
                this.submissionsenabled = submissionsenabled;
                this.locked = locked;
                this.graded = graded;
                this.canedit = canedit;
                this.caneditowner = caneditowner;
                this.cansubmit = cansubmit;
                this.extensionduedate = extensionduedate;
                this.blindmarking = blindmarking;
                this.gradingstatus = gradingstatus;
                this.usergroups = usergroups;
            }
        }

        public class Gradingsummary : ICloneable, IDataModel
        {
            public int participantcount { get; set; }
            public int submissiondraftscount { get; set; }
            public bool submissionsenabled { get; set; }
            public int submissionssubmittedcount { get; set; }
            public int submissionsneedgradingcount { get; set; }
            public bool warnofungroupedusers { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Gradingsummary( int participantcount, int submissiondraftscount, bool submissionsenabled,
                                    int submissionssubmittedcount, int submissionsneedgradingcount, bool warnofungroupedusers )
            {
                this.participantcount = participantcount;
                this.submissiondraftscount = submissiondraftscount;
                this.submissionsenabled = submissionsenabled;
                this.submissionssubmittedcount = submissionssubmittedcount;
                this.submissionsneedgradingcount = submissionsneedgradingcount;
                this.warnofungroupedusers = warnofungroupedusers;
            }
        }

        public class Mappings : ICloneable, IDataModel
        {
            public int id { get; set; }
            public int userid { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]

            internal Mappings(int id, int userid)
            {
                this.id = id;
                this.userid = userid;
            }
        }

        public class Mod_assign_view_grading_table : ICloneable, IDataModel
        {
            int status { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_view_grading_table( List<object> warnings, int status )
            {
                this.status = status;
                this.warnings = warnings;
            }
        }
        
        public class Mod_assign_view_submission_status : ICloneable, IDataModel
        {
            int status { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_view_submission_status( List<object> warnings, int status )
            {
                this.status = status;
                this.warnings = warnings;
            }
        }

        public class Mod_assign_view_assign : ICloneable, IDataModel
        {
            int status { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_view_assign( List<object> warnings, int status )
            {
                this.status = status;
                this.warnings = warnings;
            }
        }

        public class Mod_assign_unlock_submissions : ICloneable, IDataModel
        {
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_unlock_submissions( List<object> warnings )
            {
                this.warnings = warnings;
            }
        }

        public class Mod_assign_submit_for_grading : ICloneable, IDataModel
        {
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_submit_for_grading( List<object> warnings )
            {
                this.warnings = warnings;
            }
        }

        public class Mod_assign_submit_grading_form : ICloneable, IDataModel
        {
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_submit_grading_form( List<object> warnings )
            {
                this.warnings = warnings;
            }
        }

        public class Mod_assign_get_user_mappings : ICloneable
        {
            public List<Assignment> assignments { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_get_user_mappings(List<Assignment> assignments, List<object> warnings)
            {
                this.assignments = assignments;
                this.warnings = warnings;
            }
        }

        public class Assignment : ICloneable, IDataModel
        {
            public int id { get; set; }
            public List<Submission> submissions { get; set; }
            public List<Mappings> mappings { get; set; }// 
            public int assignmentid { get; set; } //
            public List<Userflags> userflags { get; set; } //
            public int cmid { get; set; }
            public int course { get; set; }
            public string name { get; set; }
            public int nosubmissions { get; set; }
            public int submissiondrafts { get; set; }
            public int sendnotifications { get; set; }
            public int sendlatenotifications { get; set; }
            public int sendstudentnotifications { get; set; }
            public int duedate { get; set; }
            public int allowsubmissionsfromdate { get; set; }
            public int grade { get; set; }
            public int timemodified { get; set; }
            public int completionsubmit { get; set; }
            public int cutoffdate { get; set; }
            public int gradingduedate { get; set; }
            public int teamsubmission { get; set; }
            public int requireallteammemberssubmit { get; set; }
            public int teamsubmissiongroupingid { get; set; }
            public int blindmarking { get; set; }
            public int revealidentities { get; set; }
            public string attemptreopenmethod { get; set; }
            public int maxattempts { get; set; }
            public int markingworkflow { get; set; }
            public int markingallocation { get; set; }
            public int requiresubmissionstatement { get; set; }
            public int preventsubmissionnotingroup { get; set; }
            public string submissionstatement { get; set; }
            public int submissionstatementformat { get; set; }
            public List<Config> configs { get; set; }
            public string intro { get; set; }
            public int introformat { get; set; }
            public List<Introfiles> introfiles { get; set; }
            public List<Introattachments> introattachments { get; set; }
            //public List<object> introfiles { get; set; }
            //public List<object> introattachments { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Assignment(int id, int assignmentid, List<Mappings> mappings, List<Userflags> userflags , int cmid, int course, string name,
                                int nosubmissions, int submissiondrafts,
                                int sendnotifications, int sendlatenotifications,
                                   int duedate, int allowsubmissionsfromdate, int grade,
                                  int timemodified, int completionsubmit, int cutoffdate,
                                int gradingduedate, int teamsubmission, int requireallteammemberssubmit,
                                   int teamsubmissiongroupingid, int blindmarking, int revealidentities,
                                string attemptreopenmethod, int maxattempts, int markingworkflow,
                                   int markingallocation, int requiresubmissionstatement, int preventsubmissionnotingroup,
                                   string submissionstatement, int submissionstatementformat, List<Config> configs,
                                   string intro, int introformat, List<Introfiles> introfiles, List<Introattachments> introattachments,
                                List<Submission> submissions )
            {
                this.id = id;
                this.submissions = submissions;
                this.assignmentid = assignmentid;//
                this.mappings = mappings; //
                this.userflags = userflags;//
                this.cmid = cmid;
                this.course = course;
                this.name = name;
                this.nosubmissions = nosubmissions;
                this.submissiondrafts = submissiondrafts;
                this.sendnotifications = sendnotifications;
                this.sendlatenotifications = sendlatenotifications;
                this.duedate = duedate;
                this.allowsubmissionsfromdate = allowsubmissionsfromdate;
                this.grade = grade;
                this.timemodified = timemodified;
                this.completionsubmit = completionsubmit;
                this.cutoffdate = cutoffdate;
                this.gradingduedate = gradingduedate;
                this.teamsubmission = teamsubmission;
                this.requireallteammemberssubmit = requireallteammemberssubmit;
                this.teamsubmissiongroupingid = teamsubmissiongroupingid;
                this.blindmarking = blindmarking;
                this.revealidentities = revealidentities;
                this.attemptreopenmethod = attemptreopenmethod;
                this.maxattempts = maxattempts;
                this.markingworkflow = markingworkflow;
                this.markingallocation = markingallocation;
                this.requiresubmissionstatement = requiresubmissionstatement;
                this.preventsubmissionnotingroup = preventsubmissionnotingroup;
                this.submissionstatement = submissionstatement;
                this.submissionstatementformat = submissionstatementformat;
                this.configs = configs;
                this.intro = intro;
                this.introformat = introformat;
                this.introfiles = introfiles;
                this.introattachments = introattachments;
            }
        }
        
        public class Userflags : ICloneable, IDataModel
        {
            public int id { get; set; }   //user flag id
            public int userid { get; set; }  //student id
            public int locked { get; set; }   //locked
            public int mailed { get; set; }   //mailed
            public int extensionduedate { get; set; }  //extension due date
            public int allocatedmarker { get; set; }   //allocated marker

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Userflags( int id, int userid, int locked, int mailed, int extensionduedate, int allocatedmarker)
            {
                this.id = id;
                this.locked = locked;
                this.mailed = mailed;
                this.extensionduedate = extensionduedate;
                this.allocatedmarker = allocatedmarker;      
            }
        }

        public class Mod_assign_lock_submissions : ICloneable, IDataModel 
        {
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_lock_submissions( List<object> warnings )
            {
                this.warnings = warnings;
            }
        }

        public class Mod_assign_set_user_flags : ICloneable, IDataModel
        {
            public List<Userflags> userflags { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_set_user_flags( List<Userflags> userflags )
            {
                this.userflags = userflags;
            }
        }

        public class Mod_assign_save_user_extensions : ICloneable, IDataModel
        {
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_save_user_extensions( List<object> warnings )
            {
                this.warnings = warnings;
            }
        }

        public class Mod_assign_save_grade : ICloneable, IDataModel
        {
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        public class Mod_assign_save_grades : ICloneable, IDataModel
        {
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        public class Mod_assign_save_submission : ICloneable, IDataModel
        {
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        public class Mod_assign_revert_submissions_to_draft : ICloneable, IDataModel
        {
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_revert_submissions_to_draft( List<object> warnings )
            {
                this.warnings = warnings;
            }
        }



        public class Mod_assign_reveal_identities : ICloneable, IDataModel
        {
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_reveal_identities( List<object> warnings )
            {
                this.warnings = warnings;
            }
        }

        public class Mod_assign_list_participants : ICloneable, IDataModel //не все переменные
        {
            public int id { get; set; }
            public string fullname { get; set; }
            public string profileimageurlsmall { get; set; }
            public string profileimageurl { get; set; }
            public string type { get; set; }
            public string value { get; set; }
            public string name { get; set; }
            public string shortname { get; set; }
            public bool submitted { get; set; }
            public bool requiregrading { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_list_participants ( int id, string fullname, string profileimageurlsmall, string profileimageurl, 
                                                    string type, string value, string name, string shortname, bool submitted,
                                                    bool requiregrading )
            {
                this.id = id;
                this.fullname = fullname;
                this.profileimageurlsmall = profileimageurlsmall;
                this.profileimageurl = profileimageurl;
                this.type = type;
                this.value = value;
                this.name = name;
                this.shortname = shortname;
                this.submitted = submitted;
                this.requiregrading = requiregrading;
            }
        }

        

        public class Cours : ICloneable, IDataModel
        {
            public int id { get; set; }
            public string fullname { get; set; }
            public string shortname { get; set; }
            public int timemodified { get; set; }
            public List<Assignment> assignments { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Cours(int id, string fullname, string shortname, int timemodified, List<Assignment> assignments)
            {
                this.id = id;
                this.fullname = fullname;
                this.shortname = shortname;
                this.timemodified = timemodified;
                this.assignments = assignments;
            }
        }

        public class Mod_assign_get_grades : ICloneable, IDataModel
        {
            public List<Assignment> assigment { get; set; }
            public List<object> warnings { get; set; }

            public object Clone ()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_get_grades(List<Assignment> assigments, List<object> warnings)
            {
                this.assigment = assigment;
                this.warnings = warnings;
            }

        }

        public class Mod_assign_get_participant : ICloneable, IDataModel
        {
            public int id { get; set; }
            public string fullname { get; set; }
            public bool submitted { get; set; }
            public bool requiregrading { get; set; }
            public bool grantedextension { get; set; }
            public bool blindmarking { get; set; }
            public int allowsubmissionsfromdate { get; set; }
            public int duedate { get; set; }
            public int cutoffdate { get; set; }
            public string duedatestr { get; set; }
            public int groupid { get; set; }
            public string groupname { get; set; }
            public Users user { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_get_participant( int id, string fullname, bool submitted, bool requiregrading, bool grantedextension,
                bool blindmarking, int allowsubmissionsfromdate, int duedate, int cutoffdate, string duedatestr,
                int groupid, string groupnameUsers, Users user)
            {
                this.id = id;
                this.fullname = fullname;
                this.submitted = submitted;
                this.requiregrading = requiregrading;
                this.grantedextension = grantedextension;
                this.blindmarking = blindmarking;
                this.allowsubmissionsfromdate = allowsubmissionsfromdate;
                this.duedate = duedate;
                this.cutoffdate = cutoffdate;
                this.duedatestr = duedatestr;
                this.groupid = groupid;
                this.groupname = groupname;
                this.user = user;
            }

        }
        public class Mod_assign_copy_previous_attempt : ICloneable, IDataModel
        {
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_copy_previous_attempt(List<object> warnings)
            {
                this.warnings = warnings;
            }
        }

        public class Core_user_get_users_by_field : ICloneable, IDataModel
        {
            public List<Users> user { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Core_user_get_users_by_field( List<Users> user )
            {
                this.user = user;
            }
        }

        public class Mod_assign_get_assignments : ICloneable, IDataModel
        {
            public List<Cours> courses { get; set; } //курсы
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_get_assignments(List<Cours> courses, List<object> warnings)
            {
                this.courses = courses;
                this.warnings = warnings;
            }
        }

        public class Mod_assign_get_user_flags : ICloneable, IDataModel
        {
            public List<Assignment> assignments { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_get_user_flags ( List<Assignment> assignments, List<object> warnings )
            {
                this.assignments = assignments;
                this.warnings = warnings;
            }
        }

        public class Mod_assign_get_submissions : ICloneable, IDataModel
        {
            public List<Assignment> assignments { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_get_submissions( List<Assignment> assignments, List<object> warnings )
            {
                this.assignments = assignments;
                this.warnings = warnings;
            }
        }

        public class Mod_assign_get_status_plugin : ICloneable, IDataModel
        {
            public Lastattempt_Status_Plugin lastattempt { get; set; }
            public Feedback_Status_Plugin feedback { get; set; }
            public List<object> warnings { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Mod_assign_get_status_plugin(Lastattempt_Status_Plugin lastattempt, Feedback_Status_Plugin feedback, List<object> warnings)
            {
                this.lastattempt = lastattempt;
                this.feedback = feedback;
                this.warnings = warnings;
            }
        }

        public class Grade_Status_Plugin : ICloneable, IDataModel
        {
            public int id { get; set; }
            public int assignment { get; set; }
            public int userid { get; set; }
            public int attemptnumber { get; set; }
            public int timecreated { get; set; }
            public int timemodified { get; set; }
            public int grader { get; set; }
            public string grade { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Grade_Status_Plugin(int id, int assignment, int userid, int attemptnumber, int timecreated,
                                         int timemodified, int grader, string grade)
            {
                this.id = id;
                this.assignment = assignment;
                this.userid = userid;
                this.attemptnumber = attemptnumber;
                this.timecreated = timecreated;
                this.timemodified = timemodified;
                this.grader = grader;
                this.grade = grade;
            }
        }

        public class Feedback_Status_Plugin : ICloneable, IDataModel
        {
            public Grade_Status_Plugin grade { get; set; }
            public string gradefordisplay { get; set; }
            public int gradeddate { get; set; }
            public List<Plugin2_Status_Plugin> plugins { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Feedback_Status_Plugin(Grade_Status_Plugin grade, string gradefordisplay,
                                            int gradeddate, List<Plugin2_Status_Plugin> plugins)
            {
                this.grade = grade;
                this.gradefordisplay = gradefordisplay;
                this.gradeddate = gradeddate;
                this.plugins = plugins;
            }
        }

        public class Editorfield_Status_Plugin : ICloneable, IDataModel
        {
            public string name { get; set; }
            public string description { get; set; }
            public string text { get; set; }
            public int format { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Editorfield_Status_Plugin(string name, string description, string text, int format)
            {
                this.name = name;
                this.description = description;
                this.text = text;
                this.format = format;
            }
        }

        public class Filearea2_Status_Plugin : ICloneable, IDataModel
        {
            public string area { get; set; }
            public List<object> files { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Filearea2_Status_Plugin(string area, List<object> files)
            {
                this.area = area;
                this.files = files;
            }
        }

        public class Plugin2_Status_Plugin : ICloneable, IDataModel
        {
            public string type { get; set; }
            public string name { get; set; }
            public List<Editorfield_Status_Plugin> editorfields { get; set; }
            public List<Filearea2_Status_Plugin> fileareas { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Plugin2_Status_Plugin(string type, string name, List<Editorfield_Status_Plugin> editorfields,
                                           List<Filearea2_Status_Plugin> fileareas)
            {
                this.type = type;
                this.name = name;
                this.editorfields = editorfields;
                this.fileareas = fileareas;
            }
        }

        public class Lastattempt_Status_Plugin : ICloneable, IDataModel
        {
            public Submission submission { get; set; }
            public List<object> submissiongroupmemberswhoneedtosubmit { get; set; }
            public bool submissionsenabled { get; set; }
            public bool locked { get; set; }
            public bool graded { get; set; }
            public bool canedit { get; set; }
            public bool caneditowner { get; set; }
            public bool cansubmit { get; set; }
            public object extensionduedate { get; set; }
            public bool blindmarking { get; set; }
            public string gradingstatus { get; set; }
            public List<int> usergroups { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Lastattempt_Status_Plugin(Submission submission, List<object> submissiongroupmemberswhoneedtosubmit,
                                              bool submissionsenabled, bool locked, bool graded, bool canedit, bool caneditowner,
                                              bool cansubmit, object extensionduedate, bool blindmarking,
                                              string gradingstatus, List<int> usergroups)
            {
                this.submission = submission;
                this.submissiongroupmemberswhoneedtosubmit = submissiongroupmemberswhoneedtosubmit;
                this.submissionsenabled = submissionsenabled;
                this.locked = locked;
                this.graded = graded;
                this.canedit = canedit;
                this.caneditowner = caneditowner;
                this.cansubmit = cansubmit;
                this.extensionduedate = extensionduedate;
                this.blindmarking = blindmarking;
                this.gradingstatus = gradingstatus;
                this.usergroups = usergroups;
            }
        }

        public class Submission : IDataModel, ICloneable 
        {
            public int id { get; set; }
            public int userid { get; set; }
            public int attemptnumber { get; set; }
            public int timecreated { get; set; }
            public int timemodified { get; set; }
            public string status { get; set; }
            public int groupid { get; set; }
            public int assignment { get; set; }
            public int latest { get; set; }
            public string gradingstatus { get; set; }
            public List<Plugins> plugins { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Submission(int id, int userid, int attemptnumber, int timecreated, int timemodified,
                                string status, int groupid, int assignment, int latest, List<Plugins> plugins,
                                string gradingstatus )
            {
                this.id = id;
                this.userid = userid;
                this.attemptnumber = attemptnumber;
                this.timecreated = timecreated;
                this.timemodified = timemodified;
                this.status = status;
                this.groupid = groupid;
                this.assignment = assignment;
                this.latest = latest;
                this.plugins = plugins;
                this.gradingstatus = gradingstatus;
            }
        }

        public class File : ICloneable
        {
            public string filename { get; set; }
            public string filepath { get; set; }
            public int filesize { get; set; }
            public string fileurl { get; set; }
            public int timemodified { get; set; }
            public string mimetype { get; set; }
            public bool isexternalfile { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal File(string filename, string filepath, int filesize, string fileurl, int timemodified,
                          string mimetype, bool isexternalfile)
            {
                this.filename = filename;
                this.filepath = filepath;
                this.filesize = filesize;
                this.fileurl = fileurl;
                this.timemodified = timemodified;
                this.mimetype = mimetype;
                this.isexternalfile = isexternalfile;
            }
        }

        public class Filearea : ICloneable
        {
            public string area { get; set; }
            public List<File> files { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Filearea(string area, List<File> files)
            {
                this.area = area;
                this.files = files;
            }
        }

       

        public class Editorfield : ICloneable
        {
            public string name { get; set; }
            public string description { get; set; }
            public string text { get; set; }
            public int format { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Editorfield(string name, string description, string text, int format)
            {
                this.name = name;
                this.description = description;
                this.text = text;
                this.format = format;
            }
        }
        public class Lastattempt_status_False : ICloneable, IDataModel
        {
            public Submission_status_False submission { get; set; }
            public List<object> submissiongroupmemberswhoneedtosubmit { get; set; }
            public bool submissionsenabled { get; set; }
            public bool locked { get; set; }
            public bool graded { get; set; }
            public bool canedit { get; set; }
            public bool caneditowner { get; set; }
            public bool cansubmit { get; set; }
            public object extensionduedate { get; set; }
            public bool blindmarking { get; set; }
            public string gradingstatus { get; set; }
            public List<int> usergroups { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Lastattempt_status_False(Submission_status_False submission, List<object> submissiongroupmemberswhoneedtosubmit,
                                              bool submissionsenabled, bool locked, bool graded, bool canedit, bool caneditowner, bool cansubmit,
                                              object extensionduedate, bool blindmarking, string gradingstatus, List<int> usergroups)
            {
                this.submission = submission;
                this.submissiongroupmemberswhoneedtosubmit = submissiongroupmemberswhoneedtosubmit;
                this.submissionsenabled = submissionsenabled;
                this.locked = locked;
                this.graded = graded;
                this.canedit = canedit;
                this.caneditowner = caneditowner;
                this.cansubmit = cansubmit;
                this.extensionduedate = extensionduedate;
                this.blindmarking = blindmarking;
                this.gradingstatus = gradingstatus;
                this.usergroups = usergroups;
            }
        }

        public class Plugin_status_False : ICloneable, IDataModel
        {
            public string type { get; set; }
            public string name { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Plugin_status_False(string type, string name)
            {
                this.type = type;
                this.name = name;
            }
        }

        public class Submission_status_False : ICloneable, IDataModel
        {
            public int id { get; set; }
            public int userid { get; set; }
            public int attemptnumber { get; set; }
            public int timecreated { get; set; }
            public int timemodified { get; set; }
            public string status { get; set; }
            public int groupid { get; set; }
            public int assignment { get; set; }
            public int latest { get; set; }
            public List<Plugin_status_False> plugins { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            [JsonConstructor]
            internal Submission_status_False(int id, int userid, int attemptnumber, int timecreated, int timemodified,
                                             string status, int groupid, int assignment, int latest, List<Plugin_status_False> plugins)
            {
                this.id = id;
                this.userid = userid;
                this.attemptnumber = attemptnumber;
                this.timecreated = timecreated;
                this.timemodified = timemodified;
                this.status = status;
                this.groupid = groupid;
                this.assignment = assignment;
                this.latest = latest;
                this.plugins = plugins;
            }
        }

        #endregion
        #endregion
    }
}