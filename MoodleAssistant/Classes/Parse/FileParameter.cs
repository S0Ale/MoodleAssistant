using System.Text.RegularExpressions;

namespace MoodleAssistant.Classes.Parse;

public class FileParameter : Parameter{
    public FileParameter(Match m) : base(m){
        Name = m.Groups[2].Value;
    }
}