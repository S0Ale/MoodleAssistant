﻿using Microsoft.AspNetCore.Components.Forms;

namespace MoodleAssistant.Services;

// Represents a service that manages the uploaded BrowserFiles during a user session.
public interface IBrowserFileService{
    public Task<bool> SaveFile(IBrowserFile file, string fileName);

    public FileStream GetFile(string fileName);

    public FileInfo GetFileInfo(string fileName);

    public void DeleteFile(string fileName);

    public void DeleteAllFiles();
    string GetBase64(string filename);
}