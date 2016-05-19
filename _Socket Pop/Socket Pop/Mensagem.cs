using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatProdan
{
    [Serializable]
    public class Mensagem 
    {
        public string ReceiverIP { get; set; }

        public string ReceiverUSER { get; set; }

        public string SenderUSER { get; set; }

        public string SenderIP { get; set; }

        public string MENSAGEM { get; set; }

        public string TIMESTAMP { get; set; }

        public string EVENTO { get; set; }

    }
}
