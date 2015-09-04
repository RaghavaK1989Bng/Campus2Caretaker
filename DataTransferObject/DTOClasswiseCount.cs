using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
    public class DTOClasswiseCount
    {
        private string _className;

        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        private int? _count;

        public int? Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _subjectName;

        public string SubjectName
        {
            get { return _subjectName; }
            set { _subjectName = value; }
        }


    }
}
