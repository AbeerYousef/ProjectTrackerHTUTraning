using FinalProject.Data;
using FinalProject.Dto;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public class WorkRep : IWorkRep
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public WorkRep(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public List<Work> GetSprintTaskWorks(int SprintTaskId)
        {

            return db.Works.Include(x => x.SprintTask).Where(x => x.SprintTaskId == SprintTaskId).ToList(); ;
        }


        public Work GetWork(int WorkId)
        {
            return db.Works.Where(x => x.Id == WorkId).FirstOrDefault();
        }

        public List<SprintTask> GetWorks(int SprintTaskId, String DeveloperId)
        {
            var SprintTasks= db.SprintTasks.Include(x => x.Works).ThenInclude(x => x.Developer).Where(x => x.DeveloperId == DeveloperId && x.Id == SprintTaskId).ToList();
            return SprintTasks;
        }

        public void InsertWork(WorkDto WorkDto, String DeveloperId)
        {

            var NewWork = new Work()
            {
                Title = WorkDto.Title,
                Description = WorkDto.Description,
                DeveloperId = DeveloperId,
                SprintTaskId = WorkDto.SprintTaskId,
            };
            NewWork.StatusWork = (WorkStatus)WorkDto.StatusWorkDto;
            //open stream
            Stream stream = WorkDto.TheFile.OpenReadStream();
            //
            using (BinaryReader Br = new BinaryReader(stream))
            {
                //convert file to array of byte  .... Read byte
                var ByteFile = Br.ReadBytes((int)stream.Length);
                NewWork.FileName = WorkDto.TheFile.FileName;
                NewWork.ContentType = WorkDto.TheFile.ContentType;
                NewWork.TheFile = ByteFile;
            }
            db.Works.Add(NewWork);
            db.SaveChanges();
        }
   
        public void UpdateWork(WorkDto WorkDto)
        {

            var work = db.Works.Where(x => x.Id == WorkDto.Id).FirstOrDefault();
            if (work.StatusWork == (WorkStatus)3)
            {

                //This update after rejected send email and change status to pinding

                work.StatusWork = (WorkStatus)1;
            }
            work.Title = WorkDto.Title;
            work.Description = WorkDto.Description;
            work.Title = WorkDto.Title;

            //open stream
            Stream stream = WorkDto.TheFile.OpenReadStream();
            //
            using (BinaryReader Br = new BinaryReader(stream))
            {
                //convert file to array of byte  .... Read byte
                var ByteFile = Br.ReadBytes((int)stream.Length);
                work.FileName = WorkDto.TheFile.FileName;
                work.ContentType = WorkDto.TheFile.ContentType;
                work.TheFile = ByteFile;
            }
            db.Works.Update(work);
            db.SaveChanges();

        }

        public void RejectedWork(int WorkId, string RejectionNote)
        {
            var Work = GetWork(WorkId);
            Work.StatusWork = (WorkStatus)3;
            Work.RejectionNote = RejectionNote;
            db.Works.Update(Work);
            db.SaveChanges();

        }

        public void ApprovedWork(int WorkId)
        {
            var Work = GetWork(WorkId);
            Work.StatusWork = (WorkStatus)2;
            Work.RejectionNote = null;
            db.Works.Update(Work);
            db.SaveChanges();
        }

        public bool IsAllWorksApproved(int SprintTaskId)
        {
            var Works = GetSprintTaskWorks(SprintTaskId);
            var IsAllApproved = true;
            if (Works.Count() == 0)  //It is Emtey The Developer not creat Work yet
            {
                //////For Test If Ther Is chang on DB
                IsAllApproved = false; //SprintTask should be Pending

                var SprintTask = db.SprintTasks.Where(x => x.Id == SprintTaskId).FirstOrDefault();
                SprintTask.StatusSprintTask = (SprintTaskStatus)1;
                db.SprintTasks.Update(SprintTask);
                db.SaveChanges();

                //And Sprint should be Pending
                var Sprint = db.Sprints.Where(x => x.Id == SprintTask.SprintId).FirstOrDefault();
                Sprint.StatusSprint = (SprintStatus)1;
                db.Sprints.Update(Sprint);
                db.SaveChanges();

                //
                //And Project should be Pending
                var Project = db.Projects.Where(x => x.Id == Sprint.ProjectId).FirstOrDefault();
                Project.StatusProject = (ProjectStatus)1;
                db.Projects.Update(Project);
                db.SaveChanges();
            }

            foreach (var Work in Works)  //Is All works for this SprintTask  Approved ?
            {
                if (Work.StatusWork != (WorkStatus)2) // If one is not Approved
                {
                    IsAllApproved = false; //SprintTask should be Pending
                    //var SprintTask = db.SprintTasks.Where(x => x.Id == SprintTaskId).FirstOrDefault();
                    //SprintTask.StatusSprintTask = (SprintTaskStatus)1;
                    //db.SprintTasks.Update(SprintTask);
                    //db.SaveChanges();
                    ////And Sprint should be Pending
                    //var Sprint = db.Sprints.Where(x => x.Id == SprintTask.SprintId).FirstOrDefault();
                    //Sprint.StatusSprint = (SprintStatus)1;
                    //db.Sprints.Update(Sprint);
                    //db.SaveChanges();

                    ////
                    ////And Project should be Pending
                    //var Project = db.Projects.Where(x => x.Id == Sprint.ProjectId).FirstOrDefault();
                    //Project.StatusProject = (ProjectStatus)1;
                    //db.Projects.Update(Project);
                    //db.SaveChanges();
                    break;
                }

            }
            return IsAllApproved;
        }


        public void SendMail(TeamLeader TeamLeader, Developer Developer)
        {
            using (var message = new MailMessage())
            {

                message.To.Add(new MailAddress("Abeeryosef67@gmail.com")); //the reseve....> one or list of emails
                message.From = new MailAddress("Abeeryosef67@gmail.com");  //the sender email ....> Developer login
                message.Subject = "Please check your email to receive the work";
                var TeamLeaderName = TeamLeader.FirstName + " " + TeamLeader.LastName;
                var DeveloperName = Developer.FirstName + " " + Developer.LastName;
                message.Body = $"Dear {TeamLeaderName},<br/><br/>I hope you are well when you receive my email<br/>Send you the required work attached to this email.< br />I hope the work is good and accepted by you.< br />Sincerely <br/> {DeveloperName} ";
                message.IsBodyHtml = true;
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587)) /// for google...> smtp.gmail.com , for office365 .....>smtp.office365.com
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("Abeeryosef67@gmail.com", "a0796040518");

                    smtpClient.Send(message);
                }
            }
        }

        public void DeletWork(Work Work)
        {
            db.Works.Remove(Work);
            db.SaveChanges();
        }
    }
}
