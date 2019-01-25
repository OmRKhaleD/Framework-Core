using System;
using System.Collections.Generic;
using System.Text;

namespace Samuri.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Samurai Samuri { get; set; }
        public int SamuriId { get; set; }
    }
}
