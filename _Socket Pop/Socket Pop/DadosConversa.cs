using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatProdan
{
    [Serializable]
    public class DadosConversa
    {
        public string ReceiverIP { get; set; }

        public string ReceiverTCP { get; set; }

        public string ReceiverUSER { get; set; }

        public string ReceiverStatus { get; set; }

        public string SenderUSER { get; set; }

        public string SenderIP { get; set; }

    }
}
