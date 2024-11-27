using System.Text.RegularExpressions;

namespace MoodleAssistant.Parse;

public class FileParameter : Parameter {

    public FileParameter(Match m) : base(m){
        Name = m.Groups[2].Value;
    }

}
