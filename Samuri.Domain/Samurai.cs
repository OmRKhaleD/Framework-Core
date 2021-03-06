﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Samuri.Domain
{
    public class Samurai
    {
        public Samurai()
        {
            Quotes = new List<Quote>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Quote> Quotes { get; set; }

        // public int BattleId { get; set; }
        public List<SumariBattle> SumariBattles { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
    }
}
