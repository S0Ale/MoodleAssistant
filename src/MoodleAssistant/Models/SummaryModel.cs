using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodleAssistant.Models
{
    public class SummaryModel
    {
        public string QuestionText;

        public IEnumerable<string> QuestionParametersList;

        public IEnumerable<string> AnswersTextList;

        public IEnumerable<string> AnswerParametersList;

    }
}
