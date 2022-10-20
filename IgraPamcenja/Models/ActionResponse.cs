using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraPamcenja.Models
{
    public enum ResponseType
    {
        FIRST_FIELD_SELECTED,
        MATCHING,
        NOT_MATCHING,
        GAME_ENDED
    }

    public class ActionResponse
    {
        public int? FieldIndex1 { get; set; }
        public int? FieldValue1 { get; set; }
        public int? FieldIndex2 { get; set; }
        public int? FieldValue2 { get; set; }
        public ResponseType Type { get; set; }
    }
}
