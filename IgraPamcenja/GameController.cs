using IgraPamcenja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraPamcenja
{
    public class GameController
    {
        private Dictionary<int, FieldModel> dictionary = new Dictionary<int, FieldModel>();
        private int? previouslyClickedIndex;

        public void InitializeGame()
        {
            dictionary.Clear();
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            // Shuffle list
            list = list.OrderBy(a => Guid.NewGuid()).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                dictionary.Add(i, new FieldModel(list[i]));
            }
        }

        public ActionResponse FieldClicked(int fieldIndex)
        {
            var field = dictionary.GetValueOrDefault(fieldIndex);
            if (field.Status.Equals(FieldStatus.RESOLVED))
            {
                return null;
            }

            if (previouslyClickedIndex == null)
            {
                previouslyClickedIndex = fieldIndex;
                ActionResponse response = new();
                response.FieldIndex1 = fieldIndex;
                response.FieldValue1 = dictionary.GetValueOrDefault(fieldIndex).Value;
                response.Type = ResponseType.FIRST_FIELD_SELECTED;
                return response;
            } else
            {
                if (previouslyClickedIndex == fieldIndex)
                {
                    return null;
                } 
                else
                {
                    var field1 = dictionary.GetValueOrDefault((int)previouslyClickedIndex);
                    var field2 = dictionary.GetValueOrDefault(fieldIndex);

                    ActionResponse response = new();
                    response.FieldIndex1 = previouslyClickedIndex;
                    response.FieldValue1 = field1.Value;
                    response.FieldIndex2 = fieldIndex;
                    response.FieldValue2 = field2.Value;

                    if (field1.Value == field2.Value)
                    {
                        response.Type = ResponseType.MATCHING;
                        field1.Status = FieldStatus.RESOLVED;
                        field2.Status = FieldStatus.RESOLVED;
                    } else
                    {
                        response.Type = ResponseType.NOT_MATCHING;
                    }
                    
                    previouslyClickedIndex = null;

                    if (dictionary.Values.Count(item => item.Status.Equals(FieldStatus.NOT_RESOLVED)) == 0)
                    {
                        response.Type = ResponseType.GAME_ENDED;
                    }

                    return response;

                }
            }

            return null;
        }
    }
}
