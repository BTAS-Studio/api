using System;
using System.Collections.Generic;

namespace BTAS.API.Dto
{
    public class tbl_milestone_masterDto
    {
        public int idtbl_milestone_master { get; set; }
        public string code { get; set; }
        public DateTime masterCut { get; set; }
        public DateTime etd { get; set; }
        public DateTime available { get; set; }
        //public DateTime tbl_milestone_origDocument { get; set; }
        public DateTime ediReceive { get; set; }
        public DateTime etaDischarge { get; set; }
        public DateTime etaDestination { get; set; }
        public DateTime ataDestination { get; set; }
        public DateTime boundArrival { get; set; }
        public DateTime excptReportSent { get; set; }
        public DateTime lastMileCarrier { get; set; }

        //master one to one relationship with tbl_milestone_master
        public virtual tbl_masterDto master { get; set; }
        //original document  one to one relationship with tbl_document
        public virtual tbl_documentDto originalDocument { get; set;}
    }
}
