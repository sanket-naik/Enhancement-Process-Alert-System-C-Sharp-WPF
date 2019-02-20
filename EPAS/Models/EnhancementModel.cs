using EPAS.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace EPAS.Services
{
    public class EnhancementModel
    {
        /// <summary>
        /// Parsing of Enhancement File
        /// </summary>
        bool Result = false;
        Word.Application app = new Word.Application();
        Document doc;
        private Utilities _clean;
        public List<Jobs> weeks = new List<Jobs>();

        public EnhancementModel()
        {
            _clean = new Utilities();
        }
        /// <summary>
        /// Takes enhancementPath as input and parse data
        /// </summary>
        /// <param name="enhancementPath"></param>
        /// <returns></returns>
        public bool Read(string enhancementPath)
        {
            try
            {
                Documents docs = app.Documents;
                doc = docs.Open(@enhancementPath, ReadOnly: true);
                Table tbl = doc.Tables[1];
                Range rng = tbl.Range;
                Rows rows = rng.Rows;
                Cells dcells = rng.Cells;

                //Counts rows of week
                int weekcount = rows.Count;
                int count = weekcount - 1;

                //Read week index
                List<string> indx = new List<string>();
                for (int j = 4; j <= dcells.Count; j = j + 2)
                {
                    string date = dcells[j].Range.Text;
                    indx.Add(date);
                }

                //Getting week tables
                for (int i = 2; i <= weekcount; i++)
                {
                    Table t = doc.Tables[i];
                    Range r = t.Range;
                    Cells wcells = r.Cells;
                    string date = indx[i - 2];
                    date = _clean.Formate_string(date);

                    //Column count
                    Columns clm = t.Columns;
                    int columncount = clm.Count;

                    if(columncount==4 || columncount==3)
                    {
                        for (int j = columncount + 1; j <= wcells.Count; j = j + columncount)
                        {

                            string target = wcells[j].Range.Text;
                            target = _clean.Formate_string(target);

                            string resp = wcells[j + 1].Range.Text;
                            resp = _clean.Formate_string(resp);

                            string task = wcells[j + 2].Range.Text;

                            string approve;

                            if (columncount == 3)
                            {
                                approve = "None";
                            }
                            else
                            {
                                approve = wcells[j + 3].Range.Text;
                                approve = _clean.Formate_string(approve);
                            }

                            if (approve == "")
                            {
                                approve = "None";
                            }


                            Jobs week = new Jobs()
                            {
                                day = date,
                                target = target,
                                responsibility = resp,
                                task = task,
                                approval = approve,
                                week = count
                            };
                            weeks.Add(week);
                        }
                        count--;
                        Result = true;
                    }
                    else
                    {
                        Result = false;
                    }
                    
                }

                doc.Close();
                app.Quit();
            }
            catch (Exception)
            {
                Result=false;
            }
            return Result;
        }
    }
}
