using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace EPAS.Services
{
    public class AssigneeModel
    {
        /// <summary>
        /// Parsing of Assignee File
        /// </summary>
        bool Result = false;
        Word.Application app = new Word.Application();
        Document doc;
        public Dictionary<string, string> asignee;
        private Utilities _clean;

        public AssigneeModel()
        {
            _clean = new Utilities();
        }
        /// <summary>
        /// Takes the asigneePath as a input and parse data
        /// </summary>
        /// <param name="asigneePath"></param>
        /// <returns></returns>
        public bool Read(string asigneePath)
        {
            try
            {
                Documents docs = app.Documents;
                doc = docs.Open(@asigneePath, ReadOnly: true);
                Table tbl = doc.Tables[1];
                Range rng = tbl.Range;
                Cells dcells = rng.Cells;
                Columns clm = rng.Columns;
                Rows rows = rng.Rows;

                int columncount = clm.Count;
                int rowcount = rows.Count;

                asignee = new Dictionary<string, string>();

                if (rowcount==2)
                {
                    //Parsing table
                    for (int i = 1; i <= columncount; i++)
                    {
                        string name = dcells[i + columncount].Range.Text;
                        name = _clean.Formate_email(name);

                        byte[] byt = Encoding.Default.GetBytes(dcells[i].Range.Text);
                        string position = Encoding.UTF8.GetString(byt);
                        position = _clean.Formate_string(position);

                        asignee.Add(position, name);
                    }
                    Result = true;
                }
                else
                {
                    Result = false;
                }

                doc.Close();
                app.Quit();
            }
            catch
            {
                Result= false;
            }
            return Result;

        }
    }
}
