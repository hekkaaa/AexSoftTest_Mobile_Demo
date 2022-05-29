using System;
using System.Collections.Generic;
using System.Text;

namespace AexSoftTest.Models
{
    public class Comic : PrintEdition
    {
        public string IssueNumber { get; set; }
        public string Universe { get; set; }
    }
}
