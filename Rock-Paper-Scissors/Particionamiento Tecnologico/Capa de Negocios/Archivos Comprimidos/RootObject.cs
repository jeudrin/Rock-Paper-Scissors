﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Negocios.Archivos_Comprimidos
{
    public class RootObject
    {
        public object in_reply_to_status_id { get; set; }
        public string text { get; set; }
        public Activities activities { get; set; }
        public string in_reply_to_screen_name { get; set; }
        public bool truncated { get; set; }
        public bool retweeted { get; set; }
        public object in_reply_to_status_id_str { get; set; }
        public string source { get; set; }
        public string created_at { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public object geo { get; set; }
        public int retweet_count { get; set; }
        public object contributors { get; set; }
        public string id_str { get; set; }
        public Entities entities { get; set; }
        public object place { get; set; }
        public object coordinates { get; set; }
        public User user { get; set; }
        public int in_reply_to_user_id { get; set; }
        public long id { get; set; }
        public bool favorited { get; set; }
    }
}