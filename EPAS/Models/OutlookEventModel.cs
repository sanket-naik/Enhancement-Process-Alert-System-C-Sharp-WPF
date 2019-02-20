using System;
using System.Text;
using Windows=System.Windows;
using Outlook = Microsoft.Office.Interop.Outlook;
using EPAS.Models;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;
using System.Windows;

namespace EPAS.Services
{
    /// <summary>
    /// Event Scheduler
    /// </summary>
    public class OutlookEventModel
    {
        private Utilities _uts;
       // private LoginView _login;
        List<Jobs> Datalist = new List<Jobs>();
        StringBuilder sb = new StringBuilder();
        bool flag = false;
        Accounts accounts;
        Outlook.Application App;

        /// <summary>
        /// Takes list from Verify view
        /// </summary>
        /// <param name="list"></param>
        public OutlookEventModel(List<Jobs> list)
        {
            this.Datalist = list;
            _uts = new Utilities();
        }
        /// <summary>
        /// Schedules the events that are in the list
        /// </summary>
        /// <returns></returns>
        public bool Event()
        {
            try
            {
                App = new Outlook.Application();
                accounts = App.Session.Accounts;

                try
                {
                    string msg = "Are you sure you want to send ?";
                    MessageBoxResult result =
                      MessageBox.Show(
                        msg,
                        "Confirmation",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (Jobs j in Datalist)
                        {
                            sb.AppendLine("Hello Associate").AppendLine("You are assigned with a task:\n");
                            TaskItem oTask = (TaskItem)App.CreateItem(OlItemType.olTaskItem);
                            oTask.Subject = "Do It By " + j.target.ToUpper();
                            string date = _uts.Formate_date(j.day);
                            oTask.StartDate = Convert.ToDateTime(date + "8:26 AM");
                            oTask.DueDate = Convert.ToDateTime(date + "9:28 AM");
                            oTask.ReminderSet = true;
                            oTask.ReminderTime = Convert.ToDateTime(date + "9:27 AM");
                            sb.AppendLine(j.task);
                            sb.AppendLine("Thank You");
                            oTask.Body = sb.ToString();
                            oTask.SchedulePlusPriority = "Medium";
                            oTask.Status = OlTaskStatus.olTaskInProgress;
                            oTask.Save();
                            sb.Length = 0;

                            //Send task
                            Recipients oRecipients = oTask.Recipients;
                            Recipient oReceipient;
                            oReceipient = oRecipients.Add(j.responsibility);
                            oReceipient.Type = 1;
                            oRecipients.ResolveAll();
                            oTask.Assign();

                            foreach (Account account in accounts)
                            {
                                if (j.responsibility != account.DisplayName.ToLower())
                                {
                                    oTask.Send();
                                }
                            }

                        }
                        flag = true;
                        Windows.MessageBox.Show("Events Successfully Sent", "Success", Windows.MessageBoxButton.OK, Windows.MessageBoxImage.Information);
                      //  _login.Show();
                    }
                
                }
                catch (System.Exception)
                {
                    flag = false;
                    MessageBox.Show(
                        "Event Scheduling Error, Invalid Name Given In Assignee!!", 
                        "Error", 
                        Windows.MessageBoxButton.OK, 
                        Windows.MessageBoxImage.Error);
                }
               

            }
            catch (System.Exception)
            {
                MessageBox.Show("You Dosn't Have Microsoft Outlook Installed!!!");
            }

            return flag;
        }
    }
}