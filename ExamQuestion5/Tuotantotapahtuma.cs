using System;
using System.Collections.Generic;
using System.Text;

namespace ExamQuestion4
{
    class Tuotantotapahtuma
    {
        public int KoneID { get; set; }
        public string KoneenNimi { get; set; }
        public int TuoteID { get; set; }
        public int KoneAika { get; set; }
        public Tuotantotapahtuma(int koneId, string koneenNimi, int tuoteId, int koneAika)
        {
            this.KoneID = koneId;
            this.KoneenNimi = koneenNimi;
            this.TuoteID = tuoteId;
            this.KoneAika = koneAika;
        }

        public override string ToString()
        {
            return KoneID + " " + KoneenNimi + " " + TuoteID + " " + KoneAika;
        }
    }
}
