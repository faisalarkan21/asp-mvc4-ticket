﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tiket_airlines.Models
{
    public class Gabungan
    {
        public pembeli tblPembeli { get; set; }
        public pembeli_validasi tblValidasi { get; set; }
        public detil_pesan_tiket tblDetailTiket { get; set; }
        public string rp_bandara_berangkat { get; set; }
        public string rp_bandara_tujuan { get; set; }
        public string nm_bandara_berangkat { get; set; }
        public string nm_bandara_tujuan { get; set; }
        public string rp_harga_tiket { get; set; }


    }
}