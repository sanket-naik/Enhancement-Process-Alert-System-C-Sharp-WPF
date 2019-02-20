using EPAS.Views;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EPAS.Services
{
    public class Utilities
    {
        private string name;

        /// <summary>
        /// Cleans unwanted data \r\a
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public string Formate_string(string job)
        {
            job = job.Replace("\r\a", "");
            job = job.ToLower();
            job = job.Trim();
            return job;
        }
        /// <summary>
        /// Format the date according to outloook required format
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string Formate_date(string date)
        {
            string dy = Regex.Match(date, @"\w*([0-9]+)\w*").Value.Trim();
            string day_str = Regex.Replace(dy, "[^0-9.]", "");
            int day = Int32.Parse(day_str);

            string mon = date.Replace(dy, "").Trim();
            int month = DateTime.ParseExact(mon, "MMMM", CultureInfo.InvariantCulture).Month;

            int year = @DateTime.Now.Year;
            string Dateformate = month + "/" + day + "/" + year + " ";

            return Dateformate;
        }
        /// <summary>
        /// Format email from to outlook mail format
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Formate_email(string name)
        {
            name = Formate_string(name);
            name = name.Replace(" ", ".");
            name = name + "@cerner.com";
            return name;
        }
        /// <summary>
        /// File dialog for document upload
        /// </summary>
        /// <returns></returns>
        public string FileDiloge()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".docx";
            openFileDialog.Filter = "Word Document (.docx)|*.docx";

            if (openFileDialog.ShowDialog() == true)
            {
                name = openFileDialog.FileName;
            }
            return name;
        }
    }
}