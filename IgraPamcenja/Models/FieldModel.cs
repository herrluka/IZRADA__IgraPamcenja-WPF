using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraPamcenja.Models
{
    public enum FieldStatus
    {
        RESOLVED,
        NOT_RESOLVED
    }

    public class FieldModel
    {
        private int value;
        public int Value { get { return value; } }
        public FieldStatus Status { get; set; }

        public FieldModel(int value)
        {
            this.value = value;
            Status = FieldStatus.NOT_RESOLVED;
        }
    }
}
