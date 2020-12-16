using System.Collections.Generic;
using System.Linq;

namespace QuestionEvaluator
{
    public class MultipleChoiceQuestionEvaluator
    {
        public static AssessmentResult GetResults(List<MultiChoiceItem> multiChoiceItems, Dictionary<int, int> responses)
        {
            var correctItems = GetCorrectItems(multiChoiceItems, responses);
            
            return new AssessmentResult { 
                ItemsAttempted = responses.Keys.Count(),
                ItemsCorrect = correctItems.Count(),
                TotalMarksAwarded = correctItems.Sum(item => item.MarksAwardedIfCorrect)
            };
        }

        private static List<MultiChoiceItem> GetCorrectItems(List<MultiChoiceItem> multiChoiceItems, Dictionary<int, int> responses)
        {
            return (from int index in responses.Keys
                    let choice = multiChoiceItems[index]
                    where choice.CorrectAnswerIndex == responses[index]
                    select choice).ToList();
        }
    }
}
