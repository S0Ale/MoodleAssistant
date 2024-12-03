using System.Text;
using System.Text.RegularExpressions;

namespace MoodleAssistant.Classes.Parse;

public class FileParameter : Parameter{
    private static readonly string ImageTagOpen = "<img src=\"@@PLUGINFILE@@";
    private static readonly string ImageTagClose = "\" />";
    
    public FileParameter(Match m) : base(m){
        Name = m.Groups[2].Value;
    }
    
    //public void 6
    
    public override StringBuilder Replace(StringBuilder builder){ // needs a way to put the file in the correct place, needs a XmlDocument object
        builder = builder.Remove(Match.Index, Match.Length);
        builder = builder.Insert(Match.Index, $"{ImageTagOpen}/{Replacement}{ImageTagClose}");
        return builder;
    }
    
    // need to verify presence of CDATA tag in the file, if not present, add it | <![CDATA[...]]>
}