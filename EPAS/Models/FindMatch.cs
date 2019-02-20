
using EPAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace EPAS.Services
{
    public class FindMatch
    {
        bool flag;
        StringBuilder err = new StringBuilder();
        private AssigneeModel _asn;
        private EnhancementModel _ens;
        private VerifyModel _vrf;

        List<Jobs> Enhancementlist;
        /// <summary>
        /// Takes param from document read model
        /// </summary>
        /// <param name="assignee"></param>
        /// <param name="enhancement"></param>
        public FindMatch(AssigneeModel assignee, EnhancementModel enhancement)
        {
            this._ens = enhancement;
            this._asn = assignee;
        }
        /// <summary>
        /// This method will search for match in enhancement and asignee class
        /// </summary>
        /// <returns></returns>
        public bool Get()
        {
            //Reading Key Value from asignee and enhancement
            if (_ens.weeks.Count != 0)
            {
                for (int k = 0; k < _ens.weeks.Count; k++)
                {
                    if (_asn.asignee.ContainsKey(_ens.weeks[k].responsibility))
                    {
                        _ens.weeks[k].responsibility = _asn.asignee[_ens.weeks[k].responsibility];
                    }
                    else
                    {
                        if (!(err.ToString().Contains(_ens.weeks[k].responsibility)))
                        {
                            err.AppendLine(_ens.weeks[k].responsibility);
                        }
                        
                    }
                }
                //linq Query
                Enhancementlist = _ens.weeks
                  .GroupBy(p => new Jobs { responsibility = p.responsibility, day = p.day, week = p.week, target = p.target, approval = p.approval, })
                  .Select(g => new Jobs()
                  {
                      week = g.Key.week,
                      day = g.Key.day,
                      target = g.Key.target,
                      responsibility = g.Key.responsibility,
                      approval = g.Key.approval,
                      task = String.Concat(_ens.weeks.Where(x => x.responsibility == g.Key.responsibility && x.day == g.Key.day).Select(x => x.task).ToArray())
                  }).Distinct()
                    .ToList();

                if (err.Length != 0)
                {
                    MessageBox.Show("Position Not Found in Asignee : \n" + err.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _vrf = new VerifyModel(Enhancementlist);
                    _vrf.Show();
                    flag = true;
                }
            }
            else
            {
                flag = false;
            }
                
            return flag;

        }
    }
}
