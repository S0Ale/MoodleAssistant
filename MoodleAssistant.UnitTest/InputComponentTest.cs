using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using MoodleAssistant.Components.Upload;

namespace MoodleAssistant.UnitTest;

internal class InputComponentTest : FileUploadTest{
    
    private IRenderedComponent<DropFileInput> cut;
    
    [SetUp]
    public new void Setup(){
        cut = Ctx.Render<DropFileInput>(param => param
            .Add(p => p.InputName, "test")
            .Add(p => p.MaxFiles, 3)
        );
    }

    [Test]
    public void Upload_AllAtOnce(){
        var word1 = TestService.Create("Test1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word2 = TestService.Create("Test2.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word3 = TestService.Create("Test3.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        
        var labels = cut.FindComponents<CustomLabel>();
        labels[0].FindComponent<InputFile>().UploadFiles(word1, word2, word3);
        
        Assert.That(cut.Instance.UploadedFiles, Has.Count.EqualTo(3));
    }
    
    [Test]
    public void Upload_OneAtATime(){
        var word1 = TestService.Create("Test1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word2 = TestService.Create("Test2.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var word3 = TestService.Create("Test3.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        var words = new[] {word1, word2, word3};
        
        var labels = cut.FindComponents<CustomLabel>();
        for(var i = 0; i < 3; i++){
            labels[i].FindComponent<InputFile>().UploadFiles(words[i]);
        }
        
        Assert.That(cut.Instance.UploadedFiles, Has.Count.EqualTo(3));
    }

    [TearDown]
    public new void TearDown(){
        cut.Dispose();
    }
}